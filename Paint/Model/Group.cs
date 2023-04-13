using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace Paint.Model
{
    public class Group : Shape
    {
        public List<Shape> shapes = new List<Shape>();

        private GraphicsPath[] graphicsPaths
        {
            get
            {
                GraphicsPath[] paths = new GraphicsPath[shapes.Count];

                for (int i = 0; i < shapes.Count; i++)
                {
                    GraphicsPath path = new GraphicsPath();
                    if (shapes[i] is PLine)
                    {
                        PLine line = (PLine)shapes[i];
                        path.AddLine(line.firstPoint, line.lastPoint);
                    }
                    else if (shapes[i] is PArc arc)
                    {
                        if (Math.Abs(arc.lastPoint.Y - arc.firstPoint.Y) == 0 && Math.Abs(arc.lastPoint.X - arc.firstPoint.X) == 0)
                        {
                            RectangleF r = new RectangleF(
                             Math.Min(arc.firstPoint.X, arc.lastPoint.X),
                             Math.Min(arc.firstPoint.Y, arc.lastPoint.Y),
                             Math.Abs(arc.lastPoint.X - arc.firstPoint.X + 10),
                             Math.Abs(arc.lastPoint.Y - arc.firstPoint.Y + 10));
                            path.AddArc(r, 0, arc.SweepAngle);
                        }
                        else if (Math.Abs(arc.lastPoint.Y - arc.firstPoint.Y) == 0)
                        {
                            RectangleF r = new RectangleF(
                             Math.Min(arc.firstPoint.X, arc.lastPoint.X),
                             Math.Min(arc.firstPoint.Y, arc.lastPoint.Y),
                             Math.Abs(arc.lastPoint.X - arc.firstPoint.X),
                             Math.Abs(arc.lastPoint.Y - arc.firstPoint.Y + 10));
                            path.AddArc(r, 0, arc.SweepAngle);
                        }
                        else if (Math.Abs(arc.lastPoint.X - arc.firstPoint.X) == 0)
                        {
                            RectangleF r = new RectangleF(
                            Math.Min(arc.firstPoint.X, arc.lastPoint.X),
                            Math.Min(arc.firstPoint.Y, arc.lastPoint.Y),
                            Math.Abs(arc.lastPoint.X - arc.firstPoint.X + 10),
                            Math.Abs(arc.lastPoint.Y - arc.firstPoint.Y));
                            path.AddArc(r, 0, arc.SweepAngle);
                        }
                        else
                        {
                            RectangleF r = new RectangleF(
                              Math.Min(arc.firstPoint.X, arc.lastPoint.X),
                              Math.Min(arc.firstPoint.Y, arc.lastPoint.Y),
                              Math.Abs(arc.lastPoint.X - arc.firstPoint.X),
                              Math.Abs(arc.lastPoint.Y - arc.firstPoint.Y));
                            path.AddArc(r, 0, arc.SweepAngle);
                        }
                    }
                    else if (shapes[i] is PEllipse)
                    {
                        PEllipse ellipse = (PEllipse)shapes[i];

                        {
                            path.AddEllipse(new RectangleF(ellipse.firstPoint.X,
                                ellipse.firstPoint.Y,
                                ellipse.lastPoint.X - ellipse.firstPoint.X,
                                ellipse.lastPoint.Y - ellipse.firstPoint.Y));
                        }
                    }
                    else if (shapes[i] is PCircle)
                    {
                        PCircle circle = (PCircle)shapes[i];
                        float r = ((circle.lastPoint.X - circle.firstPoint.X) + (circle.lastPoint.Y - circle.firstPoint.Y)) / 2;
                        path.AddEllipse(new RectangleF(circle.firstPoint.X, circle.firstPoint.Y, r, r));

                    }
                    else if (shapes[i] is PRectangle)
                    {
                        PRectangle rect = (PRectangle)shapes[i];

                        path.AddRectangle(new RectangleF(Math.Min(rect.firstPoint.X, rect.lastPoint.X),
                            Math.Min(rect.firstPoint.Y, rect.lastPoint.Y),
                            Math.Abs(rect.lastPoint.X - rect.firstPoint.X),
                            Math.Abs(rect.lastPoint.Y - rect.firstPoint.Y)));
                    }
                    else if (shapes[i] is PPolygon)
                    {
                        PPolygon polygon = (PPolygon)shapes[i];
                        path.AddPolygon(polygon.pointsPoly.ToArray());
                    }
                    paths[i] = path;
                }

                return paths;
            }
        }

        public void addShape(Shape shape)
        {
            shapes.Add(shape);
        }

        public override void Draw(Graphics myGp, Pen myPen)
        {
            GraphicsPath[] paths = graphicsPaths;
            for (int i = 0; i < paths.Length; i++)
            {
                using (GraphicsPath path = paths[i])
                {
                    if (shapes[i] is PRectangle || shapes[i] is PEllipse || shapes[i] is PPolygon || shapes[i] is PCircle)
                    {
                        if (shapes[i].isFill)
                        {
                            using (Brush brush = new SolidBrush(shapes[i].shapeColor))
                            {
                                myGp.FillPath(brush, path);
                            }
                        }
                        else
                        {
                            using (Pen pen = new Pen(shapes[i].shapeColor, shapes[i].widthPen))
                            {
                                myGp.DrawPath(pen, path);
                            }
                        }
                    }
                    else if (shapes[i] is Group)
                    {
                        Group group = (Group)shapes[i];
                        group.Draw(myGp, myPen);
                    }
                    else
                    {
                        using (Pen pen = new Pen(shapes[i].shapeColor, shapes[i].widthPen))
                        {
                            myGp.DrawPath(pen, path);
                        }
                    }
                }
            }
        }

        public override bool isSelect(PointF point)
        {

            GraphicsPath[] paths = graphicsPaths;
            for (int i = 0; i < paths.Length; i++)
            {
                using (GraphicsPath path = paths[i])
                {
                    if (shapes[i].isFill)
                    {
                        using (Brush brush = new SolidBrush(Color.Black))
                        {
                            if (path.IsVisible(point))
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        using (Pen pen = new Pen(Color.Black, widthPen + 3))
                        {
                            if (path.IsOutlineVisible(point, pen))
                            {
                                return true;
                            }
                        }
                    }

                    if (!(shapes[i] is Group))
                    {
                        using (Pen pen = new Pen(Color.Black, widthPen + 3))
                        {
                            if (path.IsOutlineVisible(point, pen))
                            {
                                return true;
                            }
                        }
                    }
                    else if (shapes[i] is Group)
                    {
                        Group group = (Group)shapes[i];
                        return group.isSelect(point);
                    }
                }
            }
            return false;
        }

        public override void moveShape(PointF distance)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i] is Group)
                {
                    Group group = (Group)shapes[i];
                    group.moveShape(distance);
                }
                else
                {
                    shapes[i].moveShape(distance);
                }
            }
            firstPoint = new PointF(firstPoint.X + distance.X, firstPoint.Y + distance.Y);
            lastPoint = new PointF(lastPoint.X + distance.X, lastPoint.Y + distance.Y);
        }

        public void LinkShapes()
        {
            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            for (int i = 0; i < this.shapes.Count; i++)
            {
                Shape shape = shapes[i];

                if (shape is PPolygon polygon)
                {
                    polygon.LinkPoints();
                }
                if (shape.firstPoint.X < minX)
                {
                    minX = shape.firstPoint.X;
                }
                if (shape.lastPoint.X < minX)
                {
                    minX = shape.lastPoint.X;
                }

                if (shape.firstPoint.Y < minY)
                {
                    minY = shape.firstPoint.Y;
                }
                if (shape.lastPoint.Y < minY)
                {
                    minY = shape.lastPoint.Y;
                }

                if (shape.firstPoint.X > maxX)
                {
                    maxX = shape.firstPoint.X;
                }
                if (shape.lastPoint.X > maxX)
                {
                    maxX = shape.lastPoint.X;
                }

                if (shape.firstPoint.Y > maxY)
                {
                    maxY = shape.firstPoint.Y;
                }
                if (shape.lastPoint.Y > maxY)
                {
                    maxY = shape.lastPoint.Y;
                }
            }

            this.firstPoint = new PointF(minX, minY);
            this.lastPoint = new PointF(maxX, maxY);
        }
        public void UnGroup(List<Shape> Shapes)
        {
            foreach (var shape in shapes)
            {
                shape.isSelected = false;
                Shapes.Add(shape);
            }
        }
        public override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                path.AddLine(firstPoint, lastPoint);
                return path;
            }
        }

        public override void ZoomIn()
        {
            foreach(Shape shape in shapes)
            {
                shape.ZoomIn();
            }
        }

        public override void ZoomOut()
        {
            foreach (Shape shape in shapes)
            {
                shape.ZoomOut();
            }
        }
    }
}
