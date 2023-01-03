using Xamarin.Forms;

namespace Autinaut
{
    public partial class App : Application
    {
        public App()
        {
            // From https://www.syncfusion.com/forums/177811/storing-licensing-key-best-practices
            // If you use this license key without Syncfusion account,
            // you are not able to contact Syncfusion for any technical support
            // or for any updates.
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo + DSMBaFt / QHRqVVhjVFpFdEBBXHxAd1p / VWJYdVt5flBPcDwsT3RfQF9iS3xad0ZiWHxYeH1WRg ==; Mgo + DSMBPh8sVXJ0S0J + XE9HflRDX3xKf0x / TGpQb19xflBPallYVBYiSV9jS3xSdEdqWHxfcXdTT2BbUQ ==; ORg4AjUWIQA / Gnt2VVhkQlFadVdJXGFWfVJpTGpQdk5xdV9DaVZUTWY / P1ZhSXxRd0dhUH5dcXVWQGleU0Q =; ODM5MjA2QDMyMzAyZTM0MmUzMEdpbkVNdWw3UGl5aHEzNkg0Sm5HOFoyRnhsdExHendxS3JmRmFyZlp6a2c9; ODM5MjA3QDMyMzAyZTM0MmUzMG1EdE0rdnE5M2VWTUtDbUcrR3Z4V1NQaVlLazVKNmgvanhqcHVVTnRtcVk9; NRAiBiAaIQQuGjN / V0Z + WE9EaFxKVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdERhW3Zfc3VURWdeWEZz; ODM5MjA5QDMyMzAyZTM0MmUzMFprMTVuZ0pqWjUyWDJRMDF2cDlldjZaeTgxenNNVnRoZDJDRVVjRGc4Yjg9; ODM5MjEwQDMyMzAyZTM0MmUzMEZUems4aThodHV6bHB5dTR2blZSQ3AxY21hRDEyZmxJR2xabG4xdFN3TzA9; Mgo + DSMBMAY9C3t2VVhkQlFadVdJXGFWfVJpTGpQdk5xdV9DaVZUTWY / P1ZhSXxRd0dhUH5dcXVWQWNaVkE =; ODM5MjEyQDMyMzAyZTM0MmUzMERpNW1wUnZDeTI4dEJPVEFTRllZbGpMTXd5bHViS0gxVkN0RXQrV1dzWTA9; ODM5MjEzQDMyMzAyZTM0MmUzME5tczlmbDF4dHhPdGxUNmpPeXlTcVUvVzhVclFiOXdwdjNNdzcrQ0ptRUU9; ODM5MjE0QDMyMzAyZTM0MmUzMFprMTVuZ0pqWjUyWDJRMDF2cDlldjZaeTgxenNNVnRoZDJDRVVjRGc4Yjg9");
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
