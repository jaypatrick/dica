﻿using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("DigitallyImported.Components")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
// [assembly: AssemblyCompany("ZeroTrilogy")]

[assembly: AssemblyProduct("DigitallyImported.Components")]
// [assembly: AssemblyCopyright("Copyright © ZeroTrilogy 2006")]

[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: Guid("20b271ae-6c7e-4721-83da-22ba762b585c")]

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

[assembly: CLSCompliant(true)]
[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile(@"..\..\DigitallyImported.Components.pfx")]
//[assembly: AssemblyKeyName("")]

[assembly:
    InternalsVisibleTo(
        "DigitallyImported.Components.Tests.NUnit, PublicKey=00240000048000009400000006020000002400005253413100040000010001008DFD0348D9BDEA7DBAAE9F13DAD65A4F1B7ECE3E4752C209D1B2D390A7A81421B2616AAF41A4B0CEBD7CF237E862FDC7B9154C46975473E1D61757D0E7AA5168282FA81B15FDABB529210DB83D624498096F96CFA1243762BEB0CCA3A9CBF24FA7E5C6A07E2AB705F000C3B0627FC4C7BA38AEABDF5C74703AF61DF3B49C36B9"
        )]
[assembly: InternalsVisibleTo("DigitallyImported.UnitTests")]