
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    
        public class RepositoryContext : DbContext
        {
            // vb bağlantısı için bir ctor oluşturacağız
            // options un içerisinde bağlantı dizesini almış olacağız ve 
            // ve bunu da "base(options)" kalıtım yolulya base e göndermiş olacağız

            // DbContextOptions nesnesi verdiğimizde, DbContext e nesneyi göndermiş olacak  
            // bu da veri tabanı bağlantısını sağlamış olacak 
            public RepositoryContext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<Book> Books { get; set; }
            //DbContext (kalıtım üzerinden devralınmış) bir metodu  OnModelCreating metodunu override ettik
            // tip konfigurasyonunu dbcontext üzerinden veri tabaından yansıtmış olduk 
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfiguration(new BookConfig());
                // model oluşturulurken BookConfig dikkate alınacak
            }
        }
    }
 
