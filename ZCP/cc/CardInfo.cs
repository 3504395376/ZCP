using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;
namespace ZCP.cc
{
    public class CardInfo
    {
        public static List<String> __HS = new List<String> { "A","B" };//黑红
        public static List<String> __CN = new List<String> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public static string GetCardPath(string card)
        {
            return Config.GetCardPath() + card + ".bmp";
        }
        public Point point;//卡牌坐标
        public string hs;//黑红
        public string cn;//卡牌点数
        public int num;//计算点数
        public int group;//分组
        public CardInfo(Point p, string h, string c,int g)
        {
            point = p;
            hs = h;
            cn = c;
            num = __CN.IndexOf(c)+1;
            group = g;
        }
        public CardInfo Clone()
        {
            return new CardInfo(this.point,this.hs,this.cn,this.group);
        }
    };
}
