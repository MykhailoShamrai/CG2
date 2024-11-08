using CG2.Drawers;
using CG2.Shapes;
using System.Numerics;


namespace CG2
{
    public partial class ShapeForm : Form
    {
        public DirectBitmap DirectBitmap { get; set; }
        public MyPlane Plane { get; set; }
        public MainDrawer MainDrawer { get; set; }

        public ShapeForm()
        {
            InitializeComponent();
            DirectBitmap = new DirectBitmap(PictureBoxMain.Width, PictureBoxMain.Height);
            PictureBoxMain.Image = DirectBitmap.Bitmap;
            Plane = new MyPlane();
            ReadStartVerticesFromFile("data.txt", Plane.ControlPoints);
            Plane.Triangularization();
            MainDrawer = new MainDrawer(Plane);

            TrackAroundZ.Minimum = (int)Math.Round(1000 * -Math.PI / 4);
            TrackAroundZ.Maximum = (int)Math.Round(1000 * Math.PI / 4);
            TrackAroundZ.TickFrequency = 100;
            TrackAroundX.Minimum = (int)Math.Round(1000 * -Math.PI / 4);
            TrackAroundX.Maximum = (int)Math.Round(1000 * Math.PI / 4);
            TrackAroundX.TickFrequency = 100;
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
                MainDrawer.Draw(g);
            }
        }

        private void TrackAroundZ_Scroll(object sender, EventArgs e)
        {
            MainDrawer.ZAngle = (float)TrackAroundZ.Value / 1000;
            Plane.ZAngle = (float)TrackAroundZ.Value / 1000;
            Refresh();
        }

        private void TrackAroundX_Scroll(object sender, EventArgs e)
        {
            MainDrawer.XAngle = (float)TrackAroundX.Value / 1000;
            Plane.XAngle = (float)TrackAroundX.Value / 1000;
            Refresh();
        }
    }
}
