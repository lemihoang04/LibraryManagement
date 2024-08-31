using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class Book
    {
        [Key]
        [Required]
        public string BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public bool IsAvailable { get; set; }
    }
}
