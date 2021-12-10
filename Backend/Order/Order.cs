using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System;
public class Order : IOrder
{
    public int Id { get; set; }
    public List<MenuItem> Pizzas { get; set; }
    public float TotalPrice { get; set; }

    public List<Order> GetOrders()
    {
        var Options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        string JsonStringOrders = File.ReadAllText(@"Order/Orders.json");
        List<Order> Orders = JsonSerializer.Deserialize<List<Order>>(JsonStringOrders, Options);
        return Orders;
    }

    public float GetOrderTotalPrice(Order Order)
    {
        float TotalPrice = 0;
        foreach (MenuItem Pizza in Order.Pizzas)
        {
            TotalPrice += Pizza.Price;
        }
        Console.Write(TotalPrice);
        return TotalPrice;
    }

    public Order SaveOrder(List<MenuItem> Pizzas)
    {
        List<Order> Orders = GetOrders();
        Order Order = new();
        if (Orders.Count == 0)
        {
            Order.Id = 1;
        }
        else
        {
            Order.Id = Orders.Count + 1;
        }
        Order.Pizzas = Pizzas;
        Order.TotalPrice = GetOrderTotalPrice(Order);
        Orders.Add(Order);
        var Options = new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        string JsonStringOrders = JsonSerializer.Serialize<List<Order>>(Orders, Options);
        File.WriteAllText(@"Order/Orders.json", JsonStringOrders);
        return Order;
    }

}