using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("DigitallyImported.Controls")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
// [assembly: AssemblyCompany("ZeroTrilogy")]

[assembly: AssemblyProduct("DigitallyImported.Controls")]
// [assembly: AssemblyCopyright("Copyright © ZeroTrilogy 2006")]

[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: Guid("a5c4aeb2-b5de-446d-8437-2d856aeb2de1")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("2.0.*")]

//
// In order to sign your assembly you must specify a key to use. Refer to the 
// Microsoft .NET Framework documentation for more information on assembly signing.
//
// Use the attributes below to control which key is used for signing. 
//
// Notes: 
//   (*) If no key is specified, the assembly is not signed.
//   (*) KeyName refers to a key that has been installed in the Crypto Service
//       Provider (CSP) on your machine. KeyFile refers to a file which contains
//       a key.
//   (*) If the KeyFile and the KeyName values are both specified, the 
//       following processing occurs:
//       (1) If the KeyName can be found in the CSP, that key is used.
//       (2) If the KeyName does not exist and the KeyFile does exist, the key 
//           in the KeyFile is installed into the CSP and used.
//   (*) In order to create a KeyFile, you can use the sn.exe (Strong Name) utility.
//       When specifying the KeyFile, the location of the KeyFile should be
//       relative to the project output directory which is
//       %Project Directory%\obj\<configuration>. For example, if your KeyFile is
//       located in the project directory, you would specify the AssemblyKeyFile 
//       attribute as [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) Delay Signing is an advanced option - see the Microsoft .NET Framework
//       documentation for more information on this.
//

[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile(@"..\..\DigitallyImported.Controls.pfx")]
//[assembly: AssemblyKeyName("")]

[assembly:
    InternalsVisibleTo(
        "DigitallyImported.Controls.Tests.NUnit, PublicKey=0024000004800000940000000602000000240000525341310004000001000100C9AE0B1A82EEBF40923711D0BF740462635BFE9C6924E6F732DFBB6441F1B062C583D1B2B96B66384D949865DF8A381B22726B9BC6E10A083F1C7B783BA4F5A215F158DCCEF853FB4945D9BEBAB3859F34B06EC415F55386B35EC26E270D902CDFF93BC61DC855529A7AA156A49549B3310326DDF065BFAE4EAE63781779BAB3"
        )]
//[assembly: AssemblyVersionAttribute("3.0.1.12")]

[assembly: InternalsVisibleTo("DigitallyImported.Tests")]