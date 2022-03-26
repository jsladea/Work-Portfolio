namespace sampleApp
{
    partial class ManagementDash
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
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerLbl = new System.Windows.Forms.Label();
            this.pendingTasksDGV = new System.Windows.Forms.DataGridView();
            this.pendingTasksHeaderPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pendingTasksLbl = new System.Windows.Forms.Label();
            this.reloadPendingBtn = new System.Windows.Forms.Button();
            this.instructionsLbl = new System.Windows.Forms.Label();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.helpLink1 = new sampleApp.CustomControls.HelpLink.HelpLink();
            this.mainLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pendingTasksDGV)).BeginInit();
            this.pendingTasksHeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 2;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.mainLayoutPanel.Controls.Add(this.headerLbl, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.pendingTasksDGV, 0, 3);
            this.mainLayoutPanel.Controls.Add(this.pendingTasksHeaderPanel, 0, 2);
            this.mainLayoutPanel.Controls.Add(this.helpLink1, 0, 4);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 5;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(1098, 619);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // headerLbl
            // 
            this.headerLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.headerLbl.AutoSize = true;
            this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLbl.Location = new System.Drawing.Point(3, 8);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(82, 29);
            this.headerLbl.TabIndex = 0;
            this.headerLbl.Text = "Home";
            // 
            // pendingTasksDGV
            // 
            this.pendingTasksDGV.AllowUserToAddRows = false;
            this.pendingTasksDGV.AllowUserToDeleteRows = false;
            this.pendingTasksDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pendingTasksDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pendingTasksDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pendingTasksDGV.Location = new System.Drawing.Point(3, 108);
            this.pendingTasksDGV.Name = "pendingTasksDGV";
            this.pendingTasksDGV.RowHeadersVisible = false;
            this.pendingTasksDGV.Size = new System.Drawing.Size(1087, 488);
            this.pendingTasksDGV.TabIndex = 2;
            this.pendingTasksDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pendingTasksDGV_CellDoubleClick);
            // 
            // pendingTasksHeaderPanel
            // 
            this.pendingTasksHeaderPanel.Controls.Add(this.pendingTasksLbl);
            this.pendingTasksHeaderPanel.Controls.Add(this.reloadPendingBtn);
            this.pendingTasksHeaderPanel.Controls.Add(this.instructionsLbl);
            this.pendingTasksHeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pendingTasksHeaderPanel.Location = new System.Drawing.Point(3, 68);
            this.pendingTasksHeaderPanel.Name = "pendingTasksHeaderPanel";
            this.pendingTasksHeaderPanel.Size = new System.Drawing.Size(1087, 34);
            this.pendingTasksHeaderPanel.TabIndex = 3;
            // 
            // pendingTasksLbl
            // 
            this.pendingTasksLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pendingTasksLbl.AutoSize = true;
            this.pendingTasksLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingTasksLbl.Location = new System.Drawing.Point(3, 4);
            this.pendingTasksLbl.Margin = new System.Windows.Forms.Padding(3, 2, 35, 0);
            this.pendingTasksLbl.Name = "pendingTasksLbl";
            this.pendingTasksLbl.Size = new System.Drawing.Size(174, 29);
            this.pendingTasksLbl.TabIndex = 1;
            this.pendingTasksLbl.Text = "Pending Tasks";
            // 
            // reloadPendingBtn
            // 
            this.reloadPendingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reloadPendingBtn.Location = new System.Drawing.Point(215, 3);
            this.reloadPendingBtn.Margin = new System.Windows.Forms.Padding(3, 3, 25, 3);
            this.reloadPendingBtn.Name = "reloadPendingBtn";
            this.reloadPendingBtn.Size = new System.Drawing.Size(191, 29);
            this.reloadPendingBtn.TabIndex = 2;
            this.reloadPendingBtn.Text = "Reload Pending Tasks";
            this.reloadPendingBtn.UseVisualStyleBackColor = true;
            this.reloadPendingBtn.Click += new System.EventHandler(this.reloadPendingBtn_Click);
            // 
            // instructionsLbl
            // 
            this.instructionsLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.instructionsLbl.AutoSize = true;
            this.instructionsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsLbl.Location = new System.Drawing.Point(434, 9);
            this.instructionsLbl.Margin = new System.Windows.Forms.Padding(3, 3, 35, 0);
            this.instructionsLbl.Name = "instructionsLbl";
            this.instructionsLbl.Size = new System.Drawing.Size(276, 20);
            this.instructionsLbl.TabIndex = 3;
            this.instructionsLbl.Text = "Double click row to approve training";
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // helpLink1
            // 
            this.helpLink1.AutoSize = true;
            this.helpLink1.Location = new System.Drawing.Point(3, 602);
            this.helpLink1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.helpLink1.Name = "helpLink1";
            this.helpLink1.Size = new System.Drawing.Size(29, 13);
            this.helpLink1.TabIndex = 4;
            this.helpLink1.TabStop = true;
            this.helpLink1.Text = "Help";
            // 
            // ManagementDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 619);
            this.Controls.Add(this.mainLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManagementDash";
            this.Text = "ManagementDash";
            this.Shown += new System.EventHandler(this.ManagementDash_Shown);
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pendingTasksDGV)).EndInit();
            this.pendingTasksHeaderPanel.ResumeLayout(false);
            this.pendingTasksHeaderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.Label headerLbl;
        private System.Windows.Forms.Label pendingTasksLbl;
        private System.Windows.Forms.DataGridView pendingTasksDGV;
        private System.Windows.Forms.FlowLayoutPanel pendingTasksHeaderPanel;
        private System.Windows.Forms.Button reloadPendingBtn;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.Label instructionsLbl;
        private CustomControls.HelpLink.HelpLink helpLink1;
    }
}