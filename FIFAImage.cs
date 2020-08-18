
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
        private IAnalysisrStratege algorithm;


        public FIFAImage(string imgpath)
        {
            imagePath = imgpath;
        }
        public bool Verify()
        {
            string patern1Path = "images\\patterns\\CUSTOMIZE.png";
            string patern2Path = "images\\patterns\\NewItem.png";


            string mutchedPuth = Verify(patern1Path);
            mutchedPuth+= Verify(patern1Path);

            switch (mutchedPuth)
            {
                case 
            }
            return isValide;
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
