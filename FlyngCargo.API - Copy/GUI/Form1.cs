using Entities;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Windows.Forms;
using Services.ServiceContracts.DTO;
using Services.Helpers;
using Services.ServiceContracts;
using Services;
using Microsoft.Extensions.DependencyInjection;


namespace GUI
{
    public partial class Form1 : Form
    {
        
        private readonly HttpClient _httpClient;
        //private readonly IProductServiceGUI _productServiceGUI;
        private readonly IValidationService _validationService;

        public Form1(//IProductServiceGUI productServiceGUI,
                     IValidationService validationService)
        {
            InitializeComponent();
            _validationService = validationService;
            //_productServiceGUI = productServiceGUI;
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            _httpClient = new HttpClient(handler);
            
            dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
            buttonUPD.Enabled = true;
        }
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4) // ProductName, Price, Description, StockQuantity
            {
                string newValue = e.FormattedValue.ToString();
                int rowIndex = e.RowIndex;

                
                var productId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);

                try
                {
                    switch (e.ColumnIndex)
                    {
                        case 1: // ProductName
                            _validationService.ValidateProductInput(newValue, "1", "test", "1"); 
                            break;
                        case 2: // Price
                            _validationService.ValidateProductInput("test", newValue, "test", "1");
                            break;
                        case 3: // Description
                            _validationService.ValidateProductInput("test", "1", newValue, "1");
                            break;
                        case 4: // StockQuantity
                            _validationService.ValidateProductInput("test", "1", "test", newValue);
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true; 
                }
            }
        }
        private async Task LoadProductsAsync()
        {
            var products = await GetProducts();
            dataGridView1.DataSource = products;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }

        private async Task<List<ProductDTO>> GetProducts()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:44380/api/Products");
            var products = JsonConvert.DeserializeObject<List<ProductDTO>>(response);

            return products;
        }

        private async Task AddProductAsync(ProductDTO productRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:44380/api/Products", productRequest);
            response.EnsureSuccessStatusCode();
        }

        private async Task UpdateProductAsync(ProductDTO productRequest)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:44380/api/products/{productRequest.ProductId}", productRequest);
            response.EnsureSuccessStatusCode();

        }
        private async Task DeleteProductAsync(int productId)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:44380/api/Products/{productId}");
            response.EnsureSuccessStatusCode();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadProductsAsync();
            dataGridView1.Columns[0].ReadOnly = true;
        }
        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _validationService.ValidateProductInput(textBoxName.Text, textBoxPrice.Text, textBoxDesc.Text, textBoxStock.Text);
                var newProductRequest = new ProductDTO
                {
                    ProductName = textBoxName.Text,
                    Price = decimal.Parse(textBoxPrice.Text),
                    Description = textBoxDesc.Text,
                    StockQuantity = int.Parse(textBoxStock.Text)
                };


                await AddProductAsync(newProductRequest);
                await LoadProductsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonUPD_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    
                   
                    var productRequest = new ProductDTO
                    {
                        ProductId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                        ProductName = (dataGridView1.CurrentRow.Cells[1].Value).ToString(),
                        Price = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[2].Value),
                        Description = dataGridView1.CurrentRow.Cells[3].Value.ToString(),
                        StockQuantity = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value)
                    };
                    _validationService.ValidateProductInput(productRequest.ProductName, productRequest.Price.ToString(), productRequest.Description, productRequest.StockQuantity.ToString());

                    await UpdateProductAsync(productRequest);
                    MessageBox.Show("Product successfully updated!");
                    await LoadProductsAsync();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  

            }
            else
            {
                MessageBox.Show("Please select the product which you want to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void buttonDEL_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                var confirmationResult = MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmationResult == DialogResult.Yes)
                {

                    int productId = (int)dataGridView1.CurrentRow.Cells[0].Value;
                    await DeleteProductAsync(productId);
                    await LoadProductsAsync();
                }
            }
            else
            {
                MessageBox.Show("Plese select the product you want to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }
    }
}
