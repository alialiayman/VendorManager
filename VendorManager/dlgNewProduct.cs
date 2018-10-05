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
    public partial class dlgNewProduct : Form
    {
        public string inputLabel { get; set; }
        public string inputValue { get; set; }
        public int inputId { get; set; }
        public IntegrationServiceType IntegrationServiceType { get; set; }
        public IntegrationProduct IntegrationProduct { get; set; }
        public dlgNewProduct()
        {
            InitializeComponent();
            Load += DlgInput_Load;
        }

        private void DlgInput_Load(object sender, EventArgs e)
        {
            lblLabel.Text = inputLabel;
            Text = inputLabel;
            dfsId.Text = inputId.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            inputId = int.Parse(dfsId.Text);
            var vm = new VendorManager();
            var newProduct = new IntegrationProduct
            {
                IntegrationProductId = inputId,
                Name = dfsValue.Text,
                Code = dfsValue.Text.ToUpper().Replace(" ", "_"),
                Descr = dfsValue.Text,
                IntegrationServiceTypeId = IntegrationServiceType.IntegrationServiceTypeId,
                IsActive = true,
                CreatedBy = -1,
                ModifiedBy = -1,
                ModifiedDate = DateTime.UtcNow,

            };

            vm.AddProduct(newProduct);
            IntegrationProduct = newProduct;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dfsId_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
