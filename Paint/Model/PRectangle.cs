using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Net;

namespace Paint.Model
{
    public class PRectangle : Shape
    {
        public override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath getPath = new GraphicsPath();
                RectangleF rec = new RectangleF(Math.Min(firstPoint.X, lastPoint.X),
                            Math.Min(firstPoint.Y, lastPoint.Y),
                            Math.Abs(lastPoint.X - firstPoint.X),
                            Math.Abs(lastPoint.Y - firstPoint.Y));
                getPath.AddRectangle(rec);
                return getPath;
            }
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

        public override void moveShape(PointF distance)
        {
            firstPoint = new PointF(firstPoint.X + distance.X, firstPoint.Y + distance.Y);
            lastPoint = new PointF(lastPoint.X + distance.X, lastPoint.Y + distance.Y);
        }

        public override void Draw(Graphics myGp, Pen myPen)
        {
            using (GraphicsPath path = GetPath)
            {
                if (!isFill)
                {
                    using (myPen = new Pen(shapeColor, widthPen))
                    {
                        myPen.DashStyle = DashStyle;
                        myGp.DrawRectangle(myPen, Math.Min(this.firstPoint.X, this.lastPoint.X),
                          Math.Min(this.firstPoint.Y, this.lastPoint.Y),
                          Math.Abs(this.lastPoint.X - this.firstPoint.X),
                          Math.Abs(this.lastPoint.Y - this.firstPoint.Y));
                    }
                }
                else
                {
                    using (Brush myBrush = new SolidBrush(shapeColor))
                    {
                        myGp.FillRectangle(myBrush, Math.Min(this.firstPoint.X, this.lastPoint.X),
                          Math.Min(this.firstPoint.Y, this.lastPoint.Y),
                          Math.Abs(this.lastPoint.X - this.firstPoint.X),
                          Math.Abs(this.lastPoint.Y - this.firstPoint.Y));
                    }
                }
            }
        }

        public void CheckPoints()
        {
            PointF firstTemp = new PointF(),lastTemp = new PointF();
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

        public void DrawRectangle(Graphics graphics, Pen pen)
        {
            float x = Math.Min(firstPoint.X, lastPoint.X);
            float y = Math.Min(firstPoint.Y, lastPoint.Y);
            float width = Math.Abs(lastPoint.X - firstPoint.X);
            float height = Math.Abs(lastPoint.Y - firstPoint.Y);
            graphics.DrawRectangle(pen, x, y, width, height);
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
