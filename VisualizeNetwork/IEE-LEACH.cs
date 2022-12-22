using System;
using System.Collections.Generic;

namespace VisualizeNetwork
{
    enum Mode
    {
        IEE_LEACH,
        IEE_LEACH_A,
        IEE_LEACH_B,
        My_IEE_LEACH_B
    }

    internal class IEE_LEACH : LEACH
    {
        private readonly Mode mode;

        public IEE_LEACH(Form1 form1, Mode mode) : base(form1)
        {
            this.mode = mode;
            if (mode == Mode.IEE_LEACH) AlgoName = "IEE-LEACH";
            else if (mode == Mode.IEE_LEACH_A) AlgoName = "IEE-LEACH-A";
            else if (mode == Mode.IEE_LEACH_B) AlgoName = "IEE-LEACH-B";
            else if (mode == Mode.My_IEE_LEACH_B) AlgoName = "My-IEE-LEACH-B";
        }

        protected override void ResetUnqualifiedRound(List<Node> nodes)
        {
            if (mode == Mode.IEE_LEACH_B || mode == Mode.My_IEE_LEACH_B) base.ResetUnqualifiedRound(nodes);
        }

        protected override double GetPi(List<Node> nodes, int i)
        {
            if (mode == Mode.IEE_LEACH_B || mode == Mode.My_IEE_LEACH_B)
            {
                return base.GetPi(nodes, i);
            }

            // ラウンド数に応じたCH選出確立を計算
            double E_t = CalcTotalEnergy(nodes);
            double E_a = E_t / N;
            //double E_a = (E_t * (1 - (double)Round/R))/CH_candidate;
            double Pi = P * (nodes[i].E_r / E_a);
            //double Pi = P * CH_candidate * node.E_r * Sim.E_init / (E_t * E_a);
            Pi = Math.Min(1, Pi);
            return Pi;
        }

        //protected override void CHElection(List<Node> nodes)
        //{
        //    CHIDs.Clear();
        //    CHNum = 0;
        //    //if (mode == Mode.IEE_LEACH_B || mode == Mode.My_IEE_LEACH_B) ResetUnqualifiedRound(nodes);
        //    ResetUnqualifiedRound(nodes);
        //    for (int i = 0; i < nodes.Count; i++)
        //    {
        //        Node node = nodes[i];
        //        if (!node.IsAlive) continue;// ノードが死んでたら次


        //        Pi = GetP_i(nodes, i);
        //        T = Pi;
        //        if (T > 20)
        //            Console.WriteLine(T);
        //        node.Pi = Pi;

        //        nodes[i] = CHElectionHelper(node);
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
                if (Dist2(BS, node) < distMin && (mode == Mode.IEE_LEACH || mode == Mode.IEE_LEACH_B))
                {
                    node.CHID = -1;
                    nodes[i] = node;
                    return;
                }
                else if (mode == Mode.My_IEE_LEACH_B && DirectIsMoreEfficient(node, head))
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

        private bool DirectIsMoreEfficient(Node node, Node head)
        {
            double energyDirect, energyViaCH;
            double distDirect = Math.Sqrt(Dist2(BS, node));
            double distToCH = Math.Sqrt(Dist2(head, node));
            energyDirect = E_TX(packetSize, distDirect);
            energyViaCH = E_TX(packetSize, distToCH) + E_DA * packetSize + E_RX(packetSize);
            if (energyDirect < energyViaCH) return true;
            else return false;
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
