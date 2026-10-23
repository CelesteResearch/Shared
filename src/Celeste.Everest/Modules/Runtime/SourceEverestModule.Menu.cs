using System;
using System.Reflection;
using Celeste.Audio.Fmod.Events;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Settings.Metadata;
using Celeste.Everest.UI.Controls;
using Celeste.Everest.UI.Settings;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Options;
using Celeste.Game.Menus.Overworld;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using TextMenu = Celeste.Simulation.UI.Menus.Text.TextMenuPresentation;
using ButtonBinding = Celeste.Everest.Input.Bindings.EverestButtonBinding;
using OuiNumberEntry = Celeste.Everest.UI.Settings.EverestNumberEntryState;
using OuiModOptionString = Celeste.Everest.UI.Settings.EverestModOptionStringState;
using OuiModOptions = Celeste.Everest.UI.ModOptions.EverestModOptionsState;

namespace Celeste.Everest.Modules.Runtime
{
    public abstract partial class SourceEverestModule
    {
        protected virtual void CreateModMenuSectionHeader(TextMenu menu, bool inGame, FmodEventReference snapshot)
        {
            var settingsType = SettingsType;
            var settings = _Settings;
            if (!(!(settingsType == null) && settings != null))
                return;
            var text = ReadMenuTypeName(settingsType).ToLowerInvariant();
            if (text.EndsWith("settings")) text = text.Substring(0, text.Length - 8);

            var text2 = "modoptions_" + text + "_";
            var input = settingsType.GetCustomAttribute<SettingNameAttribute>()?.Name ?? text2 + "title";
            input = EverestModuleDialogText.CleanOrNull(SourceEngine, input) ??
                    ((IEverestModUpdaterEnvironment)SourceEngine).ModUpdater.FormatModName(Metadata.Name);
            menu.Add(new TextMenu.SubHeader(input + " | v." + Metadata.VersionString));
        }

        protected virtual void CreateModMenuSectionKeyBindings(TextMenu menu, bool inGame, FmodEventReference snapshot)
        {
            menu.Add(new TextMenu.Button(
                ((IOriginalGameTextEnvironment)SourceEngine).Text.Dialog.Clean("options_keyconfig")).Pressed(delegate
            {
                menu.Focused = false;
                ((ISourceScene)SourceEngine.Frame.Scenes.CurrentScene).SourceScene.QueueSourceEntity(
                    CreateKeyboardConfigUI(menu));
                ((ISourceScene)SourceEngine.Frame.Scenes.CurrentScene).SourceScene.OnEndOfFrame += delegate
                {
                    ((ISourceScene)SourceEngine.Frame.Scenes.CurrentScene).SourceScene.CommitQueuedEntityLists();
                };
            }));
            menu.Add(new TextMenu.Button(
                ((IOriginalGameTextEnvironment)SourceEngine).Text.Dialog.Clean("options_btnconfig")).Pressed(delegate
            {
                menu.Focused = false;
                ((ISourceScene)SourceEngine.Frame.Scenes.CurrentScene).SourceScene.QueueSourceEntity(
                    CreateButtonConfigUI(menu));
                ((ISourceScene)SourceEngine.Frame.Scenes.CurrentScene).SourceScene.OnEndOfFrame += delegate
                {
                    ((ISourceScene)SourceEngine.Frame.Scenes.CurrentScene).SourceScene.CommitQueuedEntityLists();
                };
            }));
        }

        private SceneEntityState CreateKeyboardConfigUI(TextMenu menu)
        {
            return new ModuleSettingsKeyboardConfigUI(this, SourceEngine,
                ((IOriginalMenuOptionsEnvironment)SourceEngine).MenuOptions)
            {
                OnClose = delegate { menu.Focused = true; },
            };
        }

        private SceneEntityState CreateButtonConfigUI(TextMenu menu)
        {
            return new ModuleSettingsButtonConfigUI(this, SourceEngine,
                ((IOriginalMenuOptionsEnvironment)SourceEngine).MenuOptions)
            {
                OnClose = delegate { menu.Focused = true; },
            };
        }

