namespace KlikaczBot
{
    partial class DobraForma
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
            this.btnClick = new System.Windows.Forms.Button();
            this.webOkno = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webOkno)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClick
            // 
            this.btnClick.Location = new System.Drawing.Point(24, 54);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(227, 99);
            this.btnClick.TabIndex = 5;
            this.btnClick.Text = "Click";
            this.btnClick.UseVisualStyleBackColor = true;
            // 
            // webOkno
            // 
            this.webOkno.AllowExternalDrop = true;
            this.webOkno.CreationProperties = null;
            this.webOkno.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webOkno.Location = new System.Drawing.Point(321, 25);
            this.webOkno.Name = "webOkno";
            this.webOkno.Size = new System.Drawing.Size(757, 521);
            this.webOkno.Source = new System.Uri("https://dungeon.wombat.app/dungeon", System.UriKind.Absolute);
            this.webOkno.TabIndex = 4;
            this.webOkno.ZoomFactor = 1D;
            // 
            // DobraForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 630);
            this.Controls.Add(this.btnClick);
            this.Controls.Add(this.webOkno);
            this.Name = "DobraForma";
            this.Text = "DobraForma";
            ((System.ComponentModel.ISupportInitialize)(this.webOkno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnClick;
        private Microsoft.Web.WebView2.WinForms.WebView2 webOkno;
    }
}