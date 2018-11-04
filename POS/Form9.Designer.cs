namespace POS
{
    partial class Form9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form9));
            this.label1 = new System.Windows.Forms.Label();
            this.Updatebox = new System.Windows.Forms.TextBox();
            this.delbutton = new System.Windows.Forms.Button();
            this.currcatlabel = new System.Windows.Forms.Label();
            this.Currcats = new System.Windows.Forms.ListBox();
            this.cancel = new System.Windows.Forms.Button();
            this.addcat = new System.Windows.Forms.TextBox();
            this.Newcat = new System.Windows.Forms.Label();
            this.addcatbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 281);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Delete Category:";
            // 
            // Updatebox
            // 
            this.Updatebox.Location = new System.Drawing.Point(159, 278);
            this.Updatebox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Updatebox.Name = "Updatebox";
            this.Updatebox.Size = new System.Drawing.Size(265, 26);
            this.Updatebox.TabIndex = 20;
            // 
            // delbutton
            // 
            this.delbutton.Location = new System.Drawing.Point(432, 269);
            this.delbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.delbutton.Name = "delbutton";
            this.delbutton.Size = new System.Drawing.Size(94, 45);
            this.delbutton.TabIndex = 19;
            this.delbutton.Text = "Delete";
            this.delbutton.UseVisualStyleBackColor = true;
            this.delbutton.Click += new System.EventHandler(this.delbutton_Click);
            // 
            // currcatlabel
            // 
            this.currcatlabel.AutoSize = true;
            this.currcatlabel.Location = new System.Drawing.Point(25, 84);
            this.currcatlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currcatlabel.Name = "currcatlabel";
            this.currcatlabel.Size = new System.Drawing.Size(143, 20);
            this.currcatlabel.TabIndex = 18;
            this.currcatlabel.Text = "Current Categories";
            // 
            // Currcats
            // 
            this.Currcats.FormattingEnabled = true;
            this.Currcats.ItemHeight = 20;
            this.Currcats.Location = new System.Drawing.Point(29, 109);
            this.Currcats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Currcats.Name = "Currcats";
            this.Currcats.Size = new System.Drawing.Size(574, 144);
            this.Currcats.TabIndex = 17;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(534, 269);
            this.cancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(100, 45);
            this.cancel.TabIndex = 16;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // addcat
            // 
            this.addcat.Location = new System.Drawing.Point(159, 26);
            this.addcat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addcat.Name = "addcat";
            this.addcat.Size = new System.Drawing.Size(307, 26);
            this.addcat.TabIndex = 14;
            // 
            // Newcat
            // 
            this.Newcat.AutoSize = true;
            this.Newcat.Location = new System.Drawing.Point(25, 29);
            this.Newcat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Newcat.Name = "Newcat";
            this.Newcat.Size = new System.Drawing.Size(116, 20);
            this.Newcat.TabIndex = 13;
            this.Newcat.Text = "New Category: ";
            // 
            // addcatbutton
            // 
            this.addcatbutton.Location = new System.Drawing.Point(474, 17);
            this.addcatbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addcatbutton.Name = "addcatbutton";
            this.addcatbutton.Size = new System.Drawing.Size(160, 45);
            this.addcatbutton.TabIndex = 12;
            this.addcatbutton.Text = "Add";
            this.addcatbutton.UseVisualStyleBackColor = true;
            this.addcatbutton.Click += new System.EventHandler(this.addcatbutton_Click);
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 333);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Updatebox);
            this.Controls.Add(this.delbutton);
            this.Controls.Add(this.currcatlabel);
            this.Controls.Add(this.Currcats);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.addcat);
            this.Controls.Add(this.Newcat);
            this.Controls.Add(this.addcatbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form9";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HFC - Edit Category ";
            this.Load += new System.EventHandler(this.Form9_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Updatebox;
        private System.Windows.Forms.Button delbutton;
        private System.Windows.Forms.Label currcatlabel;
        private System.Windows.Forms.ListBox Currcats;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TextBox addcat;
        private System.Windows.Forms.Label Newcat;
        private System.Windows.Forms.Button addcatbutton;
    }
}