using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly ILogger<MenuController> _logger;
    public MenuController(ILogger<MenuController> logger)
    {
        _logger = logger;
    }
    private IMenuItem MenuItem = new MenuItem();

    [HttpGet]
    public MenuItem[] Get()
    {
        return MenuItem.GetMenuItems();
    }
}