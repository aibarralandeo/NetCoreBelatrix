using Belatrix.WebApi.Repository.Postgresql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Tests.Builder.Data
{
    public partial class BelatrixDbContextBuilder: IDisposable
    {

        private BelatrixDbContext _context;

        public BelatrixDbContextBuilder ConfigureInMemory()
        {
            var options = new DbContextOptionsBuilder<BelatrixDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            _context = new BelatrixDbContext(options);
            return this;
        }

        public BelatrixDbContext Build()
        {
            return _context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}