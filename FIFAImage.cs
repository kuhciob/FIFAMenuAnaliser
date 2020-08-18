
using FIFAImageAnaliser.Analysis;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIFAImageAnaliser
{
    class FIFAImage
    {
        private string imagePath;
        private Image fifaImage;
        private bool isValide;
        OpenCvSharp.Point mutchLoc;
        private IAnalysisStratege algorithm;
        


        public FIFAImage(string imgpath)
        {
            imagePath = imgpath;
            fifaImage=Image.FromFile(imgpath);
        }
        private string Verify(string patternpath)
        {
            var image = new Mat(imagePath);
            var template = new Mat(patternpath);

            var w = (image.Width - template.Width) + 1;
            var h = (image.Height - template.Height) + 1;

            double minVal, maxVal;

            OpenCvSharp.Point minLoc, maxLoc;

            var result = image.MatchTemplate(template, TemplateMatchModes.CCoeffNormed);

            result.MinMaxLoc(out minVal, out maxVal, out minLoc, out maxLoc);
            string VaryName = Path.GetFileNameWithoutExtension(patternpath);
            if (maxVal == 1)
            {
                //MessageBox.Show($"It is {VaryName} maxLoc: {maxLoc}, maxVal: {maxVal}");
                this.mutchLoc = maxLoc;
                return patternpath;
            }

            return "";
        }
        public void Analise()
        {
            const string customizePaternPath = AppConfig.CustomizePaternPath;
            const string newItemPaternPath = AppConfig.NewItemPaternPath;


            string mutchedPuth = Verify(customizePaternPath);
            mutchedPuth+= Verify(newItemPaternPath);
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
                case newItemPaternPath:
                    {
                        algorithm = new NewItemAnalyser();
                        Image pattern = Image.FromFile(newItemPaternPath);
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
