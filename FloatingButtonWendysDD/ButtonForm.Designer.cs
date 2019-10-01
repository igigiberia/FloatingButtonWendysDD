namespace FloatingButtonWendysDD
{
    partial class ButtonForm
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
            this.ReloadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReloadButton
            // 
            this.ReloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReloadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReloadButton.Location = new System.Drawing.Point(2, 2);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(322, 56);
            this.ReloadButton.TabIndex = 0;
            this.ReloadButton.Text = "სერვისის გადატვირთვა";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // ButtonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(326, 60);
            this.Controls.Add(this.ReloadButton);
            this.Name = "ButtonForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReloadButton;
    }
}

