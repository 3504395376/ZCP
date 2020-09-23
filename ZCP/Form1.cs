using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using OpenCvSharp;
using ZCP.cc;
namespace ZCP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_tmpimg_Click(object sender, EventArgs e)
        {
            Mat src = new Mat(Config.GetCacheImgPath(), ImreadModes.Color);
            Cv2.ImShow("缓存图片:根据计算结果，选择纠错未识别卡牌", src);
        }
        private void btn_errcor_Click(object sender, EventArgs e)
        {
            if(this.comboBox1.Text == "")
            {
                MessageBox.Show("清选择纠错卡牌");
            }
            else
            {
                richTextBox1.Clear();
                Mat src = new Mat(Config.GetCacheImgPath(), ImreadModes.Color);
                richTextBox1.AppendText(CardObtain.errCor(src, this.comboBox1.Text));
            }
        }
        private void btn_ob_Click(object sender, EventArgs e)
        {
            checkRes(new Mat(Config.GetCacheImgPath(), ImreadModes.Color), true);
        }
        private void btn_auto_Click(object sender, EventArgs e)
        {
            checkRes(ScreenCut.PrtSrc(), this.chb_auto.Checked);
        }

        private void btn_prtsrc_Click(object sender, EventArgs e)
        {
            Mat mat = ScreenCut.PrtSrc();
            Cv2.ImShow("ss", mat);
        }
        private void checkRes(Mat src,bool auto)
        {
            richTextBox1.Clear();
            OpenCvSharp.Point leftUp;
            Mat rect = CardObtain.GetRect(src,out leftUp);
            if (rect == null)
            {
                richTextBox1.AppendText("未识别\r\n");
                return;
            }

            List<CardInfo> cards = CardObtain.GetCard(rect);
            GroupCards groupCards = GroupCards.Grouping(cards);

            

            richTextBox1.AppendText("识别卡牌:");
            this.group_0.Controls.Clear();
            foreach (CardInfo card in groupCards.allCards)
            {
                richTextBox1.AppendText(card.cn);
                AddImgToGroup(this.group_0, card.hs + card.cn);
            }
            richTextBox1.AppendText("\r\n");

            List<CardInfo> bestAnswer = groupCards.BestAnswer();
            richTextBox1.AppendText("分组A:");
            this.group_1.Controls.Clear();
            foreach (CardInfo card in bestAnswer)
            {
                if (card.group == 1)
                {
                    richTextBox1.AppendText(card.cn);
                    AddImgToGroup(this.group_1, card.hs + card.cn);
                }
            }
            richTextBox1.AppendText(";分组B:");
            this.group_2.Controls.Clear();
            foreach (CardInfo card in bestAnswer)
            {
                if (card.group == 2)
                {
                    richTextBox1.AppendText(card.cn);
                    AddImgToGroup(this.group_2, card.hs + card.cn);
                }
            }
            if (bestAnswer.Count > 0 && auto)
            {
                OpenCvSharp.Point[] points = CardObtain.GetGroupPoint(src);
                if (Math.Abs(points[0].X - points[1].X) < 10 && Math.Abs(points[0].Y - points[1].Y) > 150)
                {
                    foreach (CardInfo card in bestAnswer)
                    {
                        if (card.group > 0)
                        {
                            hotkey.DropObj(300, leftUp.X+ card.point.X+5, leftUp.Y + card.point.Y + 5, leftUp.X + card.point.X + 5, leftUp.Y + points[card.group-1].Y);
                        }
                    }
                }
            }
        }
        private void AddImgToGroup(GroupBox g,string card)
        {
            PictureBox p = new PictureBox();
            p.Image = Image.FromFile(CardInfo.GetCardPath(card));
            p.SizeMode = PictureBoxSizeMode.AutoSize;
            p.Dock = DockStyle.Left;
            g.Controls.Add(p);
            Console.Out.WriteLine(g.Controls.Count);
        }
        private HotKey hotkey;
        private int hotKey_Ctrl_F2;
        private void OnHotkey(int HotkeyID)
        {
            if (HotkeyID == hotKey_Ctrl_F2)
            {
                this.WindowState = FormWindowState.Normal;
                this.Focus();
                checkRes(ScreenCut.PrtSrc(),this.chb_auto.Checked);
            }
        }
        /// <summary>
        /// 加载注册热键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //最前
            HotKey.SetWindowPos(this.Handle, -1, 0, 0, 0, 0, 1 | 2);
            hotkey = new HotKey(this.Handle);
            //定义热键(F3)
            hotKey_Ctrl_F2 = hotkey.RegisterHotkey(Keys.F3, HotKey.KeyFlags.MOD_NULL);
            hotkey.OnHotkey += new HotKey.HotkeyEventHandler(OnHotkey);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            hotkey.UnregisterHotkeys();
        }
        /// <summary>
        /// 下拉框显示图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            System.Drawing.Size imageSize = imageList1.ImageSize;
            Font fn = null;
            if (e.Index >= 0)
            {
                fn = new Font("宋体", 10, FontStyle.Bold);//创建字体对象
                string s = (string)comboBox1.Items[e.Index];
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect))
                {
                    //画条目背景
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), r);
                    //绘制图像
                    imageList1.Draw(e.Graphics, r.Left, r.Top, e.Index);
                    //显示字符串
                    e.Graphics.DrawString(s, fn, new SolidBrush(Color.Black), r.Left + imageSize.Width, r.Top);
                    //显示取得焦点时的虚线框
                    e.DrawFocusRectangle();
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), r);
                    imageList1.Draw(e.Graphics, r.Left, r.Top, e.Index);
                    e.Graphics.DrawString(s, fn, new SolidBrush(Color.Black), r.Left + imageSize.Width, r.Top);
                    e.DrawFocusRectangle();
                }
            }
        }
    }
}
