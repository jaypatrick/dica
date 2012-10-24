#region using declarations

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#endregion

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//

[assembly: AssemblyTitle("DI Channel Aggregator")]
[assembly: AssemblyDescription("A simple channel Aggregator for DI.fm.")]
[assembly: AssemblyConfiguration("")]
// [assembly: AssemblyCompany("JaysonKnight.com")]

[assembly: AssemblyProduct("DI Channel Aggregator")]
// [assembly: AssemblyCopyright("Copyright 2005 :: Jayson Knight")]

[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

// [assembly: AssemblyVersion("2.1.0.15")]

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

[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile(@"..\..\DigitallyImported.Client.pfx")]
//[assembly: AssemblyKeyName("")]

[assembly: Guid("959CCFE1-7821-4ec9-AA60-3238AE44B2BB")]
[assembly:
    InternalsVisibleTo(
        "DigitallyImported.Client.Tests.NUnit, PublicKey=00240000048000009400000006020000002400005253413100040000010001004B558744A36FC5F3A5A07636592FDFB13DFA03FD6E355D038FE14EAF20B5A181419F6F707FD348FFD7116D4AF6057CCEBCFFEBD02965B86FCBF77BBE4F95FDCAFD66AD86F8D12581E066769B7E2310BBF8F253F015BC4046E9B944C00F08DC4D23B3E08677DFFA5036DD9289C68E59155A4A4993A6BD716842A88553018E9ECB"
        )]
[assembly: InternalsVisibleTo("DigitallyImported.UnitTests")]