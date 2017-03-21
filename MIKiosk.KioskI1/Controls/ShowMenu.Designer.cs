namespace MIKiosk.KioskI1.Controls
{
    partial class ShowMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.CarouselEllipsePath carouselEllipsePath2 = new Telerik.WinControls.UI.CarouselEllipsePath();
            this.radCarousel1 = new Telerik.WinControls.UI.RadCarousel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radCarousel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radCarousel1
            // 
            carouselEllipsePath2.Center = new Telerik.WinControls.UI.Point3D(50D, 50D, 0D);
            carouselEllipsePath2.FinalAngle = -100D;
            carouselEllipsePath2.InitialAngle = -90D;
            carouselEllipsePath2.U = new Telerik.WinControls.UI.Point3D(-20D, -17D, -50D);
            carouselEllipsePath2.V = new Telerik.WinControls.UI.Point3D(30D, -25D, -60D);
            carouselEllipsePath2.ZScale = 500D;
            this.radCarousel1.CarouselPath = carouselEllipsePath2;
            this.radCarousel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radCarousel1.Location = new System.Drawing.Point(0, 50);
            this.radCarousel1.Name = "radCarousel1";
            this.radCarousel1.SelectedIndex = 0;
            this.radCarousel1.Size = new System.Drawing.Size(661, 386);
            this.radCarousel1.TabIndex = 0;
            this.radCarousel1.Text = "radCarousel1";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radButton3);
            this.radPanel1.Controls.Add(this.radButton2);
            this.radPanel1.Controls.Add(this.radButton1);
            this.radPanel1.Controls.Add(this.radTextBox1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(661, 50);
            this.radPanel1.TabIndex = 1;
            this.radPanel1.ThemeName = "TelerikMetro";
            // 
            // radButton3
            // 
            this.radButton3.Dock = System.Windows.Forms.DockStyle.Left;
            this.radButton3.Location = new System.Drawing.Point(0, 0);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(130, 50);
            this.radButton3.TabIndex = 3;
            this.radButton3.Text = "Categorys";
            this.radButton3.ThemeName = "TelerikMetro";
            this.radButton3.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // radButton2
            // 
            this.radButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.radButton2.Location = new System.Drawing.Point(531, 0);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(130, 50);
            this.radButton2.TabIndex = 2;
            this.radButton2.Text = "Checkout";
            this.radButton2.ThemeName = "TelerikMetro";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(280, 24);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(28, 23);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "go";
            this.radButton1.ThemeName = "TelerikMetro";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radTextBox1
            // 
            this.radTextBox1.Location = new System.Drawing.Point(136, 24);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(138, 23);
            this.radTextBox1.TabIndex = 0;
            this.radTextBox1.TabStop = false;
            this.radTextBox1.Text = "Search Items here";
            this.radTextBox1.ThemeName = "TelerikMetro";
            // 
            // ShowMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.radCarousel1);
            this.Controls.Add(this.radPanel1);
            this.Name = "ShowMenu";
            this.Size = new System.Drawing.Size(661, 436);
            this.Load += new System.EventHandler(this.ShowMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radCarousel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadCarousel radCarousel1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
    }
}
