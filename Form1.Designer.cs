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

namespace İronideDeneme
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openbutton = new Ironide.IronideButton();
            this.leftpanel = new Ironide.IronideSlidePanel();
            this.version = new Ironide.IronideLabel();
            this.postRC = new Ironide.Components.IronideContextMenuStrip();
            this.firstitem = new Ironide.IronideToolStripMenuItem();
            this.seconditem = new Ironide.IronideToolStripMenuItem();
            this.leftpanel.SuspendLayout();
            this.postRC.SuspendLayout();
            this.SuspendLayout();
            // 
            // openbutton
            // 
            this.openbutton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.openbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openbutton.EnterColor = System.Drawing.Color.Gray;
            this.openbutton.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openbutton.HoverColor = System.Drawing.Color.DimGray;
            this.openbutton.ImageLocation = new System.Drawing.Point(1, 1);
            this.openbutton.ImageSize = new System.Drawing.Size(10, 10);
            this.openbutton.Location = new System.Drawing.Point(-5, 324);
            this.openbutton.Name = "openbutton";
            this.openbutton.Size = new System.Drawing.Size(34, 53);
            this.openbutton.TabIndex = 4;
            this.openbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.openbutton.Click += new System.EventHandler(this.openbutton_Click);
            // 
            // leftpanel
            // 
            this.leftpanel.BackColor = System.Drawing.SystemColors.Control;
            this.leftpanel.BorderThickness = 0;
            this.leftpanel.Controls.Add(this.version);
            this.leftpanel.Delay = 120;
            this.leftpanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftpanel.Location = new System.Drawing.Point(3, 28);
            this.leftpanel.Name = "leftpanel";
            this.leftpanel.Size = new System.Drawing.Size(251, 671);
            this.leftpanel.TabIndex = 5;
            this.leftpanel.Text = "ıronideSlidePanel1";
            // 
            // version
            // 
            this.version.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.version.AutoSize = true;
            this.version.BackColor = System.Drawing.SystemColors.Control;
            this.version.Location = new System.Drawing.Point(211, 658);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(37, 13);
            this.version.TabIndex = 6;
            this.version.Text = "v1.0.1";
            // 
            // postRC
            // 
            this.postRC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.postRC.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.postRC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstitem,
            this.seconditem});
            this.postRC.Name = "postRC";
            this.postRC.Size = new System.Drawing.Size(166, 48);
            this.postRC.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.postRC_ItemClicked);
            // 
            // firstitem
            // 
            this.firstitem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.firstitem.ForeColor = System.Drawing.Color.White;
            this.firstitem.HoverColor = System.Drawing.SystemColors.GrayText;
            this.firstitem.Name = "firstitem";
            this.firstitem.Size = new System.Drawing.Size(165, 22);
            this.firstitem.Text = "Edit this post";
            // 
            // seconditem
            // 
            this.seconditem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.seconditem.ForeColor = System.Drawing.Color.White;
            this.seconditem.HoverColor = System.Drawing.SystemColors.GrayText;
            this.seconditem.Name = "seconditem";
            this.seconditem.Size = new System.Drawing.Size(165, 22);
            this.seconditem.Text = "Remove this post";
            // 
            // Form1
            // 
            this.Animation = Ironide.IronideFormAnimation.Fade;
            this.AnimationDelay = ((uint)(15u));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderColor = System.Drawing.Color.Transparent;
            this.BorderThickness = 3;
            this.ClientSize = new System.Drawing.Size(1182, 702);
            this.CloseBoxHoverColor = System.Drawing.Color.Red;
            this.Controls.Add(this.openbutton);
            this.Controls.Add(this.leftpanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBoxEnterColor = System.Drawing.Color.DimGray;
            this.MaximizeBoxHoverColor = System.Drawing.Color.DimGray;
            this.MinimizeBoxEnterColor = System.Drawing.Color.DimGray;
            this.MinimizeBoxHoverColor = System.Drawing.Color.DimGray;
            this.Name = "Form1";
            this.Text = " ";
            this.Title = "ZeitBook";
            this.TitlebarBackColor = System.Drawing.Color.AliceBlue;
            this.TitlebarIconWidth = 25;
            this.Controls.SetChildIndex(this.leftpanel, 0);
            this.Controls.SetChildIndex(this.openbutton, 0);
            this.leftpanel.ResumeLayout(false);
            this.leftpanel.PerformLayout();
            this.postRC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Ironide.IronideButton openbutton;
        private Ironide.IronideSlidePanel leftpanel;
        private Ironide.IronideLabel version;
        private Ironide.Components.IronideContextMenuStrip postRC;
        private Ironide.IronideToolStripMenuItem firstitem;
        private Ironide.IronideToolStripMenuItem seconditem;
    }
}

