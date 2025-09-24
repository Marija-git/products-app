namespace ProductsApp.GUI.UI
{
    partial class ProductForm
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
            dgvProducts = new DataGridView();
            txtProductId = new TextBox();
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtDescription = new TextBox();
            txtStock = new TextBox();
            lblStatus = new Label();
            btnGetById = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnClear = new Button();
            txtCategoryIds = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(6, 13);
            dgvProducts.Margin = new Padding(3, 4, 3, 4);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(1039, 400);
            dgvProducts.TabIndex = 0;
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(14, 440);
            txtProductId.Margin = new Padding(3, 4, 3, 4);
            txtProductId.Name = "txtProductId";
            txtProductId.PlaceholderText = "Product ID";
            txtProductId.Size = new Size(114, 27);
            txtProductId.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(149, 440);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Product Name";
            txtName.Size = new Size(171, 27);
            txtName.TabIndex = 2;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(343, 440);
            txtPrice.Margin = new Padding(3, 4, 3, 4);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "Price";
            txtPrice.Size = new Size(114, 27);
            txtPrice.TabIndex = 3;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(480, 440);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Description";
            txtDescription.Size = new Size(228, 27);
            txtDescription.TabIndex = 4;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(731, 440);
            txtStock.Margin = new Padding(3, 4, 3, 4);
            txtStock.Name = "txtStock";
            txtStock.PlaceholderText = "Stock";
            txtStock.Size = new Size(114, 27);
            txtStock.TabIndex = 5;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(14, 547);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 20);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "Ready";
            // 
            // btnGetById
            // 
            btnGetById.Location = new Point(14, 493);
            btnGetById.Margin = new Padding(3, 4, 3, 4);
            btnGetById.Name = "btnGetById";
            btnGetById.Size = new Size(86, 31);
            btnGetById.TabIndex = 6;
            btnGetById.Text = "Get By ID";
            btnGetById.UseVisualStyleBackColor = true;
            btnGetById.Click += btnGetById_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(114, 493);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(86, 31);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(217, 493);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(86, 31);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(320, 493);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(86, 31);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(423, 493);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(86, 31);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnUpdate
            // 
            btnUpdate = new Button();
            btnUpdate.Location = new Point(523, 493); 
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(86, 31);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtCategoryIds
            // 
            txtCategoryIds.Location = new Point(873, 440);
            txtCategoryIds.Margin = new Padding(3, 4, 3, 4);
            txtCategoryIds.Name = "txtCategoryIds";
            txtCategoryIds.PlaceholderText = "Category IDs (comma separated)";
            txtCategoryIds.Size = new Size(342, 27);
            txtCategoryIds.TabIndex = 0;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1227, 600);
            Controls.Add(txtCategoryIds);
            Controls.Add(dgvProducts);
            Controls.Add(txtProductId);
            Controls.Add(txtName);
            Controls.Add(txtPrice);
            Controls.Add(txtDescription);
            Controls.Add(txtStock);
            Controls.Add(btnGetById);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnRefresh);
            Controls.Add(btnClear);
            Controls.Add(lblStatus);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProductForm";
            Text = "Product Management";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProducts;
        private TextBox txtProductId;
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtDescription;
        private TextBox txtStock;
        private TextBox txtCategoryIds;
        private Label lblStatus;
        private Button btnGetById;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnClear;

    }
}