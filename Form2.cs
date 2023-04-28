using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAM_GUI
{
    public partial class Form2 : Form
    {
        TextBox userInput = new TextBox();
        Label txtBoxLbl = new Label();
        Button submit = new Button();

        string SAMpath;

        int beginningWidth = 20;
        int beginningHeight = 20;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Size = new Size(200, 100);

            /*userInput.Location = new Point(beginningWidth, beginningHeight);
            userInput.Multiline = true;
            userInput.Height = 20;
            userInput.Width = 170;
            //userInput.Text = "Hello I am SAM";
            this.Controls.Add(userInput);*/

            submit.Location = new Point(beginningWidth, beginningHeight);
            submit.Text = "open";
            submit.Click += new EventHandler(submit_click);
            this.Controls.Add(submit);
        }

        private void submit_click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SAMpath = openFileDialog1.FileName;
                    /*Properties.Settings.Default.creditsValue = SAMpath;*/
                }
            }
            Console.WriteLine(SAMpath);
        }
    }
}
