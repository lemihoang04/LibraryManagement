using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVien.DTO;

namespace QuanLyThuVien.DAL
{
    internal class QLTV_DAL
    {
        public List<Category> GetALLCategory()
        {
            using (QLTV db = new QLTV())
            {
                return db.Categories.ToList();
            }
        }
    }
}
