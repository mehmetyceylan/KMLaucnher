using CmlLib.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMLaucnher
{
    public partial class KMLauncher : Form
    {
        public KMLauncher()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        public static string version;
        private void path()
        {
            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);
            foreach (var item in launcher.GetAllVersions())
            {
                comboBox1.Items.Add(item.Name);
            }
        }

        private void launch ()
        {
            var path = new MinecraftPath();
            CMLauncher launcher = new CMLauncher(path);
            var launcherOptions = new MLaunchOption
            {
                MaximumRamMb = 4096,
                ServerIp = "",
            };

            version = comboBox1.SelectedItem.ToString();
            var process = launcher.CreateProcess(version, launcherOptions);
            process.Start();
            Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            path();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Thread thread = new Thread(() => launch());
            thread.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
