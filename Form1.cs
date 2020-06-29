//MIT License
//
//Copyright (c) 2020 Koray Akpınar
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using System;
using System.Drawing;
using System.Windows.Forms;
using Ironide;
using Ironide.Tools;
using MochaDB;
using MochaDB.Querying;
using MochaDB.Mhql;
using ZeitBook.Properties;
using System.Media;

namespace İronideDeneme
{
    public partial class Form1 : IronideForm
    {
        int i = 10;
        string tablename = "";
        string labelname;
        string buttonname;
        string tablepass;
        Control clickedpanel;
        MochaDatabase db = new MochaDatabase("path=Zeit;AutoConnect=true");
        
        #region Components

        IronideSlidePanel menuPanel1 = new IronideSlidePanel();
        IronideSlidePanel actionsPanel = new IronideSlidePanel();
        IronideFlowLayoutPanel messagesPanel = new IronideFlowLayoutPanel();
        IronidePanel behindPostTextBox = new IronidePanel();
        IronideForm creatingForm = new IronideForm();
        IronideForm removingForm = new IronideForm();
        IronideForm editingForm = new IronideForm();
        IronideForm aboutForm = new IronideForm();
        IronideForm askingPassForm = new IronideForm();
        IronideForm changePassForm = new IronideForm();
        IronideButton menuButton1 = new IronideButton();
        IronidePanel logoPanel1 = new IronidePanel();
        IronideButton loginButton = new IronideButton();
        IronideButton aboutButton = new IronideButton();
        IronideButton actionsButton = new IronideButton();
        IronideButton creatingButton = new IronideButton();
        IronideButton removingButton = new IronideButton();
        IronideButton editingButton = new IronideButton();
        IronideButton homepageButton = new IronideButton();
        IronideButton editButton = new IronideButton();
        IronideButton createButton = new IronideButton();
        IronideButton addDiary = new IronideButton();
        IronideButton applyButton = new IronideButton();
        IronideFlowLayoutPanel mainPanel = new IronideFlowLayoutPanel();
        IronideLabel passwordLabel = new IronideLabel();
        IronideLabel nameLabel = new IronideLabel();
        IronideLabel descLabel = new IronideLabel();
        IronideLabel nameLabelEditing = new IronideLabel();
        IronideLabel descLabelEditing = new IronideLabel();
        IronideButton removeButton = new IronideButton();
        IronideButton passlogin = new IronideButton();
        IronideButton passcreate = new IronideButton();
        IronidePictureBox logopicture = new IronidePictureBox();
        IronideCheckBox passwordChecker = new IronideCheckBox();
        IronideCheckBox colorChecker = new IronideCheckBox();
        IronideCheckBox colorCheckerEditing = new IronideCheckBox();
        IronideColorPicker buttonColor = new IronideColorPicker();
        IronideColorPicker buttonColorEditing = new IronideColorPicker();
        TextBox desc = new TextBox();
        TextBox name = new TextBox();
        TextBox descEditing = new TextBox();
        TextBox nameEditing = new TextBox();
        IronideTextBox loginBox = new IronideTextBox();
        IronideComboBox buttonsList = new IronideComboBox();
        IronideComboBox buttonsListEditing = new IronideComboBox();
        Ironide.Components.IronideContextMenuStrip bigOneRC = new Ironide.Components.IronideContextMenuStrip();
        IronideTextBox postTextBox = new IronideTextBox();
        IronideTextBox editbox = new IronideTextBox();
        TextBox passwordBox = new TextBox();
        IronideTextBox currentPass = new IronideTextBox();
        IronideTextBox newPass = new IronideTextBox();
        IronideTextBox newPassVerify = new IronideTextBox();
        #endregion

