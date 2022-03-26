namespace sampleApp
{
    partial class DepartmentView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentView));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.outerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.deptLbl = new System.Windows.Forms.Label();
            this.deptSelectorBox = new System.Windows.Forms.ComboBox();
            this.exportBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.deptDGV = new System.Windows.Forms.DataGridView();
            this.deptEmpDGV = new System.Windows.Forms.DataGridView();
            this.requiredTrainingsLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.instructionsIcon = new System.Windows.Forms.PictureBox();
            this.instructionsLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.helpLink1 = new sampleApp.CustomControls.HelpLink.HelpLink();
            this.outerLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deptDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptEmpDGV)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instructionsIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // outerLayoutPanel
            // 
            this.outerLayoutPanel.ColumnCount = 3;
            this.outerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.outerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.outerLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 4);
            this.outerLayoutPanel.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.outerLayoutPanel.Controls.Add(this.headerLbl, 1, 0);
            this.outerLayoutPanel.Controls.Add(this.helpLink1, 1, 5);
            this.outerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outerLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.outerLayoutPanel.Name = "outerLayoutPanel";
            this.outerLayoutPanel.RowCount = 6;
            this.outerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.outerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.outerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.outerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.outerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.outerLayoutPanel.Size = new System.Drawing.Size(1208, 557);
            this.outerLayoutPanel.TabIndex = 0;
            // 
            // headerLbl
            // 
            this.headerLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.headerLbl.AutoSize = true;
            this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLbl.Location = new System.Drawing.Point(8, 3);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(264, 29);
            this.headerLbl.TabIndex = 1;
            this.headerLbl.Text = "Department Overview";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.deptLbl);
            this.flowLayoutPanel1.Controls.Add(this.deptSelectorBox);
            this.flowLayoutPanel1.Controls.Add(this.exportBtn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 45);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(688, 35);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // deptLbl
            // 
            this.deptLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.deptLbl.AutoSize = true;
            this.deptLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptLbl.Location = new System.Drawing.Point(3, 9);
            this.deptLbl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.deptLbl.Name = "deptLbl";
            this.deptLbl.Size = new System.Drawing.Size(109, 20);
            this.deptLbl.TabIndex = 0;
            this.deptLbl.Text = "Department:";
            // 
            // deptSelectorBox
            // 
            this.deptSelectorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deptSelectorBox.FormattingEnabled = true;
            this.deptSelectorBox.Location = new System.Drawing.Point(117, 8);
            this.deptSelectorBox.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this.deptSelectorBox.Name = "deptSelectorBox";
            this.deptSelectorBox.Size = new System.Drawing.Size(211, 21);
            this.deptSelectorBox.TabIndex = 1;
            this.deptSelectorBox.SelectedIndexChanged += new System.EventHandler(this.deptSelectorBox_SelectedIndexChanged);
            // 
            // exportBtn
            // 
            this.exportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtn.Location = new System.Drawing.Point(332, 2);
            this.exportBtn.Margin = new System.Windows.Forms.Padding(2);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(137, 30);
            this.exportBtn.TabIndex = 9;
            this.exportBtn.Text = "Export To Excel";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 384F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Controls.Add(this.deptDGV, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.deptEmpDGV, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.requiredTrainingsLbl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 93);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 700F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 800F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1192, 441);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // deptDGV
            // 
            this.deptDGV.AllowUserToAddRows = false;
            this.deptDGV.AllowUserToDeleteRows = false;
            this.deptDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.deptDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.deptDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.deptDGV, 5);
            this.deptDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deptDGV.Location = new System.Drawing.Point(8, 808);
            this.deptDGV.Name = "deptDGV";
            this.deptDGV.ReadOnly = true;
            this.deptDGV.RowHeadersVisible = false;
            this.deptDGV.RowHeadersWidth = 51;
            this.deptDGV.Size = new System.Drawing.Size(1159, 794);
            this.deptDGV.TabIndex = 11;
            // 
            // deptEmpDGV
            // 
            this.deptEmpDGV.AllowUserToAddRows = false;
            this.deptEmpDGV.AllowUserToDeleteRows = false;
            this.deptEmpDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.deptEmpDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.deptEmpDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.deptEmpDGV, 5);
            this.deptEmpDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deptEmpDGV.Location = new System.Drawing.Point(8, 43);
            this.deptEmpDGV.Name = "deptEmpDGV";
            this.deptEmpDGV.ReadOnly = true;
            this.deptEmpDGV.RowHeadersVisible = false;
            this.deptEmpDGV.RowHeadersWidth = 51;
            this.deptEmpDGV.Size = new System.Drawing.Size(1159, 694);
            this.deptEmpDGV.TabIndex = 5;
            this.deptEmpDGV.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.deptDGV_CellDoubleClick);
            // 
            // requiredTrainingsLbl
            // 
            this.requiredTrainingsLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.requiredTrainingsLbl.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.requiredTrainingsLbl, 3);
            this.requiredTrainingsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requiredTrainingsLbl.Location = new System.Drawing.Point(8, 10);
            this.requiredTrainingsLbl.Name = "requiredTrainingsLbl";
            this.requiredTrainingsLbl.Size = new System.Drawing.Size(356, 20);
            this.requiredTrainingsLbl.TabIndex = 7;
            this.requiredTrainingsLbl.Text = "Required Trainings Assigned To Employees";
            // 
            // flowLayoutPanel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel3, 2);
            this.flowLayoutPanel3.Controls.Add(this.instructionsIcon);
            this.flowLayoutPanel3.Controls.Add(this.instructionsLbl);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(374, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(454, 33);
            this.flowLayoutPanel3.TabIndex = 8;
            // 
            // instructionsIcon
            // 
            this.instructionsIcon.Image = ((System.Drawing.Image)(resources.GetObject("instructionsIcon.Image")));
            this.instructionsIcon.Location = new System.Drawing.Point(3, 3);
            this.instructionsIcon.Name = "instructionsIcon";
            this.instructionsIcon.Size = new System.Drawing.Size(35, 31);
            this.instructionsIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.instructionsIcon.TabIndex = 0;
            this.instructionsIcon.TabStop = false;
            // 
            // instructionsLbl
            // 
            this.instructionsLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.instructionsLbl.AutoSize = true;
            this.instructionsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsLbl.Location = new System.Drawing.Point(44, 9);
            this.instructionsLbl.Name = "instructionsLbl";
            this.instructionsLbl.Size = new System.Drawing.Size(351, 18);
            this.instructionsLbl.TabIndex = 8;
            this.instructionsLbl.Text = "Double click row for in-depth view of specific training";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 3);
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 775);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Trainings Assigned To Department";
            // 
            // helpLink1
            // 
            this.helpLink1.AutoSize = true;
            this.helpLink1.Location = new System.Drawing.Point(8, 540);
            this.helpLink1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.helpLink1.Name = "helpLink1";
            this.helpLink1.Size = new System.Drawing.Size(29, 13);
            this.helpLink1.TabIndex = 4;
            this.helpLink1.TabStop = true;
            this.helpLink1.Text = "Help";
            // 
            // DepartmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 557);
            this.Controls.Add(this.outerLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DepartmentView";
            this.Text = "DepartmentView";
            this.outerLayoutPanel.ResumeLayout(false);
            this.outerLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deptDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptEmpDGV)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instructionsIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TableLayoutPanel outerLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label deptLbl;
        private System.Windows.Forms.ComboBox deptSelectorBox;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Label headerLbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView deptDGV;
        private System.Windows.Forms.DataGridView deptEmpDGV;
        private System.Windows.Forms.Label requiredTrainingsLbl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.PictureBox instructionsIcon;
        private System.Windows.Forms.Label instructionsLbl;
        private System.Windows.Forms.Label label3;
        private CustomControls.HelpLink.HelpLink helpLink1;
    }
}