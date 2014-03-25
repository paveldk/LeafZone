using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace TestImageEdgeRecognition
{
	public partial class MainForm : Form
	{
		private Image<Bgr, Byte> ImageOriginal { get; set; }

		private Image<Bgr, Byte> Image { get; set; }

		private Image<Gray, Byte> GrayscaleImage { get; set; }

		public Contour<Point> Contours { get; set; }

		public MainForm()
		{
			this.InitializeComponent();
		}

		private void loadImageButton_Click(object sender, EventArgs e)
		{
			DialogResult result = this.openFileDialog1.ShowDialog();
			if (result == DialogResult.OK || result == DialogResult.Yes)
			{
				this.fileNameTextBox.Text = this.openFileDialog1.FileName;

				this.ImageOriginal = new Image<Bgr, byte>(this.fileNameTextBox.Text)
																					.Resize(400, 400, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR, true);

				this.GrayscaleImage = this.ImageOriginal.Convert<Gray, Byte>().PyrDown().PyrUp();

				Gray averageIntensity = this.GrayscaleImage.GetAverage();

				this.trackBarThreshold.Value = (int)(averageIntensity.Intensity * .66);
				this.trackBarThresholdLinking.Value = (int)(averageIntensity.Intensity * 1.33);

				this.textBox1.Text = "";
				this.UpdateTackBarValues();
				this.PerformEdgeDetection();
			}
		}

		private void UpdateTackBarValues()
		{
			this.labelThresholdValue.Text = this.trackBarThreshold.Value.ToString();
			this.labelThresholdLinkingValue.Text = this.trackBarThresholdLinking.Value.ToString();
		}

		public void PerformEdgeDetection()
		{
			Image<Gray, Byte> cannyEdges = this.GrayscaleImage.Canny(this.trackBarThreshold.Value, this.trackBarThresholdLinking.Value);

			this.Image = this.ImageOriginal.Copy();
			this.imageBoxOriginal.Image = this.Image;
			this.imageBoxEdges.Image = cannyEdges;
			this.Contours = cannyEdges.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL);
		}

		private void trackBarThreshold_Scroll(object sender, EventArgs e)
		{
			this.UpdateTackBarValues();
			this.PerformEdgeDetection();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (this.Contours == null)
			{
				return;
			}

			this.Image.Draw(this.Contours, new Bgr(Color.Red), -1);
			this.textBox1.Text += "Area: " + this.Contours.Area + " Perimeter: " + this.Contours.Perimeter + Environment.NewLine;
			this.imageBoxOriginal.Refresh();
			this.Contours = this.Contours.HNext;
		}
	}
}