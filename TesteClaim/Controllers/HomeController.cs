using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TesteClaim.Models;

namespace TesteClaim.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Colaborador colaborador = new()
        {
            Id = 1,
            Nmae = "Josué",
            Permissions = "add, remove, edit",
            UserClaim = "colaborador",
            ListPermissions = new Dictionary<string, bool>() { { "add", true }, { "remove", true }, { "list", true } },
            ListUserClaims = new Dictionary<string, bool>() { { "colaborador", true } }
        };

        Colaborador chefe = new()
        {
            Id = 2,
            Nmae = "Diogo",
            Permissions = "add, remove, list, edit",
            UserClaim = "Chefe",
            ListPermissions = new Dictionary<string, bool>() { { "add", true }, { "remove", true }, { "list", true }, { "edit", true } },
            ListUserClaims = new Dictionary<string, bool>() { { "Chefe", true } }
        };


        foreach(var permission in chefe.ListPermissions)
            if (!colaborador.ListPermissions.ContainsKey(permission.Key))
                colaborador.ListPermissions.Add(permission.Key, false);


        return View(colaborador);
    }

    [HttpPost]
    public IActionResult Index(Colaborador colaborador)
    {

        var teste = colaborador;
        return View();
    }

    public IActionResult Privacy()
    {
        

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public class Colaborador
{
    public int Id { get; set; }
    public string Nmae { get; set; }
    public string Permissions { get; set; }
    public string UserClaim { get; set; }

    public IDictionary<string, bool> ListPermissions { get; set; }
    public IDictionary<string, bool> ListUserClaims { get; set; }
}
