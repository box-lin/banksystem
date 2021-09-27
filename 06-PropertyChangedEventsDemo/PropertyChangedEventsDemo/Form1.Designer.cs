
namespace PropertyChangedEventsDemo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFirstName2 = new System.Windows.Forms.Button();
            this.btnFirstName1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLastName2 = new System.Windows.Forms.Button();
            this.btnLastName1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFirstName2);
            this.groupBox1.Controls.Add(this.btnFirstName1);
            this.groupBox1.Location = new System.Drawing.Point(115, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "First Name";
            // 
            // btnFirstName2
            // 
            this.btnFirstName2.Location = new System.Drawing.Point(32, 89);
            this.btnFirstName2.Name = "btnFirstName2";
            this.btnFirstName2.Size = new System.Drawing.Size(369, 30);
            this.btnFirstName2.TabIndex = 1;
            this.btnFirstName2.Tag = "Bob";
            this.btnFirstName2.UseVisualStyleBackColor = true;
            this.btnFirstName2.Click += new System.EventHandler(this.btnFirstName_Click);
            // 
            // btnFirstName1
            // 
            this.btnFirstName1.Location = new System.Drawing.Point(32, 40);
            this.btnFirstName1.Name = "btnFirstName1";
            this.btnFirstName1.Size = new System.Drawing.Size(369, 30);
            this.btnFirstName1.TabIndex = 0;
            this.btnFirstName1.Tag = "Joe";
            this.btnFirstName1.UseVisualStyleBackColor = true;
            this.btnFirstName1.Click += new System.EventHandler(this.btnFirstName_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLastName2);
            this.groupBox2.Controls.Add(this.btnLastName1);
            this.groupBox2.Location = new System.Drawing.Point(115, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 146);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Last Name";
            // 
            // btnLastName2
            // 
            this.btnLastName2.Location = new System.Drawing.Point(32, 86);
            this.btnLastName2.Name = "btnLastName2";
            this.btnLastName2.Size = new System.Drawing.Size(369, 30);
            this.btnLastName2.TabIndex = 2;
            this.btnLastName2.Tag = "Johnson";
            this.btnLastName2.UseVisualStyleBackColor = true;
            this.btnLastName2.Click += new System.EventHandler(this.btnLastName_Click);
            // 
            // btnLastName1
            // 
            this.btnLastName1.Location = new System.Drawing.Point(32, 31);
            this.btnLastName1.Name = "btnLastName1";
            this.btnLastName1.Size = new System.Drawing.Size(369, 30);
            this.btnLastName1.TabIndex = 1;
            this.btnLastName1.Tag = "Smith";
            this.btnLastName1.UseVisualStyleBackColor = true;
            this.btnLastName1.Click += new System.EventHandler(this.btnLastName_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFirstName2;
        private System.Windows.Forms.Button btnFirstName1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLastName2;
        private System.Windows.Forms.Button btnLastName1;
    }
}

