using CG2.Drawers;
using CG2.Shapes;
using System.Diagnostics;
using System.Numerics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


namespace CG2
{
    public partial class ShapeForm : Form
    {
        private DirectBitmap _imageBitmap;
        private DirectBitmap _normalMapBitmap;
        private System.Timers.Timer _timer = new System.Timers.Timer(100);
        private Color _color = Color.CadetBlue;
        public LightSourceAnimator Animator { get; set; }
        public IColorer Colorer { get; set; }
        public DirectBitmap DirectBitmap { get; set; }
        public MyPlane Plane { get; set; }
        public MainDrawer MainDrawer { get; set; }
        public LightSource LightSource { get; set; }
        public ShapeForm()
        {
            InitializeComponent();

            // Track Bars
            TrackAroundZ.Minimum = (int)Math.Round(1000 * -Math.PI / 4);
            TrackAroundZ.Maximum = (int)Math.Round(1000 * Math.PI / 4);
            TrackAroundZ.TickFrequency = 100;
            TrackAroundX.Minimum = (int)Math.Round(1000 * -Math.PI / 4);
            TrackAroundX.Maximum = (int)Math.Round(1000 * Math.PI / 4);
            TrackAroundX.TickFrequency = 100;
            trackTriangulation.Minimum = 0;
            trackTriangulation.Maximum = 4;
            trackTriangulation.Value = 0;
            trackTriangulation.TickFrequency = 1;

            trackBarM.Minimum = 0;
            trackBarM.Maximum = 100;
            trackBarM.Value = 1;
            trackBarM.TickFrequency = 1;
            // Here we have to normalize the values after, it'll important
            trackBarKd.Minimum = 0;
            trackBarKd.Maximum = 100;
            trackBarKd.Value = 100;
            trackBarKs.Minimum = 0;
            trackBarKs.Maximum = 100;
            trackBarKs.Value = 100;
            // Starting values from trackbar
            Colorer = new MainColorer(trackBarKd.Value / 100, trackBarKs.Value / 100, trackBarM.Value);
            LightSource = new LightSource { Position = new Vector3(0, 0, 1000), Color = Color.White };
            ChangeZTrack.Value = 1000;
            ZAxisValue.Text = ChangeZTrack.Value.ToString();
            Animator = new LightSourceAnimator { LightSource = LightSource, Radius = 2000, Step = 10 };
            DirectBitmap = new DirectBitmap(PictureBoxMain.Width, PictureBoxMain.Height);
            PictureBoxMain.Image = DirectBitmap.Bitmap;
            Plane = new MyPlane();
            ReadStartVerticesFromFile("data.txt", Plane.ControlPoints);
            Plane.RotatedControlPoints = new List<Vector3>(Plane.ControlPoints);
            Plane.Triangularization();
            MainDrawer = new MainDrawer(Plane, DirectBitmap, Colorer);
            ColorOfLightPanel.BackColor = LightSource.Color;
            ColorOfSurfacePanel.BackColor = _color;

            // 
            string path = Path.Combine(Directory.GetCurrentDirectory(), "images.jpg");
            _imageBitmap = ReturnImageInDirectBitmap(path);
            path = Path.Combine(Directory.GetCurrentDirectory(), "earth-normalmap.jpg");
            _normalMapBitmap = ReturnImageInDirectBitmap(path);
            Animate();
        }

        public void Animate()
        {
            _timer.Elapsed += Timer_Elapsed;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Animator.LightMove();
            PictureBoxMain.Invalidate();
        }

        static DirectBitmap ReturnImageInDirectBitmap(string fileName)
        {
            using (FileStream fs = File.OpenRead($"{fileName}"))
            {
                Bitmap tmp = new Bitmap(fs);
                DirectBitmap ret = new DirectBitmap(tmp.Width, tmp.Height);
                Graphics g = Graphics.FromImage(ret.Bitmap);
                g.DrawImageUnscaled(tmp, 0, 0);
                return ret;
            }
        }

