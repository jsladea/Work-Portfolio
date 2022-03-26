namespace sampleApp
{
    partial class AssignTraining
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
            this.layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerLbl = new System.Windows.Forms.Label();
            this.completionDateLbl = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.employeePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.employeeSearchLbl = new System.Windows.Forms.Label();
            this.employeeSearchBox = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.employeeSelectionPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.selectedLbl = new System.Windows.Forms.Label();
            this.selectedEmployeesBox = new System.Windows.Forms.CheckedListBox();
            this.assignBtn = new System.Windows.Forms.Button();
            this.assignToLbl = new System.Windows.Forms.Label();
            this.trainingLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.trainingSelectorBox = new System.Windows.Forms.ComboBox();
            this.addTrainingBtn = new System.Windows.Forms.Button();
            this.selectedTrainingsLbl = new System.Windows.Forms.Label();
            this.selectedTrainingsBox = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.assignTypeSelectorBox = new System.Windows.Forms.ComboBox();
            this.assignBox = new PresentationControls.CheckBoxComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.requiredLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.yesCheckBox = new System.Windows.Forms.CheckBox();
            this.noCheckBox = new System.Windows.Forms.CheckBox();
            this.helpLink1 = new sampleApp.CustomControls.HelpLink.HelpLink();
            this.layoutPanel.SuspendLayout();
            this.employeePanel.SuspendLayout();
            this.employeeSelectionPanel.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutPanel
            // 
            this.layoutPanel.ColumnCount = 4;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.Controls.Add(this.headerLbl, 0, 0);
            this.layoutPanel.Controls.Add(this.completionDateLbl, 0, 3);
            this.layoutPanel.Controls.Add(this.dateTimePicker, 1, 3);
            this.layoutPanel.Controls.Add(this.employeePanel, 0, 5);
            this.layoutPanel.Controls.Add(this.employeeSelectionPanel, 2, 5);
            this.layoutPanel.Controls.Add(this.assignBtn, 2, 6);
            this.layoutPanel.Controls.Add(this.assignToLbl, 0, 1);
            this.layoutPanel.Controls.Add(this.trainingLbl, 0, 2);
            this.layoutPanel.Controls.Add(this.flowLayoutPanel3, 1, 2);
            this.layoutPanel.Controls.Add(this.selectedTrainingsLbl, 2, 2);
            this.layoutPanel.Controls.Add(this.selectedTrainingsBox, 2, 3);
            this.layoutPanel.Controls.Add(this.panel1, 1, 4);
            this.layoutPanel.Controls.Add(this.assignTypeSelectorBox, 1, 1);
            this.layoutPanel.Controls.Add(this.assignBox, 2, 1);
            this.layoutPanel.Controls.Add(this.flowLayoutPanel2, 0, 4);
            this.layoutPanel.Controls.Add(this.helpLink1, 0, 6);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.RowCount = 8;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.layoutPanel.Size = new System.Drawing.Size(944, 712);
            this.layoutPanel.TabIndex = 0;
            // 
            // headerLbl
            // 
            this.headerLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.headerLbl.AutoSize = true;
            this.layoutPanel.SetColumnSpan(this.headerLbl, 3);
            this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLbl.Location = new System.Drawing.Point(3, 7);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(188, 25);
            this.headerLbl.TabIndex = 0;
            this.headerLbl.Text = "Assign Trainings";
            this.headerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // completionDateLbl
            // 
            this.completionDateLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.completionDateLbl.AutoSize = true;
            this.completionDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completionDateLbl.Location = new System.Drawing.Point(3, 105);
            this.completionDateLbl.Name = "completionDateLbl";
            this.completionDateLbl.Size = new System.Drawing.Size(103, 20);
            this.completionDateLbl.TabIndex = 6;
            this.completionDateLbl.Text = "Complete By:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Location = new System.Drawing.Point(153, 105);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(194, 20);
            this.dateTimePicker.TabIndex = 7;
            // 
            // employeePanel
            // 
            this.layoutPanel.SetColumnSpan(this.employeePanel, 2);
            this.employeePanel.Controls.Add(this.employeeSearchLbl);
            this.employeePanel.Controls.Add(this.employeeSearchBox);
            this.employeePanel.Controls.Add(this.addBtn);
            this.employeePanel.Controls.Add(this.removeBtn);
            this.employeePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.employeePanel.Location = new System.Drawing.Point(3, 349);
            this.employeePanel.Name = "employeePanel";
            this.employeePanel.Size = new System.Drawing.Size(494, 292);
            this.employeePanel.TabIndex = 13;
            // 
            // employeeSearchLbl
            // 
            this.employeeSearchLbl.AutoSize = true;
            this.employeeSearchLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeSearchLbl.Location = new System.Drawing.Point(3, 0);
            this.employeeSearchLbl.Name = "employeeSearchLbl";
            this.employeeSearchLbl.Size = new System.Drawing.Size(175, 24);
            this.employeeSearchLbl.TabIndex = 0;
            this.employeeSearchLbl.Text = "Search Employees:";
            // 
            // employeeSearchBox
            // 
            this.employeeSearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.employeeSearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.employeeSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeSearchBox.Location = new System.Drawing.Point(3, 27);
            this.employeeSearchBox.Name = "employeeSearchBox";
            this.employeeSearchBox.Size = new System.Drawing.Size(300, 22);
            this.employeeSearchBox.TabIndex = 1;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(3, 55);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(3, 86);
            this.removeBtn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeBtn.TabIndex = 3;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // employeeSelectionPanel
            // 
            this.employeeSelectionPanel.Controls.Add(this.selectedLbl);
            this.employeeSelectionPanel.Controls.Add(this.selectedEmployeesBox);
            this.employeeSelectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeSelectionPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.employeeSelectionPanel.Location = new System.Drawing.Point(503, 349);
            this.employeeSelectionPanel.Name = "employeeSelectionPanel";
            this.employeeSelectionPanel.Size = new System.Drawing.Size(394, 292);
            this.employeeSelectionPanel.TabIndex = 14;
            // 
            // selectedLbl
            // 
            this.selectedLbl.AutoSize = true;
            this.selectedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedLbl.Location = new System.Drawing.Point(3, 0);
            this.selectedLbl.Name = "selectedLbl";
            this.selectedLbl.Size = new System.Drawing.Size(201, 24);
            this.selectedLbl.TabIndex = 0;
            this.selectedLbl.Text = "Selected Employee(s):";
            // 
            // selectedEmployeesBox
            // 
            this.selectedEmployeesBox.FormattingEnabled = true;
            this.selectedEmployeesBox.Location = new System.Drawing.Point(3, 27);
            this.selectedEmployeesBox.Name = "selectedEmployeesBox";
            this.selectedEmployeesBox.Size = new System.Drawing.Size(375, 229);
            this.selectedEmployeesBox.TabIndex = 1;
            this.selectedEmployeesBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.selectedEmployeesBox_ItemCheck);
            // 
            // assignBtn
            // 
            this.assignBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.assignBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignBtn.Location = new System.Drawing.Point(622, 650);
            this.assignBtn.Name = "assignBtn";
            this.assignBtn.Size = new System.Drawing.Size(156, 28);
            this.assignBtn.TabIndex = 8;
            this.assignBtn.Text = "Assign Training";
            this.assignBtn.UseVisualStyleBackColor = true;
            this.assignBtn.Click += new System.EventHandler(this.assignBtn_Click);
            // 
            // assignToLbl
            // 
            this.assignToLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.assignToLbl.AutoSize = true;
            this.assignToLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignToLbl.Location = new System.Drawing.Point(3, 45);
            this.assignToLbl.Name = "assignToLbl";
            this.assignToLbl.Size = new System.Drawing.Size(83, 20);
            this.assignToLbl.TabIndex = 3;
            this.assignToLbl.Text = "Assign To:";
            // 
            // trainingLbl
            // 
            this.trainingLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trainingLbl.AutoSize = true;
            this.trainingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainingLbl.Location = new System.Drawing.Point(3, 75);
            this.trainingLbl.Name = "trainingLbl";
            this.trainingLbl.Size = new System.Drawing.Size(77, 20);
            this.trainingLbl.TabIndex = 1;
            this.trainingLbl.Text = "Trainings:";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.trainingSelectorBox);
            this.flowLayoutPanel3.Controls.Add(this.addTrainingBtn);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(150, 70);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(350, 30);
            this.flowLayoutPanel3.TabIndex = 16;
            // 
            // trainingSelectorBox
            // 
            this.trainingSelectorBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.trainingSelectorBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.trainingSelectorBox.FormattingEnabled = true;
            this.trainingSelectorBox.Location = new System.Drawing.Point(3, 3);
            this.trainingSelectorBox.Name = "trainingSelectorBox";
            this.trainingSelectorBox.Size = new System.Drawing.Size(261, 21);
            this.trainingSelectorBox.TabIndex = 15;
            // 
            // addTrainingBtn
            // 
            this.addTrainingBtn.Location = new System.Drawing.Point(270, 3);
            this.addTrainingBtn.Name = "addTrainingBtn";
            this.addTrainingBtn.Size = new System.Drawing.Size(75, 23);
            this.addTrainingBtn.TabIndex = 16;
            this.addTrainingBtn.Text = "Add";
            this.addTrainingBtn.UseVisualStyleBackColor = true;
            this.addTrainingBtn.Click += new System.EventHandler(this.addTrainingBtn_Click);
            // 
            // selectedTrainingsLbl
            // 
            this.selectedTrainingsLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.selectedTrainingsLbl.AutoSize = true;
            this.selectedTrainingsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedTrainingsLbl.Location = new System.Drawing.Point(503, 75);
            this.selectedTrainingsLbl.Name = "selectedTrainingsLbl";
            this.selectedTrainingsLbl.Size = new System.Drawing.Size(144, 20);
            this.selectedTrainingsLbl.TabIndex = 17;
            this.selectedTrainingsLbl.Text = "Selected Trainings:";
            // 
            // selectedTrainingsBox
            // 
            this.selectedTrainingsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedTrainingsBox.FormattingEnabled = true;
            this.selectedTrainingsBox.Location = new System.Drawing.Point(503, 103);
            this.selectedTrainingsBox.Name = "selectedTrainingsBox";
            this.layoutPanel.SetRowSpan(this.selectedTrainingsBox, 2);
            this.selectedTrainingsBox.Size = new System.Drawing.Size(394, 240);
            this.selectedTrainingsBox.TabIndex = 18;
            this.selectedTrainingsBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.selectedTrainingsBox_ItemCheck);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(153, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 210);
            this.panel1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 140);
            this.label1.TabIndex = 19;
            this.label1.Text = "Instructions: \r\nTo remove trainings or employees: \r\nuncheck the box next to the i" +
    "tem on the list.\r\n\r\nTo assign trainings:\r\n click the assign training button\r\n at" +
    " the bottom of the form.\r\n";
            // 
            // assignTypeSelectorBox
            // 
            this.assignTypeSelectorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.assignTypeSelectorBox.FormattingEnabled = true;
            this.assignTypeSelectorBox.Items.AddRange(new object[] {
            "Employee(s)",
            "Employee(s) by Department",
            "Department"});
            this.assignTypeSelectorBox.Location = new System.Drawing.Point(153, 43);
            this.assignTypeSelectorBox.Name = "assignTypeSelectorBox";
            this.assignTypeSelectorBox.Size = new System.Drawing.Size(261, 21);
            this.assignTypeSelectorBox.TabIndex = 21;
            this.assignTypeSelectorBox.SelectedIndexChanged += new System.EventHandler(this.assignTypeSelectorBox_SelectedIndexChanged);
            // 
            // assignBox
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.assignBox.CheckBoxProperties = checkBoxProperties1;
            this.assignBox.DisplayMemberSingleItem = "";
            this.assignBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.assignBox.FormattingEnabled = true;
            this.assignBox.Location = new System.Drawing.Point(503, 43);
            this.assignBox.Name = "assignBox";
            this.assignBox.Size = new System.Drawing.Size(394, 21);
            this.assignBox.TabIndex = 22;
            this.assignBox.CheckBoxCheckedChanged += new System.EventHandler(this.assignBox_CheckBoxCheckedChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.requiredLbl);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 133);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(144, 210);
            this.flowLayoutPanel2.TabIndex = 23;
            // 
            // requiredLbl
            // 
            this.requiredLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.requiredLbl.AutoSize = true;
            this.requiredLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requiredLbl.Location = new System.Drawing.Point(3, 0);
            this.requiredLbl.Name = "requiredLbl";
            this.requiredLbl.Size = new System.Drawing.Size(134, 29);
            this.requiredLbl.TabIndex = 1;
            this.requiredLbl.Text = "Required?";
            this.requiredLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.yesCheckBox);
            this.flowLayoutPanel4.Controls.Add(this.noCheckBox);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 32);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(134, 60);
            this.flowLayoutPanel4.TabIndex = 2;
            // 
            // yesCheckBox
            // 
            this.yesCheckBox.AutoSize = true;
            this.yesCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.yesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesCheckBox.Location = new System.Drawing.Point(3, 3);
            this.yesCheckBox.Name = "yesCheckBox";
            this.yesCheckBox.Size = new System.Drawing.Size(51, 20);
            this.yesCheckBox.TabIndex = 4;
            this.yesCheckBox.Text = "Yes";
            this.yesCheckBox.UseVisualStyleBackColor = true;
            this.yesCheckBox.CheckStateChanged += new System.EventHandler(this.yesCheckBox_CheckStateChanged);
            // 
            // noCheckBox
            // 
            this.noCheckBox.AutoSize = true;
            this.noCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.noCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noCheckBox.Location = new System.Drawing.Point(77, 3);
            this.noCheckBox.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.noCheckBox.Name = "noCheckBox";
            this.noCheckBox.Size = new System.Drawing.Size(45, 20);
            this.noCheckBox.TabIndex = 3;
            this.noCheckBox.Text = "No";
            this.noCheckBox.UseVisualStyleBackColor = true;
            this.noCheckBox.CheckStateChanged += new System.EventHandler(this.noCheckBox_CheckStateChanged);
            // 
            // helpLink1
            // 
            this.helpLink1.AutoSize = true;
            this.helpLink1.Location = new System.Drawing.Point(3, 647);
            this.helpLink1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.helpLink1.Name = "helpLink1";
            this.helpLink1.Size = new System.Drawing.Size(29, 13);
            this.helpLink1.TabIndex = 24;
            this.helpLink1.TabStop = true;
            this.helpLink1.Text = "Help";
            // 
            // AssignTraining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 712);
            this.Controls.Add(this.layoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AssignTraining";
            this.Text = "AssignRequiredTraining";
            this.Load += new System.EventHandler(this.AssignRequiredTraining_Load);
            this.layoutPanel.ResumeLayout(false);
            this.layoutPanel.PerformLayout();
            this.employeePanel.ResumeLayout(false);
            this.employeePanel.PerformLayout();
            this.employeeSelectionPanel.ResumeLayout(false);
            this.employeeSelectionPanel.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutPanel;
        private System.Windows.Forms.Label headerLbl;
        private System.Windows.Forms.Label trainingLbl;
        private System.Windows.Forms.Label assignToLbl;
        private System.Windows.Forms.Label completionDateLbl;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button assignBtn;
        private System.Windows.Forms.FlowLayoutPanel employeePanel;
        private System.Windows.Forms.FlowLayoutPanel employeeSelectionPanel;
        private System.Windows.Forms.Label selectedLbl;
        private System.Windows.Forms.CheckedListBox selectedEmployeesBox;
        private System.Windows.Forms.Label employeeSearchLbl;
        private System.Windows.Forms.TextBox employeeSearchBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.ComboBox trainingSelectorBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button addTrainingBtn;
        private System.Windows.Forms.Label selectedTrainingsLbl;
        private System.Windows.Forms.CheckedListBox selectedTrainingsBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox assignTypeSelectorBox;
        private PresentationControls.CheckBoxComboBox assignBox;
        private System.Windows.Forms.CheckBox noCheckBox;
        private System.Windows.Forms.Label requiredLbl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.CheckBox yesCheckBox;
        private CustomControls.HelpLink.HelpLink helpLink1;
    }
}