namespace Servicio_Tralix
{
    partial class Interfaz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interfaz));
            this.EmpresaCB = new System.Windows.Forms.ComboBox();
            this.EmpresaLbl = new System.Windows.Forms.Label();
            this.progresoTxt = new System.Windows.Forms.RichTextBox();
            this.DirectorioLbl = new System.Windows.Forms.Label();
            this.BuscarBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.TItuloLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EmpresaCB
            // 
            this.EmpresaCB.FormattingEnabled = true;
            this.EmpresaCB.Items.AddRange(new object[] {
            "CAMSA",
            "MASERTEC",
            "MISA",
            "OIA",
            "OIH",
            "TRONCALNET",
            "FOTUNAL"});
            this.EmpresaCB.Location = new System.Drawing.Point(170, 65);
            this.EmpresaCB.Name = "EmpresaCB";
            this.EmpresaCB.Size = new System.Drawing.Size(165, 21);
            this.EmpresaCB.TabIndex = 0;
            this.EmpresaCB.SelectedIndexChanged += new System.EventHandler(this.EmpresaCB_SelectedIndexChanged);
            // 
            // EmpresaLbl
            // 
            this.EmpresaLbl.AutoSize = true;
            this.EmpresaLbl.Location = new System.Drawing.Point(33, 68);
            this.EmpresaLbl.Name = "EmpresaLbl";
            this.EmpresaLbl.Size = new System.Drawing.Size(104, 13);
            this.EmpresaLbl.TabIndex = 1;
            this.EmpresaLbl.Text = "Seleccione Empresa";
            // 
            // progresoTxt
            // 
            this.progresoTxt.Location = new System.Drawing.Point(36, 162);
            this.progresoTxt.Name = "progresoTxt";
            this.progresoTxt.ReadOnly = true;
            this.progresoTxt.Size = new System.Drawing.Size(361, 180);
            this.progresoTxt.TabIndex = 2;
            this.progresoTxt.Text = "";
            // 
            // DirectorioLbl
            // 
            this.DirectorioLbl.AutoSize = true;
            this.DirectorioLbl.Location = new System.Drawing.Point(33, 109);
            this.DirectorioLbl.Name = "DirectorioLbl";
            this.DirectorioLbl.Size = new System.Drawing.Size(234, 13);
            this.DirectorioLbl.TabIndex = 3;
            this.DirectorioLbl.Text = "Seleccione el Directorio con los XML a procesar";
            // 
            // BuscarBtn
            // 
            this.BuscarBtn.Location = new System.Drawing.Point(170, 133);
            this.BuscarBtn.Name = "BuscarBtn";
            this.BuscarBtn.Size = new System.Drawing.Size(75, 23);
            this.BuscarBtn.TabIndex = 4;
            this.BuscarBtn.Text = "Buscar";
            this.BuscarBtn.UseVisualStyleBackColor = true;
            this.BuscarBtn.Click += new System.EventHandler(this.BuscarBtn_Click);
            // 
            // TItuloLbl
            // 
            this.TItuloLbl.AutoSize = true;
            this.TItuloLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TItuloLbl.Location = new System.Drawing.Point(132, 22);
            this.TItuloLbl.Name = "TItuloLbl";
            this.TItuloLbl.Size = new System.Drawing.Size(190, 20);
            this.TItuloLbl.TabIndex = 5;
            this.TItuloLbl.Text = "Cancelación de facturas";
            // 
            // Interfaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 354);
            this.Controls.Add(this.TItuloLbl);
            this.Controls.Add(this.BuscarBtn);
            this.Controls.Add(this.DirectorioLbl);
            this.Controls.Add(this.progresoTxt);
            this.Controls.Add(this.EmpresaLbl);
            this.Controls.Add(this.EmpresaCB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Interfaz";
            this.Text = "Servicio Tralix";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EmpresaCB;
        private System.Windows.Forms.Label EmpresaLbl;
        private System.Windows.Forms.RichTextBox progresoTxt;
        private System.Windows.Forms.Label DirectorioLbl;
        private System.Windows.Forms.Button BuscarBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label TItuloLbl;
    }
}

