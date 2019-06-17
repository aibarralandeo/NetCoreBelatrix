using Belatrix.WebApi.Repository.Postgresql;
using GenFu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Tests.Builder.Data
{
    public partial class BelatrixDbContextBuilder
    {
        public BelatrixDbContextBuilder AddTenOrders()
        {
            AddOrders(_context, 10);
            return this;
        }

        private void AddOrders(BelatrixDbContext context, int quantity)
        {
            var customerList = A.ListOf<Models.Order>(quantity);
            for (int i = 1; i <= quantity; i++)
            {
                customerList[i - 1].Id = i;
            }

            context.Orders.AddRange(customerList);
            context.SaveChanges();
        }

        public BelatrixDbContextBuilder AddOrder()
        {
            AddOrders(_context, 1);
            return this;
        }

    }
}
   