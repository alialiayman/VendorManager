namespace VendorManager
{
    partial class dlgNewSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgNewSetting));
            this.lblLabel = new System.Windows.Forms.Label();
            this.dfsValue = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.dfcProducts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewSetting = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(12, 19);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(35, 13);
            this.lblLabel.TabIndex = 0;
            this.lblLabel.Text = "Name";
            // 
            // dfsValue
            // 
            this.dfsValue.Location = new System.Drawing.Point(12, 45);
            this.dfsValue.Name = "dfsValue";
            this.dfsValue.Size = new System.Drawing.Size(321, 20);
            this.dfsValue.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(258, 136);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dfcProducts
            // 
            this.dfcProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dfcProducts.FormattingEnabled = true;
            this.dfcProducts.Location = new System.Drawing.Point(12, 99);
            this.dfcProducts.Name = "dfcProducts";
            this.dfcProducts.Size = new System.Drawing.Size(275, 21);
            this.dfcProducts.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Setting";
            // 
            // btnAddNewSetting
            // 
            this.btnAddNewSetting.Location = new System.Drawing.Point(293, 97);
            this.btnAddNewSetting.Name = "btnAddNewSetting";
            this.btnAddNewSetting.Size = new System.Drawing.Size(40, 23);
            this.btnAddNewSetting.TabIndex = 5;
            this.btnAddNewSetting.Text = "...";
            this.btnAddNewSetting.UseVisualStyleBackColor = true;
            this.btnAddNewSetting.Click += new System.EventHandler(this.btnAddNewProduct_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(177, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dlgNewSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 169);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddNewSetting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dfcProducts);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dfsValue);
            this.Controls.Add(this.lblLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgNewSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.TextBox dfsValue;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox dfcProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNewSetting;
        private System.Windows.Forms.Button btnCancel;
    }
}