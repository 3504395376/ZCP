using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;
namespace ZCP.cc
{
    public class CardObtain
    {
        /// <summary>
        /// 牌组区域识别
        /// </summary>
        /// <param name="src"></param>
        /// <param name="leftUpPoint"></param>
        /// <returns></returns>
        public static Mat GetRect(Mat src,out Point leftUpPoint)
        {
            Mat leftUp = new Mat(Config.GetLeftPath(), ImreadModes.Color);
            Mat rightUp = new Mat(Config.GetRightImgPath(), ImreadModes.Color);
            Mat down = new Mat(Config.GetDownImgPath(), ImreadModes.Color);

            Mat dst = new Mat();
            double minVal, maxVal;
            Point minPoint, maxPoint;
            Point P0, P1, P3;
            //比对
            Cv2.MatchTemplate(src, leftUp, dst, TemplateMatchModes.SqDiff);
            //查找最小点
            Cv2.MinMaxLoc(dst, out minVal, out maxVal, out minPoint, out maxPoint);
            P0 = minPoint;
            Cv2.MatchTemplate(src, rightUp, dst, TemplateMatchModes.SqDiff);
            Cv2.MinMaxLoc(dst, out minVal, out maxVal, out minPoint, out maxPoint);
            P1 = minPoint;
            Cv2.MatchTemplate(src, down, dst, TemplateMatchModes.SqDiff);
            Cv2.MinMaxLoc(dst, out minVal, out maxVal, out minPoint, out maxPoint);
            P3 = minPoint;

            leftUpPoint = P0;
            if (P0.X < P1.X && P3.Y > P1.Y)
            {
                // Cv2.Rectangle(showSrc, new Rect(P0.X, P0.Y, P1.X - P0.X, P3.Y - P0.Y), new Scalar(0, 0, 255));
                Mat rect = new Mat(src, new Rect(P0.X, P0.Y, P1.X - P0.X, P3.Y - P0.Y));
                if (rect.Cols > 500 && rect.Rows > 200)
                    return rect;
            }
            return null;
        }
        /// <summary>
        /// 分组区域识别 张昌蒲，自己
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Point[] GetGroupPoint(Mat src)
        {
            Point[] res = new Point[2];

            Mat zcp = new Mat(Config.GetZcpImgPath(), ImreadModes.Color);
            Mat zj = new Mat(Config.GetZjImgPath(), ImreadModes.Color);

            Mat dst = new Mat();
            double minVal, maxVal;
            Point minPoint, maxPoint;

            Cv2.MatchTemplate(src, zcp, dst, TemplateMatchModes.SqDiff);
            Cv2.MinMaxLoc(dst, out minVal, out maxVal, out minPoint, out maxPoint);
            res[0] = new Point(minPoint.X, minPoint.Y);
            Cv2.MatchTemplate(src, zj, dst, TemplateMatchModes.SqDiff);
            Cv2.MinMaxLoc(dst, out minVal, out maxVal, out minPoint, out maxPoint);
            res[1] = new Point(minPoint.X, minPoint.Y);

            return res;
        }
        /// <summary>
        /// 识别卡组区域的卡牌
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static List<CardInfo> GetCard(Mat src)
        {
            List<CardInfo> list = new List<CardInfo>();
            Mat dst = new Mat();
            double minVal, maxVal;
            Point minPoint, maxPoint;
            for (int i = 0; i < CardInfo.__CN.Count; i++)
            {
                for (int j = 0; j < CardInfo.__HS.Count; j++)
                {
                    Mat tpl = new Mat(CardInfo.GetCardPath(CardInfo.__HS[j] + CardInfo.__CN[i]), ImreadModes.Color);
                    if (tpl.Cols <= 0) continue;
                    while (true)
                    {
                        Cv2.MatchTemplate(src, tpl, dst, TemplateMatchModes.SqDiff);
                        //Cv2.ImShow("dst", dst);
                        //查找最小点
                        Cv2.MinMaxLoc(dst, out minVal, out maxVal, out minPoint, out maxPoint);
                        //设置阈值
                        if (minVal < 656178)
                        {
                            Cv2.Rectangle(src, new Rect(minPoint, tpl.Size()), new Scalar(255, 255, 255), -1);
                            list.Add(new CardInfo(minPoint, CardInfo.__HS[j], CardInfo.__CN[i],0));
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 刷新模板图片
        /// </summary>
        /// <param name="src"></param>
        /// <param name="cards"></param>
        /// <returns></returns>
        public static string errCor(Mat src, string cards)
        {
            string res = "";
            Mat dst = new Mat();
            double minVal, maxVal;
            Point minPoint, maxPoint;
            Mat tpl = new Mat(CardInfo.GetCardPath(cards), ImreadModes.Color);
            if (tpl.Cols <= 0)
            {
                res = "模板不存在";
            }
            else
            {
                Cv2.MatchTemplate(src, tpl, dst, TemplateMatchModes.SqDiff);
                //查找最小点
                Cv2.MinMaxLoc(dst, out minVal, out maxVal, out minPoint, out maxPoint);
                (new Mat(src, new Rect(minPoint, tpl.Size()))).SaveImage(CardInfo.GetCardPath(cards));

                res = minVal + ":" + minPoint.X + "," + minPoint.Y;
                tpl = new Mat(CardInfo.GetCardPath(cards), ImreadModes.Color);
                Cv2.MinMaxLoc(dst, out minVal, out maxVal, out minPoint, out maxPoint);
            }
            return res;
        }
    }
}
