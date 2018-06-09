namespace ComputerGeometry
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PictureBoxShow = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxShow)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxShow
            // 
            this.PictureBoxShow.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PictureBoxShow.Location = new System.Drawing.Point(205, 34);
            this.PictureBoxShow.Name = "PictureBoxShow";
            this.PictureBoxShow.Size = new System.Drawing.Size(629, 471);
            this.PictureBoxShow.TabIndex = 0;
            this.PictureBoxShow.TabStop = false;
            this.PictureBoxShow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxShow_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 49);
            this.button1.TabIndex = 1;
            this.button1.Text = "导入测试点";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(33, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 56);
            this.button2.TabIndex = 2;
            this.button2.Text = "计算三角剖分";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(33, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 45);
            this.button3.TabIndex = 3;
            this.button3.Text = "对鼠标点击的点进行操作";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(33, 350);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 39);
            this.button4.TabIndex = 4;
            this.button4.Text = "清空";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 541);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PictureBoxShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxShow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

