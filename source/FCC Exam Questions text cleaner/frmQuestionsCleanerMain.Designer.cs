namespace FCC_Exam_Questions_text_cleaner
{
    partial class frmQuestionsCleanerMain
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
            this.btnReloadFile = new System.Windows.Forms.Button();
            this.btnFindInputFile = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetOutputDir = new System.Windows.Forms.Button();
            this.txtOutputDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLinesRead = new System.Windows.Forms.Label();
            this.lblLinesCleaned = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReloadFile
            // 
            this.btnReloadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadFile.Location = new System.Drawing.Point(546, 89);
            this.btnReloadFile.Name = "btnReloadFile";
            this.btnReloadFile.Size = new System.Drawing.Size(75, 23);
            this.btnReloadFile.TabIndex = 34;
            this.btnReloadFile.Text = "Reload";
            this.btnReloadFile.UseVisualStyleBackColor = true;
            this.btnReloadFile.Click += new System.EventHandler(this.btnReloadFile_Click);
            // 
            // btnFindInputFile
            // 
            this.btnFindInputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindInputFile.Location = new System.Drawing.Point(546, 60);
            this.btnFindInputFile.Name = "btnFindInputFile";
            this.btnFindInputFile.Size = new System.Drawing.Size(75, 23);
            this.btnFindInputFile.TabIndex = 33;
            this.btnFindInputFile.Text = "Find";
            this.btnFindInputFile.UseVisualStyleBackColor = true;
            this.btnFindInputFile.Click += new System.EventHandler(this.btnFindInputFile_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(88, 60);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(452, 23);
            this.txtFileName.TabIndex = 32;
            this.txtFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(288, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Input File";
            // 
            // btnSetOutputDir
            // 
            this.btnSetOutputDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetOutputDir.Location = new System.Drawing.Point(546, 157);
            this.btnSetOutputDir.Name = "btnSetOutputDir";
            this.btnSetOutputDir.Size = new System.Drawing.Size(75, 23);
            this.btnSetOutputDir.TabIndex = 37;
            this.btnSetOutputDir.Text = "Find";
            this.btnSetOutputDir.UseVisualStyleBackColor = true;
            this.btnSetOutputDir.Click += new System.EventHandler(this.btnSetOutputDir_Click);
            // 
            // txtOutputDirectory
            // 
            this.txtOutputDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputDirectory.Location = new System.Drawing.Point(88, 157);
            this.txtOutputDirectory.Name = "txtOutputDirectory";
            this.txtOutputDirectory.Size = new System.Drawing.Size(452, 23);
            this.txtOutputDirectory.TabIndex = 36;
            this.txtOutputDirectory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(254, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "Output File Directory";
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(104, 237);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 34);
            this.btnRun.TabIndex = 41;
            this.btnRun.Text = "Clean";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(336, 338);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 34);
            this.btnExit.TabIndex = 39;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(231, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 42;
            this.label3.Text = "Lines Read";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(458, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 43;
            this.label4.Text = "Lines Cleaned";
            // 
            // lblLinesRead
            // 
            this.lblLinesRead.BackColor = System.Drawing.SystemColors.Window;
            this.lblLinesRead.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLinesRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinesRead.Location = new System.Drawing.Point(331, 246);
            this.lblLinesRead.Name = "lblLinesRead";
            this.lblLinesRead.Size = new System.Drawing.Size(80, 17);
            this.lblLinesRead.TabIndex = 44;
            this.lblLinesRead.Text = "0";
            this.lblLinesRead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLinesCleaned
            // 
            this.lblLinesCleaned.BackColor = System.Drawing.SystemColors.Window;
            this.lblLinesCleaned.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLinesCleaned.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinesCleaned.Location = new System.Drawing.Point(577, 246);
            this.lblLinesCleaned.Name = "lblLinesCleaned";
            this.lblLinesCleaned.Size = new System.Drawing.Size(80, 17);
            this.lblLinesCleaned.TabIndex = 45;
            this.lblLinesCleaned.Text = "0";
            this.lblLinesCleaned.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(167, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(335, 17);
            this.label5.TabIndex = 46;
            this.label5.Text = "{ Default Output File Name Is \'CleanedExamFile.txt\' }";
            // 
            // frmQuestionsCleanerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLinesCleaned);
            this.Controls.Add(this.lblLinesRead);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSetOutputDir);
            this.Controls.Add(this.txtOutputDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReloadFile);
            this.Controls.Add(this.btnFindInputFile);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Name = "frmQuestionsCleanerMain";
            this.Text = "FCC Exam Questions Cleaner";
            this.Shown += new System.EventHandler(this.frmQuestionsCleanerMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReloadFile;
        private System.Windows.Forms.Button btnFindInputFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetOutputDir;
        private System.Windows.Forms.TextBox txtOutputDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLinesRead;
        private System.Windows.Forms.Label lblLinesCleaned;
        private System.Windows.Forms.Label label5;
    }
}

