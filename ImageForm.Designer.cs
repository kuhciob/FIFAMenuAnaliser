namespace FIFAImageAnaliser
{
    partial class ImageForm
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
            this.ResultpictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ResultpictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ResultpictureBox
            // 
            this.ResultpictureBox.Location = new System.Drawing.Point(12, 12);
            this.ResultpictureBox.Name = "ResultpictureBox";
            this.ResultpictureBox.Size = new System.Drawing.Size(933, 521);
            this.ResultpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ResultpictureBox.TabIndex = 0;
            this.ResultpictureBox.TabStop = false;
            this.ResultpictureBox.Click += new System.EventHandler(this.ResultpictureBox_Click);
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 544);
            this.Controls.Add(this.ResultpictureBox);
            this.Name = "ImageForm";
            this.Text = "Image";
            this.Load += new System.EventHandler(this.ImageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResultpictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ResultpictureBox;
    }
}