﻿// -----------------------------------------------------------------------
// <copyright file="AppleTypeRegistrationService.cs">
// Copyright Edward Wilde (c) 2013.
// </copyright>
// -----------------------------------------------------------------------
namespace Edward.Wilde.Note.For.Nurses.iOS.Services
{
    using Edward.Wilde.Note.For.Nurses.Core;
    using Edward.Wilde.Note.For.Nurses.Core.Service;
    using Edward.Wilde.Note.For.Nurses.Core.UI;

    public class AppleTypeRegistrationService
    {
        public void RegisterAll()
        {
            var container = TinyIoC.TinyIoCContainer.Current;
           
            container.Register<IFileManager, Edward.Wilde.Note.For.Nurses.iOS.FileManager>().AsSingleton();
            container.Register<IApplicationSettingsProvider, Edward.Wilde.Note.For.Nurses.iOS.ApplicationSettingsProvider>().AsSingleton();
            container.Register<ILocationListener, Edward.Wilde.Note.For.Nurses.iOS.Services.LocationListener>().AsSingleton();
            container.Register<IDistanceCalculatorService, Edward.Wilde.Note.For.Nurses.iOS.Services.DistanceCalculatorService>().AsSingleton();            
            container.Register<IScreenController, Edward.Wilde.Note.For.Nurses.iOS.UI.ScreenController>().AsSingleton();            
        }
    }
}