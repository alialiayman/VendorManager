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
    public partial class dlgNewSetting : Form
    {
        public string inputLabel { get; set; }
        public string inputValue { get; set; }
        public IntegrationSourceObjectType IntegrationSourceObjectType { get; set; }
        public IntegrationSettingType SelectedSettingType { get; set; }

        public List<IntegrationSettingType> IntegrationSettingTypes { get; set; }
        public dlgNewSetting()
        {
            InitializeComponent();
            Load += DlgInput_Load;
        }

        private void DlgInput_Load(object sender, EventArgs e)
        {
            lblLabel.Text = inputLabel;
            Text = inputLabel;

            dfcProducts.DataSource = IntegrationSettingTypes;
            dfcProducts.DisplayMember = "Name";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            inputValue = dfsValue.Text;
            SelectedSettingType = dfcProducts.SelectedItem as IntegrationSettingType;
            Close();
        }
        private readonly VendorManager _vm = new VendorManager();

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            var inputDialoge = new dlgInput
            {
                inputLabel = "New TEXT Setting Name",
                inputId = _vm.MaxFieldId(),
                //IntegrationServiceType = IntegrationServiceType
            };

            inputDialoge.ShowDialog();
            dfcProducts.DataSource = null;

            var newSetting = new IntegrationSettingType
            {
                Name = inputDialoge.inputValue,
                Code = inputDialoge.inputValue.ToUpper().Replace(" ", "_"),
                Descr = inputDialoge.inputValue,
                DataEntryType = "TEXT",
                DefatulValue = "",
                Restrictions = "",
            };
            _vm.AddSettingType(newSetting);
            IntegrationSettingTypes.Add(newSetting);
            dfcProducts.DataSource = IntegrationSettingTypes;
            dfcProducts.DisplayMember = "Name";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
