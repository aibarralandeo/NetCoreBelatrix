using Belatrix.WebApi.Repository.Postgresql;
using GenFu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Tests.Builder.Data
{
    public partial class BelatrixDbContextBuilder
    {
        public BelatrixDbContextBuilder AddTenOrderItems()
        {
            AddOrderItems(_context, 10);
            return this;
        }

        private void AddOrderItems(BelatrixDbContext context, int quantity)
        {
            var customerList = A.ListOf<Models.OrderItem>(quantity);
            for (int i = 1; i <= quantity; i++)
            {
                customerList[i - 1].Id = i;
            }

            context.OrderItems.AddRange(customerList);
            context.SaveChanges();
        }

        public BelatrixDbContextBuilder AddOrderItem()
        {
            AddOrderItems(_context, 1);
            return this;
        }

    }
}