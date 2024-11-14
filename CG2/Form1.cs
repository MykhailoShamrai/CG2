using CG2.Drawers;
using CG2.Shapes;
using System.Numerics;


namespace CG2
{
    public partial class ShapeForm : Form
    {
        public IColorer Colorer { get; set; }
        public DirectBitmap DirectBitmap { get; set; }
        public MyPlane Plane { get; set; }
        public MainDrawer MainDrawer { get; set; }
        public Vector3 LightSource { get; set; }
        public ShapeForm()
        {
            InitializeComponent();
            Colorer = new MainColorer(1.0f, 1.0f, 1);
            LightSource = new Vector3(300, 200, 1000);
            DirectBitmap = new DirectBitmap(PictureBoxMain.Width, PictureBoxMain.Height);
            PictureBoxMain.Image = DirectBitmap.Bitmap;
            Plane = new MyPlane();
            ReadStartVerticesFromFile("data.txt", Plane.ControlPoints);
            Plane.RotatedControlPoints = new List<Vector3>(Plane.ControlPoints);
            Plane.Triangularization();
            MainDrawer = new MainDrawer(Plane, DirectBitmap, Colorer);

            TrackAroundZ.Minimum = (int)Math.Round(1000 * -Math.PI / 4);
            TrackAroundZ.Maximum = (int)Math.Round(1000 * Math.PI / 4);
            TrackAroundZ.TickFrequency = 100;
            TrackAroundX.Minimum = (int)Math.Round(1000 * -Math.PI / 4);
            TrackAroundX.Maximum = (int)Math.Round(1000 * Math.PI / 4);
            TrackAroundX.TickFrequency = 100;
            trackTriangulation.Minimum = 0;
            trackTriangulation.Maximum = 4;
            trackTriangulation.Value = 0;
            PictureBoxMain_Paint(PictureBoxMain, new PaintEventArgs(Graphics.FromImage(PictureBoxMain.Image), PictureBoxMain.ClientRectangle));
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
                MainDrawer.Draw(g, LightSource);
            }
            //PictureBoxMain.Image = DirectBitmap.Bitmap;
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
    }
}
