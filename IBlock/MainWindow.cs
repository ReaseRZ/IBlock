using System;
using System.IO;
using System.Windows.Forms;

public class MainWindow : System.Windows.Forms.Form
{
    private CheckedListBox WebsiteList;
    private Label Header;
    private System.ComponentModel.IContainer components;
    private Label Title;
    private Label Dependency;
    private Label closeButtn;
    private Label InitButton;
    private string[] args = { "0.0.0.0 youtube.com www.youtube.com" ,
        "0.0.0.0 facebook.com www.facebook.com m.facebook.com",
    "0.0.0.0 twitter.com www.twitter.com" ,
    "0.0.0.0 tiktok.com www.tiktok.com",
    "0.0.0.0 telegram.org www.telegram.org web.telegram.org api.telegram.org",
    "0.0.0.0 instagram.com www.instagram.com",
    "0.0.0.0 twitch.tv www.twitch.com",
    "0.0.0.0 bilibili.com www.bilibili.com",
    "0.0.0.0 pixiv.net www.pixiv.net",
    "0.0.0.0 pinterest.com www.pinterest.com id.pinterest.com"
    };

    public MainWindow()
    {
        InitializeComponent();
    }
    private void BlockWebsite(object sender, System.EventArgs arg)
    {
        String hostPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");
        System.IO.File.WriteAllText(hostPath, string.Empty);
        foreach (object itemChecked in WebsiteList.CheckedItems)
        {
            int index = WebsiteList.Items.IndexOf(itemChecked);
            try
            {
                using (System.IO.StreamWriter w = System.IO.File.AppendText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts")))
                {
                    // clear hosts content
                    w.WriteLine(args[index]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private void CloseApp(object sender, System.EventArgs arg) 
    {
        Application.Exit();
    }
    private void InitializeComponent()
    {
            this.WebsiteList = new System.Windows.Forms.CheckedListBox();
            this.Header = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.Dependency = new System.Windows.Forms.Label();
            this.closeButtn = new System.Windows.Forms.Label();
            this.InitButton = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WebsiteList
            // 
            this.WebsiteList.BackColor = System.Drawing.Color.Black;
            this.WebsiteList.CheckOnClick = true;
            this.WebsiteList.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WebsiteList.ForeColor = System.Drawing.Color.White;
            this.WebsiteList.FormattingEnabled = true;
            this.WebsiteList.Items.AddRange(new object[] {
            "Youtube",
            "Facebook",
            "Twitter",
            "TikTok",
            "Telegram",
            "Instagram",
            "Twitch",
            "Bilibili",
            "Pixiv",
            "Pinterest"
            });
            this.WebsiteList.Location = new System.Drawing.Point(212, 127);
            this.WebsiteList.Name = "WebsiteList";
            this.WebsiteList.Size = new System.Drawing.Size(220, 118);
            this.WebsiteList.TabIndex = 2;
            this.WebsiteList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.BlockWebsite);
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.SystemColors.Control;
            this.Header.Location = new System.Drawing.Point(212, 95);
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
            this.Dependency.Size = new System.Drawing.Size(452, 39);
            this.Dependency.TabIndex = 4;
            this.Dependency.Text = "√ Name website you want to block";
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
            this.InitButton.Location = new System.Drawing.Point(286, 241);
            this.InitButton.Name = "InitButton";
            this.InitButton.Size = new System.Drawing.Size(80, 48);
            this.InitButton.TabIndex = 6;
            this.InitButton.Text = "INIT";
            this.InitButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InitButton.Click += new System.EventHandler(BlockWebsite);
            // 
            // MainWindow
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(678, 444);
            this.ControlBox = false;
            this.Controls.Add(this.InitButton);
            this.Controls.Add(this.closeButtn);
            this.Controls.Add(this.Dependency);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.WebsiteList);
            this.Controls.Add(this.Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}