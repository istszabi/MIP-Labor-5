namespace Labor_5
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addExistingProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sellProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sellHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(764, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProductToolStripMenuItem,
            this.sellProductToolStripMenuItem,
            this.searchProductToolStripMenuItem,
            this.sellHistoryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // addProductToolStripMenuItem
            // 
            this.addProductToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewProductToolStripMenuItem,
            this.addExistingProductToolStripMenuItem});
            this.addProductToolStripMenuItem.Name = "addProductToolStripMenuItem";
            this.addProductToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.addProductToolStripMenuItem.Text = "Add Product";
            this.addProductToolStripMenuItem.Click += new System.EventHandler(this.addProductToolStripMenuItem_Click);
            // 
            // addNewProductToolStripMenuItem
            // 
            this.addNewProductToolStripMenuItem.Name = "addNewProductToolStripMenuItem";
            this.addNewProductToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.addNewProductToolStripMenuItem.Text = "Add New Product";
            this.addNewProductToolStripMenuItem.Click += new System.EventHandler(this.addNewProductToolStripMenuItem_Click);
            // 
            // addExistingProductToolStripMenuItem
            // 
            this.addExistingProductToolStripMenuItem.Name = "addExistingProductToolStripMenuItem";
            this.addExistingProductToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.addExistingProductToolStripMenuItem.Text = "Add quantity to existing product";
            this.addExistingProductToolStripMenuItem.Click += new System.EventHandler(this.addExistingProductToolStripMenuItem_Click);
            // 
            // sellProductToolStripMenuItem
            // 
            this.sellProductToolStripMenuItem.Name = "sellProductToolStripMenuItem";
            this.sellProductToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.sellProductToolStripMenuItem.Text = "Sell Product";
            this.sellProductToolStripMenuItem.Click += new System.EventHandler(this.sellProductToolStripMenuItem_Click);
            // 
            // searchProductToolStripMenuItem
            // 
            this.searchProductToolStripMenuItem.Name = "searchProductToolStripMenuItem";
            this.searchProductToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.searchProductToolStripMenuItem.Text = "Search Product";
            this.searchProductToolStripMenuItem.Click += new System.EventHandler(this.searchProductToolStripMenuItem_Click);
            // 
            // sellHistoryToolStripMenuItem
            // 
            this.sellHistoryToolStripMenuItem.Name = "sellHistoryToolStripMenuItem";
            this.sellHistoryToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.sellHistoryToolStripMenuItem.Text = "Sell History";
            this.sellHistoryToolStripMenuItem.Click += new System.EventHandler(this.sellHistoryToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sellProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addExistingProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sellHistoryToolStripMenuItem;
    }
}

