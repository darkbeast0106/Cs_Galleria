using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galleria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] fajlok = Directory.GetFiles("Kepek");
            foreach (var fajl in fajlok)
            {
                Image kep = Image.FromFile(fajl);
                PictureBox pb = new PictureBox();
                pb.Image = kep;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Height = 100;
                pb.Width = (int)((double)kep.Width / kep.Height * pb.Height);
                //Eseménykezelőre feliratkozás.
                pb.Click += Pb_Click;
                /*
                 * lambdás megoldás:
                 */
                /*
               pb.Click += (send, args) =>
               {
                    pictureBox.Image = pb.Image; 
               };
               */
                flPanel.Controls.Add(pb);
            }
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pictureBox.Image = pb.Image; 
        }
    }
}
