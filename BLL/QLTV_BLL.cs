using QuanLyThuVien.DAL;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL
{
    internal class QLTV_BLL
    {
        public List<CBBItem> GetCBB()
        {
            List<CBBItem> list = new List<CBBItem>();

            QLTV_DAL dal = new QLTV_DAL();
            foreach (Category i in dal.GetALLCategory())
            {
                list.Add(new CBBItem
                {
                    Value = i.CategoryId,
                    Text = i.Name
                });
            }

            return list;
        }
        public List<Book> GetBookBySeach(int id, String txt)
        {
            QLTV db = new QLTV();
            if(id == 0)
            {
                return db.Books.Where(p => p.Title.Contains(txt)).ToList();
            }
            else
            {
                return db.Books.Where(p => p.CategoryId == id && p.Title.Contains(txt)).ToList();
            }
           
        }
        public bool BookExists(string bookId)
        {
            QLTV db = new QLTV();
            return db.Books.Any(b => b.BookId == bookId);
        }
        public void AddBook(Book book)
        {
            QLTV db = new QLTV();
            db.Books.Add(book);
            db.SaveChanges();
        }
        public void DeleteBook(string id) {
            QLTV db = new QLTV();
            Book sdel = db.Books.Find(id);
            db.Books.Remove(sdel);
            db.SaveChanges();
        }
        public void EditBook(Book book)
        {
            QLTV db = new QLTV();
            Book sedit = db.Books.Find(book.BookId);
            sedit.Title = book.Title;
            sedit.Author = book.Author;
            sedit.CategoryId = book.CategoryId;
            sedit.PublishDate = book.PublishDate;
            sedit.IsAvailable = book.IsAvailable;
            db.SaveChanges();
        }
    }
}
