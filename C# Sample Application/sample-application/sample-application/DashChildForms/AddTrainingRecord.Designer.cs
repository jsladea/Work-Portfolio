namespace sampleApp
{
    partial class AddTrainingRecord
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.selectedTrainingsListBox = new System.Windows.Forms.CheckedListBox();
            this.headerLbl = new System.Windows.Forms.Label();
            this.selectTrainingTypeLbl = new System.Windows.Forms.Label();
            this.searchTrainingLbl = new System.Windows.Forms.Label();
            this.selectedEmployeesListBox = new System.Windows.Forms.CheckedListBox();
            this.employeeSearchBox = new System.Windows.Forms.TextBox();
            this.selectEmployeeLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.removeTrainingBtn = new System.Windows.Forms.Button();
            this.addTrainingBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.removeEmployeeBtn = new System.Windows.Forms.Button();
            this.addEmployeeBtn = new System.Windows.Forms.Button();
            this.selectTrainingLbl = new System.Windows.Forms.Label();
            this.addRecordBtn = new System.Windows.Forms.Button();
            this.compDateLbl = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.instructionsLbl = new System.Windows.Forms.Label();
            this.searchEmployeeLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.attachFileBtn = new System.Windows.Forms.Button();
            this.filenameBox = new System.Windows.Forms.TextBox();
            this.printBtn = new System.Windows.Forms.Button();
            this.addRecordLbl = new System.Windows.Forms.Label();
            this.trainingSelectorBox = new System.Windows.Forms.ComboBox();
            this.trainingTypeSelectorBox = new System.Windows.Forms.ComboBox();
            this.trainerLbl = new System.Windows.Forms.Label();
            this.trainerSearchBox = new System.Windows.Forms.TextBox();
            this.openTrainingRecordDialog = new System.Windows.Forms.OpenFileDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpLink1 = new sampleApp.CustomControls.HelpLink.HelpLink();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.selectedTrainingsListBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.headerLbl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.selectTrainingTypeLbl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.searchTrainingLbl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.selectedEmployeesListBox, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.employeeSearchBox, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.selectEmployeeLbl, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.selectTrainingLbl, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.addRecordBtn, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.compDateLbl, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.instructionsLbl, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.searchEmployeeLbl, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.printBtn, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.addRecordLbl, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.trainingSelectorBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.trainingTypeSelectorBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.trainerLbl, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.trainerSearchBox, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.helpLink1, 0, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(940, 560);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // selectedTrainingsListBox
            // 
            this.selectedTrainingsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedTrainingsListBox.FormattingEnabled = true;
            this.selectedTrainingsListBox.Location = new System.Drawing.Point(203, 148);
            this.selectedTrainingsListBox.Name = "selectedTrainingsListBox";
            this.tableLayoutPanel1.SetRowSpan(this.selectedTrainingsListBox, 2);
            this.selectedTrainingsListBox.Size = new System.Drawing.Size(294, 259);
            this.selectedTrainingsListBox.TabIndex = 14;
            this.selectedTrainingsListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.selectedTrainingsListBox_ItemCheck);
            // 
            // headerLbl
            // 
            this.headerLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.headerLbl.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.headerLbl, 4);
            this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLbl.Location = new System.Drawing.Point(3, 8);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(255, 29);
            this.headerLbl.TabIndex = 0;
            this.headerLbl.Text = "Add Training Record";
            // 
            // selectTrainingTypeLbl
            // 
            this.selectTrainingTypeLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.selectTrainingTypeLbl.AutoSize = true;
            this.selectTrainingTypeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectTrainingTypeLbl.Location = new System.Drawing.Point(3, 47);
            this.selectTrainingTypeLbl.Name = "selectTrainingTypeLbl";
            this.selectTrainingTypeLbl.Size = new System.Drawing.Size(156, 20);
            this.selectTrainingTypeLbl.TabIndex = 1;
            this.selectTrainingTypeLbl.Text = "Select Training Type:";
            // 
            // searchTrainingLbl
            // 
            this.searchTrainingLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.searchTrainingLbl.AutoSize = true;
            this.searchTrainingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTrainingLbl.Location = new System.Drawing.Point(3, 100);
            this.searchTrainingLbl.Name = "searchTrainingLbl";
            this.searchTrainingLbl.Size = new System.Drawing.Size(132, 20);
            this.searchTrainingLbl.TabIndex = 9;
            this.searchTrainingLbl.Text = "Search Trainings:";
            // 
            // selectedEmployeesListBox
            // 
            this.selectedEmployeesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedEmployeesListBox.FormattingEnabled = true;
            this.selectedEmployeesListBox.Location = new System.Drawing.Point(753, 148);
            this.selectedEmployeesListBox.Name = "selectedEmployeesListBox";
            this.tableLayoutPanel1.SetRowSpan(this.selectedEmployeesListBox, 2);
            this.selectedEmployeesListBox.Size = new System.Drawing.Size(344, 259);
            this.selectedEmployeesListBox.TabIndex = 12;
            this.selectedEmployeesListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.selectedEmployeesListBox_ItemCheck);
            // 
            // employeeSearchBox
            // 
            this.employeeSearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.employeeSearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.employeeSearchBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.employeeSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeSearchBox.Location = new System.Drawing.Point(753, 98);
            this.employeeSearchBox.Margin = new System.Windows.Forms.Padding(3, 23, 3, 3);
            this.employeeSearchBox.Name = "employeeSearchBox";
            this.employeeSearchBox.Size = new System.Drawing.Size(344, 24);
            this.employeeSearchBox.TabIndex = 5;
            // 
            // selectEmployeeLbl
            // 
            this.selectEmployeeLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.selectEmployeeLbl.AutoSize = true;
            this.selectEmployeeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectEmployeeLbl.Location = new System.Drawing.Point(576, 157);
            this.selectEmployeeLbl.Name = "selectEmployeeLbl";
            this.selectEmployeeLbl.Size = new System.Drawing.Size(168, 20);
            this.selectEmployeeLbl.TabIndex = 3;
            this.selectEmployeeLbl.Text = "Selected Employee(s):";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.removeTrainingBtn);
            this.panel1.Controls.Add(this.addTrainingBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(500, 75);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(70, 70);
            this.panel1.TabIndex = 15;
            // 
            // removeTrainingBtn
            // 
            this.removeTrainingBtn.Location = new System.Drawing.Point(0, 47);
            this.removeTrainingBtn.Name = "removeTrainingBtn";
            this.removeTrainingBtn.Size = new System.Drawing.Size(75, 23);
            this.removeTrainingBtn.TabIndex = 11;
            this.removeTrainingBtn.Text = "Remove";
            this.removeTrainingBtn.UseVisualStyleBackColor = true;
            this.removeTrainingBtn.Click += new System.EventHandler(this.removeTrainingBtn_Click);
            // 
            // addTrainingBtn
            // 
            this.addTrainingBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addTrainingBtn.Location = new System.Drawing.Point(0, 22);
            this.addTrainingBtn.Name = "addTrainingBtn";
            this.addTrainingBtn.Size = new System.Drawing.Size(49, 23);
            this.addTrainingBtn.TabIndex = 10;
            this.addTrainingBtn.Text = "Add";
            this.addTrainingBtn.UseVisualStyleBackColor = true;
            this.addTrainingBtn.Click += new System.EventHandler(this.addTrainingBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.removeEmployeeBtn);
            this.panel2.Controls.Add(this.addEmployeeBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1100, 75);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(70, 70);
            this.panel2.TabIndex = 16;
            // 
            // removeEmployeeBtn
            // 
            this.removeEmployeeBtn.Location = new System.Drawing.Point(0, 47);
            this.removeEmployeeBtn.Name = "removeEmployeeBtn";
            this.removeEmployeeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeEmployeeBtn.TabIndex = 17;
            this.removeEmployeeBtn.Text = "Remove";
            this.removeEmployeeBtn.UseVisualStyleBackColor = true;
            this.removeEmployeeBtn.Click += new System.EventHandler(this.removeEmployeeBtn_Click);
            // 
            // addEmployeeBtn
            // 
            this.addEmployeeBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addEmployeeBtn.Location = new System.Drawing.Point(0, 22);
            this.addEmployeeBtn.Name = "addEmployeeBtn";
            this.addEmployeeBtn.Size = new System.Drawing.Size(44, 23);
            this.addEmployeeBtn.TabIndex = 11;
            this.addEmployeeBtn.Text = "Add";
            this.addEmployeeBtn.UseVisualStyleBackColor = true;
            this.addEmployeeBtn.Click += new System.EventHandler(this.addEmployeeBtn_Click);
            // 
            // selectTrainingLbl
            // 
            this.selectTrainingLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.selectTrainingLbl.AutoSize = true;
            this.selectTrainingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectTrainingLbl.Location = new System.Drawing.Point(3, 157);
            this.selectTrainingLbl.Name = "selectTrainingLbl";
            this.selectTrainingLbl.Size = new System.Drawing.Size(154, 20);
            this.selectTrainingLbl.TabIndex = 13;
            this.selectTrainingLbl.Text = "Selected Training(s):";
            // 
            // addRecordBtn
            // 
            this.addRecordBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addRecordBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.addRecordBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addRecordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addRecordBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRecordBtn.Location = new System.Drawing.Point(3, 503);
            this.addRecordBtn.Name = "addRecordBtn";
            this.addRecordBtn.Size = new System.Drawing.Size(194, 28);
            this.addRecordBtn.TabIndex = 17;
            this.addRecordBtn.Text = "Add Record";
            this.addRecordBtn.UseVisualStyleBackColor = false;
            this.addRecordBtn.Click += new System.EventHandler(this.addRecordBtn_Click);
            // 
            // compDateLbl
            // 
            this.compDateLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.compDateLbl.AutoSize = true;
            this.compDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compDateLbl.Location = new System.Drawing.Point(3, 437);
            this.compDateLbl.Name = "compDateLbl";
            this.compDateLbl.Size = new System.Drawing.Size(129, 20);
            this.compDateLbl.TabIndex = 18;
            this.compDateLbl.Text = "Date Completed:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker.Location = new System.Drawing.Point(203, 433);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(294, 20);
            this.dateTimePicker.TabIndex = 19;
            // 
            // instructionsLbl
            // 
            this.instructionsLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.instructionsLbl.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.instructionsLbl, 4);
            this.instructionsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsLbl.Location = new System.Drawing.Point(503, 50);
            this.instructionsLbl.Name = "instructionsLbl";
            this.instructionsLbl.Size = new System.Drawing.Size(520, 15);
            this.instructionsLbl.TabIndex = 20;
            this.instructionsLbl.Text = "To remove an employee or training, uncheck the box or use the search box and remo" +
    "ve button.";
            // 
            // searchEmployeeLbl
            // 
            this.searchEmployeeLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchEmployeeLbl.AutoSize = true;
            this.searchEmployeeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchEmployeeLbl.Location = new System.Drawing.Point(587, 100);
            this.searchEmployeeLbl.Name = "searchEmployeeLbl";
            this.searchEmployeeLbl.Size = new System.Drawing.Size(146, 20);
            this.searchEmployeeLbl.TabIndex = 6;
            this.searchEmployeeLbl.Text = "Search Employees:";
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 3);
            this.flowLayoutPanel1.Controls.Add(this.attachFileBtn);
            this.flowLayoutPanel1.Controls.Add(this.filenameBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(573, 468);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(594, 29);
            this.flowLayoutPanel1.TabIndex = 25;
            this.flowLayoutPanel1.Resize += new System.EventHandler(this.flowLayoutPanel1_Resize);
            // 
            // attachFileBtn
            // 
            this.attachFileBtn.Location = new System.Drawing.Point(3, 3);
            this.attachFileBtn.Name = "attachFileBtn";
            this.attachFileBtn.Size = new System.Drawing.Size(75, 25);
            this.attachFileBtn.TabIndex = 23;
            this.attachFileBtn.Text = "Attach File";
            this.attachFileBtn.UseVisualStyleBackColor = true;
            this.attachFileBtn.Click += new System.EventHandler(this.attachFileBtn_Click);
            // 
            // filenameBox
            // 
            this.filenameBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filenameBox.Location = new System.Drawing.Point(84, 5);
            this.filenameBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.filenameBox.Name = "filenameBox";
            this.filenameBox.ReadOnly = true;
            this.filenameBox.Size = new System.Drawing.Size(318, 20);
            this.filenameBox.TabIndex = 24;
            // 
            // printBtn
            // 
            this.printBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.printBtn, 3);
            this.printBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtn.Location = new System.Drawing.Point(573, 434);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(415, 26);
            this.printBtn.TabIndex = 26;
            this.printBtn.Text = "Print Training Record Form To Sign and Attach";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // addRecordLbl
            // 
            this.addRecordLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addRecordLbl.AutoSize = true;
            this.addRecordLbl.Location = new System.Drawing.Point(203, 504);
            this.addRecordLbl.Name = "addRecordLbl";
            this.addRecordLbl.Size = new System.Drawing.Size(269, 26);
            this.addRecordLbl.TabIndex = 27;
            this.addRecordLbl.Text = "Attached record will be saved in EFileCabinet Trainings Cabinet in the Directory:" +
    " employee/year/month";
            // 
            // trainingSelectorBox
            // 
            this.trainingSelectorBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trainingSelectorBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.trainingSelectorBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.trainingSelectorBox.FormattingEnabled = true;
            this.trainingSelectorBox.Location = new System.Drawing.Point(203, 99);
            this.trainingSelectorBox.Name = "trainingSelectorBox";
            this.trainingSelectorBox.Size = new System.Drawing.Size(294, 21);
            this.trainingSelectorBox.TabIndex = 28;
            // 
            // trainingTypeSelectorBox
            // 
            this.trainingTypeSelectorBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trainingTypeSelectorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trainingTypeSelectorBox.FormattingEnabled = true;
            this.trainingTypeSelectorBox.Items.AddRange(new object[] {
            "Individual",
            "Group"});
            this.trainingTypeSelectorBox.Location = new System.Drawing.Point(203, 47);
            this.trainingTypeSelectorBox.Name = "trainingTypeSelectorBox";
            this.trainingTypeSelectorBox.Size = new System.Drawing.Size(181, 21);
            this.trainingTypeSelectorBox.TabIndex = 29;
            this.trainingTypeSelectorBox.SelectedIndexChanged += new System.EventHandler(this.trainingTypeSelectorBox_SelectedIndexChanged);
            // 
            // trainerLbl
            // 
            this.trainerLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trainerLbl.AutoSize = true;
            this.trainerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainerLbl.Location = new System.Drawing.Point(3, 472);
            this.trainerLbl.Name = "trainerLbl";
            this.trainerLbl.Size = new System.Drawing.Size(62, 20);
            this.trainerLbl.TabIndex = 30;
            this.trainerLbl.Text = "Trainer:";
            // 
            // trainerSearchBox
            // 
            this.trainerSearchBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trainerSearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.trainerSearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.trainerSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainerSearchBox.Location = new System.Drawing.Point(203, 470);
            this.trainerSearchBox.Name = "trainerSearchBox";
            this.trainerSearchBox.Size = new System.Drawing.Size(269, 24);
            this.trainerSearchBox.TabIndex = 31;
            // 
            // openTrainingRecordDialog
            // 
            this.openTrainingRecordDialog.FileName = "openFileDialog1";
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // helpLink1
            // 
            this.helpLink1.AutoSize = true;
            this.helpLink1.Location = new System.Drawing.Point(3, 538);
            this.helpLink1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.helpLink1.Name = "helpLink1";
            this.helpLink1.Size = new System.Drawing.Size(29, 13);
            this.helpLink1.TabIndex = 32;
            this.helpLink1.TabStop = true;
            this.helpLink1.Text = "Help";
            // 
            // AddTrainingRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 560);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddTrainingRecord";
            this.Text = "AddTrainingRecord";
            this.Load += new System.EventHandler(this.AddTrainingRecord_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckedListBox selectedTrainingsListBox;
        private System.Windows.Forms.Label headerLbl;
        private System.Windows.Forms.Label selectTrainingTypeLbl;
        private System.Windows.Forms.Label searchTrainingLbl;
        private System.Windows.Forms.Button addTrainingBtn;
        private System.Windows.Forms.Label searchEmployeeLbl;
        private System.Windows.Forms.CheckedListBox selectedEmployeesListBox;
        private System.Windows.Forms.TextBox employeeSearchBox;
        private System.Windows.Forms.Button addEmployeeBtn;
        private System.Windows.Forms.Label selectEmployeeLbl;
        private System.Windows.Forms.Label selectTrainingLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button removeTrainingBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button removeEmployeeBtn;
        private System.Windows.Forms.Button addRecordBtn;
        private System.Windows.Forms.Label compDateLbl;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label instructionsLbl;
        private System.Windows.Forms.Button attachFileBtn;
        private System.Windows.Forms.OpenFileDialog openTrainingRecordDialog;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox filenameBox;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.Label addRecordLbl;
        private System.Windows.Forms.ComboBox trainingSelectorBox;
        private System.Windows.Forms.ComboBox trainingTypeSelectorBox;
        private System.Windows.Forms.Label trainerLbl;
        private System.Windows.Forms.TextBox trainerSearchBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private CustomControls.HelpLink.HelpLink helpLink1;
    }
}