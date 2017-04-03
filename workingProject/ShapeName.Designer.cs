namespace WindowsFormsApplication1
{
    partial class ShapeName
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
            this.label1 = new System.Windows.Forms.Label();
            this.ShapeNameTextBOx = new System.Windows.Forms.RichTextBox();
            this.BtnRename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shape Name";
            // 
            // ShapeNameTextBOx
            // 
            this.ShapeNameTextBOx.Location = new System.Drawing.Point(147, 17);
            this.ShapeNameTextBOx.Name = "ShapeNameTextBOx";
            this.ShapeNameTextBOx.Size = new System.Drawing.Size(143, 25);
            this.ShapeNameTextBOx.TabIndex = 1;
            this.ShapeNameTextBOx.Text = "";
            // 
            // BtnRename
            // 
            this.BtnRename.Location = new System.Drawing.Point(299, 17);
            this.BtnRename.Name = "BtnRename";
            this.BtnRename.Size = new System.Drawing.Size(75, 23);
            this.BtnRename.TabIndex = 2;
            this.BtnRename.Text = "Rename";
            this.BtnRename.UseVisualStyleBackColor = true;
            this.BtnRename.Click += new System.EventHandler(this.BtnRename_Click);
            // 
            // ShapeName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 61);
            this.Controls.Add(this.BtnRename);
            this.Controls.Add(this.ShapeNameTextBOx);
            this.Controls.Add(this.label1);
            this.Name = "ShapeName";
            this.Text = "ShapeName";
            this.Load += new System.EventHandler(this.ShapeName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox ShapeNameTextBOx;
        private System.Windows.Forms.Button BtnRename;
    }
}