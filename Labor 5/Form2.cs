using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labor_5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void ProductAddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productNametextBox1.Text) ||
                string.IsNullOrWhiteSpace(descriptionRichTextBox.Text) ||
                string.IsNullOrWhiteSpace(quantityTextBox.Text) ||
                string.IsNullOrWhiteSpace(categoryTextBox.Text))
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            int qty;
            if (!int.TryParse(quantityTextBox.Text, out qty) || qty <= 0)
            {
                MessageBox.Show("Invalid quantity!");
                return;
            }

            try
            {
                using (ProductDbContext db = new ProductDbContext())
                {
                    CategorieProdus category = null;

                    var catQuery = from c in db.CategorieProdus
                                   where c.Denumire == categoryTextBox.Text
                                   select c;
                    List<CategorieProdus> catList = catQuery.ToList();
                    if (catList.Count > 0)
                    {
                        category = catList[0];
                    }
                    else
                    {
                        category = new CategorieProdus { Denumire = categoryTextBox.Text };
                        db.CategorieProdus.Add(category);
                        db.SaveChanges();
                    }

                    Product p = new Product
                    {
                        Name = productNametextBox1.Text,
                        Description = descriptionRichTextBox.Text,
                        EntryDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddMonths(1),
                        Quantity = qty,
                        IdCategorie = category.Id
                    };

                    db.Product.Add(p);
                    db.SaveChanges();
                }

                MessageBox.Show("Product added successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message + (ex.InnerException != null ? "\nInner: " + ex.InnerException.Message : ""));
            }
        }
    }
}
