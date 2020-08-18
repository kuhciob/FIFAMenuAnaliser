
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
        private bool isValide;
        OpenCvSharp.Point minLoc;
        private IAnalysisStratege algorithm;


        public FIFAImage(string imgpath)
        {
            imagePath = imgpath;
        }
        public void Analise()
        {
            const string customizePaternPath = "images\\patterns\\CUSTOMIZE.png";
            const string newItemPaternPath = "images\\patterns\\NewItem.png";


            string mutchedPuth = Verify(customizePaternPath);
            mutchedPuth+= Verify(newItemPaternPath);
            isValide = true;

            switch (mutchedPuth)
            {
                case customizePaternPath:
                    algorithm = new CustomizeAnalyser();
                    break;
                case newItemPaternPath:
                    algorithm = new NewItemAnalyser();
                    break;
                default:
                    isValide = false;
                    algorithm = new InvalidAnalyser();
                    break;
            }

            algorithm.AnalyseImage();
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
                MessageBox.Show($"It is {VaryName} maxLoc: {maxLoc}, maxVal: {maxVal}");
                return patternpath;    
            }
          
            return "";
        }


    }
}
