using System.Text.Json;
public class MenuItem
{
    public int Number { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string[] ExtraToppings { get; set; }
    public string[] Size { get; set; }
    public int Price { get; set; }
}