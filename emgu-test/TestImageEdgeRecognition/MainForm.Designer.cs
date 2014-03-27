namespace TestImageEdgeRecognition
{
	partial class MainForm
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
			this.fileNameTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.loadImageButton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.trackBarThreshold = new System.Windows.Forms.TrackBar();
			this.trackBarThresholdLinking = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.labelThresholdValue = new System.Windows.Forms.Label();
			this.labelThresholdLinkingValue = new System.Windows.Forms.Label();
			this.imageBoxOriginal = new Emgu.CV.UI.ImageBox();
			this.imageBoxEdges = new Emgu.CV.UI.ImageBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarThresholdLinking)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageBoxOriginal)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageBoxEdges)).BeginInit();
			this.SuspendLayout();
			// 
			// fileNameTextBox
			// 
			this.fileNameTextBox.Location = new System.Drawing.Point(133, 12);
			this.fileNameTextBox.Name = "fileNameTextBox";
			this.fileNameTextBox.ReadOnly = true;
			this.fileNameTextBox.Size = new System.Drawing.Size(742, 20);
			this.fileNameTextBox.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(26, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "File:";
			// 
			// loadImageButton
			// 
			this.loadImageButton.Location = new System.Drawing.Point(894, 16);
			this.loadImageButton.Name = "loadImageButton";
			this.loadImageButton.Size = new System.Drawing.Size(30, 23);
			this.loadImageButton.TabIndex = 3;
			this.loadImageButton.Text = "...";
			this.loadImageButton.UseVisualStyleBackColor = true;
			this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// trackBarThreshold
			// 
			this.trackBarThreshold.Location = new System.Drawing.Point(133, 41);
			this.trackBarThreshold.Maximum = 300;
			this.trackBarThreshold.Name = "trackBarThreshold";
			this.trackBarThreshold.Size = new System.Drawing.Size(742, 45);
			this.trackBarThreshold.TabIndex = 10;
			this.trackBarThreshold.Scroll += new System.EventHandler(this.trackBarThreshold_Scroll);
			// 
			// trackBarThresholdLinking
			// 
			this.trackBarThresholdLinking.Location = new System.Drawing.Point(133, 92);
			this.trackBarThresholdLinking.Maximum = 300;
			this.trackBarThresholdLinking.Name = "trackBarThresholdLinking";
			this.trackBarThresholdLinking.Size = new System.Drawing.Size(742, 45);
			this.trackBarThresholdLinking.TabIndex = 20;
			this.trackBarThresholdLinking.Scroll += new System.EventHandler(this.trackBarThreshold_Scroll);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 22;
			this.label2.Text = "Threshold";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 92);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Threshold Linking";
			// 
			// labelThresholdValue
			// 
			this.labelThresholdValue.AutoSize = true;
			this.labelThresholdValue.Location = new System.Drawing.Point(901, 56);
			this.labelThresholdValue.Name = "labelThresholdValue";
			this.labelThresholdValue.Size = new System.Drawing.Size(13, 13);
			this.labelThresholdValue.TabIndex = 24;
			this.labelThresholdValue.Text = "0";
			// 
			// labelThresholdLinkingValue
			// 
			this.labelThresholdLinkingValue.AutoSize = true;
			this.labelThresholdLinkingValue.Location = new System.Drawing.Point(901, 96);
			this.labelThresholdLinkingValue.Name = "labelThresholdLinkingValue";
			this.labelThresholdLinkingValue.Size = new System.Drawing.Size(13, 13);
			this.labelThresholdLinkingValue.TabIndex = 25;
			this.labelThresholdLinkingValue.Text = "0";
			// 
			// imageBoxOriginal
			// 
			this.imageBoxOriginal.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.imageBoxOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.imageBoxOriginal.Cursor = System.Windows.Forms.Cursors.Cross;
			this.imageBoxOriginal.Location = new System.Drawing.Point(12, 252);
			this.imageBoxOriginal.Name = "imageBoxOriginal";
			this.imageBoxOriginal.Size = new System.Drawing.Size(400, 400);
			this.imageBoxOriginal.TabIndex = 26;
			this.imageBoxOriginal.TabStop = false;
			// 
			// imageBoxEdges
			// 
			this.imageBoxEdges.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.imageBoxEdges.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.imageBoxEdges.Cursor = System.Windows.Forms.Cursors.Cross;
			this.imageBoxEdges.Location = new System.Drawing.Point(475, 252);
			this.imageBoxEdges.Name = "imageBoxEdges";
			this.imageBoxEdges.Size = new System.Drawing.Size(400, 400);
			this.imageBoxEdges.TabIndex = 27;
			this.imageBoxEdges.TabStop = false;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 136);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(396, 98);
			this.textBox1.TabIndex = 28;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(429, 136);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(108, 23);
			this.button1.TabIndex = 29;
			this.button1.Text = "Draw Contours";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(936, 673);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.imageBoxEdges);
			this.Controls.Add(this.imageBoxOriginal);
			this.Controls.Add(this.labelThresholdLinkingValue);
			this.Controls.Add(this.labelThresholdValue);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.trackBarThresholdLinking);
			this.Controls.Add(this.trackBarThreshold);
			this.Controls.Add(this.fileNameTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.loadImageButton);
			this.Name = "MainForm";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarThresholdLinking)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageBoxOriginal)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageBoxEdges)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox fileNameTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button loadImageButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TrackBar trackBarThreshold;
		private System.Windows.Forms.TrackBar trackBarThresholdLinking;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelThresholdValue;
		private System.Windows.Forms.Label labelThresholdLinkingValue;
		private Emgu.CV.UI.ImageBox imageBoxOriginal;
		private Emgu.CV.UI.ImageBox imageBoxEdges;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;

	}
}

