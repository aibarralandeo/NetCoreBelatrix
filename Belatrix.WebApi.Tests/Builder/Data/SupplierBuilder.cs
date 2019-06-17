using Belatrix.WebApi.Repository.Postgresql;
using GenFu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Tests.Builder.Data
{
    public partial class BelatrixDbContextBuilder
    {
        public BelatrixDbContextBuilder AddTenSuppliers()
        {
            AddSuppliers(_context, 10);
            return this;
        }

        private void AddSuppliers(BelatrixDbContext context, int quantity)
        {
            var customerList = A.ListOf<Models.Supplier>(quantity);
            for (int i = 1; i <= quantity; i++)
            {
                customerList[i - 1].Id = i;
            }

            context.Suppliers.AddRange(customerList);
            context.SaveChanges();
        }

    }
}