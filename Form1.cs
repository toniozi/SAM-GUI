using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SAM_GUI
{
    public partial class Form1 : Form
    {
        string SAMPath = "C:/Users/hygia/Documents/SAM/sam.exe";

        int beginningWidth = 20;
        int beginningHeight = 20;

        TextBox userInput = new TextBox();

        Button enter = new Button();

        Label speedLbl = new Label();
        TrackBar speedSlider = new TrackBar();

        Label pitchLbl = new Label();
        TrackBar pitchSlider = new TrackBar();

        Label throatLbl = new Label();
        TrackBar throatSlider = new TrackBar();

        Label mouthLbl = new Label();
        TrackBar mouthSlider = new TrackBar();

        Label listLbl = new Label();
        ListBox options = new ListBox();
        MenuStrip menu = new MenuStrip();

        //Font font = new Font("C:/Users/hygia/Documents/Font/commodore_64/Commodore-64-v6.3.ttf");
        Color background = Color.FromArgb(124, 113, 218);
        Color foreground = Color.FromArgb(62, 50, 162);

        public Form1()
        {       
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "SAM GUI";
            //string ico = "resources/sam.ico";
            this.Icon = new Icon("../../resources/sam.ico");
            this.BackColor = background;            
            //this.BackColor = Color.Black;

            userInput.Location = new Point(beginningWidth, beginningHeight);
            userInput.Multiline = true;
            userInput.Height = 20;
            userInput.Width = 170;
            //userInput.Text = "Hello I am SAM";
            this.Controls.Add(userInput);


            enter.Location = new Point(userInput.Width + 30, userInput.Height);
            enter.Text = "Read";
            enter.Margin = new Padding(0, 0, 0, 0);
            //enter.Font = font;
            enter.BackColor = foreground;
            enter.Click += new EventHandler(enter_click);

            this.Controls.Add(enter);


            speedSlider.Location = new Point(beginningWidth, userInput.Height + 40);
            speedSlider.Name = "Speed";
            speedSlider.Width = 170;
            speedSlider.Minimum = 1;
            speedSlider.Maximum = 200;
            speedSlider.Value = 72;
            speedSlider.TickFrequency = 20;
            speedSlider.Visible = true;
            speedSlider.Scroll += new EventHandler(speedSlider_Scroll);
            this.Controls.Add(speedSlider);


            speedLbl.Text = "Speed : 72";
            speedLbl.Location = new Point(speedSlider.Width+30, speedSlider.Height+20);

            speedLbl.BackColor = Color.Transparent;
            this.Controls.Add(speedLbl);

            pitchSlider.Location = new Point(beginningWidth, speedSlider.Height + 60);
            pitchSlider.Name = "Pitch";
            pitchSlider.Width = 170;
            pitchSlider.Minimum = 1;
            pitchSlider.Maximum = 200;
            pitchSlider.Value = 64;
            pitchSlider.TickFrequency = 20;
            pitchSlider.Visible = true;
            pitchSlider.Scroll += new EventHandler(pitchSlider_Scroll);
            this.Controls.Add(pitchSlider);


            pitchLbl.Text = "Pitch : 64";
            pitchLbl.Location = new Point(pitchSlider.Width + 30, pitchSlider.Height + 65);
            this.Controls.Add(pitchLbl);

            throatSlider.Location = new Point(beginningWidth, pitchSlider.Height + 115);
            throatSlider.Name = "Pitch";
            throatSlider.Width = 170;
            throatSlider.Minimum = 1;
            throatSlider.Maximum = 200;
            throatSlider.Value = 128;
            throatSlider.TickFrequency = 20;
            throatSlider.Visible = true;
            throatSlider.Scroll += new EventHandler(throatSlider_Scroll);
            this.Controls.Add(throatSlider);


            throatLbl.Text = "Throat : 128";
            throatLbl.Location = new Point(pitchSlider.Width + 30, pitchSlider.Height + 120);
            this.Controls.Add(throatLbl);

            mouthSlider.Location = new Point(beginningWidth, throatSlider.Height + 175);
            mouthSlider.Name = "Pitch";
            mouthSlider.Width = 170;
            mouthSlider.Minimum = 1;
            mouthSlider.Maximum = 200;
            mouthSlider.Value = 128;
            mouthSlider.TickFrequency = 20;
            mouthSlider.Visible = true;
            mouthSlider.Scroll += new EventHandler(mouthSlider_Scroll);
            this.Controls.Add(mouthSlider);


            mouthLbl.Text = "Mouth : 128";
            mouthLbl.Location = new Point(pitchSlider.Width + 30, mouthSlider.Height + 180);
            this.Controls.Add(mouthLbl);


            listLbl.Location=new Point(enter.Width + 300, beginningHeight);
            listLbl.Text = "Presets";
            this.Controls.Add(listLbl);


            options.Location = new Point(enter.Width + 300, listLbl.Height+20);
            options.Text = "Options";
            options.Items.Add("SAM");
            options.Items.Add("Elf");
            options.Items.Add("Little Robot");
            options.Items.Add("Stuffy Guy");
            options.Items.Add("Little Old Lady");
            options.Items.Add("Extra-Terrestrial");
            this.Controls.Add(options);
            options.SelectedValueChanged += new EventHandler(options_SelectedValueChanged);

            //menu.Location = new Point(enter.Width + 300, beginningHeight);
            menu.Text = "prout";
            menu.Dock = DockStyle.Right;
            this.Controls.Add(menu);
        }

        private void enter_click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            string firstPart = "/C "+SAMPath;
            string args = "-speed " + speedSlider.Value.ToString() + " -pitch " + pitchSlider.Value.ToString() + " -throat " + throatSlider.Value.ToString() + " -mouth " + mouthSlider.Value.ToString(); ; 
            string secondPart = userInput.Text;
            startInfo.Arguments = firstPart+" "+args +" "+secondPart;
            Console.WriteLine(firstPart + " " + secondPart);
            process.StartInfo = startInfo;
            process.Start();
        }

        private void speedSlider_Scroll(object sender, EventArgs e)
        {
            speedLbl.Text= "Speed : " + speedSlider.Value.ToString();
        }

        private void pitchSlider_Scroll(object sender, EventArgs e)
        {
            pitchLbl.Text = "Pitch : " + pitchSlider.Value.ToString();
        }

        private void throatSlider_Scroll(object sender, EventArgs e)
        {
            throatLbl.Text = "Throat : " + throatSlider.Value.ToString();
        }

        private void mouthSlider_Scroll(object sender, EventArgs e)
        {
            mouthLbl.Text = "Mouth : " + mouthSlider.Value.ToString();
        }
        private void options_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (options.SelectedItem.ToString())
            {
                case "SAM":
                    speedSlider.Value = 72;
                    speedLbl.Text = "Speed : 72";
                    pitchSlider.Value = 64;
                    pitchLbl.Text = "Pitch : 64";
                    throatSlider.Value = 128;
                    throatLbl.Text = "Throat : 128";
                    mouthSlider.Value = 128;
                    mouthLbl.Text = "Mouth : 128";
                    break;
                case "Elf":
                    speedSlider.Value = 72;
                    speedLbl.Text = "Speed : 72";
                    pitchSlider.Value = 64;
                    pitchLbl.Text = "Pitch : 64";
                    throatSlider.Value = 110;
                    throatLbl.Text = "Throat : 110";
                    mouthSlider.Value = 160;
                    mouthLbl.Text = "Mouth : 160";
                    break;
                case "Little Robot":
                    speedSlider.Value = 92;
                    speedLbl.Text = "Speed : 92";
                    pitchSlider.Value = 60;
                    pitchLbl.Text = "Pitch : 60";
                    throatSlider.Value = 190;
                    throatLbl.Text = "Throat : 190";
                    mouthSlider.Value = 190;
                    mouthLbl.Text = "Mouth : 190";
                    break;
                case "Stuffy Guy":
                    speedSlider.Value = 82;
                    speedLbl.Text = "Speed : 82";
                    pitchSlider.Value = 72;
                    pitchLbl.Text = "Pitch : 72";
                    throatSlider.Value = 110;
                    throatLbl.Text = "Throat : 110";
                    mouthSlider.Value = 190;
                    mouthLbl.Text = "Mouth : 190";
                    break;
                case "Little Old Lady":
                    speedSlider.Value = 82;
                    speedLbl.Text = "Speed : 82";
                    pitchSlider.Value = 32;
                    pitchLbl.Text = "Pitch : 32";
                    throatSlider.Value = 145;
                    throatLbl.Text = "Throat : 145";
                    mouthSlider.Value = 145;
                    mouthLbl.Text = "Mouth : 145";
                    break;
                case "Extra-Terrestrial":
                    speedSlider.Value = 100;
                    speedLbl.Text = "Speed : 100";
                    pitchSlider.Value = 64;
                    pitchLbl.Text = "Pitch : 64";
                    throatSlider.Value = 150;
                    throatLbl.Text = "Throat : 150";
                    mouthSlider.Value = 200;
                    mouthLbl.Text = "Mouth : 200";
                    break;
            }
            /*if (options.SelectedItem.ToString() == "SAM"){
                speedSlider.Value = 72;
                speedLbl.Text = "Speed : 72";
                pitchSlider.Value = 64;
                pitchLbl.Text = "Pitch : 64";
                throatSlider.Value = 128;
                throatLbl.Text = "Throat : 128";
                mouthSlider.Value = 128;
                mouthLbl.Text = "Mouth : 128";
            }
            else if (options.SelectedItem.ToString() == "Elf")
            {
                speedSlider.Value = 72;
                speedLbl.Text = "Speed : 72";
                pitchSlider.Value = 64;
                pitchLbl.Text = "Pitch : 64";
                throatSlider.Value = 110;
                throatLbl.Text = "Throat : 110";
                mouthSlider.Value = 160;
                mouthLbl.Text = "Mouth : 160";
            }
            else if (options.SelectedItem.ToString() == "Little Robot")
            {
                speedSlider.Value = 92;
                speedLbl.Text = "Speed : 92";
                pitchSlider.Value = 60;
                pitchLbl.Text = "Pitch : 60";
                throatSlider.Value = 190;
                throatLbl.Text = "Throat : 190";
                mouthSlider.Value = 190;
                mouthLbl.Text = "Mouth : 190";
            }
            else if (options.SelectedItem.ToString() == "Stuffy Guy")
            {
                speedSlider.Value = 82;
                speedLbl.Text = "Speed : 82";
                pitchSlider.Value = 72;
                pitchLbl.Text = "Pitch : 72";
                throatSlider.Value = 110;
                throatLbl.Text = "Throat : 110";
                mouthSlider.Value = 190;
                mouthLbl.Text = "Mouth : 190";
            }
            else if (options.SelectedItem.ToString() == "Little Old Lady")
            {
                speedSlider.Value = 82;
                speedLbl.Text = "Speed : 82";
                pitchSlider.Value = 32;
                pitchLbl.Text = "Pitch : 32";
                throatSlider.Value = 145;
                throatLbl.Text = "Throat : 145";
                mouthSlider.Value = 145;
                mouthLbl.Text = "Mouth : 145";
            }
            else if (options.SelectedItem.ToString() == "Extra-Terrestrial")
            {
                speedSlider.Value = 100;
                speedLbl.Text = "Speed : 100";
                pitchSlider.Value = 64;
                pitchLbl.Text = "Pitch : 64";
                throatSlider.Value = 150;
                throatLbl.Text = "Throat : 150";
                mouthSlider.Value = 200;
                mouthLbl.Text = "Mouth : 200";
            }*/
            /*list0 =[72, 64, 128, 128]    #SAM
            list1 =[72, 64, 110, 160]    #Elf
            list2 =[92, 60, 190, 190]    #Little Robot
            list3 =[82, 72, 110, 105]    #Stuffy Guy
            list4 =[82, 32, 145, 145]    #Little Old Lady
            list5 =[100, 64, 150, 200]   #Extra-Terrestrial*/
        }
    }
}
