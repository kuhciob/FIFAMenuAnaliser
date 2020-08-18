using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIFAImageAnaliser
{
    public partial class Form1 : Form
    {
        private List<FIFAImage> Images=new List<FIFAImage>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                Image image = ImageGeter.GetByFilePath(filePath);
                if (image!=null)
                {
                    pictureBox1.Image = image;
                    Images.Add(new FIFAImage(image));
                }
                else
                {
                    MessageBox.Show("File dosen`t exist or not image");
                }

                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var img in Images)
                img.Analise();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image image = ImageGeter.GetFromServer(AppConfig.APIUrl);
            this.pictureBox1.Image = image;
            Images.Add(new FIFAImage(image));

        }
    }
}
