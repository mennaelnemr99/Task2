using System.Collections.Generic;
using System;
using System.Text.Json;
using System.IO;
public class MenuItem :IMenuItem
{
    public int Number { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string[] ExtraToppings { get; set; }
    public string[] Size { get; set; }
    public int Price { get; set; }

    public  MenuItem[] GetMenuItems()
    {
        var Options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        String JsonStringMenu = File.ReadAllText(@"Menu/Menu.json");
        MenuItem[] Menu = JsonSerializer.Deserialize<MenuItem[]>(JsonStringMenu, Options);
        return Menu;
    }  
}