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
    public partial class dlgInput : Form
    {
        public string inputLabel { get; set; }
        public string inputValue { get; set; }

        public int inputId { get; set; }
        public dlgInput()
        {
            InitializeComponent();
            Load += DlgInput_Load;
        }

        private void DlgInput_Load(object sender, EventArgs e)
        {
            lblLabel.Text = inputLabel;
            dfsId.Text = inputId.ToString();
            Text = inputLabel;
            WriteSQL();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            inputValue = dfsValue.Text;
            inputId = int.Parse(dfsId.Text);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WriteSQL()
        {
            var sql = $"INSERT INTO[dbo].[IntegrationServiceType] "
                + $"([IntegrationServiceTypeId] "
                      + $",[Name] "
                + $",[Descr] "
                + $",[IsActive] "
                + $",[CreatedBy] "
                + $",[ModifiedBy] "
                + $",[ModifiedDate]) "
                + $"VALUES "
                + $"({dfsId.Text} "
                + $",'{dfsValue.Text}' "
                + $",'{dfsValue.Text}' "
                + $",1 "
                + $",-1"
                + $",-1 "
                + $",'{DateTime.UtcNow}' "
                + $")"
            ;


        }

        private void dfsId_TextChanged(object sender, EventArgs e)
        {
            WriteSQL();
        }

        private void dfsValue_TextChanged(object sender, EventArgs e)
        {
            WriteSQL();
        }
    }
}
