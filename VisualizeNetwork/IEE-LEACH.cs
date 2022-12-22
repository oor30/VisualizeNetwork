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

        public IEE_LEACH(Mode mode)
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
