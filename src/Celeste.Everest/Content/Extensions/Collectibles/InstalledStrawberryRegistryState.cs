using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Celeste.Core.Components;
using Celeste.Scene.Following;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Everest.Modules.Updating;

namespace Celeste.Everest.Content.Extensions.Collectibles
{
// The installed registry's static state belongs to one actual process instance.
    public class InstalledStrawberryRegistryState
    {
        public class RegisteredBerry
        {
            public Type berryClass;
            public string entityName;
            public bool isTracked;
            public bool blocksNormalCollection;

            public RegisteredBerry(Type type, string name, bool tracked, bool blockCollect)
            {
                berryClass = type;
                entityName = name;
                isTracked = tracked;
                blocksNormalCollection = blockCollect;
            }
        }

        private HashSet<RegisteredBerry> registeredBerries;
        private ReadOnlyCollection<RegisteredBerry> getRegisteredBerries;
        private ReadOnlyCollection<RegisteredBerry> getTrackableBerries;
        private ReadOnlyCollection<Type> getBerryTypes;
        private ReadOnlyCollection<string> getBerryNames;
        private HashSet<string> trackedBerryNames;
        private HashSet<string> berryNamesHashSet;

        public InstalledStrawberryRegistryState()
        {
            registeredBerries = new HashSet<RegisteredBerry>
            {
                new RegisteredBerry(typeof(OriginalStrawberryState), "strawberry", true, false),
                new RegisteredBerry(typeof(OriginalStrawberryState), "goldenBerry", false, true),
                new RegisteredBerry(typeof(OriginalStrawberryState), "memorialTextController", false, true)
            };
        }

        public ReadOnlyCollection<RegisteredBerry> GetRegisteredBerries()
        {
            if (getRegisteredBerries == null)
                getRegisteredBerries = registeredBerries.ToList().AsReadOnly();
            return getRegisteredBerries;
        }

        public ReadOnlyCollection<RegisteredBerry> GetTrackableBerries()
        {
            if (getTrackableBerries == null)
                getTrackableBerries = registeredBerries.ToList().FindAll(berry => berry.isTracked).AsReadOnly();
            return getTrackableBerries;
        }

        public ReadOnlyCollection<Type> GetBerryTypes()
        {
            if (getBerryTypes == null)
            {
                List<Type> types = new List<Type>();
                foreach (RegisteredBerry berry in registeredBerries)
                    if (!types.Contains(berry.berryClass))
                        types.Add(berry.berryClass);
                getBerryTypes = types.AsReadOnly();
            }

            return getBerryTypes;
        }

        public ReadOnlyCollection<string> GetBerryNames()
        {
            if (getBerryNames == null)
            {
                List<string> names = new List<string>(registeredBerries.Count);
                foreach (RegisteredBerry berry in registeredBerries)
                    names.Add(berry.entityName);
                getBerryNames = names.AsReadOnly();
            }

            return getBerryNames;
        }

        public void Register(Type type, string entityName, bool tracked, bool blocksNormalCollection)
        {
            registeredBerries.Add(new RegisteredBerry(type, entityName, tracked, blocksNormalCollection));
            InvalidateRegistrationViews();
        }

        public IDisposable RegisterOwned(Type type, string entityName, bool tracked, bool blocksNormalCollection)
        {
            var berry = new RegisteredBerry(type, entityName, tracked, blocksNormalCollection);
            registeredBerries.Add(berry);
            InvalidateRegistrationViews();
            return new RegistrationUndo(() =>
            {
                if (registeredBerries.Remove(berry)) InvalidateRegistrationViews();
            });
        }

        private void InvalidateRegistrationViews()
        {
            getRegisteredBerries = null;
            getTrackableBerries = null;
            getBerryTypes = null;
            getBerryNames = null;
            trackedBerryNames = null;
            berryNamesHashSet = null;
        }

        public void Register(Type type, bool tracked, bool blocksNormalCollection)
        {
            if (Attribute.IsDefined(type, typeof(CustomEntityAttribute)))
            {
                string[] ids =
                    (Attribute.GetCustomAttribute(type, typeof(CustomEntityAttribute)) as CustomEntityAttribute)
                    .IDs;
                for (int i = 0; i < ids.Length; i++)
                    Register(type, ids[i], tracked, blocksNormalCollection);
            }
        }

        public bool TrackableContains(string name)
        {
            if (trackedBerryNames == null)
                trackedBerryNames = GetTrackableBerries().Select(berry => berry.entityName).ToHashSet();
            return trackedBerryNames.Contains(name);
        }

        public bool TrackableContains(BinaryPackerElement element)
        {
            if (element.AttrBool("moon", false))
                return false;
            return TrackableContains(element.Name);
        }

        public bool IsRegisteredBerry(string name)
        {
            if (berryNamesHashSet == null)
                berryNamesHashSet = GetBerryNames().ToHashSet();
            return berryNamesHashSet.Contains(name);
        }

        public bool IsFirstStrawberry(ISourceOwnedComponentList entity)
        {
            FollowerState follower = entity.OwnedComponents.Get<FollowerState>();
            if (follower == null)
                return false;
            List<RegisteredBerry> berries = registeredBerries.ToList();
            ReadOnlyCollection<Type> types = GetBerryTypes();
            for (int i = follower.FollowIndex - 1; i >= 0; i--)
            {
                // Preserve the per-iteration predicate capture before the first lookup.
                BerryTypeMatch match = new BerryTypeMatch();
                object previous = follower.Leader.Followers[i].Entity;
                match.type = previous.GetType();
                RegisteredBerry berry = berries.Find(match.Matches);
                _ = types.Contains(previous.GetType());
                bool blocks = false;
                if (berry != null)
                    blocks = berry.blocksNormalCollection;
                bool golden = false;
                if (previous is OriginalStrawberryState)
                    golden = (previous as OriginalStrawberryState).Golden;
                if (types.Contains(previous.GetType()) && !blocks && !golden)
                    return false;
            }

            return true;
        }

        private sealed class BerryTypeMatch
        {
            public Type type;
            public bool Matches(RegisteredBerry berry) => berry.berryClass == type;
        }
    }
}
