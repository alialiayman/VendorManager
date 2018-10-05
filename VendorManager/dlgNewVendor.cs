using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendorManager
{
    public partial class dlgNewVendor : Form
    {
        public string inputLabel { get; set; }
        public string inputValue { get; set; }
        public int inputId { get; set; }
        public IntegrationServiceType IntegrationServiceType { get; set; }
        public IntegrationProduct SelectedProduct { get; set; }

        public List<IntegrationProduct> IntegrationProducts { get; set; }
        public dlgNewVendor()
        {
            InitializeComponent();
            Load += DlgInput_Load;
        }

        private void DlgInput_Load(object sender, EventArgs e)
        {
            lblLabel.Text = inputLabel;
            Text = inputLabel;
            dfsId.Text = inputId.ToString();
            dfcProducts.DataSource = IntegrationProducts;
            dfcProducts.DisplayMember = "Name";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            inputValue = dfsValue.Text;
            inputId = int.Parse(dfsId.Text);
            SelectedProduct = dfcProducts.SelectedItem as IntegrationProduct;
            Close();
        }

        private readonly VendorManager _vm = new VendorManager();
        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            var inputDialoge = new dlgNewProduct
            {
                inputLabel = "New Product Name",
                IntegrationServiceType = IntegrationServiceType,
                inputId = _vm.MaxProductId(),
            };

            inputDialoge.ShowDialog();
            dfcProducts.DataSource = null;
            IntegrationProducts.Add(inputDialoge.IntegrationProduct);
            dfcProducts.DataSource = IntegrationProducts;
            dfcProducts.DisplayMember = "Name";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
