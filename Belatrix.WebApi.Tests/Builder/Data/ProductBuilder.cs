using Belatrix.WebApi.Repository.Postgresql;
using GenFu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Tests.Builder.Data
{
    public partial class BelatrixDbContextBuilder
    {
        public BelatrixDbContextBuilder AddTenProducts()
        {
            AddProducts(_context, 10);
            return this;
        }

        private void AddProducts(BelatrixDbContext context, int quantity)
        {
            var customerList = A.ListOf<Models.Product>(quantity);
            for (int i = 1; i <= quantity; i++)
            {
                customerList[i - 1].Id = i;
            }

            context.Products.AddRange(customerList);
            context.SaveChanges();
        }

    }
}