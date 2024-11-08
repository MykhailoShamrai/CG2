﻿namespace CG2
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
            MainUnder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxMain).BeginInit();
            RightLayout.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrackAroundZ).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrackAroundX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackTriangulation).BeginInit();
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
    }
}
