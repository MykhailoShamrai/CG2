using System.Numerics;
using System.IO;
using System.Net;

namespace CG2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new ShapeForm());
        }

        static void ReadStartVerticesFromFile(string fileName, List<Vector3> lsitOfPoints)
        {
            using (FileStream fs = File.OpenRead($"./{fileName}"))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string tmp;
                    // TODO: End a parsing process. After I should start implementing main class for storing a shape.
                }
            }
        }
    }
}