        public Form1()
        {
            InitializeComponent();

            #region editbox
            editbox.Font = new Font("Tahoma",13);
            editbox.BorderThickness=0;
            editbox.Multiline=false;
            editbox.WordWrap=false;
            editbox.Visible=false;
            editbox.KeyDown+=Editbox_KeyDown;
            #endregion

            #region loadingButtons

            refresh();

            #endregion

            #region ComponentOptions
            TitlebarBackColor = IronideColorizer.FromHtml("#1f1f1f");
            TitlebarForeColor = Color.FromArgb(255, 255, 255);
            this.BackColor = Color.FromArgb(69, 69, 69);
            this.BackColor2 = this.BackColor;
            this.Title = "ZeitBook";
            this.ShowIcon = true;
            this.TitlebarIconWidth=0;
            leftpanel.BackColor = Color.FromArgb(39, 39, 39);
            leftpanel.BackColor2 = Color.FromArgb(39,39,39);
            leftpanel.Visible = false;
            openbutton.Region = IronideConvert.ToRoundedRegion(openbutton.ClientRectangle,15);
            openbutton.BackColor = Color.FromArgb(39, 39, 39);
            openbutton.BackColor2 = Color.FromArgb(39,39,39);
            openbutton.ForeColor = Color.White;
            openbutton.SendToBack();
            openbutton.BorderThickness = 0;
            this.BorderColor = Color.FromArgb(31, 31, 31);
            version.ForeColor=Color.DimGray;
            version.BackColor=Color.Transparent;
            version.BackColor2=version.BackColor;

            #endregion

            #region AllPanels

            #region mainPanel

            mainPanel.Size = new Size(this.Width, leftpanel.Height);
            mainPanel.SendToBack();
            mainPanel.Top = this.Height - mainPanel.Height-3;
            mainPanel.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            mainPanel.Width = mainPanel.Width - 10;
            mainPanel.Left = 3;
            mainPanel.BackColor = this.BackColor;
            mainPanel.BackColor2=this.BackColor2;
            mainPanel.ControlAdded+=MainPanel_ControlAdded;

            #endregion

            #region menuPanel1

            menuPanel1.Text = "There is no diaries right now :'(";
            if(menuPanel1.Controls.Count>0) {
                menuPanel1.TextRender=false;
            } else {
                menuPanel1.TextRender=true;
            }
            menuPanel1.Font = new Font("Microsoft Sans Serif",13);
            menuPanel1.ForeColor = IronideColorizer.FromHtml("#797979");
            menuPanel1.TextAlign = ContentAlignment.MiddleCenter;
            menuPanel1.Name = "menuPanel1";
            menuPanel1.Size = new Size(251,40);
            menuPanel1.BorderThickness = 0;
            menuPanel1.Dock = DockStyle.Top;
            menuPanel1.BackColor = IronideColorizer.FromHtml("#484848");
            menuPanel1.BackColor2 = menuPanel1.BackColor;
            menuPanel1.ControlAdded += MenuPanel1_ControlAdded;
            menuPanel1.ControlRemoved+=MenuPanel1_ControlRemoved;
            var numb = db.GetElements("Tables").Count;
            if(numb==1) {
                menuPanel1.Height=40;
            } else {
                menuPanel1.Height=(db.GetElements("Tables").Count)*40;
            }
            menuPanel1.Hide();

            #endregion

            #region actionsPanel

            actionsPanel.Name = "menuPanel1";
            actionsPanel.Size = new Size(251,160);
            actionsPanel.BorderThickness = 0;
            actionsPanel.Dock = DockStyle.Top;
            actionsPanel.BackColor = IronideColorizer.FromHtml("#404040");
            actionsPanel.BackColor2 = IronideColorizer.FromHtml("#404040");
            actionsPanel.Hide();

            #endregion

            #region logoPanel

            logoPanel1.Name = "logoPanel1";
            logoPanel1.Size =new Size(251, 85);
            logoPanel1.BorderThickness = 0;
            logoPanel1.Dock = DockStyle.Top;
            logoPanel1.BackColor = leftpanel.BackColor;
            logoPanel1.BackColor2 = leftpanel.BackColor2;

            #endregion

            #endregion

            #region AllButtons

            #region aboutButton

            aboutButton.Name = "setttingsButton";
            aboutButton.Size = new Size(251, 40);
            aboutButton.Text = "About ZeitBook";
            aboutButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            aboutButton.ForeColor = Color.White;
            aboutButton.BorderThickness = 0;
            aboutButton.TextAlign = ContentAlignment.MiddleCenter;
            aboutButton.BackColor = IronideColorizer.FromHtml("#303030");
            aboutButton.BackColor2 = aboutButton.BackColor;
            aboutButton.EnterColor = IronideColorizer.FromHtml("#363636");
            aboutButton.HoverColor = IronideColorizer.FromHtml("#383838");
            aboutButton.Dock = DockStyle.Top;
            aboutButton.Click+=AboutButton_Click;

            #endregion

            #region actionsButton
            
            actionsButton.Name = "actionsButton";
            actionsButton.Size = new Size(251, 40);
            actionsButton.Text = "Actions";
            actionsButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            actionsButton.ForeColor = Color.White;
            actionsButton.BorderThickness = 0;
            actionsButton.TextAlign = ContentAlignment.MiddleCenter;
            actionsButton.BackColor = IronideColorizer.FromHtml("#303030");
            actionsButton.BackColor2 = actionsButton.BackColor;
            actionsButton.EnterColor = IronideColorizer.FromHtml("#363636");
            actionsButton.HoverColor = IronideColorizer.FromHtml("#383838");
            actionsButton.Dock = DockStyle.Top;
            actionsButton.Click += ActionsButton_Click;

            #endregion

            #region menuButton1

            menuButton1.Name = "menuButton1";
            menuButton1.Size = new Size(251,40);
            menuButton1.Text = "Diaries";
            menuButton1.Font = new Font("Microsoft Sans Serif",12,FontStyle.Regular);
            menuButton1.ForeColor = Color.White;
            menuButton1.BorderThickness = 0;
            menuButton1.TextAlign = ContentAlignment.MiddleCenter;
            menuButton1.BackColor = IronideColorizer.FromHtml("#303030");
            menuButton1.BackColor2 = menuButton1.BackColor;
            menuButton1.EnterColor = IronideColorizer.FromHtml("#363636");
            menuButton1.HoverColor = IronideColorizer.FromHtml("#383838");
            menuButton1.Dock = DockStyle.Top;
            menuButton1.Top += 50;
            menuButton1.Click += MenuButton1_Click;

            #endregion
            
            #region creatingButton

            creatingButton.Name = "Create a Diary";
            creatingButton.Size = new Size(251, 40);
            creatingButton.Text = "  Create a Diary";
            creatingButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            creatingButton.Dock = DockStyle.Top;
            creatingButton.TextAlign = ContentAlignment.MiddleLeft;
            creatingButton.BorderThickness = 0;
            creatingButton.BackColor = IronideColorizer.FromHtml("#484848");
            creatingButton.BackColor2 = creatingButton.BackColor;
            creatingButton.EnterColor = IronideColorizer.FromHtml("#363636");
            creatingButton.HoverColor = IronideColorizer.FromHtml("#4d4d4d");
            creatingButton.ForeColor = IronideColorizer.FromHtml("#00ff00");
            creatingButton.Click += AddingButton_Click;
            
            #endregion

            #region removingButton

            removingButton.Name = "Remove a Diary";
            removingButton.Size = new Size(251, 40);
            removingButton.Text = "  Remove a Diary";
            removingButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            removingButton.Dock = DockStyle.Top;
            removingButton.TextAlign = ContentAlignment.MiddleLeft;
            removingButton.BorderThickness = 0;
            removingButton.BackColor = IronideColorizer.FromHtml("#484848");
            removingButton.BackColor2 = removingButton.BackColor;
            removingButton.EnterColor = IronideColorizer.FromHtml("#363636");
            removingButton.HoverColor = IronideColorizer.FromHtml("#4d4d4d");
            removingButton.ForeColor = IronideColorizer.FromHtml("#ff0000");
            removingButton.Click+=RemovingButton_Click;

            #endregion

            #region editingButton

            editingButton.Name = "Edit a Diary";
            editingButton.Size = new Size(251, 40);
            editingButton.Text = "  Edit a Diary";
            editingButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            editingButton.Dock = DockStyle.Top;
            editingButton.TextAlign = ContentAlignment.MiddleLeft;
            editingButton.BorderThickness = 0;
            editingButton.BackColor = IronideColorizer.FromHtml("#484848");
            editingButton.BackColor2 = editingButton.BackColor;
            editingButton.EnterColor = IronideColorizer.FromHtml("#363636");
            editingButton.HoverColor = IronideColorizer.FromHtml("#4d4d4d");
            editingButton.ForeColor = Color.Yellow;
            editingButton.Click+=EditButton_Click;

            #endregion

            #region homepageButton

            homepageButton.Name = "Go to Homepage";
            homepageButton.Size = new Size(251, 40);
            homepageButton.Text = "  Go to Homepage";
            homepageButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            homepageButton.Dock = DockStyle.Top;
            homepageButton.TextAlign = ContentAlignment.MiddleLeft;
            homepageButton.BorderThickness = 0;
            homepageButton.BackColor = IronideColorizer.FromHtml("#484848");
            homepageButton.BackColor2 = homepageButton.BackColor;
            homepageButton.EnterColor = IronideColorizer.FromHtml("#363636");
            homepageButton.HoverColor = IronideColorizer.FromHtml("#4d4d4d");
            homepageButton.ForeColor = IronideColorizer.FromHtml("#ffffff");
            homepageButton.Click+=HomepageButton_Click;

            #endregion

            #region createButton
            
            createButton.Size = new Size(150, 40);
            createButton.Location = new Point(575, 650);
            createButton.BackColor = IronideColorizer.FromHtml("#606060");
            createButton.BackColor2 = IronideColorizer.FromHtml("#606060");
            createButton.ForeColor = IronideColorizer.FromHtml("#00ff00");
            createButton.EnterColor = createButton.BackColor;
            createButton.HoverColor = IronideColorizer.FromHtml("#757575");
            createButton.BorderThickness = 0;
            createButton.Text = "Create";
            createButton.TextAlign = ContentAlignment.MiddleCenter;
            createButton.Font = menuButton1.Font;
            createButton.Click += CreateButton_Click;

            #endregion

            #region editButton

            editButton.Size = new Size(150,40);
            editButton.Location = new Point(createButton.Location.X,createButton.Location.Y+35);
            editButton.BackColor = IronideColorizer.FromHtml("#606060");
            editButton.BackColor2 = IronideColorizer.FromHtml("#606060");
            editButton.ForeColor = IronideColorizer.FromHtml("#ffff00");
            editButton.EnterColor = editButton.BackColor;
            editButton.HoverColor = IronideColorizer.FromHtml("#757575");
            editButton.BorderThickness = 0;
            editButton.Text = "Edit";
            editButton.TextAlign = ContentAlignment.MiddleCenter;
            editButton.Font = menuButton1.Font;
            editButton.Click+=EditButton_Click1;

            #endregion

            #region removeButton
            removeButton.Size = new Size(150,40);
            removeButton.Location = new Point(400,250);
            removeButton.BackColor = IronideColorizer.FromHtml("#606060");
            removeButton.BackColor2 = IronideColorizer.FromHtml("#606060");
            removeButton.ForeColor = IronideColorizer.FromHtml("#ff0000");
            removeButton.EnterColor = createButton.BackColor;
            removeButton.HoverColor = IronideColorizer.FromHtml("#757575");
            removeButton.BorderThickness = 0;
            removeButton.Text = "Remove";
            removeButton.TextAlign = ContentAlignment.MiddleCenter;
            removeButton.Font = menuButton1.Font;
            removeButton.Click+=RemoveButton_Click;
            #endregion

            #region loginButton
            loginButton.Size=removeButton.Size;
            loginButton.BackColor=removeButton.BackColor;
            loginButton.BackColor2=loginButton.BackColor;
            loginButton.EnterColor=createButton.BackColor;
            loginButton.HoverColor=removeButton.HoverColor;
            loginButton.BorderThickness=0;
            loginButton.Location=removeButton.Location;
            loginButton.Text="Login";
            loginButton.ForeColor=Color.Silver;
            loginButton.Font=removeButton.Font;
            loginButton.Click+=LoginButton_Click;
            #endregion

            #region applyButton
            applyButton.Size=removeButton.Size;
            applyButton.BackColor=removeButton.BackColor;
            applyButton.BackColor2=applyButton.BackColor;
            applyButton.EnterColor=createButton.BackColor;
            applyButton.HoverColor=removeButton.HoverColor;
            applyButton.BorderThickness=0;
            applyButton.Location=new Point(removeButton.Location.X,removeButton.Location.Y+25);
            applyButton.Text="Apply";
            applyButton.ForeColor=Color.Silver;
            applyButton.Font=removeButton.Font;
            applyButton.Click+=ApplyButton_Click;
            #endregion

            #endregion

            #region Forms

            #region creatingForm

            creatingForm.Size = new Size(800, 750);
            creatingForm.BackColor = IronideColorizer.FromHex("3f3f3f");
            creatingForm.BackColor2 = IronideColorizer.FromHex("3f3f3f");
            creatingForm.BorderThickness = 1;
            creatingForm.BorderColor = IronideColorizer.FromHtml("#00ff00");
            creatingForm.Animation = IronideFormAnimation.Fade;
            creatingForm.AnimationDelay = 15;
            creatingForm.ShowIcon = false;
            creatingForm.TitlebarIconWidth = 0;
            creatingForm.MaximizeBox = false;
            creatingForm.MinimizeBox = false;
            creatingForm.ResizeDoubleClick = false;
            creatingForm.Title = "";
            creatingForm.TitlebarForeColor = Color.White;
            creatingForm.TitlebarBackColor = creatingForm.BackColor;
            creatingForm.CloseBoxHoverColor = Color.Red;
            creatingForm.ShowInTaskbar = false;

            #endregion

            #region removingForm

            removingForm.Size= new Size(600,350);
            removingForm.Sizable=false;
            removingForm.BackColor = IronideColorizer.FromHex("3f3f3f");
            removingForm.BackColor2 = IronideColorizer.FromHex("3f3f3f");
            removingForm.BorderThickness = 1;
            removingForm.BorderColor = IronideColorizer.FromHtml("#ff0000");
            removingForm.Animation = IronideFormAnimation.Fade;
            removingForm.AnimationDelay = 15;
            removingForm.ShowIcon = false;
            removingForm.TitlebarIconWidth = 0;
            removingForm.MaximizeBox = false;
            removingForm.MinimizeBox = false;
            removingForm.ResizeDoubleClick = false;
            removingForm.Title = "";
            removingForm.TitlebarForeColor = Color.White;
            removingForm.TitlebarBackColor = removingForm.BackColor;
            removingForm.CloseBoxHoverColor = Color.Red;
            removingForm.ShowInTaskbar = false;

            #endregion

            #region editingForm

            editingForm.Size= new Size(creatingForm.Width,creatingForm.Height+25);
            editingForm.BackColor = IronideColorizer.FromHex("3f3f3f");
            editingForm.BackColor2 = IronideColorizer.FromHex("3f3f3f");
            editingForm.BorderThickness = 1;
            editingForm.BorderColor = IronideColorizer.FromHtml("#ffff00");
            editingForm.Animation = IronideFormAnimation.Fade;
            editingForm.AnimationDelay = 15;
            editingForm.ShowIcon = false;
            editingForm.TitlebarIconWidth = 0;
            editingForm.MaximizeBox = false;
            editingForm.MinimizeBox = false;
            editingForm.ResizeDoubleClick = false;
            editingForm.Title = "";
            editingForm.TitlebarForeColor = Color.White;
            editingForm.TitlebarBackColor = editingForm.BackColor;
            editingForm.CloseBoxHoverColor = Color.Red;
            editingForm.ShowInTaskbar = false;

            #endregion

            #region aboutForm

            aboutForm.Size = new Size(800,550);
            aboutForm.BackColor = IronideColorizer.FromHex("3f3f3f");
            aboutForm.BackColor2 = IronideColorizer.FromHex("3f3f3f");
            aboutForm.BorderThickness = 1;
            aboutForm.BorderColor = Color.Silver;
            aboutForm.Animation = IronideFormAnimation.Fade;
            aboutForm.AnimationDelay = 15;
            aboutForm.ShowIcon = false;
            aboutForm.TitlebarIconWidth = 0;
            aboutForm.MaximizeBox = false;
            aboutForm.MinimizeBox = false;
            aboutForm.ResizeDoubleClick = false;
            aboutForm.Title = "";
            aboutForm.TitlebarForeColor = Color.White;
            aboutForm.TitlebarBackColor = aboutForm.BackColor;
            aboutForm.CloseBoxHoverColor = Color.Red;
            aboutForm.ShowInTaskbar = false;

            #endregion

            #region askingPassForm

            askingPassForm.Size= new Size(600,350);
            askingPassForm.BackColor = IronideColorizer.FromHex("3f3f3f");
            askingPassForm.BackColor2 = IronideColorizer.FromHex("3f3f3f");
            askingPassForm.BorderThickness = 1;
            askingPassForm.BorderColor = IronideColorizer.FromHtml("#0000ff");
            askingPassForm.Animation = IronideFormAnimation.Fade;
            askingPassForm.AnimationDelay = 15;
            askingPassForm.ShowIcon = false;
            askingPassForm.Sizable=false;
            askingPassForm.TitlebarIconWidth = 0;
            askingPassForm.MaximizeBox = false;
            askingPassForm.MinimizeBox = false;
            askingPassForm.ResizeDoubleClick = false;
            askingPassForm.Title = "Password";
            askingPassForm.TitleAlign=IronideTitleAlign.Center;
            askingPassForm.TitlebarForeColor = Color.White;
            askingPassForm.TitlebarBackColor = askingPassForm.BackColor;
            askingPassForm.CloseBoxHoverColor = Color.Red;
            askingPassForm.ShowInTaskbar = false;
            askingPassForm.FormClosing+=AskingPassForm_FormClosing;

            #endregion

            #region changePassForm
            changePassForm.Size= new Size(600,350);
            changePassForm.BackColor = IronideColorizer.FromHex("3f3f3f");
            changePassForm.BackColor2 = IronideColorizer.FromHex("3f3f3f");
            changePassForm.BorderThickness = 1;
            changePassForm.BorderColor = IronideColorizer.FromHtml("#0000ff");
            changePassForm.Animation = IronideFormAnimation.Fade;
            changePassForm.AnimationDelay = 15;
            changePassForm.ShowIcon = false;
            changePassForm.Sizable=false;
            changePassForm.TitlebarIconWidth = 0;
            changePassForm.MaximizeBox = false;
            changePassForm.MinimizeBox = false;
            changePassForm.ResizeDoubleClick = false;
            changePassForm.Title = "New Password";
            changePassForm.TitleAlign=IronideTitleAlign.Center;
            changePassForm.TitlebarForeColor = Color.White;
            changePassForm.TitlebarBackColor = changePassForm.BackColor;
            changePassForm.CloseBoxHoverColor = Color.Red;
            changePassForm.ShowInTaskbar = false;
            changePassForm.Shown+=ChangePassForm_Shown;
            #endregion

            #endregion

            #region aboutZeitBook

            IronideLabel about = new IronideLabel();
            about.Text="About ZeitBook";
            about.AutoSize=true;
            about.Font=new Font("Tahoma",14);
            about.ForeColor=Color.White;
            about.BackColor=Color.Transparent;
            about.BackColor2=about.BackColor;
            about.Location=new Point((aboutForm.Width/2) - (about.Width/2) - 20,75);
            IronideLabel copyright = new IronideLabel();
            copyright.Text="Copyright © 2020 Koray Akpınar";
            copyright.AutoSize=true;
            copyright.Font=new Font("Tahoma",14);
            copyright.ForeColor=Color.White;
            copyright.BackColor=Color.Transparent;
            copyright.BackColor2=copyright.BackColor;
            copyright.Location=new Point((aboutForm.Width/2) - (copyright.Width/2) - 85,150);
            IronideLabel aboutVersion = new IronideLabel();
            aboutVersion.Text="Version 1.0.1";
            aboutVersion.AutoSize=true;
            aboutVersion.Font=new Font("Tahoma",14);
            aboutVersion.ForeColor=Color.White;
            aboutVersion.BackColor=Color.Transparent;
            aboutVersion.BackColor2=aboutVersion.BackColor;
            aboutVersion.Location=new Point((aboutForm.Width/2)-(aboutVersion.Width/2) - 20,200);
            IronideLabel aboutText = new IronideLabel();
            aboutText.Text="ZeitBook is an electronic diary where you can keep your memories, regardless of size.";
            aboutText.AutoSize=true;
            aboutText.Font=new Font("Tahoma",14);
            aboutText.ForeColor=Color.White;
            aboutText.BackColor=Color.Transparent;
            aboutText.BackColor2=aboutText.BackColor;
            aboutText.Location=new Point((aboutForm.Width/2) - (aboutText.Width/2) - 310,250);

            #endregion

            #region logoPicture

            logopicture.Image = Resources._new;
            logopicture.SizeMode = IronideImageSizeMode.Stretch;
            logopicture.BorderThickness = 0;
            logopicture.Size = new Size(125, 125);
            logopicture.BackColor = logoPanel1.BackColor;
            logopicture.BackColor2=logoPanel1.BackColor2;
            logopicture.Location = new Point((logoPanel1.Width / 2) - (logopicture.Height / 2), (logoPanel1.Height / 2) - (logopicture.Width / 2));
            logopicture.Anchor = AnchorStyles.None;

            #endregion

            #region nameLabelandTextBox

            name.Name = "NameTextBox";
            name.Location = new Point(320, 100);
            name.Size = new Size(300, 90);
            name.Font = new Font("Microsoft Sans Serif", 10);
            nameLabel.AutoSize = true;
            nameLabel.Text = "Name of the Diary:";
            nameLabel.Font = new Font("Microsoft Sans Serif", 13);
            nameLabel.ForeColor = Color.White;
            nameLabel.BackColor=creatingForm.BackColor;
            nameLabel.BackColor2=nameLabel.BackColor;
            nameLabel.Location = new Point(160, 100);

            #endregion

            #region descLabelandTextBox

            desc.Location = new Point(320, 175);
            desc.Multiline = true;
            desc.Size = new Size(300, 150);
            desc.Font = new Font("Microsoft Sans Serif", 9);
            desc.ScrollBars = ScrollBars.Vertical;
            descLabel.AutoSize = true;
            descLabel.Text = "Description of the Diary:";
            descLabel.Font = new Font("Microsoft Sans Serif", 13);
            descLabel.ForeColor = Color.White;
            descLabel.BackColor=creatingForm.BackColor;
            descLabel.BackColor2=descLabel.BackColor;
            descLabel.Location = new Point(120, 230);
            
            #endregion

            #region editingFormControls

            #region nameLabelandTextBoxEditing

            nameEditing.Name = "nameEditingTextBox";
            nameEditing.Location = new Point(360,130);
            nameEditing.Size = new Size(300,90);
            nameEditing.Font = new Font("Microsoft Sans Serif",10);
            nameLabelEditing.AutoSize = true;
            nameLabelEditing.Text = "New name of the Diary:";
            nameLabelEditing.Font = new Font("Microsoft Sans Serif",13);
            nameLabelEditing.ForeColor = Color.White;
            nameLabelEditing.BackColor=creatingForm.BackColor;
            nameLabelEditing.BackColor2=nameLabelEditing.BackColor;
            nameLabelEditing.Location = new Point(160,130);

            #endregion

            #region descLabelandTextBoxEditing

            descEditing.Location = new Point(360,205);
            descEditing.Multiline = true;
            descEditing.Size = new Size(300,150);
            descEditing.Font = new Font("Microsoft Sans Serif",9);
            descEditing.ScrollBars = ScrollBars.Vertical;
            descLabelEditing.AutoSize = true;
            descLabelEditing.Text = "New description of the Diary:";
            descLabelEditing.Font = new Font("Microsoft Sans Serif",13);
            descLabelEditing.ForeColor = Color.White;
            descLabelEditing.BackColor=creatingForm.BackColor;
            descLabelEditing.BackColor2=descLabelEditing.BackColor;
            descLabelEditing.Location = new Point(120,260);

            #endregion

            #region ColorPickerandCheckBoxEditing
            buttonColorEditing.Size=new Size(200,190);
            buttonColorEditing.Location=new Point(410,430);
            buttonColorEditing.Hide();
            colorCheckerEditing.Size=new Size(150,25);
            colorCheckerEditing.Text="New Color";
            colorCheckerEditing.BackColor=Color.Transparent;
            colorCheckerEditing.BackColor2=colorCheckerEditing.BackColor;
            colorCheckerEditing.ForeColor=Color.White;
            colorCheckerEditing.Location=new Point(180,510);
            colorCheckerEditing.Visible=true;
            colorCheckerEditing.Font=menuButton1.Font;
            colorCheckerEditing.CheckedChanged+=ColorCheckerEditing_CheckedChanged;

            #endregion

            #region buttonsListEditing

            buttonsListEditing.Font=new Font("Microsoft Sans Serif",10);
            buttonsListEditing.Width=200;
            buttonsListEditing.BackColor=Color.White;
            buttonsListEditing.BackColor=Color.White;
            buttonsListEditing.BorderColor=editingForm.BackColor;
            buttonsListEditing.HighlightColor=editingForm.BackColor;
            buttonsListEditing.Location=new Point((editingForm.Width/2)-(buttonsListEditing.Width/2),70);
            buttonsListEditing.PlaceholderAlign=ContentAlignment.MiddleCenter;
            buttonsListEditing.SelectedIndexChanged+=ButtonsListEditing_SelectedIndexChanged;
            ListButtons(buttonsListEditing);

            #endregion

            #endregion

            #region changePassFormControls
            #region currentPass
            currentPass.Font=name.Font;
            currentPass.Width=name.Width+25;
            currentPass.Location=new Point((changePassForm.Width/2)-(currentPass.Width/2),75);
            currentPass.Placeholder="Please enter the current password of the diary";
            currentPass.BackColor=Color.White;
            currentPass.BorderThickness=(IronideTextBoxBorderThickness)2;
            currentPass.ActiveBorderColor=changePassForm.BorderColor;
            currentPass.InactiveBorderColor=currentPass.ActiveBorderColor;
            currentPass.PasswordChar=Convert.ToChar("*");
            currentPass.Font=new Font("Tahoma",11);
            #endregion

            #region newPass
            newPass.Font=name.Font;
            newPass.Width=name.Width+25;
            newPass.Location=new Point((changePassForm.Width/2)-(newPass.Width/2),145);
            newPass.Placeholder="Please enter the new password of the diary";
            newPass.BackColor=Color.White;
            newPass.BorderThickness=(IronideTextBoxBorderThickness)2;
            newPass.ActiveBorderColor=changePassForm.BorderColor;
            newPass.InactiveBorderColor=newPass.ActiveBorderColor;
            newPass.PasswordChar=Convert.ToChar("*");
            newPass.Font=new Font("Tahoma",11);
            #endregion

            #region newPassVerify
            newPassVerify.Font=name.Font;
            newPassVerify.Width=name.Width+25;
            newPassVerify.Location=new Point((changePassForm.Width/2)-(newPassVerify.Width/2),185);
            newPassVerify.Placeholder="Please verify the new password of the diary";
            newPassVerify.BackColor=Color.White;
            newPassVerify.BorderThickness=(IronideTextBoxBorderThickness)2;
            newPassVerify.ActiveBorderColor=changePassForm.BorderColor;
            newPassVerify.InactiveBorderColor=newPassVerify.ActiveBorderColor;
            newPassVerify.PasswordChar=Convert.ToChar("*");
            newPassVerify.Font=new Font("Tahoma",11);
            #endregion
            #endregion

            #region ColorPickerAndCheckBox
            colorChecker.Size=new Size(150,25);
            colorChecker.Text="Special color";
            colorChecker.BackColor=creatingForm.BackColor;
            colorChecker.BackColor2=creatingForm.BackColor2;
            colorChecker.ForeColor=Color.White;
            colorChecker.Location=new Point(160,530);
            colorChecker.Visible=true;
            colorChecker.Font=menuButton1.Font;
            colorChecker.CheckedChanged+=ColorChecker_CheckedChanged;
            buttonColor.Size=new Size(200,190);
            buttonColor.Location=new Point(370,450);
            buttonColor.Hide();

            #endregion

            #region diaryPassword

            passwordChecker.Size=new Size(150,25);
            passwordChecker.Text="Password";
            passwordChecker.BackColor=creatingForm.BackColor;
            passwordChecker.BackColor2=creatingForm.BackColor2;
            passwordChecker.ForeColor=Color.White;
            passwordChecker.Location=new Point(160,385);
            passwordChecker.Visible=true;
            passwordChecker.Font=menuButton1.Font;
            passwordChecker.CheckedChanged+=PasswordChecker_CheckedChanged;
            passwordBox.Font = name.Font;
            passwordBox.Size = name.Size;
            passwordBox.Location=new Point(320,385);
            passwordBox.PasswordChar=Convert.ToChar("*");
            passwordBox.Visible=false;
            passcreate.Size=new Size(45,20);
            passcreate.Location=new Point(passwordBox.Width+passwordBox.Location.X+20,passwordBox.Location.Y+4);
            passcreate.BackgroundImage = Resources.redeye;
            passcreate.BackgroundImageLayout=ImageLayout.Stretch;
            passcreate.Region=IronideConvert.ToRoundedRegion(passcreate.ClientRectangle,20);
            passcreate.BackColor=Color.Transparent;
            passcreate.BackColor2=passcreate.BackColor;
            passcreate.BorderThickness=0;
            passcreate.Tag="kirmizi";
            passcreate.HoverColor=Color.Transparent;
            passcreate.EnterColor=Color.Transparent;
            passcreate.Visible=false;
            passcreate.Click+=Passcreate_Click;

            #endregion

            #region messagesPanel

            messagesPanel.WrapContents=false;
            messagesPanel.FlowDirection=FlowDirection.BottomUp;
            messagesPanel.Padding=new Padding(85,0,0,0);
            messagesPanel.AutoScroll=true;
            messagesPanel.Size = new Size(this.Width,leftpanel.Height-100);
            messagesPanel.Top = this.Height - messagesPanel.Height-103;
            messagesPanel.Anchor = AnchorStyles.Right | AnchorStyles.Left |AnchorStyles.Bottom|AnchorStyles.Top;
            messagesPanel.Width = messagesPanel.Width - 8;
            messagesPanel.Left = 4;
            messagesPanel.BackColor=IronideColorizer.FromHex("363636");
            messagesPanel.BackColor2=messagesPanel.BackColor;
            messagesPanel.Visible=false;

            #endregion

            #region postTextBox

            postTextBox.BorderThickness=0;
            postTextBox.Size=new Size(900,200);
            postTextBox.Location=new Point(45,10);
            postTextBox.Left=(Width/2)-(behindPostTextBox.Width/2)-(postTextBox.Width/2)+10;
            postTextBox.Font= new Font("Tahoma",11);
            postTextBox.BackColor=IronideColorizer.FromHtml("#383838");
            postTextBox.ForeColor=Color.White;
            postTextBox.Visible=false;
            postTextBox.KeyDown+=PostTextBox_KeyDown;
            behindPostTextBox.BorderThickness=0;
            behindPostTextBox.Size=new Size(1000,45);
            behindPostTextBox.Location=new Point(3,this.Height-80);
            behindPostTextBox.Left=(this.Width-behindPostTextBox.Width)/2;
            behindPostTextBox.BackColor=IronideColorizer.FromHtml("#383838");
            behindPostTextBox.BackColor2=IronideColorizer.FromHtml("#383838");
            behindPostTextBox.Anchor=AnchorStyles.Bottom;
            behindPostTextBox.Region=IronideConvert.ToRoundedRegion(behindPostTextBox.ClientRectangle,25);
            behindPostTextBox.Visible=false;

            #endregion

            #region buttonsList

            buttonsList.Font=new Font("Microsoft Sans Serif",10);
            buttonsList.Width=200;
            buttonsList.Placeholder="Select a button";
            buttonsList.PlaceholderAlign=ContentAlignment.MiddleCenter;
            buttonsList.BackColor=Color.White;
            buttonsList.BorderColor=removingForm.BackColor;
            buttonsList.HighlightColor=removingForm.BackColor;
            buttonsList.Location=new Point((removingForm.Width/2)-(buttonsList.Width/2),100);
            ListButtons(buttonsList);

            #endregion

            #region loginBox
            loginBox.Font=name.Font;
            loginBox.Width=name.Width;
            loginBox.Location=new Point((askingPassForm.Width/2) - (loginBox.Width/2)-50,name.Location.Y+45);
            loginBox.Placeholder="Please enter the password of the diary";
            loginBox.BackColor=Color.White;
            loginBox.BorderThickness=(IronideTextBoxBorderThickness)2;
            loginBox.ActiveBorderColor=askingPassForm.BorderColor;
            loginBox.InactiveBorderColor=loginBox.ActiveBorderColor;
            loginBox.PasswordChar=Convert.ToChar("*");
            loginBox.Font=new Font("Tahoma",11);
            loginBox.KeyDown+=LoginBox_KeyDown;
            #endregion

            #region passlogin

            passlogin.Size=new Size(45,20);
            passlogin.Location=new Point(loginBox.Location.X+20+loginBox.Width,loginBox.Location.Y+4);
            passlogin.BackgroundImage = Resources.redeye;
            passlogin.BackgroundImageLayout=ImageLayout.Stretch;
            passlogin.Region=IronideConvert.ToRoundedRegion(passlogin.ClientRectangle,20);
            passlogin.BackColor=Color.Transparent;
            passlogin.BackColor2=passlogin.BackColor;
            passlogin.BorderThickness=0;
            passlogin.Tag="kirmizi";
            passlogin.HoverColor=Color.Transparent;
            passlogin.EnterColor=Color.Transparent;
            passlogin.Click+=Passlogin_Click;

            #endregion

            #region DockAlignment

            leftpanel.Controls.Add(aboutButton);
            leftpanel.Controls.Add(actionsPanel);
            leftpanel.Controls.Add(actionsButton);
            leftpanel.Controls.Add(menuPanel1);
            leftpanel.Controls.Add(menuButton1);
            leftpanel.Controls.Add(logoPanel1);
            actionsPanel.Controls.Add(homepageButton);
            actionsPanel.Controls.Add(removingButton);
            actionsPanel.Controls.Add(editingButton);
            actionsPanel.Controls.Add(creatingButton);
            creatingForm.Controls.Add(createButton);
            creatingForm.Controls.Add(name);
            creatingForm.Controls.Add(nameLabel);
            creatingForm.Controls.Add(desc);
            creatingForm.Controls.Add(descLabel);
            creatingForm.Controls.Add(passwordChecker);
            creatingForm.Controls.Add(passwordBox);
            creatingForm.Controls.Add(colorChecker);
            creatingForm.Controls.Add(buttonColor);
            creatingForm.Controls.Add(passcreate);
            askingPassForm.Controls.Add(loginButton);
            askingPassForm.Controls.Add(loginBox);
            askingPassForm.Controls.Add(passlogin);
            changePassForm.Controls.Add(currentPass);
            changePassForm.Controls.Add(newPass);
            changePassForm.Controls.Add(newPassVerify);
            changePassForm.Controls.Add(applyButton);
            removingForm.Controls.Add(buttonsList);
            removingForm.Controls.Add(removeButton);
            editingForm.Controls.Add(nameEditing);
            editingForm.Controls.Add(nameLabelEditing);
            editingForm.Controls.Add(descEditing);
            editingForm.Controls.Add(descLabelEditing);
            editingForm.Controls.Add(buttonColorEditing);
            editingForm.Controls.Add(buttonsListEditing);
            editingForm.Controls.Add(colorCheckerEditing);
            editingForm.Controls.Add(editButton);
            aboutForm.Controls.Add(about);
            aboutForm.Controls.Add(copyright);
            aboutForm.Controls.Add(aboutVersion);
            aboutForm.Controls.Add(aboutText);
            Controls.Add(behindPostTextBox);
            behindPostTextBox.Controls.Add(postTextBox);
            Controls.Add(messagesPanel);
            Controls.Add(mainPanel);
            logoPanel1.Controls.Add(logopicture);

            #endregion

            #region bigOneRightClickMenu
            bigOneRC.AutoSize=true;
            bigOneRC.Items.Add(new IronideToolStripMenuItem("Edit this diary",this.BackColor,Color.White,Color.DimGray));
            bigOneRC.Items.Add(new IronideToolStripMenuItem("Remove this diary",this.BackColor,Color.White,Color.DimGray));
            bigOneRC.Items.Add(new IronideToolStripMenuItem("Change this diary's password",this.BackColor,Color.White,Color.DimGray));
            bigOneRC.BackColor=this.BackColor;
            bigOneRC.BackColor2=bigOneRC.BackColor;
            bigOneRC.ItemClicked+=BigOneRC_ItemClicked;
            #endregion
        }
        #region Events
        private void ChangePassForm_Shown(object sender,EventArgs e) {
            if(tablepass==null) {
                currentPass.Hide();
            }
        }

