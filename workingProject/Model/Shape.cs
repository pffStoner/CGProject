using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1.Model
{
    class Shape
    {
        #region Constructors

        public Shape()
        {
        }
        public Shape(Point point, Point point2)
        {
            this.point = point;
            this.point2 = point2;
        }

        public Shape(RectangleF rect)
        {
            rectangle = rect;
        }

        public Shape(Shape shape)
        {

        }
        #endregion

        #region Properties
       private List<string> shapeName = new List<string>();
        public List<string> ShapeName
        {
            get { return shapeName; }
            set { shapeName = value; }
        }

        private string shapeName1=" name";

        public string ShapeName1
        {
            get { return shapeName1; }
            set { shapeName1 = value; }

        }

        private string shapeType = "";

        public string ShapeType
        {
            get { return shapeType; }
            set { shapeType = value; }

        }
        /// <summary>
        /// Обхващащ правоъгълник на елемента.
        /// </summary>
        private RectangleF rectangle;

        public virtual RectangleF Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }

        }


        /// <summary>
        /// Широчина на елемента.
        /// </summary>
        public virtual float Width
        {
            get { return Rectangle.Width; }
            set { rectangle.Width = value; }
        }

        /// <summary>
        /// Височина на елемента.
        /// </summary>
        public virtual float Height
        {
            get { return Rectangle.Height; }
            set { rectangle.Height = value; }
        }

        /// <summary>
        /// Горен ляв ъгъл на елемента.
        /// </summary>
        public virtual PointF Location
        {
            get { return Rectangle.Location; }
            set { rectangle.Location = value; }
        }

        /// <summary>
        /// Цвят на елемента.
        /// </summary>
        private Color fillColor;
        public virtual Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }
        /// <summary>
        /// CVQT NA RAMKA
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private Pen borderColor;
        public virtual Pen BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }
        /// <summary>
        /// razmer na bordera 
        /// </summary>
        private float borderSize;
        public virtual float BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; }
        }

        private Point point;
        public virtual Point Point
        {
            get { return point; }
            set { point = value; }
        }

        private Point point2;
        public virtual Point Point2
        {
            get { return point2; }
            set { point2 = value; }
        }


        #endregion
        /// <summary>
        /// Проверка дали точка point принадлежи на елемента.
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Връща true, ако точката принадлежи на елемента и
        /// false, ако не пренадлежи</returns>

        public virtual bool Contains(PointF point)
        {
            return Rectangle.Contains(point.X, point.Y);
        }

        public virtual void DrawSelf(Graphics grfx)
        {
            // shape.Rectangle.Inflate(shape.BorderWidth, shape.BorderWidth);
        }

        
    }
}
