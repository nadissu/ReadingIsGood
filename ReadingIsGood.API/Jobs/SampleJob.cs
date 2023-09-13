using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quartz;
using ReadingIsGood.API.Controllers;
using ReadingIsGood.Application.Features.OrderFeature.Commands;
using ReadingIsGood.Application.Features.OrderFeature.Queries;
using ReadingIsGood.Application.Services;
using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Domain.Entities;
using ReadingIsGood.Persistance.Context;
using ReadingIsGood.Persistance.Repositories;

namespace ReadingIsGood.API.Jobs
{
   
    public class ShowDateTimeJob : BaseController, IJob
    {
        IOrderRepository _orderRepository;
        IBookRepository _bookRepository;

        public ShowDateTimeJob()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PostgreContext>();
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ReadingIsGood;User Id=postgres;Password=1905;");
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json") // Varsa, projenizin yapılandırma dosyasını belirtin.
                    .Build();
            var Context = new PostgreContext(optionsBuilder.Options,configuration);
            _orderRepository = new OrderRepository(Context);
            _bookRepository = new BookRepository(Context);
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var waitOrders = await _orderRepository.GetListAsync(x => x.OrderStatus == OrderStatus.Wait,o=>o.OrderBy(x=>x.CreateAt));
            foreach (var order in waitOrders.Items)
            {
                var book = await _bookRepository.GetAsync(b => b.Id == order.BookId);
                if (book == null)
                {
                    // Kitap bulunamadı, siparişi iptal et
                    order.OrderStatus = OrderStatus.Cancelled;
                }
                if (book.Stock >= order.Count)
                {
                    // Stok yeterli, siparişi onayla ve stoktan düş
                    book.Stock -= order.Count;
                    order.OrderStatus = OrderStatus.Approved;
                }
                else
                {
                    // Stok yetersiz, siparişi iptal et
                    order.OrderStatus = OrderStatus.Cancelled;
                }
                await _bookRepository.UpdateAsync(book);
                await _orderRepository.UpdateAsync(order);
            }
            


            await Task.CompletedTask;
        }
    }

    
   
}
