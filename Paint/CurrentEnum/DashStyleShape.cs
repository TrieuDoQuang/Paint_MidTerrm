using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.CurrentEnum
{
    public static class DashStyleShape
    {
        public static DashStyle GetDashStyle(float n)
        {
            switch (n)
            {
                case 0:
                    return DashStyle.Solid;
                case 1:
                    return DashStyle.Dash;
                case 2:
                    return DashStyle.Dot;
                case 3:
                    return DashStyle.DashDot;
                case 4:
                    return DashStyle.DashDotDot;
                default:
                    return DashStyle.Solid;
            }
        }
    }
}
