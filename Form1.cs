using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D_Connexion_Mouse
{
    public partial class Form1 : Form
    {
        public void WriteResourceToFile(string resourceName, string fileName)
        {
            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    resource.CopyTo(file);
                }
            }
        }

        Color In = ColorTranslator.FromHtml("#FF002B");
        //Color In = Color.RoyalBlue;
        Color Out = Color.White;
        Color Dark = Color.DimGray;
        String DestPath = @"C:\ProgramData\3Dconnexion\3DxWare\Cfg\Desktop_2DMouse.xml";
        //
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            if (File.Exists(DestPath))
            {
                button1.PerformClick();
            }
            else
            {
                button2.PerformClick();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderColor = In;
            button1.BackColor = In;
            button1.ForeColor = Out;

            button2.FlatAppearance.BorderColor = Dark;
            button2.BackColor = Dark;
            button2.ForeColor = Out;

            WriteResourceToFile("_3D_Connexion_Mouse.Desktop_2DMouse.xml", DestPath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.FlatAppearance.BorderColor = In;
            button2.BackColor = In;
            button2.ForeColor = Out;

            button1.FlatAppearance.BorderColor = Dark;
            button1.BackColor = Dark;
            button1.ForeColor = Out;
            if (File.Exists(DestPath))
            {
                File.Delete(DestPath);
            }
        }
    }
}
