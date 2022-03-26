namespace sampleApp
{
    partial class TrainingRecordViewer
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
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.headerLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.viewByLbl = new System.Windows.Forms.Label();
            this.viewBySelectorBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.searchLbl = new System.Windows.Forms.Label();
            this.trainingSearchBox = new System.Windows.Forms.ComboBox();
            this.trainingSearchBtn = new System.Windows.Forms.Button();
            this.loadRecordsBtn = new System.Windows.Forms.Button();
            this.recordsDGV = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.viewLbl = new System.Windows.Forms.Label();
            this.viewTypeSelectorBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.employeeLbl = new System.Windows.Forms.Label();
            this.employeeSelectorBox = new PresentationControls.CheckBoxComboBox();
            this.clearEmployeesBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.deptLbl = new System.Windows.Forms.Label();
            this.deptSelectorBox = new System.Windows.Forms.ComboBox();
            this.helpLink1 = new sampleApp.CustomControls.HelpLink.HelpLink();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordsDGV)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.Controls.Add(this.headerLbl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.recordsDGV, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.helpLink1, 1, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1141, 507);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // headerLbl
            // 
            this.headerLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.headerLbl.AutoSize = true;
            this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLbl.Location = new System.Drawing.Point(8, 3);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(215, 29);
            this.headerLbl.TabIndex = 0;
            this.headerLbl.Text = "Training Records";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.viewByLbl);
            this.flowLayoutPanel1.Controls.Add(this.viewBySelectorBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 48);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(439, 34);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // viewByLbl
            // 
            this.viewByLbl.AutoSize = true;
            this.viewByLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewByLbl.Location = new System.Drawing.Point(3, 5);
            this.viewByLbl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.viewByLbl.Name = "viewByLbl";
            this.viewByLbl.Size = new System.Drawing.Size(91, 24);
            this.viewByLbl.TabIndex = 0;
            this.viewByLbl.Text = "View By:";
            // 
            // viewBySelectorBox
            // 
            this.viewBySelectorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.viewBySelectorBox.FormattingEnabled = true;
            this.viewBySelectorBox.Items.AddRange(new object[] {
            "Department",
            "Employee"});
            this.viewBySelectorBox.Location = new System.Drawing.Point(100, 7);
            this.viewBySelectorBox.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.viewBySelectorBox.Name = "viewBySelectorBox";
            this.viewBySelectorBox.Size = new System.Drawing.Size(213, 21);
            this.viewBySelectorBox.TabIndex = 1;
            this.viewBySelectorBox.SelectedIndexChanged += new System.EventHandler(this.viewBySelectorBox_SelectedIndexChanged);
            // 
            // flowLayoutPanel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel3, 2);
            this.flowLayoutPanel3.Controls.Add(this.searchLbl);
            this.flowLayoutPanel3.Controls.Add(this.trainingSearchBox);
            this.flowLayoutPanel3.Controls.Add(this.trainingSearchBtn);
            this.flowLayoutPanel3.Controls.Add(this.loadRecordsBtn);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(8, 135);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1124, 45);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // searchLbl
            // 
            this.searchLbl.AutoSize = true;
            this.searchLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLbl.Location = new System.Drawing.Point(3, 10);
            this.searchLbl.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.searchLbl.Name = "searchLbl";
            this.searchLbl.Size = new System.Drawing.Size(158, 24);
            this.searchLbl.TabIndex = 0;
            this.searchLbl.Text = "Search Trainings:";
            this.searchLbl.Visible = false;
            // 
            // trainingSearchBox
            // 
            this.trainingSearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.trainingSearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.trainingSearchBox.FormattingEnabled = true;
            this.trainingSearchBox.Location = new System.Drawing.Point(167, 12);
            this.trainingSearchBox.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.trainingSearchBox.Name = "trainingSearchBox";
            this.trainingSearchBox.Size = new System.Drawing.Size(360, 21);
            this.trainingSearchBox.TabIndex = 3;
            this.trainingSearchBox.Visible = false;
            // 
            // trainingSearchBtn
            // 
            this.trainingSearchBtn.Location = new System.Drawing.Point(533, 11);
            this.trainingSearchBtn.Margin = new System.Windows.Forms.Padding(3, 11, 3, 3);
            this.trainingSearchBtn.Name = "trainingSearchBtn";
            this.trainingSearchBtn.Size = new System.Drawing.Size(75, 23);
            this.trainingSearchBtn.TabIndex = 4;
            this.trainingSearchBtn.Text = "Search";
            this.trainingSearchBtn.UseVisualStyleBackColor = true;
            this.trainingSearchBtn.Visible = false;
            // 
            // loadRecordsBtn
            // 
            this.loadRecordsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadRecordsBtn.Location = new System.Drawing.Point(676, 6);
            this.loadRecordsBtn.Margin = new System.Windows.Forms.Padding(65, 6, 0, 3);
            this.loadRecordsBtn.Name = "loadRecordsBtn";
            this.loadRecordsBtn.Size = new System.Drawing.Size(202, 32);
            this.loadRecordsBtn.TabIndex = 4;
            this.loadRecordsBtn.Text = "Load Records";
            this.loadRecordsBtn.UseVisualStyleBackColor = true;
            this.loadRecordsBtn.Click += new System.EventHandler(this.loadRecordsBtn_Click);
            // 
            // recordsDGV
            // 
            this.recordsDGV.AllowUserToAddRows = false;
            this.recordsDGV.AllowUserToDeleteRows = false;
            this.recordsDGV.AllowUserToResizeColumns = false;
            this.recordsDGV.AllowUserToResizeRows = false;
            this.recordsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.recordsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.recordsDGV, 2);
            this.recordsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordsDGV.Location = new System.Drawing.Point(8, 188);
            this.recordsDGV.Name = "recordsDGV";
            this.recordsDGV.ReadOnly = true;
            this.recordsDGV.RowHeadersVisible = false;
            this.recordsDGV.Size = new System.Drawing.Size(1124, 281);
            this.recordsDGV.TabIndex = 4;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.viewLbl);
            this.flowLayoutPanel4.Controls.Add(this.viewTypeSelectorBox);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(573, 48);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(439, 34);
            this.flowLayoutPanel4.TabIndex = 5;
            // 
            // viewLbl
            // 
            this.viewLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.viewLbl.AutoSize = true;
            this.viewLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLbl.Location = new System.Drawing.Point(3, 6);
            this.viewLbl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.viewLbl.Name = "viewLbl";
            this.viewLbl.Size = new System.Drawing.Size(62, 24);
            this.viewLbl.TabIndex = 0;
            this.viewLbl.Text = "View:";
            // 
            // viewTypeSelectorBox
            // 
            this.viewTypeSelectorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.viewTypeSelectorBox.FormattingEnabled = true;
            this.viewTypeSelectorBox.Items.AddRange(new object[] {
            "Past Due Trainings",
            "Upcoming Trainings",
            "Completed Trainings"});
            this.viewTypeSelectorBox.Location = new System.Drawing.Point(71, 7);
            this.viewTypeSelectorBox.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.viewTypeSelectorBox.Name = "viewTypeSelectorBox";
            this.viewTypeSelectorBox.Size = new System.Drawing.Size(220, 21);
            this.viewTypeSelectorBox.TabIndex = 1;
            this.viewTypeSelectorBox.SelectedIndexChanged += new System.EventHandler(this.viewTypeSelectorBox_SelectedIndexChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.employeeLbl);
            this.flowLayoutPanel2.Controls.Add(this.employeeSelectorBox);
            this.flowLayoutPanel2.Controls.Add(this.clearEmployeesBtn);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(573, 98);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(559, 34);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // employeeLbl
            // 
            this.employeeLbl.AutoSize = true;
            this.employeeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeLbl.Location = new System.Drawing.Point(3, 5);
            this.employeeLbl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.employeeLbl.Name = "employeeLbl";
            this.employeeLbl.Size = new System.Drawing.Size(134, 24);
            this.employeeLbl.TabIndex = 1;
            this.employeeLbl.Text = "Employee(s):";
            // 
            // employeeSelectorBox
            // 
            this.employeeSelectorBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.employeeSelectorBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.employeeSelectorBox.CheckBoxProperties = checkBoxProperties1;
            this.employeeSelectorBox.DisplayMemberSingleItem = "";
            this.employeeSelectorBox.FormattingEnabled = true;
            this.employeeSelectorBox.Location = new System.Drawing.Point(143, 7);
            this.employeeSelectorBox.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.employeeSelectorBox.Name = "employeeSelectorBox";
            this.employeeSelectorBox.Size = new System.Drawing.Size(236, 21);
            this.employeeSelectorBox.TabIndex = 4;
            this.employeeSelectorBox.SelectedValueChanged += new System.EventHandler(this.employeeSelectorBox_SelectedValueChanged);
            this.employeeSelectorBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.employeeSelectorBox_KeyDown);
            this.employeeSelectorBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.employeeSelectorBox_KeyPress);
            // 
            // clearEmployeesBtn
            // 
            this.clearEmployeesBtn.Location = new System.Drawing.Point(385, 6);
            this.clearEmployeesBtn.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.clearEmployeesBtn.Name = "clearEmployeesBtn";
            this.clearEmployeesBtn.Size = new System.Drawing.Size(138, 23);
            this.clearEmployeesBtn.TabIndex = 5;
            this.clearEmployeesBtn.Text = "Clear Employee Selection";
            this.clearEmployeesBtn.UseVisualStyleBackColor = true;
            this.clearEmployeesBtn.Click += new System.EventHandler(this.clearEmployeesBtn_Click);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.deptLbl);
            this.flowLayoutPanel5.Controls.Add(this.deptSelectorBox);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(8, 98);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(559, 34);
            this.flowLayoutPanel5.TabIndex = 6;
            // 
            // deptLbl
            // 
            this.deptLbl.AutoSize = true;
            this.deptLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptLbl.Location = new System.Drawing.Point(3, 5);
            this.deptLbl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.deptLbl.Name = "deptLbl";
            this.deptLbl.Size = new System.Drawing.Size(123, 24);
            this.deptLbl.TabIndex = 2;
            this.deptLbl.Text = "Department:";
            // 
            // deptSelectorBox
            // 
            this.deptSelectorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deptSelectorBox.FormattingEnabled = true;
            this.deptSelectorBox.Location = new System.Drawing.Point(132, 7);
            this.deptSelectorBox.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.deptSelectorBox.Name = "deptSelectorBox";
            this.deptSelectorBox.Size = new System.Drawing.Size(220, 21);
            this.deptSelectorBox.TabIndex = 3;
            this.deptSelectorBox.SelectedIndexChanged += new System.EventHandler(this.deptSelectorBox_SelectedIndexChanged);
            // 
            // helpLink1
            // 
            this.helpLink1.AutoSize = true;
            this.helpLink1.Location = new System.Drawing.Point(8, 480);
            this.helpLink1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.helpLink1.Name = "helpLink1";
            this.helpLink1.Size = new System.Drawing.Size(29, 13);
            this.helpLink1.TabIndex = 7;
            this.helpLink1.TabStop = true;
            this.helpLink1.Text = "Help";
            // 
            // TrainingRecordViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 507);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TrainingRecordViewer";
            this.Text = "TrainingRecordViewer";
            this.Shown += new System.EventHandler(this.TrainingRecordViewer_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordsDGV)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label headerLbl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label viewByLbl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label employeeLbl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label searchLbl;
        private System.Windows.Forms.DataGridView recordsDGV;
        private System.Windows.Forms.ComboBox viewBySelectorBox;
        private System.Windows.Forms.ComboBox trainingSearchBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label viewLbl;
        private System.Windows.Forms.ComboBox viewTypeSelectorBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label deptLbl;
        private System.Windows.Forms.ComboBox deptSelectorBox;
        private System.Windows.Forms.Button trainingSearchBtn;
        private PresentationControls.CheckBoxComboBox employeeSelectorBox;
        private System.Windows.Forms.Button loadRecordsBtn;
        private System.Windows.Forms.Button clearEmployeesBtn;
        private CustomControls.HelpLink.HelpLink helpLink1;
    }
}