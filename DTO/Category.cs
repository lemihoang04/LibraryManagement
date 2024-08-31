using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }
        [Key]
        [Required]
        public int CategoryId { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
