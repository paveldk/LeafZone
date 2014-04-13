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
            this.bMin = new System.Windows.Forms.TrackBar();
            this.bMax = new System.Windows.Forms.TrackBar();
            this.gMax = new System.Windows.Forms.TrackBar();
            this.gMin = new System.Windows.Forms.TrackBar();
            this.rMax = new System.Windows.Forms.TrackBar();
            this.rMin = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThresholdLinking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxEdges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMin)).BeginInit();
            this.SuspendLayout();
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(266, 23);
            this.fileNameTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.ReadOnly = true;
            this.fileNameTextBox.Size = new System.Drawing.Size(1480, 31);
            this.fileNameTextBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "File:";
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(1788, 31);
            this.loadImageButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(60, 44);
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
            this.trackBarThreshold.Location = new System.Drawing.Point(266, 79);
            this.trackBarThreshold.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.trackBarThreshold.Maximum = 300;
            this.trackBarThreshold.Name = "trackBarThreshold";
            this.trackBarThreshold.Size = new System.Drawing.Size(1484, 90);
            this.trackBarThreshold.TabIndex = 10;
            this.trackBarThreshold.Scroll += new System.EventHandler(this.trackBarThreshold_Scroll);
            // 
            // trackBarThresholdLinking
            // 
            this.trackBarThresholdLinking.Location = new System.Drawing.Point(266, 177);
            this.trackBarThresholdLinking.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.trackBarThresholdLinking.Maximum = 300;
            this.trackBarThresholdLinking.Name = "trackBarThresholdLinking";
            this.trackBarThresholdLinking.Size = new System.Drawing.Size(1484, 90);
            this.trackBarThresholdLinking.TabIndex = 20;
            this.trackBarThresholdLinking.Scroll += new System.EventHandler(this.trackBarThreshold_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Threshold";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 177);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Threshold Linking";
            // 
            // labelThresholdValue
            // 
            this.labelThresholdValue.AutoSize = true;
            this.labelThresholdValue.Location = new System.Drawing.Point(1802, 108);
            this.labelThresholdValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelThresholdValue.Name = "labelThresholdValue";
            this.labelThresholdValue.Size = new System.Drawing.Size(24, 25);
            this.labelThresholdValue.TabIndex = 24;
            this.labelThresholdValue.Text = "0";
            // 
            // labelThresholdLinkingValue
            // 
            this.labelThresholdLinkingValue.AutoSize = true;
            this.labelThresholdLinkingValue.Location = new System.Drawing.Point(1802, 185);
            this.labelThresholdLinkingValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelThresholdLinkingValue.Name = "labelThresholdLinkingValue";
            this.labelThresholdLinkingValue.Size = new System.Drawing.Size(24, 25);
            this.labelThresholdLinkingValue.TabIndex = 25;
            this.labelThresholdLinkingValue.Text = "0";
            // 
            // imageBoxOriginal
            // 
            this.imageBoxOriginal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBoxOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageBoxOriginal.Cursor = System.Windows.Forms.Cursors.Cross;
            this.imageBoxOriginal.Location = new System.Drawing.Point(24, 485);
            this.imageBoxOriginal.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.imageBoxOriginal.Name = "imageBoxOriginal";
            this.imageBoxOriginal.Size = new System.Drawing.Size(796, 766);
            this.imageBoxOriginal.TabIndex = 26;
            this.imageBoxOriginal.TabStop = false;
            // 
            // imageBoxEdges
            // 
            this.imageBoxEdges.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBoxEdges.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageBoxEdges.Cursor = System.Windows.Forms.Cursors.Cross;
            this.imageBoxEdges.Location = new System.Drawing.Point(950, 485);
            this.imageBoxEdges.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.imageBoxEdges.Name = "imageBoxEdges";
            this.imageBoxEdges.Size = new System.Drawing.Size(796, 766);
            this.imageBoxEdges.TabIndex = 27;
            this.imageBoxEdges.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 262);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(788, 185);
            this.textBox1.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(858, 262);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 44);
            this.button1.TabIndex = 29;
            this.button1.Text = "Draw Contours";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bMin
            // 
            this.bMin.Location = new System.Drawing.Point(1135, 233);
            this.bMin.Margin = new System.Windows.Forms.Padding(6);
            this.bMin.Maximum = 300;
            this.bMin.Name = "bMin";
            this.bMin.Size = new System.Drawing.Size(199, 90);
            this.bMin.TabIndex = 30;
            this.bMin.Scroll += new System.EventHandler(this.colorsChange);
            // 
            // bMax
            // 
            this.bMax.Location = new System.Drawing.Point(1400, 233);
            this.bMax.Margin = new System.Windows.Forms.Padding(6);
            this.bMax.Maximum = 300;
            this.bMax.Name = "bMax";
            this.bMax.Size = new System.Drawing.Size(199, 90);
            this.bMax.TabIndex = 31;
            this.bMax.Scroll += new System.EventHandler(this.colorsChange);
            // 
            // gMax
            // 
            this.gMax.Location = new System.Drawing.Point(1400, 309);
            this.gMax.Margin = new System.Windows.Forms.Padding(6);
            this.gMax.Maximum = 300;
            this.gMax.Name = "gMax";
            this.gMax.Size = new System.Drawing.Size(199, 90);
            this.gMax.TabIndex = 33;
            this.gMax.Scroll += new System.EventHandler(this.colorsChange);
            // 
            // gMin
            // 
            this.gMin.Location = new System.Drawing.Point(1135, 309);
            this.gMin.Margin = new System.Windows.Forms.Padding(6);
            this.gMin.Maximum = 300;
            this.gMin.Name = "gMin";
            this.gMin.Size = new System.Drawing.Size(199, 90);
            this.gMin.TabIndex = 32;
            this.gMin.Scroll += new System.EventHandler(this.colorsChange);
            // 
            // rMax
            // 
            this.rMax.Location = new System.Drawing.Point(1400, 383);
            this.rMax.Margin = new System.Windows.Forms.Padding(6);
            this.rMax.Maximum = 300;
            this.rMax.Name = "rMax";
            this.rMax.Size = new System.Drawing.Size(199, 90);
            this.rMax.TabIndex = 35;
            this.rMax.Scroll += new System.EventHandler(this.colorsChange);
            // 
            // rMin
            // 
            this.rMin.Location = new System.Drawing.Point(1135, 383);
            this.rMin.Margin = new System.Windows.Forms.Padding(6);
            this.rMin.Maximum = 300;
            this.rMin.Name = "rMin";
            this.rMin.Size = new System.Drawing.Size(199, 90);
            this.rMin.TabIndex = 34;
            this.rMin.Scroll += new System.EventHandler(this.colorsChange);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1872, 1294);
            this.Controls.Add(this.rMax);
            this.Controls.Add(this.rMin);
            this.Controls.Add(this.gMax);
            this.Controls.Add(this.gMin);
            this.Controls.Add(this.bMax);
            this.Controls.Add(this.bMin);
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
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThresholdLinking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxEdges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMin)).EndInit();
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
        private System.Windows.Forms.TrackBar bMin;
        private System.Windows.Forms.TrackBar bMax;
        private System.Windows.Forms.TrackBar gMax;
        private System.Windows.Forms.TrackBar gMin;
        private System.Windows.Forms.TrackBar rMax;
        private System.Windows.Forms.TrackBar rMin;

	}
}

