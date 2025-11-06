using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Microsoft.VisualBasic;

namespace Labor_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();

        }

        private void LoadProducts()
        {
            var productsForGrid = new List<object>();

            try
            {
                using (ProductDbContext db = new ProductDbContext())
                {
                    List<CategorieProdus> categories = new List<CategorieProdus>();
                    foreach (var c in db.CategorieProdus)
                    {
                        categories.Add(c);
                    }


                    foreach (var p in db.Product)
                    {
                        CategorieProdus cat = null;

                        foreach (var c in categories)
                        {
                            if (c.Id == p.IdCategorie)
                            {
                                cat = c;
                                break;
                            }
                        }

                        productsForGrid.Add(new
                        {
                            p.Id,
                            p.Name,
                            p.Description,
                            CategoryId = p.IdCategorie,
                            CategoryName = cat != null ? cat.Denumire : "",
                            p.EntryDate,
                            p.ExpirationDate,
                            p.Quantity
                        });
                    }
                }


                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke(new Action(delegate { dataGridView1.DataSource = productsForGrid; }));
                }
                else
                {
                    dataGridView1.DataSource = productsForGrid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sellProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to sell.");
                return;
            }

            int productId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

            string inputQtyStr = Interaction.InputBox("Enter quantity to sell:", "Sell Product");
            int qty;
            bool qtyOk = int.TryParse(inputQtyStr, out qty);

            if (!qtyOk || qty <= 0)
            {
                MessageBox.Show("Invalid quantity!");
                return;
            }

            using (ProductDbContext db = new ProductDbContext())
            {
                Product product = db.Product.Find(productId);

                if (product != null)
                {
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
                    db.IstoricVanzari.Add(istoric);
                    db.SaveChanges();
                    MessageBox.Show("Product sold successfully!");
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("Product not found!");
                }
            }
        }

        private void searchProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string searchName = Interaction.InputBox("Product name:", "Product searching");

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                using (ProductDbContext db = new ProductDbContext())
                {
                    var results =
                        (from p in db.Product
                         where p.Name.Contains(searchName)
                         select p).ToList();
                    if (results.Count == 0)
                    {
                        MessageBox.Show("No result!");
                    }
                    else
                    {
                        dataGridView1.DataSource = results;
                    }
                }
            }
        }
        private void addQuantityExistingProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string inputId = Interaction.InputBox("Enter Product ID:", "Add quantity to existing product");
            int productId;
            bool idOk = int.TryParse(inputId, out productId);
            if (idOk == false)
            {
                MessageBox.Show("Invalid Product ID!");
                return;
            }

            string inputQty = Interaction.InputBox("Enter quantity to add:", "Add quantity");
            int qty;
            bool qtyOk = int.TryParse(inputQty, out qty);
            if (qtyOk == false || qty <= 0)
            {
                MessageBox.Show("Invalid quantity!");
                return;
            }

            using (ProductDbContext db = new ProductDbContext())
            {
                Product product = db.Product.Find(productId);

                if (product != null)
                {
                    product.Quantity = product.Quantity + qty;
                    db.SaveChanges();

                    MessageBox.Show("Quantity updated successfully!");
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("Product not found!");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form2 addForm = new Form2())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        private void addExistingProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string inputId = Interaction.InputBox("Enter product ID to add quantity:", "Add Existing Product");

            int productId;
            bool success = int.TryParse(inputId, out productId);
            if (success == false)
            {
                MessageBox.Show("Invalid ID!");
                return;
            }

            using (ProductDbContext db = new ProductDbContext())
            {
                Product product =
                    (from p in db.Product
                     where p.Id == productId
                     select p).FirstOrDefault();

                if (product == null)
                {
                    MessageBox.Show("Product not found!");
                    return;
                }


                string qtyStr = Interaction.InputBox($"Enter quantity to add for '{product.Name}':", "Add Quantity");
                if (!int.TryParse(qtyStr, out int qty) || qty <= 0) return;

                product.Quantity += qty;
                db.SaveChanges();
                MessageBox.Show("Quantity updated successfully!");
                LoadProducts();
            }
        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int productId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

            using (ProductDbContext db = new ProductDbContext())
            {
                using (Form3 sellForm = new Form3(productId))
                {
                    if (sellForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadProducts();
                    }
                }

            }
        }

        private void sellHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var historyForGrid = new List<object>();

            using (ProductDbContext db = new ProductDbContext())
            {
                List<Product> allProducts = new List<Product>();
                foreach (var p in db.Product)
                {
                    allProducts.Add(p);
                }

                foreach (var h in db.IstoricVanzari)
                {
                    Product prod = null;
                    foreach (var p in allProducts)
                    {
                        if (p.Id == h.IdProdus)
                        {
                            prod = p;
                            break;
                        }
                    }

                    CategorieProdus cat = null;
                    if (prod != null)
                    {
                        foreach (var c in db.CategorieProdus)
                        {
                            if (c.Id == prod.IdCategorie)
                            {
                                cat = c;
                                break;
                            }
                        }
                    }

                    historyForGrid.Add(new
                    {
                        h.Id,
                        ProductName = prod != null ? prod.Name : "Deleted product",
                        Category = cat != null ? cat.Denumire : "",
                        h.Cantitate
                    });
                }
            }

            dataGridView1.DataSource = historyForGrid;
        }
    }
}

