using QuanLyThuVien.DTO;
using System;
using System.Data.Entity;
using System.Linq;
using QuanLyThuVien.DTO;

namespace QuanLyThuVien
{
    public class QLTV : DbContext
    {
        // Your context has been configured to use a 'QLTV' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'QuanLyThuVien.QLTV' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLTV' 
        // connection string in the application configuration file.
        public QLTV()
            : base("name=QLTV")
        {
            Database.SetInitializer<QLTV>(new CreateDB());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}