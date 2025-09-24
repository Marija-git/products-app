using ProductsApp.API.DTOs.Request;
using ProductsApp.GUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductsApp.GUI.UI
{
    public partial class ProductForm : Form
    {
        private readonly ProductService _productService;

        public ProductForm()
        {
            InitializeComponent();
            _productService = new ProductService();
            LoadProductsAsync();
        }

        private async void LoadProductsAsync()
        {
            try
            {
                lblStatus.Text = "Loading products...";
                lblStatus.ForeColor = Color.Blue;

                var products = await _productService.GetAllWithCategoriesAsync();

                // Bind to DataGridView
                dgvProducts.DataSource = products.Select(p => new
                {
                    p.ProductId,
                    p.ProductName,
                    p.Price,
                    p.Description,
                    p.StockQuantity,
                    CreatedAt = p.CreatedAt.ToString("yyyy-MM-dd"),
                    Categories = string.Join(", ", p.Categories.Select(c => c.CategoryName))
                }).ToList();

                lblStatus.Text = $"Loaded {products.Count} products";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
                lblStatus.ForeColor = Color.Red;
            }
        }

        private async void btnGetById_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtProductId.Text, out int id))
                {
                    var product = await _productService.GetByIdWithCategoriesAsync(id);

                    txtName.Text = product.ProductName;
                    txtPrice.Text = product.Price.ToString();
                    txtDescription.Text = product.Description;
                    txtStock.Text = product.StockQuantity.ToString();

                    lblStatus.Text = $"Product {id} loaded";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("Please enter valid Product ID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var categoryIds = txtCategoryIds.Text
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(id => int.Parse(id.Trim()))
                    .ToList();

                var request = new ProductDtoRequest
                {
                    ProductName = txtName.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Description = txtDescription.Text,
                    StockQuantity = int.Parse(txtStock.Text),
                    CategoryIds = categoryIds
                };

                var newProduct = await _productService.AddProductAsync(request);

                MessageBox.Show($"Product '{newProduct.ProductName}' created successfully!");
                ClearForm();
                LoadProductsAsync(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtProductId.Text, out int productId))
                {
                    MessageBox.Show("Please enter a valid Product ID.");
                    return;
                }

              //  int productId = (int)dgvProducts.CurrentRow.Cells["ProductId"].Value;

                var categoryIds = txtCategoryIds.Text
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(id => int.Parse(id.Trim()))
                    .ToList();

                var request = new ProductDtoRequest
                {
                    ProductName = txtName.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Description = txtDescription.Text,
                    StockQuantity = int.Parse(txtStock.Text),
                    CategoryIds = categoryIds
                };

                var updatedProduct = await _productService.UpdateProductAsync(productId, request);

                MessageBox.Show($"Product '{updatedProduct.ProductName}' updated successfully!");
                ClearForm();
                LoadProductsAsync(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtProductId.Text, out int id))
                {
                    var result = MessageBox.Show($"Are you sure you want to delete product {id}?",
                        "Confirm Delete", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        await _productService.DeleteProductAsync(id);
                        MessageBox.Show("Product deleted successfully!");
                        ClearForm();
                        LoadProductsAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProductsAsync();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtProductId.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
            txtStock.Text = "";
        }

  

        private void ProductForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _productService?.Dispose();
        }
    }
}
