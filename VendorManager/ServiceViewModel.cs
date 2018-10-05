using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendorManager
{
    public class ServiceViewModel
    {
        private readonly VendorManager _vm = new VendorManager();

        private TreeView tvServices;
        public ServiceViewModel(TreeView tv)
        {
            tvServices = tv;
        }
        public void StartAddService()
        {
            var inputDialoge = new dlgInput { inputLabel = "New Service Name" , inputId = _vm.MaxServiceId()};
            inputDialoge.ShowDialog();
            if (string.IsNullOrEmpty(inputDialoge.inputValue)) return;
            var newServiceType = new IntegrationServiceType
            {
                IntegrationServiceTypeId = inputDialoge.inputId,
                Name = inputDialoge.inputValue,
                Descr = inputDialoge.inputValue,
                IsActive = true,
                CreatedBy = -1,
                ModifiedBy = -1,
                ModifiedDate = DateTime.UtcNow,
            };

            _vm.AddService(newServiceType);
            var newServiceNode = new TreeNode
            {
                Text = $"{newServiceType.IntegrationServiceTypeId}-{newServiceType.Name}",
                ImageKey = "blank.png",
                SelectedImageKey = "blank.png",
                Tag = newServiceType,
                ToolTipText = MakeToolTip(newServiceType),
            };
            tvServices.Nodes.Insert(tvServices.Nodes.Count - 1, newServiceNode);
        }

        private string MakeToolTip(IntegrationServiceType input)
        {
            return
                $"IntegrationServiceTypeId = {input.IntegrationServiceTypeId} for ({input.Descr}) located at [{input.GetType().ToString().Split('.').Last()}] table";
        }

    }
}
