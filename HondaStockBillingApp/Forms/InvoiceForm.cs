using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace HondaStockBillingApp
{
    public partial class InvoiceForm : Form
    {
        // ✅ Properties to receive data from BillingForm
        public string CustomerName { get; set; }
        public string SaleDate { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Paid { get; set; }
        public decimal ReturnAmount { get; set; }
        public DataTable CartItems { get; set; }

        // ✅ New properties for enhanced invoice management
        public string InvoiceNumber { get; private set; }
        public decimal SubTotal { get; private set; }

        public InvoiceForm()
        {
            InitializeComponent();


            // ✅ Generate random invoice number
            GenerateInvoiceNumber();         
        }

        
        private void GenerateInvoiceNumber()
        {
            Random random = new Random();
            int year = DateTime.Now.Year;
            int randomNumber = random.Next(100000, 999999); // 6-digit random number
            InvoiceNumber = $"HON-{year}-{randomNumber}";
        }

        /// <summary>
        /// Calculate subtotal from cart items
        /// </summary>
        private void CalculateSubTotal()
        {
            SubTotal = 0;
            if (CartItems != null && CartItems.Rows.Count > 0)
            {
                foreach (DataRow row in CartItems.Rows)
                {
                    try
                    {
                        decimal qty = Convert.ToDecimal(row["qty"]);
                        decimal price = Convert.ToDecimal(row["price"]);
                        SubTotal += (qty * price);
                    }
                    catch (Exception ex)
                    {
                        // Handle conversion errors gracefully
                        MessageBox.Show($"Error calculating subtotal: {ex.Message}", "Calculation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        /// <summary>
        /// Validate and recalculate totals to ensure consistency
        /// </summary>
        private void ValidateAndRecalculateTotals()
        {
            CalculateSubTotal();

            // Calculate grand total (SubTotal - Discount)
            decimal calculatedGrandTotal = SubTotal - Discount;

            // Update GrandTotal if it seems inconsistent
            if (Math.Abs(GrandTotal - calculatedGrandTotal) > 0.01m)
            {
                GrandTotal = calculatedGrandTotal;
            }

            // Ensure GrandTotal is not negative
            if (GrandTotal < 0)
                GrandTotal = 0;

            // ✅ ReturnAmount can now be positive (Return) or negative (Due)
            ReturnAmount = Paid - GrandTotal;
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            try
            {
                // ✅ Validate and recalculate totals
                ValidateAndRecalculateTotals();

                // ✅ Fill labels with data
                lblCustomer.Text = "Customer: " + (!string.IsNullOrEmpty(CustomerName) ? CustomerName : "Walk-in Customer");
                lblDate.Text = "Date: " + (!string.IsNullOrEmpty(SaleDate) ? SaleDate : DateTime.Now.ToString("dd/MM/yyyy"));

                // ✅ Display financial information
                lblSubTotal.Text = $"Sub Total: Rs {SubTotal:N2}";
                lblDiscount.Text = $"Discount: Rs {Discount:N2}";
                lblTotal.Text = $"Grand Total: Rs {GrandTotal:N2}";
                lblPaid.Text = $"Paid: Rs {Paid:N2}";
                lblReturn.Text = ReturnAmount >= 0
                        ? $"Return: Rs {ReturnAmount:N2}"
                            : $"Due: Rs {Math.Abs(ReturnAmount):N2}";


                // ✅ Bind DataTable to DataGridView
                if (CartItems != null && CartItems.Rows.Count > 0)
                {
                    dgvInvoice.DataSource = CartItems;
                    FormatDataGridView();
                }
                else
                {
                    // Show message if no items
                    MessageBox.Show("No items found in the cart.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading invoice data: {ex.Message}", "Loading Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Format the DataGridView for better appearance
        /// </summary>
        private void FormatDataGridView()
        {
            if (dgvInvoice.DataSource != null)
            {
                // Format columns if they exist
                foreach (DataGridViewColumn column in dgvInvoice.Columns)
                {
                    switch (column.Name.ToLower())
                    {
                        case "code":
                            column.HeaderText = "Product Code";
                            column.Width = 120;
                            break;
                        case "name":
                            column.HeaderText = "Product Name";
                            column.Width = 250;
                            break;
                        case "qty":
                            column.HeaderText = "Quantity";
                            column.Width = 80;
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;
                        case "price":
                            column.HeaderText = "Unit Price";
                            column.Width = 100;
                            column.DefaultCellStyle.Format = "N2";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            break;
                    }
                }
            }

            if (dgvInvoice.DataSource != null)
            {
                // Auto-size columns to fill the grid
                dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Center-align all column headers
                dgvInvoice.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Center-align all cell values
                dgvInvoice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
         
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ✅ Enhanced printing logic with invoice number and subtotal
      

   
        public string GetInvoiceSummary()
        {
            return $"Customer: {CustomerName ?? "Walk-in Customer"}\n" +
                   $"Date: {SaleDate ?? DateTime.Now.ToString("dd/MM/yyyy")}\n" +
                   $"Sub Total: Rs {SubTotal:N2}\n" +
                   $"Discount: Rs {Discount:N2}\n" +
                   $"Grand Total: Rs {GrandTotal:N2}\n" +
                   $"Paid: Rs {Paid:N2}\n" +
                   $"Return: Rs {ReturnAmount:N2}";
        }

        // Add these event handlers for button hover effects (if using the updated designer code)
      

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
          
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {

        }

        private void lblSubTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblShopName_Click(object sender, EventArgs e)
        {

        }

        private void lblInvoiceNo_Click(object sender, EventArgs e)
        {

        }
    }
}