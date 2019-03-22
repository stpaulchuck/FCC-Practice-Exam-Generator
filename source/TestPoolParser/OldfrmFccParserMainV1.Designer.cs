namespace TestPoolParser
{
    partial class OldfrmFccParserMainV1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFccParserMain));
			this.label1 = new System.Windows.Forms.Label();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.btnFindInputFile = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnAbort = new System.Windows.Forms.Button();
			this.btnRun = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.txtStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.udElementNumber = new System.Windows.Forms.NumericUpDown();
			this.rbOutput2DB = new System.Windows.Forms.RadioButton();
			this.rbOutput2File = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnFindDescFile = new System.Windows.Forms.Button();
			this.btnFindQuestFile = new System.Windows.Forms.Button();
			this.txtDescriptionFileName = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnFindOutputFolder = new System.Windows.Forms.Button();
			this.txtQuestionFileName = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtOutputFolder = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnSelectDB = new System.Windows.Forms.Button();
			this.txtDBname = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.udElementNumber)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(298, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Input File";
			// 
			// txtFileName
			// 
			this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFileName.Location = new System.Drawing.Point(91, 33);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(511, 23);
			this.txtFileName.TabIndex = 1;
			this.txtFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnFindInputFile
			// 
			this.btnFindInputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFindInputFile.Location = new System.Drawing.Point(626, 33);
			this.btnFindInputFile.Name = "btnFindInputFile";
			this.btnFindInputFile.Size = new System.Drawing.Size(75, 23);
			this.btnFindInputFile.TabIndex = 2;
			this.btnFindInputFile.Text = "Find";
			this.btnFindInputFile.UseVisualStyleBackColor = true;
			this.btnFindInputFile.Click += new System.EventHandler(this.btnFindInputFile_Click);
			// 
			// btnExit
			// 
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExit.Location = new System.Drawing.Point(542, 418);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 34);
			this.btnExit.TabIndex = 13;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnAbort
			// 
			this.btnAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAbort.Location = new System.Drawing.Point(387, 418);
			this.btnAbort.Name = "btnAbort";
			this.btnAbort.Size = new System.Drawing.Size(75, 34);
			this.btnAbort.TabIndex = 14;
			this.btnAbort.Text = "Abort";
			this.btnAbort.UseVisualStyleBackColor = true;
			this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
			// 
			// btnRun
			// 
			this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRun.Location = new System.Drawing.Point(234, 418);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(75, 34);
			this.btnRun.TabIndex = 15;
			this.btnRun.Text = "Run";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtStatus,
            this.toolStripStatusLabel2});
			this.statusStrip1.Location = new System.Drawing.Point(0, 488);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(844, 22);
			this.statusStrip1.TabIndex = 16;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// txtStatus
			// 
			this.txtStatus.Font = new System.Drawing.Font("Tahoma", 10F);
			this.txtStatus.Name = "txtStatus";
			this.txtStatus.Size = new System.Drawing.Size(747, 17);
			this.txtStatus.Spring = true;
			this.txtStatus.Text = "idle ...";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
			this.toolStripStatusLabel2.Font = new System.Drawing.Font("Tahoma", 8F);
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(82, 17);
			this.toolStripStatusLabel2.Text = "Parser V2.0";
			// 
			// udElementNumber
			// 
			this.udElementNumber.Location = new System.Drawing.Point(638, 133);
			this.udElementNumber.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.udElementNumber.Name = "udElementNumber";
			this.udElementNumber.Size = new System.Drawing.Size(79, 20);
			this.udElementNumber.TabIndex = 17;
			// 
			// rbOutput2DB
			// 
			this.rbOutput2DB.AutoSize = true;
			this.rbOutput2DB.Checked = true;
			this.rbOutput2DB.Location = new System.Drawing.Point(65, 19);
			this.rbOutput2DB.Name = "rbOutput2DB";
			this.rbOutput2DB.Size = new System.Drawing.Size(122, 17);
			this.rbOutput2DB.TabIndex = 23;
			this.rbOutput2DB.TabStop = true;
			this.rbOutput2DB.Text = "Output to SQLite DB";
			this.rbOutput2DB.UseVisualStyleBackColor = true;
			this.rbOutput2DB.CheckedChanged += new System.EventHandler(this.rbOutput2DB_CheckedChanged);
			// 
			// rbOutput2File
			// 
			this.rbOutput2File.AutoSize = true;
			this.rbOutput2File.Location = new System.Drawing.Point(245, 19);
			this.rbOutput2File.Name = "rbOutput2File";
			this.rbOutput2File.Size = new System.Drawing.Size(92, 17);
			this.rbOutput2File.TabIndex = 24;
			this.rbOutput2File.Text = "Output To File";
			this.rbOutput2File.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbOutput2DB);
			this.groupBox1.Controls.Add(this.rbOutput2File);
			this.groupBox1.Location = new System.Drawing.Point(107, 76);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(406, 42);
			this.groupBox1.TabIndex = 26;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Output Type Selection";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnFindDescFile);
			this.groupBox2.Controls.Add(this.btnFindQuestFile);
			this.groupBox2.Controls.Add(this.txtDescriptionFileName);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.btnFindOutputFolder);
			this.groupBox2.Controls.Add(this.txtQuestionFileName);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.txtOutputFolder);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(24, 251);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(784, 128);
			this.groupBox2.TabIndex = 27;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Output File Properties";
			// 
			// btnFindDescFile
			// 
			this.btnFindDescFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFindDescFile.Location = new System.Drawing.Point(682, 89);
			this.btnFindDescFile.Name = "btnFindDescFile";
			this.btnFindDescFile.Size = new System.Drawing.Size(75, 23);
			this.btnFindDescFile.TabIndex = 34;
			this.btnFindDescFile.Text = "Find";
			this.btnFindDescFile.UseVisualStyleBackColor = true;
			this.btnFindDescFile.Click += new System.EventHandler(this.btnFindDescFile_Click);
			// 
			// btnFindQuestFile
			// 
			this.btnFindQuestFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFindQuestFile.Location = new System.Drawing.Point(27, 89);
			this.btnFindQuestFile.Name = "btnFindQuestFile";
			this.btnFindQuestFile.Size = new System.Drawing.Size(75, 23);
			this.btnFindQuestFile.TabIndex = 33;
			this.btnFindQuestFile.Text = "Find";
			this.btnFindQuestFile.UseVisualStyleBackColor = true;
			this.btnFindQuestFile.Click += new System.EventHandler(this.btnFindQuestFile_Click);
			// 
			// txtDescriptionFileName
			// 
			this.txtDescriptionFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDescriptionFileName.Location = new System.Drawing.Point(407, 89);
			this.txtDescriptionFileName.Name = "txtDescriptionFileName";
			this.txtDescriptionFileName.Size = new System.Drawing.Size(269, 23);
			this.txtDescriptionFileName.TabIndex = 32;
			this.txtDescriptionFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(429, 69);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(240, 17);
			this.label7.TabIndex = 31;
			this.label7.Text = " Desc. File Name (.csv will be added)";
			// 
			// btnFindOutputFolder
			// 
			this.btnFindOutputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFindOutputFolder.Location = new System.Drawing.Point(518, 34);
			this.btnFindOutputFolder.Name = "btnFindOutputFolder";
			this.btnFindOutputFolder.Size = new System.Drawing.Size(102, 28);
			this.btnFindOutputFolder.TabIndex = 30;
			this.btnFindOutputFolder.Text = "Select Folder";
			this.btnFindOutputFolder.UseVisualStyleBackColor = true;
			this.btnFindOutputFolder.Click += new System.EventHandler(this.btnFindOutputFolder_Click);
			// 
			// txtQuestionFileName
			// 
			this.txtQuestionFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtQuestionFileName.Location = new System.Drawing.Point(108, 89);
			this.txtQuestionFileName.Name = "txtQuestionFileName";
			this.txtQuestionFileName.Size = new System.Drawing.Size(269, 23);
			this.txtQuestionFileName.TabIndex = 29;
			this.txtQuestionFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(130, 69);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(242, 17);
			this.label6.TabIndex = 28;
			this.label6.Text = "Quest. File Name (.csv will be added)";
			// 
			// txtOutputFolder
			// 
			this.txtOutputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtOutputFolder.Location = new System.Drawing.Point(148, 37);
			this.txtOutputFolder.Name = "txtOutputFolder";
			this.txtOutputFolder.Size = new System.Drawing.Size(355, 23);
			this.txtOutputFolder.TabIndex = 27;
			this.txtOutputFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(236, 17);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(95, 17);
			this.label5.TabIndex = 26;
			this.label5.Text = "Output Folder";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(623, 113);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(113, 17);
			this.label4.TabIndex = 18;
			this.label4.Text = "Element Number";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnSelectDB);
			this.groupBox3.Controls.Add(this.txtDBname);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Location = new System.Drawing.Point(91, 133);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(469, 89);
			this.groupBox3.TabIndex = 28;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "SQLite Server Properties";
			// 
			// btnSelectDB
			// 
			this.btnSelectDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSelectDB.Location = new System.Drawing.Point(344, 44);
			this.btnSelectDB.Name = "btnSelectDB";
			this.btnSelectDB.Size = new System.Drawing.Size(75, 23);
			this.btnSelectDB.TabIndex = 12;
			this.btnSelectDB.Text = "Select";
			this.btnSelectDB.UseVisualStyleBackColor = true;
			this.btnSelectDB.Click += new System.EventHandler(this.btnSelectDB_Click);
			// 
			// txtDBname
			// 
			this.txtDBname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDBname.Location = new System.Drawing.Point(51, 44);
			this.txtDBname.Name = "txtDBname";
			this.txtDBname.Size = new System.Drawing.Size(269, 23);
			this.txtDBname.TabIndex = 11;
			this.txtDBname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(139, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 17);
			this.label3.TabIndex = 10;
			this.label3.Text = "Database Name";
			// 
			// frmParserMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(844, 510);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.udElementNumber);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.btnAbort);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnFindInputFile);
			this.Controls.Add(this.txtFileName);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmParserMain";
			this.Text = "FCC Test Pool Parser";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmParserMain_FormClosing);
			this.Shown += new System.EventHandler(this.frmParserMain_Shown);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.udElementNumber)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnFindInputFile;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.NumericUpDown udElementNumber;
        private System.Windows.Forms.RadioButton rbOutput2DB;
        private System.Windows.Forms.RadioButton rbOutput2File;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFindOutputFolder;
        private System.Windows.Forms.TextBox txtQuestionFileName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSelectDB;
        private System.Windows.Forms.TextBox txtDBname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescriptionFileName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFindDescFile;
        private System.Windows.Forms.Button btnFindQuestFile;
    }
}

