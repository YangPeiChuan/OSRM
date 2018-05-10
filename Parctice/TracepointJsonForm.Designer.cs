namespace Parctice
{
    partial class TracepointJsonForm
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
            this.tbJson = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbJson
            // 
            this.tbJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbJson.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbJson.Location = new System.Drawing.Point(0, 0);
            this.tbJson.Multiline = true;
            this.tbJson.Name = "tbJson";
            this.tbJson.ReadOnly = true;
            this.tbJson.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbJson.Size = new System.Drawing.Size(722, 246);
            this.tbJson.TabIndex = 0;
            this.tbJson.WordWrap = false;
            // 
            // TracepointJsonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 246);
            this.Controls.Add(this.tbJson);
            this.Name = "TracepointJsonForm";
            this.Text = "TracepointJsonForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TracepointJsonForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbJson;
    }
}