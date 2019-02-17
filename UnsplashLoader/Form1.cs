using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace UnsplashLoader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string GetImages(string url)
        {
            var client = new WebClient();
            var response = client.DownloadString(url);
            return response;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            String s = GetImages("https://api.unsplash.com/photos/random?client_id=af75ff63f6f032b2637c95417a691c9bbab5a884a4f245bab3f6304bebe43147");
            dynamic images = JsonConvert.DeserializeObject(s);
            string url = images["urls"]["full"];
            textBox1.Text = url;
            pictureBox1.ImageLocation = url;
            
            //MessageBox.Show(url);
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
    }
}