        static void ReadStartVerticesFromFile(string fileName, List<Vector3> listOfPoints)
        {
            listOfPoints.Clear();
            using (FileStream fs = File.OpenRead($"./{fileName}"))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string tmp;
                    string[] pointTmp;
                    while ((tmp = sr.ReadLine()!) != null)
                    {
                        pointTmp = tmp.Split(',');
                        // Here must be a try/catch statement
                        listOfPoints.Add(new Vector3(float.Parse(pointTmp[0]),
                                                    float.Parse(pointTmp[1]),
                                                    float.Parse(pointTmp[2])));
                    }
                }
            }
        }


        private void PictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = Graphics.FromImage(PictureBoxMain.Image))
            {
                g.Clear(Color.WhiteSmoke);
                g.ScaleTransform(1, -1);
                g.TranslateTransform((float)PictureBoxMain.Width / 2, -(float)PictureBoxMain.Height / 2);
                MainDrawer.Draw(g, LightSource, _color);
            }
            e.Graphics.DrawImage(PictureBoxMain.Image, 0, 0);
        }

        private void TrackAroundZ_Scroll(object sender, EventArgs e)
        {
            Plane.ZAngle = (float)TrackAroundZ.Value / 1000;

            PictureBoxMain.Invalidate();
        }

        private void TrackAroundX_Scroll(object sender, EventArgs e)
        {
            Plane.XAngle = (float)TrackAroundX.Value / 1000;

            PictureBoxMain.Invalidate();
        }


        private void trackTriangulation_ValueChanged(object sender, EventArgs e)
        {
            Plane.LevelOfTriang = trackTriangulation.Value;

            PictureBoxMain.Invalidate();
        }

        private void DrawControlPointsCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.MainDrawer.DrawControlPointsBool = DrawControlPointsCheck.Checked;
            PictureBoxMain.Invalidate();
        }

        private void DrawBordersOfTrianglesCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.MainDrawer.DrawBordersBool = DrawBordersOfTrianglesCheck.Checked;
            PictureBoxMain.Invalidate();
        }

        private void trackBarM_Scroll(object sender, EventArgs e)
        {
            Colorer.M = trackBarM.Value;
            MValueLabel.Text = trackBarM.Value.ToString();
            PictureBoxMain.Invalidate();
        }

        private void trackBarKs_Scroll(object sender, EventArgs e)
        {
            Colorer.Ks = (float)trackBarKs.Value / 100;
            KsValueLabel.Text = Colorer.Ks.ToString();
            PictureBoxMain.Invalidate();
        }

        private void trackBarKd_Scroll(object sender, EventArgs e)
        {
            Colorer.Kd = (float)trackBarKd.Value / 100;
            KdValueLabel.Text = Colorer.Kd.ToString();
            PictureBoxMain.Invalidate();
        }

        private void StartAnimationButton_Click(object sender, EventArgs e)
        {
            if (StartAnimationButton.Text == "Stop")
            {
                _timer.Stop();
                StartAnimationButton.Text = "Start";
            }
            else
            {
                _timer.Start();
                StartAnimationButton.Text = "Stop";
            }
        }

        private void ChangeZTrack_Scroll(object sender, EventArgs e)
        {
            lock (LightSource)
                LightSource.Position = new Vector3(LightSource.Position.X, LightSource.Position.Y, ChangeZTrack.Value);
            ZAxisValue.Text = ChangeZTrack.Value.ToString();
            PictureBoxMain.Invalidate();
        }

        private void SetLightColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.ShowDialog();
                lock (LightSource)
                    LightSource.Color = dialog.Color;
                ColorOfLightPanel.BackColor = dialog.Color;
            }
            PictureBoxMain.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.ShowDialog();
                _color = dialog.Color;
                ColorOfSurfacePanel.BackColor = dialog.Color;
            }
            PictureBoxMain.Invalidate();
        }

        private void UseImageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UseImageCheckBox.Checked)
                Colorer.Image = _imageBitmap;
            else
                Colorer.Image = null;
            PictureBoxMain.Invalidate();
        }

        private void ChangeImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "All files (*.png;*.jpg)|*.png;*.jpg|png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = dialog.FileName;
                    _imageBitmap = ReturnImageInDirectBitmap(filePath);
                    UseImageCheckBox_CheckedChanged(sender, e);
                }
            }
        }

        private void UseNormalMapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UseNormalMapCheckBox.Checked)
                Colorer.NormalMap = _normalMapBitmap;
            else
                Colorer.NormalMap = null;
            PictureBoxMain.Invalidate();
        }

        private void ChangeNormalMapButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "All files (*.png;*.jpg)|*.png;*.jpg|png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = dialog.FileName;
                    _normalMapBitmap = ReturnImageInDirectBitmap(filePath);
                    UseNormalMapCheckBox_CheckedChanged(sender, e);
                }
            }
        }
    }
}
