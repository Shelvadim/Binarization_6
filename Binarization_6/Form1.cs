using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;

namespace Binarization_6
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> imgInput;
        Image<Gray, byte> imgGray;
        Image<Gray, byte> imgBinarized;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog()==DialogResult.OK)
            {
                imgInput = new Image<Bgr, byte>(ofd.FileName);
                pictureBox1.Image = imgInput.ToBitmap();
            }
        }

        private void binarizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgGray = imgInput.Convert<Gray, byte>();
            pictureBox1.Image = imgGray.ToBitmap();

            // Binarization
            imgBinarized =new Image<Gray, byte>(imgGray.Width, imgGray.Height, new Gray(0));

            //CvInvoke.Threshold(imgGray, imgBinarized, 50, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
            //pictureBox2.Image = imgBinarized.ToBitmap();

            // adaptive threshold
            CvInvoke.AdaptiveThreshold(imgGray, imgBinarized, 255, Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC, Emgu.CV.CvEnum.ThresholdType.Binary, 5, 0.0);
            pictureBox2.Image = imgBinarized.ToBitmap();
        }
    }
}
