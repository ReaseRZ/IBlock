using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBlock
{
    internal class PanelAdvanced : Panel
    {
        private ListBox WebsiteList;
        private Label Header;
        private System.ComponentModel.IContainer components;
        private Label Title;
        private Label Dependency;
        private Label closeButtn;
        private Label InitButton;
        private Label Info;
        private Timer timer1;
        private TextBox inputText;

        public PanelAdvanced()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            CheckBlockWebsite();
        }
        private void CheckBlockWebsite()
        {
            var lines = File.ReadAllLines("file2.txt");
            for (int i = 0; i < lines.Length; i += 1)
            {
                WebsiteList.Items.Add(lines[i]);
            }
        }
        private void BlockWebsite(object sender, System.EventArgs arg)
        {
            String hostPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");
            System.IO.File.WriteAllText(hostPath, string.Empty);
            File.WriteAllText("file2.txt", string.Empty);
            FileStream fileStream = new FileStream("file2.txt", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(fileStream);
            foreach (object itemChecked in WebsiteList.Items)
            {
                writer.WriteLine(itemChecked.ToString());
                try
                {
                    using (System.IO.StreamWriter w = System.IO.File.AppendText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts")))
                    {
                        // clear hosts content
                        w.WriteLine("0.0.0.0 "+itemChecked.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            writer.Close();
            fileStream.Close();
            this.Info.Visible = true;
            this.timer1.Enabled = true;
        }
        private void CloseApp(object sender, System.EventArgs arg)
        {
            this.Hide();
        }
        private void TimeElapsedEnded(object sender, System.EventArgs arg)
        {
            this.Info.Visible = false;
            this.timer1.Enabled = false;
        }
        private void MouseHoverOnInitBttn(object sender, EventArgs e)
        {
            this.InitButton.BackColor = System.Drawing.Color.Gray;
        }
        private void MouseLeaveOnInitBttn(object sender, EventArgs e)
        {
            this.InitButton.BackColor = System.Drawing.Color.Black;
        }
        private void EnterText(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.WebsiteList.Items.Add(inputText.Text);
                this.inputText.Text = string.Empty;
            }
        }
        private void ClickOnWebsiteList(object sender, MouseEventArgs e)
        {
            if(this.WebsiteList.SelectedIndices.Count > 0)
            {
                this.WebsiteList.Items.RemoveAt(WebsiteList.SelectedIndices[0]);
            }
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.WebsiteList = new System.Windows.Forms.ListBox();
            this.Header = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.Dependency = new System.Windows.Forms.Label();
            this.closeButtn = new System.Windows.Forms.Label();
            this.InitButton = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.inputText = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // WebsiteList
            // 
            this.WebsiteList.BackColor = System.Drawing.Color.Black;
            this.WebsiteList.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WebsiteList.ForeColor = System.Drawing.Color.White;
            this.WebsiteList.FormattingEnabled = true;
            
            this.WebsiteList.Location = new System.Drawing.Point(212, 127);
            this.WebsiteList.Name = "WebsiteList";
            this.WebsiteList.Size = new System.Drawing.Size(220, 118);
            this.WebsiteList.TabIndex = 2;
            this.WebsiteList.MouseDoubleClick += new MouseEventHandler(ClickOnWebsiteList);
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.SystemColors.Control;
            this.Header.Location = new System.Drawing.Point(212, 91);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(315, 55);
            this.Header.TabIndex = 1;
            this.Header.Text = "Blocked Website";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(12, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(106, 39);
            this.Title.TabIndex = 3;
            this.Title.Text = "IBLOCK";
            // 
            // Dependency
            // 
            this.Dependency.AutoSize = true;
            this.Dependency.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dependency.ForeColor = System.Drawing.Color.White;
            this.Dependency.Location = new System.Drawing.Point(12, 401);
            this.Dependency.Name = "Dependency";
            this.Dependency.Size = new System.Drawing.Size(636, 39);
            this.Dependency.TabIndex = 4;
            this.Dependency.Text = "√ Advanced Menu";
            // 
            // closeButtn
            // 
            this.closeButtn.AutoSize = true;
            this.closeButtn.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButtn.ForeColor = System.Drawing.Color.White;
            this.closeButtn.Location = new System.Drawing.Point(646, 9);
            this.closeButtn.Name = "closeButtn";
            this.closeButtn.Size = new System.Drawing.Size(32, 39);
            this.closeButtn.TabIndex = 5;
            this.closeButtn.Text = "X";
            this.closeButtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeButtn.Click += new System.EventHandler(this.CloseApp);
            // 
            // InitButton
            // 
            this.InitButton.AutoSize = true;
            this.InitButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 20F);
            this.InitButton.ForeColor = System.Drawing.Color.White;
            this.InitButton.Location = new System.Drawing.Point(293, 255);
            this.InitButton.Name = "InitButton";
            this.InitButton.Size = new System.Drawing.Size(80, 48);
            this.InitButton.TabIndex = 6;
            this.InitButton.Text = "INIT";
            this.InitButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InitButton.Click += new System.EventHandler(this.BlockWebsite);
            this.InitButton.MouseLeave += new System.EventHandler(this.MouseLeaveOnInitBttn);
            this.InitButton.MouseHover += new System.EventHandler(this.MouseHoverOnInitBttn);
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Info.ForeColor = System.Drawing.Color.White;
            this.Info.Location = new System.Drawing.Point(12, 357);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(416, 39);
            this.Info.TabIndex = 7;
            this.Info.Text = "√ INIT Button have been clicked";
            this.Info.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.TimeElapsedEnded);

            this.inputText.Size = new Size(220, 50);
            this.inputText.Location = new Point(212, 230);
            this.inputText.KeyDown += new KeyEventHandler(this.EnterText);
            // 
            // MainWindow
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.Info);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.InitButton);
            this.Controls.Add(this.closeButtn);
            this.Controls.Add(this.Dependency);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.WebsiteList);
            this.Controls.Add(this.Header);
            this.Name = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
