using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.BLL;
using QuanLyThuVien.DTO;

namespace QuanLyThuVien.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetDGV();
            setCBB();
            SetSort();
            comboBox2.SelectedIndex = 0;
        }
        public void SetSort()
        {
            comboBox1.Items.Add("BookId");
            comboBox1.Items.Add("Title");
            comboBox1.Items.Add("PublishDate");
            comboBox1.Items.Add("Arthur");
            comboBox1.Items.Add("IsAvailable");
        }
        public Book getSelectedRows()
        {
            Book b = new Book();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                b.BookId = dataGridView1.SelectedRows[0].Cells["BookId"].Value.ToString();
                b.Title = dataGridView1.SelectedRows[0].Cells["Title"].Value.ToString();
                b.PublishDate = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["PublishDate"].Value);
                b.Author = dataGridView1.SelectedRows[0].Cells["Author"].Value.ToString();
                b.CategoryId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["CategoryId"].Value);
                b.IsAvailable = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["IsAvailable"].Value);
                return b;
            }
            else
                return null;
        }
        public void setCBB()
        {
            QLTV_BLL bll = new QLTV_BLL();
            comboBox2.Items.Add(new CBBItem
            {
                Value = 0,
                Text = "All"
            });
            comboBox2.Items.AddRange(bll.GetCBB().ToArray());
        }
        public void SetDGV()
        {
            QLTV db = new QLTV();
            var l1 = db.Books.Select(p => new { p.BookId,p.Title,p.Category.CategoryId, p.Author,p.PublishDate,p.IsAvailable });
            dataGridView1.DataSource = l1.ToList();
        }
        public void Reload()
        {
            SetDGV();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainForm tmp = new MainForm();
            DetailForm dtp = new DetailForm(tmp);
            dtp.OnBookSaved += DetailForm_OnBookSaved;
            dtp.ShowDialog();
        }
        private void DetailForm_OnBookSaved(Book book)
        {
            QLTV_BLL BLL = new QLTV_BLL();  
            if (BLL.BookExists(book.BookId))
            {
                BLL.EditBook(book);
            }
            else
            {
                BLL.AddBook(book);
            }

            Reload();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int idLop = ((CBBItem)comboBox2.SelectedItem).Value;
            string txt = textBox1.Text;
            QLTV_BLL BLL = new QLTV_BLL();
            dataGridView1.DataSource = BLL.GetBookBySeach(idLop, txt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DetailForm dtp = new DetailForm(this);
            dtp.OnBookSaved += DetailForm_OnBookSaved;
            dtp.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    QLTV_BLL BLL = new QLTV_BLL();
                    String BookId = i.Cells["BookId"].Value.ToString();
                    BLL.DeleteBook(BookId);
                }
            }
            Reload();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
