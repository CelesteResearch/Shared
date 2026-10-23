using System;
using System.Globalization;
using Celeste.Core.Display;
using Celeste.Core.Reflection;

namespace Celeste.Framework.Diagnostics.Commands
{
    public partial class SourceCommands
    {
        protected virtual void BuildCommandsList()
        {
            var types = process.CommandsCallingAssembly.GetTypes();
            for (var i = 0; i < types.Length; i++)
            {
                var methods =
                    ((ISourceCommandTypeMetadata)types[i]).GetDeclaredStaticMethods();
                foreach (var method in methods) ProcessMethod(method);
            }

            types = process.CommandsEntryAssembly.GetTypes();
            for (var i = 0; i < types.Length; i++)
            {
                var methods =
                    ((ISourceCommandTypeMetadata)types[i]).GetDeclaredStaticMethods();
                foreach (var method2 in methods) ProcessMethod(method2);
            }

            foreach (var command in commands) sorted.Add(command.Key);

            sorted.Sort();
        }

        protected virtual void ProcessMethod(ISourceCommandMethodMetadata method)
        {
            SourceCommandDeclaration command = null;
            var customAttributes = method.ReadDeclaredCommands();
            if (customAttributes.Length != 0) command = customAttributes[0];

            if (command == null) return;

            if (!method.IsStatic)
                throw new(method.DeclaringTypeName + "." + method.Name +
                          " is marked as a command, but is not static");

            var value = new SourceCommandInfo
            {
                Help = command.Help,
            };
            var parameters = method.GetCommandParameters();
            var defaults = new object[parameters.Length];
            var array = new string[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameterInfo = parameters[i];
                array[i] = parameterInfo.Name + ":";
                if (parameterInfo.ParameterTypeIdentity == "System.String")
                {
                    array[i] += "string";
                }
                else if (parameterInfo.ParameterTypeIdentity == "System.Int32")
                {
                    array[i] += "int";
                }
                else if (parameterInfo.ParameterTypeIdentity == "System.Single")
                {
                    array[i] += "float";
                }
                else
                {
                    if (!(parameterInfo.ParameterTypeIdentity == "System.Boolean"))
                        throw new(method.DeclaringTypeName + "." + method.Name +
                                  " is marked as a command, but has an invalid parameter type. Allowed types are: string, int, float, and bool");

                    array[i] += "bool";
                }

                if (parameterInfo.DefaultValue == DBNull.Value)
                {
                    defaults[i] = null;
                }
                else if (parameterInfo.DefaultValue != null)
                {
                    defaults[i] = parameterInfo.DefaultValue;
                    if (parameterInfo.ParameterTypeIdentity == "System.String")
                    {
                        ref var reference = ref array[i];
                        reference = string.Concat(reference, "=\"", parameterInfo.DefaultValue, "\"");
                    }
                    else
                    {
                        ref var reference2 = ref array[i];
                        reference2 = reference2 + "=" + parameterInfo.DefaultValue;
                    }
                }
                else
                {
                    defaults[i] = null;
                }
            }

            if (array.Length == 0)
                value.Usage = "";
            else
                value.Usage = "[" + string.Join(" ", array) + "]";

            value.Action = delegate(string[] args)
            {
                if (parameters.Length == 0)
                {
                    InvokeMethod(method);
                }
                else
                {
                    var array2 = (object[])defaults.Clone();
                    for (var j = 0; j < array2.Length && j < args.Length; j++)
                        if (parameters[j].ParameterTypeIdentity == "System.String")
                            array2[j] = ArgString(args[j]);
                        else if (parameters[j].ParameterTypeIdentity == "System.Int32")
                            array2[j] = ArgInt(args[j]);
                        else if (parameters[j].ParameterTypeIdentity == "System.Single")
                            array2[j] = ArgFloat(args[j]);
                        else if (parameters[j].ParameterTypeIdentity == "System.Boolean") array2[j] = ArgBool(args[j]);

                    InvokeMethod(method, array2);
                }
            };
            commands[NormalizeCommandName(command.Name)] = value;
        }

        protected virtual void InvokeMethod(ISourceCommandMethodMetadata method, object[] param = null)
        {
            try
            {
                method.Invoke(null, param);
            }
            catch (Exception ex)
            {
                process.Commands.Log(ex.InnerException.Message, PackedColor.Yellow);
                LogStackTrace(ex.InnerException.StackTrace);
            }
        }

        private static string ArgString(string arg)
        {
            if (arg == null) return "";

            return arg;
        }

        private static bool ArgBool(string arg)
        {
            if (arg != null)
            {
                if (!(arg == "0") && !(arg.ToLower() == "false")) return !(arg.ToLower() == "f");

                return false;
            }

            return false;
        }

        private static int ArgInt(string arg)
        {
            try
            {
                return Convert.ToInt32(arg);
            }
            catch
            {
                return 0;
            }
        }

        private static float ArgFloat(string arg)
        {
            try
            {
                return Convert.ToSingle(arg, CultureInfo.InvariantCulture);
            }
            catch
            {
                return 0f;
            }
        }

        protected virtual string NormalizeCommandName(string name)
        {
            return name;
        }
    }
}
