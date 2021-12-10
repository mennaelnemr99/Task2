using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private IOrder Order = new Order();
    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public List<Order> Get()
    {
        return Order.GetOrders();
    }

    [HttpPost]
    public void Post([FromBody] List<MenuItem> Pizzas)
    {
        Order.SaveOrder(Pizzas);
    }
}