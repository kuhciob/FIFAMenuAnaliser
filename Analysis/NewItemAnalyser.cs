using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIFAImageAnaliser.Analysis
{
    class NewItemAnalyser : IAnalysisStratege
    {
        public void AnalyseImage()
        {
            MessageBox.Show("It is New Item tab");
        }
    }
}
