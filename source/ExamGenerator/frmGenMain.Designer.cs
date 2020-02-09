namespace ExamGenerator
{
	partial class frmGenMain
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
			SqlHandler.Dispose();
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenMain));
            this.btnRun = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSelectDB = new System.Windows.Forms.Button();
            this.txtDBname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.udElementNumber = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtSubelementDesc = new System.Windows.Forms.TextBox();
            this.txtNumberOfQuestions = new System.Windows.Forms.TextBox();
            this.chkAllQuestions = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbEvenDist = new System.Windows.Forms.RadioButton();
            this.rbRandomDist = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbTextFileExam = new System.Windows.Forms.RadioButton();
            this.rbElectronicExam = new System.Windows.Forms.RadioButton();
            this.cmbSubelements = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSubelementTest = new System.Windows.Forms.RadioButton();
            this.rbRegularTest = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udElementNumber)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Enabled = false;
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(295, 278);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 34);
            this.btnRun.TabIndex = 28;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(435, 278);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 34);
            this.btnExit.TabIndex = 26;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSelectDB
            // 
            this.btnSelectDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectDB.Location = new System.Drawing.Point(689, 49);
            this.btnSelectDB.Name = "btnSelectDB";
            this.btnSelectDB.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDB.TabIndex = 20;
            this.btnSelectDB.Text = "Select";
            this.btnSelectDB.UseVisualStyleBackColor = true;
            this.btnSelectDB.Click += new System.EventHandler(this.btnSelectDB_Click);
            // 
            // txtDBname
            // 
            this.txtDBname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBname.Location = new System.Drawing.Point(396, 49);
            this.txtDBname.Name = "txtDBname";
            this.txtDBname.Size = new System.Drawing.Size(269, 23);
            this.txtDBname.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(484, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "SQLite db file name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Exam Element";
            // 
            // udElementNumber
            // 
            this.udElementNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udElementNumber.Location = new System.Drawing.Point(105, 215);
            this.udElementNumber.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.udElementNumber.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.udElementNumber.Name = "udElementNumber";
            this.udElementNumber.Size = new System.Drawing.Size(65, 23);
            this.udElementNumber.TabIndex = 31;
            this.udElementNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.udElementNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.udElementNumber.ValueChanged += new System.EventHandler(this.udElementNumber_ValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtStatus,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 368);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(826, 24);
            this.statusStrip1.TabIndex = 32;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtStatus
            // 
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(708, 19);
            this.txtStatus.Spring = true;
            this.txtStatus.Text = "Idle ...";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(103, 19);
            this.toolStripStatusLabel2.Text = "Test Gen. V2.0";
            // 
            // txtSubelementDesc
            // 
            this.txtSubelementDesc.Location = new System.Drawing.Point(72, 128);
            this.txtSubelementDesc.Multiline = true;
            this.txtSubelementDesc.Name = "txtSubelementDesc";
            this.txtSubelementDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSubelementDesc.Size = new System.Drawing.Size(556, 44);
            this.txtSubelementDesc.TabIndex = 34;
            // 
            // txtNumberOfQuestions
            // 
            this.txtNumberOfQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumberOfQuestions.Location = new System.Drawing.Point(80, 288);
            this.txtNumberOfQuestions.Name = "txtNumberOfQuestions";
            this.txtNumberOfQuestions.Size = new System.Drawing.Size(69, 23);
            this.txtNumberOfQuestions.TabIndex = 43;
            this.txtNumberOfQuestions.Text = "35";
            this.txtNumberOfQuestions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkAllQuestions
            // 
            this.chkAllQuestions.AutoSize = true;
            this.chkAllQuestions.Location = new System.Drawing.Point(163, 292);
            this.chkAllQuestions.Name = "chkAllQuestions";
            this.chkAllQuestions.Size = new System.Drawing.Size(45, 17);
            this.chkAllQuestions.TabIndex = 3;
            this.chkAllQuestions.Text = "ALL";
            this.chkAllQuestions.UseVisualStyleBackColor = true;
            this.chkAllQuestions.CheckedChanged += new System.EventHandler(this.chkAllQuestions_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(69, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 17);
            this.label9.TabIndex = 44;
            this.label9.Text = "Number Of Questions";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbEvenDist);
            this.groupBox2.Controls.Add(this.rbRandomDist);
            this.groupBox2.Location = new System.Drawing.Point(581, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 46);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Distribution";
            // 
            // rbEvenDist
            // 
            this.rbEvenDist.AutoSize = true;
            this.rbEvenDist.Checked = true;
            this.rbEvenDist.Location = new System.Drawing.Point(96, 19);
            this.rbEvenDist.Name = "rbEvenDist";
            this.rbEvenDist.Size = new System.Drawing.Size(58, 17);
            this.rbEvenDist.TabIndex = 1;
            this.rbEvenDist.TabStop = true;
            this.rbEvenDist.Text = "Normal";
            this.rbEvenDist.UseVisualStyleBackColor = true;
            // 
            // rbRandomDist
            // 
            this.rbRandomDist.AutoSize = true;
            this.rbRandomDist.Location = new System.Drawing.Point(18, 19);
            this.rbRandomDist.Name = "rbRandomDist";
            this.rbRandomDist.Size = new System.Drawing.Size(65, 17);
            this.rbRandomDist.TabIndex = 0;
            this.rbRandomDist.Text = "Random";
            this.rbRandomDist.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbTextFileExam);
            this.groupBox3.Controls.Add(this.rbElectronicExam);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(257, 195);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(439, 50);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output Type";
            // 
            // rbTextFileExam
            // 
            this.rbTextFileExam.AutoSize = true;
            this.rbTextFileExam.Location = new System.Drawing.Point(242, 18);
            this.rbTextFileExam.Name = "rbTextFileExam";
            this.rbTextFileExam.Size = new System.Drawing.Size(154, 21);
            this.rbTextFileExam.TabIndex = 2;
            this.rbTextFileExam.Text = "Text File Exam (*.txt)";
            this.rbTextFileExam.UseVisualStyleBackColor = true;
            // 
            // rbElectronicExam
            // 
            this.rbElectronicExam.AutoSize = true;
            this.rbElectronicExam.Checked = true;
            this.rbElectronicExam.Location = new System.Drawing.Point(78, 18);
            this.rbElectronicExam.Name = "rbElectronicExam";
            this.rbElectronicExam.Size = new System.Drawing.Size(126, 21);
            this.rbElectronicExam.TabIndex = 0;
            this.rbElectronicExam.TabStop = true;
            this.rbElectronicExam.Text = "Electronic Exam";
            this.rbElectronicExam.UseVisualStyleBackColor = true;
            // 
            // cmbSubelements
            // 
            this.cmbSubelements.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubelements.FormattingEnabled = true;
            this.cmbSubelements.Location = new System.Drawing.Point(661, 145);
            this.cmbSubelements.Name = "cmbSubelements";
            this.cmbSubelements.Size = new System.Drawing.Size(79, 24);
            this.cmbSubelements.Sorted = true;
            this.cmbSubelements.TabIndex = 47;
            this.cmbSubelements.SelectedIndexChanged += new System.EventHandler(this.cmbSubelements_SelectedIndexChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(659, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 46;
            this.label6.Text = "Subelement";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSubelementTest);
            this.groupBox1.Controls.Add(this.rbRegularTest);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(50, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 42);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Type";
            // 
            // rbSubelementTest
            // 
            this.rbSubelementTest.AutoSize = true;
            this.rbSubelementTest.Location = new System.Drawing.Point(148, 16);
            this.rbSubelementTest.Name = "rbSubelementTest";
            this.rbSubelementTest.Size = new System.Drawing.Size(144, 21);
            this.rbSubelementTest.TabIndex = 1;
            this.rbSubelementTest.Text = "Single Subelement";
            this.rbSubelementTest.UseVisualStyleBackColor = true;
            // 
            // rbRegularTest
            // 
            this.rbRegularTest.AutoSize = true;
            this.rbRegularTest.Checked = true;
            this.rbRegularTest.Location = new System.Drawing.Point(37, 16);
            this.rbRegularTest.Name = "rbRegularTest";
            this.rbRegularTest.Size = new System.Drawing.Size(76, 21);
            this.rbRegularTest.TabIndex = 0;
            this.rbRegularTest.TabStop = true;
            this.rbRegularTest.Text = "Regular";
            this.rbRegularTest.UseVisualStyleBackColor = true;
            this.rbRegularTest.CheckedChanged += new System.EventHandler(this.rbRegularTest_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(314, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 17);
            this.label7.TabIndex = 38;
            this.label7.Text = "Subelement Description";
            // 
            // frmGenMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 392);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbSubelements);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkAllQuestions);
            this.Controls.Add(this.txtNumberOfQuestions);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSubelementDesc);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.udElementNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSelectDB);
            this.Controls.Add(this.txtDBname);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGenMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FCC Test Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGenMain_FormClosing);
            this.Shown += new System.EventHandler(this.frmGenMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.udElementNumber)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnSelectDB;
		private System.Windows.Forms.TextBox txtDBname;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown udElementNumber;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel txtStatus;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.TextBox txtSubelementDesc;
		private System.Windows.Forms.TextBox txtNumberOfQuestions;
		private System.Windows.Forms.CheckBox chkAllQuestions;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbEvenDist;
		private System.Windows.Forms.RadioButton rbRandomDist;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rbTextFileExam;
		private System.Windows.Forms.RadioButton rbElectronicExam;
		private System.Windows.Forms.ComboBox cmbSubelements;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbSubelementTest;
		private System.Windows.Forms.RadioButton rbRegularTest;
		private System.Windows.Forms.Label label7;
	}
}

