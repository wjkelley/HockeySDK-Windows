﻿// <copyright file="StubDebugOutput.cs" company="Microsoft">
// Copyright © Microsoft. All Rights Reserved.
// </copyright>

namespace Microsoft.HockeyApp.TestFramework
{
    using System;
    using Extensibility;

    internal class StubDebugOutput : IDebugOutput
    {
        public Action<string> OnWriteLine = message => { };

        public void WriteLine(string message)
        {
            this.OnWriteLine(message);
        }

        public bool IsLogging()
        {
            return true;
        }
    }
}
