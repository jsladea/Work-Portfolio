namespace sampleApp
{
    partial class UnassignTraining
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
            this.headerLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.selectTrainingLbl = new System.Windows.Forms.Label();
            this.trainingSelectorBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.unassignByLbl = new System.Windows.Forms.Label();
            this.unassignBySelectorBox = new System.Windows.Forms.ComboBox();
            this.unassignSelectLbl = new System.Windows.Forms.Label();
            this.unassignSelectorBox = new System.Windows.Forms.ComboBox();
            this.unassignBtn = new System.Windows.Forms.Button();
            this.helpLink1 = new sampleApp.CustomControls.HelpLink.HelpLink();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1000F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.headerLbl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.unassignBtn, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.helpLink1, 0, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1149, 542);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // headerLbl
            // 
            this.headerLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.headerLbl.AutoSize = true;
            this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLbl.Location = new System.Drawing.Point(3, 8);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(225, 29);
            this.headerLbl.TabIndex = 0;
            this.headerLbl.Text = "Unassign Training";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.selectTrainingLbl);
            this.flowLayoutPanel1.Controls.Add(this.trainingSelectorBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 68);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(994, 34);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // selectTrainingLbl
            // 
            this.selectTrainingLbl.AutoSize = true;
            this.selectTrainingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectTrainingLbl.Location = new System.Drawing.Point(3, 4);
            this.selectTrainingLbl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.selectTrainingLbl.Name = "selectTrainingLbl";
            this.selectTrainingLbl.Size = new System.Drawing.Size(157, 24);
            this.selectTrainingLbl.TabIndex = 0;
            this.selectTrainingLbl.Text = "Select Training:";
            // 
            // trainingSelectorBox
            // 
            this.trainingSelectorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trainingSelectorBox.FormattingEnabled = true;
            this.trainingSelectorBox.Location = new System.Drawing.Point(166, 7);
            this.trainingSelectorBox.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.trainingSelectorBox.Name = "trainingSelectorBox";
            this.trainingSelectorBox.Size = new System.Drawing.Size(309, 21);
            this.trainingSelectorBox.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.unassignByLbl);
            this.flowLayoutPanel2.Controls.Add(this.unassignBySelectorBox);
            this.flowLayoutPanel2.Controls.Add(this.unassignSelectLbl);
            this.flowLayoutPanel2.Controls.Add(this.unassignSelectorBox);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 118);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(994, 34);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // unassignByLbl
            // 
            this.unassignByLbl.AutoSize = true;
            this.unassignByLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unassignByLbl.Location = new System.Drawing.Point(3, 4);
            this.unassignByLbl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.unassignByLbl.Name = "unassignByLbl";
            this.unassignByLbl.Size = new System.Drawing.Size(131, 24);
            this.unassignByLbl.TabIndex = 3;
            this.unassignByLbl.Text = "Unassign By:";
            // 
            // unassignBySelectorBox
            // 
            this.unassignBySelectorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unassignBySelectorBox.FormattingEnabled = true;
            this.unassignBySelectorBox.Items.AddRange(new object[] {
            "Employee",
            "Department"});
            this.unassignBySelectorBox.Location = new System.Drawing.Point(140, 7);
            this.unassignBySelectorBox.Margin = new System.Windows.Forms.Padding(3, 7, 30, 3);
            this.unassignBySelectorBox.Name = "unassignBySelectorBox";
            this.unassignBySelectorBox.Size = new System.Drawing.Size(147, 21);
            this.unassignBySelectorBox.TabIndex = 4;
            this.unassignBySelectorBox.SelectedIndexChanged += new System.EventHandler(this.unassignBySelectorBox_SelectedIndexChanged);
            // 
            // unassignSelectLbl
            // 
            this.unassignSelectLbl.AutoSize = true;
            this.unassignSelectLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unassignSelectLbl.Location = new System.Drawing.Point(320, 4);
            this.unassignSelectLbl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.unassignSelectLbl.Name = "unassignSelectLbl";
            this.unassignSelectLbl.Size = new System.Drawing.Size(174, 24);
            this.unassignSelectLbl.TabIndex = 1;
            this.unassignSelectLbl.Text = "Select Employee:";
            // 
            // unassignSelectorBox
            // 
            this.unassignSelectorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unassignSelectorBox.FormattingEnabled = true;
            this.unassignSelectorBox.Location = new System.Drawing.Point(500, 7);
            this.unassignSelectorBox.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.unassignSelectorBox.Name = "unassignSelectorBox";
            this.unassignSelectorBox.Size = new System.Drawing.Size(309, 21);
            this.unassignSelectorBox.TabIndex = 2;
            // 
            // unassignBtn
            // 
            this.unassignBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.unassignBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unassignBtn.Location = new System.Drawing.Point(3, 173);
            this.unassignBtn.Name = "unassignBtn";
            this.unassignBtn.Size = new System.Drawing.Size(225, 33);
            this.unassignBtn.TabIndex = 3;
            this.unassignBtn.Text = "Unassign Training";
            this.unassignBtn.UseVisualStyleBackColor = true;
            this.unassignBtn.Click += new System.EventHandler(this.unassignBtn_Click);
            // 
            // helpLink1
            // 
            this.helpLink1.AutoSize = true;
            this.helpLink1.Location = new System.Drawing.Point(3, 525);
            this.helpLink1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.helpLink1.Name = "helpLink1";
            this.helpLink1.Size = new System.Drawing.Size(29, 13);
            this.helpLink1.TabIndex = 4;
            this.helpLink1.TabStop = true;
            this.helpLink1.Text = "Help";
            // 
            // UnassignTraining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 542);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UnassignTraining";
            this.Text = "UnassignTraining";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label headerLbl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label selectTrainingLbl;
        private System.Windows.Forms.ComboBox trainingSelectorBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label unassignSelectLbl;
        private System.Windows.Forms.ComboBox unassignSelectorBox;
        private System.Windows.Forms.Button unassignBtn;
        private System.Windows.Forms.Label unassignByLbl;
        private System.Windows.Forms.ComboBox unassignBySelectorBox;
        private CustomControls.HelpLink.HelpLink helpLink1;
    }
}