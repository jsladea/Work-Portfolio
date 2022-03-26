
namespace sampleApp
{
    partial class AddEmployee
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
            this.headerLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.loginLbl = new System.Windows.Forms.Label();
            this.userIdBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.firstNameLbl = new System.Windows.Forms.Label();
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.lastNameLbl = new System.Windows.Forms.Label();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.deptLbl = new System.Windows.Forms.Label();
            this.deptBox = new System.Windows.Forms.ComboBox();
            this.jobTitleLbl = new System.Windows.Forms.Label();
            this.jobTitleBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.userRightsLbl = new System.Windows.Forms.Label();
            this.userRightsBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.createBtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpLink1 = new sampleApp.CustomControls.HelpLink.HelpLink();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 750F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.headerLbl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.helpLink1, 0, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(752, 427);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // headerLbl
            // 
            this.headerLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.headerLbl.AutoSize = true;
            this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLbl.Location = new System.Drawing.Point(2, 4);
            this.headerLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(196, 24);
            this.headerLbl.TabIndex = 0;
            this.headerLbl.Text = "Add New Employee";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.loginLbl);
            this.flowLayoutPanel1.Controls.Add(this.userIdBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 42);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(746, 28);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // loginLbl
            // 
            this.loginLbl.AutoSize = true;
            this.loginLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLbl.Location = new System.Drawing.Point(2, 5);
            this.loginLbl.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
            this.loginLbl.Name = "loginLbl";
            this.loginLbl.Size = new System.Drawing.Size(447, 18);
            this.loginLbl.TabIndex = 0;
            this.loginLbl.Text = "Username (use windows login username if they have one):";
            // 
            // userIdBox
            // 
            this.userIdBox.Location = new System.Drawing.Point(453, 5);
            this.userIdBox.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.userIdBox.Name = "userIdBox";
            this.userIdBox.Size = new System.Drawing.Size(108, 20);
            this.userIdBox.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.firstNameLbl);
            this.flowLayoutPanel2.Controls.Add(this.firstNameBox);
            this.flowLayoutPanel2.Controls.Add(this.lastNameLbl);
            this.flowLayoutPanel2.Controls.Add(this.lastNameBox);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 82);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(746, 28);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // firstNameLbl
            // 
            this.firstNameLbl.AutoSize = true;
            this.firstNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLbl.Location = new System.Drawing.Point(2, 5);
            this.firstNameLbl.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
            this.firstNameLbl.Name = "firstNameLbl";
            this.firstNameLbl.Size = new System.Drawing.Size(96, 18);
            this.firstNameLbl.TabIndex = 2;
            this.firstNameLbl.Text = "First Name:";
            // 
            // firstNameBox
            // 
            this.firstNameBox.Location = new System.Drawing.Point(102, 5);
            this.firstNameBox.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(108, 20);
            this.firstNameBox.TabIndex = 3;
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.AutoSize = true;
            this.lastNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLbl.Location = new System.Drawing.Point(214, 5);
            this.lastNameLbl.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
            this.lastNameLbl.Name = "lastNameLbl";
            this.lastNameLbl.Size = new System.Drawing.Size(94, 18);
            this.lastNameLbl.TabIndex = 4;
            this.lastNameLbl.Text = "Last Name:";
            // 
            // lastNameBox
            // 
            this.lastNameBox.Location = new System.Drawing.Point(312, 5);
            this.lastNameBox.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(108, 20);
            this.lastNameBox.TabIndex = 5;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.deptLbl);
            this.flowLayoutPanel3.Controls.Add(this.deptBox);
            this.flowLayoutPanel3.Controls.Add(this.jobTitleLbl);
            this.flowLayoutPanel3.Controls.Add(this.jobTitleBox);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(2, 122);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(746, 28);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // deptLbl
            // 
            this.deptLbl.AutoSize = true;
            this.deptLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptLbl.Location = new System.Drawing.Point(2, 5);
            this.deptLbl.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
            this.deptLbl.Name = "deptLbl";
            this.deptLbl.Size = new System.Drawing.Size(100, 18);
            this.deptLbl.TabIndex = 3;
            this.deptLbl.Text = "Department:";
            // 
            // deptBox
            // 
            this.deptBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deptBox.FormattingEnabled = true;
            this.deptBox.Location = new System.Drawing.Point(106, 5);
            this.deptBox.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.deptBox.Name = "deptBox";
            this.deptBox.Size = new System.Drawing.Size(146, 21);
            this.deptBox.TabIndex = 4;
            // 
            // jobTitleLbl
            // 
            this.jobTitleLbl.AutoSize = true;
            this.jobTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobTitleLbl.Location = new System.Drawing.Point(284, 5);
            this.jobTitleLbl.Margin = new System.Windows.Forms.Padding(30, 5, 2, 0);
            this.jobTitleLbl.Name = "jobTitleLbl";
            this.jobTitleLbl.Size = new System.Drawing.Size(78, 18);
            this.jobTitleLbl.TabIndex = 5;
            this.jobTitleLbl.Text = "Job Title:";
            // 
            // jobTitleBox
            // 
            this.jobTitleBox.Location = new System.Drawing.Point(366, 5);
            this.jobTitleBox.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.jobTitleBox.Name = "jobTitleBox";
            this.jobTitleBox.Size = new System.Drawing.Size(108, 20);
            this.jobTitleBox.TabIndex = 6;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.emailLabel);
            this.flowLayoutPanel4.Controls.Add(this.emailBox);
            this.flowLayoutPanel4.Controls.Add(this.userRightsLbl);
            this.flowLayoutPanel4.Controls.Add(this.userRightsBox);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(2, 162);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(746, 28);
            this.flowLayoutPanel4.TabIndex = 5;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(2, 5);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(256, 18);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "UST Email Address (If Available):";
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(262, 5);
            this.emailBox.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(200, 20);
            this.emailBox.TabIndex = 7;
            // 
            // userRightsLbl
            // 
            this.userRightsLbl.AutoSize = true;
            this.userRightsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRightsLbl.Location = new System.Drawing.Point(486, 5);
            this.userRightsLbl.Margin = new System.Windows.Forms.Padding(22, 5, 2, 0);
            this.userRightsLbl.Name = "userRightsLbl";
            this.userRightsLbl.Size = new System.Drawing.Size(102, 18);
            this.userRightsLbl.TabIndex = 8;
            this.userRightsLbl.Text = "User Rights:";
            // 
            // userRightsBox
            // 
            this.userRightsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userRightsBox.FormattingEnabled = true;
            this.userRightsBox.Location = new System.Drawing.Point(592, 4);
            this.userRightsBox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.userRightsBox.Name = "userRightsBox";
            this.userRightsBox.Size = new System.Drawing.Size(146, 21);
            this.userRightsBox.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.createBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 194);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 206);
            this.panel1.TabIndex = 6;
            // 
            // createBtn
            // 
            this.createBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createBtn.Location = new System.Drawing.Point(154, 83);
            this.createBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(199, 54);
            this.createBtn.TabIndex = 0;
            this.createBtn.Text = "Create New Employee";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // helpLink1
            // 
            this.helpLink1.AutoSize = true;
            this.helpLink1.Location = new System.Drawing.Point(3, 405);
            this.helpLink1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.helpLink1.Name = "helpLink1";
            this.helpLink1.Size = new System.Drawing.Size(29, 13);
            this.helpLink1.TabIndex = 7;
            this.helpLink1.TabStop = true;
            this.helpLink1.Text = "Help";
            // 
            // AddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 427);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddEmployee";
            this.Text = "AddEmployee";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label headerLbl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label loginLbl;
        private System.Windows.Forms.TextBox userIdBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label firstNameLbl;
        private System.Windows.Forms.TextBox firstNameBox;
        private System.Windows.Forms.Label lastNameLbl;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label deptLbl;
        private System.Windows.Forms.ComboBox deptBox;
        private System.Windows.Forms.Label jobTitleLbl;
        private System.Windows.Forms.TextBox jobTitleBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Label userRightsLbl;
        private System.Windows.Forms.ComboBox userRightsBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private CustomControls.HelpLink.HelpLink helpLink1;
    }
}