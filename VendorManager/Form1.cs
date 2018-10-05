using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using EllieMae.EMLite.DataEngine;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.Client;
using EllieMae.Encompass.Query;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.VisualBasic;
using Microsoft.Web.Administration;
using Newtonsoft.Json;
using VendorManager.Properties;
using Application = System.Windows.Forms.Application;

namespace VendorManager
{
    public partial class dlgMain : Form
    {
        private readonly Stopwatch _sw = new Stopwatch();
        private readonly VendorManager _vm = new VendorManager();
        private readonly ServiceViewModel serviceVM;
        private List<VendorManagerLeaf> vendorManagerTree;

        public dlgMain()
        {
            InitializeComponent();
            Load += DlgMain_Load;
            serviceVM = new ServiceViewModel(tvServices);
            _vm.Notification += _vm_Notification;
            
            Closing += FrmLogAnalyzer_Closing;
            tsEncompassVersions.Click += TsEncompassVersions_Click;
        }

        private void TsEncompassVersions_Click(object sender, EventArgs e)
        {
            var programFiles = GetEncompassVersionFromFolder(@"C:\Program Files (x86)\Encompass");
            var sdk =  GetEncompassVersionFromFolder(Path.Combine(tsLocalHostPath.Text, @"ExternalLibraries\Encompass\Encompass SDK"));
            var mmlBin  =  GetEncompassVersionFromFolder(Path.Combine(tsLocalHostPath.Text, @"MML.Bin"));

            if (programFiles == sdk && sdk == mmlBin)
            {
                MessageBox.Show("Encompass is installed consistently. No action is needed", "Encompass versions are Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var message = $"Encompass is not installed Consistently.\n{programFiles} in C:\\Program Files (x86)\\Encompass the version is .\n{sdk} in {Path.Combine(tsLocalHostPath.Text, "ExternalLibraries\\Encompass\\Encompass SDK")}\n{mmlBin} in {Path.Combine(tsLocalHostPath.Text, @"MML.Bin")} \n\n";
                message +=
                    $"Click Yes to set the version consistently to {programFiles}.\nClick No to set it to {sdk}.\nClick Cancel to leave it inconsistent. \nIf you intend to press Yes Or No you must \n1.stop the services \n2.Make sure you have access rights to these folders \n3.Make sure these folders are not readonly";
                var result = MessageBox.Show(message, "Encompass version inconsistent", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    CopyFiles(@"C:\Program Files (x86)\Encompass", Path.Combine(tsLocalHostPath.Text, @"ExternalLibraries\Encompass\Encompass SDK"), Path.Combine(tsLocalHostPath.Text, @"MML.Bin"));
                    MessageBox.Show("Encompass version is Consistent now", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.No)
                {
                    CopyFiles( Path.Combine(tsLocalHostPath.Text, @"ExternalLibraries\Encompass\Encompass SDK"), @"C:\Program Files (x86)\Encompass", Path.Combine(tsLocalHostPath.Text, @"MML.Bin"));
                    MessageBox.Show("Encompass version is Consistent now", "Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            
        }

        private void CopyFiles(string source, string dest1, string dest2)
        {
            var files = Directory.GetFiles(source, "*.*");
            foreach (var file in files)
            {
                try
                {

                    File.Copy(file, Path.Combine(dest1, Path.GetFileName(file)), true);
                    File.Copy(file, Path.Combine(dest2, Path.GetFileName(file)), true);
                }
                catch (Exception e)
                {
                    var result = MessageBox.Show(e.Message, "Copy Error", MessageBoxButtons.AbortRetryIgnore);
                    if (result == DialogResult.Abort)
                        Application.Exit();
                    else if (result == DialogResult.Retry)
                    {
                        Process.Start(source);
                        Process.Start(dest1);
                        Process.Start(dest2);
                    }
                }


            }
        }

        private void FrmLogAnalyzer_Closing(object sender, CancelEventArgs e)
        {
            Settings.Default.Save();
        }


        private void DlgMain_Load(object sender, EventArgs e)
        {
            if (!IsUserAdministrator())
            {
                MessageBox.Show(
                    "You must start this program as an administrator.\nPlease restart as administrator.\nThe application will now shutdown",
                    "Run as administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            if (File.Exists("DBInstances.txt"))
            {
                var instances = File.ReadAllLines("DBInstances.txt").OrderBy(x => x).ToList();
                foreach (var inst in instances)
                    dfcDatabase.Items.Add(inst);
            }
            Reload();
            LoadStatics();
            LoadScripts();
        }

        private void LoadScripts()
        {

            if (!Directory.Exists("SQL"))
                Directory.CreateDirectory("SQL");

            var files = Directory.GetFiles("SQL", "*.sql").ToList();
            var newFiles = new List<string>();
            files.ForEach(x=> newFiles.Add(Path.GetFileNameWithoutExtension(x)));
            dfcSQLScripts.DataSource = newFiles;
        }

        public bool IsUserAdministrator()
        {
            try
            {
                var user = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(user);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                return false;
            }
        }

        private void LoadStatics()
        {
            var sm = new ServerManager();
            var site = sm.Sites.FirstOrDefault(x => x.Name == "LoanCenter");
            if (site != null)
            {
                tsLocalHostPath.Text = site.Applications[0].VirtualDirectories[0].PhysicalPath;
                var webconfig = File.ReadAllText(Path.Combine(tsLocalHostPath.Text, "web.config"));
                tsLocalDB.Text = Regex.Match(webconfig, "connectionString=\"Data Source=(.*?);").Groups[1].ToString();
                dfcDatabase.Items.Insert(0, "Local," + tsLocalDB.Text);
                dfcDatabase.SelectedIndex = 0;
                var log4Net = File.ReadAllText(Path.Combine(Directory.GetParent(tsLocalHostPath.Text).FullName,
                    "MML.Services\\Integrations\\Appraisal\\Service\\log4net.config"));
                tsLog4net.Text = Regex.Match(log4Net, "Data Source=(.*?);").Groups[1].ToString();

                tsLocalHostPath.Text = Directory.GetParent(tsLocalHostPath.Text).FullName;
            }

            ShowEncompassVersions();
        }

        private void ShowEncompassVersions()
        {
            //Check MML.Bin -- EncompassObjects.dll
            //C:\ProgramFiles (x86)
            //External Libraries

            tsEncompassVersions.Text = GetEncompassVersionFromFolder(@"C:\Program Files (x86)\Encompass");
            tsEncompassVersions.Text+= "," + GetEncompassVersionFromFolder(Path.Combine(tsLocalHostPath.Text, @"ExternalLibraries\Encompass\Encompass SDK"));
            tsEncompassVersions.Text += "," + GetEncompassVersionFromFolder(Path.Combine(tsLocalHostPath.Text, @"MML.Bin"));

            var configFile =
                File.ReadAllText(Path.Combine(tsLocalHostPath.Text, @"MML.Bin\MML.ServiceHost.exe.config"));

            var encompassUserName = Regex.Match(configFile, "EncompassUserName.*?=\"(.*?)\"").Groups[1].ToString();
            var encompassPassword = Regex.Match(configFile, "EncompassPassword.*?=\"(.*?)\"").Groups[1].ToString();
            var encompassUrl = Regex.Match(configFile, "EncompassServerSource.*?=\"(.*?)\"").Groups[1].ToString();
            tsEncompassVersions.Text += "," + encompassUserName + "," + encompassPassword; // + "," + encompassUrl;

            tsEncompassVersions.ToolTipText = encompassUrl;
        }

        private string GetEncompassVersionFromFolder(string folder)
        {
            if (File.Exists(Path.Combine(folder, "EncompassObjects.dll")))
            {
                var fvi =
                    FileVersionInfo.GetVersionInfo(Path.Combine(folder, "EncompassObjects.dll"));
                return fvi.FileVersion ;
            }

            return string.Empty;
        }


        private void AddProduct()
        {
            //Add this product under the selected service, then associate it with the vendor
            var inputDialoge = new dlgInput {inputLabel = "New Product Name", inputId = _vm.MaxProductId()};
            inputDialoge.ShowDialog();
            if (string.IsNullOrEmpty(inputDialoge.inputValue)) return;
            var service =
                ((VendorManagerLeaf) tvServices.SelectedNode.Parent.Parent.Tag).LeafeObject as IntegrationServiceType;
            var newProduct = new IntegrationProduct
            {
                IntegrationProductId = inputDialoge.inputId,
                IntegrationServiceTypeId = service.IntegrationServiceTypeId,
                Name = inputDialoge.inputValue,
                Code = inputDialoge.inputValue.ToUpper().Replace(" ", "_"),
                Descr = inputDialoge.inputValue,
                IsActive = true,
                CreatedBy = -1,
                ModifiedBy = -1,
                ModifiedDate = DateTime.UtcNow
            };

            _vm.AddProduct(newProduct);


            var vendor = ((VendorManagerLeaf) tvServices.SelectedNode.Parent.Tag).LeafeObject as IntegrationVendor;
            var newVendorProduct = new IntegrationVendorProduct
            {
                IntegrationProductId = newProduct.IntegrationProductId,
                IntegrationVendorId = vendor.IntegrationVendorId,
                IsActive = true,
                CreatedBy = -1,
                ModifiedDate = DateTime.UtcNow
            };

            _vm.SaveVendorProduct(newVendorProduct);

            var newProductNode = new TreeNode
            {
                Text =
                    $"{newProduct.IntegrationProductId}-{newProduct.Name}",
                ForeColor = Color.Green,
                Tag = newProduct,
                ImageKey = "p.png",
                SelectedImageKey = "p.png"
            };


            //Settings Node
            var SettingsNode = new TreeNode
            {
                Text =
                    $"Settings",
                ForeColor = Color.Green,
                Tag = newProduct,
                ImageKey = "SettingsProduct.png",
                SelectedImageKey = "SettingsProduct.png"
            };
            newProductNode.Nodes.Add(SettingsNode);
            tvServices.SelectedNode.Parent.Nodes.Insert(tvServices.SelectedNode.Parent.Nodes.Count - 1, newProductNode);
        }

        private void AddVendor()
        {
            var inputDialoge = new dlgNewVendor {inputLabel = "New Vendor Name", inputId = _vm.MaxVendorId()};
            var selectedService =
                ((VendorManagerLeaf) tvServices.SelectedNode.Parent.Tag).LeafeObject as IntegrationServiceType;
            inputDialoge.IntegrationProducts = _vm.AllProducts
                .Where(x => selectedService != null &&
                            x.IntegrationServiceTypeId == selectedService.IntegrationServiceTypeId).ToList();
            inputDialoge.IntegrationServiceType = selectedService;
            inputDialoge.ShowDialog();
            if (string.IsNullOrEmpty(inputDialoge.inputValue)) return;
            var newVendor = new IntegrationVendor
            {
                IntegrationVendorId = inputDialoge.inputId,
                Name = inputDialoge.inputValue,
                Code = inputDialoge.inputValue.ToUpper().Replace(" ", "_"),
                Descr = inputDialoge.inputValue,
                SchemaType = inputDialoge.inputValue.ToUpper().Replace(" ", "_"),
                IsActive = true,
                CreatedBy = -1,
                ModifiedBy = -1,
                ModifiedDate = DateTime.UtcNow
            };

            var vendorId = _vm.AddVendor(newVendor);


            var newVendorProduct = new IntegrationVendorProduct
            {
                IntegrationProductId = inputDialoge.SelectedProduct.IntegrationProductId,
                IntegrationVendorId = vendorId,
                IntegrationHelperFQN = "www.EndPoint.com",
                IsActive = true,
                CreatedBy = -1,
                ModifiedBy = -1,
                ModifiedDate = DateTime.UtcNow
            };

            _vm.AssociateProductToVendor(newVendorProduct);

            var newVendorNode = new TreeNode
            {
                Text =
                    $"{newVendorProduct.IntegrationVendorId}-{newVendor.Name}",
                ForeColor = Color.Blue,
                Tag = newVendor,
                ImageKey = "V.jpg",
                SelectedImageKey = "V.jpg"
            };
            tvServices.SelectedNode.Parent.Nodes.Insert(tvServices.SelectedNode.Parent.Nodes.Count - 1, newVendorNode);
            Reload(); //Quick and dirty refresh - We should add the Product Node, Vendor and product settings node - I figured reload will do that faster so I don't have to write this part since I can accomplish it some other way - Saves my development time but wastes 6 seconds for the user
        }

        private void Reload()
        {
            _sw.Start();
            Task.Factory.StartNew(() => { vendorManagerTree = _vm.GetVendorManagerTree(); });
        }

        private void _vm_Notification(object sender, NotificationEventAgrs e)
        {
            WriteLog(e.Message);
            if (e.StatusId == 1 && _vm.Services != null) //Model created 
                Invoke((MethodInvoker) delegate
                {
                    tvServices.Nodes.Clear();
                    tsServiceCount.Text = _vm.Services.Count.ToString();
                    tsVendorCount.Text = _vm.AllVendors.Count.ToString();
                    tsProductcount.Text = _vm.AllProducts.Count.ToString();
                    tsVendorProducts.Text = _vm.AllVendorProducts.Count.ToString();
                    tsVendorSettings.Text = _vm.AllSettings.Count.ToString();
                    tsProductSettings.Text = _vm.AllSettings.Count.ToString();
                    foreach (var leaf in _vm.Services)
                        DisplayLeaf(null, leaf);
                    UpdateOrphans();
                    _sw.Stop();
                    WriteLog($"Tree created in {_sw.ElapsedMilliseconds / 1000} seconds");
                });
        }

        private void DisplayLeaf(TreeNode node, VendorManagerLeaf leaf)
        {
            if (leaf == null) return;
            var n =
                new TreeNode(
                    leaf.LeafText)
                {
                    Tag = leaf,
                    ForeColor = leaf.ForeColor,
                    BackColor = leaf.BackColor,
                    ImageKey = leaf.LeafImageKey,
                    SelectedImageKey = leaf.LeafImageKey,
                    ToolTipText = leaf.Tooltip
                };
            if (node == null)
                tvServices.Nodes.Add(n);
            else
                node.Nodes.Add(n);

            foreach (var child in leaf.Children)
                DisplayLeaf(n, child);
        }


        //private void AddProductSettings(TreeNode vendorNode)
        //{
        //    //Add settings for this vendor
        //    var productSource = _allSources.FirstOrDefault(x => x.Name == "INTEGRATION_PRODUCT");
        //    var productFields = _allSourceFields.Where(x =>
        //        x.IntegrationSourceObjectTypeId == productSource.IntegrationSourceObjectTypeId).ToList();
        //    var fields = _allFieldTypes.Where(x =>
        //        productFields.Select(p => p.IntegrationSettingTypeId).Contains(x.IntegrationSettingTypeId));

        //    foreach (var field in fields)
        //    {
        //        var actualSettingNode =
        //            new TreeNode(
        //                $"{field.Name}")
        //            {
        //                Tag = field,
        //                BackColor = Color.Silver
        //            }; //Add product setting this should be a settings object with some ids added to it

        //        vendorNode.Nodes.Add(actualSettingNode);
        //    }
        //}


        //private void AddVendorProductSettings(TreeNode vendorNode)
        //{
        //    //Add settings for this vendor
        //    var vendorProductSource = _allSources.FirstOrDefault(x => x.Name == "INTEGRATION_VENDOR_PRODUCT");
        //    var vendorProductFields = _allSourceFields.Where(x =>
        //        x.IntegrationSourceObjectTypeId == vendorProductSource.IntegrationSourceObjectTypeId).ToList();
        //    var fields = _allFieldTypes.Where(x =>
        //        vendorProductFields.Select(p => p.IntegrationSettingTypeId).Contains(x.IntegrationSettingTypeId));

        //    foreach (var field in fields)
        //    {
        //        var actualSettingNode =
        //            new TreeNode(
        //                $"{field.Name}")
        //            {
        //                Tag = field,
        //                BackColor = Color.Yellow
        //            }; //Add product setting this should be a settings object with some ids added to it

        //        vendorNode.Nodes.Add(actualSettingNode);
        //    }
        //}


        //private void AddProductsToVendor(IEnumerable<IntegrationVendorProduct> vendorProducts, TreeNode vendorNode,
        //    IntegrationVendorProduct vendor)
        //{
        //    foreach (var vendorProduct in vendorProducts) //Add products
        //    {
        //        var productNode =
        //            new TreeNode(
        //                $"{vendorProduct.IntegrationProductId}-{_allProducts.First(p => p.IntegrationProductId == vendorProduct.IntegrationProductId).Name}")
        //            {
        //                Tag = vendorProduct
        //            };
        //        vendorNode.Nodes.Add(productNode); //Vendor --> Product, ex. Appraisal -> West VM -> Appraisal
        //        //AddVendorProductSettings
        //        AddVendorProductSettings(productNode);
        //        //AddProductSettings
        //        AddProductSettings(productNode);
        //        var productSettingNode =
        //            new TreeNode(
        //                $"+Add new product setting to ({_allProducts.First(p => p.IntegrationProductId == vendorProduct.IntegrationProductId).Name}) product")
        //            {
        //                Tag = new IntegrationSourceObjectType {Name = "INTEGRATION_PRODUCT"},
        //                ForeColor = Color.Blue,
        //                BackColor = Color.Silver
        //            };
        //        productNode.Nodes.Add(productSettingNode);

        //        var vendorProductSettingsNode =
        //            new TreeNode(
        //                $"+Add new Vendor Product setting to ({_allProducts.First(p => p.IntegrationProductId == vendorProduct.IntegrationProductId).Name}) product for ({_allVendors.First(p => p.IntegrationVendorId == vendor.IntegrationVendorId).Name}) vendor")
        //            {
        //                Tag = new IntegrationSourceObjectType {Name = "INTEGRATION_VENDOR_PRODUCT"},
        //                ForeColor = Color.Blue,
        //                BackColor = Color.Tan
        //            };
        //        productNode.Nodes.Add(vendorProductSettingsNode);
        //    }
        //}


        private void tvServices_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClearAllGroupBoxes();
            dfsSQL.Text = string.Empty;
            //tvServices.SelectedNode.ExpandAll();
            GenerateSql(tvServices.SelectedNode);
            if (((VendorManagerLeaf) e.Node.Tag).LeafeObject is IntegrationServiceType)
                OnServiceNodeClicked(e);
            if (((VendorManagerLeaf) e.Node.Tag).LeafeObject is IntegrationVendor)
                OnVendorNodeClicked(e);
            if (((VendorManagerLeaf) e.Node.Tag).LeafeObject is IntegrationVendorProduct)
            {
                var vendorProduct = (IntegrationVendorProduct) ((VendorManagerLeaf) e.Node.Tag).LeafeObject;
                if (vendorProduct.IntegrationVendorProductId == 0)
                    AddProduct();
                else
                    OnVendorProductNodeClicked(e);
            }
            if (((VendorManagerLeaf) e.Node.Tag).LeafeObject is IntegrationProduct)
            {
                var vendorProduct = (IntegrationProduct) ((VendorManagerLeaf) e.Node.Tag).LeafeObject;
                if (vendorProduct.IntegrationProductId == 0)
                    AddProduct();
                {
                }
            }
            if (((VendorManagerLeaf) e.Node.Tag).LeafeObject is IntegrationSetting)
            {
                var setting = (IntegrationSetting) ((VendorManagerLeaf) e.Node.Tag).LeafeObject;
                if (setting.IntegrationSettingId == 0)
                    if (((VendorManagerLeaf) tvServices.SelectedNode.Parent.Parent.Tag).LeafeObject is IntegrationVendor
                    )
                        AddVendorSetting();
                    else if (((VendorManagerLeaf) tvServices.SelectedNode.Parent.Parent.Tag).LeafeObject is
                        IntegrationVendorProduct)
                        AddVendorProductSetting();
            }
            if (((VendorManagerLeaf) e.Node.Tag).LeafeObject is IntegrationSettingType)
            {
                var setting = (IntegrationSettingType) ((VendorManagerLeaf) e.Node.Tag).LeafeObject;
                if (setting.IntegrationSettingTypeId == 0)
                {
                    if (((VendorManagerLeaf) tvServices.SelectedNode.Parent.Parent.Tag).LeafeObject is IntegrationVendor
                    )
                        AddVendorSetting();
                    else if (((VendorManagerLeaf) tvServices.SelectedNode.Parent.Parent.Tag).LeafeObject is
                        IntegrationVendorProduct)
                        AddVendorProductSetting();
                }
                else
                {
                    OnSettingsNodeClicked(e);
                }
            }
        }

        private void GenerateSql(TreeNode n)
        {
            try
            {
                if (n.Text.ToLower().StartsWith("add new") || n.Text == "Settings") return;
                var leafObject = ((VendorManagerLeaf) n.Tag).LeafeObject;
                dfsSQL.Text += _vm.GenerateSql(leafObject);
                if (leafObject is IntegrationSettingType
                ) //Find and Generate IntegrationSettingTypeSourceObject as well as IntegrationSetting
                    if (((VendorManagerLeaf) n.Parent.Parent.Tag).LeafeObject is IntegrationVendorProduct)
                    {
                        var vendorProduct =
                            ((VendorManagerLeaf) n.Parent.Parent.Tag).LeafeObject as IntegrationVendorProduct;
                        var vendorProductSource = _vm.AllSources.First(x => x.Name == "INTEGRATION_VENDOR_PRODUCT");
                        var sourceFields = _vm.AllSourceFields.Where(X =>
                                X.IntegrationSettingTypeId ==
                                (leafObject as IntegrationSettingType).IntegrationSettingTypeId &&
                                X.IntegrationSourceObjectTypeId == vendorProductSource.IntegrationSourceObjectTypeId)
                            .ToList();
                        var thisSetting = _vm.AllSettings.FirstOrDefault(x =>
                            x.SettingSourceObjectId == vendorProduct.IntegrationVendorProductId.ToString() &&
                            sourceFields.Select(p => p.IntegrationSettingTypeSourceObjectId)
                                .Contains(x.IntegrationSettingTypeSourceObjectId.Value));
                        var thisSourceFile = sourceFields.FirstOrDefault(x =>
                            x.IntegrationSettingTypeSourceObjectId == thisSetting.IntegrationSettingTypeSourceObjectId);
                        dfsSQL.Text += _vm.GenerateSql(thisSourceFile);
                        dfsSQL.Text += _vm.GenerateSql(thisSetting);
                    }
                foreach (TreeNode nNode in n.Nodes)
                    GenerateSql(nNode);
            }
            catch (Exception ex)
            {
            }
        }

        private void ClearAllGroupBoxes()
        {
            dfsServiceName.Text = string.Empty;
            dfsServiceDescription.Text = string.Empty;

            dfsVendorCode.Text = string.Empty;
            dfsVendorDescription.Text = string.Empty;
            dfsVendorName.Text = string.Empty;
            dfsVendorSchema.Text = string.Empty;

            dfsProductCode.Text = string.Empty;
            dfsProductDescription.Text = string.Empty;
            dfsProductName.Text = string.Empty;


            dfsVendorProductFQN.Text = string.Empty;
            dfsVendorProductSimulatorUrl.Text = string.Empty;


            dfsServiceName.Text = string.Empty;
            dfsSettingCode.Text = string.Empty;
            dfsSettingDescription.Text = string.Empty;
            dfsSettingDataEntryType.Text = string.Empty;
            dfsSettingDefaultValue.Text = string.Empty;
            dfsSettingRestriction.Text = string.Empty;
            dfsSettingObjectValue.Text = string.Empty;
        }

        private void OnServiceNodeClicked(TreeViewEventArgs e)
        {
            var service = (IntegrationServiceType) ((VendorManagerLeaf) e.Node.Tag).LeafeObject;
            if (service.IntegrationServiceTypeId == 0) //this is the add new service node 
            {
                serviceVM.StartAddService();
            }
            else
            {
                dfsServiceName.Text = service.Name;
                dfsServiceDescription.Text = service.Descr;
                WriteLog(MakeToolTip(service));
                EnableGroupBoxes();
                gbProduct.Enabled = false;
                gbVendor.Enabled = false;
                gbSetting.Enabled = false;
                gbVendorProduct.Enabled = false;
            }
        }

        private void OnVendorNodeClicked(TreeViewEventArgs e)
        {
            var vendor = (IntegrationVendor) ((VendorManagerLeaf) e.Node.Tag).LeafeObject;
            if (vendor.IntegrationVendorId == 0)
            {
                WriteLog($"Add new vendor to ({tvServices.SelectedNode.Parent.Text}) service");
                AddVendor();
            }
            else
            {
                var service =
                    (tvServices.SelectedNode.Parent.Tag as VendorManagerLeaf).LeafeObject as IntegrationServiceType;
                dfsServiceName.Text = service.Name;
                dfsServiceDescription.Text = service.Descr;

                dfsVendorName.Text = vendor.Name;
                dfsVendorDescription.Text = vendor.Descr;
                dfsVendorCode.Text = vendor.Code;
                dfsVendorSchema.Text = vendor.SchemaType;
                WriteLog(MakeToolTip(vendor));
                EnableGroupBoxes();
                gbProduct.Enabled = false;
                gbService.Enabled = false;
                gbSetting.Enabled = false;
                gbVendorProduct.Enabled = false;
                btnSaveChanges.ForeColor = Color.Blue;
            }
        }

        private void OnVendorProductNodeClicked(TreeViewEventArgs e)
        {
            var vendorProduct = (IntegrationVendorProduct) ((VendorManagerLeaf) e.Node.Tag).LeafeObject;
            if (vendorProduct.IntegrationVendorProductId == 0)
            {
                WriteLog($"Add new vendor product to ({tvServices.SelectedNode.Parent.Text}) service");
                AddProduct();
            }
            else
            {
                var vendor =
                    _vm.AllVendors.FirstOrDefault(x => x.IntegrationVendorId == vendorProduct.IntegrationVendorId);
                dfsVendorName.Text = vendor.Name;
                dfsVendorDescription.Text = vendor.Descr;
                dfsVendorCode.Text = vendor.Code;
                dfsVendorSchema.Text = vendor.SchemaType;

                var product =
                    _vm.AllProducts.FirstOrDefault(x => x.IntegrationProductId == vendorProduct.IntegrationProductId);
                dfsProductName.Text = product.Name;
                dfsProductCode.Text = product.Code;
                dfsProductDescription.Text = product.Descr;
                dfsVendorProductFQN.Text = vendorProduct.IntegrationHelperFQN;
                dfsVendorProductSimulatorUrl.Text = vendorProduct.SimulatorURL;


                var service =
                    _vm.AllServices.FirstOrDefault(x => x.IntegrationServiceTypeId == product.IntegrationServiceTypeId);
                dfsServiceName.Text = service.Name;
                dfsServiceDescription.Text = service.Descr;


                WriteLog(MakeToolTip(vendorProduct));
                EnableGroupBoxes();
                gbProduct.Enabled = true;
                gbService.Enabled = false;
                gbVendor.Enabled = false;
                gbSetting.Enabled = false;
                gbVendorProduct.Enabled = true;
                btnSaveChanges.ForeColor = Color.Green;
            }
        }

        private void OnSettingsNodeClicked(TreeViewEventArgs e)
        {
            var vendorSetting = (IntegrationSettingType) ((VendorManagerLeaf) e.Node.Tag).LeafeObject;
            if (vendorSetting.IntegrationSettingTypeId == 0)
            {
                //WriteLog($"Add new vendor product to ({tvServices.SelectedNode.Parent.Text}) service");
                //AddProduct();
            }
            else
            {
                var vendorProduct =
                    ((VendorManagerLeaf) tvServices.SelectedNode.Parent.Parent.Tag).LeafeObject as
                    IntegrationVendorProduct;
                if (vendorProduct != null
                ) //Show green settings and product image - this is vendor product setting use vendorProductId to get the value
                {
                    dfsVendorProductFQN.Text = vendorProduct.IntegrationHelperFQN;
                    dfsVendorProductSimulatorUrl.Text = vendorProduct.SimulatorURL;

                    var vendor = (tvServices.SelectedNode.Parent.Parent.Parent.Tag as VendorManagerLeaf)
                        .IntegrationVendor;

                    dfsVendorCode.Text = vendor.Code;
                    dfsVendorDescription.Text = vendor.Descr;
                    dfsVendorName.Text = vendor.Name;
                    dfsVendorSchema.Text = vendor.SchemaType;


                    var service = (tvServices.SelectedNode.Parent.Parent.Parent.Parent.Tag as VendorManagerLeaf)
                        .IntegrationServiceType;

                    dfsServiceName.Text = service.Name;
                    dfsServiceDescription.Text = service.Descr;

                    //Display product above for fun
                    var product =
                        ((VendorManagerLeaf) tvServices.SelectedNode.Parent.Parent.Tag).IntegrationProduct;
                    dfsProductName.Text = product.Name;
                    dfsProductCode.Text = product.Code;
                    dfsProductDescription.Text = product.Descr;


                    picProduct.Visible = true;
                    picProductSetting.Visible = true;
                    picVendorSetting.Visible = false;
                    picVendor.Visible = false;
                }
                else //show blue image and vendor image  -- This must be vendor product -- use vendor Id to get the value
                {
                    var vendor =
                        ((VendorManagerLeaf) tvServices.SelectedNode.Parent.Parent.Tag)
                        .LeafeObject as IntegrationVendor;
                    dfsVendorName.Text = vendor.Name;
                    dfsVendorDescription.Text = vendor.Descr;
                    dfsVendorCode.Text = vendor.Code;
                    dfsVendorSchema.Text = vendor.SchemaType;

                    var service =
                        ((VendorManagerLeaf) tvServices.SelectedNode.Parent.Parent.Parent.Tag).LeafeObject as
                        IntegrationServiceType;
                    dfsServiceName.Text = service.Name;
                    dfsServiceDescription.Text = service.Descr;

                    picProduct.Visible = false;
                    picProductSetting.Visible = false;
                    picVendorSetting.Visible = true;
                    picVendor.Visible = true;
                }


                var setting = ((VendorManagerLeaf) tvServices.SelectedNode.Tag).IntegrationSetting;
                dfsSettingObjectValue.Text = setting.Value; //Get the value from IntegrationSetting

                //var service =
                //    _vm.AllServices.FirstOrDefault(x => x.IntegrationServiceTypeId == product.IntegrationServiceTypeId);
                //dfsServiceName.Text = service.Name;
                //dfsServiceDescription.Text = service.Descr;

                dfsSettingName.Text = vendorSetting.Name;
                dfsSettingCode.Text = vendorSetting.Code;
                dfsSettingDataEntryType.Text = vendorSetting.DataEntryType;
                dfsSettingDescription.Text = vendorSetting.Descr;
                dfsSettingDefaultValue.Text = vendorSetting.DefatulValue;
                dfsSettingRestriction.Text = vendorSetting.Restrictions;

                //WriteLog(MakeToolTip(vendorProduct));
                EnableGroupBoxes();
                gbProduct.Enabled = false;
                gbService.Enabled = false;
                gbVendor.Enabled = false;
                gbVendorProduct.Enabled = false;
                gbSetting.Enabled = true;
                btnSaveChanges.ForeColor = Color.Green;
            }
        }


        private void EnableGroupBoxes()
        {
            gbProduct.Enabled = true;
            gbService.Enabled = true;
            gbVendor.Enabled = true;
            gbSetting.Enabled = true;
            gbVendorProduct.Enabled = true;
            btnSaveChanges.ForeColor = Color.Black;
        }


        private string MakeToolTip(IntegrationServiceType input)
        {
            return
                $"IntegrationServiceTypeId = {input.IntegrationServiceTypeId} for {input.Descr} located at [{input.GetType().ToString().Split('.').Last()}] table";
        }

        private string MakeToolTip(IntegrationVendor input)
        {
            return
                $"IntegrationVendorId = {input.IntegrationVendorId} for {input.Descr} located at [{input.GetType().ToString().Split('.').Last()}] table";
        }

        private string MakeToolTip(IntegrationVendorProduct input)
        {
            return
                $"IntegrationVendorProductId = {input.IntegrationVendorProductId} with {input.IntegrationHelperFQN} located at [{input.GetType().ToString().Split('.').Last()}] table";
        }

        private void AddVendorProductSetting()
        {
            var vedorProductAsaSource = _vm.AllSources.First(x => x.Name == "INTEGRATION_VENDOR_PRODUCT");
            var inputDialoge = new dlgNewSetting {inputLabel = $"Setting Value"};
            var allVendorProductSettings = _vm.AllSourceFields.Where(x =>
                    x.IntegrationSourceObjectTypeId == vedorProductAsaSource.IntegrationSourceObjectTypeId)
                .Select(p => p.IntegrationSettingTypeId).ToList();
            var fieldTypes =
                _vm.AllFieldTypes; //.Where(x => allVendorProductSettings.Contains(x.IntegrationSettingTypeId)).ToList();
            inputDialoge.IntegrationSettingTypes = fieldTypes;
            inputDialoge.ShowDialog();
            if (string.IsNullOrEmpty(inputDialoge.inputValue)) return;

            var vendorProduct =
                ((VendorManagerLeaf) tvServices.SelectedNode.Parent.Parent.Tag).LeafeObject as IntegrationVendorProduct;
            var newIntegrationSettingTypeSourceObject =
                new IntegrationSettingTypeSourceObject //make sure they not already associated
                {
                    IntegrationSettingTypeId = inputDialoge.SelectedSettingType.IntegrationSettingTypeId,
                    IntegrationSourceObjectTypeId = vedorProductAsaSource
                        .IntegrationSourceObjectTypeId
                };

            _vm.AssociateSettingToSource(newIntegrationSettingTypeSourceObject);
            var newSetting = new IntegrationSetting
            {
                IntegrationSettingTypeSourceObjectId =
                    newIntegrationSettingTypeSourceObject
                        .IntegrationSettingTypeSourceObjectId, //this is the selected setting
                SettingSourceObjectId = vendorProduct.IntegrationVendorProductId.ToString(),
                Value = inputDialoge.inputValue,
                CreatedBy = -1,
                ModifiedBy = -1,
                ModifiedDate = DateTime.UtcNow
            };

            _vm.AddSetting(newSetting);

            var newsettingsNode = new TreeNode
            {
                Text =
                    $"{newSetting.IntegrationSettingId}-{inputDialoge.SelectedSettingType.Name}",
                ForeColor = Color.Green,
                Tag = new VendorManagerLeaf
                {
                    LeafeObject = newSetting,
                    IntegrationSetting = newSetting,
                    LeafText = $"{newSetting.IntegrationSettingId}-{inputDialoge.SelectedSettingType.Name}",
                    LeafImageKey = "SettingsProduct.png"
                },
                ImageKey = "SettingsProduct.png",
                SelectedImageKey = "SettingsProduct.png"
            };
            tvServices.SelectedNode.Parent.Nodes.Insert(tvServices.SelectedNode.Parent.Nodes.Count - 1,
                newsettingsNode);
        }


        private void AddVendorSetting()
        {
            var vedorProductAsaSource = _vm.AllSources.First(x => x.Name == "INTEGRATION_VENDOR");
            var inputDialoge = new dlgNewSetting {inputLabel = $"Setting Value"};
            var allVendorProductSettings = _vm.AllSourceFields.Where(x =>
                    x.IntegrationSourceObjectTypeId == vedorProductAsaSource.IntegrationSourceObjectTypeId)
                .Select(p => p.IntegrationSettingTypeId).ToList();
            var fieldTypes =
                _vm.AllFieldTypes; //.Where(x => allVendorProductSettings.Contains(x.IntegrationSettingTypeId)).ToList();
            inputDialoge.IntegrationSettingTypes = fieldTypes;
            inputDialoge.ShowDialog();
            if (string.IsNullOrEmpty(inputDialoge.inputValue)) return;

            var vendor =
                ((VendorManagerLeaf) tvServices.SelectedNode.Parent.Parent.Tag).LeafeObject as IntegrationVendor;
            var newIntegrationSettingTypeSourceObject =
                new IntegrationSettingTypeSourceObject //make sure they not already associated
                {
                    IntegrationSettingTypeId = inputDialoge.SelectedSettingType.IntegrationSettingTypeId,
                    IntegrationSourceObjectTypeId = vedorProductAsaSource.IntegrationSourceObjectTypeId
                };

            _vm.AssociateSettingToSource(newIntegrationSettingTypeSourceObject);
            var newSetting = new IntegrationSetting
            {
                IntegrationSettingTypeSourceObjectId =
                    newIntegrationSettingTypeSourceObject
                        .IntegrationSettingTypeSourceObjectId, //this is the selected setting
                SettingSourceObjectId = vendor.IntegrationVendorId.ToString(),
                Value = inputDialoge.inputValue,
                CreatedBy = -1,
                ModifiedBy = -1,
                ModifiedDate = DateTime.UtcNow
            };

            _vm.AddSetting(newSetting);

            var newsettingsNode = new TreeNode
            {
                Text =
                    $"{newSetting.IntegrationSettingId}-{inputDialoge.SelectedSettingType.Name}",
                ForeColor = Color.Blue,
                Tag = newSetting,
                ImageKey = "SettingsVendor.png",
                SelectedImageKey = "SettingsVendor.png"
            };
            tvServices.SelectedNode.Parent.Nodes.Insert(tvServices.SelectedNode.Parent.Nodes.Count - 1,
                newsettingsNode);
        }

        private void WriteLog(string inputMessage)
        {
            Invoke((MethodInvoker) delegate
            {
                if (_sw.IsRunning) inputMessage += $" : {_sw.ElapsedMilliseconds / 1000} sec Elapsed";
                dfsLog.Text = inputMessage + "\n" + dfsLog.Text;
            });
        }

        private void tvServices_KeyUp(object sender, KeyEventArgs e)
        {
            //Process the delete button
            if (e.KeyCode != Keys.Delete) return;

            if (((VendorManagerLeaf) tvServices.SelectedNode.Tag).LeafeObject is IntegrationServiceType)
            {
                var service = (IntegrationServiceType) ((VendorManagerLeaf) tvServices.SelectedNode.Tag).LeafeObject;
                if (service.IntegrationServiceTypeId == 0) return;

                var result = MessageBox.Show(
                    $"This will delete {service.Name} service and all its associated products as well as all the associations found in IntegrationVendorProduct Tables",
                    "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Cancel) return;

                _vm.DeleteService(service);
                tvServices.SelectedNode.Remove();
            }
            else if (((VendorManagerLeaf) tvServices.SelectedNode.Tag).LeafeObject is IntegrationVendor)
            {
                var vendor = (IntegrationVendor) ((VendorManagerLeaf) tvServices.SelectedNode.Tag).LeafeObject;
                if (vendor.IntegrationVendorId == 0) return;

                var result =
                    MessageBox.Show(
                        $"This will delete {vendor.Name} vendor and all the associations found in IntegrationVendorProduct Tables",
                        "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Cancel) return;
                _vm.DeleteVendor(vendor);
                tvServices.SelectedNode.Remove();
            }
            else if (((VendorManagerLeaf) tvServices.SelectedNode.Tag).LeafeObject is IntegrationProduct)
            {
                var vendor = (IntegrationProduct) ((VendorManagerLeaf) tvServices.SelectedNode.Tag).LeafeObject;
                if (vendor.IntegrationProductId == 0) return;

                var result =
                    MessageBox.Show(
                        $"This will delete {vendor.Name} product and all the associations found in IntegrationVendorProduct Tables",
                        "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Cancel) return;
                _vm.DeleteProduct(vendor);
                tvServices.SelectedNode.Remove();
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (((VendorManagerLeaf) tvServices.SelectedNode.Tag).LeafeObject is IntegrationServiceType)
                SaveService();
            else if (((VendorManagerLeaf) tvServices.SelectedNode.Tag).LeafeObject is IntegrationVendor)
                SaveVendor();
            else if (((VendorManagerLeaf) tvServices.SelectedNode.Tag).LeafeObject is IntegrationVendorProduct)
                SaveVendorProduct();
            else if (((VendorManagerLeaf) tvServices.SelectedNode.Tag).LeafeObject is IntegrationSettingType)
                SaveSettingValueAndType();
        }

        private void SaveSettingValueAndType()
        {
            var vendorSettingType =
                ((VendorManagerLeaf) tvServices.SelectedNode.Tag).LeafeObject as IntegrationSettingType;
            if (vendorSettingType != null)
            {
                //var product =
                //    _vm.AllProducts.FirstOrDefault(x => x.IntegrationProductId == vendorProduct.IntegrationProductId);

                vendorSettingType.Name = dfsSettingName.Text;
                vendorSettingType.Code = dfsSettingCode.Text;
                vendorSettingType.Descr = dfsSettingDescription.Text;
                vendorSettingType.DataEntryType = dfsSettingDataEntryType.Text;
                vendorSettingType.DefatulValue = dfsSettingDefaultValue.Text;
                vendorSettingType.Restrictions = dfsSettingRestriction.Text;
                _vm.SaveSettingType(vendorSettingType);

                var setting = (tvServices.SelectedNode.Tag as VendorManagerLeaf).IntegrationSetting;
                setting.Value = dfsSettingObjectValue.Text;
                _vm.SaveSetting(setting);

                tvServices.SelectedNode.Text = $"{vendorSettingType.IntegrationSettingTypeId}-{vendorSettingType.Name}";
            }
        }

        private void SaveVendorProduct()
        {
            var vendorProduct =
                ((VendorManagerLeaf) tvServices.SelectedNode.Tag).LeafeObject as IntegrationVendorProduct;
            if (vendorProduct != null)
            {
                var product =
                    _vm.AllProducts.FirstOrDefault(x => x.IntegrationProductId == vendorProduct.IntegrationProductId);

                product.Name = dfsProductName.Text;
                product.Code = dfsProductCode.Text;
                product.Descr = dfsProductDescription.Text;
                _vm.SaveProduct(product);

                vendorProduct.IntegrationHelperFQN = dfsVendorProductFQN.Text;
                vendorProduct.SimulatorURL = dfsVendorProductSimulatorUrl.Text;

                _vm.SaveVendorProduct(vendorProduct);
                //tvServices.SelectedNode.ToolTipText = MakeToolTip(vendor);
                tvServices.SelectedNode.Text = $"{product.IntegrationProductId}-{product.Name}";
            }
        }

        private void SaveService()
        {
            var service = ((VendorManagerLeaf) tvServices.SelectedNode.Tag).LeafeObject as IntegrationServiceType;
            if (service != null)
            {
                service.Name = dfsServiceName.Text;
                service.Descr = dfsServiceDescription.Text;
                _vm.SaveService(service);
                tvServices.SelectedNode.ToolTipText = MakeToolTip(service);
                tvServices.SelectedNode.Text = $"{service.IntegrationServiceTypeId}-{service.Name}";
            }
        }


        private void SaveVendor()
        {
            var vendor = ((VendorManagerLeaf) tvServices.SelectedNode.Tag).LeafeObject as IntegrationVendor;
            if (vendor != null)
            {
                vendor.Name = dfsVendorName.Text;
                vendor.Descr = dfsVendorDescription.Text;
                vendor.Code = dfsVendorCode.Text;
                vendor.SchemaType = dfsVendorSchema.Text;
                _vm.SaveVendor(vendor);
                tvServices.SelectedNode.ToolTipText = MakeToolTip(vendor);
                tvServices.SelectedNode.Text = $"{vendor.IntegrationVendorId}-{vendor.Name}";
            }
        }

        private void dfcDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change connection string based on the selection and reload
            _vm.SetConnection(dfcDatabase.SelectedItem.ToString());
            tvServices.Nodes.Clear();
            Reload();
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
        }

        private void dfcDatabase_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void tvServices_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                Reload();
        }

        private void tbResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void UpdateOrphans()
        {
            var orphanServices = _vm.GetOrphanServices();
            var orphanProducts = _vm.GetOrphanProducts();
            ;
            var orphanVendors = _vm.GetOrphanVendors();
            ;
            var orphanSettinTypes = _vm.GetOrphanSettingTypes();
            ;

            tsOrphanService.Text = $"{orphanServices.Count} Orphan Service";
            tsOrphanProducts.Text = $"{orphanProducts.Count} Orphan Product";
            tsOrphanVendors.Text = $"{orphanVendors.Count} Orphan Vendor";
            tsOrphanSettingType.Text = $"{orphanSettinTypes.Count} Orphan Setting Type";
        }

        private void tsOrphans_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var message = new StringBuilder();
            if (e.ClickedItem == tsOrphanService)
            {
                message.AppendLine("The following services do not have any product");
                foreach (var service in _vm.GetOrphanServices())
                    message.AppendLine($"{service.IntegrationServiceTypeId}-{service.Name}");
                MessageBox.Show(
                    message.ToString(),
                    e.ClickedItem.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.ClickedItem == tsOrphanProducts)
            {
                message.AppendLine("The following products are not linked to any vendor");
                foreach (var product in _vm.GetOrphanProducts())
                    message.AppendLine($"{product.IntegrationProductId}-{product.Name}");
                MessageBox.Show(
                    message.ToString(),
                    e.ClickedItem.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.ClickedItem == tsOrphanVendors)
            {
                message.AppendLine("The following vendors are not linked to any product");
                foreach (var vendor in _vm.GetOrphanVendors())
                    message.AppendLine($"{vendor.IntegrationVendorId}-{vendor.Name}");
                MessageBox.Show(
                    message.ToString(),
                    e.ClickedItem.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.ClickedItem == tsOrphanSettingType)
            {
                message.AppendLine("The following setting type is not linked to any source");
                foreach (var setting in _vm.GetOrphanSettingTypes())
                    message.AppendLine($"{setting.IntegrationSettingTypeId}-{setting.Name}");
                MessageBox.Show(
                    message.ToString(),
                    e.ClickedItem.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsLocalDB_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tsLocalDB.Text);
            tsStatus.Text = $"Copied {tsLocalDB.Text} to Clipboard";
        }

        private void tsLog4net_Click(object sender, EventArgs e)
        {
            if (tsLog4net.Text != tsLocalDB.Text)
            {
                var result = MessageBox.Show("Your log4net.config is not pointing to the same database of iMP, do you want to correct log4net.config?Check out all log4net.config files first using the command tf checkout log4net.config /recursive then press yes. Did you check out log4net.config files?", "Log4net.config problem", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    //find log4net in the project path and change it to the same database
                    var log4netFiles = Directory.GetFiles(tsLocalHostPath.Text, "log4net.config",
                        SearchOption.AllDirectories);
                    foreach (var log4NetFile in log4netFiles)
                    {
                        //Change connection string

                        var content = File.ReadAllText(log4NetFile);

                        content = Regex.Replace(content, "(Data Source=)(.*?);",
                            mtch => mtch.Result($"$1{tsLocalDB.Text};"), RegexOptions.IgnoreCase);

                        File.WriteAllText(log4NetFile,content);
                    }
                }

            }

            Clipboard.SetText(tsLog4net.Text);
            tsStatus.Text = $"Copied {tsLog4net.Text} to Clipboard";
        }

        public void CheckOutFromTFS(string fileName)
        {
            using (TfsTeamProjectCollection pc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("http://tfs.cloudvirga.local:8080/tfs")))
            {
                if (pc != null)
                {
                    WorkspaceInfo workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(fileName);
                    if (null != workspaceInfo)
                    {
                        Workspace workspace = workspaceInfo.GetWorkspace(pc);
                        workspace.PendEdit(fileName);
                    }
                }
            }
            FileInfo fi = new FileInfo(fileName);
        }


        private void mnuUMLDiagram_Click(object sender, EventArgs e)
        {
            var frm = new dlgUML();
            frm.Show();

        }


        private void btnReadLogi_Click(object sender, EventArgs e)
        {
            var zeroLoanId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var lm = new LogManager();
            Connection = dfcDatabase.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(Connection))
                lm.SetConnection(Connection);

            var loanId = lm.GetLoanId(dfsLoanId.Text);
            if (loanId == zeroLoanId) 
            {
                  MessageBox.Show("Loan Does not exist on this environment", "Loan does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;

             }
            var openDate = lm.GetLoanCreationDateTime(loanId);
            lblCreated.Text = openDate.ToLongDateString() + "  " + openDate.ToLongTimeString();
            var allLogs = lm.GetLogData(loanId, _maxId);

            _errors = allLogs.Where(x => x.EventType.ToLower() == "error").ToList();
            _warnings = allLogs.Where(x => x.EventType.ToLower() == "warning").ToList();
            _others = allLogs.Where(x => x.EventType.ToLower() != "warning" && x.EventType.ToLower() != "error" && !x.EventType.StartsWith("Prob", StringComparison.OrdinalIgnoreCase)).ToList();
            _prob = allLogs.Where(x => x.EventType.StartsWith("Prob", StringComparison.OrdinalIgnoreCase)).ToList();

            _errorsFiltered = _errors;
            _warningsFiltered = _warnings;
            _othersFiltered = _others;
            _probFiltered = _prob;

            _auditLog = lm.GetAuditLog(loanId);
            grdAuditLog.DataSource = _auditLog;
            _integrationServices = lm.GetIntegrationLog(loanId);
            grdIntegrationLog.DataSource = _integrationServices;
            grdErrors.DataSource = _errorsFiltered.OrderByDescending(x => x.Id).ToList();
            RemoveUnnecessaryColumns(grdErrors);
            DisplayTotals();

            //if (allLogs.Any())
            //{
            //    _maxId = allLogs.Max(x => x.Id);
            //    btnReadLogi.Text = $"Refresh > {_maxId}";
            //}
        }

        private void grdErrors_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //C:\TFS_agent\_work\53\s\Trunk.126\MML.ServiceModel\ServiceBroker.cs:line 37  
            DisplayAdditionalInfo(e);
        }

        private void DisplayAdditionalInfo(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var additionalInfo = (grdErrors.Rows[e.RowIndex].DataBoundItem as LogData).AdditionalInfo;

                if (string.IsNullOrEmpty(additionalInfo)) return;
                var uniqueClassList = new Dictionary<string, List<string>>();

                var matches = Regex.Matches(additionalInfo, @"in ((C\:\\.*?\.cs)\:.*?(\d+))");
                foreach (Match match in matches)
                {
                    var errorFileName = match.Groups[2].ToString();
                    var className = Path.GetFileName(errorFileName);
                    var lineNumber = match.Groups[3].ToString();
                    if (uniqueClassList.ContainsKey(className))
                        uniqueClassList[className].Add(lineNumber);
                    else
                        uniqueClassList.Add(className, new List<string> { lineNumber });

                    var localFileName = GetFileNameOnDisk(errorFileName);
                    if (File.Exists(localFileName))
                    {
                        var fileLines = File.ReadAllLines(localFileName);
                        var ln = int.Parse(lineNumber);
                        uniqueClassList[className][uniqueClassList[className].Count - 1] +=
                            " ==> " + fileLines[ln - 1] + Environment.NewLine + "Surronding Lines" +
                            Environment.NewLine +
                            string.Join(Environment.NewLine, fileLines.Skip(ln - 5).Take(10));
                    }
                }
                var formattedSummary = string.Empty;
                foreach (var oneClass in uniqueClassList)
                    formattedSummary += oneClass.Key + " " + string.Join(",", oneClass.Value.Distinct()) +
                                        Environment.NewLine;

                var formattedOriginal = additionalInfo.Replace(" in ", "\n\tin ").Replace(" at ", "\n\t\tat ");
                formattedSummary += Regex.Replace(formattedOriginal, "<LogicalOperationStack.*?Serialization\">", "");
                formattedSummary = Regex.Replace(formattedSummary, "&amp;#xD;&amp;#xA;", "");
                formattedSummary = Regex.Replace(formattedSummary, @".*?at.*?System\..*?[\r|\n]", "");
                var fileName = $"flog_{Guid.NewGuid()}";
                File.WriteAllText(fileName,
                    formattedSummary + "\n\n--------------------------------- Full Log File\n\n--------------------" +
                    formattedOriginal);
                Process.Start(fileName);
            }
            else if (e.ColumnIndex == 1)
            {
                var filterDate = (DateTime)grdErrors.Rows[e.RowIndex].Cells[1].Value;
                dfsFilter.Text = filterDate.Date.ToString(CultureInfo.CurrentUICulture);

                _errorsFiltered = _errors.Where(x => x.DatabaseTime != null && Math.Abs(x.DatabaseTime.Value.Subtract(filterDate).TotalMinutes) <= 1).OrderByDescending(i => i.Id).ToList();

                grdErrors.DataSource = _errorsFiltered;
                _warningsFiltered = _warnings.Where(x => x.DatabaseTime != null && Math.Abs(x.DatabaseTime.Value.Subtract(filterDate).TotalMinutes) <= 1).OrderByDescending(i => i.Id).ToList();
                grdWarningLogs.DataSource = _warningsFiltered;

                _othersFiltered = _others.Where(x => x.DatabaseTime != null && Math.Abs(x.DatabaseTime.Value.Subtract(filterDate).TotalMinutes) <= 1).OrderByDescending(i => i.Id).ToList();

                grdOtherLogs.DataSource = _othersFiltered;

                _probFiltered = _prob.Where(x => x.DatabaseTime != null && Math.Abs(x.DatabaseTime.Value.Subtract(filterDate).TotalMinutes) <= 1).OrderByDescending(i => i.Id).ToList();

                grdProb.DataSource = _probFiltered;

                RemoveUnnecessaryColumns();
                DisplayTotals();
            }
        }

        private string GetFileNameOnDisk(string errorFileName)
        {
            if (File.Exists(errorFileName)) return errorFileName;
            //in C:\TFS_agent\_work\53\s\Trunk.126\MML.Tracelisteners\ServiceTraceListener.cs:line 298 & amp;#xD;&amp;#xA;
            var codeLocation = llMeAndMyLoan.Text;
            var newFile = string.Empty;
            var sourceComponents = errorFileName.Split('\\').ToList();
            for (var index = sourceComponents.Count - 1; index > 0; index--)
            {
                newFile = sourceComponents[index] + "\\" + newFile;
                newFile = newFile.TrimEnd('\\');
                var newPhysicalFile = Path.Combine(codeLocation, newFile);
                if (File.Exists(newPhysicalFile)) return newPhysicalFile;
            }

            return errorFileName;
        }

        private void btnFilterByMachineName_Click(object sender, EventArgs e)
        {
            DisplayTotals();
        }

        private void DisplayTotals()
        {
            grdErrors.AutoGenerateColumns = true;
            grdWarningLogs.AutoGenerateColumns = true;
            grdOtherLogs.AutoGenerateColumns = true;
            tbErrors.Text = $"Errors ({_errorsFiltered.Count})";
            tbWarning.Text = $"Warnings ({_warningsFiltered.Count})";
            tbOther.Text = $"Others ({_othersFiltered.Count})";
            tbProbable.Text = $"Same Time ({_probFiltered.Count})";

            tbAuditLog.Text = $"Audit Log ({_auditLog.Count})";
            tbIntegrationServices.Text = $"Integration Services ({_integrationServices.Count})";
        }

        private void RemoveUnnecessaryColumns()
        {
            if (tbLogTabs.SelectedTab == tbErrors)
            {
                grdErrors.DataSource = _errorsFiltered;
                RemoveUnnecessaryColumns(grdErrors);
            }
            else if (tbLogTabs.SelectedTab == tbWarning)
            {
                grdWarningLogs.DataSource = _warningsFiltered;
                RemoveUnnecessaryColumns(grdWarningLogs);
            }
            else if (tbLogTabs.SelectedTab == tbOther)
            {
                grdOtherLogs.DataSource = _othersFiltered;
                RemoveUnnecessaryColumns(grdOtherLogs);
            }
            else if (tbLogTabs.SelectedTab == tbProbable)
            {
                grdProb.DataSource = _probFiltered;
                RemoveUnnecessaryColumns(grdProb);
            }
            else if (tbLogTabs.SelectedTab == tbAuditLog)
            {
                grdAuditLog.DataSource = _auditLog;
                RemoveUnnecessaryColumns(grdAuditLog);
            }
            else if (tbLogTabs.SelectedTab == tbIntegrationServices)
            {
                grdIntegrationLog.DataSource = _integrationServices;
                RemoveUnnecessaryColumns(grdIntegrationLog);
            }
        }

        private void RemoveUnnecessaryColumns(DataGridView grd)
        {
            try
            {
                if (grd == grdAuditLog)
                {
                    grd.Columns.RemoveAt(9);
                    grd.Columns.RemoveAt(8);
                    grd.Columns.RemoveAt(7);
                    grd.Columns.RemoveAt(6);
                    grd.Columns.RemoveAt(5);
                    grd.Columns.RemoveAt(4);
                    grd.Columns.RemoveAt(0);
                    grd.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grd.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grd.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else if (grd == grdIntegrationLog)
                {
                    grd.Columns.RemoveAt(8);
                    grd.Columns.RemoveAt(6);
                    grd.Columns.RemoveAt(4);
                    grd.Columns.RemoveAt(3);
                    grd.Columns.RemoveAt(2);
                    grd.Columns.RemoveAt(1);
                    grd.Columns.RemoveAt(0);
                    grd.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grd.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grd.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    grd.Columns.RemoveAt(20);
                    grd.Columns.RemoveAt(19);
                    grd.Columns.RemoveAt(18);
                    grd.Columns.RemoveAt(17);
                    grd.Columns.RemoveAt(16);
                    grd.Columns.RemoveAt(15);
                    grd.Columns.RemoveAt(14);
                    grd.Columns.RemoveAt(13);
                    grd.Columns.RemoveAt(11);
                    grd.Columns.RemoveAt(10);
                    grd.Columns.RemoveAt(8);
                    grd.Columns.RemoveAt(6);
                    grd.Columns.RemoveAt(5);
                    grd.Columns.RemoveAt(4);
                    grd.Columns.RemoveAt(3);
                    grd.Columns.RemoveAt(2);
                    grd.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grd.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grd.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grd.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grd.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grd.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void dfsFilter_Leave(object sender, EventArgs e)
        {
            if (dfsFilter.Text == string.Empty)
            {
                grdErrors.DataSource = _errors;
                grdWarningLogs.DataSource = _warnings;
                grdOtherLogs.DataSource = _others;
                grdProb.DataSource = _prob;

                _errorsFiltered = _errors;
                _warningsFiltered = _warnings;
                _othersFiltered = _others;
                _probFiltered = _prob;
                RemoveUnnecessaryColumns();
            }
            else
            {
                _errorsFiltered = _errors.Where(x =>
                    x.Message.IndexOf(dfsFilter.Text, StringComparison.OrdinalIgnoreCase) > 0 ||
                    x.Source.IndexOf(dfsFilter.Text, StringComparison.OrdinalIgnoreCase) > 0 ||
                    x.AdditionalInfo.IndexOf(dfsFilter.Text, StringComparison.OrdinalIgnoreCase) > 0).OrderByDescending(i => i.Id).ToList();

                grdErrors.DataSource = _errorsFiltered;
                _warningsFiltered = _warnings.Where(x =>
                    x.Message.Contains(dfsFilter.Text) || x.Source.Contains(dfsFilter.Text) ||
                    x.AdditionalInfo.Contains(dfsFilter.Text)).OrderByDescending(i => i.Id).ToList();
                grdWarningLogs.DataSource = _warningsFiltered;

                _othersFiltered = _others.Where(x =>
                    x.Message.Contains(dfsFilter.Text) || x.Source.Contains(dfsFilter.Text) ||
                    x.AdditionalInfo.Contains(dfsFilter.Text)).OrderByDescending(i => i.Id).ToList();

                grdOtherLogs.DataSource = _othersFiltered;

                _probFiltered = _prob.Where(x =>
                    x.Message.Contains(dfsFilter.Text) || x.Source.Contains(dfsFilter.Text) ||
                    x.AdditionalInfo.Contains(dfsFilter.Text)).OrderByDescending(i => i.Id).ToList();

                grdProb.DataSource = _probFiltered;

                RemoveUnnecessaryColumns();
            }

            DisplayTotals();
        }

        private void llMeAndMyLoan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void dfsLoanId_TextChanged(object sender, EventArgs e)
        {
            _maxId = 0;
        }

        private void grdErrors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clipboard.SetText(grdErrors.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            tsMessage.Text =
                $"Copied [{grdErrors.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()}] to Clipboard";
        }

        private void tbLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbLogTabs.SelectedTab == tbErrors)
            {
                grdErrors.DataSource = _errorsFiltered;
                RemoveUnnecessaryColumns(grdErrors);
            }
            else if (tbLogTabs.SelectedTab == tbWarning)
            {
                grdWarningLogs.DataSource = _warningsFiltered;
                RemoveUnnecessaryColumns(grdWarningLogs);
            }
            else if (tbLogTabs.SelectedTab == tbOther)
            {
                grdOtherLogs.DataSource = _othersFiltered;
                RemoveUnnecessaryColumns(grdOtherLogs);
            }
            else if (tbLogTabs.SelectedTab == tbProbable)
            {
                grdProb.DataSource = _prob;
                RemoveUnnecessaryColumns(grdProb);
            }
            else if (tbLogTabs.SelectedTab == tbAuditLog)
            {
                grdAuditLog.DataSource = _auditLog;
                RemoveUnnecessaryColumns(grdAuditLog);
            }
            else if (tbLogTabs.SelectedTab == tbIntegrationServices)
            {
                grdIntegrationLog.DataSource = _integrationServices;
                RemoveUnnecessaryColumns(grdIntegrationLog);
            }
        }

        private void grdWarningLogs_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DisplayAdditionalInfo(e);
        }

        private void grdOtherLogs_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DisplayAdditionalInfo(e);
        }

        private void grdWarningLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Clipboard.SetText(grdWarningLogs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            tsMessage.Text =
                $"Copied [{grdWarningLogs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()}] to Clipboard";
        }

        private void grdOtherLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Clipboard.SetText(grdOtherLogs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            tsMessage.Text =
                $"Copied [{grdOtherLogs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()}] to Clipboard";
        }

        private void dfsFilter_TextChanged(object sender, EventArgs e)
        {
        }

        private void dffDistinct_CheckedChanged(object sender, EventArgs e)
        {
            _errorsFiltered = new List<LogData>();
            _warningsFiltered = new List<LogData>();
            _othersFiltered = new List<LogData>();

            if (dffDistinct.Checked)
            {
                foreach (var logDatas in _errors.GroupBy(x => x.Message))
                {
                    _errorsFiltered.Add(logDatas.First());
                }
                foreach (var logDatas in _warnings.GroupBy(x => x.Message))
                {
                    _warningsFiltered.Add(logDatas.First());
                }
                foreach (var logDatas in _others.GroupBy(x => x.Message))
                {
                    _othersFiltered.Add(logDatas.First());
                }
                foreach (var logDatas in _prob.GroupBy(x => x.Message))
                {
                    _probFiltered.Add(logDatas.First());
                }
            }
            else
            {
                _errorsFiltered = _errors;
                _warningsFiltered = _warnings;
                _othersFiltered = _others;
                _probFiltered = _prob;
            }

            grdErrors.DataSource = _errorsFiltered;
            grdWarningLogs.DataSource = _warningsFiltered;
            grdOtherLogs.DataSource = _othersFiltered;
            RemoveUnnecessaryColumns(grdErrors);
            DisplayTotals();
        }

        private List<LogData> _errors = new List<LogData>();
        private List<LogData> _prob = new List<LogData>();
        private List<LogData> _errorsFiltered = new List<LogData>();
        private List<LogData> _others = new List<LogData>();
        private List<LogData> _othersFiltered = new List<LogData>();
        private List<LogData> _warnings = new List<LogData>();
        private List<LogData> _warningsFiltered = new List<LogData>();
        private List<LogData> _probFiltered = new List<LogData>();

        private List<AuditLog> _auditLog = new List<AuditLog>();
        private List<IntegrationStatusDetail> _integrationServices = new List<IntegrationStatusDetail>();

        public string Connection;
        private int _maxId;

        private void dffLast20Minutes_CheckedChanged(object sender, EventArgs e)
        {
            _errorsFiltered = new List<LogData>();
            _warningsFiltered = new List<LogData>();
            _othersFiltered = new List<LogData>();

            if (dffLast20Minutes.Checked)
            {
                _errorsFiltered = _errors.Where(x => x.DatabaseTime > DateTime.Now.AddMinutes(-20)).ToList();
                _warningsFiltered = _warnings.Where(x => x.DatabaseTime > DateTime.Now.AddMinutes(-20)).ToList();

                _othersFiltered = _others.Where(x => x.DatabaseTime > DateTime.Now.AddMinutes(-20)).ToList();

                _probFiltered = _prob.Where(x => x.DatabaseTime > DateTime.Now.AddMinutes(-20)).ToList();

            }
            else
            {
                _errorsFiltered = _errors;
                _warningsFiltered = _warnings;
                _othersFiltered = _others;
                _probFiltered = _prob;
            }

            grdErrors.DataSource = _errorsFiltered;
            RemoveUnnecessaryColumns(grdErrors);
            DisplayTotals();
        }

        private void btnRunSQL_Click(object sender, EventArgs e)
        {

                if (!Directory.Exists("SQL"))
                    Directory.CreateDirectory("SQL");

                var defaultScriptName = string.Empty;
                if (dfcSQLScripts.SelectedItem != null)
                    defaultScriptName = dfcSQLScripts.SelectedItem.ToString();

            defaultScriptName =
                    Interaction.InputBox("Enter SQL Name", "SQL Name",
                        $"{defaultScriptName}"); //Default Controller Name

                File.WriteAllText($"SQL\\{defaultScriptName}.sql", dfsSQLScript.Text);

            if (!dfsSQLScript.Text.ToLower().StartsWith("select") && !dfsSQLScript.Text.ToLower().StartsWith("update") && !dfsSQLScript.Text.ToLower().StartsWith("delete"))
            {
                //run those RegEx filters on all the log results
                var regExLines = dfsSQLScript.Lines;
                _errorsFiltered = _errors;
                _warningsFiltered = _warnings;
                _othersFiltered = _others;
                foreach (var regExLine in regExLines)
                {
                    _errorsFiltered = _errorsFiltered.Where(x=> !Regex.IsMatch(x.Message, regExLine)).ToList();
                    _warningsFiltered = _warningsFiltered.Where(x => !Regex.IsMatch(x.Message, regExLine)).ToList();
                    _othersFiltered = _othersFiltered.Where(x => !Regex.IsMatch(x.Message, regExLine)).ToList();

                }

                ApplyFilter();

            }
            else
            {
                var lm = new LogManager();
                Connection = dfcDatabase.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(Connection))
                    lm.SetConnection(Connection);

                lm.ExecuteSQL(dfsSQLScript.Text);
            }



        }

        private void ApplyFilter()
        {
            RemoveUnnecessaryColumns();
            DisplayTotals();
        }

        private void dfcSQLScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            dfsSQLScript.Text = File.ReadAllText("SQL\\" + dfcSQLScripts.SelectedItem.ToString() + ".sql");
        }

        private void dfsSQLScript_Click(object sender, EventArgs e)
        {
            grbSQLExecuter.Height = tabControl1.Height;
            dfsSQLScript.Height = tabControl1.Height - 100;
        }

        private void dfsSQLScript_Leave(object sender, EventArgs e)
        {
            dfsSQLScript.Height = 39;
            grbSQLExecuter.Height = 93;
        }

        private void dfsSQLScript_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGetEncompass_Click(object sender, EventArgs e)
        {
            var loanNumber = "5468267";
            if (File.Exists(loanNumber))
                File.Delete(loanNumber);
            var session = new Session();
            session.Start("https://TEBE11166948.ea.elliemae.net$TEBE11166948", "cloudvirgauser", "Loanpal1");
            var loanNumberCriterion = new StringFieldCriterion {FieldName = "Loan.LoanNumber", Value = loanNumber};

            var queryCriterionLoanFolder = new StringFieldCriterion
            {
                FieldName = "Loan.LoanFolder",
                Value = "(Trash)",
                MatchType = StringFieldMatchType.Exact,
                Include = false
            };

            var queryCriterion = loanNumberCriterion.And(queryCriterionLoanFolder);

            using (var pipelineCursor = session.Loans.QueryPipeline(queryCriterion, PipelineSortOrder.None))
            {
                //  Check cursor
                if (pipelineCursor == null)
                    throw new InvalidOperationException(
                        $"Pipeline query yielded no results (loan number: '{loanNumber}').");

                //  Check pipeline data
                if (pipelineCursor.Count == 0)
                {
                    pipelineCursor.Close();
                    throw new InvalidOperationException(
                        $"Pipeline cursor does not contain any data (loan number: '{loanNumber}').");
                }
                var data = pipelineCursor.GetItem(0);
                if (data == null)
                {
                    pipelineCursor.Close();
                    throw new InvalidOperationException(
                        $"Pipeline data from cursor is null (loan number: '{loanNumber}').");
                }

                //  Open loan
                var loanName = data.LoanIdentity.LoanName;
                pipelineCursor.Close();
                if (string.IsNullOrWhiteSpace(loanName))
                    throw new InvalidOperationException(
                        $"Loan name retrieved from pipeline data is null or empty (loan number: '{loanNumber}').");

                var loan = session.Loans.Folders[data.LoanIdentity.LoanFolder].OpenLoan(loanName);
                Console.WriteLine(loan.Fields["3155"].ReadOnly);
                


                //EllieMae.EMLite.DataEngine.LoanData.SetCurrentField("3155", DateTime.Now.ToString("MM/dd/yyyy")); //, BorrowerPair pair, Boolean customCalcsOnly)
                //loan.Fields["3155"].Value = DateTime.Now.ToString("MM/dd/yyyy");
                //loan.Fields["3153"].Value = DateTime.Now.ToString("MM/dd/yyyy");
                //loan.Lock(false);
                //try
                //{
                //    loan.Commit();
                //}
                //catch (Exception exception)
                //{
                //    Console.WriteLine(exception);
                //}
                
                //for (int i = 0; i < 5000; i++)
                //{
                //    try
                //    {
                //        var fld = loan.Fields[i.ToString()];
                //        File.AppendAllText(loan.LoanNumber,
                //            $"{i},{fld.Value.ToString()},{fld.Descriptor.Description},{fld.Descriptor.FieldID},{fld.Descriptor.Format},{fld.Descriptor.IsCustomField},{fld.Descriptor.MaxLength}\n");
                //    }
                //    catch (Exception exception)
                //    {

                //        //File.AppendAllText(loan.LoanNumber, $"{i} Does not exist {exception.Message}");

                //    }



                //}

                //Process.Start(loan.LoanNumber);
                Console.WriteLine(loan.Fields.ToString());
            }
        }
    }
}