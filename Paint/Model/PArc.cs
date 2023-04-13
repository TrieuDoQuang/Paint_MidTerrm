using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint.Model
{
    public class PArc : Shape
    {
        public List<PointF> pointsArc = new List<PointF>();
        public int SweepAngle { get; set; }

        public override void Draw(Graphics myGp, Pen myPen)
        {
            using (GraphicsPath path = GetPath)
            {
                using (myPen = new Pen(shapeColor, widthPen))
                {
                    myPen.DashStyle = DashStyle;
                    myGp.DrawPath(myPen, path);
                }
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
                    using (Pen pen = new Pen(shapeColor, widthPen + 3))
                    {
                        inside = path.IsOutlineVisible(point, pen);
                    }
                }
            }

            return inside;
        }
        public override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                int startAngle = 0;
                int sweepAngle = -180;

                if (firstPoint.Y > lastPoint.Y) // If firstPoint is below lastPoint
                {
                    startAngle = 0;
                    sweepAngle = 180;
                }
                if (Math.Abs(lastPoint.Y - firstPoint.Y) == 0 && Math.Abs(lastPoint.X - firstPoint.X) == 0)
                {
                    RectangleF rect = new RectangleF(
                     Math.Min(firstPoint.X, lastPoint.X),
                     Math.Min(firstPoint.Y, lastPoint.Y),
                     Math.Abs(lastPoint.X - firstPoint.X + 10),
                     Math.Abs(lastPoint.Y - firstPoint.Y + 10));
                    path.AddArc(rect, startAngle, sweepAngle);
                }
                else if (Math.Abs(lastPoint.Y - firstPoint.Y) == 0)
                {
                    RectangleF rect = new RectangleF(
                     Math.Min(firstPoint.X, lastPoint.X),
                     Math.Min(firstPoint.Y, lastPoint.Y),
                     Math.Abs(lastPoint.X - firstPoint.X),
                     Math.Abs(lastPoint.Y - firstPoint.Y + 10));
                    path.AddArc(rect, startAngle, sweepAngle);
                }
                else if (Math.Abs(lastPoint.X - firstPoint.X) == 0)
                {
                    RectangleF rect = new RectangleF(
                    Math.Min(firstPoint.X, lastPoint.X),
                    Math.Min(firstPoint.Y, lastPoint.Y),
                    Math.Abs(lastPoint.X - firstPoint.X + 10),
                    Math.Abs(lastPoint.Y - firstPoint.Y));
                    path.AddArc(rect, startAngle, sweepAngle);
                }
                else
                {
                    RectangleF rect = new RectangleF(
                      Math.Min(firstPoint.X, lastPoint.X),
                      Math.Min(firstPoint.Y, lastPoint.Y),
                      Math.Abs(lastPoint.X - firstPoint.X),
                      Math.Abs(lastPoint.Y - firstPoint.Y));
                    path.AddArc(rect, startAngle, sweepAngle);
                }
                return path;
            }
        }

        public void CheckPoints()
        {
            PointF firstTemp = new PointF(), lastTemp = new PointF();
            if (firstPoint.X < lastPoint.X && firstPoint.Y > lastPoint.Y)
            {
                SweepAngle = 180;
                firstTemp.X = firstPoint.X;
                firstTemp.Y = lastPoint.Y;

                lastTemp.X = lastPoint.X;
                lastTemp.Y = firstPoint.Y;
            }
            else if (firstPoint.X > lastPoint.X && firstPoint.Y > lastPoint.Y)
            {
                SweepAngle = 180;

                firstTemp = lastPoint;
                lastTemp = firstPoint;
            }
            else if (firstPoint.X > lastPoint.X && lastPoint.Y > firstPoint.Y)
            {
                SweepAngle = -180;

                firstTemp.X = lastPoint.X;
                firstTemp.Y = firstPoint.Y;

                lastTemp.X = firstPoint.X;
                lastTemp.Y = lastPoint.Y;
            }
            else
            {
                SweepAngle = -180;

                firstTemp = firstPoint;
                lastTemp = lastPoint;
            }
            firstPoint = firstTemp;
            lastPoint = lastTemp;
        }

        public override void ZoomIn()
        {
            lastPoint.X += (lastPoint.X * (float)0.02);
            lastPoint.Y += (lastPoint.Y * (float)0.02);
            this.widthPen += widthPen * (float)0.15;
        }

        public override void ZoomOut()
        {
            lastPoint.X -= (lastPoint.X * (float)0.02);
            lastPoint.Y -= (lastPoint.Y * (float)0.02);
            this.widthPen -= widthPen * (float)0.12;
        }

    }

}
