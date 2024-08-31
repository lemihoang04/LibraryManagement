using QuanLyThuVien.BLL;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyThuVien.View
{
    public partial class DetailForm : Form
    {
        public delegate void BookDelegate(Book book);
        public event BookDelegate OnBookSaved;

        public void setCBB()
        {
            QLTV_BLL bll = new QLTV_BLL();
            comboBox1.Items.AddRange(bll.GetCBB().ToArray());
        }
        public void setData(Book b)
        {
            textBox1.Text = b.BookId;
            textBox2.Text = b.Title;
            textBox3.Text = b.Author;
            dateTimePicker1.Value = b.PublishDate;
            if (b.IsAvailable == true)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            foreach (CBBItem item in comboBox1.Items)
            {
                if (item.Value == b.CategoryId)
                {
                    comboBox1.SelectedItem = item;
                    break;
                }
            }

        }
        MainForm _mform;
        public DetailForm(MainForm mform)
        {
            
            InitializeComponent();
            setCBB();
            if (mform.getSelectedRows() != null)
            {
                setData(mform.getSelectedRows());
                textBox1.ReadOnly = true;

            }
            _mform = mform;
        }
        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLTV_BLL BLL = new QLTV_BLL();
            Book book = new Book
            {
                BookId = textBox1.Text,
                Title = textBox2.Text,
                Author = textBox3.Text,
                CategoryId = ((CBBItem)comboBox1.SelectedItem).Value,
                PublishDate = dateTimePicker1.Value,
                IsAvailable = radioButton1.Checked
            };

            OnBookSaved?.Invoke(book);

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
