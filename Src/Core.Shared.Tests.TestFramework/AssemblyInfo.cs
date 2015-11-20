﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#if !WINDOWS_UWP
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyCopyright("Copyright © Microsoft. All Rights Reserved.")]
[assembly: ComVisible(false)]
#endif

[assembly: InternalsVisibleTo("Microsoft.HockeyApp.Core.Net40.Tests" + AssemblyInfo.PublicKey)]
[assembly: InternalsVisibleTo("Microsoft.HockeyApp.Core.Net46.Tests" + AssemblyInfo.PublicKey)]
[assembly: InternalsVisibleTo("Microsoft.HockeyApp.Core.Wrt81.Win81.Tests" + AssemblyInfo.PublicKey)]
[assembly: InternalsVisibleTo("Microsoft.HockeyApp.Core.Wp80.Tests" + AssemblyInfo.PublicKey)]        
[assembly: InternalsVisibleTo("Microsoft.HockeyApp.Core.Wrt81.Wpa81.Tests" + AssemblyInfo.PublicKey)]

// ToDo: Remove obsolete Assembly names for UWP.Tests
[assembly: InternalsVisibleTo("Microsoft.HockeyApp.Kit.Tests" + AssemblyInfo.PublicKey)]
[assembly: InternalsVisibleTo("Kit.UWP.Tests" + AssemblyInfo.PublicKey)]
[assembly: InternalsVisibleTo("Microsoft.HockeyApp.Kit.UWP.Tests" + AssemblyInfo.PublicKey)]
[assembly: InternalsVisibleTo("Kit.UWP.Tests2" + AssemblyInfo.PublicKey)]
[assembly: InternalsVisibleTo("Microsoft.HockeyApp.Kit.UWP.Tests2" + AssemblyInfo.PublicKey)]

[assembly: InternalsVisibleTo("Microsoft.HockeyApp.Extensibility.Wp80.Tests" + AssemblyInfo.PublicKey)]
[assembly: InternalsVisibleTo("Microsoft.HockeyApp.Extensibility.Wrt81.Wpa81.Tests" + AssemblyInfo.PublicKey)]
[assembly: InternalsVisibleTo("Microsoft.HockeyApp.Extensibility.Wrt81.Win81.Tests" + AssemblyInfo.PublicKey)]

[assembly: InternalsVisibleTo("Microsoft.HockeyApp.PersistenceChannel.Net40.Tests" + AssemblyInfo.PublicKey)]
[assembly: InternalsVisibleTo("Microsoft.HockeyApp.PersistenceChannel.Net45.Tests" + AssemblyInfo.PublicKey)]
[assembly: InternalsVisibleTo("Microsoft.HockeyApp.PersistenceChannel.Wrt81.Tests" + AssemblyInfo.PublicKey)]
[assembly: InternalsVisibleTo("Microsoft.HockeyApp.PersistenceChannel.Wp80.Tests" + AssemblyInfo.PublicKey)]
