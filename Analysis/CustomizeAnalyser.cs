﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIFAImageAnaliser.Analysis
{
    class CustomizeAnalyser : IAnalysisStratege
    {
        public void AnalyseImage()
        {
            MessageBox.Show("It is Customize tab");
        }
    }
}
