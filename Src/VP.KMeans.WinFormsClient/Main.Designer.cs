namespace VP.KMeansClient.GUI
{
	partial class Form1
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
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btBrowse = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFilePath = new System.Windows.Forms.TextBox();
			this.btnRunKMeans1 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pnlGraph = new System.Windows.Forms.Panel();
			this.txtClusterCount = new System.Windows.Forms.MaskedTextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(194, 69);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(95, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Draw 2D Data";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Number of Clusters:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtClusterCount);
			this.groupBox1.Controls.Add(this.btBrowse);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtFilePath);
			this.groupBox1.Controls.Add(this.btnRunKMeans1);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(405, 99);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "2D";
			// 
			// btBrowse
			// 
			this.btBrowse.Location = new System.Drawing.Point(371, 43);
			this.btBrowse.Name = "btBrowse";
			this.btBrowse.Size = new System.Drawing.Size(28, 20);
			this.btBrowse.TabIndex = 7;
			this.btBrowse.Text = "...";
			this.btBrowse.UseVisualStyleBackColor = true;
			this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Data file path:";
			// 
			// txtFilePath
			// 
			this.txtFilePath.Location = new System.Drawing.Point(114, 43);
			this.txtFilePath.Name = "txtFilePath";
			this.txtFilePath.Size = new System.Drawing.Size(254, 20);
			this.txtFilePath.TabIndex = 5;
			this.txtFilePath.Text = "input1_2D_02.txt";
			// 
			// btnRunKMeans1
			// 
			this.btnRunKMeans1.Location = new System.Drawing.Point(294, 69);
			this.btnRunKMeans1.Name = "btnRunKMeans1";
			this.btnRunKMeans1.Size = new System.Drawing.Size(105, 23);
			this.btnRunKMeans1.TabIndex = 4;
			this.btnRunKMeans1.Text = "Run K-Means";
			this.btnRunKMeans1.UseVisualStyleBackColor = true;
			this.btnRunKMeans1.Click += new System.EventHandler(this.btnRunKMeans1_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.pnlGraph);
			this.groupBox2.Location = new System.Drawing.Point(12, 117);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(405, 405);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Output graph";
			// 
			// pnlGraph
			// 
			this.pnlGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGraph.Location = new System.Drawing.Point(3, 16);
			this.pnlGraph.Name = "pnlGraph";
			this.pnlGraph.Size = new System.Drawing.Size(399, 386);
			this.pnlGraph.TabIndex = 0;
			// 
			// txtClusterCount
			// 
			this.txtClusterCount.Location = new System.Drawing.Point(114, 17);
			this.txtClusterCount.Mask = "00000";
			this.txtClusterCount.Name = "txtClusterCount";
			this.txtClusterCount.Size = new System.Drawing.Size(100, 20);
			this.txtClusterCount.TabIndex = 8;
			this.txtClusterCount.Text = "6";
			this.txtClusterCount.ValidatingType = typeof(int);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(437, 536);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "K-Means Implementation";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btBrowse;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFilePath;
		private System.Windows.Forms.Button btnRunKMeans1;
		private System.Windows.Forms.Panel pnlGraph;
		private System.Windows.Forms.MaskedTextBox txtClusterCount;
	}
}

