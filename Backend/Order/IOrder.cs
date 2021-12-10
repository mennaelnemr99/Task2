public interface IOrder
{
    List<Order> GetOrders();
    float GetOrderTotalPrice(Order Order);
    Order SaveOrder(List<MenuItem> Pizzas);
}
