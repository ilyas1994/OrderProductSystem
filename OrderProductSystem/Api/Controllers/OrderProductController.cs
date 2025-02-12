using CQRSAndMediatR.Read;
using DataBase;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;
using UseCases.Dto;
using UseCases.interfaces;

namespace OrderProductSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderProductController : ControllerBase
{
    private readonly IOrders _orders;
    

    public OrderProductController(IOrders orders)
    {
        _orders = orders;
    }


    [HttpGet("GetOrder")]
    public async Task<IActionResult> GetOrder()
    {
        try
        {
            var data = await _orders.GetAllOrdersLogic();
            return Ok(data);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    [HttpGet("GetProducts")]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            var data = await _orders.GetAllProductsLogic();
            return Ok(data);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    [HttpPost("InsertNewOrder")]
    public async Task<IActionResult> InsertNewOrder(CreateOrderDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = await _orders.CreateOrder(dto);
            return Ok(data);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    [HttpPut("UpdateCountOrder")]
    public async Task<IActionResult> UpdateOrder(UpdateOrderDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _orders.UpdateOrder(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    [HttpDelete("RemoveOrder/{OrderId}")]
    public async Task<IActionResult> RemoveOrder(Guid OrderId)
    {
        try
        {
            if (OrderId == Guid.Empty) throw new Exception($"Недопустимый OrderId - {OrderId}");
            await _orders.RemoveOrder(OrderId);
            return Ok();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    /// <summary>
    /// Восстановить заказ
    /// </summary>
    /// <param name="OrderId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [HttpGet("RecoveryOrder/{OrderId}")]
    public async Task<IActionResult> RecoveryOrder(Guid OrderId)
    {
        try
        {
            if (OrderId == Guid.Empty) throw new Exception($"Недопустимый OrderId - {OrderId}");
            await _orders.RecoveryOrder(OrderId);
            return Ok();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}