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
    public class SupplierControllerTests

    {
        private readonly BelatrixDbContextBuilder _builder;

        public SupplierControllerTests()
        {
            _builder = new BelatrixDbContextBuilder();
        }

        [Fact]
        public async Task SupplierController_GetSuppliers_Ok()
        {
            var db = _builder
                .ConfigureInMemory()
                .AddTenSuppliers()
                .Build();

            var repository = new Repository<Models.Supplier>(db);

            var controller = new SupplierController(repository);

            var response = (await controller.GetSuppliers())
                .Result as OkObjectResult;

            var values = response.Value as List<Models.Supplier>;

            values.Count.Should().Be(10);
        }

        [Fact]
        public async Task SupplierController_CreateSupplier_Ok()
        {
            var db = _builder
            .ConfigureInMemory()
            .Build();

            var repository = new Repository<Models.Supplier>(db);

            var controller = new SupplierController(repository);

            var newSupplier = A.New<Models.Supplier>();
            var response = (await controller.PostSupplier(newSupplier))
                .Result as OkObjectResult;

            var values = Convert.ToInt32(response.Value);

            values.Should().Be(newSupplier.Id);            
        }

        [Fact]
        public async Task SupplierController_UpdateSupplier_Ok()
        {
            var db = _builder
            .ConfigureInMemory()
            .AddTenCustomers()
            .Build();

            var repository = new Repository<Models.Supplier>(db);

            var controller = new SupplierController(repository);

            var updateSupplier = db.Suppliers.Find(1);
            updateSupplier.Country = "Peru";
             
            var response = (await controller.PutSupplier(updateSupplier))
                .Result as OkObjectResult;

            var values = Convert.ToBoolean(response.Value);

            values.Should().Be(true);
        }

        [Fact]
        public async Task SupplierController_DeleteSupplier_Ok()
        {
            var db = _builder
            .ConfigureInMemory()
            .AddTenSuppliers()
            .Build();

            var repository = new Repository<Models.Supplier>(db);

            var controller = new SupplierController(repository);

            var Supplier = db.Suppliers.Find(1);
            var response = (await controller.DeleteSupplier(Supplier.Id))
                .Result as OkObjectResult;

            var values = Convert.ToBoolean(response.Value);

            values.Should().Be(true);
        }

    }

}