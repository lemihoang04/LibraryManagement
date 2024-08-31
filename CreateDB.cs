using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVien.DTO;

namespace QuanLyThuVien
{
    public class CreateDB :
        CreateDatabaseIfNotExists<QLTV>
    {
        protected override void Seed(QLTV db)
        {
            db.Categories.AddRange(new Category[]
            {
            new Category{ CategoryId = 1, Name = "Chính trị – pháp luật" },
            new Category{ CategoryId = 2, Name = "Văn học nghệ thuật" }
            });
            db.SaveChanges();

            db.Books.AddRange(new Book[]
            {
            new Book{ BookId = "1", Title = "Luật 2015", PublishDate = DateTime.ParseExact("03/03/2015", "dd/MM/yyyy", null), Author = "Luật pháp Việt Nam", CategoryId = 1, IsAvailable = true},
            new Book{ BookId = "2", Title = "Nhà giả kim", PublishDate = DateTime.ParseExact("01/02/2015", "dd/MM/yyyy", null), Author = "Paulo Coelho", CategoryId = 2, IsAvailable = true },
            new Book{ BookId = "3", Title = "Bố già", PublishDate = DateTime.ParseExact("09/08/2010", "dd/MM/yyyy", null), Author = "Mario Puzo", CategoryId = 2, IsAvailable = true },
            new Book{ BookId = "4", Title = "Số đỏ", PublishDate = DateTime.ParseExact("03/03/2025", "dd/MM/yyyy", null), Author = "Vũ Trọng Phụng", CategoryId = 1, IsAvailable = true }
            });
            db.SaveChanges();
        }
    }
}
