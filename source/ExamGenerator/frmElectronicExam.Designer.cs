namespace ExamGenerator
{
    partial class frmElectronicExam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmElectronicExam));
            this.lblTotalQ = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIncorrectQ = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCorrectQ = new System.Windows.Forms.Label();
            this.btnPreviousQ = new System.Windows.Forms.Button();
            this.btnNextQ = new System.Windows.Forms.Button();
            this.lblCurrentQnum = new System.Windows.Forms.Label();
            this.TQholder = new ExamGenerator.ucTestQuestionHolder();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTotalQ
            // 
            this.lblTotalQ.BackColor = System.Drawing.Color.White;
            this.lblTotalQ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQ.Location = new System.Drawing.Point(152, 29);
            this.lblTotalQ.Name = "lblTotalQ";
            this.lblTotalQ.Size = new System.Drawing.Size(64, 23);
            this.lblTotalQ.TabIndex = 0;
            this.lblTotalQ.Text = "00";
            this.lblTotalQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Questions:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(521, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Incorrect Answers:";
            // 
            // lblIncorrectQ
            // 
            this.lblIncorrectQ.BackColor = System.Drawing.Color.White;
            this.lblIncorrectQ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIncorrectQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncorrectQ.Location = new System.Drawing.Point(664, 29);
            this.lblIncorrectQ.Name = "lblIncorrectQ";
            this.lblIncorrectQ.Size = new System.Drawing.Size(64, 23);
            this.lblIncorrectQ.TabIndex = 2;
            this.lblIncorrectQ.Text = "00";
            this.lblIncorrectQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(286, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Correct Answers:";
            // 
            // lblCorrectQ
            // 
            this.lblCorrectQ.BackColor = System.Drawing.Color.White;
            this.lblCorrectQ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCorrectQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrectQ.Location = new System.Drawing.Point(418, 29);
            this.lblCorrectQ.Name = "lblCorrectQ";
            this.lblCorrectQ.Size = new System.Drawing.Size(64, 23);
            this.lblCorrectQ.TabIndex = 4;
            this.lblCorrectQ.Text = "00";
            this.lblCorrectQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPreviousQ
            // 
            this.btnPreviousQ.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviousQ.Image")));
            this.btnPreviousQ.Location = new System.Drawing.Point(207, 372);
            this.btnPreviousQ.Name = "btnPreviousQ";
            this.btnPreviousQ.Size = new System.Drawing.Size(62, 42);
            this.btnPreviousQ.TabIndex = 7;
            this.btnPreviousQ.UseVisualStyleBackColor = true;
            this.btnPreviousQ.Click += new System.EventHandler(this.btnPreviousQ_Click);
            // 
            // btnNextQ
            // 
            this.btnNextQ.Image = ((System.Drawing.Image)(resources.GetObject("btnNextQ.Image")));
            this.btnNextQ.Location = new System.Drawing.Point(493, 372);
            this.btnNextQ.Name = "btnNextQ";
            this.btnNextQ.Size = new System.Drawing.Size(62, 42);
            this.btnNextQ.TabIndex = 8;
            this.btnNextQ.UseVisualStyleBackColor = true;
            this.btnNextQ.Click += new System.EventHandler(this.btnNextQ_Click);
            // 
            // lblCurrentQnum
            // 
            this.lblCurrentQnum.BackColor = System.Drawing.Color.White;
            this.lblCurrentQnum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentQnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentQnum.Location = new System.Drawing.Point(352, 381);
            this.lblCurrentQnum.Name = "lblCurrentQnum";
            this.lblCurrentQnum.Size = new System.Drawing.Size(64, 23);
            this.lblCurrentQnum.TabIndex = 9;
            this.lblCurrentQnum.Text = "1";
            this.lblCurrentQnum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TQholder
            // 
            this.TQholder.AutoSize = true;
            this.TQholder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TQholder.Location = new System.Drawing.Point(43, 91);
            this.TQholder.Name = "TQholder";
            this.TQholder.Size = new System.Drawing.Size(698, 238);
            this.TQholder.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(324, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Question Number";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(352, 451);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 42);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Done";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmElectronicExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 529);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCurrentQnum);
            this.Controls.Add(this.btnNextQ);
            this.Controls.Add(this.btnPreviousQ);
            this.Controls.Add(this.TQholder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCorrectQ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblIncorrectQ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalQ);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmElectronicExam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FCC Practice Exam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmElectronicExam_FormClosing);
            this.Shown += new System.EventHandler(this.frmElectronicExam_Shown);
            this.VisibleChanged += new System.EventHandler(this.frmElectronicExam_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmElectronicExam_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalQ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIncorrectQ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCorrectQ;
        private ucTestQuestionHolder TQholder;
        private System.Windows.Forms.Button btnPreviousQ;
        private System.Windows.Forms.Button btnNextQ;
        private System.Windows.Forms.Label lblCurrentQnum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
    }
}