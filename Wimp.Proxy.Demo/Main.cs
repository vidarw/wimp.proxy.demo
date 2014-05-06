using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Fiddler;


namespace Wimp.Proxy.Demo
{


    public partial class Main : Form
    {
        private static string TargetDirectory = @"C:\wimp\";
        private static MemoryStream FlacBuffer;
        private static BinaryWriter FlacWriter;

        public Main()
        {
            InitializeComponent();
            Path.Text = TargetDirectory;
            FiddlerApplication.BeforeResponse += FiddlerApplicationOnBeforeResponse;
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
        }

        private void StartFiddler_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = "Proxy started...";
            Logo.ForeColor = Color.DarkGreen;
            FiddlerApplication.Startup(8888, true, false);
        }

        private void StopFiddler_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = "Proxy stopped...";
            Logo.ForeColor = Color.Red;
            FiddlerApplication.Shutdown();
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            FiddlerApplication.Shutdown();
        }

        private void FiddlerApplicationOnBeforeResponse(Session oSession)
        {
            var name = oSession.id.ToString();
            name = name.PadLeft(5, '0');

            // Handle Wimp Normal and High
            if (oSession.host.Contains("wimpmusic.com") && oSession.oResponse.headers.ExistsAndContains("Content-Type", "audio/mp4"))
            {
                StatusLabel.Text = "Downloading AAC...";
                oSession.SaveResponseBody(TargetDirectory + name + ".m4a");
                StatusLabel.Text = "Proxy started...";
            }

            // Handle Wimp HiFi
            if (oSession.host.Contains("wimpmusic.com") && oSession.oResponse.headers.ExistsAndContains("Content-Type", "audio/flac") && oSession.oResponse.headers.Exists("Content-Range"))
            {
                //bytes 204801-614401/44464923
                var range = oSession.oResponse.headers.First(x => x.Name == "Content-Range").Value;
                var rangeStr = range.Split('-').Last().Split('/');
                var offset = int.Parse(range.Split(' ')[1].Split('-')[0]);
                var chunkEnd = int.Parse(rangeStr[0]);
                var totalSize = int.Parse(rangeStr[1]);

                // If its a first package. Prepare memory stream.
                if (offset == 0)
                {
                    StatusLabel.Text = "Downloading FLAC...";
                    FlacBuffer = new MemoryStream(new byte[totalSize]);
                    FlacWriter = new BinaryWriter(FlacBuffer);
                }

                // Add chunk to memorystream. Do nothing if we dont have a stream initialized.
                if (FlacBuffer != null)
                {
                    FlacWriter.Write(oSession.responseBodyBytes);
                }

                // When download is complete; dump memory stream to file.
                if (FlacBuffer != null && chunkEnd == (totalSize - 1))
                {
                    StatusLabel.Text = "Download completed. Saving file...";
                    FlacWriter.Flush();
                    FlacBuffer.Flush();

                    if (!Directory.Exists(TargetDirectory))
                    {
                        Directory.CreateDirectory(TargetDirectory);
                    }

                    using (FileStream file = new FileStream(TargetDirectory + name + ".flac", FileMode.Create, System.IO.FileAccess.Write))
                    {
                        byte[] bytes = FlacBuffer.ToArray();
                        file.Write(bytes, 0, bytes.Length);
                    }

                    StatusLabel.Text = "Proxy started...";
                }
            }
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            DialogResult result = this.FolderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Path.Text = this.FolderBrowserDialog.SelectedPath;
            }
        }

        private void Path_TextChanged(object sender, EventArgs e)
        {
            TargetDirectory = Path.Text;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
