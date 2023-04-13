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
    public class PLine : Shape
    {
        public override void Draw(Graphics myGp, Pen myPen)
        {
            using (myPen = new Pen(shapeColor, widthPen))
            {
                myPen.DashStyle = DashStyle;
                myGp.DrawLine(myPen, this.firstPoint, this.lastPoint);
            }
        }

        public override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath getPath = new GraphicsPath();
                getPath.AddLine(firstPoint, lastPoint);
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
                    using (Pen pen = new Pen(shapeColor, widthPen + 3))
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

        public override void ZoomIn()
        {
            float Dx = (float)(-firstPoint.Y + lastPoint.Y) / (firstPoint.X - lastPoint.X);
            if (Dx == 0)
            {
                Dx = (float)(-firstPoint.Y + lastPoint.Y) / (firstPoint.X - lastPoint.X);
            }

            if (lastPoint.X > firstPoint.X)
            {
                lastPoint = new PointF(lastPoint.X + 3, lastPoint.Y - (3 * Dx));
            }
            else
            {
                firstPoint = new PointF(firstPoint.X + 3, firstPoint.Y - (3 * Dx));
            }
            widthPen += 1;
        }
        public override void ZoomOut()
        {
            if (widthPen <= 2) return;

            float Dx = (float)(-firstPoint.Y + lastPoint.Y) / (firstPoint.X - lastPoint.X);

            if (lastPoint.X > firstPoint.X && lastPoint.X - firstPoint.X > 8)
            {
                lastPoint = new PointF(lastPoint.X - 3, lastPoint.Y + (3 * Dx));
            }
            else if (firstPoint.X - lastPoint.X > 8)
            {
                firstPoint = new PointF(firstPoint.X - 3, firstPoint.Y + (3 * Dx));
            }
            widthPen -= 1;
        }
    }
}
