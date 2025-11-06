using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Labor_5
{
   
    public partial class Form3 : Form
    {
        private int sellProductId;
        public Form3(int productId)
        {
            InitializeComponent();
            sellProductId = productId;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            using (ProductDbContext db = new ProductDbContext())
            {
                var product = db.Product.Find(sellProductId);
                if (product == null)
                {
                    MessageBox.Show("Product not found!");
                    this.Close();
                    return;
                }

                label3.Text = product.Name;
                textBox1.Text = "1";
                label2.Text = "Available: " + product.Quantity;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ProductDbContext db = new ProductDbContext())
            {
                var product = db.Product.Find(sellProductId);
                if (product == null)
                {
                    MessageBox.Show("Product not found!");
                    this.Close();
                    return;
                }

                if (!int.TryParse(textBox1.Text, out int qty) || qty <= 0)
                {
                    MessageBox.Show("Invalid quantity!");
                    return;
                }

                int soldQty = qty;
                product.Quantity -= qty;

                if (product.Quantity <= 0)
                {
                    db.Product.Remove(product);
                }
                IstoricVanzari istoric = new IstoricVanzari
                {
                    IdProdus = product.Id,
                    Cantitate = soldQty
                };

                db.SaveChanges(); 

                MessageBox.Show("Product sold!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
