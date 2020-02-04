# wayf-jwt-net
Tilføj følgende til appsettings.json

```javascript
"Wayf": {
    "WayfPublicKey": "" // Public key kan findes her: https://metadata.wayf.dk/wayf-metadata.xml
    "Endpoint": "https://wayf.wayf.dk/saml2jwt",
    "Issuer": "",
    "Acs": "",
  },
```

# Configuration
Startup.cs
```csharp
public IConfiguration Configuration { get; }

public Startup(IConfiguration configuration)
{
    Configuration = configuration;
}

public void ConfigureServices(IServiceCollection services)
{
    services.AddWayf(Configuration.GetSection("Wayf"));
}
```
Controller, "/wayf/ls" er det endpoint som er Wayf er konfigureret til at svare tilbage på.
```csharp
private readonly WayfClient wayfClient;

public WayfController(WayfClient wayfClient)
{
    this.wayfClient = wayfClient;
}

public async Task<IActionResult> Index()
{
    var url = await wayfClient.RedirectUrl(); // Vis alle idP'er
    var nemlogon = await wayfClient.NemLogin(); // Benyt nemlogon, kræver opsætning af Wayf.
    var scoping = await wayfClient.RedirectUrl("https://nemlogin.wayf.dk"); // Scoping, vælger idP for brugeren. Læs mere på https://www.wayf.dk/da/scoping
    return Redirect(url);
}

[HttpPost("/wayf/ls")]
public async Task<IActionResult> ValidateWayfLogin()
{
    var data = await wayfClient.ValidateAsync(Request.Body);
    return Json(data);
}
```
