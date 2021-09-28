using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Note_BOR.Models;

namespace Note_BOR.Contexts
{
    public class NoteContext : DbContext
    {
        public NoteContext (DbContextOptions<NoteContext> options)
            : base(options)
        {
        }

        public DbSet<Note_BOR.Models.NoteM> NoteM { get; set; }
    }
}