        private void ApplyButton_Click(object sender,EventArgs e) {
            var dex = db.GetDataIndex("Diaries","names",tablename);
            tablepass = db.GetData("Diaries","password",dex).ToString();
            if(tablepass==currentPass.Text) {
                currentPass.InactiveBorderColor=changePassForm.BorderColor;
                currentPass.ActiveBorderColor=currentPass.InactiveBorderColor;
                if(newPass.Text==newPassVerify.Text) {
                    newPass.InactiveBorderColor=changePassForm.BorderColor;
                    newPass.ActiveBorderColor=currentPass.InactiveBorderColor;
                    newPassVerify.InactiveBorderColor=changePassForm.BorderColor;
                    newPassVerify.ActiveBorderColor=currentPass.InactiveBorderColor;
                    if(newPass.Text=="") {
                        if(MessageBox.Show("Are you sure to remove the password of the diary","Removing Password",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes) {
                            db.UpdateData("Diaries","password",dex,"");
                        }
                    } else {
                        db.UpdateData("Diaries","password",dex,newPass.Text);
                        currentPass.InactiveBorderColor=changePassForm.BorderColor;
                        currentPass.ActiveBorderColor=currentPass.InactiveBorderColor;
                        newPass.InactiveBorderColor=changePassForm.BorderColor;
                        newPass.ActiveBorderColor=currentPass.InactiveBorderColor;
                        newPassVerify.InactiveBorderColor=changePassForm.BorderColor;
                        newPassVerify.ActiveBorderColor=newPassVerify.InactiveBorderColor;
                        currentPass.Text="";
                        newPass.Text="";
                        newPassVerify.Text="";
                        changePassForm.Close();
                    }
                } else {
                    newPass.InactiveBorderColor=Color.Red;
                    newPass.ActiveBorderColor=Color.Red;
                    newPassVerify.InactiveBorderColor=Color.Red;
                    newPassVerify.ActiveBorderColor=Color.Red;
                    SystemSounds.Beep.Play();
                }
            } else {
                SystemSounds.Beep.Play();
                currentPass.InactiveBorderColor=Color.Red;
                currentPass.ActiveBorderColor=Color.Red;
            }
        }
        
        private void Passcreate_Click(object sender,EventArgs e) {
            if((string)passcreate.Tag=="kirmizi") {
                passcreate.Tag="yesil";
                passcreate.BackgroundImage=Resources.greeneye;
                passwordBox.PasswordChar=Convert.ToChar("\0");
            } else {
                passcreate.Tag="kirmizi";
                passcreate.BackgroundImage=Resources.redeye;
                passwordBox.PasswordChar=Convert.ToChar("*");
            }
        }
        
        private void Passlogin_Click(object sender,EventArgs e) {
            if((string)passlogin.Tag=="kirmizi") {
                passlogin.Tag="yesil";
                passlogin.BackgroundImage=Resources.greeneye;
                loginBox.PasswordChar=Convert.ToChar("\0");
            } else {
                passlogin.Tag="kirmizi";
                passlogin.BackgroundImage=Resources.redeye;
                loginBox.PasswordChar=Convert.ToChar("*");
            }
        }
        
        private void LoginButton_Click(object sender,EventArgs e) {
            trypass();
        }

        private void AskingPassForm_FormClosing(object sender,FormClosingEventArgs e) {
            loginBox.Text="";
        }

        private void LoginBox_KeyDown(object sender,KeyEventArgs e) {
            if(e.KeyCode==Keys.Enter) {
                e.SuppressKeyPress=true;
                trypass();
            }
        }

        private void PasswordChecker_CheckedChanged(object sender,EventArgs e) {
            if(passwordChecker.Checked==true) {
                passwordBox.Show();
                passcreate.Show();
            } else {
                passwordBox.Hide();
                passcreate.Hide();
            }
        }

        private void AboutButton_Click(object sender,EventArgs e) {
            aboutForm.ShowDialog();
        }

        private void Editbox_KeyDown(object sender,KeyEventArgs e) {
            if(e.KeyCode==Keys.Enter) {
                var dex = db.GetDataIndex(tablename,"content",clickedpanel.Controls[labelname].Text);
                e.SuppressKeyPress=true;
                editbox.Visible=false;
                var label = clickedpanel.Controls[labelname];
                label.Text=IronideWrapper.WordWrapPxStr(editbox.Text,label.Font,205,IronideWrapStyle.RemoveNewLines);
                clickedpanel.Controls[labelname].Visible=true;
                if(label.Width<102) {
                    clickedpanel.Width=142;
                } else {
                    clickedpanel.Width=clickedpanel.Controls[labelname].Width+40;
                }
                clickedpanel.Height=clickedpanel.Controls[labelname].Height+30;
                label.Location = new Point((clickedpanel.Width / 2) - (label.Width/2),(clickedpanel.Height / 2) - (label.Height / 2) + 5);
                clickedpanel.Region=IronideConvert.ToRoundedRegion(clickedpanel.ClientRectangle,18);
                clickedpanel.Controls.Remove(editbox);
                db.UpdateData(tablename,"content",dex,clickedpanel.Controls[labelname].Text);
            }
        }

        private void MenuPanel1_ControlRemoved(object sender,ControlEventArgs e) {
            var numb = db.GetElements("Tables").Count;
            menuPanel1.Height=(numb)*40;
            if(numb==1) {
               menuPanel1.Height=40;
               menuPanel1.TextRender=true;
            }
        }

        private void PostTextBox_KeyDown(object sender,KeyEventArgs e) {
            if(e.KeyCode==Keys.Enter) {
                e.SuppressKeyPress=true;
                if(postTextBox.Text!="") {
                    createPost(postTextBox.Text,tablename);
                    postTextBox.Text="";
                    postTextBox.Focus();
                } else {
                    return;
                }
            }
        }

        public void listPosts(string content,string date,string time) {
            #region postpanel
            IronidePanel postpanel = new IronidePanel();
            postpanel.AutoSize = false;
            postpanel.Name = "post" + i;
            postpanel.BorderThickness = 0;
            postpanel.ForeColor = Color.Black;
            postpanel.BackColor=IronideColorizer.FromHex("282828");
            postpanel.BackColor2=postpanel.BackColor;
            postpanel.ContextMenuStrip=postRC;
            postpanel.MouseEnter+=PostPanel_MouseEnter;
            postpanel.MouseLeave+=PostPanel_MouseLeave;
            i =i+5;
            #endregion

            #region Content
            IronideLabel Content = new IronideLabel();
            Content.AutoSize = true;
            Content.Name="content"+i;
            Content.Text = content;
            Content.BackColor=Color.Transparent;
            Content.BackColor2=Color.Transparent;
            Content.ForeColor = Color.White;
            Content.Font = new Font("Tahoma",14);
            Content.MouseEnter+=Parent_MouseEnter;
            Content.MouseLeave+=Parent_MouseLeave;
            #endregion

            #region Date
            IronideLabel Date = new IronideLabel();
            Date.AutoSize=true;
            Date.ForeColor=Color.White;
            Date.BackColor=Color.Transparent;
            Date.BackColor2=Color.Transparent;
            Date.Text=date;
            Date.Location=new Point(22,5);
            Date.Font = new Font("Tahoma",8);
            Date.MouseEnter+=Parent_MouseEnter;
            Date.MouseLeave+=Parent_MouseLeave;
            postpanel.Controls.Add(Date);
            #endregion

            #region postTime
            IronideLabel postTime = new IronideLabel();
            postTime.AutoSize=true;
            postTime.ForeColor=Color.Gray;
            postTime.BackColor=Color.Transparent;
            postTime.BackColor2=postTime.BackColor;
            postTime.Text=time;
            postTime.Location=new Point((Date.Width/2)+(postTime.Width/2) + 5,5);
            postTime.Font=new Font("Tahoma",8);
            postTime.MouseEnter+=Parent_MouseEnter;
            postTime.MouseLeave+=Parent_MouseLeave;
            #endregion
            postpanel.Controls.Add(postTime);
            #region size
            postpanel.Controls.Add(Content);
            postpanel.Height = Content.Height+30;
            postpanel.Width = Content.Width+40;
            if(Date.Width+postTime.Width>Content.Width) {
                postpanel.Width=Date.Width+postTime.Width+40;
            }
            Content.Location = new Point((postpanel.Width / 2) - (Content.Width/2),(postpanel.Height / 2) - (Content.Height / 2) + 5);
            #endregion
            postpanel.Tag=db.GetData(tablename,"number",db.GetDataIndex(tablename,"content",Content.Text));
            postpanel.Region = IronideConvert.ToRoundedRegion(postpanel.ClientRectangle,18);
            messagesPanel.Controls.Add(postpanel);
        }

        private void createPost(string text,string table) {
            #region postPanel
            IronidePanel postPanel = new IronidePanel();
            postPanel.AutoSize=false;
            postPanel.Name="post"+i;
            postPanel.BorderThickness=0;
            postPanel.ForeColor=Color.Black;
            postPanel.BackColor=IronideColorizer.FromHex("282828");
            postPanel.BackColor2=postPanel.BackColor;
            postPanel.ContextMenuStrip=postRC;
            postPanel.MouseEnter+=PostPanel_MouseEnter;
            postPanel.MouseLeave+=PostPanel_MouseLeave;
            i=i+5;
            #endregion

            #region content
            IronideLabel content = new IronideLabel();
            content.AutoSize=true;
            content.BackColor=Color.Transparent;
            content.BackColor2=Color.Transparent;
            content.ForeColor=Color.White;
            content.Font=new Font("Tahoma",14);
            content.Name="content"+i;
            text=IronideWrapper.WordWrapPxStr(text,content.Font,800);
            content.Text=text;
            content.MouseEnter+=Parent_MouseEnter;
            content.MouseLeave+=Parent_MouseLeave;
            #endregion

            #region date
            IronideLabel date = new IronideLabel();
            date.AutoSize=true;
            date.ForeColor=Color.White;
            date.BackColor=Color.Transparent;
            date.BackColor2=date.BackColor;
            date.Text=DateTime.Now.ToString("MMM dd yyyy");
            date.Location=new Point(22,5);
            date.Font=new Font("Tahoma",8);
            date.MouseEnter+=Parent_MouseEnter;
            date.MouseLeave+=Parent_MouseLeave;
            #endregion

            #region time
            IronideLabel time = new IronideLabel();
            time.AutoSize=true;
            time.ForeColor=Color.Gray;
            time.BackColor=Color.Transparent;
            time.BackColor2=time.BackColor;
            time.Text=DateTime.Now.ToString("H:mm");
            time.Location=new Point((date.Width/2) + (time.Width/2) - 10,5);
            time.Font=new Font("Tahoma",8);
            time.MouseEnter+=Parent_MouseEnter;
            time.MouseLeave+=Parent_MouseLeave;

            #endregion
            postPanel.Controls.Add(time);
            postPanel.Controls.Add(date);
            postPanel.Controls.Add(content);
            #region size
            postPanel.Height=content.Height+30;
            postPanel.Width=content.Width+40;

            if(date.Width+time.Width>content.Width) {
                postPanel.Width=date.Width+time.Width+40;
            }
            #endregion
            content.Location=new Point((postPanel.Width/2) - (content.Width/2),(postPanel.Height/2) - (content.Height/2) + 5);
            postPanel.Region=IronideConvert.ToRoundedRegion(postPanel.ClientRectangle,18);
            messagesPanel.Controls.Add(postPanel);
            postPanel.Visible=true;
            db.AddData(tablename,"content",content.Text);
            db.UpdateLastData(tablename,"date",date.Text);
            db.UpdateLastData(tablename,"time",time.Text);
            postPanel.Tag=db.GetData(tablename,"number",db.GetDataIndex(tablename,"content",content.Text));
        }

        private void Parent_MouseEnter(object sender,EventArgs e) {
            IronidePanel panel = ((Control)sender).Parent as IronidePanel;
            panel.BackColor = IronideColorizer.FromHex("222222");
            panel.BackColor2=IronideColorizer.FromHex("222222");
        }

        private void Parent_MouseLeave(object sender,EventArgs e) {
            IronidePanel panel = ((Control)sender).Parent as IronidePanel;
            panel.BackColor = IronideColorizer.FromHex("282828");
            panel.BackColor2=IronideColorizer.FromHex("282828");
        }

        private void PostPanel_MouseLeave(object sender,EventArgs e) {
            IronidePanel panel = sender as IronidePanel;
            panel.BackColor=IronideColorizer.FromHex("282828");
            panel.BackColor2=IronideColorizer.FromHex("282828");
        }

        private void PostPanel_MouseEnter(object sender,EventArgs e) {
            IronidePanel panel = sender as IronidePanel;
            panel.BackColor= IronideColorizer.FromHex("222222");
            panel.BackColor2=IronideColorizer.FromHex("222222");
        }

        private void refresh() {
            mainPanel.Controls.Clear();
            menuPanel1.Controls.Clear();
            MochaTableResult mt = db.ExecuteScalarTable("USE * FROM Diaries RETURN");
            for(int i = 0; i < mt.Rows.Length; i++) {
                createButtons(mt.Rows[i].Datas[0].ToString(),mt.Rows[i].Datas[1].ToString(),mt.Rows[i].Datas[2].ToString());
            }
        }

        private void trypass() {
            var dex = db.GetDataIndex("Diaries","names",tablename);
            var passindb = db.GetData("Diaries","password",dex);
            if(passindb.ToString()==loginBox.Text) {
                if(messagesPanel.Visible==false&&postTextBox.Visible==false) {
                    messagesPanel.Show();
                    postTextBox.Show();
                    behindPostTextBox.Show();
                    messagesPanel.Controls.Clear();
                    MochaTable mt = db.GetTable($"{tablename}");
                    /*for(int a = mt.Rows.Count; a > 0; a--) {
                        listPosts(mt.Rows[a-1].Datas[0].ToString(),mt.Rows[a-1].Datas[1].ToString());

                    }*/
                    for(int a = 0; a < mt.Rows.Count; a++) {
                        listPosts(mt.Rows[a].Datas[0].ToString(),mt.Rows[a].Datas[1].ToString(),mt.Rows[a].Datas[2].ToString());
                    }
                }
                mainPanel.Hide();
                askingPassForm.Close();
                loginBox.InactiveBorderColor=askingPassForm.BorderColor;
                loginBox.ActiveBorderColor=loginBox.InactiveBorderColor;
                loginBox.Text="";
            } else {
                SystemSounds.Beep.Play();
                loginBox.ActiveBorderColor=Color.Red;
                loginBox.InactiveBorderColor=loginBox.ActiveBorderColor;
            }
        }

        private void EditButton_Click1(object sender,EventArgs e) {
            if(buttonsListEditing.SelectedIndex!=-1) {
                var buttonname = "D"+buttonsListEditing.SelectedItem;
                var dex = db.GetDataIndex("Diaries","names",buttonname);
                db.UpdateData("Diaries","names",dex,"D"+nameEditing.Text);
                db.UpdateData("Diaries","descs",dex,descEditing.Text);
                if(colorCheckerEditing.Checked==true) {
                    db.UpdateData("Diaries","color",dex,IronideColorizer.ToHtml(buttonColorEditing.Color));
                }
                db.RenameTable(buttonname,"D"+nameEditing.Text);
                mainPanel.Controls.Clear();
                menuPanel1.Controls.Clear();
                MochaTableResult mt = db.ExecuteScalarTable("USE * FROM Diaries RETURN");
                for(int i = 0; i < mt.Rows.Length; i++) {
                    createButtons(mt.Rows[i].Datas[0].ToString(),mt.Rows[i].Datas[1].ToString(),mt.Rows[i].Datas[2].ToString());
                }
                editingForm.Close();
            } else {
                return;
            }
        }

        private void BigOneRC_ItemClicked(object sender,ToolStripItemClickedEventArgs e) {
            buttonname = "D"+bigOneRC.SourceControl.Name;
            if(e.ClickedItem.Text=="Edit this diary") {
                var dex = db.GetDataIndex("Diaries","names",buttonname);
                buttonsListEditing.SelectedIndex=dex;
                editingForm.ShowDialog();
            }
            if(e.ClickedItem.Text=="Remove this diary") {
                if(MessageBox.Show("Are you sure to remove this diary?","Remove a Diary",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes) {
                    db.RemoveTable(buttonname);
                    db.RemoveRow("Diaries",db.GetDataIndex("Diaries","names",buttonname));
                    refresh();
                    ListButtons(buttonsListEditing);
                    ListButtons(buttonsList);
                } else {
                }
            }
            if(e.ClickedItem.Text=="Change this diary's password") {
                changePassForm.ShowDialog();
            }
        }

        private void HomepageButton_Click(object sender,EventArgs e) {
            goToHomepage();
        }
        
        private void ColorCheckerEditing_CheckedChanged(object sender,EventArgs e) {
            if(colorCheckerEditing.Checked==true){
                buttonColorEditing.Show();
            }else {
                buttonColorEditing.Hide();
            }
        }

        private void goToHomepage() {
            mainPanel.Show();
            messagesPanel.Hide();
            behindPostTextBox.Hide();
        }

        private void ButtonsListEditing_SelectedIndexChanged(object sender,EventArgs e) {
            descEditing.Enabled=true;
            nameEditing.Enabled=true;
            buttonColorEditing.Enabled=true;
            var buttonname = "D"+buttonsListEditing.Items[buttonsListEditing.SelectedIndex];
            nameEditing.Text=buttonname.Substring(1).ToString();
            var dex = db.GetDataIndex("Diaries","names",buttonname);
            var buttondesc = db.GetData("Diaries","descs",dex);
            descEditing.Text=buttondesc.ToString();
            var buttoncolor = db.GetData("Diaries","color",dex);
            buttonColorEditing.Color=IronideColorizer.FromHtml(buttoncolor.ToString());
        }

        private void EditButton_Click(object sender,EventArgs e) {
            descEditing.Text="";
            nameEditing.Text="";
            buttonsListEditing.Placeholder="Select a button";
            if(mainPanel.Controls.Count<1) {
                buttonsListEditing.Enabled=false;
            } else {
                descEditing.Enabled=true;
                nameEditing.Enabled=true;
                buttonColorEditing.Enabled=true;
                editButton.Enabled=true;
                colorCheckerEditing.Enabled=true;
            }
            if(buttonsListEditing.SelectedIndex<0) {
                descEditing.Enabled=false;
                nameEditing.Enabled=false;
                buttonColorEditing.Enabled=false;
                //editButton.Enabled=false;
                //colorCheckerEditing.Enabled=false;
            } else {
                descEditing.Enabled=true;
                nameEditing.Enabled=true;
                buttonColorEditing.Enabled=true;
            }
            editingForm.ShowDialog();
            ListButtons(buttonsListEditing);
        }
        
        private void RemoveButton_Click(object sender,EventArgs e) {
            if(buttonsList.SelectedIndex!=-1) {
                if(MessageBox.Show("Are you sure to remove this diary?","Remove a Diary",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes) {
                    db.RemoveTable("D"+buttonsList.SelectedItem.ToString());
                    db.RemoveRow("Diaries",db.GetDataIndex("Diaries","names","D"+buttonsList.SelectedItem));
                    goToHomepage();
                    refresh();
                    removingForm.Close();
                    ListButtons(buttonsList);
                } else {
                }
            }
        }

        private void MainPanel_ControlAdded(object sender,ControlEventArgs e) {
            buttonsList.Enabled=true;
            buttonsListEditing.Enabled=true;
            ListButtons(buttonsList);
            ListButtons(buttonsListEditing);
        }

        private void RemovingButton_Click(object sender,EventArgs e) {
            if(mainPanel.Controls.Count>0) {
                buttonsList.Enabled=true;
            } else {
                buttonsList.Enabled=false;
            }
            removingForm.ShowDialog();
        }

        private void ListButtons(IronideComboBox combobox) {
            combobox.Items.Clear();
            foreach(IronideButton b in mainPanel.Controls) {
                combobox.Items.Add(b.Name);
            }
        }

        private void ColorChecker_CheckedChanged(object sender,EventArgs e) {
            if(colorChecker.Checked==true) {
                buttonColor.Show();
            } else {
                buttonColor.Hide();
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            #region diaryButton
            IronideButton diaryButton = new IronideButton();
            diaryButton.Name = name.Text;
            diaryButton.Size = new Size(251, 40);
            diaryButton.Text = "  "+name.Text;
            diaryButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            diaryButton.Dock = DockStyle.Top;
            diaryButton.TextAlign = ContentAlignment.MiddleLeft;
            diaryButton.BorderThickness = 0;
            diaryButton.BackColor = IronideColorizer.FromHtml("#484848");
            diaryButton.BackColor2 = diaryButton.BackColor;
            diaryButton.EnterColor = IronideColorizer.FromHtml("#262626");
            diaryButton.HoverColor = IronideColorizer.FromHtml("#4d4d4d");
            diaryButton.ForeColor = Color.White;
            if(menuPanel1.Controls.Count > 0) {
                menuPanel1.TextRender = false;
            } else {
                menuPanel1.TextRender = true;
            }
            diaryButton.MouseClick += BigDiaryButton_MouseClick;
            #endregion

            #region bigDiaryButton
            IronideButton bigDiaryButton = new IronideButton();
            bigDiaryButton.Size= new Size(384,186);
            if(colorChecker.Checked==true) {
                bigDiaryButton.BorderThickness=2;
                bigDiaryButton.BorderColor=buttonColor.Color;
            } else {
                bigDiaryButton.BorderThickness=0;
            }
            
            bigDiaryButton.BackColor=IronideColorizer.FromHtml("#595959");
            bigDiaryButton.HoverColor=IronideColorizer.FromHtml("#6f6f73");
            bigDiaryButton.EnterColor=IronideColorizer.FromHtml("#595959");
            bigDiaryButton.Font=new Font("Microsoft Sans Serif",12,FontStyle.Regular);
            bigDiaryButton.ForeColor=Color.White;
            bigDiaryButton.BackColor2=bigDiaryButton.BackColor;
            bigDiaryButton.Anchor=AnchorStyles.Left|AnchorStyles.Right|AnchorStyles.Top;
            bigDiaryButton.Name=name.Text;
            bigDiaryButton.Text=name.Text+"\n\n\n"+desc.Text;
            bigDiaryButton.ContextMenuStrip=bigOneRC;
            bigDiaryButton.MouseClick+=BigDiaryButton_MouseClick;

            #endregion

            if(db.ExistsTable("D"+name.Text)==true) {
                MessageBox.Show("Sorry, there is a diary with the same name","Name Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                menuPanel1.TextRender=true;
            } else {
                if(name.Text=="") {
                    MessageBox.Show("Sorry, the diary can not be nameless","Name Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    menuPanel1.TextRender=true;
                } else {
                    db.AddData("Diaries","names","D"+name.Text);
                    name.Text=name.Text.Replace(" ",String.Empty);
                    db.CreateTable("D"+name.Text);
                    db.AddColumn("D"+name.Text,new MochaColumn("content"));
                    db.AddColumn("D"+name.Text,new MochaColumn("date"));
                    db.AddColumn("D"+name.Text,new MochaColumn("time"));
                    db.AddColumn("D"+name.Text,new MochaColumn("number"));
                    db.SetColumnDataType("D"+name.Text,"number",MochaDataType.AutoInt);
                    db.UpdateLastData("Diaries","descs",desc.Text);
                    if(passwordChecker.Checked==true) {
                        db.UpdateLastData("Diaries","password",passwordBox.Text);
                    }
                    if(bigDiaryButton.BorderThickness>0) {
                        db.UpdateLastData("Diaries","color",IronideColorizer.ToHtml(bigDiaryButton.BorderColor));
                    } else {
                        db.UpdateLastData("Diaries","color",IronideColorizer.ToHtml(Color.Transparent));
                    }
                    mainPanel.Controls.Add(bigDiaryButton);
                    menuPanel1.Controls.Add(diaryButton);
                    menuPanel1.TextRender=false;
                    desc.Text = "";
                    name.Text = "";
                    passwordBox.Text="";
                    creatingForm.Close();
                }
            }
        }

        public void createButtons(string buttonName,string buttonDesc,string color) {
            #region bigOne
            IronideButton bigDiaryButton = new IronideButton();
            bigDiaryButton.Size= new Size(384,186);
            bigDiaryButton.BorderColor=IronideColorizer.FromHtml(color);
            bigDiaryButton.BorderThickness=2;
            bigDiaryButton.BackColor=IronideColorizer.FromHtml("#595959");
            bigDiaryButton.HoverColor=IronideColorizer.FromHtml("#6f6f73");
            bigDiaryButton.EnterColor=IronideColorizer.FromHtml("#595959");
            bigDiaryButton.Font=new Font("Microsoft Sans Serif",12,FontStyle.Regular);
            bigDiaryButton.ForeColor=Color.White;
            bigDiaryButton.BackColor2=bigDiaryButton.BackColor;
            bigDiaryButton.Anchor=AnchorStyles.Left|AnchorStyles.Right|AnchorStyles.Top;
            bigDiaryButton.Name=buttonName.Substring(1);
            bigDiaryButton.Text=buttonName.Substring(1)+"\n\n\n"+buttonDesc;
            bigDiaryButton.ContextMenuStrip=bigOneRC;
            bigDiaryButton.MouseClick+=BigDiaryButton_MouseClick;
            mainPanel.Controls.Add(bigDiaryButton);
            #endregion
            #region littleOne
            IronideButton diaryButton = new IronideButton();
            diaryButton.Name = buttonName.Substring(1);
            diaryButton.Size = new Size(251,40);
            diaryButton.Text = "  "+buttonName.Substring(1);
            diaryButton.Font = new Font("Microsoft Sans Serif",12,FontStyle.Regular);
            diaryButton.Dock = DockStyle.Top;
            diaryButton.TextAlign = ContentAlignment.MiddleLeft;
            diaryButton.BorderThickness = 0;
            diaryButton.BackColor = IronideColorizer.FromHtml("#484848");
            diaryButton.BackColor2 = diaryButton.BackColor;
            diaryButton.EnterColor = IronideColorizer.FromHtml("#262626");
            diaryButton.HoverColor = IronideColorizer.FromHtml("#4d4d4d");
            diaryButton.ForeColor = Color.White;
            if(menuPanel1.TextRender == true) {
                menuPanel1.TextRender = false;
            }
            diaryButton.MouseClick += BigDiaryButton_MouseClick;
            menuPanel1.Controls.Add(diaryButton);
            #endregion
        }
        
        private void MenuPanel1_ControlAdded(object sender,ControlEventArgs e) {
            var numb = db.GetElements("Tables").Count;
            menuPanel1.Height=(numb)*40;
            if(numb==1) {
                menuPanel1.TextRender=true;
            }
        }
        
        private void BigDiaryButton_MouseClick(object sender,MouseEventArgs e) {
            IronideButton asd = sender as IronideButton;
            tablename = "D"+asd.Name.Replace(" ",String.Empty);
            if(e.Button == MouseButtons.Left) {
                var dex = db.GetDataIndex("Diaries","names",tablename);
                var pass = db.GetData("Diaries","password",dex).ToString();
                if(pass!="") {
                    askingPassForm.ShowDialog();
                } else {
                    if(messagesPanel.Visible==false&&postTextBox.Visible==false) {
                        messagesPanel.Show();
                        postTextBox.Show();
                        behindPostTextBox.Show();
                        messagesPanel.Controls.Clear();
                        MochaTable mt = db.GetTable($"{tablename}");
                        /*for(int a = mt.Rows.Count; a > 0; a--) {
                            listPosts(mt.Rows[a-1].Datas[0].ToString(),mt.Rows[a-1].Datas[1].ToString());

                        }*/
                        for(int a = 0; a < mt.Rows.Count; a++) {
                            listPosts(mt.Rows[a].Datas[0].ToString(),mt.Rows[a].Datas[1].ToString(),mt.Rows[a].Datas[2].ToString());
                        }
                    }
                    mainPanel.Hide();
                    askingPassForm.Close();
                }
                
            }
        }

        private void AddingButton_Click(object sender, EventArgs e)
        {
            name.Text="";
            desc.Text="";
            colorChecker.Checked=false;
            buttonColor.Color=Color.White;
            creatingForm.ShowDialog();
        }   

        private void ActionsButton_Click(object sender, EventArgs e)
        {
            if(actionsPanel.Visible==false) {
                actionsPanel.Show();
            } else {
                actionsPanel.Hide();
            }
        }

        private void MenuButton1_Click(object sender, EventArgs e)
        {
            if(menuPanel1.Visible==false) {
                menuPanel1.Show();
            } else {
                menuPanel1.Hide();
            }
        }

        private void openbutton_Click(object sender, EventArgs e)
        {
            openbutton.Visible=false;
            leftpanel.Toggle();
            openbutton.Visible=true;
            if (leftpanel.Visible == false)
            {
                mainPanel.Location=new Point(BorderThickness,mainPanel.Location.Y);
                mainPanel.Size=new Size(Width-(BorderThickness * 2),mainPanel.Height);
                messagesPanel.Location=new Point(BorderThickness,messagesPanel.Location.Y);
                messagesPanel.Size=new Size(Width-(BorderThickness * 2),messagesPanel.Height);
                openbutton.Left -= leftpanel.Width;
                behindPostTextBox.Width+=leftpanel.Width;
                behindPostTextBox.Left-=leftpanel.Width;
                postTextBox.Width+=leftpanel.Width;
                behindPostTextBox.Region=IronideConvert.ToRoundedRegion(behindPostTextBox.ClientRectangle,25);
            }
            else
            {
                mainPanel.Location=new Point(leftpanel.Width,mainPanel.Location.Y);
                mainPanel.Size=new Size((Width-mainPanel.Location.X)-BorderThickness,mainPanel.Height);
                messagesPanel.Location=new Point(leftpanel.Width+3,messagesPanel.Location.Y);
                messagesPanel.Size=new Size((Width-messagesPanel.Location.X)-BorderThickness,messagesPanel.Height);
                openbutton.Left += leftpanel.Width;
                behindPostTextBox.Width-=leftpanel.Width;
                behindPostTextBox.Left+=leftpanel.Width;
                postTextBox.Width-=leftpanel.Width;
                behindPostTextBox.Region=IronideConvert.ToRoundedRegion(behindPostTextBox.ClientRectangle,25);
            }
        }

        private void postRC_ItemClicked(object sender,ToolStripItemClickedEventArgs e) {
            var itemname = e.ClickedItem.Name;
            
            if(editbox.Visible==false) {
                clickedpanel = postRC.SourceControl;
                var name = Int32.Parse(clickedpanel.Name.Substring(4))+5;
                labelname = "content"+name;
                if(itemname=="firstitem") {
                    editbox.Visible=true;
                    editbox.Width=clickedpanel.Width-40;
                    editbox.Location = new Point((clickedpanel.Width / 2) - (editbox.Width/2),(clickedpanel.Height / 2) - (editbox.Height / 2) + 5);
                    clickedpanel.Controls[labelname].Visible=false;
                    clickedpanel.Controls.Add(editbox);
                    editbox.Text=clickedpanel.Controls[labelname].Text;
                    editbox.SelectionStart=editbox.Text.Length;
                    editbox.Focus();
                }
            } else {
                SystemSounds.Beep.Play();
            }
            if(itemname=="seconditem") {
                if(MessageBox.Show("Are you sure to remove this post?","Remove a post",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes) {
                    messagesPanel.Controls.Remove(clickedpanel);
                    db.RemoveRow(tablename,db.GetDataIndex(tablename,"number",clickedpanel.Tag));
                }
            }
        }
        #endregion
    }
}