        /// <summary>
        ///     Create the mod menu subsection including the section header in the given menu.
        ///     The default implementation uses reflection to attempt creating a menu.
        /// </summary>
        /// <param name="menu">Menu to add the section to.</param>
        /// <param name="inGame">Whether we're in-game (paused) or in the main menu.</param>
        /// <param name="snapshot">The Level.PauseSnapshot</param>
        public virtual void CreateModMenuSection(TextMenu menu, bool inGame, FmodEventReference snapshot)
        {
            var settingsType = SettingsType;
            var settings = _Settings;
            if (settingsType == null || settings == null) return;

            var text = ReadMenuTypeName(settingsType).ToLowerInvariant();
            if (text.EndsWith("settings")) text = text.Substring(0, text.Length - 8);

            var nameDefaultPrefix = "modoptions_" + text + "_";
            SettingInGameAttribute attribInGame;
            if ((attribInGame = settingsType.GetCustomAttribute<SettingInGameAttribute>()) != null &&
                attribInGame.InGame != inGame)
                return;

            var flag = false;
            if (GetType().GetMethod("CreateModMenuSection").DeclaringType != typeof(SourceEverestModule))
            {
                CreateModMenuSectionHeader(menu, inGame, snapshot);
                flag = true;
            }

            PropertyInfo[] array;
            if (settingsType == _PrevSettingsType)
            {
                array = _PrevSettingsProps;
            }
            else
            {
                array = _PrevSettingsProps = settingsType.GetProperties();
                _PrevSettingsType = settingsType;
            }

            var array2 = array;
            SettingRangeAttribute attribRange;
            SettingNumberInputAttribute attribNumber;
            foreach (var propertyInfo in array2)
            {
                var input = propertyInfo.GetCustomAttribute<SettingNameAttribute>()?.Name ??
                            nameDefaultPrefix + propertyInfo.Name.ToLowerInvariant();
                input = EverestModuleDialogText.CleanOrNull(SourceEngine, input) ??
                        EverestStringSource.SpacedPascalCase(propertyInfo.Name);
                var method = settingsType.GetMethod("Create" + propertyInfo.Name + "Entry",
                    BindingFlags.Instance | BindingFlags.Public, null, [
                        typeof(TextMenu),
                        typeof(bool),
                    ], /* ReSharper disable once UseCollectionExpression */ new ParameterModifier[0]);
                if (method != null)
                {
                    if (!flag)
                    {
                        CreateModMenuSectionHeader(menu, inGame, snapshot);
                        flag = true;
                    }

                    ((Action<TextMenu, bool>)method.CreateDelegate(typeof(Action<TextMenu, bool>), settings))(menu,
                        inGame);
                    continue;
                }

                var item = CreateItem(propertyInfo, input);
                if (item == null && propertyInfo.PropertyType.GetCustomAttribute<SettingSubMenuAttribute>() != null)
                {
                    var obj = propertyInfo.GetValue(settings);
                    if (obj == null)
                        propertyInfo.SetValue(settings, obj = Activator.CreateInstance(propertyInfo.PropertyType));

                    var subMenu = new EverestSubMenu(menu.Resources, input, false);
                    var properties = propertyInfo.PropertyType.GetProperties();
                    foreach (var propertyInfo2 in properties)
                    {
                        method = propertyInfo.PropertyType.GetMethod("Create" + propertyInfo2.Name + "Entry",
                            BindingFlags.Instance | BindingFlags.Public, null, [
                                typeof(EverestSubMenu),
                                typeof(bool),
                            ], /* ReSharper disable once UseCollectionExpression */ new ParameterModifier[0]);
                        if (method != null)
                        {
                            ((Action<EverestSubMenu, bool>)method.CreateDelegate(typeof(Action<EverestSubMenu, bool>),
                                obj))(subMenu, inGame);
                            continue;
                        }

                        var item2 = CreateItem(propertyInfo2, null, obj);
                        if (item2 != null)
                        {
                            var text2 = propertyInfo2.GetCustomAttribute<SettingSubHeaderAttribute>()?.SubHeader;
                            if (text2 != null)
                                subMenu.Add(new TextMenu.SubHeader(
                                    EverestModuleDialogText.CleanOrNull(SourceEngine, text2) ?? text2,
                                    false));

                            subMenu.Add(item2);
                            var text3 = propertyInfo2.GetCustomAttribute<SettingSubTextAttribute>()?.Description;
                            if (text3 != null)
                                item2.AddDescription(subMenu, menu,
                                    EverestModuleDialogText.CleanOrNull(SourceEngine, text3) ?? text3);
                        }
                    }

                    item = subMenu;
                }

                if (item != null)
                {
                    if (!flag)
                    {
                        CreateModMenuSectionHeader(menu, inGame, snapshot);
                        flag = true;
                    }

                    var text4 = propertyInfo.GetCustomAttribute<SettingSubHeaderAttribute>()?.SubHeader;
                    if (text4 != null)
                        menu.Add(new TextMenu.SubHeader(
                            EverestModuleDialogText.CleanOrNull(SourceEngine, text4) ?? text4,
                            false));

                    menu.Add(item);
                    if (propertyInfo.GetCustomAttribute<SettingNeedsRelaunchAttribute>() != null)
                        item.NeedsRelaunch(menu);

                    var text5 = propertyInfo.GetCustomAttribute<SettingSubTextAttribute>()?.Description;
                    if (text5 != null)
                        item.AddDescription(menu, EverestModuleDialogText.CleanOrNull(SourceEngine, text5) ?? text5);
                }
            }

            array2 = settingsType.GetProperties();
            foreach (var propertyInfo3 in array2)
                if (((attribInGame = propertyInfo3.GetCustomAttribute<SettingInGameAttribute>()) == null ||
                     attribInGame.InGame == inGame) &&
                    propertyInfo3.GetCustomAttribute<SettingIgnoreAttribute>() == null &&
                    propertyInfo3.CanRead && propertyInfo3.CanWrite &&
                    typeof(ButtonBinding).IsAssignableFrom(propertyInfo3.PropertyType))
                {
                    if (!flag)
                    {
                        CreateModMenuSectionHeader(menu, inGame, snapshot);
                        flag = true;
                    }

                    CreateModMenuSectionKeyBindings(menu, inGame, snapshot);
                    break;
                }

            TextMenu.Item CreateItem(PropertyInfo prop, string name = null, object settingsObject = null)
            {
                if (settingsObject == null) settingsObject = settings;

                if ((attribInGame = prop.GetCustomAttribute<SettingInGameAttribute>()) != null &&
                    attribInGame.InGame != inGame)
                    return null;

                if (prop.GetCustomAttribute<SettingIgnoreAttribute>() != null) return null;

                if (!prop.CanRead || !prop.CanWrite) return null;

                if (name == null)
                {
                    name = prop.GetCustomAttribute<SettingNameAttribute>()?.Name ??
                           nameDefaultPrefix + prop.Name.ToLowerInvariant();
                    name = EverestModuleDialogText.CleanOrNull(SourceEngine, name) ??
                           EverestStringSource.SpacedPascalCase(prop.Name);
                }

                TextMenu.Item item3 = null;
                var propType = prop.PropertyType;
                var value = prop.GetValue(settingsObject);
                var flag2 = false;
                var
                    customAttribute = prop.GetCustomAttribute<SettingInGameDisableAttribute>();
                var flag3 = customAttribute != null && customAttribute.InGame == inGame;
                if (propType == typeof(bool))
                {
                    item3 = new TextMenu.OnOff(name, (bool)value, SourceEngine).Change(delegate(bool v)
                    {
                        prop.SetValue(settingsObject, v);
                    });
                }
                else if (propType == typeof(int) &&
                         (attribRange = prop.GetCustomAttribute<SettingRangeAttribute>()) != null)
                {
                    item3 = !attribRange.LargeRange
                        ? new TextMenu.Slider(name, num2 => num2.ToString(), attribRange.Min,
                            attribRange.Max, (int)value).Change(delegate(int v) { prop.SetValue(settingsObject, v); })
                        : new EverestMenuIntSlider(name, attribRange.Min, attribRange.Max, (int)value)
                            .Change(delegate(int v) { prop.SetValue(settingsObject, v); });
                }
                else if ((propType == typeof(int) || propType == typeof(float)) &&
                         (attribNumber = prop.GetCustomAttribute<SettingNumberInputAttribute>()) != null)
                {
                    flag2 = true;
                    float currentValue;
                    Action<float> valueSetter;
                    if (propType == typeof(int))
                    {
                        currentValue = (int)value;
                        valueSetter = delegate(float v) { prop.SetValue(settingsObject, (int)v); };
                    }
                    else
                    {
                        currentValue = (float)value;
                        valueSetter = delegate(float v) { prop.SetValue(settingsObject, v); };
                    }

                    var maxLength = attribNumber.MaxLength;
                    var allowNegatives = attribNumber.AllowNegatives;
                    item3 = new TextMenu.Button(name + ": " +
                                                currentValue.ToString($"F{maxLength}").TrimEnd('0').TrimEnd('.'))
                        .Pressed(
                            delegate
                            {
                                ((IOriginalGameplayProcess)SourceEngine).AudioSession.Play(
                                    "event:/ui/main/savefile_rename_start");
                                ((OverworldSequence)menu.Scene).Goto<OuiNumberEntry>().Init<OuiModOptions>(currentValue,
                                    valueSetter, maxLength, propType == typeof(float), allowNegatives);
                            });
                }
                else if (propType.IsEnum)
                {
                    var enumValues = Enum.GetValues(propType);
                    Array.Sort(enumValues);
                    var value2 = 0;
                    for (var num = 0; num < enumValues.Length; num++)
                        if (enumValues.GetValue(num).Equals(value))
                        {
                            value2 = num;
                            break;
                        }

                    var enumNamePrefix = nameDefaultPrefix + prop.Name.ToLowerInvariant() + "_";
                    item3 = new TextMenu.Slider(name, delegate(int index)
                    {
                        var text6 = enumValues.GetValue(index).ToString();
                        return
                            EverestModuleDialogText.CleanOrNull(SourceEngine,
                                enumNamePrefix + text6.ToLowerInvariant()) ??
                            EverestModuleDialogText.CleanOrNull(SourceEngine,
                                "modoptions_" + ReadMenuTypeName(propType).ToLowerInvariant() + "_" +
                                text6.ToLowerInvariant()) ?? text6;
                    }, 0, enumValues.Length - 1, value2).Change(delegate(int v)
                    {
                        prop.SetValue(settingsObject, enumValues.GetValue(v));
                    });
                }
                else if (propType == typeof(string))
                {
                    flag2 = true;
                    var maxValueLength = prop.GetCustomAttribute<SettingMaxLengthAttribute>()?.Max ?? 12;
                    var minValueLength = prop.GetCustomAttribute<SettingMinLengthAttribute>()?.Min ?? 1;
                    item3 = new TextMenu.Button(name + ": " + value).Pressed(delegate
                    {
                        ((IOriginalGameplayProcess)SourceEngine).AudioSession.Play(
                            "event:/ui/main/savefile_rename_start");
                        ((OverworldSequence)menu.Scene).Goto<OuiModOptionString>().Init<OuiModOptions>((string)value,
                            delegate(string v) { prop.SetValue(settingsObject, v); }, maxValueLength, minValueLength);
                    });
                }

                if (item3 != null) item3.Disabled = flag3 || (inGame && flag2);

                return item3;
            }
        }

        private string ReadMenuTypeName(Type actualType)
        {
            return actualType.GetCustomAttribute<SettingMenuNameAttribute>()?.Name ?? actualType.Name;
        }
    }
}
