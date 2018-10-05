using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using EnvDTE;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RestSharp;
using VendorManager.Properties;
using Process = System.Diagnostics.Process;

namespace VendorManager
{
    public partial class dlgUML : Form
    {
        private static DTE _visualStudio;
        private readonly PrintDocument _printDocument1 = new PrintDocument();
        private Bitmap _memoryImage;
        private StringBuilder _sb = new StringBuilder();
        private Model _uml = new Model();

        public dlgUML()
        {
            InitializeComponent();
            Load += DlgUML_Load;
            Closing += DlgUML_Closing;
            _printDocument1.PrintPage += printDocument1_PrintPage;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(_memoryImage, 0, 0);
        }

        private void DlgUML_Closing(object sender, CancelEventArgs e)
        {
            Settings.Default.Save();
        }

        private void DlgUML_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            if (Directory.Exists("Projects"))
            {
                var projects = Directory.GetFiles("Projects", "*.*");
                foreach (var item in projects)
                    dfcProjects.Items.Add(Path.GetFileName(item));

                dfcProjects.Items.Add("All Projects");
            }
        }

        private void llMeAndMyLoan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
            {
                OpenFile(sender);
            }
            else
            {
                var fName = SelectFile(sender as LinkLabel, @"c:\Code\Imp",
                    "MeAndMyLoan.sln|MeAndMyLoan.sln");
            }
        }

        private string SelectFile(LinkLabel sender, string subDirectory, string filter)
        {
            var dlg = new OpenFileDialog
            {
                InitialDirectory = GetValidInitialDirectory(llMeAndMyLoan.Text, subDirectory),
                Filter = filter
            };
            dlg.ShowDialog();

            if (!string.IsNullOrEmpty(dlg.FileName)) //File selected
            {
                sender.Tag = dlg.FileName;
                SetControlText(sender);
                BindToUml(sender);
                ttMain.SetToolTip(sender, dlg.FileName);
                return dlg.FileName;
            }
            return "Select File";
        }

        private void SetControlText(Control sender)
        {
            if (sender.Tag == null) return;
            if (sender.Tag.ToString().EndsWith(".sln"))
                sender.Text = Path.GetDirectoryName(sender.Tag.ToString());
            else
            {
                if (File.Exists(sender.Tag.ToString()))
                    sender.Text = Path.GetFileName(sender.Tag.ToString());
                else
                {
                    sender.Text = sender.Tag.ToString();
                }
            }
        }

        private void BindToUml(Control inputcontrol)
        {
            var objectMemberName = inputcontrol.Name;
            if (objectMemberName.StartsWith("dfs"))
            {
                objectMemberName = objectMemberName.Substring(3);
                _uml.GetType().GetProperty(objectMemberName)?.SetValue(_uml, inputcontrol.Text);
            }
            if (objectMemberName.StartsWith("ll"))
            {
                objectMemberName = objectMemberName.Substring(2);
                _uml.GetType().GetProperty(objectMemberName)?.SetValue(_uml, inputcontrol.Tag);
            }
        }

        private string GetValidInitialDirectory(string solutionFolder, string subDirectory)
        {
            //We assume solutionFolderalwaysExist

            var subdirectoryComponents = subDirectory.Split('\\').ToList();
            var goodValidFolder = solutionFolder;
            if (subDirectory.Contains(":"))
                goodValidFolder = string.Empty;
            foreach (var subdirectoryComponent in subdirectoryComponents)
            {
                var newFolder = Path.Combine(goodValidFolder, subdirectoryComponent);
                if (newFolder.EndsWith(":")) newFolder += "\\";
                if (Directory.Exists(newFolder))
                    goodValidFolder = newFolder;
                else
                    break;
            }

            return goodValidFolder;
        }

        private static void OpenFile(object sender)
        {
            if (!(sender is LinkLabel))
            {
            }
            else
            {
                if ((sender as LinkLabel).Tag != null && File.Exists((sender as LinkLabel).Tag.ToString()))
                {
                    Clipboard.SetText((sender as LinkLabel).Tag.ToString());

                    if (_visualStudio == null)
                    {
                        try
                        {
                            _visualStudio = (DTE)
                                Marshal.GetActiveObject("VisualStudio.DTE.15.0");
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Can not reuse open instance of Visual Studio 2017, Creating a new instance, please open MeAndMyLoan.sln or Rest.API to continue","New Visual Studio 2017", MessageBoxButtons.OK,MessageBoxIcon.Information);
                            System.Type dteType = Type.GetTypeFromProgID("VisualStudio.DTE.15.0", true);
                            _visualStudio = (EnvDTE.DTE)System.Activator.CreateInstance(dteType);
                        }

                    }



                    _visualStudio.MainWindow.Visible = true;
                    _visualStudio.ExecuteCommand("File.OpenFile", (sender as LinkLabel).Tag.ToString());

                    //Process process = new Process
                    //    {
                    //        StartInfo =
                    //        {
                    //            //FileName = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.exe",
                    //            Arguments = (sender as LinkLabel).Tag.ToString(),
                    //            WindowStyle = ProcessWindowStyle.Maximized
                    //        }
                    //    };
                    //    // Configure the process using the StartInfo properties.
                    //    process.Start();
                    //    process.WaitForExit();// Waits here for the process to exit.
                }
            }
        }

        private static Process GetMeAndMyLoanInstance()
        {
            foreach (var pList in Process.GetProcesses())
                if (pList.MainWindowTitle.Contains("MeAndMyLoan"))
                    return pList;
            return null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("Projects"))
                Directory.CreateDirectory("Projects");

            var defaultProductName = Text;
            if (dfcProjects.SelectedItem != null)
                defaultProductName = dfcProjects.SelectedItem.ToString();

            var projectName =
                Interaction.InputBox("Enter Project Name", "Project Name",
                    $"{defaultProductName}"); //Default Controller Name

            if (string.IsNullOrEmpty(projectName)) return;
            var projectContent = JsonConvert.SerializeObject(_uml);
            File.WriteAllText($"Projects\\{projectName}", projectContent);
        }

        private void llControllerClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
            {
                OpenFile(sender);
            }
            else
            {
                var fName = SelectFile(sender as LinkLabel, "MML.Web.LoanCenter.Services\\Controllers",
                    "Controllers|*Controller*.cs");
            }
        }

        private void dfcProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists("Projects"))
                Directory.CreateDirectory("Projects");

            if (File.Exists($"Projects\\{dfcProjects.SelectedItem}"))
            {
                _uml = JsonConvert.DeserializeObject<Model>(File.ReadAllText($"Projects\\{dfcProjects.SelectedItem}"));
                Text = $"UML Class Diagram for {dfcProjects.SelectedItem}";
                BindToUI(this);
            }
            else if (dfcProjects.SelectedItem.ToString() == "All Projects")
            {
                Process.Start("Projects");
            }
        }

        private void BindToUI(Control inputcontrol)
        {

            foreach (Control control in inputcontrol.Controls)
            {
                if (control.HasChildren)
                    BindToUI(control);
                if (control is LinkLabel || control is TextBox)
                {
                    var objectMemberName = control.Name;
                    if (objectMemberName.StartsWith("dfs")) objectMemberName = objectMemberName.Substring(3);
                    if (objectMemberName.StartsWith("ll")) objectMemberName = objectMemberName.Substring(2);


                    try
                    {
                        var controlValue = _uml.GetType().GetProperty(objectMemberName)?.GetValue(_uml, null);
                        control.Tag = controlValue;
                        SetControlText(control);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }

            lblMicroserviceContracts.Text =
                lblMicroserviceContracts.Text.Replace("ProductName", dfcProjects.SelectedItem.ToString());
            lblMicroServiceProxy.Text =
                lblMicroServiceProxy.Text.Replace("ProductName", dfcProjects.SelectedItem.ToString());
            lblMicroServiceFacade.Text =
                lblMicroServiceFacade.Text.Replace("ProductName", dfcProjects.SelectedItem.ToString());
            lblMicroServiceService.Text =
                lblMicroServiceService.Text.Replace("ProductName", dfcProjects.SelectedItem.ToString());

            lblServiceHostService.Text =
                lblServiceHostService.Text.Replace("ProductName", dfcProjects.SelectedItem.ToString());
        }

        private void dfsControllerMethod_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        private void llLoanCenterModelRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, "MML.Web.LoanCenterModel", "C# Files|*.cs");
        }

        private void llLoanCenterModelResponse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, "MML.Web.LoanCenterModel", "C# Files|*.cs");
        }

        private void dfsCanonicInterfaceMethod_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        private void llCanonicInterfaceClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, "ServiceInterfaces", "C# Files|*.cs");
        }

        private void dfsCanonicMethod_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        private void llCanonicClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, "MML.LoanCenter.Services", "C# Files|*.cs");
        }

        private void btnHowToMicroService_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(
                "http://sharepoint.cloudvirga.local/sites/Dev/_layouts/15/WopiFrame2.aspx?sourcedoc=%7b3EEE9F6C-9955-4932-BCDA-351F658578D2%7d&file=Micro-Service%20Step-By-Step.docx&action=default");
        }

        private void btnHowToInstallMicroService_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(
                "http://sharepoint.cloudvirga.local/infrastructure/_layouts/15/WopiFrame2.aspx?sourcedoc=%7bF3C9CB1F-05A7-42DA-A30B-CF3CFCF6DE26%7d&file=MicroServicesInstructions.docx&action=default");
        }

        private void llMSContractRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, $"MML.Services\\Integrations\\{dfcProjects.SelectedItem}\\Contract",
                    "C# Files|*.cs");
        }

        private void llMSContractResponse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, $"MML.Services\\Integrations\\{dfcProjects.SelectedItem}\\Contract",
                    "C# Files|*.cs");
        }

        private void llMSProxyInterface_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, $"MML.Services\\Integrations\\{dfcProjects.SelectedItem}\\Proxy",
                    "C# Files|*.cs");
        }

        private void llMSProxyClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, $"MML.Services\\Integrations\\{dfcProjects.SelectedItem}\\Proxy",
                    "C# Files|*.cs");
        }

        private void llMSFacadeClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, $"MML.Services\\Integrations\\{dfcProjects.SelectedItem}\\Facade",
                    "C# Files|*.cs");
        }

        private void llMSFacadeFactoryClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, $"MML.Services\\Integrations\\{dfcProjects.SelectedItem}\\Facade",
                    "C# Files|*.cs");
        }

        private void dfsMSFacadeMethod_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        private void btnAddmicroserviceInstaller_Click(object sender, EventArgs e)
        {
            _sb = new StringBuilder();
            AddChildXmlNode(@"iMP.Deployment\iMPServicesInstaller\Directories.wxs", "Directory", "Id",
                Text.ToUpper() + "FOLDER", "Name", Text + "Service", "Directory", "Id", "MICROSERVICES");
            AddChildXmlNode(@"iMP.Deployment\iMPServicesInstaller\Components\Binaries.wxs", "Property", "Id",
                Text + "ServiceName", "Value", $"iMP.{Text}Service", "Fragment", "", "");
            var componentGuid = AddDirectoryRef(@"iMP.Deployment\iMPServicesInstaller\Components\Binaries.wxs");
            AddComponentGroup(@"iMP.Deployment\iMPServicesInstaller\Components\Binaries.wxs", componentGuid);
            AddSiblingXmlNode(@"iMP.Deployment\iMPServicesInstaller\Product.wxs", "WixVariable", "Id",
                Text + "ServicePath", "Value",
                $"..\\..\\..\\..\\MML.Services\\Integrations\\{Text}\\Service\\bin\\Debug", "WixVariable", "", "");
            AddSiblingXmlNode(@"iMP.Deployment\iMPServicesInstaller\Product.wxs", "Property", "Id",
                $"INSTALL{Text.ToUpper()}SERVICE", "Value", $"true", "Secure", "yes", "Property", "", "");
            AddFeature(@"iMP.Deployment\iMPServicesInstaller\Product.wxs");
            UpdateCustomActions(@"iMP.Deployment\iMPServicesInstaller\Product.wxs");
            UpdatePreBuildEvents(@"iMP.Deployment\iMPServicesInstaller\iMP.ServicesInstaller.wixproj");
            UpdateWebConfig(@"iMP.Deployment\iMP.ServicesInstaller.CustomActions\WebConfig.xml");

            AddChildXmlNode(@"BuildConfiguration\BuildConfiguration.xml", "Directory", "Id",
                Text.ToUpper() + "FOLDER", "Name", Text + "Service", "Directory", "Id", "MICROSERVICES");
            _sb.AppendLine(
                $"Now, Build iMP.Deployment.sln and include {Text}ServiceComponents.wxs in Components Folder under iMP.ServicesInstaller.wixproj");
            MessageBox.Show(_sb.ToString(), "Add Microservice Result", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void AddChildXmlNode(string fileName, string newNodeName, string firstAttributeName,
            string firstAttributeValue, string secondAttributeName, string secondAttributevalue, string parentNodeName,
            string parentNodeAttributeName, string parentNodeAttributeValue)
        {
            var fName = Path.Combine(llMeAndMyLoan.Text, fileName);
            if (IsFileReadOnly(fName)) return;
            var doc = XDocument.Load(fName);
            var ns = doc.Root.Name.Namespace;
            //Check if node is added
            if (doc.Descendants().FirstOrDefault(x =>
                    x.Name == ns + newNodeName && x.HasAttributes && x.Attribute(firstAttributeName) != null &&
                    x.Attribute(firstAttributeName).Value == firstAttributeValue) != null)
            {
                _sb.AppendLine($"{fileName} Success --> Exists {firstAttributeValue}\n");
                return; //Node already exist
            }
            foreach (var item in doc.Descendants())
                if (item.Name == ns + parentNodeName)
                    if (!string.IsNullOrEmpty(parentNodeAttributeName) &&
                        !string.IsNullOrEmpty(parentNodeAttributeValue) && item.HasAttributes &&
                        item.Attribute(parentNodeAttributeName) != null &&
                        item.Attribute(parentNodeAttributeName).Value == parentNodeAttributeValue)
                    {
                        var myElement = new XElement(ns + newNodeName,
                            new XAttribute(firstAttributeName, firstAttributeValue),
                            new XAttribute(secondAttributeName, secondAttributevalue));

                        item.AddFirst(myElement);
                        doc.Save(fName, SaveOptions.OmitDuplicateNamespaces);
                        _sb.AppendLine($"{fileName} Success --> {firstAttributeValue}\n");
                        return;
                    }
                    else if (string.IsNullOrEmpty(parentNodeAttributeName) &&
                             string.IsNullOrEmpty(parentNodeAttributeValue))
                    {
                        var myElement = new XElement(ns + newNodeName,
                            new XAttribute(firstAttributeName, firstAttributeValue),
                            new XAttribute(secondAttributeName, secondAttributevalue));
                        item.AddFirst(myElement);
                        doc.Save(fName, SaveOptions.OmitDuplicateNamespaces);
                        _sb.AppendLine($"{fileName} Success --> {firstAttributeValue}\n");
                        return;
                    }
        }

        private void AddSiblingXmlNode(string fileName, string newNodeName, string firstAttributeName,
            string firstAttributeValue, string secondAttributeName, string secondAttributevalue, string parentNodeName,
            string parentNodeAttributeName, string parentNodeAttributeValue)
        {
            var fName = Path.Combine(llMeAndMyLoan.Text, fileName);
            if (IsFileReadOnly(fName)) return;
            var doc = XDocument.Load(fName);
            var ns = doc.Root.Name.Namespace;
            //Check if node is added
            if (doc.Descendants().FirstOrDefault(x =>
                    x.Name == ns + newNodeName && x.HasAttributes && x.Attribute(firstAttributeName) != null &&
                    x.Attribute(firstAttributeName).Value == firstAttributeValue) != null)
            {
                _sb.AppendLine($"{fileName} Success --> Exists {firstAttributeValue}\n");
                return; //Node already exist
            }
            foreach (var item in doc.Descendants())
                if (item.Name == ns + parentNodeName)
                    if (!string.IsNullOrEmpty(parentNodeAttributeName) &&
                        !string.IsNullOrEmpty(parentNodeAttributeValue) && item.HasAttributes &&
                        item.Attribute(parentNodeAttributeName) != null &&
                        item.Attribute(parentNodeAttributeName).Value == parentNodeAttributeValue)
                    {
                        var myElement = new XElement(ns + newNodeName,
                            new XAttribute(firstAttributeName, firstAttributeValue),
                            new XAttribute(secondAttributeName, secondAttributevalue));

                        item.AddFirst(myElement);
                        doc.Save(fName, SaveOptions.OmitDuplicateNamespaces);
                        _sb.AppendLine($"{fileName} Success --> {firstAttributeValue}\n");
                        return;
                    }
                    else if (string.IsNullOrEmpty(parentNodeAttributeName) &&
                             string.IsNullOrEmpty(parentNodeAttributeValue))
                    {
                        var myElement = new XElement(ns + newNodeName,
                            new XAttribute(firstAttributeName, firstAttributeValue),
                            new XAttribute(secondAttributeName, secondAttributevalue));
                        item.AddAfterSelf(myElement);
                        doc.Save(fName, SaveOptions.OmitDuplicateNamespaces);
                        _sb.AppendLine($"{fileName} Success --> {firstAttributeValue}\n");
                        return;
                    }
        }

        private void AddSiblingXmlNode(string fileName, string newNodeName, string firstAttributeName,
            string firstAttributeValue, string secondAttributeName, string secondAttributevalue,
            string thirdAttributeName, string thirdAttributevalue, string parentNodeName,
            string parentNodeAttributeName, string parentNodeAttributeValue)
        {
            var fName = Path.Combine(llMeAndMyLoan.Text, fileName);
            if (IsFileReadOnly(fName)) return;
            var doc = XDocument.Load(fName);
            var ns = doc.Root.Name.Namespace;
            //Check if node is added
            if (doc.Descendants().FirstOrDefault(x =>
                    x.Name == ns + newNodeName && x.HasAttributes && x.Attribute(firstAttributeName) != null &&
                    x.Attribute(firstAttributeName).Value == firstAttributeValue) != null)
            {
                _sb.AppendLine($"{fileName} Success --> Exists {firstAttributeValue}\n");
                return; //Node already exist
            }
            foreach (var item in doc.Descendants())
                if (item.Name == ns + parentNodeName)
                    if (!string.IsNullOrEmpty(parentNodeAttributeName) &&
                        !string.IsNullOrEmpty(parentNodeAttributeValue) && item.HasAttributes &&
                        item.Attribute(parentNodeAttributeName) != null &&
                        item.Attribute(parentNodeAttributeName).Value == parentNodeAttributeValue)
                    {
                        var myElement = new XElement(ns + newNodeName,
                            new XAttribute(firstAttributeName, firstAttributeValue),
                            new XAttribute(secondAttributeName, secondAttributevalue));

                        item.AddFirst(myElement);
                        doc.Save(fName, SaveOptions.OmitDuplicateNamespaces);
                        _sb.AppendLine($"{fileName} Success --> {firstAttributeValue}\n");
                        return;
                    }
                    else if (string.IsNullOrEmpty(parentNodeAttributeName) &&
                             string.IsNullOrEmpty(parentNodeAttributeValue))
                    {
                        var myElement = new XElement(ns + newNodeName,
                            new XAttribute(firstAttributeName, firstAttributeValue),
                            new XAttribute(secondAttributeName, secondAttributevalue),
                            new XAttribute(thirdAttributeName, thirdAttributevalue));
                        item.AddAfterSelf(myElement);
                        doc.Save(fName, SaveOptions.OmitDuplicateNamespaces);
                        _sb.AppendLine($"{fileName} Success --> {firstAttributeValue}\n");
                        return;
                    }
        }

        private string AddDirectoryRef(string fileName)
        {
            var fName = Path.Combine(llMeAndMyLoan.Text, fileName);
            if (IsFileReadOnly(fName)) return string.Empty;
            var doc = XDocument.Load(fName);
            var ns = doc.Root.Name.Namespace;
            //Check if node is added
            if (doc.Descendants().FirstOrDefault(x =>
                    x.Name == ns + "DirectoryRef" && x.HasAttributes && x.Attribute("Id") != null &&
                    x.Attribute("Id").Value == $"{Text.ToUpper()}FOLDER") != null)
            {
                var existingNode = doc.Descendants().FirstOrDefault(x =>
                    x.Name == ns + "DirectoryRef" && x.HasAttributes && x.Attribute("Id") != null &&
                    x.Attribute("Id").Value == $"{Text.ToUpper()}FOLDER");

                _sb.AppendLine($"{fileName} Success --> Exists DirectoryRef {Text.ToUpper()}FOLDER\n");
                var guid = Regex.Match(existingNode.FirstNode.ToString(), "Id=\"(cmp.*?)\"");
                return guid.Groups[1].ToString(); //Node already exist
            }
            foreach (var item in doc.Descendants())
                if (item.Name == ns + "DirectoryRef") //Just add the nodes above
                {
                    var directoryRef = new XElement(ns + "DirectoryRef",
                        new XAttribute("Id", $"{Text.ToUpper()}FOLDER"));
                    //<Component Id="cmp57CED2E8935A3E297BCC17162CDE5RT8" Guid="81CF6553-1910-4661-B13A-4CADE76043C8">
                    var componentGuid = Guid.NewGuid().ToString().ToUpper().Replace("-", string.Empty);
                    var componentGuid2 = Guid.NewGuid().ToString().ToUpper();
                    var component = new XElement(ns + "Component", new XAttribute("Id", $"cmp{componentGuid}"),
                        new XAttribute("Guid", $"{componentGuid2}"));
                    var fileGuid = Guid.NewGuid().ToString().ToUpper().Replace("-", string.Empty);

                    //< File Id = "filFA8A2BF2547D011395BF4174659E9257" KeyPath = "yes" Source = "!(wix.AppraisalServicePath)\AppraisalService.exe" />
                    var fileNode = new XElement(ns + "File", new XAttribute("Id", $"fil{fileGuid}"),
                        new XAttribute("KeyPath", $"yes"),
                        new XAttribute("Source", $"!(wix.{Text}ServicePath)\\{Text}Service.exe"));


                    //   < ServiceInstall Id = "AppraisalServiceInstall" DisplayName = "[AppraisalServiceName]" Description = "[AppraisalServiceName]" Type = "ownProcess" ErrorControl = "normal" Name = "[AppraisalServiceName]" Start = "auto" Account = "[SERVICEUSERNAME]" Password = "[PASSWORD]" />
                    var serviceInstallNode = new XElement(ns + "ServiceInstall",
                        new XAttribute("Id", $"{Text}ServiceInstall"),
                        new XAttribute("DisplayName", $"[{Text}ServiceName]"),
                        new XAttribute("Description", $"[{Text}ServiceName]"),
                        new XAttribute("Name", $"[{Text}ServiceName]"), new XAttribute("Type", $"ownProcess"),
                        new XAttribute("ErrorControl", $"normal"), new XAttribute("Start", $"auto"),
                        new XAttribute("Account", $"[SERVICEUSERNAME]"), new XAttribute("Password", $"[PASSWORD]"));


                    //< ServiceControl Id = "AppraisalServiceControll" Name = "[AppraisalServiceName]" Remove = "uninstall" />
                    var serviceControlNode = new XElement(ns + "ServiceControl",
                        new XAttribute("Id", $"{Text}ServiceControl"), new XAttribute("Name", $"[{Text}ServiceName]"),
                        new XAttribute("Remove", $"uninstall"));
                    component.Add(fileNode);
                    component.Add(serviceInstallNode);
                    component.Add(serviceControlNode);
                    directoryRef.Add(component);
                    item.AddBeforeSelf(directoryRef);
                    doc.Save(fName, SaveOptions.OmitDuplicateNamespaces);
                    _sb.AppendLine($"{fileName} Success --> DirectoryRef {Text.ToUpper()}FOLDER\n");
                    return "cmp" + componentGuid;
                }

            return string.Empty;
        }

        private void AddComponentGroup(string fileName, string componentGuid)
        {
            var fName = Path.Combine(llMeAndMyLoan.Text, fileName);
            if (IsFileReadOnly(fName)) return;
            var doc = XDocument.Load(fName);
            var ns = doc.Root.Name.Namespace;
            //Check if node is added
            if (doc.Descendants().FirstOrDefault(x =>
                    x.Name == ns + "ComponentGroup" && x.HasAttributes && x.Attribute("Id") != null &&
                    x.Attribute("Id").Value == $"{Text}ServiceBinaryComponents") != null)
            {
                _sb.AppendLine($"{fileName} Success --> Exists ComponentGroup {Text}ServiceBinaryComponents\n");
                return; //Node already exist
            }
            foreach (var item in doc.Descendants())
                if (item.Name == ns + "ComponentGroup") //Just add the nodes above
                {
                    var componentGroup = new XElement(ns + "ComponentGroup",
                        new XAttribute("Id", $"{Text}ServiceBinaryComponents"));
                    //<ComponentRef Id="cmp26CED2E8935A3E297BCC17131CDD4B75" />
                    var component = new XElement(ns + "ComponentRef", new XAttribute("Id", $"{componentGuid}"));

                    componentGroup.Add(component);
                    item.AddBeforeSelf(componentGroup);
                    doc.Save(fName, SaveOptions.OmitDuplicateNamespaces);
                    _sb.AppendLine($"{fileName} Success --> ComponentGroup {Text}ServiceBinaryComponents\n");
                    return;
                }
        }


        private void AddFeature(string fileName)
        {
            var fName = Path.Combine(llMeAndMyLoan.Text, fileName);
            if (IsFileReadOnly(fName)) return;
            var doc = XDocument.Load(fName);
            var ns = doc.Root.Name.Namespace;
            //Check if node is added
            if (doc.Descendants().FirstOrDefault(x =>
                    x.Name == ns + "Feature" && x.HasAttributes && x.Attribute("Id") != null &&
                    x.Attribute("Id").Value == $"{Text}ServiceFeature") != null)
            {
                _sb.AppendLine($"{fileName} Success --> Exists Feature {Text}ServiceFeature\n");
                return; //Node already exist
            }
            foreach (var item in doc.Descendants())
                if (item.Name == ns + "Feature") //Just add the nodes above
                {
                    var featureNode = new XElement(ns + "Feature", new XAttribute("Id", $"{Text}ServiceFeature"),
                        new XAttribute("Title", $"{Text}"), new XAttribute("Level", "0"));
                    var componentGroupRef1 = new XElement(ns + "ComponentGroupRef",
                        new XAttribute("Id", $"{Text}ServiceComponents"));
                    var componentGroupRef12 = new XElement(ns + "ComponentGroupRef",
                        new XAttribute("Id", $"{Text}ServiceBinaryComponents"));
                    var conditionNode = new XElement(ns + "Condition", new XAttribute("Level", $"1"));
                    conditionNode.SetValue($"INSTALL{Text.ToUpper()}SERVICE = \"true\"");
                    featureNode.Add(componentGroupRef1);
                    featureNode.Add(componentGroupRef12);
                    featureNode.Add(conditionNode);
                    item.AddBeforeSelf(featureNode);
                    doc.Save(fName, SaveOptions.OmitDuplicateNamespaces);
                    _sb.AppendLine($"{fileName} Success --> Feature {Text}ServiceFeature\n");
                    return;
                }
        }


        private void UpdateCustomActions(string fileName)
        {
            var fName = Path.Combine(llMeAndMyLoan.Text, fileName);
            if (IsFileReadOnly(fName)) return;
            var doc = XDocument.Load(fName);
            var ns = doc.Root.Name.Namespace;
            //Check if node is added

            var setStartNode = doc.Descendants().FirstOrDefault(x =>
                x.Name == ns + "CustomAction" && x.HasAttributes && x.Attribute("Id") != null &&
                x.Attribute("Id").Value == $"SetStartServices");

            if (!setStartNode.Attribute("Value").Value.Contains($"INSTALL{Text.ToUpper()}SERVICE"))
            {
                setStartNode.Attribute("Value")
                    .SetValue($"INSTALL{Text.ToUpper()}SERVICE=[INSTALL{Text.ToUpper()}SERVICE];" +
                              setStartNode.Attribute("Value").Value);
                _sb.AppendLine($"{fileName} Success --> SetStartServices INSTALL{Text.ToUpper()}SERVICE\n");
            }
            else
            {
                _sb.AppendLine($"{fileName} Exists --> SetStartServices INSTALL{Text.ToUpper()}SERVICE\n");
            }

            //SetResolveMacroValues
            var SetResolveMacroValues = doc.Descendants().FirstOrDefault(x =>
                x.Name == ns + "CustomAction" && x.HasAttributes && x.Attribute("Id") != null &&
                x.Attribute("Id").Value == $"SetResolveMacroValues");
            if (!SetResolveMacroValues.Attribute("Value").Value.Contains($"INSTALL{Text.ToUpper()}SERVICE"))
            {
                SetResolveMacroValues.Attribute("Value").SetValue(
                    $"INSTALL{Text.ToUpper()}SERVICE=[INSTALL{Text.ToUpper()}SERVICE];" +
                    SetResolveMacroValues.Attribute("Value").Value);
                _sb.AppendLine($"{fileName} Success --> SetResolveMacroValues INSTALL{Text.ToUpper()}SERVICE\n");
            }
            else
            {
                _sb.AppendLine($"{fileName} Exists --> SetResolveMacroValues INSTALL{Text.ToUpper()}SERVICE\n");
            }
            doc.Save(fName, SaveOptions.OmitDuplicateNamespaces);
        }


        private void UpdateWebConfig(string fileName)
        {
            var fName = Path.Combine(llMeAndMyLoan.Text, fileName);
            if (IsFileReadOnly(fName)) return;
            var doc = XDocument.Load(fName);
            var ns = doc.Root.Name.Namespace;
            //Check if node is added

            var ServiceNode = doc.Descendants().FirstOrDefault(x =>
                x.Name == ns + "service" && x.HasAttributes && x.Attribute("Name") != null &&
                x.Attribute("Name").Value == $"{Text}Service");

            if (ServiceNode == null) //Add the node
            {
                var ServicesNode = doc.Descendants().FirstOrDefault(x =>
                    x.Name == ns + "services");
                var newNode = new XElement(ns + "service", new XAttribute("Name", $"{Text}Service"),
                    new XAttribute("Pool", $"UI"), new XAttribute("Start", $"3"));
                var macrosNode = new XElement(ns + "macros");
                //<macroFolder>MicroServices\PaymentProcessingService</macroFolder>
                var macrosFolderNode = new XElement(ns + "macroFolder");
                macrosFolderNode.SetValue($"MicroServices\\{Text}Service");
                macrosNode.Add(macrosFolderNode);
                newNode.Add(macrosNode);
                ServicesNode.Add(newNode);
                _sb.AppendLine($"{fileName} Success --> Service\n");
            }
            else
            {
                _sb.AppendLine($"{fileName} Exists --> Service\n");
            }


            doc.Save(fName, SaveOptions.OmitDuplicateNamespaces);
        }

        private void UpdatePreBuildEvents(string fileName)
        {
            var fName = Path.Combine(llMeAndMyLoan.Text, fileName);
            if (IsFileReadOnly(fName)) return;
            var doc = XDocument.Load(fName);
            var ns = doc.Root.Name.Namespace;
            //Check if node is added

            var prebuildEventsNode = doc.Descendants().FirstOrDefault(x =>
                x.Name == ns + "PreBuildEvent");


            //"..\..\..\..\ExternalLibraries\Wix\3.10\heat.exe" dir  "..\..\..\..\MML.Services\Integrations\PaymentProcessing\MML.Services.Integrations.PaymentProcessing\bin\Debug"  -dr PAYMENTPROCESSINGSERVICEFOLDER -cg PaymentProcessingServiceComponents -sfrag -gg -g1 -sf -srd  -var wix.PaymentProcessingServicePath -t "..\..\HarvestTransform.xsl"  -out "..\..\Components\PaymentProcessingServiceComponents.wxs" -sreg -scom
            if (!prebuildEventsNode.Value.Contains($"{Text.ToUpper()}FOLDER"))
            {
                prebuildEventsNode.SetValue(prebuildEventsNode.Value + Environment.NewLine +
                                            $"\"..\\..\\..\\..\\ExternalLibraries\\Wix\\3.10\\heat.exe\" dir  \"..\\..\\..\\..\\MML.Services\\Integrations\\{Text}\\Service\\bin\\Debug\" -dr {Text.ToUpper()}FOLDER -cg {Text}ServiceComponents -sfrag -gg -g1 -sf -srd -var wix.{Text}ServicePath -t \"..\\..\\HarvestTransform.xsl\" -out \"..\\..\\Components\\{Text}ServiceComponents.wxs\" -sreg -scom" +
                                            Environment.NewLine);
                _sb.AppendLine($"{fileName} Success --> Prebuild Events {Text.ToUpper()}FOLDER\n");
            }
            else
            {
                _sb.AppendLine($"{fileName} Exists --> Prebuild Events {Text.ToUpper()}FOLDER\n");
            }


            doc.Save(fName, SaveOptions.OmitDuplicateNamespaces);
        }

        private void MessageFileUpdated(string inputFileName, string message)
        {
            MessageBox.Show($"File {inputFileName}\n{message}", "Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private bool IsFileReadOnly(string inputFile)
        {
            var fi = new FileInfo(inputFile);
            if (fi.IsReadOnly)
            {
                //MessageBox.Show($"File {inputFile} is readonly. Can't update file. Check out this file first",
                //    "Checkout error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var si = new ProcessStartInfo
                {
                    FileName = $"\"C:\\Program Files (x86)\\Microsoft Visual Studio 14.0\\Common7\\IDE\\tf.exe\"",
                    Arguments = "checkout \"" + inputFile + "\""
                };
                var p = Process.Start(si);
                p.WaitForExit();
                return false;
            }
            return false;
        }

        private void llPingService_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"http://localhost:{dfsHttpPort.Text}/{dfcProjects.SelectedItem}Service/ping");
        }

        private void llPortExcelSheet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(
                "http://sharepoint.cloudvirga.local/sites/Dev/_layouts/15/WopiFrame2.aspx?sourcedoc={a861e327-9ad4-47c7-8101-d590a72b48d5}&action=view&activeCell=%27Integrations%27!D45");
        }

        private void llMSServiceInterface_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, $"MML.Services\\Integrations\\{dfcProjects.SelectedItem}\\Service",
                    "C# Files|*.cs");
        }

        private void llMSServiceClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, $"MML.Services\\Integrations\\{dfcProjects.SelectedItem}\\Service",
                    "C# Files|*.cs");
        }

        private void llMSHelperClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel,
                    $"MML.Services\\Integrations\\{dfcProjects.SelectedItem}\\Service\\Helpers", "C# Files|*.cs");
        }

        private void dfsFQN_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        private void dfsHttpPort_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        private void dfstcpPort_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        private void llMSServiceHost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, $"MML.Services\\Integrations\\{dfcProjects.SelectedItem}\\Service",
                    "Exe Files|*.exe");
        }

        private void llMSHostConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, $"MML.Services\\Integrations\\{dfcProjects.SelectedItem}\\Service",
                    "Config Files|*.config");
        }

        private void dfsProductTypeEnum_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        private void dfsVendorTypeEnum_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            _printDocument1.DefaultPageSettings.Landscape = true;
            _printDocument1.Print();
        }

        private void CaptureScreen()
        {
            var myGraphics = CreateGraphics();
            var s = Size;
            _memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            var memoryGraphics = Graphics.FromImage(_memoryImage);
            memoryGraphics.CopyFromScreen(Location.X, Location.Y, 0, 0, s);
        }

        private void llServiceFacadeInterface_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, "MML.Services.Facade\\Abstract", "C# Files|I*.cs");
        }

        private void llServiceFacadeClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, "MML.Services.Facade\\Implementation", "C# Files|*.cs");
        }

        private void dfsServiceFacadeMethod_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        private void llServiceVMRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, @"C:\Code\iMP\Packages\iMP.Common\Trunk.126\iMP.Contracts",
                    "C# Files|*.cs");
        }

        private void llServiceVMResponse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, @"C:\Code\iMP\Packages\iMP.Common\Trunk.126\iMP.Contracts",
                    "C# Files|*.cs");
        }

        private void dfsServiceMethodName_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        private void llServiceHandleContract_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, @"C:\Code\iMP\Packages\iMP.Common\Trunk.126\iMP.Contracts",
                    "C# Files|*.cs");
        }

        private void llServiceClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, $"MML.Services.{dfcProjects.SelectedItem}", "C# Files|*.cs");
        }

        private void dfcProjects_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void btnSave_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void dfsPBI_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        System.Net.CookieContainer _coockieJar = new CookieContainer();
        private void llTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(dfsTestParameters.Text))
            {
                MakeCallString();
            }
            else //
            {
                InitializeCookieContainer();
                llTest.Visible = false;

                if (dfsTestParameters.Text.StartsWith("POST") || dfsTestParameters.Text.StartsWith("PUT"))
                {
                    llTest.Visible = false;
                    var client = new RestClient(dfsTestParameters.Lines.First().Replace("  "," ").Split(' ')[1].Trim())
                    {
                        Timeout = 300 * 1000,
                        ReadWriteTimeout = 300000
                    };
                    var request =
                        new RestRequest("", Method.POST);
                    if (dfsTestParameters.Text.StartsWith("PUT"))
                        request =
                            new RestRequest("", Method.PUT);


                    var jsonString = "{";
                    foreach (var line in dfsTestParameters.Lines.Skip(1))
                    {
                        if (string.IsNullOrEmpty(line)) continue;
                        var jsonSplit = line.Split(':');
                        jsonString += "\"" + jsonSplit[0].Trim() + "\":\"" + jsonSplit[1] + "\",";

                    }
                    if (jsonString != "{")
                    {
                        jsonString = jsonString.TrimEnd(',') + "}";
                        request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
                        request.RequestFormat = DataFormat.Json;
                    }
                    request.Timeout = 300000;
                    request.ReadWriteTimeout = 300000;
                    var bearerValue = GetBearerValue();
                    request.AddHeader("Authorization", bearerValue);
                    var sw = new Stopwatch();
                    sw.Start();
                    var response = client.Execute(request);

                    dfsResponse.Text = response.Content + response.ErrorMessage;
                    llTest.Visible = true;
                }
                else //Get
                {

                        var url = dfsTestParameters.Lines.First().Substring(3).Trim();
                        var lines = dfsTestParameters.Lines.Where(x => !string.IsNullOrEmpty(x)).ToList();
                        if (lines.Count > 1) url += "?";
                        var client = new RestClient(url)
                        {
                            Timeout = 300 * 1000,
                            ReadWriteTimeout = 300000,
                            CookieContainer = _coockieJar,
                        };
                        var request =
                            new RestRequest("", Method.GET);
                        foreach (var line in lines.Skip(1))
                        {
                            if (string.IsNullOrEmpty(line)) continue;
                            var jsonSplit = line.Split(':');
                            request.AddQueryParameter(jsonSplit[0], jsonSplit[1]);
                        }
                        //Cookie: mml-auth-token=gAAAAJ8uYMlxabGwFQylGUEPeiKiX1VuqU8eidmlfrsVt3-BPMB6VystYZZ6e2b_KyHR2rCdFa9yCTUPXyO0hBRdF4cht7sZsLo66lei5xQW8kT58kS65Wt-Ac1-Doxxq-vLwbaL2pct_itQd0u2CtrbX98bogN8XshhVQmtFZRMPyznJAEAAIAAAAClWCqGucnv8zNPYH-4xATif2BFkypOLA5WBH7sxSsur2haP8uYdiglo8yf0CKh-gV7UyWesjCrxKt2XFG0KWOkMqI5ZCPRH-o8SrLKOUjgnGiraYl2abTvj4MEAZWXwCyJU313w2LsVyEJV6imJu_4hjHwTExEFgafxKOiM1gcDpzbZrn4DH-DvoTlPFQr24EGO9uThH8YTs_dcZ0RcxKWGTbu3-g5cEVumi7lu5zJrfAHG3Mb4VzUns9Hiyr-pvetL32qpOifOQgy4jkLntQuJdUYpsQgmA2l-ofXklU3ZpBDBvhylQqQysqtHje0TRxtz5VU8fXIhlmmg7P8ali9uthi66g6Yp8kIpCX7hp87yHdt3U_IdlppSDL7dTXAzQ; __utmt=1; __utmb=111872281.288.8.1522875211272

                        request.Timeout = 300000;
                        request.ReadWriteTimeout = 300000;
                        var sw = new Stopwatch();
                        sw.Start();
                        var response = client.Execute(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        dfsResponse.Text = response.Content + response.ErrorMessage;
                    }
                    else
                    {
                        dfsResponse.Text = response.StatusDescription;
                    }
                    llTest.Visible = true;
                    
                }
            }
        }


        private string InitializeCookieContainer()
        {
            var client =
                new RestClient(
                    "http://localhost:1932/api/SecurityService/AuthenticateAndGrantConsumerSiteOAuthToken?serviceAccountUserAccountId=123456")
                {
                    CookieContainer = _coockieJar
                };
            var request = new RestRequest("", Method.POST);
            request.AddHeader("Host", "localhost:1932");
            request.AddHeader("Accept", "application/json, text/plain, */*");
            request.AddHeader("Origin", "http://localhost:1932");
            request.AddHeader("User-Agent", "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("DNT", "1");
            request.AddHeader("Referer", "http://localhost:1932/");
            request.AddHeader("Accept-Language", "en-US,en;q=0.9,ar;q=0.8");
            var srBody = new StringBuilder();
            srBody.Append("client_id=" + "MmlOAuthClientDescription" + "&");
            srBody.Append("redirect_uri=" + "https%3A%2F%2Fqa01concierge.newleaflending.com" + "&");
            srBody.Append("scope=" + "scope-mml-lc" + "&");
            srBody.Append("response_type=" + "token" + "&");
            srBody.Append("username=" + "dev%40meandmyloan.com" + "&");
            srBody.Append("password=" + "gotodev" + "&");
            var body = srBody.ToString();
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response.Content;
        }


        private void MakeCallString()
        {
            dfsTestParameters.Text =
                $"http://localhost:1932/api/{dfcProjects.SelectedItem}/{dfsControllerMethod.Text}" + Environment.NewLine;
            //Find the controller, find the method, read the parameters and put them there one by one
            var controllerLines = File.ReadAllLines(llControllerClass.Tag.ToString());
            var methodLine = controllerLines.FirstOrDefault(x => Regex.IsMatch(x, $"public.*{dfsControllerMethod.Text}(.*)"));
            if (methodLine != null)
            {
                var parameters = Regex.Match(methodLine, $"public.*{dfsControllerMethod.Text}(.*)").Groups[1].ToString()
                    .Replace("(", string.Empty).Replace(")", string.Empty);
                var pArray = parameters.Split(',').ToList();
                var callString = string.Empty;
                foreach (var p in pArray)
                {
                    var splitted = p.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
                    callString +=  splitted[1] + ":" + splitted[0] +  Environment.NewLine;
                }
                dfsTestParameters.Text += callString;
            }
        }

        private void dfsTestParameters_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(dfsTestParameters.Text) && dfsTestParameters.Text.Contains("public"))
            //{
            //    var lines = dfsTestParameters.Lines;
            //    var newText = string.Empty;
            //    foreach (var line in lines)
            //    {
            //        if (string.IsNullOrEmpty(line)) continue;
            //        newText += Regex.Replace(line, "public (.*?) (.*?) {.*$", "$2:$1") + Environment.NewLine;
            //    }

            //    dfsTestParameters.Text = "GET|POST " + newText;
            //}
            BindToUml(sender as Control);
        }

        private void btnPost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void dfsPBI_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dfsPBI.Text))
            {
                Process.Start($"http://tfs.cloudvirga.local:8080/tfs/defaultcollection/iMP/iMP%20Team/_workitems?_a=edit&id={dfsPBI.Text}");
            }
        }

        private void ltnBearer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var bearerValue = GetBearerValue();

            dfsResponse.Text = bearerValue;
            var bearerLine = dfsTestParameters.Lines.FirstOrDefault(x => x.StartsWith("Authorization: "));
            if (bearerLine != null)
                dfsTestParameters.Text = dfsTestParameters.Text.Replace(bearerLine, "Authorization: " + bearerValue);

        }

        private string GetBearerValue()
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://localhost:1932/api/loan/GetLoanIdAndAuthorize");

            request.KeepAlive = true;
            request.Accept = "application/json, text/plain, */*";
            request.Headers.Add("Origin", @"http://localhost:1932");
            request.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.139 Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers.Add("DNT", @"1");
            request.Referer = "http://localhost:1932/ConsumerSite";
            request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
            request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.9,ar;q=0.8");

            request.Method = "POST";
            request.ServicePoint.Expect100Continue = false;

            string body =
                @"client_id=MmlOAuthClientDescription&redirect_uri=https%3A%2F%2Fqa01.newleaflending.com&scope=%40loanid&response_type=token";
            byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(body);
            request.ContentLength = postBytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(postBytes, 0, postBytes.Length);
            stream.Close();

            var response = (HttpWebResponse) request.GetResponse();
            var authHeader = response.Headers["Authorization"];
            if (authHeader == null) dfsResponse.Text = "No Authorization Bearer Token";
            var bearerValue = authHeader.ToString();
            return bearerValue;
        }

        private void btnCopyUML_Click(object sender, EventArgs e)
        {
            //Prompt for new Project Name

            //Copy the controller and change all names there. ControllerName, FileName, CanonicService


            //Create the interface in serviceInterfaces


        }

        private void llDALClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, "MML.DataAccess.CDM", "C# Files|*.cs");


        }

        private void dfsDALMethod_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        private void dfsNotes_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        private void dfsDALConverterMethod_TextChanged(object sender, EventArgs e)
        {
            BindToUml(sender as Control);
        }

        private void llDALConverter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
                OpenFile(sender);
            else
                SelectFile(sender as LinkLabel, "MML.DataAccess.CDM", "C# Files|*.cs");
        }
    }
}