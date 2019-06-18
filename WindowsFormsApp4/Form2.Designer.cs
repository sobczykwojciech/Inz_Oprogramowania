namespace WindowsFormsApp4
{
    partial class StartAplikacji
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
            this.UruchomHarmonogram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UruchomHarmonogram
            // 
            this.UruchomHarmonogram.Location = new System.Drawing.Point(12, 12);
            this.UruchomHarmonogram.Name = "UruchomHarmonogram";
            this.UruchomHarmonogram.Size = new System.Drawing.Size(152, 42);
            this.UruchomHarmonogram.TabIndex = 0;
            this.UruchomHarmonogram.Text = "Uruchom standardowy harmonogram";
            this.UruchomHarmonogram.UseVisualStyleBackColor = true;
            this.UruchomHarmonogram.Click += new System.EventHandler(this.UruchomHarmonogram_Click);
            // 
            // StartAplikacji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(177, 66);
            this.Controls.Add(this.UruchomHarmonogram);
            this.Name = "StartAplikacji";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UruchomHarmonogram;
    }
}