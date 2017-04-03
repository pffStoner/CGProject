using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1.Model
{
    class RectangleShape:Shape
    {
        #region Constructor
        //za suzdavane na novi pravougulnici
        public RectangleShape(RectangleF rect) : base(rect)
        {
            
        }

        //izlishen za momenta
        public RectangleShape(RectangleShape rectangle) : base(rectangle)
        {
        }

        #endregion

        /// <summary>
        /// Проверка за принадлежност на точка point към правоъгълника.
        /// В случая на правоъгълник този метод може да не бъде пренаписван, защото
        /// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
        /// елемента в този случай).
        /// ne prai nsh :D za momenta :D
        /// </summary>
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
                // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
                // В случая на правоъгълник - директно връщаме true
                return true;
            else
                // Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
                return false;
        }

       

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// risuva
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {

            base.DrawSelf(grfx);

            grfx.FillRectangle(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawRectangle(BorderColor, Rectangle.X, Rectangle.Y, Width, Height);

          
        }

      

    }
}
