using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WindowsFormsApplication1.Model;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json.Linq;
using MongoDB.Bson;

namespace WindowsFormsApplication1.Processors
{
    class DialogProcessor : DisplayProcessor
    {
        List<SaveShape> _data = new List<SaveShape>();

        #region Constructor

        public DialogProcessor()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Избран елемент.
        /// </summary>
        private Shape selection;
        public Shape Selection
        {
            get { return selection; }
            set { selection = value; }
        }


        /// <summary>
        /// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
        /// </summary>
        private bool isDragging;
        public bool IsDragging
        {
            get { return isDragging; }
            set { isDragging = value; }
        }

        /// <summary>
        /// Последна позиция на мишката при "влачене".
        /// Използва се за определяне на вектора на транслация.
        /// </summary>
        private PointF lastLocation;
        public PointF LastLocation
        {
            get { return lastLocation; }
            set { lastLocation = value; }
        }

        #endregion

        /// <summary>
        /// Добавя примитив - правоъгълник на произволно място върху клиентската област.
        /// </summary>
        public void AddRandomRectangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 600);
            int y = rnd.Next(100, 300);

            RectangleShape rect = new RectangleShape(new Rectangle(x, y, 100, 200));
            rect.FillColor = Color.White;
            rect.BorderColor = Pens.Black;
            // rect.Width = 100;
            //  rect.Height = 100;
            rect.ShapeType = "Rectangle";
            ShapeList.Add(rect);

        }
        public void AddCustomRectangle(string col, string col2, int x,int y,int width, int height)
        {

            RectangleShape rect = new RectangleShape(new Rectangle(x, y, width, height));
            rect.FillColor = Color.FromName(col2);
            
            Color pen = new Color();
            pen= Color.FromName(col);
            rect.BorderColor = new Pen(pen);
            rect.ShapeType = "Rectangle";
           // rect.Location = pointF;
            rect.Width = width;
            rect.Height = height;
          
            PointF xy = new PointF(x,y);
            rect.Location = xy;


            ShapeList.Add(rect);
        }
        public void AddCustomRectangle(int x, int y, Color col)
        {
            RectangleShape rect = new RectangleShape(new Rectangle(211, 100, x, y));
            rect.FillColor = col;
            rect.BorderColor = Pens.Black;
            rect.ShapeType = "Rectangle";

            ShapeList.Add(rect);
        }
      
        internal void AddRandomElipse()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 300);
            int y = rnd.Next(100, 200);

            EllipseShape elipse = new EllipseShape(new Rectangle(x, y, 100, 200));
            elipse.FillColor = Color.White;
            elipse.Width = 100;
            elipse.Height = 100;
            elipse.BorderColor = Pens.Black;
            elipse.ShapeType = "Ellipse";

            ShapeList.Add(elipse);
        }
        public void AddCustomEllipse(int x, int y, Color col)
        {
            EllipseShape elipse = new EllipseShape(new Rectangle(211, 100, x, y));
            elipse.FillColor = col;
            elipse.BorderColor = Pens.Black;
            elipse.ShapeType = "Ellipse";

            ShapeList.Add(elipse);
        }
        public void AddCustomEllipse(string col, string col2, int x, int y, int width, int height)
        {

            EllipseShape eli = new EllipseShape(new Rectangle(x, y, width, height));
            eli.FillColor = Color.FromName(col2);
            Color pen = new Color();
            pen = Color.FromName(col);
            eli.BorderColor = new Pen(pen);
            eli.ShapeType = "Rectangle";
            // rect.Location = pointF;
            eli.Width = width;
            eli.Height = height;

            PointF xy = new PointF(x, y);
            eli.Location = xy;


            ShapeList.Add(eli);
        }

        /// <summary>
        /// Проверява дали дадена точка е в елемента.
        /// Обхожда в ред обратен на визуализацията с цел намиране на
        /// "най-горния" елемент т.е. този който виждаме под мишката.
        /// </summary>
        /// <param name="point">Указана точка</param>
        /// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
        /// pomaga za vlacheneto
        public Shape ContainsPoint(PointF point)
        {
            for (int i = ShapeList.Count - 1; i >= 0; i--)
            {
                if (ShapeList[i].Contains(point))
                {
                    // ShapeList[i].FillColor = Color.Red;

                    return ShapeList[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
        /// </summary>
        /// <param name="p">Вектор на транслация.</param>
        public void TranslateTo(PointF p)
        {
            if (selection != null)
            {
                selection.Location = new PointF(selection.Location.X + p.X - lastLocation.X, selection.Location.Y + p.Y - lastLocation.Y);
                lastLocation = p;
            }
        }


        //risuva obvivkata pri selekciq
        public override void Draw(Graphics grfx)
        {
            base.Draw(grfx);
            if (selection != null)
            {
                grfx.DrawRectangle(Pens.Black, selection.Location.X - 3, selection.Location.Y - 3,
                    selection.Width + 6, selection.Height + 6);
            }
        }
        //zapulvash cvqt
        internal void SetfillColor(Color color)
        {
            if (selection != null)
            {
                selection.FillColor = color;
            }
        }

        //smenq cveta na bordera
        internal void BorderColor(Color color)
        {
            if (selection != null)
            {
                selection.BorderColor = new Pen(color);
            }
        }

        //smenq razmera na bordera
        internal void BorderSize(float size, Color color)
        {
            if (selection != null)
            {
                selection.BorderColor = new Pen(color, size);
            }
        }

        //smqna width
        internal void WidthSize(float size)
        {
            if (selection != null)
            {
                selection.Width = size;
            }
        }

        //smqna height
        internal void HeightSize(float size)
        {
            if (selection != null)
            {
                selection.Height = size;
            }
        }

       
        internal void DeleteLastShape()
        {
            if (ShapeList.Count != 0)
            {
                ShapeList.RemoveAt(ShapeList.Count - 1);

            }
        }

        internal void NewProject()
        {

            ShapeList.RemoveRange(0, ShapeList.Count);
        }
       

             private void CopyHelp(Shape shape)
        {
           
            shape.BorderColor = selection.BorderColor;
            shape.FillColor = selection.FillColor;
        }
        internal void Copy()
        {
            Shape shape = new Shape();
            if (selection != null)
            {
                shape = selection;
                if (shape.ShapeType=="Rectangle")
                {
                    shape = new RectangleShape(new Rectangle((int)shape.Location.X, (int)shape.Location.Y,
                                                                (int)shape.Width, (int)shape.Height));

                    CopyHelp(shape);
                }
                if (shape.ShapeType=="Ellipse")
                {
                    shape = new EllipseShape(new Rectangle((int)shape.Location.X, (int)shape.Location.Y,
                                                               (int)shape.Width, (int)shape.Height));
                    CopyHelp(shape);
                }

              
                ShapeList.Add(shape);
               

            }

        }
        

        public void RotateRectangle(Graphics g, Shape item, float angle)
        {
          //  RectangleShape rect= (RectangleShape)item; //=RectangleShape(new Rectangle(int.Parse(item.Rectangle.X.ToString()), int.Parse(item.Rectangle.X.ToString()),int.Parse(item.Width.ToString()), int.Parse(item.Height.ToString())));
                                                       //  EllipseShape elli;
           // ShapeList.Remove(item);
            //rect = (RectangleShape)selection;

            using (Matrix m = new Matrix())
            {
                m.RotateAt(angle, new PointF(item.Rectangle.X + (item.Width / 2),
                                          item.Rectangle.Y + (item.Height / 2)));

                g.Transform = m;

                // item.DrawSelf(g);
                g.DrawRectangle(item.BorderColor, item.Rectangle.X, item.Rectangle.Y, item.Width, item.Height);
                // rect.DrawSelf(g);
                // ShapeList.Add(rect);
               g.ResetTransform();
               

            }
           
        }//end rotate

        

        internal void DeleteSelected()
        {
            if (selection != null)
            {
                ShapeList.Remove(selection);
            }
        }


        internal void NameShape(string name)
        {
            if (selection != null)
            {
                selection.ShapeName1 = name;
                selection.ShapeName.Add(name);
            }

        }

        internal void SelectByName(string name)
        {
            foreach (string item in selection.ShapeName)
            {
                if (item == name)
                {
                    
                }
            }
        }//

        public void ByName(string name)
        {
            foreach (Shape shape in ShapeList)
            {
                if (shape.ShapeName1 == name)
                {
                    selection = shape;                   
                }
            }
        }//
        public void CustomChange(string name, float width, float height, Color border)
        {
            if (selection != null)
            {
                selection.ShapeName1 = name;

                selection.Width = width;             
                selection.Height = height;
                selection.BorderColor = new Pen(border);
            }
        }//
        public string SavaData()
        {
            bool yes = true;
            // string result;
            JArray jInner = new JArray();
            if (yes)
            {
                foreach (var item in ShapeList)
                {

                    JObject container = new JObject();
                    JProperty jTitle = new JProperty("Name", item.ShapeName1);
                    JProperty jWidht = new JProperty("Width", item.Width);
                    JProperty jHeight = new JProperty("Height", item.Height);
                    JProperty jBorderColor = new JProperty("Color", item.BorderColor.Color.Name);
                    JProperty jFillColor = new JProperty("FillColor", item.FillColor.Name);
                    JProperty jLocation = new JProperty("Location", item.Location.ToString());
                    JProperty jType = new JProperty("Type", ShapeType(item));

                    container.Add(jTitle);
                    container.Add(jType);
                    container.Add(jWidht);
                    container.Add(jHeight);
                    container.Add(jBorderColor);
                    container.Add(jFillColor);
                    container.Add(jLocation);

                    jInner.Add(container);

                    //result = jInner.ToString();

                }

            }
            return jInner.ToString();
        }//
        public string ShapeType(Shape shape)
        {
            //string type;
            if (shape.ShapeType.Contains("Rectangle"))
            {
                return "Rectangle";
            }
            if (shape.ShapeType.Contains("Ellipse"))
            {
                return "Ellipse";
            }
            return "";

        }

        internal void LoadData(string read)
        {
            BsonArray bsonArray = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonArray>(read);
            // BsonDocument bsonDocument = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(this.SavaData());
            foreach (BsonDocument item in bsonArray)
            {
                string XY = item["Location"].ToString();
                string[] separators = new string[] { " ", ",", "  " ,"=","","{","}"};
               
                string[] result = XY.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                int x;
                int y;
                int width;
                int height;
                for(int q =1;q<=result.Length;q+=2)
                {
                    int j=1;
                    j+=2;
                    x = int.Parse(result[q].ToString());
                    y = int.Parse(result[q].ToString());
                    width = int.Parse(item["Width"].ToString());
                    height = int.Parse(item["Height"].ToString());
                    PointF xyF = new PointF(x, y);
                    if (item["Type"] == "Rectangle"&&q<=bsonArray.Count)
                    {

                        AddCustomRectangle(item["Color"].ToString(), item["FillColor"].ToString(), x, y, width, height);

                    }
                    if (item["Type"] == "Ellipse" && q <= bsonArray.Count)
                    {
                        AddCustomEllipse(item["Color"].ToString(),item["FillColor"].ToString(), x, y, width, height);
                        

                    }
                }
               
            }
          // Shape myClass = JsonConvert.DeserializeObject<Shape>();
        }//edn load data
    }
}
