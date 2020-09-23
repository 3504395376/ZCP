using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCP.cc
{
    /// <summary>
    /// 卡牌分组计算
    /// </summary>
    public class GroupCards
    {
        public List<CardInfo> allCards;
        public List<List<CardInfo>> answer;
        private int bestAnswerIndex;
        private int[] sum = new int[] { 0, 0, 0 }; //每个group的 点数和
        private int[] lastIndex = new int[] { -1, -1, -1 };//每组最后元素所在位置
        private int halfSum;//最大分配和
        private int maxNum;//A组最多分配牌数
        public GroupCards(List<CardInfo> cards)
        {
            bestAnswerIndex = -1;
            answer = new List<List<CardInfo>>();
            allCards = cards; 
            for (int i = 0; i < allCards.Count; i++)
            {
                sum[allCards[i].group] += allCards[i].num;
                lastIndex[allCards[i].group] = i;
            }
            halfSum = (int)Math.Floor((double)sum[0] / 2);
            maxNum = (int)Math.Floor((double)allCards.Count / 2);
        }
        private void StartGrouping()
        {
            for (int len = 1; len <= maxNum; len++)
            {
                bool isGet = getNext(1, len, 0, false);
                if (isGet)
                {
                    do
                    {
                        //第一组点数合大于一半，无解
                        if (sum[1] > halfSum)
                        {
                            ResetGroup(1);
                            break;
                        }
                        for (int len2 = 1; len2 <= allCards.Count - len; len2++)
                        {
                            bool isGet2 = getNext( 2, len2, 0, false);
                            bool ck = false;
                            if (isGet2)
                            {
                                do
                                {
                                    //第二组点数合大于一半，无解
                                    //由于是升序 第二组点数合 大于第一组点数合 无解 
                                    if (sum[2] > halfSum || sum[2]>sum[1])
                                    {
                                        ResetGroup(2);
                                        ck = true;
                                        break ;
                                    }
                                    if (CheckAnswer())
                                    {
                                        //找到最优解 一组 点数 为总和一半
                                        return;
                                    }
                                    isGet2 = getNext( 2, len2, len2-1, true);
                                }
                                while (isGet2);
                            }
                            if (ck) break;
                        }
                        isGet = getNext( 1, len, len - 1, true);
                    } while (isGet);
                }
            }
        }
        /// <summary>
        /// 修改卡牌到指定分组
        /// </summary>
        /// <param name="i"></param>
        /// <param name="g"></param>
        private void ChangeGroup(int i,int g)
        {
            sum[allCards[i].group] -= allCards[i].num;
            if (lastIndex[allCards[i].group] <= i)
            {
                lastIndex[allCards[i].group] = -1;
                for (int j= i - 1; j >= 0; j--)
                {
                    if (allCards[j].group == allCards[i].group)
                    {
                        lastIndex[allCards[i].group] = j;
                        break;
                    }
                }
            }
            allCards[i].group = g;
            sum[allCards[i].group] += allCards[i].num;
            if (lastIndex[allCards[i].group] < i)
            {
                lastIndex[allCards[i].group] = i;
            }
        }
        private void ResetGroup(int g)
        {
            for (int i=0;i< allCards.Count;i++)
            {
                if (allCards[i].group == g) ChangeGroup(i,0);
            }
            lastIndex[g] = -1;
        }
        private bool getNext(int group,int len,int curLen,bool reGet)
        {
            bool isGet = false;
            int lastTemp = lastIndex[group];
            //如果重选
            if (reGet)
            {
                if (lastTemp >= 0)
                {
                    ChangeGroup(lastTemp, 0);
                }
                else
                {
                    return false;
                }
            }
            if (curLen < len)
            {
                //在最后一个已选元素 之后查找可用元素 并选择
                for (int i = lastTemp + 1; i < allCards.Count; i++)
                {
                    if (allCards[i].group != 0) continue;
                    ChangeGroup(i, group);
                    isGet = true;
                    break;
                }
                if (isGet)
                {
                    //找到可用
                    //检查是否已经 全部元素已经选择
                    //如果 不足，继续选择
                    //否则返回 选择完成
                    if (curLen < len-1)
                    {
                        return getNext(group, len, curLen + 1,false);
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    //没找到可用元素
                    //回退，上一元素重新选择
                    if (lastTemp >= 0 && curLen>=0)
                    {
                        return getNext(group, len, curLen -1,true);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return isGet;
        }
        /// <summary>
        /// 检查是否 答案，返回是否最佳(分组卡数最多)答案
        /// </summary>
        /// <returns></returns>
        private bool CheckAnswer()
        {;
            if (sum[1] - sum[2] == 0)
            {
                SaveAnswer();
                return sum[1] == halfSum;
            }
            return false;
        }
        /// <summary>
        /// 保存卡牌答案
        /// </summary>
        private void SaveAnswer()
        {
            //Console.Out.WriteLine("SaveAnswer:" + curCards[0].group + "," + curCards[1].group + "," + curCards[2].group + "," + curCards[3].group + "," + curCards[4].group + "," + curCards[5].group + "," + curCards[6].group + "," + curCards[7].group + "," + curCards[8].group);
            List<CardInfo> res = new List<CardInfo>();
            foreach(CardInfo card in allCards)
            {
                if(card.group>0) res.Add(card.Clone());
             }
            answer.Add(res);
            if (bestAnswerIndex < 0 || res.Count > answer[bestAnswerIndex].Count)
            {
                bestAnswerIndex = answer.Count - 1;
            }
        }
        /// <summary>
        /// 最佳(卡数)答案
        /// </summary>
        /// <returns></returns>
        public List<CardInfo> BestAnswer()
        {
            if (bestAnswerIndex >= 0)
                return answer[bestAnswerIndex];
            return new List<CardInfo>();
        }
        public static GroupCards Grouping(List<CardInfo> cards)
        {
            GroupCards groupCards = new GroupCards(cards);
            groupCards.StartGrouping();
            return groupCards;
        }
    }
}
