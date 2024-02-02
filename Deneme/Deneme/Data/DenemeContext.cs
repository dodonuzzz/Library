using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Deneme.Models;

namespace Deneme.Data
{
    public class DenemeContext : DbContext
    {
        public DenemeContext (DbContextOptions<DenemeContext> options)
            : base(options)
        {
        }

        public DbSet<Deneme.Models.BookViewModel> BookViewModel { get; set; } = default!;
    }
}
