using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Reflection;

namespace Paint.Model
{
    public class PPolygon : Shape
    {
        public List<PointF> pointsPoly = new List<PointF>();

        public PPolygon()
        {
            this.pointsPoly = new List<PointF>();
        }
        public override void Draw(Graphics myGp, Pen myPen)
        {
            using (GraphicsPath path = this.GetPath)
            {
                if (!this.isFill)
                {
                    using (myPen = new Pen(shapeColor, widthPen))
                    {
                        myPen.DashStyle = DashStyle;
                        myGp.DrawPath(myPen, path);

                    }
                }
                else
                {
                    using (Brush myBrush = new SolidBrush(shapeColor))
                    {
                        if (pointsPoly.Count < 3)
                        {
                            using (myPen = new Pen(shapeColor, widthPen))
                            {
                                myGp.DrawPath(myPen, path);
                            }
                        }
                        else
                        {
                            myGp.FillPath(myBrush, path);
                        }
                    }
                }
            }
        }

        public override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                if (pointsPoly.Count < 3)
                {
                    path.AddLine(pointsPoly[0], pointsPoly[1]);
                }
                else
                {
                    path.AddPolygon(pointsPoly.ToArray());
                }
                return path;
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
            for (int i = 0; i < pointsPoly.Count; i++)
            {
                pointsPoly[i] = new PointF(pointsPoly[i].X + distance.X, pointsPoly[i].Y + distance.Y);
            }
        }

        public void LinkPoints()
        {
            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            this.pointsPoly.ForEach(p =>
            {
                if (minX > p.X) { minX = p.X; }
                if (minY > p.Y) { minY = p.Y; }
                if (maxX < p.X) { maxX = p.X; }
                if (maxY < p.Y) { maxY = p.Y; }
            });
            firstPoint = new PointF(minX, minY);
            lastPoint = new PointF(maxX, maxY);
        }

        public bool IsGroupSelect(PointF p1, PointF p2)
        {
            for (int i = 0; i < pointsPoly.Count; i++)
            {
                if (pointsPoly[i].X < Math.Max(p2.X, p1.X)
                        && pointsPoly[i].X > Math.Min(p2.X, p1.X)
                        && pointsPoly[i].Y < Math.Max(p2.Y, p1.Y)
                        && pointsPoly[i].Y > Math.Min(p2.Y, p1.Y))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
