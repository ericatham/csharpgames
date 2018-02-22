namespace GameOfSquare
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
            this.tblong = new System.Windows.Forms.TextBox();
            this.tbhigh = new System.Windows.Forms.TextBox();
            this.btngener = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnload = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tblong
            // 
            this.tblong.Location = new System.Drawing.Point(86, 46);
            this.tblong.Name = "tblong";
            this.tblong.Size = new System.Drawing.Size(100, 20);
            this.tblong.TabIndex = 0;
            // 
            // tbhigh
            // 
            this.tbhigh.Location = new System.Drawing.Point(348, 46);
            this.tbhigh.Name = "tbhigh";
            this.tbhigh.Size = new System.Drawing.Size(100, 20);
            this.tbhigh.TabIndex = 1;
            // 
            // btngener
            // 
            this.btngener.Location = new System.Drawing.Point(480, 42);
            this.btngener.Name = "btngener";
            this.btngener.Size = new System.Drawing.Size(75, 23);
            this.btngener.TabIndex = 2;
            this.btngener.Text = "Generate";
            this.btngener.UseVisualStyleBackColor = true;
            this.btngener.Click += new System.EventHandler(this.btngener_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of Squares Long";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of Squares High";
            // 
            // btnload
            // 
            this.btnload.Location = new System.Drawing.Point(591, 30);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(75, 23);
            this.btnload.TabIndex = 5;
            this.btnload.Text = "Load";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(591, 59);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 6;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 453);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btnload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btngener);
            this.Controls.Add(this.tbhigh);
            this.Controls.Add(this.tblong);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tblong;
        private System.Windows.Forms.TextBox tbhigh;
        private System.Windows.Forms.Button btngener;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.Button btnsave;
    }
}

