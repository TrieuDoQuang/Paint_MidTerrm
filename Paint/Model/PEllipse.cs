using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Model
{
    public class PEllipse : Shape
    {

        public bool isCircle { get; set; } = false;
        public override void Draw(Graphics myGp, Pen myPen)
        {
            using (GraphicsPath path = GetPath)
            {
                if (!isFill)
                {
                    using (myPen = new Pen(shapeColor, widthPen))
                    {
                        myPen.DashStyle = DashStyle;
                        myGp.DrawEllipse(myPen, Math.Min(this.firstPoint.X, this.lastPoint.X),
                          Math.Min(this.firstPoint.Y, this.lastPoint.Y),
                          Math.Abs(this.lastPoint.X - this.firstPoint.X),
                          Math.Abs(this.lastPoint.Y - this.firstPoint.Y));
                    }
                }
                else
                {
                    using (Brush myBrush = new SolidBrush(shapeColor))
                    {
                        myGp.FillEllipse(myBrush, Math.Min(this.firstPoint.X, this.lastPoint.X),
                          Math.Min(this.firstPoint.Y, this.lastPoint.Y),
                          Math.Abs(this.lastPoint.X - this.firstPoint.X),
                          Math.Abs(this.lastPoint.Y - this.firstPoint.Y));
                    }
                }
            }
        }

        public override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                if (isCircle)
                {

                    float diameter = ((lastPoint.X - firstPoint.X) + (lastPoint.Y - firstPoint.Y)) / 2;
                    path.AddEllipse(new RectangleF(firstPoint.X, firstPoint.Y, diameter, diameter));
                    lastPoint = new PointF(firstPoint.X + diameter, firstPoint.Y + diameter);
                }
                else
                {
                    path.AddEllipse(new RectangleF(firstPoint.X, firstPoint.Y, lastPoint.X - firstPoint.X, lastPoint.Y - firstPoint.Y));
                }
                return path;
            }
        }

        public override void moveShape(PointF distance)
        {
            firstPoint = new PointF(firstPoint.X + distance.X, firstPoint.Y + distance.Y);
            lastPoint = new PointF(lastPoint.X + distance.X, lastPoint.Y + distance.Y);
        }

        public override bool isSelect(PointF point)
        {
            bool inside = false;
            using (GraphicsPath path = GetPath)
            {
                if (isFill)
                {
                    inside = path.IsVisible(point);
                }
                else
                {
                    using (Pen pen = new Pen(shapeColor, widthPen + 2))
                    {
                        inside = path.IsOutlineVisible(point, pen);
                    }
                }
            }

            return inside;
        }

        public void CheckPoints()
        {
            PointF firstTemp = new PointF(), lastTemp = new PointF();
            if (firstPoint.X < lastPoint.X && firstPoint.Y > lastPoint.Y)
            {
                firstTemp.X = firstPoint.X;
                firstTemp.Y = lastPoint.Y;

                lastTemp.X = lastPoint.X;
                lastTemp.Y = firstPoint.Y;
            }
            else if (firstPoint.X > lastPoint.X && firstPoint.Y > lastPoint.Y)
            {
                firstTemp = lastPoint;
                lastTemp = firstPoint;
            }
            else if (firstPoint.X > lastPoint.X && lastPoint.Y > firstPoint.Y)
            {
                firstTemp.X = lastPoint.X;
                firstTemp.Y = firstPoint.Y;

                lastTemp.X = firstPoint.X;
                lastTemp.Y = lastPoint.Y;
            }
            else
            {
                firstTemp = firstPoint;
                lastTemp = lastPoint;
            }
            firstPoint = firstTemp;
            lastPoint = lastTemp;
        }
    }
}
