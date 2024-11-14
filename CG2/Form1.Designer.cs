namespace CG2
{
    partial class ShapeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainUnder = new TableLayoutPanel();
            PictureBoxMain = new PictureBox();
            RightLayout = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            TrackAroundZ = new TrackBar();
            AroundZLabel = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            AroundXLabel = new Label();
            TrackAroundX = new TrackBar();
            LevelOfTriangulation = new Label();
            trackTriangulation = new TrackBar();
            tableLayoutPanel4 = new TableLayoutPanel();
            DrawControlPointsCheck = new CheckBox();
            DrawBordersOfTrianglesCheck = new CheckBox();
            trackBar1 = new TrackBar();
            tableLayoutPanel5 = new TableLayoutPanel();
            MLabel = new Label();
            MValueLabel = new Label();
            tableLayoutPanel6 = new TableLayoutPanel();
            KdLabel = new Label();
            KdValueLabel = new Label();
            trackBar2 = new TrackBar();
            trackBar3 = new TrackBar();
            tableLayoutPanel7 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            MainUnder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxMain).BeginInit();
            RightLayout.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrackAroundZ).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrackAroundX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackTriangulation).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            tableLayoutPanel7.SuspendLayout();
            SuspendLayout();
            // 
            // MainUnder
            // 
            MainUnder.ColumnCount = 2;
            MainUnder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.56008F));
            MainUnder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.4399185F));
            MainUnder.Controls.Add(PictureBoxMain, 0, 0);
            MainUnder.Controls.Add(RightLayout, 1, 0);
            MainUnder.Dock = DockStyle.Fill;
            MainUnder.Location = new Point(0, 0);
            MainUnder.Name = "MainUnder";
            MainUnder.RowCount = 1;
            MainUnder.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            MainUnder.Size = new Size(982, 703);
            MainUnder.TabIndex = 0;
            // 
            // PictureBoxMain
            // 
            PictureBoxMain.Dock = DockStyle.Fill;
            PictureBoxMain.Location = new Point(3, 3);
            PictureBoxMain.Name = "PictureBoxMain";
            PictureBoxMain.Size = new Size(736, 697);
            PictureBoxMain.TabIndex = 0;
            PictureBoxMain.TabStop = false;
            PictureBoxMain.Paint += PictureBoxMain_Paint;
            // 
            // RightLayout
            // 
            RightLayout.ColumnCount = 2;
            RightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.4188042F));
            RightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.5811958F));
            RightLayout.Controls.Add(tableLayoutPanel1, 0, 0);
            RightLayout.Controls.Add(tableLayoutPanel4, 1, 0);
            RightLayout.Dock = DockStyle.Fill;
            RightLayout.Location = new Point(745, 3);
            RightLayout.Name = "RightLayout";
            RightLayout.RowCount = 1;
            RightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40.402195F));
            RightLayout.Size = new Size(234, 697);
            RightLayout.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.3661366F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 82.6338654F));
            tableLayoutPanel1.Size = new Size(119, 691);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(TrackAroundZ, 0, 1);
            tableLayoutPanel2.Controls.Add(AroundZLabel, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(113, 114);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // TrackAroundZ
            // 
            TrackAroundZ.Dock = DockStyle.Bottom;
            TrackAroundZ.Location = new Point(3, 72);
            TrackAroundZ.Maximum = 45;
            TrackAroundZ.Minimum = -45;
            TrackAroundZ.Name = "TrackAroundZ";
            TrackAroundZ.Size = new Size(107, 39);
            TrackAroundZ.TabIndex = 0;
            TrackAroundZ.TickFrequency = 2;
            TrackAroundZ.Scroll += TrackAroundZ_Scroll;
            // 
            // AroundZLabel
            // 
            AroundZLabel.AutoSize = true;
            AroundZLabel.Dock = DockStyle.Bottom;
            AroundZLabel.Font = new Font("Segoe UI", 9F);
            AroundZLabel.Location = new Point(3, 29);
            AroundZLabel.Name = "AroundZLabel";
            AroundZLabel.Size = new Size(107, 40);
            AroundZLabel.TabIndex = 1;
            AroundZLabel.Text = "Rotation around Z";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(AroundXLabel, 0, 0);
            tableLayoutPanel3.Controls.Add(TrackAroundX, 0, 1);
            tableLayoutPanel3.Controls.Add(LevelOfTriangulation, 0, 2);
            tableLayoutPanel3.Controls.Add(trackTriangulation, 0, 3);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 123);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 393F));
            tableLayoutPanel3.Size = new Size(113, 565);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // AroundXLabel
            // 
            AroundXLabel.AutoSize = true;
            AroundXLabel.Dock = DockStyle.Bottom;
            AroundXLabel.Font = new Font("Segoe UI", 9F);
            AroundXLabel.Location = new Point(3, 0);
            AroundXLabel.Name = "AroundXLabel";
            AroundXLabel.Size = new Size(107, 40);
            AroundXLabel.TabIndex = 0;
            AroundXLabel.Text = "Rotation around X";
            // 
            // TrackAroundX
            // 
            TrackAroundX.Dock = DockStyle.Bottom;
            TrackAroundX.Location = new Point(3, 43);
            TrackAroundX.Minimum = -10;
            TrackAroundX.Name = "TrackAroundX";
            TrackAroundX.Size = new Size(107, 34);
            TrackAroundX.TabIndex = 2;
            TrackAroundX.Scroll += TrackAroundX_Scroll;
            // 
            // LevelOfTriangulation
            // 
            LevelOfTriangulation.AutoSize = true;
            LevelOfTriangulation.Dock = DockStyle.Bottom;
            LevelOfTriangulation.Location = new Point(3, 86);
            LevelOfTriangulation.Name = "LevelOfTriangulation";
            LevelOfTriangulation.Size = new Size(107, 40);
            LevelOfTriangulation.TabIndex = 3;
            LevelOfTriangulation.Text = "Level of triangulation";
            // 
            // trackTriangulation
            // 
            trackTriangulation.Location = new Point(3, 129);
            trackTriangulation.Name = "trackTriangulation";
            trackTriangulation.Size = new Size(107, 40);
            trackTriangulation.TabIndex = 4;
            trackTriangulation.ValueChanged += trackTriangulation_ValueChanged;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(trackBar3, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel7, 0, 7);
            tableLayoutPanel4.Controls.Add(DrawControlPointsCheck, 0, 1);
            tableLayoutPanel4.Controls.Add(DrawBordersOfTrianglesCheck, 0, 2);
            tableLayoutPanel4.Controls.Add(trackBar1, 0, 4);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 3);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel6, 0, 5);
            tableLayoutPanel4.Controls.Add(trackBar2, 0, 6);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(128, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 10;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 7.23589F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 92.76411F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 391F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(103, 691);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // DrawControlPointsCheck
            // 
            DrawControlPointsCheck.AutoSize = true;
            DrawControlPointsCheck.Checked = true;
            DrawControlPointsCheck.CheckState = CheckState.Checked;
            DrawControlPointsCheck.Dock = DockStyle.Fill;
            DrawControlPointsCheck.Location = new Point(3, 8);
            DrawControlPointsCheck.Name = "DrawControlPointsCheck";
            DrawControlPointsCheck.Size = new Size(97, 64);
            DrawControlPointsCheck.TabIndex = 0;
            DrawControlPointsCheck.Text = "Draw control points";
            DrawControlPointsCheck.UseVisualStyleBackColor = true;
            DrawControlPointsCheck.CheckedChanged += DrawControlPointsCheck_CheckedChanged;
            // 
            // DrawBordersOfTrianglesCheck
            // 
            DrawBordersOfTrianglesCheck.AutoSize = true;
            DrawBordersOfTrianglesCheck.Checked = true;
            DrawBordersOfTrianglesCheck.CheckState = CheckState.Checked;
            DrawBordersOfTrianglesCheck.Dock = DockStyle.Fill;
            DrawBordersOfTrianglesCheck.Location = new Point(3, 78);
            DrawBordersOfTrianglesCheck.Name = "DrawBordersOfTrianglesCheck";
            DrawBordersOfTrianglesCheck.Size = new Size(97, 50);
            DrawBordersOfTrianglesCheck.TabIndex = 1;
            DrawBordersOfTrianglesCheck.Text = "Draw borders";
            DrawBordersOfTrianglesCheck.UseVisualStyleBackColor = true;
            DrawBordersOfTrianglesCheck.CheckedChanged += DrawBordersOfTrianglesCheck_CheckedChanged;
            // 
            // trackBar1
            // 
            trackBar1.Dock = DockStyle.Fill;
            trackBar1.Location = new Point(3, 164);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(97, 24);
            trackBar1.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 61F));
            tableLayoutPanel5.Controls.Add(MLabel, 0, 0);
            tableLayoutPanel5.Controls.Add(MValueLabel, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 134);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(97, 24);
            tableLayoutPanel5.TabIndex = 4;
            // 
            // MLabel
            // 
            MLabel.AutoSize = true;
            MLabel.Location = new Point(3, 0);
            MLabel.Name = "MLabel";
            MLabel.Size = new Size(22, 20);
            MLabel.TabIndex = 0;
            MLabel.Text = "m";
            // 
            // MValueLabel
            // 
            MValueLabel.AutoSize = true;
            MValueLabel.Dock = DockStyle.Fill;
            MValueLabel.Location = new Point(39, 0);
            MValueLabel.Name = "MValueLabel";
            MValueLabel.Size = new Size(55, 24);
            MValueLabel.TabIndex = 1;
            MValueLabel.Text = "1";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.1134033F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.8865967F));
            tableLayoutPanel6.Controls.Add(KdLabel, 0, 0);
            tableLayoutPanel6.Controls.Add(KdValueLabel, 1, 0);
            tableLayoutPanel6.Location = new Point(3, 194);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(97, 22);
            tableLayoutPanel6.TabIndex = 5;
            // 
            // KdLabel
            // 
            KdLabel.AutoSize = true;
            KdLabel.Location = new Point(3, 0);
            KdLabel.Name = "KdLabel";
            KdLabel.Size = new Size(27, 20);
            KdLabel.TabIndex = 6;
            KdLabel.Text = "Kd";
            // 
            // KdValueLabel
            // 
            KdValueLabel.AutoSize = true;
            KdValueLabel.Dock = DockStyle.Fill;
            KdValueLabel.Location = new Point(39, 0);
            KdValueLabel.Name = "KdValueLabel";
            KdValueLabel.Size = new Size(55, 22);
            KdValueLabel.TabIndex = 7;
            KdValueLabel.Text = "1";
            // 
            // trackBar2
            // 
            trackBar2.Dock = DockStyle.Fill;
            trackBar2.Location = new Point(3, 222);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(97, 23);
            trackBar2.TabIndex = 6;
            // 
            // trackBar3
            // 
            trackBar3.Dock = DockStyle.Fill;
            trackBar3.Location = new Point(3, 3);
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(97, 1);
            trackBar3.TabIndex = 7;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 61F));
            tableLayoutPanel7.Controls.Add(label1, 0, 0);
            tableLayoutPanel7.Controls.Add(label2, 1, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 251);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(97, 25);
            tableLayoutPanel7.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 0;
            label1.Text = "m";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(39, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 25);
            label2.TabIndex = 1;
            label2.Text = "1";
            // 
            // ShapeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 703);
            Controls.Add(MainUnder);
            MaximumSize = new Size(1000, 750);
            MinimumSize = new Size(1000, 750);
            Name = "ShapeForm";
            Text = "Bezier Plane";
            MainUnder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureBoxMain).EndInit();
            RightLayout.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrackAroundZ).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrackAroundX).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackTriangulation).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel MainUnder;
        private PictureBox PictureBoxMain;
        private TableLayoutPanel RightLayout;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TrackBar TrackAroundZ;
        private Label AroundZLabel;
        private Label AroundXLabel;
        private TrackBar TrackAroundX;
        private Label LevelOfTriangulation;
        private TrackBar trackTriangulation;
        private TableLayoutPanel tableLayoutPanel4;
        private CheckBox DrawControlPointsCheck;
        private CheckBox DrawBordersOfTrianglesCheck;
        private TrackBar trackBar1;
        private TableLayoutPanel tableLayoutPanel5;
        private Label MLabel;
        private Label MValueLabel;
        private TableLayoutPanel tableLayoutPanel6;
        private Label KdLabel;
        private Label KdValueLabel;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label1;
        private Label label2;
    }
}
