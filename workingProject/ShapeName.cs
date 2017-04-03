using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Processors;

namespace WindowsFormsApplication1
{
    public partial class ShapeName : Form
    {
        private DialogProcessor dialogProcessor = new DialogProcessor();
        public ShapeName()
        {
            
            InitializeComponent();
        }
        public static string shapeName = "";
       
        private void BtnRename_Click(object sender, EventArgs e)
        {

            shapeName = ShapeNameTextBOx.Text.ToString();
          // dialogProcessor.NameShape(ShapeNameTextBOx.Text.ToString());
          
            
            // MessageBox.Show(dialogProcessor.Selection.ShapeName[dialogProcessor.Selection.ShapeName.IndexOf[dialogProcessor.Selection.ShapeName1])
        }

        private void ShapeName_Load(object sender, EventArgs e)
        {
          
            
        }
    }
}
