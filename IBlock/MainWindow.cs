using IBlock;
using System;
using System.IO;
using System.Windows.Forms;

public class MainWindow : System.Windows.Forms.Form
{
    private PanelDefault panelDefault;
    private PanelAdvanced panelAdvanced;
    private Button defaultBttn;
    private Button advancedBttn;
    private Label IBLOCKLabel;
    private Button QuitBttn;

    private void ClickDefault(object sender, EventArgs e)
    {
        panelDefault.Show();
    }
    private void ClickQuit(object sender, EventArgs e)
    {
        Application.Exit();
    }
    private void ClickAdvanced(object sender, EventArgs e)
    {
        panelAdvanced.Show();
    }
    private void initElement()
    {
        panelDefault = new PanelDefault();
        panelAdvanced = new PanelAdvanced();
        defaultBttn = new Button();
        advancedBttn = new Button();
        IBLOCKLabel = new Label();
        QuitBttn = new Button();

        IBLOCKLabel.Text = "IBLOCK";
        IBLOCKLabel.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 37F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        IBLOCKLabel.Size = new System.Drawing.Size(170, 75);
        IBLOCKLabel.Location = new System.Drawing.Point(245, 90);
        IBLOCKLabel.ForeColor = System.Drawing.Color.White;
        defaultBttn.Text = "Default";
        defaultBttn.Size = new System.Drawing.Size(125, 75);
        defaultBttn.Location = new System.Drawing.Point(265, 170);
        defaultBttn.ForeColor = System.Drawing.Color.White;
        defaultBttn.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        defaultBttn.Click += new System.EventHandler(this.ClickDefault);
        advancedBttn.Text = "Advanced";
        advancedBttn.Size = new System.Drawing.Size(125, 75);
        advancedBttn.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        advancedBttn.Location = new System.Drawing.Point(265, 250);
        advancedBttn.ForeColor= System.Drawing.Color.White;
        advancedBttn.Click += new System.EventHandler(this.ClickAdvanced);
        QuitBttn.Text= "Quit";
        QuitBttn.Size = new System.Drawing.Size(125, 75);
        QuitBttn.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        QuitBttn.Location = new System.Drawing.Point(265, 330);
        QuitBttn.ForeColor = System.Drawing.Color.White;
        QuitBttn.Click += new System.EventHandler(this.ClickQuit);

        this.BackColor = System.Drawing.Color.Black;
        this.Controls.Add(panelDefault);
        this.Controls.Add(panelAdvanced);
        this.Controls.Add(IBLOCKLabel);
        this.Controls.Add(defaultBttn);
        this.Controls.Add(advancedBttn);
        this.Controls.Add(QuitBttn);
        this.ControlBox = false;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.ClientSize = new System.Drawing.Size(678, 444);

        this.panelDefault.Hide();
        this.panelAdvanced.Hide();
    }
    public MainWindow()
    {
        initElement();
    }
    
}