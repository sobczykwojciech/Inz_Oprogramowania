namespace Program1
{
    partial class HarmonogramStandard
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.Licz = new System.Windows.Forms.Button();
            this.Hm = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.OpisDataOstRaty = new System.Windows.Forms.Label();
            this.DataKredytu = new System.Windows.Forms.DateTimePicker();
            this.DataRatyOst = new System.Windows.Forms.DateTimePicker();
            this.KwotaKredytu = new System.Windows.Forms.Label();
            this.WartKwotaKredytu = new System.Windows.Forms.TextBox();
            this.IloscRat = new System.Windows.Forms.TextBox();
            this.OpisIloscRat = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Oprocentowanie = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DlaRat = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RodzajRatBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Export = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Hm)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Licz
            // 
            this.Licz.Location = new System.Drawing.Point(12, 107);
            this.Licz.Name = "Licz";
            this.Licz.Size = new System.Drawing.Size(208, 23);
            this.Licz.TabIndex = 0;
            this.Licz.Text = "Licz";
            this.Licz.UseVisualStyleBackColor = true;
            this.Licz.Click += new System.EventHandler(this.button1_Click);
            // 
            // Hm
            // 
            this.Hm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Hm.BackgroundColor = System.Drawing.SystemColors.Window;
            this.Hm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Hm.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.Hm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Hm.Location = new System.Drawing.Point(12, 136);
            this.Hm.Name = "Hm";
            this.Hm.ReadOnly = true;
            this.Hm.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Hm.Size = new System.Drawing.Size(638, 421);
            this.Hm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data kredytu";
            // 
            // OpisDataOstRaty
            // 
            this.OpisDataOstRaty.AutoSize = true;
            this.OpisDataOstRaty.Location = new System.Drawing.Point(6, 68);
            this.OpisDataOstRaty.Name = "OpisDataOstRaty";
            this.OpisDataOstRaty.Size = new System.Drawing.Size(92, 13);
            this.OpisDataOstRaty.TabIndex = 5;
            this.OpisDataOstRaty.Text = "Data ostatniej raty";
            // 
            // DataKredytu
            // 
            this.DataKredytu.Location = new System.Drawing.Point(163, 19);
            this.DataKredytu.Name = "DataKredytu";
            this.DataKredytu.Size = new System.Drawing.Size(194, 20);
            this.DataKredytu.TabIndex = 8;
            this.DataKredytu.Value = new System.DateTime(2018, 11, 15, 0, 0, 0, 0);
            // 
            // DataRatyOst
            // 
            this.DataRatyOst.Location = new System.Drawing.Point(163, 61);
            this.DataRatyOst.Name = "DataRatyOst";
            this.DataRatyOst.Size = new System.Drawing.Size(194, 20);
            this.DataRatyOst.TabIndex = 9;
            this.DataRatyOst.Value = new System.DateTime(2023, 10, 31, 0, 0, 0, 0);
            // 
            // KwotaKredytu
            // 
            this.KwotaKredytu.AutoSize = true;
            this.KwotaKredytu.Cursor = System.Windows.Forms.Cursors.No;
            this.KwotaKredytu.Location = new System.Drawing.Point(6, 19);
            this.KwotaKredytu.Name = "KwotaKredytu";
            this.KwotaKredytu.Size = new System.Drawing.Size(75, 13);
            this.KwotaKredytu.TabIndex = 11;
            this.KwotaKredytu.Text = "Kwota kredytu";
            // 
            // WartKwotaKredytu
            // 
            this.WartKwotaKredytu.Location = new System.Drawing.Point(131, 19);
            this.WartKwotaKredytu.Name = "WartKwotaKredytu";
            this.WartKwotaKredytu.Size = new System.Drawing.Size(117, 20);
            this.WartKwotaKredytu.TabIndex = 12;
            this.WartKwotaKredytu.Text = "100000";
            this.WartKwotaKredytu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // IloscRat
            // 
            this.IloscRat.Location = new System.Drawing.Point(261, 61);
            this.IloscRat.Name = "IloscRat";
            this.IloscRat.Size = new System.Drawing.Size(96, 20);
            this.IloscRat.TabIndex = 13;
            this.IloscRat.Text = "60";
            this.IloscRat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IloscRat.Visible = false;
            // 
            // OpisIloscRat
            // 
            this.OpisIloscRat.AutoSize = true;
            this.OpisIloscRat.Cursor = System.Windows.Forms.Cursors.No;
            this.OpisIloscRat.Location = new System.Drawing.Point(6, 68);
            this.OpisIloscRat.Name = "OpisIloscRat";
            this.OpisIloscRat.Size = new System.Drawing.Size(44, 13);
            this.OpisIloscRat.TabIndex = 14;
            this.OpisIloscRat.Text = "Ilość rat";
            this.OpisIloscRat.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.No;
            this.label5.Location = new System.Drawing.Point(38, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Oprocentowanie";
            // 
            // Oprocentowanie
            // 
            this.Oprocentowanie.Location = new System.Drawing.Point(131, 41);
            this.Oprocentowanie.Name = "Oprocentowanie";
            this.Oprocentowanie.Size = new System.Drawing.Size(117, 20);
            this.Oprocentowanie.TabIndex = 15;
            this.Oprocentowanie.Text = "10";
            this.Oprocentowanie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.No;
            this.label6.Location = new System.Drawing.Point(6, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Rodzaj rat";
            // 
            // DlaRat
            // 
            this.DlaRat.AutoSize = true;
            this.DlaRat.Location = new System.Drawing.Point(6, 41);
            this.DlaRat.Name = "DlaRat";
            this.DlaRat.Size = new System.Drawing.Size(148, 17);
            this.DlaRat.TabIndex = 20;
            this.DlaRat.Text = "harmonogram wg ilości rat";
            this.DlaRat.UseVisualStyleBackColor = true;
            this.DlaRat.CheckedChanged += new System.EventHandler(this.DlaRat_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DlaRat);
            this.groupBox1.Controls.Add(this.OpisDataOstRaty);
            this.groupBox1.Controls.Add(this.DataKredytu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.DataRatyOst);
            this.groupBox1.Controls.Add(this.OpisIloscRat);
            this.groupBox1.Controls.Add(this.IloscRat);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 89);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RodzajRatBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.KwotaKredytu);
            this.groupBox2.Controls.Add(this.WartKwotaKredytu);
            this.groupBox2.Controls.Add(this.Oprocentowanie);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(390, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 89);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // RodzajRatBox
            // 
            this.RodzajRatBox.CausesValidation = false;
            this.RodzajRatBox.FormattingEnabled = true;
            this.RodzajRatBox.Items.AddRange(new object[] {
            "Równe",
            "Malejące",
            "Indywidualne"});
            this.RodzajRatBox.Location = new System.Drawing.Point(131, 62);
            this.RodzajRatBox.Name = "RodzajRatBox";
            this.RodzajRatBox.Size = new System.Drawing.Size(117, 21);
            this.RodzajRatBox.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.No;
            this.label7.Location = new System.Drawing.Point(3, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Oprocentowanie";
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(390, 106);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(130, 23);
            this.Export.TabIndex = 24;
            this.Export.Text = "Export";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(526, 106);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(123, 23);
            this.Import.TabIndex = 25;
            this.Import.Text = "Import";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // HarmonogramStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(666, 569);
            this.Controls.Add(this.Import);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Hm);
            this.Controls.Add(this.Licz);
            this.Name = "HarmonogramStandard";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Hm)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Licz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label OpisDataOstRaty;
        private System.Windows.Forms.DateTimePicker DataRatyOst;
        private System.Windows.Forms.Label KwotaKredytu;
        private System.Windows.Forms.TextBox WartKwotaKredytu;
        private System.Windows.Forms.TextBox IloscRat;
        private System.Windows.Forms.Label OpisIloscRat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Oprocentowanie;
        public System.Windows.Forms.DateTimePicker DataKredytu;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DataGridView Hm;
        private System.Windows.Forms.CheckBox DlaRat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox RodzajRatBox;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button Import;
    }
}

