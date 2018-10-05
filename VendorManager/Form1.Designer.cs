namespace VendorManager
{
    partial class dlgMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgMain));
            this.tvServices = new System.Windows.Forms.TreeView();
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsOrphans = new System.Windows.Forms.ToolStripSplitButton();
            this.tsOrphanService = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOrphanProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOrphanVendors = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOrphanSettingType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLocalHostPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLocalDB = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLog4net = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsEncompassVersions = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsServiceCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsVendorCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProductImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProductcount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsVendorProducts = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsVendorSettings = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProductSettings = new System.Windows.Forms.ToolStripStatusLabel();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUMLDiagram = new System.Windows.Forms.ToolStripMenuItem();
            this.tbResult = new System.Windows.Forms.TabControl();
            this.tbLog = new System.Windows.Forms.TabPage();
            this.dfsLog = new System.Windows.Forms.RichTextBox();
            this.tbSQL = new System.Windows.Forms.TabPage();
            this.dfsSQL = new System.Windows.Forms.RichTextBox();
            this.dfcDatabase = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.picProductSetting = new System.Windows.Forms.PictureBox();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dfsSettingObjectValue = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.dfsSettingRestriction = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dfsSettingDefaultValue = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.dfsSettingDataEntryType = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dfsSettingDescription = new System.Windows.Forms.TextBox();
            this.picVendorSetting = new System.Windows.Forms.PictureBox();
            this.picVendor = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dfsSettingName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dfsSettingCode = new System.Windows.Forms.TextBox();
            this.gbVendorProduct = new System.Windows.Forms.GroupBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dfsVendorProductFQN = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dfsVendorProductSimulatorUrl = new System.Windows.Forms.TextBox();
            this.gbProduct = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dfsProductName = new System.Windows.Forms.TextBox();
            this.dfsProductCode = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dfsProductDescription = new System.Windows.Forms.TextBox();
            this.gbVendor = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dfsVendorName = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dfsVendorDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dfsVendorCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dfsVendorSchema = new System.Windows.Forms.TextBox();
            this.gbService = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dfsServiceName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dfsServiceDescription = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grbSQLExecuter = new System.Windows.Forms.GroupBox();
            this.dfsSQLScript = new System.Windows.Forms.TextBox();
            this.btnRunSQL = new System.Windows.Forms.Button();
            this.dfcSQLScripts = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dfsFilter = new System.Windows.Forms.TextBox();
            this.dfsLoanId = new System.Windows.Forms.TextBox();
            this.llMeAndMyLoan = new System.Windows.Forms.LinkLabel();
            this.label27 = new System.Windows.Forms.Label();
            this.btnReadLogi = new System.Windows.Forms.Button();
            this.dffDistinct = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.dffLast20Minutes = new System.Windows.Forms.CheckBox();
            this.lblCreated = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.sbMain = new System.Windows.Forms.StatusStrip();
            this.tsMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbLogTabs = new System.Windows.Forms.TabControl();
            this.tbErrors = new System.Windows.Forms.TabPage();
            this.grdErrors = new System.Windows.Forms.DataGridView();
            this.tbWarning = new System.Windows.Forms.TabPage();
            this.grdWarningLogs = new System.Windows.Forms.DataGridView();
            this.tbOther = new System.Windows.Forms.TabPage();
            this.grdOtherLogs = new System.Windows.Forms.DataGridView();
            this.tbProbable = new System.Windows.Forms.TabPage();
            this.grdProb = new System.Windows.Forms.DataGridView();
            this.tbAuditLog = new System.Windows.Forms.TabPage();
            this.grdAuditLog = new System.Windows.Forms.DataGridView();
            this.tbIntegrationServices = new System.Windows.Forms.TabPage();
            this.grdIntegrationLog = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label26 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label44 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.dfsPBI = new System.Windows.Forms.TextBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.picRest = new System.Windows.Forms.PictureBox();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.tbBackend = new System.Windows.Forms.TabControl();
            this.tbMicroService = new System.Windows.Forms.TabPage();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.pictureBox23 = new System.Windows.Forms.PictureBox();
            this.lbl7 = new System.Windows.Forms.Label();
            this.llPingService = new System.Windows.Forms.LinkLabel();
            this.llPortExcelSheet = new System.Windows.Forms.LinkLabel();
            this.dfstcpPort = new System.Windows.Forms.TextBox();
            this.dfsHttpPort = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.dfsFQN = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.llMSHostConfig = new System.Windows.Forms.LinkLabel();
            this.llMSServiceHost = new System.Windows.Forms.LinkLabel();
            this.llMSHelperClass = new System.Windows.Forms.LinkLabel();
            this.llMSServiceClass = new System.Windows.Forms.LinkLabel();
            this.llMSServiceInterface = new System.Windows.Forms.LinkLabel();
            this.lblMicroServiceService = new System.Windows.Forms.Label();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbl9 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.dfsVendorTypeEnum = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.dfsProductTypeEnum = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnAddmicroserviceInstaller = new System.Windows.Forms.Button();
            this.label56 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.dfsMSFacadeMethod = new System.Windows.Forms.TextBox();
            this.llMSFacadeFactoryClass = new System.Windows.Forms.LinkLabel();
            this.llMSFacadeClass = new System.Windows.Forms.LinkLabel();
            this.lblMicroServiceFacade = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.llMSProxyClient = new System.Windows.Forms.LinkLabel();
            this.label38 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.lblMicroServiceProxy = new System.Windows.Forms.Label();
            this.llMSProxyInterface = new System.Windows.Forms.LinkLabel();
            this.label42 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.llMSContractResponse = new System.Windows.Forms.LinkLabel();
            this.llMSContractRequest = new System.Windows.Forms.LinkLabel();
            this.lblMicroserviceContracts = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.btnHowToInstallMicroService = new System.Windows.Forms.LinkLabel();
            this.btnHowToMicroService = new System.Windows.Forms.LinkLabel();
            this.tbServiceHostService = new System.Windows.Forms.TabPage();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.llServiceClass = new System.Windows.Forms.LinkLabel();
            this.llServiceHandleContract = new System.Windows.Forms.LinkLabel();
            this.dfsServiceMethodName = new System.Windows.Forms.TextBox();
            this.lblServiceHostService = new System.Windows.Forms.Label();
            this.llServiceVMResponse = new System.Windows.Forms.LinkLabel();
            this.llServiceVMRequest = new System.Windows.Forms.LinkLabel();
            this.label34 = new System.Windows.Forms.Label();
            this.llServiceFacadeClass = new System.Windows.Forms.LinkLabel();
            this.llServiceFacadeInterface = new System.Windows.Forms.LinkLabel();
            this.dfsServiceFacadeMethod = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.tbTest = new System.Windows.Forms.TabPage();
            this.ltnBearer = new System.Windows.Forms.LinkLabel();
            this.dfsResponse = new System.Windows.Forms.TextBox();
            this.llTest = new System.Windows.Forms.LinkLabel();
            this.dfsTestParameters = new System.Windows.Forms.TextBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.llCanonicInterfaceClass = new System.Windows.Forms.LinkLabel();
            this.llLoanCenterModelRequest = new System.Windows.Forms.LinkLabel();
            this.llLoanCenterModelResponse = new System.Windows.Forms.LinkLabel();
            this.llCanonicClass = new System.Windows.Forms.LinkLabel();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.dfsCanonicInterfaceMethod = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.dfsCanonicMethod = new System.Windows.Forms.TextBox();
            this.dfcProjects = new System.Windows.Forms.ComboBox();
            this.llMeAndMyLoan2 = new System.Windows.Forms.LinkLabel();
            this.label61 = new System.Windows.Forms.Label();
            this.llServiceFacadeInstaller = new System.Windows.Forms.LinkLabel();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.dfsControllerMethod = new System.Windows.Forms.TextBox();
            this.llServiceInstaller = new System.Windows.Forms.LinkLabel();
            this.llControllerClass = new System.Windows.Forms.LinkLabel();
            this.logDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.btnGetEncompass = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tbResult.SuspendLayout();
            this.tbLog.SuspendLayout();
            this.tbSQL.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProductSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVendorSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVendor)).BeginInit();
            this.gbVendorProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.gbProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.gbVendor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grbSQLExecuter.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.sbMain.SuspendLayout();
            this.tbLogTabs.SuspendLayout();
            this.tbErrors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdErrors)).BeginInit();
            this.tbWarning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWarningLogs)).BeginInit();
            this.tbOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOtherLogs)).BeginInit();
            this.tbProbable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProb)).BeginInit();
            this.tbAuditLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAuditLog)).BeginInit();
            this.tbIntegrationServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIntegrationLog)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            this.tbBackend.SuspendLayout();
            this.tbMicroService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.tbServiceHostService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.tbTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tvServices
            // 
            this.tvServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvServices.ImageKey = "S.png";
            this.tvServices.ImageList = this.ilMain;
            this.tvServices.ItemHeight = 32;
            this.tvServices.Location = new System.Drawing.Point(0, 24);
            this.tvServices.Name = "tvServices";
            this.tvServices.SelectedImageIndex = 0;
            this.tvServices.ShowNodeToolTips = true;
            this.tvServices.Size = new System.Drawing.Size(666, 528);
            this.tvServices.TabIndex = 10;
            this.tvServices.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvServices_AfterSelect);
            this.tvServices.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tvServices_KeyUp);
            this.tvServices.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvServices_MouseClick);
            // 
            // ilMain
            // 
            this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
            this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMain.Images.SetKeyName(0, "blank.png");
            this.ilMain.Images.SetKeyName(1, "S.png");
            this.ilMain.Images.SetKeyName(2, "V.jpg");
            this.ilMain.Images.SetKeyName(3, "P.png");
            this.ilMain.Images.SetKeyName(4, "AddService.png");
            this.ilMain.Images.SetKeyName(5, "AddVendor.png");
            this.ilMain.Images.SetKeyName(6, "AddProduct.png");
            this.ilMain.Images.SetKeyName(7, "SettingsService.png");
            this.ilMain.Images.SetKeyName(8, "SettingsVendor.png");
            this.ilMain.Images.SetKeyName(9, "SettingsProduct.png");
            this.ilMain.Images.SetKeyName(10, "SQL-Management-Studio.png");
            this.ilMain.Images.SetKeyName(11, "text-file-icon-md.png");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOrphans,
            this.tsLocalHostPath,
            this.tsLocalDB,
            this.tsLog4net,
            this.tsEncompassVersions,
            this.tsStatus,
            this.toolStripStatusLabel1,
            this.tsServiceCount,
            this.toolStripStatusLabel2,
            this.tsVendorCount,
            this.tsProductImage,
            this.tsProductcount,
            this.toolStripStatusLabel3,
            this.tsVendorProducts,
            this.toolStripStatusLabel5,
            this.tsVendorSettings,
            this.toolStripStatusLabel7,
            this.tsProductSettings});
            this.statusStrip1.Location = new System.Drawing.Point(0, 828);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(977, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsOrphans
            // 
            this.tsOrphans.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsOrphans.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOrphanService,
            this.tsOrphanProducts,
            this.tsOrphanVendors,
            this.tsOrphanSettingType});
            this.tsOrphans.Image = ((System.Drawing.Image)(resources.GetObject("tsOrphans.Image")));
            this.tsOrphans.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOrphans.Name = "tsOrphans";
            this.tsOrphans.Size = new System.Drawing.Size(68, 20);
            this.tsOrphans.Text = "Orphans";
            this.tsOrphans.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsOrphans_DropDownItemClicked);
            // 
            // tsOrphanService
            // 
            this.tsOrphanService.Name = "tsOrphanService";
            this.tsOrphanService.Size = new System.Drawing.Size(191, 22);
            this.tsOrphanService.Text = "0 Orphan Service";
            // 
            // tsOrphanProducts
            // 
            this.tsOrphanProducts.Name = "tsOrphanProducts";
            this.tsOrphanProducts.Size = new System.Drawing.Size(191, 22);
            this.tsOrphanProducts.Text = "0 Orphan Products";
            // 
            // tsOrphanVendors
            // 
            this.tsOrphanVendors.Name = "tsOrphanVendors";
            this.tsOrphanVendors.Size = new System.Drawing.Size(191, 22);
            this.tsOrphanVendors.Text = "0 Orphan Vendors";
            // 
            // tsOrphanSettingType
            // 
            this.tsOrphanSettingType.Name = "tsOrphanSettingType";
            this.tsOrphanSettingType.Size = new System.Drawing.Size(191, 22);
            this.tsOrphanSettingType.Text = "0 Orphan Setting Type";
            // 
            // tsLocalHostPath
            // 
            this.tsLocalHostPath.Name = "tsLocalHostPath";
            this.tsLocalHostPath.Size = new System.Drawing.Size(152, 17);
            this.tsLocalHostPath.Text = "c:\\code\\imp\\126\\Trunk.126";
            this.tsLocalHostPath.ToolTipText = "My IIS Project";
            // 
            // tsLocalDB
            // 
            this.tsLocalDB.Name = "tsLocalDB";
            this.tsLocalDB.Size = new System.Drawing.Size(50, 17);
            this.tsLocalDB.Text = "LocalDB";
            this.tsLocalDB.ToolTipText = "my local database";
            this.tsLocalDB.Click += new System.EventHandler(this.tsLocalDB_Click);
            // 
            // tsLog4net
            // 
            this.tsLog4net.AutoToolTip = true;
            this.tsLog4net.Name = "tsLog4net";
            this.tsLog4net.Size = new System.Drawing.Size(89, 17);
            this.tsLog4net.Text = "Log4Net.config";
            this.tsLog4net.ToolTipText = "log4net.config database";
            this.tsLog4net.Click += new System.EventHandler(this.tsLog4net_Click);
            // 
            // tsEncompassVersions
            // 
            this.tsEncompassVersions.Name = "tsEncompassVersions";
            this.tsEncompassVersions.Size = new System.Drawing.Size(0, 17);
            this.tsEncompassVersions.ToolTipText = "Encompass version";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(429, 17);
            this.tsStatus.Spring = true;
            this.tsStatus.Text = "Ready";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel1.Image = global::VendorManager.Properties.Resources.S;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tsServiceCount
            // 
            this.tsServiceCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsServiceCount.Name = "tsServiceCount";
            this.tsServiceCount.Size = new System.Drawing.Size(13, 17);
            this.tsServiceCount.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel2.Image = global::VendorManager.Properties.Resources.V;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // tsVendorCount
            // 
            this.tsVendorCount.Name = "tsVendorCount";
            this.tsVendorCount.Size = new System.Drawing.Size(13, 17);
            this.tsVendorCount.Text = "0";
            // 
            // tsProductImage
            // 
            this.tsProductImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsProductImage.Image = global::VendorManager.Properties.Resources.P;
            this.tsProductImage.Name = "tsProductImage";
            this.tsProductImage.Size = new System.Drawing.Size(16, 17);
            this.tsProductImage.Text = "0";
            // 
            // tsProductcount
            // 
            this.tsProductcount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsProductcount.Name = "tsProductcount";
            this.tsProductcount.Size = new System.Drawing.Size(13, 17);
            this.tsProductcount.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel3.Image = global::VendorManager.Properties.Resources.VP;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // tsVendorProducts
            // 
            this.tsVendorProducts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsVendorProducts.Name = "tsVendorProducts";
            this.tsVendorProducts.Size = new System.Drawing.Size(13, 17);
            this.tsVendorProducts.Text = "0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel5.Image = global::VendorManager.Properties.Resources.SettingsVendor1;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel5.Text = "toolStripStatusLabel5";
            // 
            // tsVendorSettings
            // 
            this.tsVendorSettings.Name = "tsVendorSettings";
            this.tsVendorSettings.Size = new System.Drawing.Size(13, 17);
            this.tsVendorSettings.Text = "0";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel7.Image = global::VendorManager.Properties.Resources.SettingsProduct;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel7.Text = "toolStripStatusLabel7";
            // 
            // tsProductSettings
            // 
            this.tsProductSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsProductSettings.Name = "tsProductSettings";
            this.tsProductSettings.Size = new System.Drawing.Size(13, 17);
            this.tsProductSettings.Text = "0";
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(3, 3);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.splitContainer2);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.groupBox2);
            this.scMain.Panel2.Controls.Add(this.groupBox1);
            this.scMain.Size = new System.Drawing.Size(963, 796);
            this.scMain.SplitterDistance = 666;
            this.scMain.SplitterWidth = 16;
            this.scMain.TabIndex = 15;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvServices);
            this.splitContainer2.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tbResult);
            this.splitContainer2.Panel2.Controls.Add(this.dfcDatabase);
            this.splitContainer2.Size = new System.Drawing.Size(666, 796);
            this.splitContainer2.SplitterDistance = 552;
            this.splitContainer2.SplitterWidth = 16;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(666, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUMLDiagram});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // mnuUMLDiagram
            // 
            this.mnuUMLDiagram.Image = global::VendorManager.Properties.Resources.UMLIcon;
            this.mnuUMLDiagram.Name = "mnuUMLDiagram";
            this.mnuUMLDiagram.Size = new System.Drawing.Size(147, 22);
            this.mnuUMLDiagram.Text = "&UML Diagram";
            this.mnuUMLDiagram.Click += new System.EventHandler(this.mnuUMLDiagram_Click);
            // 
            // tbResult
            // 
            this.tbResult.Controls.Add(this.tbLog);
            this.tbResult.Controls.Add(this.tbSQL);
            this.tbResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbResult.ImageList = this.ilMain;
            this.tbResult.Location = new System.Drawing.Point(0, 0);
            this.tbResult.Name = "tbResult";
            this.tbResult.SelectedIndex = 0;
            this.tbResult.Size = new System.Drawing.Size(666, 190);
            this.tbResult.TabIndex = 1;
            this.tbResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbResult_MouseDoubleClick);
            // 
            // tbLog
            // 
            this.tbLog.Controls.Add(this.dfsLog);
            this.tbLog.ImageIndex = 11;
            this.tbLog.Location = new System.Drawing.Point(4, 23);
            this.tbLog.Name = "tbLog";
            this.tbLog.Padding = new System.Windows.Forms.Padding(3);
            this.tbLog.Size = new System.Drawing.Size(658, 163);
            this.tbLog.TabIndex = 0;
            this.tbLog.Text = "Log";
            this.tbLog.ToolTipText = "Log Entries";
            this.tbLog.UseVisualStyleBackColor = true;
            // 
            // dfsLog
            // 
            this.dfsLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dfsLog.Location = new System.Drawing.Point(3, 3);
            this.dfsLog.Name = "dfsLog";
            this.dfsLog.Size = new System.Drawing.Size(652, 157);
            this.dfsLog.TabIndex = 0;
            this.dfsLog.Text = "";
            // 
            // tbSQL
            // 
            this.tbSQL.Controls.Add(this.dfsSQL);
            this.tbSQL.ImageKey = "SQL-Management-Studio.png";
            this.tbSQL.Location = new System.Drawing.Point(4, 23);
            this.tbSQL.Name = "tbSQL";
            this.tbSQL.Padding = new System.Windows.Forms.Padding(3);
            this.tbSQL.Size = new System.Drawing.Size(622, 31);
            this.tbSQL.TabIndex = 1;
            this.tbSQL.Text = "SQL";
            this.tbSQL.ToolTipText = "Generated SQL Script";
            this.tbSQL.UseVisualStyleBackColor = true;
            // 
            // dfsSQL
            // 
            this.dfsSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dfsSQL.Location = new System.Drawing.Point(3, 3);
            this.dfsSQL.Name = "dfsSQL";
            this.dfsSQL.Size = new System.Drawing.Size(616, 25);
            this.dfsSQL.TabIndex = 1;
            this.dfsSQL.Text = "";
            // 
            // dfcDatabase
            // 
            this.dfcDatabase.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dfcDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dfcDatabase.FormattingEnabled = true;
            this.dfcDatabase.Location = new System.Drawing.Point(0, 207);
            this.dfcDatabase.Name = "dfcDatabase";
            this.dfcDatabase.Size = new System.Drawing.Size(666, 21);
            this.dfcDatabase.TabIndex = 1;
            this.dfcDatabase.SelectedIndexChanged += new System.EventHandler(this.dfcDatabase_SelectedIndexChanged);
            this.dfcDatabase.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dfcDatabase_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveChanges);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 746);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 50);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Additional Actions";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.Location = new System.Drawing.Point(6, 17);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(269, 23);
            this.btnSaveChanges.TabIndex = 0;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbSetting);
            this.groupBox1.Controls.Add(this.gbVendorProduct);
            this.groupBox1.Controls.Add(this.gbProduct);
            this.groupBox1.Controls.Add(this.gbVendor);
            this.groupBox1.Controls.Add(this.gbService);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 723);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Additional Information";
            // 
            // gbSetting
            // 
            this.gbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSetting.Controls.Add(this.picProductSetting);
            this.gbSetting.Controls.Add(this.picProduct);
            this.gbSetting.Controls.Add(this.label24);
            this.gbSetting.Controls.Add(this.label15);
            this.gbSetting.Controls.Add(this.dfsSettingObjectValue);
            this.gbSetting.Controls.Add(this.label23);
            this.gbSetting.Controls.Add(this.dfsSettingRestriction);
            this.gbSetting.Controls.Add(this.label22);
            this.gbSetting.Controls.Add(this.dfsSettingDefaultValue);
            this.gbSetting.Controls.Add(this.label21);
            this.gbSetting.Controls.Add(this.dfsSettingDataEntryType);
            this.gbSetting.Controls.Add(this.label20);
            this.gbSetting.Controls.Add(this.dfsSettingDescription);
            this.gbSetting.Controls.Add(this.picVendorSetting);
            this.gbSetting.Controls.Add(this.picVendor);
            this.gbSetting.Controls.Add(this.label17);
            this.gbSetting.Controls.Add(this.label18);
            this.gbSetting.Controls.Add(this.dfsSettingName);
            this.gbSetting.Controls.Add(this.label19);
            this.gbSetting.Controls.Add(this.dfsSettingCode);
            this.gbSetting.Location = new System.Drawing.Point(6, 433);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(254, 262);
            this.gbSetting.TabIndex = 25;
            this.gbSetting.TabStop = false;
            // 
            // picProductSetting
            // 
            this.picProductSetting.Image = global::VendorManager.Properties.Resources.SettingsProduct;
            this.picProductSetting.Location = new System.Drawing.Point(9, 14);
            this.picProductSetting.Name = "picProductSetting";
            this.picProductSetting.Size = new System.Drawing.Size(21, 20);
            this.picProductSetting.TabIndex = 38;
            this.picProductSetting.TabStop = false;
            // 
            // picProduct
            // 
            this.picProduct.Image = global::VendorManager.Properties.Resources.P;
            this.picProduct.Location = new System.Drawing.Point(33, 14);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(21, 20);
            this.picProduct.TabIndex = 37;
            this.picProduct.TabStop = false;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(149, 183);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(90, 13);
            this.label24.TabIndex = 36;
            this.label24.Text = "IntegrationSetting";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(6, 210);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Value";
            // 
            // dfsSettingObjectValue
            // 
            this.dfsSettingObjectValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsSettingObjectValue.ForeColor = System.Drawing.Color.Black;
            this.dfsSettingObjectValue.Location = new System.Drawing.Point(110, 207);
            this.dfsSettingObjectValue.Name = "dfsSettingObjectValue";
            this.dfsSettingObjectValue.Size = new System.Drawing.Size(134, 20);
            this.dfsSettingObjectValue.TabIndex = 35;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(6, 156);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(57, 13);
            this.label23.TabIndex = 32;
            this.label23.Text = "Restriction";
            // 
            // dfsSettingRestriction
            // 
            this.dfsSettingRestriction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsSettingRestriction.ForeColor = System.Drawing.Color.Black;
            this.dfsSettingRestriction.Location = new System.Drawing.Point(110, 153);
            this.dfsSettingRestriction.Name = "dfsSettingRestriction";
            this.dfsSettingRestriction.Size = new System.Drawing.Size(134, 20);
            this.dfsSettingRestriction.TabIndex = 33;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(6, 133);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 13);
            this.label22.TabIndex = 30;
            this.label22.Text = "Default Value";
            // 
            // dfsSettingDefaultValue
            // 
            this.dfsSettingDefaultValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsSettingDefaultValue.ForeColor = System.Drawing.Color.Black;
            this.dfsSettingDefaultValue.Location = new System.Drawing.Point(110, 130);
            this.dfsSettingDefaultValue.Name = "dfsSettingDefaultValue";
            this.dfsSettingDefaultValue.Size = new System.Drawing.Size(134, 20);
            this.dfsSettingDefaultValue.TabIndex = 31;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(6, 109);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 13);
            this.label21.TabIndex = 28;
            this.label21.Text = "Data Entry Type";
            // 
            // dfsSettingDataEntryType
            // 
            this.dfsSettingDataEntryType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsSettingDataEntryType.ForeColor = System.Drawing.Color.Black;
            this.dfsSettingDataEntryType.Location = new System.Drawing.Point(110, 106);
            this.dfsSettingDataEntryType.Name = "dfsSettingDataEntryType";
            this.dfsSettingDataEntryType.Size = new System.Drawing.Size(134, 20);
            this.dfsSettingDataEntryType.TabIndex = 29;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(6, 85);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 13);
            this.label20.TabIndex = 26;
            this.label20.Text = "Description";
            // 
            // dfsSettingDescription
            // 
            this.dfsSettingDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsSettingDescription.ForeColor = System.Drawing.Color.Black;
            this.dfsSettingDescription.Location = new System.Drawing.Point(110, 82);
            this.dfsSettingDescription.Name = "dfsSettingDescription";
            this.dfsSettingDescription.Size = new System.Drawing.Size(134, 20);
            this.dfsSettingDescription.TabIndex = 27;
            // 
            // picVendorSetting
            // 
            this.picVendorSetting.Image = global::VendorManager.Properties.Resources.SettingsVendor;
            this.picVendorSetting.Location = new System.Drawing.Point(9, 14);
            this.picVendorSetting.Name = "picVendorSetting";
            this.picVendorSetting.Size = new System.Drawing.Size(21, 20);
            this.picVendorSetting.TabIndex = 25;
            this.picVendorSetting.TabStop = false;
            // 
            // picVendor
            // 
            this.picVendor.Image = global::VendorManager.Properties.Resources.V;
            this.picVendor.Location = new System.Drawing.Point(33, 14);
            this.picVendor.Name = "picVendor";
            this.picVendor.Size = new System.Drawing.Size(21, 20);
            this.picVendor.TabIndex = 24;
            this.picVendor.TabStop = false;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(130, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(114, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "IntegrationSettingType";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(6, 41);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "Setting Name";
            // 
            // dfsSettingName
            // 
            this.dfsSettingName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsSettingName.ForeColor = System.Drawing.Color.Black;
            this.dfsSettingName.Location = new System.Drawing.Point(110, 37);
            this.dfsSettingName.Name = "dfsSettingName";
            this.dfsSettingName.Size = new System.Drawing.Size(134, 20);
            this.dfsSettingName.TabIndex = 17;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(6, 62);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "Code";
            // 
            // dfsSettingCode
            // 
            this.dfsSettingCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsSettingCode.ForeColor = System.Drawing.Color.Black;
            this.dfsSettingCode.Location = new System.Drawing.Point(110, 59);
            this.dfsSettingCode.Name = "dfsSettingCode";
            this.dfsSettingCode.Size = new System.Drawing.Size(134, 20);
            this.dfsSettingCode.TabIndex = 20;
            // 
            // gbVendorProduct
            // 
            this.gbVendorProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbVendorProduct.Controls.Add(this.pictureBox5);
            this.gbVendorProduct.Controls.Add(this.label13);
            this.gbVendorProduct.Controls.Add(this.label14);
            this.gbVendorProduct.Controls.Add(this.dfsVendorProductFQN);
            this.gbVendorProduct.Controls.Add(this.pictureBox4);
            this.gbVendorProduct.Controls.Add(this.label16);
            this.gbVendorProduct.Controls.Add(this.dfsVendorProductSimulatorUrl);
            this.gbVendorProduct.Location = new System.Drawing.Point(6, 338);
            this.gbVendorProduct.Name = "gbVendorProduct";
            this.gbVendorProduct.Size = new System.Drawing.Size(254, 95);
            this.gbVendorProduct.TabIndex = 24;
            this.gbVendorProduct.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::VendorManager.Properties.Resources.V;
            this.pictureBox5.Location = new System.Drawing.Point(9, 16);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(21, 20);
            this.pictureBox5.TabIndex = 24;
            this.pictureBox5.TabStop = false;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(111, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "IntegrationVendorProduct";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(6, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "FQN";
            // 
            // dfsVendorProductFQN
            // 
            this.dfsVendorProductFQN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsVendorProductFQN.ForeColor = System.Drawing.Color.Black;
            this.dfsVendorProductFQN.Location = new System.Drawing.Point(110, 37);
            this.dfsVendorProductFQN.Name = "dfsVendorProductFQN";
            this.dfsVendorProductFQN.Size = new System.Drawing.Size(134, 20);
            this.dfsVendorProductFQN.TabIndex = 17;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::VendorManager.Properties.Resources.P;
            this.pictureBox4.Location = new System.Drawing.Point(36, 16);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(21, 20);
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(6, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "SimulatorUrl";
            // 
            // dfsVendorProductSimulatorUrl
            // 
            this.dfsVendorProductSimulatorUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsVendorProductSimulatorUrl.ForeColor = System.Drawing.Color.Black;
            this.dfsVendorProductSimulatorUrl.Location = new System.Drawing.Point(110, 63);
            this.dfsVendorProductSimulatorUrl.Name = "dfsVendorProductSimulatorUrl";
            this.dfsVendorProductSimulatorUrl.Size = new System.Drawing.Size(134, 20);
            this.dfsVendorProductSimulatorUrl.TabIndex = 20;
            // 
            // gbProduct
            // 
            this.gbProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProduct.Controls.Add(this.label9);
            this.gbProduct.Controls.Add(this.label12);
            this.gbProduct.Controls.Add(this.dfsProductName);
            this.gbProduct.Controls.Add(this.dfsProductCode);
            this.gbProduct.Controls.Add(this.pictureBox3);
            this.gbProduct.Controls.Add(this.label10);
            this.gbProduct.Controls.Add(this.label11);
            this.gbProduct.Controls.Add(this.dfsProductDescription);
            this.gbProduct.Location = new System.Drawing.Point(6, 232);
            this.gbProduct.Name = "gbProduct";
            this.gbProduct.Size = new System.Drawing.Size(254, 108);
            this.gbProduct.TabIndex = 11;
            this.gbProduct.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(145, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "IntegrationProduct";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Green;
            this.label12.Location = new System.Drawing.Point(6, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Product Name";
            // 
            // dfsProductName
            // 
            this.dfsProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsProductName.ForeColor = System.Drawing.Color.Green;
            this.dfsProductName.Location = new System.Drawing.Point(110, 37);
            this.dfsProductName.Name = "dfsProductName";
            this.dfsProductName.Size = new System.Drawing.Size(134, 20);
            this.dfsProductName.TabIndex = 17;
            // 
            // dfsProductCode
            // 
            this.dfsProductCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsProductCode.ForeColor = System.Drawing.Color.Green;
            this.dfsProductCode.Location = new System.Drawing.Point(110, 82);
            this.dfsProductCode.Name = "dfsProductCode";
            this.dfsProductCode.Size = new System.Drawing.Size(134, 20);
            this.dfsProductCode.TabIndex = 22;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::VendorManager.Properties.Resources.P;
            this.pictureBox3.Location = new System.Drawing.Point(9, 14);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(21, 20);
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Green;
            this.label10.Location = new System.Drawing.Point(6, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Code";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Green;
            this.label11.Location = new System.Drawing.Point(6, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Description";
            // 
            // dfsProductDescription
            // 
            this.dfsProductDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsProductDescription.ForeColor = System.Drawing.Color.Green;
            this.dfsProductDescription.Location = new System.Drawing.Point(110, 59);
            this.dfsProductDescription.Name = "dfsProductDescription";
            this.dfsProductDescription.Size = new System.Drawing.Size(134, 20);
            this.dfsProductDescription.TabIndex = 20;
            // 
            // gbVendor
            // 
            this.gbVendor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbVendor.Controls.Add(this.label8);
            this.gbVendor.Controls.Add(this.label5);
            this.gbVendor.Controls.Add(this.dfsVendorName);
            this.gbVendor.Controls.Add(this.pictureBox2);
            this.gbVendor.Controls.Add(this.label4);
            this.gbVendor.Controls.Add(this.dfsVendorDescription);
            this.gbVendor.Controls.Add(this.label6);
            this.gbVendor.Controls.Add(this.dfsVendorCode);
            this.gbVendor.Controls.Add(this.label7);
            this.gbVendor.Controls.Add(this.dfsVendorSchema);
            this.gbVendor.Location = new System.Drawing.Point(6, 96);
            this.gbVendor.Name = "gbVendor";
            this.gbVendor.Size = new System.Drawing.Size(254, 137);
            this.gbVendor.TabIndex = 24;
            this.gbVendor.TabStop = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(148, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "IntegrationVendor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Vendor Name";
            // 
            // dfsVendorName
            // 
            this.dfsVendorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsVendorName.ForeColor = System.Drawing.Color.Blue;
            this.dfsVendorName.Location = new System.Drawing.Point(110, 43);
            this.dfsVendorName.Name = "dfsVendorName";
            this.dfsVendorName.Size = new System.Drawing.Size(134, 20);
            this.dfsVendorName.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::VendorManager.Properties.Resources.V;
            this.pictureBox2.Location = new System.Drawing.Point(9, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 20);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Description";
            // 
            // dfsVendorDescription
            // 
            this.dfsVendorDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsVendorDescription.ForeColor = System.Drawing.Color.Blue;
            this.dfsVendorDescription.Location = new System.Drawing.Point(110, 65);
            this.dfsVendorDescription.Name = "dfsVendorDescription";
            this.dfsVendorDescription.Size = new System.Drawing.Size(134, 20);
            this.dfsVendorDescription.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(6, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Code";
            // 
            // dfsVendorCode
            // 
            this.dfsVendorCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsVendorCode.ForeColor = System.Drawing.Color.Blue;
            this.dfsVendorCode.Location = new System.Drawing.Point(110, 87);
            this.dfsVendorCode.Name = "dfsVendorCode";
            this.dfsVendorCode.Size = new System.Drawing.Size(134, 20);
            this.dfsVendorCode.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(6, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Schema";
            // 
            // dfsVendorSchema
            // 
            this.dfsVendorSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsVendorSchema.ForeColor = System.Drawing.Color.Blue;
            this.dfsVendorSchema.Location = new System.Drawing.Point(110, 110);
            this.dfsVendorSchema.Name = "dfsVendorSchema";
            this.dfsVendorSchema.Size = new System.Drawing.Size(134, 20);
            this.dfsVendorSchema.TabIndex = 14;
            // 
            // gbService
            // 
            this.gbService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbService.Controls.Add(this.label3);
            this.gbService.Controls.Add(this.dfsServiceName);
            this.gbService.Controls.Add(this.label1);
            this.gbService.Controls.Add(this.pictureBox1);
            this.gbService.Controls.Add(this.label2);
            this.gbService.Controls.Add(this.dfsServiceDescription);
            this.gbService.Location = new System.Drawing.Point(9, 14);
            this.gbService.Name = "gbService";
            this.gbService.Size = new System.Drawing.Size(251, 84);
            this.gbService.TabIndex = 23;
            this.gbService.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "IntegrationServiceType";
            // 
            // dfsServiceName
            // 
            this.dfsServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsServiceName.Location = new System.Drawing.Point(97, 35);
            this.dfsServiceName.Name = "dfsServiceName";
            this.dfsServiceName.Size = new System.Drawing.Size(144, 20);
            this.dfsServiceName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VendorManager.Properties.Resources.S;
            this.pictureBox1.Location = new System.Drawing.Point(6, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 20);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description";
            // 
            // dfsServiceDescription
            // 
            this.dfsServiceDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsServiceDescription.Location = new System.Drawing.Point(97, 58);
            this.dfsServiceDescription.Name = "dfsServiceDescription";
            this.dfsServiceDescription.Size = new System.Drawing.Size(144, 20);
            this.dfsServiceDescription.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(977, 828);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.scMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(969, 802);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vendor Manager";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grbSQLExecuter);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.lblCreated);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.sbMain);
            this.tabPage2.Controls.Add(this.tbLogTabs);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(969, 802);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Log Analyzer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grbSQLExecuter
            // 
            this.grbSQLExecuter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSQLExecuter.Controls.Add(this.dfsSQLScript);
            this.grbSQLExecuter.Controls.Add(this.btnRunSQL);
            this.grbSQLExecuter.Controls.Add(this.dfcSQLScripts);
            this.grbSQLExecuter.Location = new System.Drawing.Point(686, 7);
            this.grbSQLExecuter.Name = "grbSQLExecuter";
            this.grbSQLExecuter.Size = new System.Drawing.Size(271, 93);
            this.grbSQLExecuter.TabIndex = 29;
            this.grbSQLExecuter.TabStop = false;
            this.grbSQLExecuter.Text = "SQL and RegEx Executer";
            // 
            // dfsSQLScript
            // 
            this.dfsSQLScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsSQLScript.Location = new System.Drawing.Point(7, 44);
            this.dfsSQLScript.Multiline = true;
            this.dfsSQLScript.Name = "dfsSQLScript";
            this.dfsSQLScript.Size = new System.Drawing.Size(258, 39);
            this.dfsSQLScript.TabIndex = 2;
            this.dfsSQLScript.Click += new System.EventHandler(this.dfsSQLScript_Click);
            this.dfsSQLScript.TextChanged += new System.EventHandler(this.dfsSQLScript_TextChanged);
            this.dfsSQLScript.Leave += new System.EventHandler(this.dfsSQLScript_Leave);
            // 
            // btnRunSQL
            // 
            this.btnRunSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunSQL.Location = new System.Drawing.Point(177, 12);
            this.btnRunSQL.Name = "btnRunSQL";
            this.btnRunSQL.Size = new System.Drawing.Size(88, 23);
            this.btnRunSQL.TabIndex = 1;
            this.btnRunSQL.Text = "Run and save";
            this.btnRunSQL.UseVisualStyleBackColor = true;
            this.btnRunSQL.Click += new System.EventHandler(this.btnRunSQL_Click);
            // 
            // dfcSQLScripts
            // 
            this.dfcSQLScripts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dfcSQLScripts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dfcSQLScripts.FormattingEnabled = true;
            this.dfcSQLScripts.Location = new System.Drawing.Point(7, 15);
            this.dfcSQLScripts.Name = "dfcSQLScripts";
            this.dfcSQLScripts.Size = new System.Drawing.Size(164, 21);
            this.dfcSQLScripts.TabIndex = 0;
            this.dfcSQLScripts.SelectedIndexChanged += new System.EventHandler(this.dfcSQLScripts_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGetEncompass);
            this.groupBox3.Controls.Add(this.dfsFilter);
            this.groupBox3.Controls.Add(this.dfsLoanId);
            this.groupBox3.Controls.Add(this.llMeAndMyLoan);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.btnReadLogi);
            this.groupBox3.Controls.Add(this.dffDistinct);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.dffLast20Minutes);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(674, 94);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log Search";
            // 
            // dfsFilter
            // 
            this.dfsFilter.Location = new System.Drawing.Point(63, 45);
            this.dfsFilter.Name = "dfsFilter";
            this.dfsFilter.Size = new System.Drawing.Size(307, 20);
            this.dfsFilter.TabIndex = 16;
            this.dfsFilter.TextChanged += new System.EventHandler(this.dfsFilter_TextChanged);
            this.dfsFilter.Leave += new System.EventHandler(this.dfsFilter_Leave);
            // 
            // dfsLoanId
            // 
            this.dfsLoanId.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::VendorManager.Properties.Settings.Default, "LoanId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dfsLoanId.Location = new System.Drawing.Point(63, 19);
            this.dfsLoanId.Name = "dfsLoanId";
            this.dfsLoanId.Size = new System.Drawing.Size(307, 20);
            this.dfsLoanId.TabIndex = 12;
            this.dfsLoanId.Text = global::VendorManager.Properties.Settings.Default.LoanId;
            this.dfsLoanId.TextChanged += new System.EventHandler(this.dfsLoanId_TextChanged);
            // 
            // llMeAndMyLoan
            // 
            this.llMeAndMyLoan.AutoSize = true;
            this.llMeAndMyLoan.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::VendorManager.Properties.Settings.Default, "MeAndMyLoan", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.llMeAndMyLoan.Location = new System.Drawing.Point(376, 22);
            this.llMeAndMyLoan.Name = "llMeAndMyLoan";
            this.llMeAndMyLoan.Size = new System.Drawing.Size(208, 13);
            this.llMeAndMyLoan.TabIndex = 20;
            this.llMeAndMyLoan.TabStop = true;
            this.llMeAndMyLoan.Text = global::VendorManager.Properties.Settings.Default.MeAndMyLoan;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(5, 48);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 13);
            this.label27.TabIndex = 25;
            this.label27.Text = "Filter";
            // 
            // btnReadLogi
            // 
            this.btnReadLogi.Location = new System.Drawing.Point(63, 67);
            this.btnReadLogi.Name = "btnReadLogi";
            this.btnReadLogi.Size = new System.Drawing.Size(83, 23);
            this.btnReadLogi.TabIndex = 18;
            this.btnReadLogi.Text = "Get Logs";
            this.btnReadLogi.UseVisualStyleBackColor = true;
            this.btnReadLogi.Click += new System.EventHandler(this.btnReadLogi_Click);
            // 
            // dffDistinct
            // 
            this.dffDistinct.AutoSize = true;
            this.dffDistinct.Location = new System.Drawing.Point(379, 47);
            this.dffDistinct.Name = "dffDistinct";
            this.dffDistinct.Size = new System.Drawing.Size(61, 17);
            this.dffDistinct.TabIndex = 21;
            this.dffDistinct.Text = "Distinct";
            this.dffDistinct.UseVisualStyleBackColor = true;
            this.dffDistinct.CheckedChanged += new System.EventHandler(this.dffDistinct_CheckedChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(5, 22);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(40, 13);
            this.label28.TabIndex = 24;
            this.label28.Text = "LoanId";
            // 
            // dffLast20Minutes
            // 
            this.dffLast20Minutes.AutoSize = true;
            this.dffLast20Minutes.Location = new System.Drawing.Point(379, 67);
            this.dffLast20Minutes.Name = "dffLast20Minutes";
            this.dffLast20Minutes.Size = new System.Drawing.Size(123, 17);
            this.dffLast20Minutes.TabIndex = 22;
            this.dffLast20Minutes.Text = "Last 20 Minutes only";
            this.dffLast20Minutes.UseVisualStyleBackColor = true;
            this.dffLast20Minutes.CheckedChanged += new System.EventHandler(this.dffLast20Minutes_CheckedChanged);
            // 
            // lblCreated
            // 
            this.lblCreated.AutoSize = true;
            this.lblCreated.Location = new System.Drawing.Point(575, 43);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(0, 13);
            this.lblCreated.TabIndex = 23;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(-55, 43);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 13);
            this.label25.TabIndex = 17;
            this.label25.Text = "Filter";
            // 
            // sbMain
            // 
            this.sbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMessage});
            this.sbMain.Location = new System.Drawing.Point(3, 777);
            this.sbMain.Name = "sbMain";
            this.sbMain.Size = new System.Drawing.Size(963, 22);
            this.sbMain.TabIndex = 15;
            this.sbMain.Text = "statusStrip1";
            // 
            // tsMessage
            // 
            this.tsMessage.Name = "tsMessage";
            this.tsMessage.Size = new System.Drawing.Size(948, 17);
            this.tsMessage.Spring = true;
            this.tsMessage.Text = "Ready";
            // 
            // tbLogTabs
            // 
            this.tbLogTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLogTabs.Controls.Add(this.tbErrors);
            this.tbLogTabs.Controls.Add(this.tbWarning);
            this.tbLogTabs.Controls.Add(this.tbOther);
            this.tbLogTabs.Controls.Add(this.tbProbable);
            this.tbLogTabs.Controls.Add(this.tbAuditLog);
            this.tbLogTabs.Controls.Add(this.tbIntegrationServices);
            this.tbLogTabs.ImageList = this.imageList1;
            this.tbLogTabs.Location = new System.Drawing.Point(3, 106);
            this.tbLogTabs.Name = "tbLogTabs";
            this.tbLogTabs.SelectedIndex = 0;
            this.tbLogTabs.Size = new System.Drawing.Size(958, 668);
            this.tbLogTabs.TabIndex = 14;
            this.tbLogTabs.SelectedIndexChanged += new System.EventHandler(this.tbLog_SelectedIndexChanged);
            // 
            // tbErrors
            // 
            this.tbErrors.Controls.Add(this.grdErrors);
            this.tbErrors.ImageIndex = 0;
            this.tbErrors.Location = new System.Drawing.Point(4, 23);
            this.tbErrors.Name = "tbErrors";
            this.tbErrors.Padding = new System.Windows.Forms.Padding(3);
            this.tbErrors.Size = new System.Drawing.Size(950, 641);
            this.tbErrors.TabIndex = 0;
            this.tbErrors.Text = "Errors";
            this.tbErrors.UseVisualStyleBackColor = true;
            // 
            // grdErrors
            // 
            this.grdErrors.AllowUserToAddRows = false;
            this.grdErrors.AllowUserToDeleteRows = false;
            this.grdErrors.AllowUserToOrderColumns = true;
            this.grdErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdErrors.Location = new System.Drawing.Point(3, 3);
            this.grdErrors.Name = "grdErrors";
            this.grdErrors.ReadOnly = true;
            this.grdErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdErrors.Size = new System.Drawing.Size(944, 635);
            this.grdErrors.TabIndex = 0;
            this.grdErrors.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdErrors_CellClick);
            this.grdErrors.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdErrors_CellContentDoubleClick);
            // 
            // tbWarning
            // 
            this.tbWarning.Controls.Add(this.grdWarningLogs);
            this.tbWarning.ImageIndex = 1;
            this.tbWarning.Location = new System.Drawing.Point(4, 23);
            this.tbWarning.Name = "tbWarning";
            this.tbWarning.Padding = new System.Windows.Forms.Padding(3);
            this.tbWarning.Size = new System.Drawing.Size(950, 641);
            this.tbWarning.TabIndex = 1;
            this.tbWarning.Text = "Warning";
            this.tbWarning.UseVisualStyleBackColor = true;
            // 
            // grdWarningLogs
            // 
            this.grdWarningLogs.AllowUserToAddRows = false;
            this.grdWarningLogs.AllowUserToDeleteRows = false;
            this.grdWarningLogs.AllowUserToOrderColumns = true;
            this.grdWarningLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWarningLogs.Location = new System.Drawing.Point(3, 3);
            this.grdWarningLogs.Name = "grdWarningLogs";
            this.grdWarningLogs.ReadOnly = true;
            this.grdWarningLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdWarningLogs.Size = new System.Drawing.Size(944, 635);
            this.grdWarningLogs.TabIndex = 1;
            this.grdWarningLogs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdWarningLogs_CellContentClick);
            this.grdWarningLogs.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdWarningLogs_CellContentDoubleClick);
            // 
            // tbOther
            // 
            this.tbOther.Controls.Add(this.grdOtherLogs);
            this.tbOther.ImageIndex = 2;
            this.tbOther.Location = new System.Drawing.Point(4, 23);
            this.tbOther.Name = "tbOther";
            this.tbOther.Size = new System.Drawing.Size(950, 641);
            this.tbOther.TabIndex = 2;
            this.tbOther.Text = "Other";
            this.tbOther.UseVisualStyleBackColor = true;
            // 
            // grdOtherLogs
            // 
            this.grdOtherLogs.AllowUserToAddRows = false;
            this.grdOtherLogs.AllowUserToDeleteRows = false;
            this.grdOtherLogs.AllowUserToOrderColumns = true;
            this.grdOtherLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOtherLogs.Location = new System.Drawing.Point(0, 0);
            this.grdOtherLogs.Name = "grdOtherLogs";
            this.grdOtherLogs.ReadOnly = true;
            this.grdOtherLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdOtherLogs.Size = new System.Drawing.Size(950, 641);
            this.grdOtherLogs.TabIndex = 1;
            this.grdOtherLogs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOtherLogs_CellContentClick);
            this.grdOtherLogs.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOtherLogs_CellContentDoubleClick);
            // 
            // tbProbable
            // 
            this.tbProbable.Controls.Add(this.grdProb);
            this.tbProbable.Location = new System.Drawing.Point(4, 23);
            this.tbProbable.Name = "tbProbable";
            this.tbProbable.Padding = new System.Windows.Forms.Padding(3);
            this.tbProbable.Size = new System.Drawing.Size(950, 641);
            this.tbProbable.TabIndex = 3;
            this.tbProbable.Text = "Last 100 Errors";
            this.tbProbable.UseVisualStyleBackColor = true;
            // 
            // grdProb
            // 
            this.grdProb.AllowUserToAddRows = false;
            this.grdProb.AllowUserToDeleteRows = false;
            this.grdProb.AllowUserToOrderColumns = true;
            this.grdProb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProb.Location = new System.Drawing.Point(3, 3);
            this.grdProb.Name = "grdProb";
            this.grdProb.ReadOnly = true;
            this.grdProb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdProb.Size = new System.Drawing.Size(944, 635);
            this.grdProb.TabIndex = 2;
            // 
            // tbAuditLog
            // 
            this.tbAuditLog.Controls.Add(this.grdAuditLog);
            this.tbAuditLog.Location = new System.Drawing.Point(4, 23);
            this.tbAuditLog.Name = "tbAuditLog";
            this.tbAuditLog.Padding = new System.Windows.Forms.Padding(3);
            this.tbAuditLog.Size = new System.Drawing.Size(950, 641);
            this.tbAuditLog.TabIndex = 4;
            this.tbAuditLog.Text = "Audit Log";
            this.tbAuditLog.UseVisualStyleBackColor = true;
            // 
            // grdAuditLog
            // 
            this.grdAuditLog.AllowUserToAddRows = false;
            this.grdAuditLog.AllowUserToDeleteRows = false;
            this.grdAuditLog.AllowUserToOrderColumns = true;
            this.grdAuditLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAuditLog.Location = new System.Drawing.Point(3, 3);
            this.grdAuditLog.Name = "grdAuditLog";
            this.grdAuditLog.ReadOnly = true;
            this.grdAuditLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdAuditLog.Size = new System.Drawing.Size(944, 635);
            this.grdAuditLog.TabIndex = 3;
            // 
            // tbIntegrationServices
            // 
            this.tbIntegrationServices.Controls.Add(this.grdIntegrationLog);
            this.tbIntegrationServices.Location = new System.Drawing.Point(4, 23);
            this.tbIntegrationServices.Name = "tbIntegrationServices";
            this.tbIntegrationServices.Padding = new System.Windows.Forms.Padding(3);
            this.tbIntegrationServices.Size = new System.Drawing.Size(950, 641);
            this.tbIntegrationServices.TabIndex = 5;
            this.tbIntegrationServices.Text = "Integration Log";
            this.tbIntegrationServices.UseVisualStyleBackColor = true;
            // 
            // grdIntegrationLog
            // 
            this.grdIntegrationLog.AllowUserToAddRows = false;
            this.grdIntegrationLog.AllowUserToDeleteRows = false;
            this.grdIntegrationLog.AllowUserToOrderColumns = true;
            this.grdIntegrationLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIntegrationLog.Location = new System.Drawing.Point(3, 3);
            this.grdIntegrationLog.Name = "grdIntegrationLog";
            this.grdIntegrationLog.ReadOnly = true;
            this.grdIntegrationLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdIntegrationLog.Size = new System.Drawing.Size(944, 635);
            this.grdIntegrationLog.TabIndex = 3;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ErrorIcon.PNG");
            this.imageList1.Images.SetKeyName(1, "WarningIcon.PNG");
            this.imageList1.Images.SetKeyName(2, "InformationIcon.PNG");
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(-55, 13);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(40, 13);
            this.label26.TabIndex = 13;
            this.label26.Text = "LoanId";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label44);
            this.tabPage3.Controls.Add(this.linkLabel1);
            this.tabPage3.Controls.Add(this.dfsPBI);
            this.tabPage3.Controls.Add(this.pictureBox14);
            this.tabPage3.Controls.Add(this.pictureBox13);
            this.tabPage3.Controls.Add(this.pictureBox12);
            this.tabPage3.Controls.Add(this.btnSave);
            this.tabPage3.Controls.Add(this.btnPrint);
            this.tabPage3.Controls.Add(this.picRest);
            this.tabPage3.Controls.Add(this.pictureBox17);
            this.tabPage3.Controls.Add(this.pictureBox18);
            this.tabPage3.Controls.Add(this.pictureBox19);
            this.tabPage3.Controls.Add(this.pictureBox20);
            this.tabPage3.Controls.Add(this.tbBackend);
            this.tabPage3.Controls.Add(this.llCanonicInterfaceClass);
            this.tabPage3.Controls.Add(this.llLoanCenterModelRequest);
            this.tabPage3.Controls.Add(this.llLoanCenterModelResponse);
            this.tabPage3.Controls.Add(this.llCanonicClass);
            this.tabPage3.Controls.Add(this.label49);
            this.tabPage3.Controls.Add(this.label50);
            this.tabPage3.Controls.Add(this.label51);
            this.tabPage3.Controls.Add(this.label52);
            this.tabPage3.Controls.Add(this.label53);
            this.tabPage3.Controls.Add(this.label54);
            this.tabPage3.Controls.Add(this.label57);
            this.tabPage3.Controls.Add(this.label58);
            this.tabPage3.Controls.Add(this.label59);
            this.tabPage3.Controls.Add(this.dfsCanonicInterfaceMethod);
            this.tabPage3.Controls.Add(this.label60);
            this.tabPage3.Controls.Add(this.dfsCanonicMethod);
            this.tabPage3.Controls.Add(this.dfcProjects);
            this.tabPage3.Controls.Add(this.llMeAndMyLoan2);
            this.tabPage3.Controls.Add(this.label61);
            this.tabPage3.Controls.Add(this.llServiceFacadeInstaller);
            this.tabPage3.Controls.Add(this.label62);
            this.tabPage3.Controls.Add(this.label63);
            this.tabPage3.Controls.Add(this.label64);
            this.tabPage3.Controls.Add(this.label65);
            this.tabPage3.Controls.Add(this.label66);
            this.tabPage3.Controls.Add(this.dfsControllerMethod);
            this.tabPage3.Controls.Add(this.llServiceInstaller);
            this.tabPage3.Controls.Add(this.llControllerClass);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(969, 802);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "UML Manager";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(638, 243);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(24, 13);
            this.label44.TabIndex = 102;
            this.label44.Text = "PBI";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(27, 240);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(260, 13);
            this.linkLabel1.TabIndex = 103;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Run CustomTool ServiceDesign\\ServiceGeneration.tt";
            // 
            // dfsPBI
            // 
            this.dfsPBI.Location = new System.Drawing.Point(668, 240);
            this.dfsPBI.Name = "dfsPBI";
            this.dfsPBI.Size = new System.Drawing.Size(265, 20);
            this.dfsPBI.TabIndex = 101;
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = global::VendorManager.Properties.Resources.DependencyRight;
            this.pictureBox14.Location = new System.Drawing.Point(305, 73);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(40, 14);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox14.TabIndex = 100;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = global::VendorManager.Properties.Resources.DependencyLeft;
            this.pictureBox13.Location = new System.Drawing.Point(591, 73);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(49, 14);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox13.TabIndex = 99;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = global::VendorManager.Properties.Resources.Interface2;
            this.pictureBox12.Location = new System.Drawing.Point(597, 162);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(45, 14);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 98;
            this.pictureBox12.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackgroundImage = global::VendorManager.Properties.Resources.Save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Location = new System.Drawing.Point(885, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(30, 29);
            this.btnSave.TabIndex = 76;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackgroundImage = global::VendorManager.Properties.Resources.Print;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(921, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(30, 29);
            this.btnPrint.TabIndex = 74;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // picRest
            // 
            this.picRest.Image = global::VendorManager.Properties.Resources.Rest;
            this.picRest.Location = new System.Drawing.Point(26, 34);
            this.picRest.Name = "picRest";
            this.picRest.Size = new System.Drawing.Size(277, 194);
            this.picRest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRest.TabIndex = 72;
            this.picRest.TabStop = false;
            // 
            // pictureBox17
            // 
            this.pictureBox17.Image = global::VendorManager.Properties.Resources.LoanCenterModel;
            this.pictureBox17.Location = new System.Drawing.Point(345, 11);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(246, 116);
            this.pictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox17.TabIndex = 89;
            this.pictureBox17.TabStop = false;
            // 
            // pictureBox18
            // 
            this.pictureBox18.Image = global::VendorManager.Properties.Resources.ServiceInterface;
            this.pictureBox18.Location = new System.Drawing.Point(343, 127);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(250, 145);
            this.pictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox18.TabIndex = 90;
            this.pictureBox18.TabStop = false;
            // 
            // pictureBox19
            // 
            this.pictureBox19.Image = global::VendorManager.Properties.Resources.CanonicUML;
            this.pictureBox19.Location = new System.Drawing.Point(641, 47);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(292, 187);
            this.pictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox19.TabIndex = 91;
            this.pictureBox19.TabStop = false;
            // 
            // pictureBox20
            // 
            this.pictureBox20.Image = global::VendorManager.Properties.Resources.Composition;
            this.pictureBox20.Location = new System.Drawing.Point(299, 199);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(345, 14);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox20.TabIndex = 97;
            this.pictureBox20.TabStop = false;
            // 
            // tbBackend
            // 
            this.tbBackend.Controls.Add(this.tbMicroService);
            this.tbBackend.Controls.Add(this.tbServiceHostService);
            this.tbBackend.Controls.Add(this.tbTest);
            this.tbBackend.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", global::VendorManager.Properties.Settings.Default, "SelectedTab", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbBackend.ImageList = this.imageList2;
            this.tbBackend.Location = new System.Drawing.Point(17, 278);
            this.tbBackend.Name = "tbBackend";
            this.tbBackend.SelectedIndex = global::VendorManager.Properties.Settings.Default.SelectedTab;
            this.tbBackend.Size = new System.Drawing.Size(934, 425);
            this.tbBackend.TabIndex = 96;
            // 
            // tbMicroService
            // 
            this.tbMicroService.Controls.Add(this.pictureBox21);
            this.tbMicroService.Controls.Add(this.pictureBox22);
            this.tbMicroService.Controls.Add(this.pictureBox23);
            this.tbMicroService.Controls.Add(this.lbl7);
            this.tbMicroService.Controls.Add(this.llPingService);
            this.tbMicroService.Controls.Add(this.llPortExcelSheet);
            this.tbMicroService.Controls.Add(this.dfstcpPort);
            this.tbMicroService.Controls.Add(this.dfsHttpPort);
            this.tbMicroService.Controls.Add(this.label45);
            this.tbMicroService.Controls.Add(this.dfsFQN);
            this.tbMicroService.Controls.Add(this.label46);
            this.tbMicroService.Controls.Add(this.llMSHostConfig);
            this.tbMicroService.Controls.Add(this.llMSServiceHost);
            this.tbMicroService.Controls.Add(this.llMSHelperClass);
            this.tbMicroService.Controls.Add(this.llMSServiceClass);
            this.tbMicroService.Controls.Add(this.llMSServiceInterface);
            this.tbMicroService.Controls.Add(this.lblMicroServiceService);
            this.tbMicroService.Controls.Add(this.pictureBox24);
            this.tbMicroService.Controls.Add(this.groupBox4);
            this.tbMicroService.Controls.Add(this.groupBox6);
            this.tbMicroService.Controls.Add(this.label39);
            this.tbMicroService.Controls.Add(this.label40);
            this.tbMicroService.Controls.Add(this.label48);
            this.tbMicroService.Controls.Add(this.label36);
            this.tbMicroService.Controls.Add(this.label37);
            this.tbMicroService.Controls.Add(this.dfsMSFacadeMethod);
            this.tbMicroService.Controls.Add(this.llMSFacadeFactoryClass);
            this.tbMicroService.Controls.Add(this.llMSFacadeClass);
            this.tbMicroService.Controls.Add(this.lblMicroServiceFacade);
            this.tbMicroService.Controls.Add(this.pictureBox6);
            this.tbMicroService.Controls.Add(this.llMSProxyClient);
            this.tbMicroService.Controls.Add(this.label38);
            this.tbMicroService.Controls.Add(this.label41);
            this.tbMicroService.Controls.Add(this.lblMicroServiceProxy);
            this.tbMicroService.Controls.Add(this.llMSProxyInterface);
            this.tbMicroService.Controls.Add(this.label42);
            this.tbMicroService.Controls.Add(this.pictureBox10);
            this.tbMicroService.Controls.Add(this.llMSContractResponse);
            this.tbMicroService.Controls.Add(this.llMSContractRequest);
            this.tbMicroService.Controls.Add(this.lblMicroserviceContracts);
            this.tbMicroService.Controls.Add(this.label43);
            this.tbMicroService.Controls.Add(this.pictureBox11);
            this.tbMicroService.Controls.Add(this.btnHowToInstallMicroService);
            this.tbMicroService.Controls.Add(this.btnHowToMicroService);
            this.tbMicroService.ImageIndex = 0;
            this.tbMicroService.Location = new System.Drawing.Point(4, 23);
            this.tbMicroService.Name = "tbMicroService";
            this.tbMicroService.Padding = new System.Windows.Forms.Padding(3);
            this.tbMicroService.Size = new System.Drawing.Size(926, 398);
            this.tbMicroService.TabIndex = 0;
            this.tbMicroService.Text = "Microservice";
            this.tbMicroService.UseVisualStyleBackColor = true;
            // 
            // pictureBox21
            // 
            this.pictureBox21.Image = global::VendorManager.Properties.Resources.ReferenceTransparent;
            this.pictureBox21.Location = new System.Drawing.Point(346, 163);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(230, 95);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox21.TabIndex = 98;
            this.pictureBox21.TabStop = false;
            // 
            // pictureBox22
            // 
            this.pictureBox22.Image = global::VendorManager.Properties.Resources.ReferenceDown;
            this.pictureBox22.Location = new System.Drawing.Point(802, 160);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(12, 38);
            this.pictureBox22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox22.TabIndex = 97;
            this.pictureBox22.TabStop = false;
            // 
            // pictureBox23
            // 
            this.pictureBox23.Image = global::VendorManager.Properties.Resources.Reference3Right;
            this.pictureBox23.Location = new System.Drawing.Point(349, 282);
            this.pictureBox23.Name = "pictureBox23";
            this.pictureBox23.Size = new System.Drawing.Size(228, 14);
            this.pictureBox23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox23.TabIndex = 94;
            this.pictureBox23.TabStop = false;
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.BackColor = System.Drawing.Color.Gold;
            this.lbl7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl7.Location = new System.Drawing.Point(320, 192);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(20, 24);
            this.lbl7.TabIndex = 89;
            this.lbl7.Text = "7";
            this.ttMain.SetToolTip(this.lbl7, resources.GetString("lbl7.ToolTip"));
            // 
            // llPingService
            // 
            this.llPingService.AutoSize = true;
            this.llPingService.Location = new System.Drawing.Point(299, 332);
            this.llPingService.Name = "llPingService";
            this.llPingService.Size = new System.Drawing.Size(28, 13);
            this.llPingService.TabIndex = 88;
            this.llPingService.TabStop = true;
            this.llPingService.Text = "Ping";
            // 
            // llPortExcelSheet
            // 
            this.llPortExcelSheet.AutoSize = true;
            this.llPortExcelSheet.Location = new System.Drawing.Point(24, 332);
            this.llPortExcelSheet.Name = "llPortExcelSheet";
            this.llPortExcelSheet.Size = new System.Drawing.Size(49, 13);
            this.llPortExcelSheet.TabIndex = 87;
            this.llPortExcelSheet.TabStop = true;
            this.llPortExcelSheet.Text = "Http Port";
            // 
            // dfstcpPort
            // 
            this.dfstcpPort.Location = new System.Drawing.Point(224, 328);
            this.dfstcpPort.Name = "dfstcpPort";
            this.dfstcpPort.Size = new System.Drawing.Size(72, 20);
            this.dfstcpPort.TabIndex = 86;
            // 
            // dfsHttpPort
            // 
            this.dfsHttpPort.Location = new System.Drawing.Point(79, 328);
            this.dfsHttpPort.Name = "dfsHttpPort";
            this.dfsHttpPort.Size = new System.Drawing.Size(58, 20);
            this.dfsHttpPort.TabIndex = 85;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(174, 332);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(44, 13);
            this.label45.TabIndex = 84;
            this.label45.Text = "tcp Port";
            // 
            // dfsFQN
            // 
            this.dfsFQN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dfsFQN.Location = new System.Drawing.Point(27, 306);
            this.dfsFQN.Multiline = true;
            this.dfsFQN.Name = "dfsFQN";
            this.dfsFQN.Size = new System.Drawing.Size(299, 19);
            this.dfsFQN.TabIndex = 83;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.Black;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.White;
            this.label46.Location = new System.Drawing.Point(315, 369);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(14, 15);
            this.label46.TabIndex = 82;
            this.label46.Text = "8";
            // 
            // llMSHostConfig
            // 
            this.llMSHostConfig.AutoSize = true;
            this.llMSHostConfig.Location = new System.Drawing.Point(30, 368);
            this.llMSHostConfig.Name = "llMSHostConfig";
            this.llMSHostConfig.Size = new System.Drawing.Size(101, 13);
            this.llMSHostConfig.TabIndex = 81;
            this.llMSHostConfig.TabStop = true;
            this.llMSHostConfig.Text = "Service Host Config";
            // 
            // llMSServiceHost
            // 
            this.llMSServiceHost.AutoSize = true;
            this.llMSServiceHost.Location = new System.Drawing.Point(30, 352);
            this.llMSServiceHost.Name = "llMSServiceHost";
            this.llMSServiceHost.Size = new System.Drawing.Size(68, 13);
            this.llMSServiceHost.TabIndex = 80;
            this.llMSServiceHost.TabStop = true;
            this.llMSServiceHost.Text = "Service Host";
            // 
            // llMSHelperClass
            // 
            this.llMSHelperClass.AutoSize = true;
            this.llMSHelperClass.Location = new System.Drawing.Point(30, 282);
            this.llMSHelperClass.Name = "llMSHelperClass";
            this.llMSHelperClass.Size = new System.Drawing.Size(66, 13);
            this.llMSHelperClass.TabIndex = 79;
            this.llMSHelperClass.TabStop = true;
            this.llMSHelperClass.Text = "Helper Class";
            // 
            // llMSServiceClass
            // 
            this.llMSServiceClass.AutoSize = true;
            this.llMSServiceClass.Location = new System.Drawing.Point(30, 259);
            this.llMSServiceClass.Name = "llMSServiceClass";
            this.llMSServiceClass.Size = new System.Drawing.Size(71, 13);
            this.llMSServiceClass.TabIndex = 78;
            this.llMSServiceClass.TabStop = true;
            this.llMSServiceClass.Text = "Service Class";
            // 
            // llMSServiceInterface
            // 
            this.llMSServiceInterface.AutoSize = true;
            this.llMSServiceInterface.Location = new System.Drawing.Point(30, 237);
            this.llMSServiceInterface.Name = "llMSServiceInterface";
            this.llMSServiceInterface.Size = new System.Drawing.Size(116, 13);
            this.llMSServiceInterface.TabIndex = 77;
            this.llMSServiceInterface.TabStop = true;
            this.llMSServiceInterface.Text = "Service Interface Class";
            // 
            // lblMicroServiceService
            // 
            this.lblMicroServiceService.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMicroServiceService.Location = new System.Drawing.Point(25, 210);
            this.lblMicroServiceService.Name = "lblMicroServiceService";
            this.lblMicroServiceService.Size = new System.Drawing.Size(303, 20);
            this.lblMicroServiceService.TabIndex = 76;
            this.lblMicroServiceService.Text = "$/MML.Services/Integrations/ProductName/Service";
            // 
            // pictureBox24
            // 
            this.pictureBox24.Image = global::VendorManager.Properties.Resources.MicroServiceUML;
            this.pictureBox24.Location = new System.Drawing.Point(8, 190);
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.Size = new System.Drawing.Size(340, 205);
            this.pictureBox24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox24.TabIndex = 75;
            this.pictureBox24.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbl9);
            this.groupBox4.Controls.Add(this.label47);
            this.groupBox4.Controls.Add(this.dfsVendorTypeEnum);
            this.groupBox4.Controls.Add(this.label55);
            this.groupBox4.Controls.Add(this.dfsProductTypeEnum);
            this.groupBox4.Location = new System.Drawing.Point(354, 51);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(192, 104);
            this.groupBox4.TabIndex = 74;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "$/Packages/iMP.Common.Core/Trunk.126/MML.Data.Enumerations";
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.BackColor = System.Drawing.Color.LimeGreen;
            this.lbl9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl9.Location = new System.Drawing.Point(168, 28);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(20, 24);
            this.lbl9.TabIndex = 8;
            this.lbl9.Text = "9";
            this.ttMain.SetToolTip(this.lbl9, "Need to add your product Type enumerations as well as vendor type to this project" +
        "");
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(9, 74);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(92, 13);
            this.label47.TabIndex = 11;
            this.label47.Text = "VendorTypeEnum";
            // 
            // dfsVendorTypeEnum
            // 
            this.dfsVendorTypeEnum.Location = new System.Drawing.Point(110, 71);
            this.dfsVendorTypeEnum.Name = "dfsVendorTypeEnum";
            this.dfsVendorTypeEnum.Size = new System.Drawing.Size(62, 20);
            this.dfsVendorTypeEnum.TabIndex = 12;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(9, 50);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(95, 13);
            this.label55.TabIndex = 9;
            this.label55.Text = "ProductTypeEnum";
            // 
            // dfsProductTypeEnum
            // 
            this.dfsProductTypeEnum.Location = new System.Drawing.Point(110, 47);
            this.dfsProductTypeEnum.Name = "dfsProductTypeEnum";
            this.dfsProductTypeEnum.Size = new System.Drawing.Size(62, 20);
            this.dfsProductTypeEnum.TabIndex = 10;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnAddmicroserviceInstaller);
            this.groupBox6.Controls.Add(this.label56);
            this.groupBox6.Location = new System.Drawing.Point(354, 339);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(192, 53);
            this.groupBox6.TabIndex = 73;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "$/iMP.Deployment.sln";
            // 
            // btnAddmicroserviceInstaller
            // 
            this.btnAddmicroserviceInstaller.Location = new System.Drawing.Point(12, 20);
            this.btnAddmicroserviceInstaller.Name = "btnAddmicroserviceInstaller";
            this.btnAddmicroserviceInstaller.Size = new System.Drawing.Size(75, 23);
            this.btnAddmicroserviceInstaller.TabIndex = 9;
            this.btnAddmicroserviceInstaller.Text = "Add Installer";
            this.btnAddmicroserviceInstaller.UseVisualStyleBackColor = true;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.BackColor = System.Drawing.Color.Magenta;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(158, 16);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(30, 24);
            this.label56.TabIndex = 8;
            this.label56.Text = "10";
            this.ttMain.SetToolTip(this.label56, "Need to add your product Type enumerations as well as vendor type to this project" +
        "");
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.Black;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(286, 162);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(14, 15);
            this.label39.TabIndex = 72;
            this.label39.Text = "6";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Black;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.White;
            this.label40.Location = new System.Drawing.Point(302, 162);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(14, 15);
            this.label40.TabIndex = 71;
            this.label40.Text = "8";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.BackColor = System.Drawing.Color.Gold;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(318, 9);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(20, 24);
            this.label48.TabIndex = 70;
            this.label48.Text = "5";
            this.ttMain.SetToolTip(this.label48, "Facade currently uses Factory to create concret Facade.\r\nThe factory receives imp" +
        "lementation of the ServiceClient\r\nto complete the Concret Facade creation.\r\n");
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Black;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.Location = new System.Drawing.Point(301, 138);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(14, 15);
            this.label36.TabIndex = 69;
            this.label36.Text = "8";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Black;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.Location = new System.Drawing.Point(30, 140);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(14, 15);
            this.label37.TabIndex = 68;
            this.label37.Text = "8";
            // 
            // dfsMSFacadeMethod
            // 
            this.dfsMSFacadeMethod.Location = new System.Drawing.Point(50, 137);
            this.dfsMSFacadeMethod.Name = "dfsMSFacadeMethod";
            this.dfsMSFacadeMethod.Size = new System.Drawing.Size(245, 20);
            this.dfsMSFacadeMethod.TabIndex = 67;
            // 
            // llMSFacadeFactoryClass
            // 
            this.llMSFacadeFactoryClass.AutoSize = true;
            this.llMSFacadeFactoryClass.Location = new System.Drawing.Point(41, 102);
            this.llMSFacadeFactoryClass.Name = "llMSFacadeFactoryClass";
            this.llMSFacadeFactoryClass.Size = new System.Drawing.Size(70, 13);
            this.llMSFacadeFactoryClass.TabIndex = 66;
            this.llMSFacadeFactoryClass.TabStop = true;
            this.llMSFacadeFactoryClass.Text = "Factory Class";
            // 
            // llMSFacadeClass
            // 
            this.llMSFacadeClass.AutoSize = true;
            this.llMSFacadeClass.Location = new System.Drawing.Point(41, 69);
            this.llMSFacadeClass.Name = "llMSFacadeClass";
            this.llMSFacadeClass.Size = new System.Drawing.Size(71, 13);
            this.llMSFacadeClass.TabIndex = 65;
            this.llMSFacadeClass.TabStop = true;
            this.llMSFacadeClass.Text = "Facade Class";
            // 
            // lblMicroServiceFacade
            // 
            this.lblMicroServiceFacade.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMicroServiceFacade.Location = new System.Drawing.Point(23, 33);
            this.lblMicroServiceFacade.Name = "lblMicroServiceFacade";
            this.lblMicroServiceFacade.Size = new System.Drawing.Size(303, 20);
            this.lblMicroServiceFacade.TabIndex = 64;
            this.lblMicroServiceFacade.Text = "$/MML.Services/Integrations/ProductName/Facade";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::VendorManager.Properties.Resources.EmptyUML;
            this.pictureBox6.Location = new System.Drawing.Point(5, 5);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(343, 184);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 63;
            this.pictureBox6.TabStop = false;
            // 
            // llMSProxyClient
            // 
            this.llMSProxyClient.AutoSize = true;
            this.llMSProxyClient.Location = new System.Drawing.Point(625, 110);
            this.llMSProxyClient.Name = "llMSProxyClient";
            this.llMSProxyClient.Size = new System.Drawing.Size(78, 13);
            this.llMSProxyClient.TabIndex = 62;
            this.llMSProxyClient.TabStop = true;
            this.llMSProxyClient.Text = "Interface Client";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Black;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(870, 108);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(14, 15);
            this.label38.TabIndex = 61;
            this.label38.Text = "8";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.Black;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.White;
            this.label41.Location = new System.Drawing.Point(605, 108);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(14, 15);
            this.label41.TabIndex = 60;
            this.label41.Text = "8";
            // 
            // lblMicroServiceProxy
            // 
            this.lblMicroServiceProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMicroServiceProxy.Location = new System.Drawing.Point(595, 28);
            this.lblMicroServiceProxy.Name = "lblMicroServiceProxy";
            this.lblMicroServiceProxy.Size = new System.Drawing.Size(296, 28);
            this.lblMicroServiceProxy.TabIndex = 58;
            this.lblMicroServiceProxy.Text = "$/MML.Services/Integrations/ProductName/Proxy";
            // 
            // llMSProxyInterface
            // 
            this.llMSProxyInterface.AutoSize = true;
            this.llMSProxyInterface.Location = new System.Drawing.Point(606, 66);
            this.llMSProxyInterface.Name = "llMSProxyInterface";
            this.llMSProxyInterface.Size = new System.Drawing.Size(77, 13);
            this.llMSProxyInterface.TabIndex = 57;
            this.llMSProxyInterface.TabStop = true;
            this.llMSProxyInterface.Text = "Interface Class";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.LightBlue;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(897, 2);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(20, 24);
            this.label42.TabIndex = 56;
            this.label42.Text = "6";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::VendorManager.Properties.Resources.ContractUML;
            this.pictureBox10.Location = new System.Drawing.Point(576, 2);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(341, 156);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 55;
            this.pictureBox10.TabStop = false;
            // 
            // llMSContractResponse
            // 
            this.llMSContractResponse.AutoSize = true;
            this.llMSContractResponse.Location = new System.Drawing.Point(607, 313);
            this.llMSContractResponse.Name = "llMSContractResponse";
            this.llMSContractResponse.Size = new System.Drawing.Size(98, 13);
            this.llMSContractResponse.TabIndex = 54;
            this.llMSContractResponse.TabStop = true;
            this.llMSContractResponse.Text = "Response Contract";
            // 
            // llMSContractRequest
            // 
            this.llMSContractRequest.AutoSize = true;
            this.llMSContractRequest.Location = new System.Drawing.Point(607, 269);
            this.llMSContractRequest.Name = "llMSContractRequest";
            this.llMSContractRequest.Size = new System.Drawing.Size(90, 13);
            this.llMSContractRequest.TabIndex = 53;
            this.llMSContractRequest.TabStop = true;
            this.llMSContractRequest.Text = "Request Contract";
            // 
            // lblMicroserviceContracts
            // 
            this.lblMicroserviceContracts.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMicroserviceContracts.Location = new System.Drawing.Point(595, 230);
            this.lblMicroserviceContracts.Name = "lblMicroserviceContracts";
            this.lblMicroserviceContracts.Size = new System.Drawing.Size(303, 28);
            this.lblMicroserviceContracts.TabIndex = 24;
            this.lblMicroserviceContracts.Text = "$/MML.Services/Integrations/ProductName/Contract";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.LimeGreen;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(892, 204);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(20, 24);
            this.label43.TabIndex = 23;
            this.label43.Text = "8";
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::VendorManager.Properties.Resources.ContractUML;
            this.pictureBox11.Location = new System.Drawing.Point(576, 204);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(344, 156);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 22;
            this.pictureBox11.TabStop = false;
            // 
            // btnHowToInstallMicroService
            // 
            this.btnHowToInstallMicroService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHowToInstallMicroService.AutoSize = true;
            this.btnHowToInstallMicroService.Location = new System.Drawing.Point(417, 9);
            this.btnHowToInstallMicroService.Name = "btnHowToInstallMicroService";
            this.btnHowToInstallMicroService.Size = new System.Drawing.Size(40, 13);
            this.btnHowToInstallMicroService.TabIndex = 21;
            this.btnHowToInstallMicroService.TabStop = true;
            this.btnHowToInstallMicroService.Text = "Install?";
            // 
            // btnHowToMicroService
            // 
            this.btnHowToMicroService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHowToMicroService.AutoSize = true;
            this.btnHowToMicroService.Location = new System.Drawing.Point(463, 9);
            this.btnHowToMicroService.Name = "btnHowToMicroService";
            this.btnHowToMicroService.Size = new System.Drawing.Size(47, 13);
            this.btnHowToMicroService.TabIndex = 20;
            this.btnHowToMicroService.TabStop = true;
            this.btnHowToMicroService.Text = "How to?";
            // 
            // tbServiceHostService
            // 
            this.tbServiceHostService.Controls.Add(this.pictureBox16);
            this.tbServiceHostService.Controls.Add(this.label29);
            this.tbServiceHostService.Controls.Add(this.label30);
            this.tbServiceHostService.Controls.Add(this.label31);
            this.tbServiceHostService.Controls.Add(this.label32);
            this.tbServiceHostService.Controls.Add(this.label33);
            this.tbServiceHostService.Controls.Add(this.llServiceClass);
            this.tbServiceHostService.Controls.Add(this.llServiceHandleContract);
            this.tbServiceHostService.Controls.Add(this.dfsServiceMethodName);
            this.tbServiceHostService.Controls.Add(this.lblServiceHostService);
            this.tbServiceHostService.Controls.Add(this.llServiceVMResponse);
            this.tbServiceHostService.Controls.Add(this.llServiceVMRequest);
            this.tbServiceHostService.Controls.Add(this.label34);
            this.tbServiceHostService.Controls.Add(this.llServiceFacadeClass);
            this.tbServiceHostService.Controls.Add(this.llServiceFacadeInterface);
            this.tbServiceHostService.Controls.Add(this.dfsServiceFacadeMethod);
            this.tbServiceHostService.Controls.Add(this.label35);
            this.tbServiceHostService.Controls.Add(this.pictureBox15);
            this.tbServiceHostService.Controls.Add(this.pictureBox9);
            this.tbServiceHostService.Controls.Add(this.pictureBox8);
            this.tbServiceHostService.Controls.Add(this.pictureBox7);
            this.tbServiceHostService.ImageIndex = 1;
            this.tbServiceHostService.Location = new System.Drawing.Point(4, 23);
            this.tbServiceHostService.Name = "tbServiceHostService";
            this.tbServiceHostService.Padding = new System.Windows.Forms.Padding(3);
            this.tbServiceHostService.Size = new System.Drawing.Size(926, 398);
            this.tbServiceHostService.TabIndex = 1;
            this.tbServiceHostService.Text = "Service Host - Service";
            this.tbServiceHostService.UseVisualStyleBackColor = true;
            // 
            // pictureBox16
            // 
            this.pictureBox16.Image = global::VendorManager.Properties.Resources.ReferenceUp;
            this.pictureBox16.Location = new System.Drawing.Point(576, 171);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(12, 38);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox16.TabIndex = 96;
            this.pictureBox16.TabStop = false;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Black;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(617, 367);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(14, 15);
            this.label29.TabIndex = 95;
            this.label29.Text = "8";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Black;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(314, 172);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(14, 15);
            this.label30.TabIndex = 94;
            this.label30.Text = "8";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Gold;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(616, 218);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(20, 24);
            this.label31.TabIndex = 92;
            this.label31.Text = "7";
            this.ttMain.SetToolTip(this.label31, resources.GetString("label31.ToolTip"));
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Gold;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(318, 23);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(20, 24);
            this.label32.TabIndex = 91;
            this.label32.Text = "5";
            this.ttMain.SetToolTip(this.label32, "Facade currently uses Factory to create concret Facade.\r\nThe factory receives imp" +
        "lementation of the ServiceClient\r\nto complete the Concret Facade creation.\r\n");
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.LimeGreen;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(879, 19);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(20, 24);
            this.label33.TabIndex = 90;
            this.label33.Text = "8";
            // 
            // llServiceClass
            // 
            this.llServiceClass.AutoSize = true;
            this.llServiceClass.Location = new System.Drawing.Point(344, 309);
            this.llServiceClass.Name = "llServiceClass";
            this.llServiceClass.Size = new System.Drawing.Size(71, 13);
            this.llServiceClass.TabIndex = 77;
            this.llServiceClass.TabStop = true;
            this.llServiceClass.Text = "Service Class";
            // 
            // llServiceHandleContract
            // 
            this.llServiceHandleContract.AutoSize = true;
            this.llServiceHandleContract.Location = new System.Drawing.Point(344, 273);
            this.llServiceHandleContract.Name = "llServiceHandleContract";
            this.llServiceHandleContract.Size = new System.Drawing.Size(84, 13);
            this.llServiceHandleContract.TabIndex = 76;
            this.llServiceHandleContract.TabStop = true;
            this.llServiceHandleContract.Text = "Handle Contract";
            // 
            // dfsServiceMethodName
            // 
            this.dfsServiceMethodName.Location = new System.Drawing.Point(345, 344);
            this.dfsServiceMethodName.Name = "dfsServiceMethodName";
            this.dfsServiceMethodName.Size = new System.Drawing.Size(271, 20);
            this.dfsServiceMethodName.TabIndex = 75;
            // 
            // lblServiceHostService
            // 
            this.lblServiceHostService.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceHostService.Location = new System.Drawing.Point(328, 242);
            this.lblServiceHostService.Name = "lblServiceHostService";
            this.lblServiceHostService.Size = new System.Drawing.Size(303, 20);
            this.lblServiceHostService.TabIndex = 74;
            this.lblServiceHostService.Text = "$/MML.Services.ProductNameService.csproj";
            // 
            // llServiceVMResponse
            // 
            this.llServiceVMResponse.AutoSize = true;
            this.llServiceVMResponse.Location = new System.Drawing.Point(602, 123);
            this.llServiceVMResponse.Name = "llServiceVMResponse";
            this.llServiceVMResponse.Size = new System.Drawing.Size(74, 13);
            this.llServiceVMResponse.TabIndex = 72;
            this.llServiceVMResponse.TabStop = true;
            this.llServiceVMResponse.Text = "VM Response";
            // 
            // llServiceVMRequest
            // 
            this.llServiceVMRequest.AutoSize = true;
            this.llServiceVMRequest.Location = new System.Drawing.Point(602, 78);
            this.llServiceVMRequest.Name = "llServiceVMRequest";
            this.llServiceVMRequest.Size = new System.Drawing.Size(66, 13);
            this.llServiceVMRequest.TabIndex = 71;
            this.llServiceVMRequest.TabStop = true;
            this.llServiceVMRequest.Text = "VM Request";
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(590, 42);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(296, 28);
            this.label34.TabIndex = 70;
            this.label34.Text = "$/Packages/iMP.Common/Trunk.126/iMP.Contracts";
            // 
            // llServiceFacadeClass
            // 
            this.llServiceFacadeClass.AutoSize = true;
            this.llServiceFacadeClass.Location = new System.Drawing.Point(41, 114);
            this.llServiceFacadeClass.Name = "llServiceFacadeClass";
            this.llServiceFacadeClass.Size = new System.Drawing.Size(71, 13);
            this.llServiceFacadeClass.TabIndex = 68;
            this.llServiceFacadeClass.TabStop = true;
            this.llServiceFacadeClass.Text = "Facade Class";
            // 
            // llServiceFacadeInterface
            // 
            this.llServiceFacadeInterface.AutoSize = true;
            this.llServiceFacadeInterface.Location = new System.Drawing.Point(41, 78);
            this.llServiceFacadeInterface.Name = "llServiceFacadeInterface";
            this.llServiceFacadeInterface.Size = new System.Drawing.Size(88, 13);
            this.llServiceFacadeInterface.TabIndex = 67;
            this.llServiceFacadeInterface.TabStop = true;
            this.llServiceFacadeInterface.Text = "Facade Interface";
            // 
            // dfsServiceFacadeMethod
            // 
            this.dfsServiceFacadeMethod.Location = new System.Drawing.Point(42, 149);
            this.dfsServiceFacadeMethod.Name = "dfsServiceFacadeMethod";
            this.dfsServiceFacadeMethod.Size = new System.Drawing.Size(271, 20);
            this.dfsServiceFacadeMethod.TabIndex = 66;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(25, 47);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(303, 20);
            this.label35.TabIndex = 65;
            this.label35.Text = "$/MML.Services.Facade/MML.Web.Facade.csproj";
            // 
            // pictureBox15
            // 
            this.pictureBox15.Image = global::VendorManager.Properties.Resources.Reference3Right;
            this.pictureBox15.Location = new System.Drawing.Point(356, 56);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(214, 14);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox15.TabIndex = 93;
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::VendorManager.Properties.Resources.EmptyUML;
            this.pictureBox9.Location = new System.Drawing.Point(311, 211);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(343, 184);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 73;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::VendorManager.Properties.Resources.ContractUML;
            this.pictureBox8.Location = new System.Drawing.Point(571, 16);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(341, 153);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 69;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::VendorManager.Properties.Resources.EmptyUML;
            this.pictureBox7.Location = new System.Drawing.Point(8, 16);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(343, 184);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 64;
            this.pictureBox7.TabStop = false;
            // 
            // tbTest
            // 
            this.tbTest.Controls.Add(this.ltnBearer);
            this.tbTest.Controls.Add(this.dfsResponse);
            this.tbTest.Controls.Add(this.llTest);
            this.tbTest.Controls.Add(this.dfsTestParameters);
            this.tbTest.ImageKey = "test-tube.png";
            this.tbTest.Location = new System.Drawing.Point(4, 23);
            this.tbTest.Name = "tbTest";
            this.tbTest.Padding = new System.Windows.Forms.Padding(3);
            this.tbTest.Size = new System.Drawing.Size(926, 398);
            this.tbTest.TabIndex = 2;
            this.tbTest.Text = "Test";
            this.tbTest.UseVisualStyleBackColor = true;
            // 
            // ltnBearer
            // 
            this.ltnBearer.AutoSize = true;
            this.ltnBearer.Location = new System.Drawing.Point(880, 276);
            this.ltnBearer.Name = "ltnBearer";
            this.ltnBearer.Size = new System.Drawing.Size(38, 13);
            this.ltnBearer.TabIndex = 65;
            this.ltnBearer.TabStop = true;
            this.ltnBearer.Text = "Bearer";
            // 
            // dfsResponse
            // 
            this.dfsResponse.Location = new System.Drawing.Point(6, 264);
            this.dfsResponse.Multiline = true;
            this.dfsResponse.Name = "dfsResponse";
            this.dfsResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dfsResponse.Size = new System.Drawing.Size(862, 128);
            this.dfsResponse.TabIndex = 64;
            this.dfsResponse.Text = resources.GetString("dfsResponse.Text");
            // 
            // llTest
            // 
            this.llTest.AutoSize = true;
            this.llTest.Location = new System.Drawing.Point(878, 245);
            this.llTest.Name = "llTest";
            this.llTest.Size = new System.Drawing.Size(32, 13);
            this.llTest.TabIndex = 61;
            this.llTest.TabStop = true;
            this.llTest.Text = "Send";
            // 
            // dfsTestParameters
            // 
            this.dfsTestParameters.Location = new System.Drawing.Point(5, 6);
            this.dfsTestParameters.MaxLength = 1000000;
            this.dfsTestParameters.Multiline = true;
            this.dfsTestParameters.Name = "dfsTestParameters";
            this.dfsTestParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dfsTestParameters.Size = new System.Drawing.Size(862, 252);
            this.dfsTestParameters.TabIndex = 62;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "MicroService.png");
            this.imageList2.Images.SetKeyName(1, "Service.png");
            this.imageList2.Images.SetKeyName(2, "test-tube.png");
            // 
            // llCanonicInterfaceClass
            // 
            this.llCanonicInterfaceClass.AutoSize = true;
            this.llCanonicInterfaceClass.Location = new System.Drawing.Point(364, 179);
            this.llCanonicInterfaceClass.Name = "llCanonicInterfaceClass";
            this.llCanonicInterfaceClass.Size = new System.Drawing.Size(113, 13);
            this.llCanonicInterfaceClass.TabIndex = 94;
            this.llCanonicInterfaceClass.TabStop = true;
            this.llCanonicInterfaceClass.Text = "CanonicInterfaceClass";
            // 
            // llLoanCenterModelRequest
            // 
            this.llLoanCenterModelRequest.AutoSize = true;
            this.llLoanCenterModelRequest.Location = new System.Drawing.Point(364, 56);
            this.llLoanCenterModelRequest.Name = "llLoanCenterModelRequest";
            this.llLoanCenterModelRequest.Size = new System.Drawing.Size(99, 13);
            this.llLoanCenterModelRequest.TabIndex = 93;
            this.llLoanCenterModelRequest.TabStop = true;
            this.llLoanCenterModelRequest.Text = "ViewModelRequest";
            // 
            // llLoanCenterModelResponse
            // 
            this.llLoanCenterModelResponse.AutoSize = true;
            this.llLoanCenterModelResponse.Location = new System.Drawing.Point(364, 87);
            this.llLoanCenterModelResponse.Name = "llLoanCenterModelResponse";
            this.llLoanCenterModelResponse.Size = new System.Drawing.Size(107, 13);
            this.llLoanCenterModelResponse.TabIndex = 92;
            this.llLoanCenterModelResponse.TabStop = true;
            this.llLoanCenterModelResponse.Text = "ViewModelResponse";
            // 
            // llCanonicClass
            // 
            this.llCanonicClass.AutoSize = true;
            this.llCanonicClass.Location = new System.Drawing.Point(661, 114);
            this.llCanonicClass.Name = "llCanonicClass";
            this.llCanonicClass.Size = new System.Drawing.Size(71, 13);
            this.llCanonicClass.TabIndex = 95;
            this.llCanonicClass.TabStop = true;
            this.llCanonicClass.Text = "CanonicClass";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.Black;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.White;
            this.label49.Location = new System.Drawing.Point(840, 206);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(14, 15);
            this.label49.TabIndex = 88;
            this.label49.Text = "4";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.Gold;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(898, 50);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(20, 24);
            this.label50.TabIndex = 79;
            this.label50.Text = "3";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.BackColor = System.Drawing.Color.Black;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.White;
            this.label51.Location = new System.Drawing.Point(821, 206);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(14, 15);
            this.label51.TabIndex = 87;
            this.label51.Text = "2";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.BackColor = System.Drawing.Color.Black;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.White;
            this.label52.Location = new System.Drawing.Point(859, 206);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(14, 15);
            this.label52.TabIndex = 84;
            this.label52.Text = "5";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.BackColor = System.Drawing.Color.Black;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.Color.White;
            this.label53.Location = new System.Drawing.Point(661, 181);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(14, 15);
            this.label53.TabIndex = 86;
            this.label53.Text = "2";
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.LightBlue;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(563, 130);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(20, 24);
            this.label54.TabIndex = 80;
            this.label54.Text = "4";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.BackColor = System.Drawing.Color.Black;
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.Color.White;
            this.label57.Location = new System.Drawing.Point(878, 206);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(14, 15);
            this.label57.TabIndex = 83;
            this.label57.Text = "6";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.Black;
            this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.White;
            this.label58.Location = new System.Drawing.Point(894, 181);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(14, 15);
            this.label58.TabIndex = 85;
            this.label58.Text = "2";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.BackColor = System.Drawing.Color.Black;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.ForeColor = System.Drawing.Color.White;
            this.label59.Location = new System.Drawing.Point(897, 206);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(14, 15);
            this.label59.TabIndex = 82;
            this.label59.Text = "8";
            // 
            // dfsCanonicInterfaceMethod
            // 
            this.dfsCanonicInterfaceMethod.Location = new System.Drawing.Point(362, 228);
            this.dfsCanonicInterfaceMethod.Name = "dfsCanonicInterfaceMethod";
            this.dfsCanonicInterfaceMethod.Size = new System.Drawing.Size(205, 20);
            this.dfsCanonicInterfaceMethod.TabIndex = 77;
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.LimeGreen;
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.Location = new System.Drawing.Point(559, 12);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(20, 24);
            this.label60.TabIndex = 81;
            this.label60.Text = "2";
            // 
            // dfsCanonicMethod
            // 
            this.dfsCanonicMethod.Location = new System.Drawing.Point(681, 178);
            this.dfsCanonicMethod.Name = "dfsCanonicMethod";
            this.dfsCanonicMethod.Size = new System.Drawing.Size(207, 20);
            this.dfsCanonicMethod.TabIndex = 78;
            // 
            // dfcProjects
            // 
            this.dfcProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dfcProjects.FormattingEnabled = true;
            this.dfcProjects.Location = new System.Drawing.Point(659, 12);
            this.dfcProjects.Name = "dfcProjects";
            this.dfcProjects.Size = new System.Drawing.Size(220, 21);
            this.dfcProjects.TabIndex = 75;
            // 
            // llMeAndMyLoan2
            // 
            this.llMeAndMyLoan2.AutoSize = true;
            this.llMeAndMyLoan2.Location = new System.Drawing.Point(26, 12);
            this.llMeAndMyLoan2.Name = "llMeAndMyLoan2";
            this.llMeAndMyLoan2.Size = new System.Drawing.Size(194, 13);
            this.llMeAndMyLoan2.TabIndex = 73;
            this.llMeAndMyLoan2.TabStop = true;
            this.llMeAndMyLoan2.Text = "Select Solution File (MeAndMyLoan.sln)";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.BackColor = System.Drawing.Color.Black;
            this.label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.Color.White;
            this.label61.Location = new System.Drawing.Point(238, 202);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(14, 15);
            this.label61.TabIndex = 69;
            this.label61.Text = "2";
            // 
            // llServiceFacadeInstaller
            // 
            this.llServiceFacadeInstaller.AutoSize = true;
            this.llServiceFacadeInstaller.Location = new System.Drawing.Point(45, 193);
            this.llServiceFacadeInstaller.Name = "llServiceFacadeInstaller";
            this.llServiceFacadeInstaller.Size = new System.Drawing.Size(134, 13);
            this.llServiceFacadeInstaller.TabIndex = 65;
            this.llServiceFacadeInstaller.TabStop = true;
            this.llServiceFacadeInstaller.Text = "ServicesFacadeInstaller.cs";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.BackColor = System.Drawing.Color.Black;
            this.label62.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.ForeColor = System.Drawing.Color.White;
            this.label62.Location = new System.Drawing.Point(258, 202);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(14, 15);
            this.label62.TabIndex = 68;
            this.label62.Text = "3";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.BackColor = System.Drawing.Color.Black;
            this.label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.ForeColor = System.Drawing.Color.White;
            this.label63.Location = new System.Drawing.Point(257, 142);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(14, 15);
            this.label63.TabIndex = 71;
            this.label63.Text = "2";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.BackColor = System.Drawing.Color.Black;
            this.label64.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.ForeColor = System.Drawing.Color.White;
            this.label64.Location = new System.Drawing.Point(278, 202);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(14, 15);
            this.label64.TabIndex = 67;
            this.label64.Text = "4";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.BackColor = System.Drawing.Color.Black;
            this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.Color.White;
            this.label65.Location = new System.Drawing.Point(45, 142);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(14, 15);
            this.label65.TabIndex = 70;
            this.label65.Text = "2";
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.Color.Gold;
            this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(271, 34);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(20, 24);
            this.label66.TabIndex = 66;
            this.label66.Text = "1";
            // 
            // dfsControllerMethod
            // 
            this.dfsControllerMethod.Location = new System.Drawing.Point(65, 139);
            this.dfsControllerMethod.Name = "dfsControllerMethod";
            this.dfsControllerMethod.Size = new System.Drawing.Size(186, 20);
            this.dfsControllerMethod.TabIndex = 63;
            // 
            // llServiceInstaller
            // 
            this.llServiceInstaller.AutoSize = true;
            this.llServiceInstaller.Location = new System.Drawing.Point(45, 178);
            this.llServiceInstaller.Name = "llServiceInstaller";
            this.llServiceInstaller.Size = new System.Drawing.Size(98, 13);
            this.llServiceInstaller.TabIndex = 64;
            this.llServiceInstaller.TabStop = true;
            this.llServiceInstaller.Text = "ServicesInstaller.cs";
            // 
            // llControllerClass
            // 
            this.llControllerClass.AutoSize = true;
            this.llControllerClass.Location = new System.Drawing.Point(45, 87);
            this.llControllerClass.Name = "llControllerClass";
            this.llControllerClass.Size = new System.Drawing.Size(76, 13);
            this.llControllerClass.TabIndex = 62;
            this.llControllerClass.TabStop = true;
            this.llControllerClass.Text = "ControllerClass";
            // 
            // btnGetEncompass
            // 
            this.btnGetEncompass.Location = new System.Drawing.Point(152, 67);
            this.btnGetEncompass.Name = "btnGetEncompass";
            this.btnGetEncompass.Size = new System.Drawing.Size(113, 23);
            this.btnGetEncompass.TabIndex = 26;
            this.btnGetEncompass.Text = "Get Encompass";
            this.btnGetEncompass.UseVisualStyleBackColor = true;
            this.btnGetEncompass.Click += new System.EventHandler(this.btnGetEncompass_Click);
            // 
            // dlgMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 850);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "dlgMain";
            this.Text = "iMP Vendor Admin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tbResult.ResumeLayout(false);
            this.tbLog.ResumeLayout(false);
            this.tbSQL.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbSetting.ResumeLayout(false);
            this.gbSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProductSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVendorSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVendor)).EndInit();
            this.gbVendorProduct.ResumeLayout(false);
            this.gbVendorProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.gbProduct.ResumeLayout(false);
            this.gbProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.gbVendor.ResumeLayout(false);
            this.gbVendor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbService.ResumeLayout(false);
            this.gbService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.grbSQLExecuter.ResumeLayout(false);
            this.grbSQLExecuter.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.sbMain.ResumeLayout(false);
            this.sbMain.PerformLayout();
            this.tbLogTabs.ResumeLayout(false);
            this.tbErrors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdErrors)).EndInit();
            this.tbWarning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWarningLogs)).EndInit();
            this.tbOther.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOtherLogs)).EndInit();
            this.tbProbable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProb)).EndInit();
            this.tbAuditLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAuditLog)).EndInit();
            this.tbIntegrationServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdIntegrationLog)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            this.tbBackend.ResumeLayout(false);
            this.tbMicroService.ResumeLayout(false);
            this.tbMicroService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.tbServiceHostService.ResumeLayout(false);
            this.tbServiceHostService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.tbTest.ResumeLayout(false);
            this.tbTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView tvServices;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox dfsLog;
        private System.Windows.Forms.ImageList ilMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsServiceCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsVendorCount;
        private System.Windows.Forms.ToolStripStatusLabel tsProductImage;
        private System.Windows.Forms.ToolStripStatusLabel tsProductcount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox dfsServiceName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dfsServiceDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox dfsVendorSchema;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox dfsVendorCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox dfsVendorDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox dfsVendorName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dfsProductCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox dfsProductDescription;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox dfsProductName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox gbProduct;
        private System.Windows.Forms.GroupBox gbVendor;
        private System.Windows.Forms.GroupBox gbService;
        private System.Windows.Forms.ComboBox dfcDatabase;
        private System.Windows.Forms.GroupBox gbVendorProduct;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox dfsVendorProductFQN;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox dfsVendorProductSimulatorUrl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.PictureBox picVendorSetting;
        private System.Windows.Forms.PictureBox picVendor;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox dfsSettingName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox dfsSettingCode;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox dfsSettingDefaultValue;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox dfsSettingDataEntryType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox dfsSettingDescription;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox dfsSettingRestriction;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsVendorProducts;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tsVendorSettings;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel tsProductSettings;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox dfsSettingObjectValue;
        private System.Windows.Forms.PictureBox picProductSetting;
        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.TabControl tbResult;
        private System.Windows.Forms.TabPage tbLog;
        private System.Windows.Forms.TabPage tbSQL;
        private System.Windows.Forms.RichTextBox dfsSQL;
        private System.Windows.Forms.ToolStripSplitButton tsOrphans;
        private System.Windows.Forms.ToolStripMenuItem tsOrphanService;
        private System.Windows.Forms.ToolStripMenuItem tsOrphanProducts;
        private System.Windows.Forms.ToolStripMenuItem tsOrphanVendors;
        private System.Windows.Forms.ToolStripMenuItem tsOrphanSettingType;
        private System.Windows.Forms.ToolStripStatusLabel tsLocalHostPath;
        private System.Windows.Forms.ToolStripStatusLabel tsLocalDB;
        private System.Windows.Forms.ToolStripStatusLabel tsLog4net;
        private System.Windows.Forms.ToolStripStatusLabel tsEncompassVersions;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuUMLDiagram;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.CheckBox dffDistinct;
        private System.Windows.Forms.LinkLabel llMeAndMyLoan;
        private System.Windows.Forms.Button btnReadLogi;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox dfsFilter;
        private System.Windows.Forms.TextBox dfsLoanId;
        private System.Windows.Forms.CheckBox dffLast20Minutes;
        private System.Windows.Forms.StatusStrip sbMain;
        private System.Windows.Forms.ToolStripStatusLabel tsMessage;
        private System.Windows.Forms.TabControl tbLogTabs;
        private System.Windows.Forms.TabPage tbErrors;
        private System.Windows.Forms.DataGridView grdErrors;
        private System.Windows.Forms.TabPage tbWarning;
        private System.Windows.Forms.DataGridView grdWarningLogs;
        private System.Windows.Forms.TabPage tbOther;
        private System.Windows.Forms.DataGridView grdOtherLogs;
        private System.Windows.Forms.TabPage tbProbable;
        private System.Windows.Forms.DataGridView grdProb;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.BindingSource logDataBindingSource;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TabPage tbAuditLog;
        private System.Windows.Forms.DataGridView grdAuditLog;
        private System.Windows.Forms.TabPage tbIntegrationServices;
        private System.Windows.Forms.DataGridView grdIntegrationLog;
        private System.Windows.Forms.GroupBox grbSQLExecuter;
        private System.Windows.Forms.TextBox dfsSQLScript;
        private System.Windows.Forms.Button btnRunSQL;
        private System.Windows.Forms.ComboBox dfcSQLScripts;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox dfsPBI;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PictureBox picRest;
        private System.Windows.Forms.PictureBox pictureBox17;
        private System.Windows.Forms.PictureBox pictureBox18;
        private System.Windows.Forms.PictureBox pictureBox19;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.TabControl tbBackend;
        private System.Windows.Forms.TabPage tbMicroService;
        private System.Windows.Forms.PictureBox pictureBox21;
        private System.Windows.Forms.PictureBox pictureBox22;
        private System.Windows.Forms.PictureBox pictureBox23;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.LinkLabel llPingService;
        private System.Windows.Forms.LinkLabel llPortExcelSheet;
        private System.Windows.Forms.TextBox dfstcpPort;
        private System.Windows.Forms.TextBox dfsHttpPort;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox dfsFQN;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.LinkLabel llMSHostConfig;
        private System.Windows.Forms.LinkLabel llMSServiceHost;
        private System.Windows.Forms.LinkLabel llMSHelperClass;
        private System.Windows.Forms.LinkLabel llMSServiceClass;
        private System.Windows.Forms.LinkLabel llMSServiceInterface;
        private System.Windows.Forms.Label lblMicroServiceService;
        private System.Windows.Forms.PictureBox pictureBox24;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox dfsVendorTypeEnum;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox dfsProductTypeEnum;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnAddmicroserviceInstaller;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox dfsMSFacadeMethod;
        private System.Windows.Forms.LinkLabel llMSFacadeFactoryClass;
        private System.Windows.Forms.LinkLabel llMSFacadeClass;
        private System.Windows.Forms.Label lblMicroServiceFacade;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.LinkLabel llMSProxyClient;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label lblMicroServiceProxy;
        private System.Windows.Forms.LinkLabel llMSProxyInterface;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.LinkLabel llMSContractResponse;
        private System.Windows.Forms.LinkLabel llMSContractRequest;
        private System.Windows.Forms.Label lblMicroserviceContracts;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.LinkLabel btnHowToInstallMicroService;
        private System.Windows.Forms.LinkLabel btnHowToMicroService;
        private System.Windows.Forms.TabPage tbServiceHostService;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.LinkLabel llServiceClass;
        private System.Windows.Forms.LinkLabel llServiceHandleContract;
        private System.Windows.Forms.TextBox dfsServiceMethodName;
        private System.Windows.Forms.Label lblServiceHostService;
        private System.Windows.Forms.LinkLabel llServiceVMResponse;
        private System.Windows.Forms.LinkLabel llServiceVMRequest;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.LinkLabel llServiceFacadeClass;
        private System.Windows.Forms.LinkLabel llServiceFacadeInterface;
        private System.Windows.Forms.TextBox dfsServiceFacadeMethod;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.TabPage tbTest;
        private System.Windows.Forms.LinkLabel ltnBearer;
        private System.Windows.Forms.TextBox dfsResponse;
        private System.Windows.Forms.LinkLabel llTest;
        private System.Windows.Forms.TextBox dfsTestParameters;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.LinkLabel llCanonicInterfaceClass;
        private System.Windows.Forms.LinkLabel llLoanCenterModelRequest;
        private System.Windows.Forms.LinkLabel llLoanCenterModelResponse;
        private System.Windows.Forms.LinkLabel llCanonicClass;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox dfsCanonicInterfaceMethod;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.TextBox dfsCanonicMethod;
        private System.Windows.Forms.ComboBox dfcProjects;
        private System.Windows.Forms.LinkLabel llMeAndMyLoan2;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.LinkLabel llServiceFacadeInstaller;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox dfsControllerMethod;
        private System.Windows.Forms.LinkLabel llServiceInstaller;
        private System.Windows.Forms.LinkLabel llControllerClass;
        private System.Windows.Forms.Button btnGetEncompass;
    }
}

