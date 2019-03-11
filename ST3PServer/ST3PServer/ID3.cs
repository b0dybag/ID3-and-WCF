using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ST3PServer
{
    public class ID3
    {
       public List<List<string>> Poddzewo(List<List<string>> body, string key)
        {
            List<List<string>> poddzewo = new List<List<string>>() { };
            foreach (var item in body)
            {
                if (item.Contains(key)) poddzewo.Add(item);
            }
            return poddzewo;
        }

       public double TreeInfo(List<List<string>> body, List<string> keys, int head)
        {
            double[] localInfo = new double[keys.Count];
            double totalCount = 0.0;
            double[] localCount = new double[keys.Count];
            double totalInfo = 0.0;
            for (int i = 0; i < keys.Count; i++)
            {
                List<List<string>> Tmp = Poddzewo(body, keys[i]);
                localInfo[i] = Info(Tmp, Heads(Tmp, head), head);
                localCount[i] = Tmp.Count;
                totalCount += localCount[i];
            }
            for (int i = 0; i < localInfo.Length; i++)
            {
                totalInfo += (localCount[i] / totalCount) * localInfo[i];
            }
            return totalInfo;
        }

       public List<string> Heads(List<List<string>> body, int head)
        {
            List<string> actions = new List<string>();
            foreach (var row in body)
            {
                if (!actions.Contains(row[head]))
                {
                    actions.Add(row[head]);
                }
            }
            return actions;
        }

       public double Info(List<List<string>> body, List<string> heads, int head)
        {
            int[] count = new int[heads.Count];   // DANGEROUS SHIT!!!! its will be zero ?? i hope so :) 
            foreach (var row in body)
            {
                for (int i = 0; i < heads.Count; i++)
                {
                    if (heads[i] == row[head]) count[i]++;
                }
            }
            int totalCount = body.Count;
            double info = 0;
            foreach (var number in count)
            {
                double num = Convert.ToDouble(number) / Convert.ToDouble(totalCount);
                info -= num * Math.Log(num, 2.0);
            }
            return info;
        }

       public List<List<string>> TreeMap(List<List<string>> body, List<string> head, int decisionPosition, int iter)
        {
            int info = mainCalc(body, decisionPosition);
            List<string> tmp = Heads(body, info);
            List<string> record = new List<string>();
            for (int i = 0; i < iter; i++)
            {
                record.Add("    ");
            }
            record.Add("(@)" + head[info]);
            List<List<string>> decision = new List<List<string>>();
            decision.Add(record);
            for (int i = 0; i < tmp.Count; i++)
            {
                List<List<string>> subTree = Poddzewo(body, tmp[i]);

                List<string> record2 = new List<string>();
                for (int j = 0; j < iter; j++)
                {
                    record2.Add("    ");
                }
                record2.Add("-" + tmp[i]);

                string isEoT = isEndOfTree(subTree, decisionPosition);
                if (isEoT != "false")
                {
                    record2.Add("->");
                    record2.Add(isEoT);
                    decision.Add(record2);
                }
                else
                {
                    decision.Add(record2);
                    decision.AddRange(TreeMap(subTree, head, 4, iter + 1));
                }
            }
            return decision;
        }

       public string isEndOfTree(List<List<string>> subtree, int head)
        {
            List<string> heads = Heads(subtree, head);
            if (heads.Count == 1)
            {
                return heads[0] + "(" + subtree.Count.ToString() + ")";
            }
            return "false";
        }

       public int mainCalc(List<List<string>> body, int head)
        {
            List<string> heads = Heads(body, head);
            double mainInfo = Info(body, heads, head);
            int columnsCount = body[0].Count;
            double[] localInfo = new double[columnsCount];
            double max = 0.0;
            int betterTreeIndex = 0;
            for (int i = 0; i < columnsCount; i++)
            {
                if (i == head) continue;
                List<string> keys = Heads(body, i);
                localInfo[i] = TreeInfo(body, keys, head);
                double tmp = mainInfo - localInfo[i];
                if (tmp > max)
                {
                    max = tmp;
                    betterTreeIndex = i;
                }
            }
            return betterTreeIndex;
        }
    }
}