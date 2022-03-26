namespace sampleApp
{
    partial class QuizCreator
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
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addQuestionBtn = new System.Windows.Forms.Button();
            this.removeQuestionBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.selectTrainingLbl = new System.Windows.Forms.Label();
            this.trainingSelectorBox = new System.Windows.Forms.ComboBox();
            this.viewTrainingBtn = new System.Windows.Forms.Button();
            this.viewQuizBtn = new System.Windows.Forms.Button();
            this.helpLink1 = new sampleApp.CustomControls.HelpLink.HelpLink();
            this.mainLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.AutoScroll = true;
            this.mainLayoutPanel.AutoSize = true;
            this.mainLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainLayoutPanel.ColumnCount = 2;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.mainLayoutPanel.Controls.Add(this.headerLbl, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.scrollPanel, 0, 3);
            this.mainLayoutPanel.Controls.Add(this.flowLayoutPanel1, 0, 4);
            this.mainLayoutPanel.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.mainLayoutPanel.Controls.Add(this.helpLink1, 0, 6);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 7;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(800, 490);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // headerLbl
            // 
            this.headerLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.headerLbl.AutoSize = true;
            this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLbl.Location = new System.Drawing.Point(3, 8);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(160, 29);
            this.headerLbl.TabIndex = 0;
            this.headerLbl.Text = "Quiz Creator";
            // 
            // scrollPanel
            // 
            this.scrollPanel.AutoScroll = true;
            this.scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel.Location = new System.Drawing.Point(3, 98);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(789, 324);
            this.scrollPanel.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.addQuestionBtn);
            this.flowLayoutPanel1.Controls.Add(this.removeQuestionBtn);
            this.flowLayoutPanel1.Controls.Add(this.createBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 428);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(789, 34);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // addQuestionBtn
            // 
            this.addQuestionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addQuestionBtn.Location = new System.Drawing.Point(3, 3);
            this.addQuestionBtn.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.addQuestionBtn.Name = "addQuestionBtn";
            this.addQuestionBtn.Size = new System.Drawing.Size(160, 29);
            this.addQuestionBtn.TabIndex = 1;
            this.addQuestionBtn.Text = "Add Question";
            this.addQuestionBtn.UseVisualStyleBackColor = true;
            this.addQuestionBtn.Click += new System.EventHandler(this.addQuestionBtn_Click);
            // 
            // removeQuestionBtn
            // 
            this.removeQuestionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeQuestionBtn.Location = new System.Drawing.Point(196, 3);
            this.removeQuestionBtn.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.removeQuestionBtn.Name = "removeQuestionBtn";
            this.removeQuestionBtn.Size = new System.Drawing.Size(218, 29);
            this.removeQuestionBtn.TabIndex = 3;
            this.removeQuestionBtn.Text = "Remove Last Question";
            this.removeQuestionBtn.UseVisualStyleBackColor = true;
            this.removeQuestionBtn.Click += new System.EventHandler(this.removeQuestionBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createBtn.Location = new System.Drawing.Point(447, 3);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(171, 29);
            this.createBtn.TabIndex = 4;
            this.createBtn.Text = "Create Quiz";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.selectTrainingLbl);
            this.flowLayoutPanel2.Controls.Add(this.trainingSelectorBox);
            this.flowLayoutPanel2.Controls.Add(this.viewTrainingBtn);
            this.flowLayoutPanel2.Controls.Add(this.viewQuizBtn);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 58);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(789, 34);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // selectTrainingLbl
            // 
            this.selectTrainingLbl.AutoSize = true;
            this.selectTrainingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectTrainingLbl.Location = new System.Drawing.Point(3, 6);
            this.selectTrainingLbl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.selectTrainingLbl.Name = "selectTrainingLbl";
            this.selectTrainingLbl.Size = new System.Drawing.Size(141, 24);
            this.selectTrainingLbl.TabIndex = 0;
            this.selectTrainingLbl.Text = "Select Training:";
            // 
            // trainingSelectorBox
            // 
            this.trainingSelectorBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.trainingSelectorBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.trainingSelectorBox.FormattingEnabled = true;
            this.trainingSelectorBox.Location = new System.Drawing.Point(150, 7);
            this.trainingSelectorBox.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.trainingSelectorBox.Name = "trainingSelectorBox";
            this.trainingSelectorBox.Size = new System.Drawing.Size(281, 21);
            this.trainingSelectorBox.TabIndex = 1;
            this.trainingSelectorBox.SelectedIndexChanged += new System.EventHandler(this.trainingSelectorBox_SelectedIndexChanged);
            // 
            // viewTrainingBtn
            // 
            this.viewTrainingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewTrainingBtn.Location = new System.Drawing.Point(449, 4);
            this.viewTrainingBtn.Margin = new System.Windows.Forms.Padding(15, 4, 3, 3);
            this.viewTrainingBtn.Name = "viewTrainingBtn";
            this.viewTrainingBtn.Size = new System.Drawing.Size(122, 28);
            this.viewTrainingBtn.TabIndex = 2;
            this.viewTrainingBtn.Text = "View Training";
            this.viewTrainingBtn.UseVisualStyleBackColor = true;
            this.viewTrainingBtn.Click += new System.EventHandler(this.viewTrainingBtn_Click);
            // 
            // viewQuizBtn
            // 
            this.viewQuizBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewQuizBtn.Location = new System.Drawing.Point(589, 4);
            this.viewQuizBtn.Margin = new System.Windows.Forms.Padding(15, 4, 3, 3);
            this.viewQuizBtn.Name = "viewQuizBtn";
            this.viewQuizBtn.Size = new System.Drawing.Size(168, 28);
            this.viewQuizBtn.TabIndex = 3;
            this.viewQuizBtn.Text = "View Current Quiz";
            this.viewQuizBtn.UseVisualStyleBackColor = true;
            this.viewQuizBtn.Click += new System.EventHandler(this.viewQuizBtn_Click);
            // 
            // helpLink1
            // 
            this.helpLink1.AutoSize = true;
            this.helpLink1.Location = new System.Drawing.Point(3, 473);
            this.helpLink1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.helpLink1.Name = "helpLink1";
            this.helpLink1.Size = new System.Drawing.Size(29, 13);
            this.helpLink1.TabIndex = 6;
            this.helpLink1.TabStop = true;
            this.helpLink1.Text = "Help";
            // 
            // QuizCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.mainLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuizCreator";
            this.Text = "QuizCreator";
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.Label headerLbl;
        private System.Windows.Forms.Button addQuestionBtn;
        private System.Windows.Forms.Panel scrollPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button removeQuestionBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label selectTrainingLbl;
        private System.Windows.Forms.ComboBox trainingSelectorBox;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button viewTrainingBtn;
        private System.Windows.Forms.Button viewQuizBtn;
        private CustomControls.HelpLink.HelpLink helpLink1;
    }
}