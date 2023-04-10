using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Model
{
    public static class SelectFrame
    {

        static Brush movingBrush = new SolidBrush(Color.FromArgb(61, 165, 129));
        static Brush movingShadow = new SolidBrush(Color.White);
        static Pen movingFrame = new Pen(Color.FromArgb(0, 30, 81), 1.5f)
        {
            DashPattern = new float[] { 3, 3, 3, 3 },
        };
        static Pen movingFrameShadow = new Pen(Color.White, 2f)
        {
            DashPattern = new float[] { 2, 2, 2, 2 },
        };

        public static void DrawSelectPoints(Graphics graphics,  PointF point0, PointF point1)
        {
            graphics.FillEllipse(movingShadow, new RectangleF(point0.X - 5, point0.Y - 5, 12, 12));
            graphics.FillEllipse(movingShadow, new RectangleF(point1.X - 5, point1.Y - 5, 12, 12));
            graphics.FillEllipse(movingBrush, new RectangleF(point0.X - 5, point0.Y - 5, 10, 10));
            graphics.FillEllipse(movingBrush, new RectangleF(point1.X - 5, point1.Y - 5, 10, 10));
        }

        public static void DrawSelectPointsLine(Graphics graphics, PointF point0, PointF point1)
        {

            graphics.FillRectangle(movingBrush, new RectangleF(point0.X - 5, point0.Y - 5, 10, 10));
            graphics.FillRectangle(movingBrush, new RectangleF(point1.X - 5, point1.Y - 5, 10, 10));

        }

        public static void DrawSelectPointsPolygon(Graphics graphics, List<PointF> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                graphics.FillEllipse(movingBrush, new RectangleF(points[i].X - 5, points[i].Y - 5, 10, 10));
                graphics.FillEllipse(movingShadow, new RectangleF(points[i].X - 4, points[i].Y - 4, 8, 8));

            }
        }
        public static void DrawSelectFrame(Graphics graphics, RectangleF selectZone)
        {
            graphics.DrawRectangle(movingFrameShadow, selectZone.X, selectZone.Y, selectZone.Width, selectZone.Height);
            graphics.DrawRectangle(movingFrame, selectZone.X, selectZone.Y, selectZone.Width, selectZone.Height);
        }

    }
}
