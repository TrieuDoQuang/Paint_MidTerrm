using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public abstract class Shape
    {
        public PointF firstPoint;
        public PointF lastPoint;
        public Color shapeColor { get; set; }
        public float widthPen { get; set; }
        public bool isDrawing { get; set; }
        public bool isInside { get; set; }
        public bool isSelected { get; set; } = false;
        public bool isFill { get; set; }
        public DashStyle DashStyle { get; set; }

        public PointF prePoint = Point.Empty;
        public abstract bool isSelect(PointF Point);
        public abstract void moveShape(PointF distance);
        public abstract void Draw(Graphics myGp, Pen myPen);
        public abstract GraphicsPath GetPath { get; }

        public abstract void ZoomIn();
        public abstract void ZoomOut();

    }
}
