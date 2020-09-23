namespace ZCP
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_ob = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_prtsrc = new System.Windows.Forms.Button();
            this.btn_auto = new System.Windows.Forms.Button();
            this.btn_errcor = new System.Windows.Forms.Button();
            this.btn_tmpimg = new System.Windows.Forms.Button();
            this.group_0 = new System.Windows.Forms.GroupBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.group_1 = new System.Windows.Forms.GroupBox();
            this.group_2 = new System.Windows.Forms.GroupBox();
            this.chb_auto = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_ob
            // 
            this.btn_ob.Location = new System.Drawing.Point(299, 12);
            this.btn_ob.Name = "btn_ob";
            this.btn_ob.Size = new System.Drawing.Size(53, 30);
            this.btn_ob.TabIndex = 2;
            this.btn_ob.Text = "计算";
            this.btn_ob.UseVisualStyleBackColor = true;
            this.btn_ob.Click += new System.EventHandler(this.btn_ob_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 48);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(245, 168);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "软件可以最小化,分牌时,按F3呼出，自动截屏计算.\n截图:截取当前屏幕存入缓存\n计算:根据缓存图片，识别卡牌，进行计算\n缓存图片:显示缓存图片\n纠错:如果有图片没" +
    "有识别出，根据缓存图片，选择未识别的卡牌，进行纠错更新卡牌模板\n注:卡牌模板存放于软件目录/IMG/car 也可自己截屏加工图片替换模板";
            // 
            // btn_prtsrc
            // 
            this.btn_prtsrc.Location = new System.Drawing.Point(240, 12);
            this.btn_prtsrc.Name = "btn_prtsrc";
            this.btn_prtsrc.Size = new System.Drawing.Size(53, 30);
            this.btn_prtsrc.TabIndex = 4;
            this.btn_prtsrc.Text = "截图";
            this.btn_prtsrc.UseVisualStyleBackColor = true;
            this.btn_prtsrc.Click += new System.EventHandler(this.btn_prtsrc_Click);
            // 
            // btn_auto
            // 
            this.btn_auto.Location = new System.Drawing.Point(12, 12);
            this.btn_auto.Name = "btn_auto";
            this.btn_auto.Size = new System.Drawing.Size(127, 28);
            this.btn_auto.TabIndex = 5;
            this.btn_auto.Text = "让我试试&(F3)";
            this.btn_auto.UseVisualStyleBackColor = true;
            this.btn_auto.Click += new System.EventHandler(this.btn_auto_Click);
            // 
            // btn_errcor
            // 
            this.btn_errcor.Location = new System.Drawing.Point(517, 13);
            this.btn_errcor.Name = "btn_errcor";
            this.btn_errcor.Size = new System.Drawing.Size(53, 30);
            this.btn_errcor.TabIndex = 8;
            this.btn_errcor.Text = "纠错";
            this.btn_errcor.UseVisualStyleBackColor = true;
            this.btn_errcor.Click += new System.EventHandler(this.btn_errcor_Click);
            // 
            // btn_tmpimg
            // 
            this.btn_tmpimg.Location = new System.Drawing.Point(358, 12);
            this.btn_tmpimg.Name = "btn_tmpimg";
            this.btn_tmpimg.Size = new System.Drawing.Size(91, 30);
            this.btn_tmpimg.TabIndex = 9;
            this.btn_tmpimg.Text = "缓存图片";
            this.btn_tmpimg.UseVisualStyleBackColor = true;
            this.btn_tmpimg.Click += new System.EventHandler(this.btn_tmpimg_Click);
            // 
            // group_0
            // 
            this.group_0.Location = new System.Drawing.Point(263, 48);
            this.group_0.Name = "group_0";
            this.group_0.Size = new System.Drawing.Size(307, 52);
            this.group_0.TabIndex = 12;
            this.group_0.TabStop = false;
            this.group_0.Text = "识别卡牌";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "AA.bmp");
            this.imageList1.Images.SetKeyName(1, "A2.bmp");
            this.imageList1.Images.SetKeyName(2, "A3.bmp");
            this.imageList1.Images.SetKeyName(3, "A4.bmp");
            this.imageList1.Images.SetKeyName(4, "A5.bmp");
            this.imageList1.Images.SetKeyName(5, "A6.bmp");
            this.imageList1.Images.SetKeyName(6, "A7.bmp");
            this.imageList1.Images.SetKeyName(7, "A8.bmp");
            this.imageList1.Images.SetKeyName(8, "A9.bmp");
            this.imageList1.Images.SetKeyName(9, "A10.bmp");
            this.imageList1.Images.SetKeyName(10, "AJ.bmp");
            this.imageList1.Images.SetKeyName(11, "AQ.bmp");
            this.imageList1.Images.SetKeyName(12, "AK.bmp");
            this.imageList1.Images.SetKeyName(13, "BA.bmp");
            this.imageList1.Images.SetKeyName(14, "B2.bmp");
            this.imageList1.Images.SetKeyName(15, "B3.bmp");
            this.imageList1.Images.SetKeyName(16, "B4.bmp");
            this.imageList1.Images.SetKeyName(17, "B5.bmp");
            this.imageList1.Images.SetKeyName(18, "B6.bmp");
            this.imageList1.Images.SetKeyName(19, "B7.bmp");
            this.imageList1.Images.SetKeyName(20, "B8.bmp");
            this.imageList1.Images.SetKeyName(21, "B9.bmp");
            this.imageList1.Images.SetKeyName(22, "B10.bmp");
            this.imageList1.Images.SetKeyName(23, "BJ.bmp");
            this.imageList1.Images.SetKeyName(24, "BQ.bmp");
            this.imageList1.Images.SetKeyName(25, "BK.bmp");
            // 
            // comboBox1
            // 
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "AA",
            "A2",
            "A3",
            "A4",
            "A5",
            "A6",
            "A7",
            "A8",
            "A9",
            "A10",
            "AJ",
            "AQ",
            "AK",
            "BA",
            "B2",
            "B3",
            "B4",
            "B5",
            "B6",
            "B7",
            "B8",
            "B9",
            "B10",
            "BJ",
            "BQ",
            "BK"});
            this.comboBox1.Location = new System.Drawing.Point(455, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(56, 26);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
            // 
            // group_1
            // 
            this.group_1.Location = new System.Drawing.Point(263, 106);
            this.group_1.Name = "group_1";
            this.group_1.Size = new System.Drawing.Size(307, 52);
            this.group_1.TabIndex = 14;
            this.group_1.TabStop = false;
            this.group_1.Text = "分组A";
            // 
            // group_2
            // 
            this.group_2.Location = new System.Drawing.Point(263, 164);
            this.group_2.Name = "group_2";
            this.group_2.Size = new System.Drawing.Size(307, 52);
            this.group_2.TabIndex = 15;
            this.group_2.TabStop = false;
            this.group_2.Text = "分组B";
            // 
            // chb_auto
            // 
            this.chb_auto.AutoSize = true;
            this.chb_auto.Location = new System.Drawing.Point(145, 18);
            this.chb_auto.Name = "chb_auto";
            this.chb_auto.Size = new System.Drawing.Size(89, 19);
            this.chb_auto.TabIndex = 11;
            this.chb_auto.Text = "自动拖牌";
            this.chb_auto.UseVisualStyleBackColor = true;
            this.chb_auto.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 226);
            this.Controls.Add(this.group_2);
            this.Controls.Add(this.group_1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.group_0);
            this.Controls.Add(this.chb_auto);
            this.Controls.Add(this.btn_tmpimg);
            this.Controls.Add(this.btn_errcor);
            this.Controls.Add(this.btn_auto);
            this.Controls.Add(this.btn_prtsrc);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_ob);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "张昌蒲计算器1.0";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion 
        private System.Windows.Forms.Button btn_ob;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_prtsrc;
        private System.Windows.Forms.Button btn_auto;
        private System.Windows.Forms.Button btn_errcor;
        private System.Windows.Forms.Button btn_tmpimg;
        private System.Windows.Forms.GroupBox group_0;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox group_1;
        private System.Windows.Forms.GroupBox group_2;
        private System.Windows.Forms.CheckBox chb_auto;
    }
}

