using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendorManager
{
    public class VendorManagerLeaf
    {
        public string LeafText { get; set; }
        public object LeafeObject { get; set; }

        public string Tooltip { get; set; }

        public Color ForeColor { get; set; }

        public Color BackColor { get; set; }
        public string LeafImageKey { get; set; }

        public IntegrationServiceType IntegrationServiceType { get; set; }
        public IntegrationVendor IntegrationVendor { get; set; }
        public IntegrationProduct IntegrationProduct { get; set; }
        public IntegrationVendorProduct IntegrationVendorProduct { get; set; }
        public IntegrationSetting IntegrationSetting { get; set; }
        public IntegrationSourceObjectType IntegrationSourceObjectType { get; set; }
        public IntegrationSettingType IntegrationSettingType { get; set; }
        public IntegrationSettingTypeSourceObject IntegrationSettingTypeSourceObject { get; set; }
        public List<VendorManagerLeaf> Children { get; set; } = new List<VendorManagerLeaf>();
    }
}
