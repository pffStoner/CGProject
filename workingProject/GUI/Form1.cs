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
using System.Runtime.InteropServices;//
using System.IO;//
using WindowsFormsApplication1.Model;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
      
        Color color;
        bool choose = false;
        

        // Color drwClr;
        bool _BoolRect = true;
        bool _copy=false;

        private DialogProcessor dialogProcessor = new DialogProcessor();
       

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            dialogProcessor.ReDraw(sender, e);
            if (_copy == true  && dialogProcessor.Selection!=null )
            {
               dialogProcessor.RotateRectangle(e.Graphics, dialogProcessor.Selection, 30);
               // dialogProcessor.Rotate(e.Graphics, dialogProcessor.Selection, 30);
            }
           

        }

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (slctBox.Checked)
            {
                dialogProcessor.Selection = dialogProcessor.ContainsPoint(e.Location);
                if (dialogProcessor.Selection != null)
                {
                    statusStrip1.Items[0].Text = "Последно действие: Селекция на примитив:"+dialogProcessor.Selection.ShapeName1;
                    dialogProcessor.IsDragging = true;
                    dialogProcessor.LastLocation = e.Location;
                    flowLayoutPanel1.Invalidate();


                }
              
            }           

            if (e.Button == MouseButtons.Left)
            {
             
            }
        }

        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dialogProcessor.IsDragging)
            {
                if (dialogProcessor.Selection != null) statusStrip1.Items[0].Text = "Последно действие: Влачене";
                dialogProcessor.TranslateTo(e.Location);
                flowLayoutPanel1.Invalidate();
            }


        }

        private void flowLayoutPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            dialogProcessor.IsDragging = false;
         
        }

        private void penBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            choose = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try {
                if (choose)
                {
                    Bitmap bmp = (Bitmap)pictureBox1.Image.Clone();
                    color = bmp.GetPixel(e.X, e.Y);
                    rTrack.Value = color.R;
                    aTrack.Value = color.A;
                    bTrack.Value = color.B;
                    gTrack.Value = color.G;
                    pictureBox2.BackColor = color;
                    rValue.Text = color.R.ToString();
                    gValue.Text = color.G.ToString();
                    bValue.Text = color.B.ToString();
                    aValue.Text = color.A.ToString();
                }
                else
                {
                    //да се довърши, не работи
                    color = Color.White;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Ne izlizau izvun ochertaniqta");
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            choose = false;
        }

        private void slctBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chColBtn_Click(object sender, EventArgs e)
        {

            dialogProcessor.SetfillColor(pictureBox2.BackColor);
            statusStrip1.Items[0].Text = "Последно действие: Смяна на цвета";
        }

        private void elliBtn_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomElipse();
            flowLayoutPanel1.Invalidate();
           statusStrip1.Items[0].Text = "Последно действие: Рисуване на Елипса";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void SizeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        //Shape/Pen Border Color*promenliva  ->DialogProcesor BorderColor*metod chrez (Shape selection)->RectangleShape/ DrawSelf*metod ->
        private void brdColBtn_Click(object sender, EventArgs e)
        {
           

            dialogProcessor.BorderColor(pictureBox2.BackColor);
            statusStrip1.Items[0].Text = "Последно действие: Смяна цвета на бордера ";
        }
        /// <summary>
        /// /NE BACHKA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void brdSizeBtn_Click(object sender,EventArgs e)
        {
            if (dialogProcessor.Selection!=null)
            {
                dialogProcessor.BorderSize(int.Parse(ShapeInsertParamsBox.Text.ToString()),
                    dialogProcessor.Selection.BorderColor.Color);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           


        }

        private void WidthSizeButton_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection!=null)
            {
                dialogProcessor.WidthSize(int.Parse(WidthBox.Text.ToString()));
            }
        }

        private void HeightSizeButton_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection != null)
            {
                dialogProcessor.HeightSize(int.Parse(HeightBox.Text.ToString()));
            }
        }

        private void rTrack_Scroll(object sender, EventArgs e)
        {
            color = Color.FromArgb(aTrack.Value, rTrack.Value, bTrack.Value, gTrack.Value);
            pictureBox2.BackColor = color;
            rValue.Text = color.R.ToString();
        }

        private void gTrack_Scroll(object sender, EventArgs e)
        {
            color = Color.FromArgb(aTrack.Value, rTrack.Value, bTrack.Value, gTrack.Value);
            pictureBox2.BackColor = color;
            gValue.Text = color.G.ToString();
        }

        private void bTrack_Scroll(object sender, EventArgs e)
        {
            color = Color.FromArgb(aTrack.Value, rTrack.Value, bTrack.Value, gTrack.Value);
            pictureBox2.BackColor = color;
            bValue.Text = color.B.ToString();
        }

        private void aTrack_Scroll(object sender, EventArgs e)
        {
            color = Color.FromArgb(aTrack.Value, rTrack.Value, bTrack.Value, gTrack.Value);
            pictureBox2.BackColor = color;
            aValue.Text = color.A.ToString();
        }

        private void addEllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            elliBtn_Click(sender, e);
        }

        private void newRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Panel1.Visible = true;
        }

        private void NewRectMenu_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        private void PanelFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {

                PanelFillColor.BackColor = colorDialog1.Color;
            }
        }

        private void PanelBorderColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
               // PanelFillColor.BackColor = colorDialog1.Color;
            }
        }
        private void Create_Click(object sender, EventArgs e)
        {

            //dialogProcessor.WidthSize(int.Parse(PanelWidthBox.Text.ToString()));
            // dialogProcessor.HeightSize(int.Parse(PanelHeightBox.Text.ToString()));
            // dialogProcessor.BorderColor();
            if (_BoolRect)
            {


               dialogProcessor.AddCustomRectangle(int.Parse(PanelWidthBox.Text.ToString()), int.Parse(PanelHeightBox.Text.ToString()), PanelFillColor.BackColor);
                statusStrip1.Items[0].Text = "Последно действие: Рисуване на Правоъгълник ";
                
            }
           else
            {
                dialogProcessor.AddCustomEllipse(int.Parse(PanelWidthBox.Text.ToString()), int.Parse(PanelHeightBox.Text.ToString()), PanelFillColor.BackColor);
                statusStrip1.Items[0].Text = "Последно действие: Рисуване на Елипса ";
               
            }
            PanelHeightBox.Text = "";
            PanelNameBox.Text = "";
            PanelWidthBox.Text = "";
            PanelFillColor.BackColor = Color.White;
            flowLayoutPanel1.Invalidate();
            Panel1.Visible = false;
        }

        private void newEllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _BoolRect = false;
            Panel1.Visible = true;
           
        }

        private void PanelCLoseButton_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            dialogProcessor.DeleteSelected();
            flowLayoutPanel1.Invalidate();
          
        }

        private void deleteLastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogProcessor.DeleteLastShape();
            flowLayoutPanel1.Invalidate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogProcessor.NewProject();
            flowLayoutPanel1.Invalidate();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            dialogProcessor.Copy();
            flowLayoutPanel1.Invalidate();

            //_copy = true;
            //flowLayoutPanel1.Invalidate();





        }

        private void addRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dialogProcessor.AddRandomRectangle();
            //statusStrip1.Items[0].Text = "Последно действие: Рисуване на Елипса";
            //flowLayoutPanel1.Invalidate();
            rctBtn_Click( sender,  e);
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {
            
        }

        private void rctBtn_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomRectangle();
             statusStrip1.Items[0].Text = "Последно действие: Рисуване на Елипса";
            flowLayoutPanel1.Invalidate();
        }

        private void flowLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
           
                dialogProcessor.Selection = null;
            flowLayoutPanel1.Invalidate();
            }

        private void flowLayoutPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dialogProcessor.Selection != null)
            {
                dialogProcessor.Selection = null;
            }
            flowLayoutPanel1.Invalidate();
        }

        private void shapeNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogProcessor.NameShape(ShapeInsertParamsBox.Text.ToString());

        }

        private void selectByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void Panel2ChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                dialogProcessor.CustomChange(Panel2NameSelectBox.Text.ToString(), int.Parse(PanelWidthBox.Text.ToString()),
                int.Parse(PanelHeightBox.Text.ToString()), PanelFillColor.BackColor);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Има непопълнени полета!");
                
            }
            //dialogProcessor.ByName(Panel2NameSelectBox.Text.ToString());
            //panel2.Visible = false;
            PanelHeightBox.Text = "";
            PanelNameBox.Text = "";
            PanelWidthBox.Text = "";
            PanelFillColor.BackColor = Color.White;
            flowLayoutPanel1.Invalidate();
        }

        private void PanelSelectBtn_Click(object sender, EventArgs e)
        {
            dialogProcessor.ByName(Panel2NameSelectBox.Text.ToString());

        }

        private void customChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel1.Visible=true;
            panel2.Visible = true;

        }

        private void Panel2CloseBtn_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            panel2.Visible = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dialogProcessor.SavaData();

            //string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\WriteLines.txt", true))
            //{
            //    outputFile.WriteLine(dialogProcessor.SavaData());
            //}

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            this.Activate();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.InitialDirectory = path;
            saveFileDialog1.Title = "Chose where the file will be saved:";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
           

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter s = new StreamWriter(myStream);
                    s.WriteLine(dialogProcessor.SavaData());
                    s.Close();

                    MessageBox.Show("File has been successfully saved.");
                }
            }
        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog()==DialogResult.OK)
            {
                StreamReader read = new StreamReader(File.OpenRead(open.FileName));
                string Text = read.ReadToEnd();
                dialogProcessor.LoadData(Text);
                read.Dispose();
            }
            // dialogProcessor.LoadData();
            flowLayoutPanel1.Invalidate();
        }

        private void RotateBtn_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection!=null)
            {
                _copy = true;
            }
            else
            {
                _copy = false;
            }
            flowLayoutPanel1.Invalidate();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
