using Lab10.Domain.DTOs;
using Lab10.Domain.Ports.Repository;
using Lab10.Infrastructure.Context;
using Lab10.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab10.Infrastructure.Repository;

public class OrderRepository
    : Repository<Order>,
        IOrderRepository
{
    private readonly LinqExampleDbContext _context;

    public OrderRepository(
        LinqExampleDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<List<OrderDTO>>
        GetOrdersReportAsync()
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Select(o => new OrderDTO()
            {
                OrderId = o.Orderid,
                ClientName = o.Client.Name,
                OrderDate = o.Orderdate
            })
            .ToListAsync();
    }
}