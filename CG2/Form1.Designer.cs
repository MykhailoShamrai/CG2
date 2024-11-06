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
            MainUnder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxMain).BeginInit();
            SuspendLayout();
            // 
            // MainUnder
            // 
            MainUnder.ColumnCount = 2;
            MainUnder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.56008F));
            MainUnder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.4399185F));
            MainUnder.Controls.Add(PictureBoxMain, 0, 0);
            MainUnder.Dock = DockStyle.Fill;
            MainUnder.Location = new Point(0, 0);
            MainUnder.Name = "MainUnder";
            MainUnder.RowCount = 1;
            MainUnder.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            MainUnder.Size = new Size(982, 553);
            MainUnder.TabIndex = 0;
            // 
            // PictureBoxMain
            // 
            PictureBoxMain.Dock = DockStyle.Fill;
            PictureBoxMain.Location = new Point(3, 3);
            PictureBoxMain.Name = "PictureBoxMain";
            PictureBoxMain.Size = new Size(736, 547);
            PictureBoxMain.TabIndex = 0;
            PictureBoxMain.TabStop = false;
            // 
            // ShapeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 553);
            Controls.Add(MainUnder);
            Name = "ShapeForm";
            Text = "Bezier Plane";
            MainUnder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureBoxMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel MainUnder;
        private PictureBox PictureBoxMain;
    }
}
