namespace AuthorsApplication
{
    partial class AuthorsApp
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
            this.listAuthors = new System.Windows.Forms.ListBox();
            this.labelBooks = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelAddress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listAuthors
            // 
            this.listAuthors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listAuthors.FormattingEnabled = true;
            this.listAuthors.ItemHeight = 20;
            this.listAuthors.Location = new System.Drawing.Point(27, 12);
            this.listAuthors.Name = "listAuthors";
            this.listAuthors.Size = new System.Drawing.Size(292, 344);
            this.listAuthors.TabIndex = 0;
            this.listAuthors.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // labelBooks
            // 
            this.labelBooks.AutoSize = true;
            this.labelBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBooks.Location = new System.Drawing.Point(364, 12);
            this.labelBooks.Name = "labelBooks";
            this.labelBooks.Size = new System.Drawing.Size(41, 20);
            this.labelBooks.TabIndex = 1;
            this.labelBooks.Text = "Item";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.Location = new System.Drawing.Point(564, 52);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(172, 26);
            this.textBoxAddress.TabIndex = 2;
            this.textBoxAddress.TextChanged += new System.EventHandler(this.textBoxAddress_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(564, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Update Address";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddress.Location = new System.Drawing.Point(560, 12);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(107, 20);
            this.labelAddress.TabIndex = 4;
            this.labelAddress.Text = "LabelAddress";
            this.labelAddress.Click += new System.EventHandler(this.label2_Click);
            // 
            // AuthorsApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 394);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelBooks);
            this.Controls.Add(this.listAuthors);
            this.Name = "AuthorsApp";
            this.Text = "Authors App";
            this.Load += new System.EventHandler(this.AuthorsApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listAuthors;
        private System.Windows.Forms.Label labelBooks;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelAddress;
    }
}

