namespace eBarSystemsSolution
{
    partial class frmLogoutDialogBox
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
            this.btnLogoutYes = new System.Windows.Forms.Button();
            this.btnLogoutNo = new System.Windows.Forms.Button();
            this.lblLogout = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogoutYes
            // 
            this.btnLogoutYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogoutYes.Location = new System.Drawing.Point(99, 74);
            this.btnLogoutYes.Name = "btnLogoutYes";
            this.btnLogoutYes.Size = new System.Drawing.Size(119, 36);
            this.btnLogoutYes.TabIndex = 1;
            this.btnLogoutYes.Text = "Yes";
            this.btnLogoutYes.UseVisualStyleBackColor = true;
            // 
            // btnLogoutNo
            // 
            this.btnLogoutNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogoutNo.Location = new System.Drawing.Point(424, 74);
            this.btnLogoutNo.Name = "btnLogoutNo";
            this.btnLogoutNo.Size = new System.Drawing.Size(119, 36);
            this.btnLogoutNo.TabIndex = 2;
            this.btnLogoutNo.Text = "No";
            this.btnLogoutNo.UseVisualStyleBackColor = true;
            // 
            // lblLogout
            // 
            this.lblLogout.AutoSize = true;
            this.lblLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogout.Location = new System.Drawing.Point(13, 13);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(344, 25);
            this.lblLogout.TabIndex = 3;
            this.lblLogout.Text = "Are you sure you want to Log Out?";
            // 
            // frmLogoutDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 122);
            this.Controls.Add(this.lblLogout);
            this.Controls.Add(this.btnLogoutNo);
            this.Controls.Add(this.btnLogoutYes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmLogoutDialogBox";
            this.Text = "LogoutDialogBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogoutYes;
        private System.Windows.Forms.Button btnLogoutNo;
        private System.Windows.Forms.Label lblLogout;
    }
}