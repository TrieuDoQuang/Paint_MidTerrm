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
    }
}
