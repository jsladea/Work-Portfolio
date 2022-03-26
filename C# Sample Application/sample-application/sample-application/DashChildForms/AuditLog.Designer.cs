namespace sampleApp
{
    partial class AuditLog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.logDGV = new System.Windows.Forms.DataGridView();
            this.headerLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.startDateLbl = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.exportBtn = new System.Windows.Forms.Button();
            this.selectActionLbl = new System.Windows.Forms.Label();
            this.actionSelectorBox = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.endDateLbl = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.searchBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logDGV)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.Controls.Add(this.logDGV, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.headerLbl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1888, 725);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // logDGV
            // 
            this.logDGV.AllowUserToAddRows = false;
            this.logDGV.AllowUserToDeleteRows = false;
            this.logDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.logDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logDGV.Location = new System.Drawing.Point(3, 158);
            this.logDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logDGV.Name = "logDGV";
            this.logDGV.RowHeadersVisible = false;
            this.logDGV.RowTemplate.Height = 24;
            this.logDGV.Size = new System.Drawing.Size(1871, 555);
            this.logDGV.TabIndex = 0;
            // 
            // headerLbl
            // 
            this.headerLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.headerLbl.AutoSize = true;
            this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLbl.Location = new System.Drawing.Point(3, 7);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(297, 36);
            this.headerLbl.TabIndex = 1;
            this.headerLbl.Text = "Modification History";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.selectActionLbl);
            this.flowLayoutPanel1.Controls.Add(this.actionSelectorBox);
            this.flowLayoutPanel1.Controls.Add(this.exportBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 102);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1871, 42);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // startDateLbl
            // 
            this.startDateLbl.AutoSize = true;
            this.startDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateLbl.Location = new System.Drawing.Point(3, 5);
            this.startDateLbl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.startDateLbl.Name = "startDateLbl";
            this.startDateLbl.Size = new System.Drawing.Size(135, 29);
            this.startDateLbl.TabIndex = 6;
            this.startDateLbl.Text = "Start Date:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(145, 9);
            this.startDatePicker.Margin = new System.Windows.Forms.Padding(4, 9, 4, 4);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(265, 22);
            this.startDatePicker.TabIndex = 5;
            // 
            // exportBtn
            // 
            this.exportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtn.Location = new System.Drawing.Point(517, 5);
            this.exportBtn.Margin = new System.Windows.Forms.Padding(40, 5, 3, 2);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(179, 32);
            this.exportBtn.TabIndex = 2;
            this.exportBtn.Text = "Export to Excel";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // selectActionLbl
            // 
            this.selectActionLbl.AutoSize = true;
            this.selectActionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectActionLbl.Location = new System.Drawing.Point(3, 5);
            this.selectActionLbl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.selectActionLbl.Name = "selectActionLbl";
            this.selectActionLbl.Size = new System.Drawing.Size(194, 29);
            this.selectActionLbl.TabIndex = 0;
            this.selectActionLbl.Text = "Filter by Action:";
            // 
            // actionSelectorBox
            // 
            this.actionSelectorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionSelectorBox.FormattingEnabled = true;
            this.actionSelectorBox.Location = new System.Drawing.Point(203, 7);
            this.actionSelectorBox.Margin = new System.Windows.Forms.Padding(3, 7, 27, 2);
            this.actionSelectorBox.Name = "actionSelectorBox";
            this.actionSelectorBox.Size = new System.Drawing.Size(247, 24);
            this.actionSelectorBox.TabIndex = 1;
            this.actionSelectorBox.SelectedIndexChanged += new System.EventHandler(this.actionSelectorBox_SelectedIndexChanged);
            // 
            // endDateLbl
            // 
            this.endDateLbl.AutoSize = true;
            this.endDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateLbl.Location = new System.Drawing.Point(417, 5);
            this.endDateLbl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.endDateLbl.Name = "endDateLbl";
            this.endDateLbl.Size = new System.Drawing.Size(127, 29);
            this.endDateLbl.TabIndex = 7;
            this.endDateLbl.Text = "End Date:";
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(551, 9);
            this.endDatePicker.Margin = new System.Windows.Forms.Padding(4, 9, 4, 4);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(265, 22);
            this.endDatePicker.TabIndex = 8;
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.Location = new System.Drawing.Point(840, 5);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(20, 5, 20, 2);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(179, 32);
            this.searchBtn.TabIndex = 9;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.startDateLbl);
            this.flowLayoutPanel2.Controls.Add(this.startDatePicker);
            this.flowLayoutPanel2.Controls.Add(this.endDateLbl);
            this.flowLayoutPanel2.Controls.Add(this.endDatePicker);
            this.flowLayoutPanel2.Controls.Add(this.searchBtn);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 53);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1871, 44);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // AuditLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1888, 725);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AuditLog";
            this.Text = "AuditLog";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logDGV)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView logDGV;
        private System.Windows.Forms.Label headerLbl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label selectActionLbl;
        private System.Windows.Forms.ComboBox actionSelectorBox;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label startDateLbl;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label endDateLbl;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Button searchBtn;
    }
}