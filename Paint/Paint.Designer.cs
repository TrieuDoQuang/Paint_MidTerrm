namespace Paint
{
    partial class Paint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Tools = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ptbColor = new System.Windows.Forms.PictureBox();
            this.ptbeditColor = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lb_DashStyle = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TrackBar();
            this.cbDashStyle = new System.Windows.Forms.ComboBox();
            this.lb_Size = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnPolygon = new System.Windows.Forms.Button();
            this.btnBezier = new System.Windows.Forms.Button();
            this.btnRetangle = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.btnUngroup = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSub = new System.Windows.Forms.Button();
            this.btnEraser = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.plMain = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.DashStyleList = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbeditColor)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Tools);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Tools
            // 
            resources.ApplyResources(this.Tools, "Tools");
            this.Tools.Name = "Tools";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Ivory;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.ptbColor);
            this.panel6.Controls.Add(this.ptbeditColor);
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Name = "panel6";
            // 
            // ptbColor
            // 
            resources.ApplyResources(this.ptbColor, "ptbColor");
            this.ptbColor.Name = "ptbColor";
            this.ptbColor.TabStop = false;
            // 
            // ptbeditColor
            // 
            this.ptbeditColor.BackgroundImage = global::Paint.Properties.Resources.wheel;
            resources.ApplyResources(this.ptbeditColor, "ptbeditColor");
            this.ptbeditColor.Name = "ptbeditColor";
            this.ptbeditColor.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbeditColor, resources.GetString("ptbeditColor.ToolTip"));
            this.ptbeditColor.Click += new System.EventHandler(this.ptbeditColor_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Ivory;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.lb_DashStyle);
            this.panel5.Controls.Add(this.tbSize);
            this.panel5.Controls.Add(this.cbDashStyle);
            this.panel5.Controls.Add(this.lb_Size);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // lb_DashStyle
            // 
            resources.ApplyResources(this.lb_DashStyle, "lb_DashStyle");
            this.lb_DashStyle.Name = "lb_DashStyle";
            // 
            // tbSize
            // 
            resources.ApplyResources(this.tbSize, "tbSize");
            this.tbSize.Name = "tbSize";
            this.toolTip1.SetToolTip(this.tbSize, resources.GetString("tbSize.ToolTip"));
            this.tbSize.Scroll += new System.EventHandler(this.tbSize_Scroll);
            // 
            // cbDashStyle
            // 
            this.cbDashStyle.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbDashStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDashStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDashStyle.DropDownWidth = 105;
            this.cbDashStyle.FormattingEnabled = true;
            this.cbDashStyle.Items.AddRange(new object[] {
            resources.GetString("cbDashStyle.Items"),
            resources.GetString("cbDashStyle.Items1"),
            resources.GetString("cbDashStyle.Items2"),
            resources.GetString("cbDashStyle.Items3"),
            resources.GetString("cbDashStyle.Items4")});
            resources.ApplyResources(this.cbDashStyle, "cbDashStyle");
            this.cbDashStyle.Name = "cbDashStyle";
            this.toolTip1.SetToolTip(this.cbDashStyle, resources.GetString("cbDashStyle.ToolTip"));
            this.cbDashStyle.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbDashStyle_DrawItem);
            // 
            // lb_Size
            // 
            resources.ApplyResources(this.lb_Size, "lb_Size");
            this.lb_Size.Name = "lb_Size";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Ivory;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.btnCircle);
            this.panel4.Controls.Add(this.btnPolygon);
            this.panel4.Controls.Add(this.btnBezier);
            this.panel4.Controls.Add(this.btnRetangle);
            this.panel4.Controls.Add(this.btnEllipse);
            this.panel4.Controls.Add(this.btnLine);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // btnCircle
            // 
            this.btnCircle.BackgroundImage = global::Paint.Properties.Resources.dry_clean;
            resources.ApplyResources(this.btnCircle, "btnCircle");
            this.btnCircle.Name = "btnCircle";
            this.toolTip1.SetToolTip(this.btnCircle, resources.GetString("btnCircle.ToolTip"));
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnPolygon
            // 
            resources.ApplyResources(this.btnPolygon, "btnPolygon");
            this.btnPolygon.Name = "btnPolygon";
            this.toolTip1.SetToolTip(this.btnPolygon, resources.GetString("btnPolygon.ToolTip"));
            this.btnPolygon.UseVisualStyleBackColor = true;
            this.btnPolygon.Click += new System.EventHandler(this.btnPolygon_Click);
            // 
            // btnBezier
            // 
            this.btnBezier.BackgroundImage = global::Paint.Properties.Resources.Arc;
            resources.ApplyResources(this.btnBezier, "btnBezier");
            this.btnBezier.Name = "btnBezier";
            this.toolTip1.SetToolTip(this.btnBezier, resources.GetString("btnBezier.ToolTip"));
            this.btnBezier.UseVisualStyleBackColor = true;
            this.btnBezier.Click += new System.EventHandler(this.btnBezier_Click);
            // 
            // btnRetangle
            // 
            resources.ApplyResources(this.btnRetangle, "btnRetangle");
            this.btnRetangle.Name = "btnRetangle";
            this.toolTip1.SetToolTip(this.btnRetangle, resources.GetString("btnRetangle.ToolTip"));
            this.btnRetangle.UseVisualStyleBackColor = true;
            this.btnRetangle.Click += new System.EventHandler(this.btnRetangle_Click);
            // 
            // btnEllipse
            // 
            resources.ApplyResources(this.btnEllipse, "btnEllipse");
            this.btnEllipse.Name = "btnEllipse";
            this.toolTip1.SetToolTip(this.btnEllipse, resources.GetString("btnEllipse.ToolTip"));
            this.btnEllipse.UseVisualStyleBackColor = true;
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnLine
            // 
            resources.ApplyResources(this.btnLine, "btnLine");
            this.btnLine.Name = "btnLine";
            this.toolTip1.SetToolTip(this.btnLine, resources.GetString("btnLine.ToolTip"));
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Ivory;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Controls.Add(this.btnSelect);
            this.panel2.Controls.Add(this.btnGroup);
            this.panel2.Controls.Add(this.btnUngroup);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // btnDel
            // 
            resources.ApplyResources(this.btnDel, "btnDel");
            this.btnDel.Name = "btnDel";
            this.toolTip1.SetToolTip(this.btnDel, resources.GetString("btnDel.ToolTip"));
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSelect
            // 
            resources.ApplyResources(this.btnSelect, "btnSelect");
            this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSelect.Name = "btnSelect";
            this.toolTip1.SetToolTip(this.btnSelect, resources.GetString("btnSelect.ToolTip"));
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnGroup
            // 
            resources.ApplyResources(this.btnGroup, "btnGroup");
            this.btnGroup.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGroup.Name = "btnGroup";
            this.toolTip1.SetToolTip(this.btnGroup, resources.GetString("btnGroup.ToolTip"));
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnUngroup
            // 
            resources.ApplyResources(this.btnUngroup, "btnUngroup");
            this.btnUngroup.Name = "btnUngroup";
            this.toolTip1.SetToolTip(this.btnUngroup, resources.GetString("btnUngroup.ToolTip"));
            this.btnUngroup.UseVisualStyleBackColor = true;
            this.btnUngroup.Click += new System.EventHandler(this.btnUngroup_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Ivory;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnSub);
            this.panel3.Controls.Add(this.btnEraser);
            this.panel3.Controls.Add(this.btnPlus);
            this.panel3.Controls.Add(this.btnFill);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // btnSub
            // 
            this.btnSub.BackgroundImage = global::Paint.Properties.Resources.Zoom_out;
            resources.ApplyResources(this.btnSub, "btnSub");
            this.btnSub.Name = "btnSub";
            this.toolTip1.SetToolTip(this.btnSub, resources.GetString("btnSub.ToolTip"));
            this.btnSub.UseVisualStyleBackColor = true;
            // 
            // btnEraser
            // 
            this.btnEraser.BackgroundImage = global::Paint.Properties.Resources.Eraser;
            resources.ApplyResources(this.btnEraser, "btnEraser");
            this.btnEraser.Name = "btnEraser";
            this.toolTip1.SetToolTip(this.btnEraser, resources.GetString("btnEraser.ToolTip"));
            this.btnEraser.UseVisualStyleBackColor = true;
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.BackgroundImage = global::Paint.Properties.Resources.Zoom_in;
            resources.ApplyResources(this.btnPlus, "btnPlus");
            this.btnPlus.Name = "btnPlus";
            this.toolTip1.SetToolTip(this.btnPlus, resources.GetString("btnPlus.ToolTip"));
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPencil_Click);
            // 
            // btnFill
            // 
            resources.ApplyResources(this.btnFill, "btnFill");
            this.btnFill.Name = "btnFill";
            this.toolTip1.SetToolTip(this.btnFill, resources.GetString("btnFill.ToolTip"));
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // plMain
            // 
            resources.ApplyResources(this.plMain, "plMain");
            this.plMain.Name = "plMain";
            this.plMain.Paint += new System.Windows.Forms.PaintEventHandler(this.plMain_Paint);
            this.plMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.plMain_MouseDown);
            this.plMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.plMain_MouseMove);
            this.plMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.plMain_MouseUp);
            // 
            // DashStyleList
            // 
            this.DashStyleList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DashStyleList.ImageStream")));
            this.DashStyleList.TransparentColor = System.Drawing.Color.Transparent;
            this.DashStyleList.Images.SetKeyName(0, "dash0.png");
            this.DashStyleList.Images.SetKeyName(1, "dash1.png");
            this.DashStyleList.Images.SetKeyName(2, "dash2.png");
            this.DashStyleList.Images.SetKeyName(3, "dash3.png");
            this.DashStyleList.Images.SetKeyName(4, "dash4.png");
            // 
            // Paint
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Paint";
            this.Load += new System.EventHandler(this.Paint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Paint_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Paint_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbeditColor)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar tbSize;
        private System.Windows.Forms.Label lb_Size;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox ptbColor;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnPolygon;
        private System.Windows.Forms.Button btnBezier;
        private System.Windows.Forms.Button btnRetangle;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnUngroup;
        private System.Windows.Forms.PictureBox ptbeditColor;
        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnEraser;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.ComboBox cbDashStyle;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lb_DashStyle;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ImageList DashStyleList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Tools;
    }
}

