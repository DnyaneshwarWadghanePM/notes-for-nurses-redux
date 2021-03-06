namespace Edward.Wilde.Note.For.Nurses.iOS {
    using Edward.Wilde.Note.For.Nurses.Core.Service;
    using Edward.Wilde.Note.For.Nurses.iOS.Services;

    using MonoTouch.UIKit;

    using Edward.Wilde.Note.For.Nurses.Core;

    public class Application 
    {
		
        static void Main (string[] args)
		{
		    RegisterTypes();
		    UIApplication.Main (args, null, "AppDelegate");
		}

        private static void RegisterTypes()
        {
            RegisterCrossPlatformTypes();
            RegisterSpecificPlatformTypes();
        }

        private static void RegisterCrossPlatformTypes()
        {
            new TypeRegistrationService().RegisterAll();
        }

        private static void RegisterSpecificPlatformTypes()
        {
            new AppleTypeRegistrationService().RegisterAll();
        }
    }
}
