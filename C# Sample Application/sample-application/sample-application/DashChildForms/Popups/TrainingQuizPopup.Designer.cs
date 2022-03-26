namespace sampleApp.DashChildForms.Popups
{
    partial class TrainingQuizPopup
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
            this.selectedTrainingLbl = new System.Windows.Forms.Label();
            this.optionsLbl = new System.Windows.Forms.Label();
            this.viewBtn = new System.Windows.Forms.Button();
            this.quizBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectedTrainingLbl
            // 
            this.selectedTrainingLbl.AutoSize = true;
            this.selectedTrainingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedTrainingLbl.Location = new System.Drawing.Point(4, 3);
            this.selectedTrainingLbl.Name = "selectedTrainingLbl";
            this.selectedTrainingLbl.Size = new System.Drawing.Size(135, 16);
            this.selectedTrainingLbl.TabIndex = 0;
            this.selectedTrainingLbl.Text = "Selected Training:";
            // 
            // optionsLbl
            // 
            this.optionsLbl.AutoSize = true;
            this.optionsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsLbl.Location = new System.Drawing.Point(4, 29);
            this.optionsLbl.Name = "optionsLbl";
            this.optionsLbl.Size = new System.Drawing.Size(57, 16);
            this.optionsLbl.TabIndex = 1;
            this.optionsLbl.Text = "Options:";
            // 
            // viewBtn
            // 
            this.viewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBtn.Location = new System.Drawing.Point(7, 68);
            this.viewBtn.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(148, 30);
            this.viewBtn.TabIndex = 2;
            this.viewBtn.Text = "View Training";
            this.viewBtn.UseVisualStyleBackColor = true;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // quizBtn
            // 
            this.quizBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quizBtn.Location = new System.Drawing.Point(190, 68);
            this.quizBtn.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.quizBtn.Name = "quizBtn";
            this.quizBtn.Size = new System.Drawing.Size(148, 30);
            this.quizBtn.TabIndex = 3;
            this.quizBtn.Text = "Take Quiz";
            this.quizBtn.UseVisualStyleBackColor = true;
            this.quizBtn.Click += new System.EventHandler(this.quizBtn_Click);
            // 
            // TrainingQuizPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 110);
            this.Controls.Add(this.quizBtn);
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.optionsLbl);
            this.Controls.Add(this.selectedTrainingLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(475, 150);
            this.MinimumSize = new System.Drawing.Size(350, 100);
            this.Name = "TrainingQuizPopup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label selectedTrainingLbl;
        private System.Windows.Forms.Label optionsLbl;
        private System.Windows.Forms.Button viewBtn;
        private System.Windows.Forms.Button quizBtn;
    }
}