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
    public class OrderControllerTests

    {
        private readonly BelatrixDbContextBuilder _builder;

        public OrderControllerTests()
        {
            _builder = new BelatrixDbContextBuilder();
        }

        [Fact]
        public async Task OrderController_GetOrders_Ok()
        {
            var database= _builder
                .ConfigureInMemory()
                .AddTenOrders()
                .Build();

            var repository = new Repository<Models.Order>(database);

            var controller = new OrderController(repository);

            var response = (await controller.GetOrders())
                .Result as OkObjectResult;

            var values = response.Value as List<Models.Order>;

            values.Count.Should().Be(10);
        }

        [Fact]
        public async Task OrderController_CreateOrder_Ok()
        {
            var database= _builder
            .ConfigureInMemory()
            .Build();

            var repository = new Repository<Models.Order>(database);

            var controller = new OrderController(repository);

            var newOrder = A.New<Models.Order>();
            var response = (await controller.PostOrder(newOrder))
                .Result as OkObjectResult;

            var values = Convert.ToInt32(response.Value);

            values.Should().Be(newOrder.Id);            
        }

        [Fact]
        public async Task OrderController_UpdateOrder_Ok()
        {
            var database= _builder
            .ConfigureInMemory()
            .AddOrder()
            .Build();

            var repository = new Repository<Models.Order>(database);

            var controller = new OrderController(repository);

            var updateOrder = database.Orders.Find(1);
            updateOrder.OrderDate = DateTime.Now;
             
            var response = (await controller.PutOrder(updateOrder))
                .Result as OkObjectResult;

            var values = Convert.ToBoolean(response.Value);

            values.Should().Be(true);
        }

        [Fact]
        public async Task OrderController_DeleteOrder_Ok()
        {
            var database= _builder
            .ConfigureInMemory()
            .AddOrder()
            .Build();

            var repository = new Repository<Models.Order>(database);

            var controller = new OrderController(repository);

            var Order = database.Orders.Find(1);
            var response = (await controller.DeleteOrder(Order.Id))
                .Result as OkObjectResult;

            var values = Convert.ToBoolean(response.Value);

            values.Should().Be(true);
        }

    }

}