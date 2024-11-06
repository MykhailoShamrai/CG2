using CG2.Drawers;
using CG2.Shapes;
using System.Numerics;


namespace CG2
{
    public partial class ShapeForm : Form
    {
        public MyPlane Plane { get; set; }
        public MainDrawer MainDrawer { get; set; }

        public ShapeForm()
        {
            Plane = new MyPlane();
            InitializeComponent();
            ReadStartVerticesFromFile("data.txt", Plane.ControlPoints);
            MainDrawer = new MainDrawer(Plane);
            PictureBoxMain.Refresh();
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
                    while ((tmp = sr.ReadLine()) != null)
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
            Graphics g = e.Graphics;
            g.ScaleTransform(1, -1);
            g.TranslateTransform(PictureBoxMain.Width / 2, -PictureBoxMain.Height / 2);

            MainDrawer.Draw(g);
        }
    }
}
