using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Paint.Model;
using Paint.SolvingFlicker;
using System.Reflection;
using Paint.CurrentEnum;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Paint
{
    public partial class Paint : Form
    {
        Pen myPen;
        Color myColor;
        bool isPress = false;
        bool isDrawingPolygon = false;
        bool isFill;
        bool isMoving = false; //Moving shape
        PRectangle rec = new PRectangle();
        EnumShape PaintType = EnumShape.Line; // Mode of PaintType
        List<Shape> listofShape = new List<Shape>(); //List all of shapes
        List<Shape> selectedShapeList = new List<Shape>();
        bool isControlKeyPress;
        Shape currentShape;
        Shape selectShape; //Shape is selected
        Shape deleteShape; //Shape is deleted
        PointF prePoint = Point.Empty; // Previous point
        Color myRecColor = Color.CornflowerBlue;
        Pen myRec;

        public Paint()
        {
            InitializeComponent();

        }
        private void Paint_Load(object sender, EventArgs e)
        {
            this.plMain.SetDoubleBuffered();
            myColor = Color.Black;
            myPen = new Pen(myColor);
            myRec = new Pen(myRecColor, 2);
            myRec.DashStyle = DashStyle.Dash;
            myPen.Width = 3;
            tbSize.Value = (int)myPen.Width;
            setupColor();
            PaintType = EnumShape.Group;
            cbDashStyle.SelectedIndex = 0;

        }

        private void plMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (PaintType == EnumShape.Group && isControlKeyPress)
            {
                for (int i = 0; i < listofShape.Count; i++)
                {
                    if (listofShape[i].isSelect(e.Location))
                    {
                        listofShape[i].isSelected = !listofShape[i].isSelected;
                        listofShape[i].prePoint = e.Location;
                        if (listofShape[i].isSelected == true)
                        {
                            selectedShapeList.Add(listofShape[i]);
                        }
                        else
                        {
                            selectedShapeList.Remove(listofShape[i]);
                        }
                        plMain.Invalidate();
                        break;
                    }
                }
            }
            else if (PaintType == EnumShape.Select)
            {
                for (var i = listofShape.Count - 1; i >= 0; i--)
                {
                    if (listofShape[i].isSelect(e.Location))
                    {
                        selectShape = listofShape[i];
                        prePoint = e.Location;
                        isMoving = true;
                        plMain.Invalidate();
                        break;
                    }
                }
            }
            if (PaintType == EnumShape.Polygon)
            {
                this.isPress = true;
                if (this.isDrawingPolygon == false)
                {

                    currentShape = new PPolygon();
                    currentShape.shapeColor = myColor;
                    currentShape.widthPen = myPen.Width;
                    currentShape.isFill = isFill;
                    currentShape.DashStyle = DashStyleShape.GetDashStyle(Convert.ToInt32(cbDashStyle.Text));
                    ((PPolygon)this.currentShape).pointsPoly.Add(e.Location);
                    ((PPolygon)this.currentShape).pointsPoly.Add(e.Location);
                    this.listofShape.Add(currentShape);
                    this.isDrawingPolygon = true;
                }
                else
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        PPolygon polygon = listofShape[listofShape.Count - 1] as PPolygon;
                        polygon.pointsPoly.Remove(polygon.pointsPoly[polygon.pointsPoly.Count - 1]);
                        this.isDrawingPolygon = false;
                        isControlKeyPress = false;
                        this.isPress = false;
                    }
                    else
                    {
                        PPolygon currentShape = listofShape[listofShape.Count - 1] as PPolygon;
                        currentShape.pointsPoly[currentShape.pointsPoly.Count - 1] = e.Location;
                        currentShape.pointsPoly.Add(e.Location);
                    }
                }
                this.plMain.Invalidate();
            }
            else if (PaintType == EnumShape.Group)
            {
                this.isPress = true;
                rec = new PRectangle();
                rec.firstPoint = e.Location;
                rec.lastPoint = e.Location;
                this.plMain.Invalidate();
            }
            else
            {
                if (PaintType == EnumShape.Line)
                {
                    currentShape = new PLine();
                }
                else if (PaintType == EnumShape.Rec)
                {
                    currentShape = new PRectangle();
                }
                else if (PaintType == EnumShape.Ellipse)
                {
                    currentShape = new PEllipse();
                }
                else if (PaintType == EnumShape.Cirle)
                {
                    currentShape = new PCircle();
                }
                else if (PaintType == EnumShape.Arc)
                {
                    currentShape = new PArc();
                }
                if (PaintType != EnumShape.Select && PaintType != EnumShape.Group)
                {
                    currentShape.firstPoint = e.Location;
                    currentShape.shapeColor = myColor;
                    currentShape.widthPen = myPen.Width;
                    currentShape.isFill = isFill;
                    currentShape.DashStyle = DashStyleShape.GetDashStyle(Convert.ToInt32(cbDashStyle.Text));
                    this.isPress = true;
                    this.listofShape.Add(currentShape);
                }
            }
        }

        private void plMain_MouseMove(object sender, MouseEventArgs e)
        {
            //Moving
            plMain.Cursor = Cursors.Default;
            if (PaintType == EnumShape.Select || isControlKeyPress)
            {
                for (int i = 0; i < listofShape.Count; i++)
                {
                    if (listofShape[i].isSelect(e.Location))
                    {
                        plMain.Cursor = Cursors.SizeAll;
                    }
                }
            }
            if (isMoving && PaintType == EnumShape.Select)
            {
                if (selectShape != null)
                {
                    var distance = new PointF(e.X - prePoint.X, e.Y - prePoint.Y);
                    selectShape.moveShape(distance);
                    prePoint = e.Location;
                    this.plMain.Invalidate();
                }
            }
            if (isPress == false)
            {
                return;
            }
            //Paint
            if (PaintType == EnumShape.Group)
            {
                rec.lastPoint = e.Location;
                this.plMain.Refresh();
            }
            else if (this.isPress && this.currentShape is PPolygon && isDrawingPolygon)
            {
                PPolygon currentShape = listofShape[listofShape.Count - 1] as PPolygon;
                currentShape.pointsPoly[currentShape.pointsPoly.Count - 1] = e.Location;
                this.plMain.Refresh();
            }
            else if (this.isPress)
            {
                this.listofShape[this.listofShape.Count - 1].lastPoint = e.Location;
                this.plMain.Refresh();
            }
        }

        private void plMain_MouseUp(object sender, MouseEventArgs e)
        {
            //Moving
            if (isMoving && isControlKeyPress == false)
            {
                deleteShape = selectShape;
                selectShape = null;
                isMoving = false;
            }
            if (PaintType == EnumShape.Group && !isControlKeyPress)
            {
                selectedShapeList.Clear();
                for (int i = 0; i < listofShape.Count; i++)
                {
                    listofShape[i].isSelected = false;

                    if (listofShape[i] is PRectangle rect)
                    {
                        rect.CheckPoints();
                    }
                    else if (listofShape[i] is PEllipse ellipse)
                    {
                        ellipse.CheckPoints();
                    }
                    else if (listofShape[i] is PArc arc)
                    {
                        arc.CheckPoints();
                    }
                    else if (listofShape[i] is PPolygon polygon)
                    {
                        if (polygon.IsGroupSelect(rec.firstPoint, rec.lastPoint) == true)
                        {
                            polygon.isSelected = true;
                            selectedShapeList.Add(polygon);
                        }
                    }

                    if (listofShape[i].firstPoint.X < Math.Max(rec.lastPoint.X, rec.firstPoint.X)
                        && listofShape[i].firstPoint.X > Math.Min(rec.lastPoint.X, rec.firstPoint.X)
                        && listofShape[i].firstPoint.Y < Math.Max(rec.lastPoint.Y, rec.firstPoint.Y)
                        && listofShape[i].firstPoint.Y > Math.Min(rec.lastPoint.Y, rec.firstPoint.Y))
                    {
                        listofShape[i].isSelected = true;
                        selectedShapeList.Add(listofShape[i]);
                    }
                    else if (listofShape[i].lastPoint.X < Math.Max(rec.lastPoint.X, rec.firstPoint.X)
                        && listofShape[i].lastPoint.X > Math.Min(rec.lastPoint.X, rec.firstPoint.X)
                        && listofShape[i].lastPoint.Y < Math.Max(rec.lastPoint.Y, rec.firstPoint.Y)
                        && listofShape[i].lastPoint.Y > Math.Min(rec.lastPoint.Y, rec.firstPoint.Y))
                    {
                        listofShape[i].isSelected = true;
                        selectedShapeList.Add(listofShape[i]);
                    }
                }
                PointF p = new PointF(0, 0);
                rec.firstPoint = p;
                rec.lastPoint = p;
                plMain.Invalidate();
            }
            //Polygon
            if (PaintType != EnumShape.Polygon)
                isPress = false;
        }

        private void plMain_Paint(object sender, PaintEventArgs e)
        {
            if (rec != null)
                rec.DrawRectangle(e.Graphics, myRec);
            listofShape.ForEach((shape) =>
            {
                shape.Draw(e.Graphics, new Pen(shape.shapeColor, shape.widthPen));
                if (PaintType == EnumShape.Group)
                {
                    if (shape.isSelected == true)
                    {
                        if (!(shape is PLine || shape is PPolygon))
                        {
                            SelectFrame.DrawSelectFrame(e.Graphics,
                            new RectangleF(shape.firstPoint.X,
                            shape.firstPoint.Y,
                            shape.lastPoint.X - shape.firstPoint.X,
                            shape.lastPoint.Y - shape.firstPoint.Y));
                        }

                        if (shape is PLine || shape is PRectangle || shape is PEllipse || shape is PArc)
                        {
                            SelectFrame.DrawSelectPoints(e.Graphics,
                                             shape.firstPoint,
                                             shape.lastPoint);
                        }
                        else if (shape is PPolygon polygon)
                        {
                            SelectFrame.DrawSelectPointsPolygon(e.Graphics, polygon.pointsPoly);
                        }
                    }
                }
                else if (isMoving || selectShape != null)
                {
                    if (!(selectShape is PLine || shape is PPolygon))
                    {
                        SelectFrame.DrawSelectFrame(e.Graphics,
                            new RectangleF(selectShape.firstPoint.X,
                            selectShape.firstPoint.Y,
                            selectShape.lastPoint.X - selectShape.firstPoint.X,
                            selectShape.lastPoint.Y - selectShape.firstPoint.Y));
                    }
                    if (selectShape is PLine)
                    {
                        SelectFrame.DrawSelectPointsLine(e.Graphics,
                                                     selectShape.firstPoint,
                                                     selectShape.lastPoint);
                    }
                    else if (selectShape is PPolygon polygon)
                    {
                        SelectFrame.DrawSelectPointsPolygon(e.Graphics, polygon.pointsPoly);
                    }
                    else if (selectShape is PRectangle || selectShape is PEllipse || selectShape is PArc)
                    {
                        SelectFrame.DrawSelectPoints(e.Graphics,
                                                    selectShape.firstPoint,
                                                    selectShape.lastPoint);
                    }
                    if (selectShape != shape || selectShape is PLine)
                        currentShape.Draw(e.Graphics, new Pen(shape.shapeColor, shape.widthPen));
                }
            });
        }


        private void setupColor()
        {
            ptbColor.BackColor = myColor;
        }

        private void ptbeditColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ptbColor.BackColor = colorDialog.Color;
                myColor = colorDialog.Color;
            }
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            this.isPress = false;
            for (int i = 0; i < selectedShapeList.Count; i++)
            {
                selectedShapeList[i].isSelected = false;
            }
            selectedShapeList.Clear();
            PaintType = EnumShape.Group;
            this.plMain.Invalidate();
        }

        private void btnUngroup_Click(object sender, EventArgs e)
        {
            if (deleteShape is null)
            {
                MessageBox.Show("Please group first before ungroup ", "Notification");
                return;
            }
            Group group = new Group();
            group = deleteShape as Group;
            group.UnGroup(listofShape);
            listofShape.Remove(group);
            plMain.Invalidate();
            deleteShape = null;
            PaintType = EnumShape.Select;
            MessageBox.Show("Shapes are ungrouped", "Notification");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            PaintType = EnumShape.Select;
            this.plMain.Invalidate();
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete all the shapes?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                listofShape.Clear();
                plMain.Invalidate();
            }
        }

        private void btnPencil_Click(object sender, EventArgs e)
        {
            PaintType = EnumShape.Pen;
        }
        private void btnLine_Click(object sender, EventArgs e)
        {
            PaintType = EnumShape.Line;
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            PaintType = EnumShape.Ellipse;
        }

        private void btnRetangle_Click(object sender, EventArgs e)
        {
            PaintType = EnumShape.Rec;
        }
        private void btnBezier_Click(object sender, EventArgs e)
        {
            PaintType = EnumShape.Arc;
        }

        private void btnPolygon_Click(object sender, EventArgs e)
        {
            PaintType = EnumShape.Polygon;
        }
        private void btnCircle_Click(object sender, EventArgs e)
        {
            PaintType = EnumShape.Cirle;
        }
        private void tbSize_Scroll(object sender, EventArgs e)
        {
            myPen.Width = tbSize.Value;
        }
        private void btnFill_Click(object sender, EventArgs e)
        {
            if (!isFill)
            {
                this.isFill = true;
            }
            else isFill = false;
        }

        private void btnEraser_Click(object sender, EventArgs e)
        {
            if (deleteShape == null)
            {
                MessageBox.Show("Please choose a shape to delete", "Notification");
                return;
            }
            listofShape.Remove(deleteShape);
            foreach (var shape in selectedShapeList)
            {
                listofShape.Remove(shape);
            }
            selectedShapeList.Clear();
            deleteShape = null;
            plMain.Invalidate();
        }
        private void Paint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                isControlKeyPress = true;
                PaintType = EnumShape.Group;
            }
   
        }
        private void Paint_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                isControlKeyPress = false;
                if (selectedShapeList.Count > 1 && PaintType == EnumShape.Group)
                {
                    DialogResult dlr = MessageBox.Show("Do you want to group these shapes?", "Notification", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        Group group = new Group();
                        foreach (var shape in selectedShapeList)
                        {
                            group.addShape(shape);
                            listofShape.Remove(shape);
                        }
                        group.LinkShapes();
                        listofShape.Add(group);
                        group.isSelected = false;
                        selectedShapeList.Clear();
                    }
                    else
                    {
                        foreach (var shape in selectedShapeList)
                        {   
                            shape.isSelected = false;
                        }
                        selectedShapeList.Clear();
                    }
                    PaintType = EnumShape.Select;
                    plMain.Invalidate();
                }
                else
                {
                    foreach (var shape in selectedShapeList)
                    {
                        shape.isSelected = false;
                    }
                    PaintType = EnumShape.Select;
                    plMain.Invalidate();
                }
            }
        }

        private void cbDashStyle_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index != -1)
            {
                e.Graphics.DrawImage(DashStyleList.Images[e.Index], e.Bounds.Left, e.Bounds.Top);
            }
            e.DrawFocusRectangle();
        }



    }
}
