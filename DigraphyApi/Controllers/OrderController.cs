using DigraphyApi.Dto;
using DigraphyApi.Models;
using DigraphyApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigraphyApi.Controllers;

[Route("api/")]
[ApiController]
public class OrderController(IOrderService orderService) : Controller
{
    [Route("orders")]
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
    public async Task<ActionResult<List<OrderDto>>> GetOrders([FromQuery] int? collectionId,
        [FromQuery] bool? isVerified)
    {
        var ordersResult = await orderService.GetOrdersAsync(collectionId,isVerified);
        var ordersDto = ordersResult.Data;
        return Ok(ordersDto);
    }
    
    [HttpGet("{orderId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Title>))]
    [ProducesResponseType(404)]
    public async Task<ActionResult<List<TitleDto>>> GetOrder(int orderId)
    {
        var orderResult = await orderService.GetOrderAsync(orderId);
        var titleDto = orderResult.Data;
        return Ok(titleDto);
    }
}