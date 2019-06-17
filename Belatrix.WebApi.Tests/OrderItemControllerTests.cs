using Belatrix.WebApi.Controllers;
using Belatrix.WebApi.Repository;
using Belatrix.WebApi.Repository.Postgresql;
using Belatrix.WebApi.Tests.Builder.Data;
using FluentAssertions;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;



namespace Belatrix.WebApi.Tests
{
    public class OrderItemControllerTests

    {
        private readonly BelatrixDbContextBuilder _builder;

        public OrderItemControllerTests()
        {
            _builder = new BelatrixDbContextBuilder();
        }

        [Fact]
        public async Task OrderItemController_GetOrderItems_Ok()
        {
            var db = _builder
                .ConfigureInMemory()
                .AddTenOrderItems()
                .Build();

            var repository = new Repository<Models.OrderItem>(db);

            var controller = new OrderItemController(repository);

            var response = (await controller.GetOrderItems())
                .Result as OkObjectResult;

            var values = response.Value as List<Models.OrderItem>;

            values.Count.Should().Be(10);
        }

        [Fact]
        public async Task OrderItemController_CreateOrderItem_Ok()
        {
            var db = _builder
            .ConfigureInMemory()
            .Build();

            var repository = new Repository<Models.OrderItem>(db);

            var controller = new OrderItemController(repository);

            var newOrderItem = A.New<Models.OrderItem>();
            var response = (await controller.PostOrderItem(newOrderItem))
                .Result as OkObjectResult;

            var values = Convert.ToInt32(response.Value);

            values.Should().Be(newOrderItem.Id);            
        }

        [Fact]
        public async Task OrderItemController_UpdateOrderItem_Ok()
        {
            var db = _builder
            .ConfigureInMemory()
            .AddOrderItem()
            .Build();

            var repository = new Repository<Models.OrderItem>(db);

            var controller = new OrderItemController(repository);

            var updateOrderItem = db.OrderItems.Find(1);
            updateOrderItem.Quantity = 15;
             
            var response = (await controller.PutOrderItem(updateOrderItem))
                .Result as OkObjectResult;

            var values = Convert.ToBoolean(response.Value);

            values.Should().Be(true);
        }

        [Fact]
        public async Task OrderItemController_DeleteOrderItem_Ok()
        {
            var db = _builder
            .ConfigureInMemory()
            .AddOrderItem()
            .Build();

            var repository = new Repository<Models.OrderItem>(db);

            var controller = new OrderItemController(repository);

            var OrderItem = db.OrderItems.Find(1);
            var response = (await controller.DeleteOrderItem(OrderItem.Id))
                .Result as OkObjectResult;

            var values = Convert.ToBoolean(response.Value);

            values.Should().Be(true);
        }

    }

}