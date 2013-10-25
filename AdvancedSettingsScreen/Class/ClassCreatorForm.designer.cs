namespace AdvancedSettingsScreen
{
    partial class ClassCreatorForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbClassName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblCopy = new DevComponents.DotNetBar.LabelX();
            this.cmbNames = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbItemDefault = new DevComponents.Editors.ComboItem();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.errorNameDuplicate = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorGradeYear = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorNameDuplicate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorGradeYear)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbClassName
            // 
            this.cmbClassName.DisplayMember = "Text";
            this.cmbClassName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClassName.FormattingEnabled = true;
            this.cmbClassName.ItemHeight = 19;
            this.cmbClassName.Location = new System.Drawing.Point(98, 12);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Size = new System.Drawing.Size(187, 25);
            this.cmbClassName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbClassName.TabIndex = 3;
            // 
            // lblCopy
            // 
            this.lblCopy.AutoSize = true;
            this.lblCopy.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblCopy.BackgroundStyle.Class = "";
            this.lblCopy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCopy.Location = new System.Drawing.Point(22, 45);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(74, 21);
            this.lblCopy.TabIndex = 0;
            this.lblCopy.Text = "複製班級：";
            // 
            // cmbNames
            // 
            this.cmbNames.DisplayMember = "Text";
            this.cmbNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNames.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbNames.FormattingEnabled = true;
            this.cmbNames.Items.AddRange(new object[] {
            this.cmbItemDefault});
            this.cmbNames.Location = new System.Drawing.Point(97, 43);
            this.cmbNames.Name = "cmbNames";
            this.cmbNames.Size = new System.Drawing.Size(187, 25);
            this.cmbNames.TabIndex = 1;
            // 
            // cmbItemDefault
            // 
            this.cmbItemDefault.Text = "不進行複製";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(219, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(138, 86);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "儲存";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblName.BackgroundStyle.Class = "";
            this.lblName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblName.Location = new System.Drawing.Point(21, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(74, 21);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "班級名稱：";
            // 
            // errorNameDuplicate
            // 
            this.errorNameDuplicate.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorNameDuplicate.ContainerControl = this;
            // 
            // errorGradeYear
            // 
            this.errorGradeYear.ContainerControl = this;
            // 
            // ClassCreatorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(306, 124);
            this.Controls.Add(this.cmbClassName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCopy);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbNames);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ClassCreatorForm";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.errorNameDuplicate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorGradeYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.LabelX lblCopy;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbNames;
        private DevComponents.Editors.ComboItem cmbItemDefault;
        private System.Windows.Forms.ErrorProvider errorNameDuplicate;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbClassName;
        private System.Windows.Forms.ErrorProvider errorGradeYear;
    }
}