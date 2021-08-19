using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDOLISTt.Models;

namespace ToDOLISTt.infrastructure
{
    public class ToDoContext:DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
             :base(options)
        {

        }
        public DbSet<Todolisst> todolissts { get; set; }
    }
}
