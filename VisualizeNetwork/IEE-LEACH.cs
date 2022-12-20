using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace VisualizeNetwork
{
    enum Mode
    {
        IEE_LEACH,
        IEE_LEACH_A,
        IEE_LEACH_B
    }

    internal class IEE_LEACH : LEACH
    {
        private Mode mode;
        private List<int> lastCHRound = new List<int>();


        public IEE_LEACH(Mode mode)
        {
            this.mode = mode;
            if (mode == Mode.IEE_LEACH) AlgoName = "IEE-LEACH";
            else if (mode == Mode.IEE_LEACH_A) AlgoName = "IEE-LEACH-A";
            else if (mode == Mode.IEE_LEACH_B) AlgoName = "IEE-LEACH-B";
            for (int i = 0; i < N; i++)
            {
                lastCHRound.Add(-1000);
            }
        }

        protected override double getP_i(List<Node> nodes, int i)
        {
            if (mode == Mode.IEE_LEACH_B) return base.getP_i();

            // ラウンド数に応じたCH選出確立を計算
            double E_t = CalcTotalEnergy(nodes);
            double E_a = E_t / N;
            //double E_a = (E_t * (1 - (double)Round/R))/CH_candidate;
            double P_i = P * (nodes[i].E_r / E_a);
            //double P_i = P * CH_candidate * node.E_r * Sim.E_init / (E_t * E_a);
            //P_i = Math.Min(1, P_i);
            return P_i;
        }

        protected override void CHElection(List<Node> nodes)
        {
            CHIDs.Clear();
            CHNum = 0;
            if (mode == Mode.IEE_LEACH_B) ResetUnqualifiedRound(nodes);
            CHElectionHelper(nodes);
            //double T;
            //for (int i = 0; i < nodes.Count; i++)
            //{
            //    Node node = nodes[i];
            //    if (!node.IsAlive) continue;// ノードが死んでたら次

            //    // ラウンド数に応じたCH選出確立を計算
            //    double P_i = getP_i(nodes, i);
            //    T = P_i / (1 - P_i * ((Round - 1) % (1 / P_i)));
            //    node.Pi = P_i;

            //    if (node.UnqualifiedRound == 0 && T > rand.NextDouble())//CH
            //    {
            //        node.T = T;
            //        node.MemberNum = 1;
            //        node.UnqualifiedRound = (int)Math.Round(1 / P_i);
            //        CHIDs.Add(i);
            //        CHNum++;
            //        node.IsCH = true;
            //        node.HasCHCnt++;
            //        nodes[i] = node;
            //        continue;
            //    }

            //    //非CH
            //    if (node.UnqualifiedRound > 0)
            //    {
            //        node.UnqualifiedRound--;
            //    }
            //    nodes[i] = node;
            //}
        }

        //public override void CHElection(List<Node> nodes)
        //{
        //    CHIDs.Clear();
        //    CHNumList.Add(0);
        //    if (Round % (1 / P) == 0)   // 1/Pラウンドごとに、
        //    {
        //        for (int i = 0; i < N; i++)
        //            hasBeenCH[i] = 0;   // CHになる確立を等しくする
        //    }

        //    for (int i = 0; i < nodes.Count; i++)
        //    {
        //        Node node = nodes[i];
        //        if (!node.IsAlive) continue;// ノードが死んでたら次

        //        // ラウンド数に応じたCH選出確立を計算
        //        double E_t = CalcTotalEnergy(nodes);
        //        double E_a = E_t/N;
        //        //double E_a = (E_t * (1 - (double)Round/R))/CH_candidate;
        //        double T;
        //        double P_i;
        //        if (mode == 0 || mode == 1)
        //        {
        //            P_i = P * (node.E_r / E_a);
        //            //double P_i = P * CH_candidate * node.E_r * Sim.E_init / (E_t * E_a);
        //            P_i = Math.Min(1, P_i);
        //        }
        //        else
        //        {
        //            //T = P / (1 - P * (Round % (1 / P)));
        //            P_i = P;
        //        }
        //        T = P_i / (1 - P_i * (Round % (int)Math.Round(1 / P_i)));

        //        node.MemberNum = 0;
        //        node.CHID = -1;
        //        node.IsCH = false;
        //        if (P_i > rand.NextDouble())//CH
        //        //if (hasBeenCH[i] == 0 && T > rand.NextDouble())//CH
        //            {
        //            node.MemberNum = 1;
        //            hasBeenCH[i] = (int)Math.Floor(1 / P_i);
        //            CHIDs.Add(i);
        //            hasBeenCHCnt[i]++;
        //            CHNumList[CHNumList.Count - 1]++;
        //            node.IsCH = true;
        //            nodes[i] = node;
        //            continue;
        //        }

        //        //非CH
        //        if (hasBeenCH[i] > 0) hasBeenCH[i] -= 1;
        //        nodes[i] = node;
        //    }
        //}

        protected override void ClusterFormation(List<Node> nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (!nodes[i].IsAlive) continue;
                Node node = nodes[i];
                Node head = node;
                double distMin = double.MaxValue;
                foreach (int headID in CHIDs)
                {
                    Node tmp = nodes[headID];
                    double dist = Dist2(tmp, node);
                    if (dist < distMin)
                    {
                        head = tmp;
                        distMin = dist;
                    }
                }
                //if (dist2(BS, node) < distMin || Math.Sqrt(dist2(BS, node)) < Sim.d_0)
                if (Dist2(BS, node) < distMin && mode != Mode.IEE_LEACH_A)
                {
                    node.CHID = -1;
                    nodes[i] = node;
                    return;
                }
                node.CHID = head.ID;
                nodes[i] = node;
                head.MemberNum += 1;
                nodes[node.CHID] = head;
            }
        }

        //public override void SteadyState(List<Node> nodes)
        //{
        //    for (int i = 0; i < nodes.Count; i++)
        //    {
        //        if (!nodes[i].IsAlive) continue;
        //        double assignedTime, sendMessageBit, dist, energyTX;
        //        Node node = nodes[i];

        //        if (node.IsCH)  //CH→BS
        //        {
        //            //assignedTime = (double)Sim.INTERVAL / node.MemberNum;
        //            //sendMessageBit = Sim.bandwidth * assignedTime;

        //            sendMessageBit = Sim.packetSize;
        //            dist = Math.Sqrt(Sim.Dist2(BS, node));
        //            energyTX = Sim.E_TX(sendMessageBit, dist)+Sim.E_DA* sendMessageBit *node.MemberNum;
        //        }
        //        else if (node.CHID == -1)//member→BS
        //        {
        //            sendMessageBit = Sim.packetSize;
        //            dist = Math.Sqrt(Sim.Dist2(BS, node));
        //            energyTX = Sim.E_TX(sendMessageBit, dist);
        //        }
        //        else//member→CH
        //        {
        //            Node head = nodes[node.CHID];
        //            //assignedTime = (double)Sim.INTERVAL / head.MemberNum;
        //            //sendMessageBit = Sim.bandwidth * assignedTime;

        //            sendMessageBit = Sim.packetSize;
        //            dist = Math.Sqrt(Sim.Dist2(head, node));
        //            energyTX = Sim.E_TX(sendMessageBit, dist);
        //            //head.E_r -= Sim.E_RX(sendMessageBit);
        //            ConsumeEnergy(Sim.E_RX(sendMessageBit), ref head);
        //            //head.ConsumeEnergy(Sim.E_RX(sendMessageBit), this);
        //            nodes[node.CHID] = head;
        //        }
        //        //node.E_r -= energyTX;
        //        ConsumeEnergy(energyTX, ref node);
        //        //node.ConsumeEnergy(energyTX, this);
        //        nodes[i] = node;
        //    }
        //}

        private double CalcTotalEnergy(List<Node> nodes)
        {
            double totalEnergy = 0;
            foreach (Node node in nodes)
            {
                totalEnergy += node.E_r;
            }
            return totalEnergy;
        }
    }
}
