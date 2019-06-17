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
    public class ProductControllerTests

    {
        private readonly BelatrixDbContextBuilder _builder;

        public ProductControllerTests()
        {
            _builder = new BelatrixDbContextBuilder();
        }

        [Fact]
        public async Task CustomerController_GetCustomers_Ok()
        {
            var db = _builder
                .ConfigureInMemory()
                .AddTenCustomers()
                .Build();

            var repository = new Repository<Models.Customer>(db);

            var controller = new CustomerController(repository);

            var response = (await controller.GetCustomers())
                .Result as OkObjectResult;

            var values = response.Value as List<Models.Customer>;

            values.Count.Should().Be(10);
        }

        [Fact]
        public async Task CustomerController_CreateCustomer_Ok()
        {
            var db = _builder
            .ConfigureInMemory()
            .Build();

            var repository = new Repository<Models.Customer>(db);

            var controller = new CustomerController(repository);

            var newCustomer = A.New<Models.Customer>();
            var response = (await controller.PostCustomer(newCustomer))
                .Result as OkObjectResult;

            var values = Convert.ToInt32(response.Value);

            values.Should().Be(newCustomer.Id);            
        }

        [Fact]
        public async Task CustomerController_UpdateCustomer_Ok()
        {
            var db = _builder
            .ConfigureInMemory()
            .AddCustomer()
            .Build();

            var repository = new Repository<Models.Customer>(db);

            var controller = new CustomerController(repository);

            var updateCustomer = db.Customers.Find(1);
            updateCustomer.LastName = "Ibarra";
             
            var response = (await controller.PutCustomer(updateCustomer))
                .Result as OkObjectResult;

            var values = Convert.ToBoolean(response.Value);

            values.Should().Be(true);
        }

        [Fact]
        public async Task CustomerController_DeleteCustomer_Ok()
        {
            var db = _builder
            .ConfigureInMemory()
            .AddCustomer()
            .Build();

            var repository = new Repository<Models.Customer>(db);

            var controller = new CustomerController(repository);

            var customer = db.Customers.Find(1);
            var response = (await controller.DeleteCustomer(customer.Id))
                .Result as OkObjectResult;

            var values = Convert.ToBoolean(response.Value);

            values.Should().Be(true);
        }

    }

}