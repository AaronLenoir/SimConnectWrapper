namespace SimConnectWrapper.Forms.Test
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
            this.simConnectWrapper = new SimConnectWrapper();
            this.SuspendLayout();
            // 
            // simConnectWrapper
            // 
            this.simConnectWrapper.Location = new System.Drawing.Point(12, 151);
            this.simConnectWrapper.Name = "simConnectWrapper";
            this.simConnectWrapper.Size = new System.Drawing.Size(242, 33);
            this.simConnectWrapper.TabIndex = 0;
            this.simConnectWrapper.Text = "simConnectWrapper1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 196);
            this.Controls.Add(this.simConnectWrapper);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SimConnectWrapper simConnectWrapper;
    }
}

