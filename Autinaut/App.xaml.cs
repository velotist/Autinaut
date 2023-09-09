using Syncfusion.Licensing;
using Xamarin.Forms;

namespace Autinaut;

public partial class App : Application
{
    public App()
    {
        // From https://www.syncfusion.com/forums/177811/storing-licensing-key-best-practices
        // If you use this license key without Syncfusion account,
        // you are not able to contact Syncfusion for any technical support
        // or for any updates.
        SyncfusionLicenseProvider.RegisterLicense(
            "Mgo+DSMBaFt9QHFqVkJrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRcQlRjTH9WdkZjWXdXcnQ=;Mgo+DSMBPh8sVXJ2S0d+X1VPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXdTc0RmWXxecH1VQGA=;ORg4AjUWIQA/Gnt2V1hhQlJAfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5adkBiXH9dcHRcRGJc;MjY4MjMzMkAzMjMyMmUzMDJlMzBNc0Y4ZE1kdUZMWkRiRWFYVHAvcW5iQThybXFnZ2ZmVkd2TnVIQVd5SlhZPQ==;MjY4MjMzM0AzMjMyMmUzMDJlMzBqRlBFQlQreE5JeVBHYjQ5N2pVTmNrSzNWd241VXFwd05oTmpVcE9HYUpNPQ==;NRAiBiAaIQQuGjN/V0R+XU9HclRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31Tf0VmWHpec3RVT2leUQ==;MjY4MjMzNUAzMjMyMmUzMDJlMzBuRVl5N1NjandDRnBpcFRaSy8zUUR5bkc1QVZxVVgyNXZhZU1mdnZsVE93PQ==;MjY4MjMzNkAzMjMyMmUzMDJlMzBhWXFwWW1PQXdSZHdxckU4U2JJWC9TbC82WnExT0NtZ0llVXR6alIxM25RPQ==;Mgo+DSMBMAY9C3t2V1hhQlJAfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5adkBiXH9dcHVVQWBc;MjY4MjMzOEAzMjMyMmUzMDJlMzBCL2l0MERBTHk5SkFTcU9qeHR2aFNFVEZLYjkzZVFoTm56dDFaMnVIOXl3PQ==;MjY4MjMzOUAzMjMyMmUzMDJlMzBPdGU1dVZVU3RDeVhlaVozTW0vczlwZ2xQR05adUROMjBxdDNOSjBxdHRFPQ==;MjY4MjM0MEAzMjMyMmUzMDJlMzBuRVl5N1NjandDRnBpcFRaSy8zUUR5bkc1QVZxVVgyNXZhZU1mdnZsVE93PQ==");

        InitializeComponent();
        MainPage = new Main();
    }

    protected override void OnStart()
    {
        // Method intentionally left empty.
    }

    protected override void OnSleep()
    {
        // Method intentionally left empty.
    }

    protected override void OnResume()
    {
        // Method intentionally left empty.
    }
}