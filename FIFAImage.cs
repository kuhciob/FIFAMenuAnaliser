
using FIFAImageAnaliser.Analysis;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIFAImageAnaliser
{
    class FIFAImage
    {
        private 
        private Image fifaImage;
        private bool isValide;
        OpenCvSharp.Point mutchLoc;
        private IAnalysisStratege algorithm;
        


        public FIFAImage(string imgpath)
        {
            fifaImage=Image.FromFile(imgpath);
        }
        public FIFAImage(Image img)
        {
            fifaImage = (Image)img.Clone();
        }
        private string Verify(string patternpath)
        {
            string tmpname = $"tmp{DateTime.Now.ToString("hh_mm_ss")}.png";
            fifaImage.Save(tmpname);

            var image = new Mat(tmpname);
            File.Delete(tmpname);
            var template = new Mat(patternpath);

            var w = (image.Width - template.Width) + 1;
            var h = (image.Height - template.Height) + 1;

            double minVal, maxVal;

            OpenCvSharp.Point minLoc, maxLoc;

            var result = image.MatchTemplate(template, TemplateMatchModes.CCorrNormed);

            result.MinMaxLoc(out minVal, out maxVal, out minLoc, out maxLoc);
            string VaryName = Path.GetFileNameWithoutExtension(patternpath);
            //MessageBox.Show($"Is it {VaryName}? : match={maxVal}");

            if (maxVal >0.9999900)
            {
                this.mutchLoc = maxLoc;
                return patternpath;
            }

            return "";
        }
        public void Analise()
        {
            const string customizePaternPath = AppConfig.CustomizePaternPath;
            const string newItemPaternPath1 = AppConfig.NewItemPaternPath1;
            const string newItemPaternPath2 = AppConfig.NewItemPaternPath2;

            string mutchedPuth = Verify(customizePaternPath);
            mutchedPuth+= Verify(newItemPaternPath1);
            mutchedPuth += Verify(newItemPaternPath2);
            isValide = true;

            switch (mutchedPuth)
            {
                case customizePaternPath:
                    {
                        algorithm = new CustomizeAnalyser();
                        Image pattern = Image.FromFile(customizePaternPath);
                        DrawRectangle(fifaImage, mutchLoc.X, mutchLoc.Y, pattern.Width, pattern.Height, Color.Red);
                        ShowMutch();
                        break;
                    }                   
                case newItemPaternPath1:
                    {
                        algorithm = new NewItemAnalyser();
                        Image pattern = Image.FromFile(newItemPaternPath1);
                        DrawRectangle(fifaImage, mutchLoc.X, mutchLoc.Y, pattern.Width, pattern.Height, Color.Red);
                        ShowMutch();

                        break;
                    }
                case newItemPaternPath2:
                    {
                        algorithm = new NewItemAnalyser();
                        Image pattern = Image.FromFile(newItemPaternPath2);
                        DrawRectangle(fifaImage, mutchLoc.X, mutchLoc.Y, pattern.Width, pattern.Height, Color.Red);
                        ShowMutch();

                        break;
                    }
                default:
                    isValide = false;
                    algorithm = new InvalidAnalyser();
                    break;
            }
            

            algorithm.AnalyseImage();
        }
        private void ShowMutch()
        {
            ImageForm form = new ImageForm();
            form.Image.Image = fifaImage;
            form.Show();
        } 
        private void DrawRectangle(Image image , int x, int y, int width,int height, Color color)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                Pen pen = new Pen(color, 3);
                Rectangle rect = new Rectangle(x, y, width, height);
                g.DrawRectangle(pen, rect);
            }
        }
        private void DrawRectangle(Image srcImage, int x, int y, Image patternImage, Color color)
        {
            using (Graphics g = Graphics.FromImage(srcImage))
            {
                Pen pen = new Pen(color, 3);
                Rectangle rect = new Rectangle(x, y, patternImage.Width, patternImage.Height);
                g.DrawRectangle(pen, rect);
            }
        }
        private void DrawRectangle(string srcImagePath, int x, int y, string patternImagePath, Color color)
        {
            Image srcImage = Image.FromFile(srcImagePath);
            Image patternImage = Image.FromFile(patternImagePath);
            using (Graphics g = Graphics.FromImage(srcImage))
            {
                Pen pen = new Pen(color, 3);
                Rectangle rect = new Rectangle(x, y, patternImage.Width, patternImage.Height);
                g.DrawRectangle(pen, rect);
            }
        }
        


    }
}
