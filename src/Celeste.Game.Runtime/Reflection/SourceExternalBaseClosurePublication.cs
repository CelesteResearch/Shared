using Celeste.Core.Reflection.Assemblies;

namespace Celeste.Game.Runtime.Reflection
{
// Finite PE assembly evidence; no BCL type/member definitions or runtime assembly scanning.
    public static class SourceExternalBaseClosurePublication
    {
        public static SourceExternalBaseClosureFacts CreateOriginal4()
            => new SourceExternalBaseClosureFacts("Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "1A1E117ADD967C0F26AD470A49D4FF442435209265BF1FDDA623821D797E80B5",
                new string[]
                {
                    "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                }, new SourceExternalAssemblyClosureNode[]
                {
                    new SourceExternalAssemblyClosureNode(
                        "Accessibility, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "D4CC4D55F254A11E355A3A5E8B2AEAD96E54E6412F94E6DC6FBAEA3A62EB062C",
                        new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
                        new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "Microsoft.VisualC, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "0DD5A0FC100EAD1C6FB45F0D591F3C08B5FAECE743E3AA54176F84771986EB42",
                        new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
                        new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        "38E7093F52D7474BBC6256906519781A1210D7DA50A1C667B52716FCF49CA130",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "Microsoft.VisualC, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        "B5DFFDD8125ABEF2A4507BA4E1D2F11062143F0A63D48FE4F298B95AD746A1F0",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "Microsoft.Xna.Framework.GamerServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Input.Touch, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "Microsoft.Xna.Framework.GamerServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        "7C6EFFED97AA25A95C5E095D9C261F5581E402180CC073271A367B9EEF79C8AF",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        "560080FC39021C611CA9D076DCEBED312FAF6D7D1413C2DC523683EA635E9F55",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "Microsoft.VisualC, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "Microsoft.Xna.Framework.Input.Touch, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        "B0585224C18022C3661057AE79544644C10F33F1DC529678364F3D6B25151C25",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "Mono.Posix, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756",
                        "848C0895AC0ADBF61E470241C9348E6C64F2A5C4A9AAD3C8EDA6B7776D4960E3",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756",
                        "DFA1B18CF3EE98E6BDBF34A530A0E8BE2090BDD3BD410C50CC52D72EC10DDA0B",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "F7BEC4BE4FB5B4CADE309522306441920B409EEDD4741C3963355D7A08604B68",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756",
                            "System.Configuration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Configuration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "D8EFCE69FFCF518B51F92A46BE44B7B36E39E257A90F8F13D169D56AAA8A7798",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "BB65859A1EC3A6406CD61D3FCE348380FAC4C50C2EBBFCE5EC92F171FF4432C7",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "Mono.Posix, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756"
                        },
                        new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Deployment, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "49487A1DC191B6E5702873FB8D2DF4209F870D9820B732828CBE8479A78DC463",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Configuration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "85F7CAD9CE583AD3C2C005B0224B2213829609ECCB0B5B32CD461D0B40B3FB08",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "E29691F59294AD50E26299683D27119969B13FB4D718D3E8E4D841760B03A028",
                        new string[] { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
                        new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Runtime.Serialization.Formatters.Soap, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "9A172D86483A0153508C1C892D9D5BBCA945B28D2EE20A4F2FA5D918FAA1E06E",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "1C9DE2F379BCA5E4C0F6096556BB45D9BADA9900296061DB5792CE375AE31B67",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756",
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "8C0F533E089647AEFFB3CE0868F01D696A3FD2893CED5C3570E8438C96613A98",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Configuration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "Accessibility, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Deployment, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.Serialization.Formatters.Soap, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "0C251C5EA2405A58387C58241813D07E3A199CE704D6BADE55A0D340093850FF",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Configuration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "1DA089AEE864876D1F7D303E91087A1E2F3C9F7B989514A780A5BA9188053341", new string[] { },
                        new string[] { }, false),
                });

        public static SourceExternalBaseClosureFacts CreateInstalled8()
            => new SourceExternalBaseClosureFacts("Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "CBE1262E6F53DDF959B072FCACDF7B8F5EB08E67F5EB5853C5C6AB1AD12B2089",
                new string[]
                {
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "MonoMod.Patcher, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                    "System.Net.Http, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Runtime.Loader, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Security.Cryptography, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                }, new SourceExternalAssemblyClosureNode[]
                {
                    new SourceExternalAssemblyClosureNode("FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        "862CE4418709A914C4BC89240026D71379FE06EE5C88D9FCF12D57600FAD9CD4",
                        new string[]
                        {
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "NETCoreifier, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "MonoMod.Patcher, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Win32.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "Microsoft.Win32.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "596160C8491D2110A36CE4CB93C736905B2C83B9B50496369F32E32AD28D2A20",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "Microsoft.Win32.Registry, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "A8CC5503BBBA36472D1DD3A8EEBC3A8B26F0B2882E770851AAB486690B23EAD9",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.AccessControl, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Principal.Windows, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "Mono.Cecil, Version=0.11.6.0, Culture=neutral, PublicKeyToken=50cebf1cceb9d05e",
                        "831DCA77470D85CB6FFBEA3072DAA7A3DF5B7C9FCFD9C3F43674A9BE99D4BFCF",
                        new string[]
                            { "netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51" },
                        new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "Mono.Cecil.Mdb, Version=0.11.6.0, Culture=neutral, PublicKeyToken=50cebf1cceb9d05e",
                        "28CB367972BDC1CD43E4006306AF2FD96D37F4ED4B239EE90E1DC7237A93AF7F",
                        new string[]
                        {
                            "netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "Mono.Cecil, Version=0.11.6.0, Culture=neutral, PublicKeyToken=50cebf1cceb9d05e"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "Mono.Cecil.Pdb, Version=0.11.6.0, Culture=neutral, PublicKeyToken=50cebf1cceb9d05e",
                        "A332332633FBCB20E8D50E49B4DB7BD1557721417122CF0C5F4C42F2332391D0",
                        new string[]
                        {
                            "netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "Mono.Cecil, Version=0.11.6.0, Culture=neutral, PublicKeyToken=50cebf1cceb9d05e"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "MonoMod.Backports, Version=1.1.2.0, Culture=neutral, PublicKeyToken=null",
                        "AC3F32BFD44AAB83ABF71ABDFF6DDE548D57B7C0F8A1FE6D8964E348B4EEAFB1",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "MonoMod.ILHelpers, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        },
                        new string[]
                        {
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, false),
                    new SourceExternalAssemblyClosureNode(
                        "MonoMod.Core, Version=1.3.1.0, Culture=neutral, PublicKeyToken=null",
                        "8B9504ECEC223C3135CC2C806361CF992E6B4C6E0CC2282B265B61595E8C8537",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "MonoMod.ILHelpers, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                            "Mono.Cecil, Version=0.11.6.0, Culture=neutral, PublicKeyToken=50cebf1cceb9d05e",
                            "MonoMod.Iced, Version=1.21.0.0, Culture=neutral, PublicKeyToken=null",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "Microsoft.Win32.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.Process, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Emit.Lightweight, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "MonoMod.Backports, Version=1.1.2.0, Culture=neutral, PublicKeyToken=null",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.Requests, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Emit.ILGeneration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "MonoMod.ILHelpers, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null",
                        "FDD0E3538340FD78B8F521E62B8CAC1EBB7683AC1F27F6AAEDFC1044B14BF4BB",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "MonoMod.Backports, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"
                        },
                        new string[]
                        {
                            "MonoMod.Backports, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, false),
                    new SourceExternalAssemblyClosureNode(
                        "MonoMod.Iced, Version=1.21.0.0, Culture=neutral, PublicKeyToken=null",
                        "81CCE977BCC8D75B8632A2D87060ABED85A29346382405C25DE22BFECD91D3B8",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "MonoMod.ILHelpers, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "MonoMod.Backports, Version=1.1.2.0, Culture=neutral, PublicKeyToken=null",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "MonoMod.Patcher, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "F5494F55A7177D47C5C2FD1490F474813C4C32ACFA8DD5EEC542575B80A5B031",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "MonoMod.ILHelpers, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                            "Mono.Cecil, Version=0.11.6.0, Culture=neutral, PublicKeyToken=50cebf1cceb9d05e",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "Mono.Cecil.Mdb, Version=0.11.6.0, Culture=neutral, PublicKeyToken=50cebf1cceb9d05e",
                            "Mono.Cecil.Pdb, Version=0.11.6.0, Culture=neutral, PublicKeyToken=50cebf1cceb9d05e",
                            "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Console, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "MonoMod.RuntimeDetour, Version=25.3.1.0, Culture=neutral, PublicKeyToken=null",
                        "D0CA795145FE96DC866C28C7E01476DF4D94B668D6EDAEDE5906D4E9FDE1B2B1",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "MonoMod.ILHelpers, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                            "Mono.Cecil, Version=0.11.6.0, Culture=neutral, PublicKeyToken=50cebf1cceb9d05e",
                            "System.ComponentModel.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "MonoMod.Core, Version=1.3.1.0, Culture=neutral, PublicKeyToken=null",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "MonoMod.Backports, Version=1.1.2.0, Culture=neutral, PublicKeyToken=null",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null",
                        "34090E4B269769F9B0485CC3F6647D6C37C24A1FD397C05E85FCC3EFC0F712B9",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "MonoMod.ILHelpers, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Mono.Cecil, Version=0.11.6.0, Culture=neutral, PublicKeyToken=50cebf1cceb9d05e",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Emit.Lightweight, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Emit, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Emit.ILGeneration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "MonoMod.Backports, Version=1.1.2.0, Culture=neutral, PublicKeyToken=null",
                            "System.Console, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "Microsoft.Win32.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Text.Encoding.Extensions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "NETCoreifier, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "A7A91067F95F75FD7E4CB2625E2BEEED9D0AA08F28E5EE3C2286983FF6D5C7A8",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "MonoMod.Patcher, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Mono.Cecil, Version=0.11.6.0, Culture=neutral, PublicKeyToken=50cebf1cceb9d05e",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Emit, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Emit.ILGeneration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.Loader, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.MemoryMappedFiles, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "MonoMod.Utils, Version=25.0.9.0, Culture=neutral, PublicKeyToken=null"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "173DD55A6D19794FB6EB8C4E4E73510EBF3A7928AFFE43C21E721861A4250E51",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=0.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.CodeDom, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "Microsoft.Win32.SystemEvents, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Diagnostics.Process, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Cryptography, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Concurrent, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ObjectModel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Specialized, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.NonGeneric, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ComponentModel.TypeConverter, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ComponentModel.EventBasedAsync, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ComponentModel.Primitives, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ComponentModel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Configuration.ConfigurationManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Diagnostics.TraceSource, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.TextWriterTraceListener, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.PerformanceCounter, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Diagnostics.EventLog, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Security.Permissions, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Diagnostics.FileVersionInfo, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Private.Uri, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.Compression, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IO.FileSystem.Watcher, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.Ports, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Windows.Extensions, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.Requests, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Primitives, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.HttpListener, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.ServicePoint, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.NameResolution, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.WebClient, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.WebHeaderCollection, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.WebProxy, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.Mail, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.NetworkInformation, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Ping, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Security, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Sockets, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.WebSockets.Client, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.WebSockets, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.AccessControl, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Text.RegularExpressions, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        },
                        new string[]
                        {
                            "Microsoft.Win32.SystemEvents, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.CodeDom, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Concurrent, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.NonGeneric, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Specialized, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ComponentModel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ComponentModel.EventBasedAsync, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ComponentModel.Primitives, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ComponentModel.TypeConverter, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Configuration.ConfigurationManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Diagnostics.EventLog, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Diagnostics.FileVersionInfo, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.PerformanceCounter, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Diagnostics.Process, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.TextWriterTraceListener, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.TraceSource, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.Compression, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IO.FileSystem.Watcher, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.Ports, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.HttpListener, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.Mail, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.NameResolution, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.NetworkInformation, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Ping, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Primitives, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Requests, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Security, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.ServicePoint, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.Sockets, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.WebClient, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.WebHeaderCollection, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.WebProxy, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.WebSockets, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.WebSockets.Client, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ObjectModel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Private.CoreLib, Version=0.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Private.Uri, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Cryptography, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Permissions, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Text.RegularExpressions, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.AccessControl, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Windows.Extensions, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
                        }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "C6BB79B8FB32504B6327B516E6FF32017A073669AB749D3C86ED49CD5F2F0C45",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "ED653CCB5DC40D0BB4EA3429165A0825705F2935A65C584CA67CBA45671884C1",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Collections.Immutable, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "6E41C8BA23968F6A9B910E3C33F66761A588F24084C4E3599214805716D6D259",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Collections.NonGeneric, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "B40CDF234652B31B443164350F73E25F98C5EDECFD30698789D6DBF9CA456E44",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        },
                        new string[]
                            { "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Collections.Specialized, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "24022887037BFAAD8C89C26642712C920DCC0ABABD3396D80D8B2BE16637673B",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ComponentModel.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.ComponentModel, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "4D9E2E21ED5C16C100221433D1AAB01409EC199C9F617E48B9FE1617989BBAA6",
                        new string[]
                            { "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" },
                        new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.ComponentModel.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "D981AF410D4ED7939FDEE47A1EE58E3DB472C05F17C2B0D48E4B1EBFB2FEA0E5",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ComponentModel, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.NonGeneric, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ObjectModel, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Console, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "D38105C5C790FC76AC6E4D99FE9B6C2672E4E250E191BD43593E55AE7D3B2AFE",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Text.Encoding.Extensions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "F7414ECFD958FDFB2B4BCDD2F7778A7B26968EB453CA2C03FDF53BA4BB21674F",
                        new string[]
                        {
                            "System.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.MemoryMappedFiles, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Cryptography, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.Pipes, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.EventLog, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Diagnostics.PerformanceCounter, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Linq.Expressions, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.Pipes.AccessControl, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq.Queryable, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq.Parallel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        },
                        new string[]
                        {
                            "System.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.EventLog, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Diagnostics.PerformanceCounter, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.IO.MemoryMappedFiles, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.Pipes, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.Pipes.AccessControl, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq.Expressions, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq.Parallel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq.Queryable, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Cryptography, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Diagnostics.DiagnosticSource, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                        "25C3BF229337A485CEACB82C00F47F2E98DE68A279EB5A450550526F9CBF0448",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Diagnostics.Tracing, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        },
                        new string[]
                            { "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Diagnostics.FileVersionInfo, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "24B0E8ED2EA93B84FF2A26CB1F69F7D6E331F6162EAE4FAE4446A5556B8A8EEE",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Diagnostics.Process, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "7083C7046AC4CBED1068B6AE7A777D421EEAF180E5697283FC1C6AF731C32A3D",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Text.Encoding.Extensions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.ThreadPool, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ComponentModel.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "Microsoft.Win32.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.FileVersionInfo, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.NonGeneric, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Specialized, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "Microsoft.Win32.Registry, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "7B26B1C48D500576994B3153B88FEFD1E516680AE4B52CDE608B8E869544B37D",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Reflection.Metadata, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Immutable, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Diagnostics.Tracing, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "6857ED7CA2C17D38F74639BACC59942599935593F9A0B33B246161C57DB27EB3",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Formats.Asn1, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                        "61F505F140E2C6417640A5AA47A86D148D4F6DC5317A66A7BFA2266A3AC975BF",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Text.Encoding.Extensions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.Numerics, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.IO.Compression, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "1F7E0CE87B7859C81D793750EA8FC58DB6D1FA1B81D3CEA1E73C614F66439C3C",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.IO.Compression.Brotli, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "46D228E5EA0E3D25B15E95D6A97A3B80E86DDE2660589462F30853EB5A0C40B5",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.Compression, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.IO.MemoryMappedFiles, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "E3136D19090F173D2AB75C392486A1427060BD149D966CFD58F3DF3308546DFD",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "2B375E90FC687967BD95A0F47DBCBA44D396923F3C98B7FE5754E34C8E4BEFAA",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Numerics.Vectors, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.Intrinsics, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Linq.Expressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "0F99977BEDDC9272D56A2E16B2581CDE37F2AFD43E77C8209827197C098DEDEB",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Emit, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Emit.ILGeneration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Emit.Lightweight, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ObjectModel, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                        "84242CCE5EACC6963A77163986066BD0A1C2EB698B5F26DBDD5E6706E002FBC7",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Net.Http, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "5102639C2037D77949340D94761C9A4C5053B940B8AE4BA2FBBE3507B8A5EC43",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.Tracing, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Security, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Cryptography, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.NonGeneric, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.DiagnosticSource, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Quic, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.NameResolution, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Sockets, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.Compression, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IO.Compression.Brotli, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Channels, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.NetworkInformation, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Principal.Windows, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Claims, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Net.NameResolution, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "E8CC6C2F0D59FB018FDC4A66057E3A56A3AA5ED82FEDE17B2398CDA88DA407CD",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Overlapped, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.Tracing, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.DiagnosticSource, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Threading.ThreadPool, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Net.NetworkInformation, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "DB21F0C5659D925741F7A08B0B50FC297248B0155F375F0FD7F970DD2E4CD3F0",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.Sockets, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.Tracing, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.ThreadPool, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "Microsoft.Win32.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Net.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "0F929E8581F09FE85275DF7B38549BC51415CD110AADFD89EADE53943174511A",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.Tracing, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.NonGeneric, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.Intrinsics, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "Microsoft.Win32.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Net.Quic, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "58F5E4C6F2BBD5320C9797FBEAD001A99E4D334FA936D5469DF82262AC8069DA",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Cryptography, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Diagnostics.Tracing, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Sockets, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "Microsoft.Win32.Registry, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Security, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Channels, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Net.NameResolution, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Net.Requests, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "60B7C1595CECC53767C3EFCDAE74DDD37350AC51F377CAC8D7E95428B1F231AF",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Specialized, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.WebHeaderCollection, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Http, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.ServicePoint, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Security.Cryptography, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Security, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Sockets, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.Tracing, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Principal.Windows, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        },
                        new string[]
                        {
                            "System.Net.WebHeaderCollection, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Net.Security, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "C957641BE9192E7812F209E2120E56A71DA0D99B1A8443CA5F7947F38EA4376D",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Cryptography, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.Tracing, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Principal.Windows, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "Microsoft.Win32.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Claims, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Sockets, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.NonGeneric, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Net.ServicePoint, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                        "8969D0EA32B01B7198030AFE6258D85A3021655B4F7E2291CB5521BBA1F7E29F",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Cryptography, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Security, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Net.Sockets, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "49E95C5A59172D80941992016EB35C965D8FB4BC05B745F85E793B6C010BDC6B",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Overlapped, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.Tracing, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.NameResolution, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Net.WebHeaderCollection, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "8DB64DD40A80422673F81EC67EE9DF921795B0579E5BA6CEF09BFFCE7FEF1294",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Specialized, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Numerics.Vectors, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "6E45388834E11D4A8E460F97DA371D6889CDF98D7B65B300079C2F2B69EA3FAF",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.ObjectModel, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "35187A8D7F9DC8896894D1A0A496FBABCD567F2AC0F047632F7178C308FF72F5",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        },
                        new string[]
                            { "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                        "99B168B84597A4F31FDA8281EFCE7D42A14E2DF0F4694194735E049DBC0F6418", new string[] { },
                        new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Private.Uri, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "F2A695DCD4073EABA43B4EE26F006C0174BFF42673E17B38914450CA7D2547F5",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Reflection.Emit, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "51742F48054D452DE444DA58D4AC69B879A23BBC8841B4B08FC337745D50CB07",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Reflection.Metadata, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Immutable, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Reflection.Emit.ILGeneration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "ED892838C6ED6649AB57A436128845EC195329CDF568C99D9CB8E6F4B92C7A01",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Reflection.Emit.Lightweight, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "39CF409E3B41B813C9E715EC4F38BC02748499D62E89F71FD8F4DAD6EBBA80BB",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Reflection.Metadata, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "1795022B24DDF1E4DB47F63035B685F2A9F3E4468FB277158BB909D3B6EC00A0",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Collections.Immutable, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.Compression, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.MemoryMappedFiles, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Text.Encoding.Extensions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Reflection.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "B15B177125F391D1CAEE193167CAFFBEC4AC2586447F822AC655ACE9A6BDFF41",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "E8FB5B78DC75B0650520042936FCA2165A060CB4AFA4B8CCE90524C9C9FC3563",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Private.Uri, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Private.Uri, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "1930AEA4D91654A4DAF13BF95B2DAFF023D3104A9B3794059EA139E550BCFB5F",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Runtime.Intrinsics, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                        "8679A62575619CAA282D3FB1A1EAD4680417B0384FFED8B73A2C4F7DC102C32B",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Runtime.Loader, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "64AC3644E7FD9279B5410E9C8D31DF01F763B4A362E626E6DD96416A9F6755B3",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Runtime.Numerics, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "D845C2A3D8EDC282D5C32FD8020C2233FBEED3EB02B5064AB8637506049CFB70",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Security.AccessControl, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "149888FD2B8F15B37BA115E2BB3C0577C8DB9AED6F91221902AD6C9A61A69A49",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Principal.Windows, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "Microsoft.Win32.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.NonGeneric, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Security.Claims, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "45171F0AD174047CBF511E7761D7ABB2D44988E899F690C36FF3C5BCFBCB2467",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Security.Cryptography, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "1E4C4CE04A46E2A2DA8221BF583EBD4F6B5149D4B32792CACC5C33978D0BB121",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Formats.Asn1, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.Numerics, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Text.Encoding.Extensions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.NonGeneric, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Net.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Security.Principal.Windows, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "AACE487981F8C9077620ABF9C9D236CE5EF98241CF4222FBB49C717286F2CD0F",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "Microsoft.Win32.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Claims, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Text.Encoding.Extensions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "9AD4679A4005EADC13AF6AE025534F22648DED33AB7C1A796C70C8813EE51977",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "8B3AF9E3E0215B46C2DCEF1F11C4CDC7AD477140883BCB5C778D04CC051BB0DC",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Emit.ILGeneration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Emit.Lightweight, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "435C110B598D30F118D0E673068B535B693C5A77FAE17398AD46821CE1261ABA",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Threading.Channels, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                        "AB05F710069580165C588789E0623E84D213C35594E3E12AE762A6C8265740B6",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.ThreadPool, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, new string[] { }, false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Threading.Overlapped, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "739BFB326810706F497DF3B66901E5657B9835AD945FDC6728A27BF932CBAFAA",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "34ED4D7D03BF9A5A5DF7ADDC37A5B75759956FC0D949E25DF61D878238BC560A",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "System.Threading.ThreadPool, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "5758D73199750AF708EDCA8456EED908B0BFDAACCD7CB2083A6C95DAD4006FDB",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        new string[]
                        {
                            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
                        },
                        false),
                    new SourceExternalAssemblyClosureNode(
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "EE4983E136AB524F29D2F43D01D1DEB978F4948EB5CA05B5D6E40BE37EC43023",
                        new string[]
                        {
                            "System.Private.CoreLib, Version=0.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "Microsoft.Win32.Registry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Principal.Windows, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Permissions, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Memory, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.NonGeneric, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Concurrent, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ObjectModel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Console, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.StackTrace, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.FileSystem.DriveInfo, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.IsolatedStorage, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ComponentModel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Reflection.TypeExtensions, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Resources.Writer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.CompilerServices.VisualC, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.Serialization.Formatters, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.AccessControl, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.FileSystem.AccessControl, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.AccessControl, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Claims, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Cryptography, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Tasks.Parallel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        },
                        new string[]
                        {
                            "Microsoft.Win32.Registry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Concurrent, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.NonGeneric, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ComponentModel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Console, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Diagnostics.StackTrace, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.FileSystem.AccessControl, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.FileSystem.DriveInfo, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.IsolatedStorage, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.ObjectModel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Private.CoreLib, Version=0.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                            "System.Reflection.TypeExtensions, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Resources.Writer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.CompilerServices.VisualC, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.Serialization.Formatters, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.AccessControl, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Claims, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Cryptography, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Security.Permissions, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.Security.Principal.Windows, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.AccessControl, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Threading.Tasks.Parallel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                        }, false),
                    new SourceExternalAssemblyClosureNode(
                        "MemoryPack.Core, Version=1.21.1.0, Culture=neutral, PublicKeyToken=df4c250b14d82627",
                        "B0A30D37435B1C21FAB1014AC75E4D78539A24E2F42C83188271656F2F8D3827",
                        new string[]
                        {
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.Compression, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                            "System.ComponentModel, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.Numerics, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.ObjectModel, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Immutable, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IO.Compression.Brotli, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Numerics.Vectors, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Runtime.Intrinsics, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
                        }, new string[] { }, false),
                });
    }
}
