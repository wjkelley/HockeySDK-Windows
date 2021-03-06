﻿namespace Microsoft.HockeyApp.Extensibility.Implementation
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Channel;
    using Extensibility.Implementation.Platform;
    using TestFramework;
#if WINDOWS_PHONE || WINDOWS_STORE || WINDOWS_UWP
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
    using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif
#if WINRT || WINDOWS_UWP
    using global::Windows.ApplicationModel;
    using global::Windows.Storage;
    using Services;
#endif

    [TestClass]
    public class PlatformTest
    {
        internal const string ConfigurationFileName = "HockeyApp.config";

        [TestCleanup]
        public void TestCleanup()
        {
            PlatformSingleton.Current = null;
        }

        [TestMethod]
        public void ClassIsPublicToAllowTestingOnWindowsRuntime()
        {
            Assert.IsFalse(typeof(PlatformSingleton).GetTypeInfo().IsPublic);
        }

        [TestMethod]
        public void ClassIsStaticToServeOnlyAsSingletonFactory()
        {
            Assert.IsTrue(typeof(PlatformSingleton).GetTypeInfo().IsAbstract && typeof(PlatformSingleton).GetTypeInfo().IsSealed);
        }

        [TestMethod]
        public void CurrentIsAutomaticallyInitializedForEasyAccess()
        {
            ServiceLocator.AddService<IPlatformService>(new PlatformService());
            Assert.IsNotNull(PlatformSingleton.Current);
        }

        [TestMethod]
        public void CurrentCanBeSetToEnableMocking()
        {
            var platform = new StubPlatform();
            PlatformSingleton.Current = platform;
            Assert.AreSame(platform, PlatformSingleton.Current);
        }
        
        private static void CreateConfigurationFile(string content)
        {
            using (Stream fileStream = OpenConfigurationFile())
            {
                byte[] configurationBytes = Encoding.UTF8.GetBytes(content);
                fileStream.Write(configurationBytes, 0, configurationBytes.Length);
            }           
        }
        
        private static void DeleteConfigurationFile()
        {
#if WINRT || WINDOWS_UWP
            StorageFile file = Package.Current.InstalledLocation.GetFileAsync(ConfigurationFileName).GetAwaiter().GetResult();
            file.DeleteAsync().GetAwaiter().GetResult();
#elif WINDOWS_PHONE
            File.Delete(Path.Combine(Environment.CurrentDirectory, ConfigurationFileName));
#else
            File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationFileName));
#endif
        }

        private static Stream OpenConfigurationFile()
        {
#if WINRT || WINDOWS_UWP
            StorageFile file = Package.Current.InstalledLocation.CreateFileAsync(ConfigurationFileName).GetAwaiter().GetResult();
            return file.OpenStreamForWriteAsync().GetAwaiter().GetResult();
#elif WINDOWS_PHONE
            return File.OpenWrite(Path.Combine(Environment.CurrentDirectory, ConfigurationFileName));
#else
            return File.OpenWrite(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationFileName));
#endif
        }
    }
}
