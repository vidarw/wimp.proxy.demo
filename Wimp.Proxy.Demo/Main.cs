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
            StartFiddler.Enabled = false;
            StopFiddler.Enabled = true;
        }

        private void StopFiddler_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = "Proxy stopped...";
            Logo.ForeColor = Color.Red;
            FiddlerApplication.Shutdown();
            StopFiddler.Enabled = false;
            StartFiddler.Enabled = true;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            FiddlerApplication.Shutdown();
        }

        delegate void SetTextCallback(string text);
        private void SetStatusLabel(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.Status.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetStatusLabel);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.StatusLabel.Text = text;
            }
        }

        delegate void SetProgressCallback(int progress);
        private void SetProgress(int progress)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.Status.InvokeRequired)
            {
                SetProgressCallback d = new SetProgressCallback(SetProgress);
                this.Invoke(d, new object[] { progress });
            }
            else
            {
                this.Progress.Value = progress;
            }
        }

        private void FiddlerApplicationOnBeforeResponse(Session oSession)
        {
            var name = oSession.id.ToString();
            name = name.PadLeft(5, '0');

            // Handle Wimp Normal and High
            if (oSession.host.Contains("wimpmusic.com") && oSession.oResponse.headers.ExistsAndContains("Content-Type", "audio/mp4"))
            {
                SetProgress(0);
                SetStatusLabel("Downloading AAC...");
                oSession.SaveResponseBody(TargetDirectory + name + ".m4a");
                SetStatusLabel("Proxy started...");
                SetProgress(100);
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
                    SetStatusLabel("Downloading FLAC...");
                    SetProgress(0);
                    FlacBuffer = new MemoryStream(new byte[totalSize]);
                    FlacWriter = new BinaryWriter(FlacBuffer);
                }

                // Add chunk to memorystream. Do nothing if we dont have a stream initialized.
                if (FlacBuffer != null)
                {
                    SetProgress((int)Math.Floor((double)chunkEnd / (double)totalSize * 100.0));
                    FlacWriter.Write(oSession.responseBodyBytes);
                }

                // When download is complete; dump memory stream to file.
                if (FlacBuffer != null && chunkEnd == (totalSize - 1))
                {
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

                    SetProgress(0);
                    SetStatusLabel("Download completed...");

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
