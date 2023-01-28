using System;
using System.Collections.Generic;

namespace VisualizeNetwork
{
    enum Mode
    {
        IEE_LEACH,
        IEE_LEACH_A,
        IEE_LEACH_B,
        My_IEE_LEACH_B,
        My_IEE_LEACH
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
            else if (mode == Mode.My_IEE_LEACH) AlgoName = "My-IEE-LEACH";
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
            //double E_a = (E_t * (1 - (double)Round/rand))/CH_candidate;
            double Pi = P * (nodes[i].E_r / E_a);
            //double Pi = P * CH_candidate * node.E_r * Sim.E_init / (E_t * E_a);
            Pi = Math.Min(1, Pi);
            return Pi;
        }

        protected override int CalcUnqualifiedRound(Node node)
        {
            if (mode == Mode.IEE_LEACH_B || mode == Mode.My_IEE_LEACH_B)
            {
                return base.CalcUnqualifiedRound(node);
            }
            return 0;
        }

        protected override void ClusterFormation(List<Node> nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (!nodes[i].IsAlive) continue;
                if (mode != Mode.My_IEE_LEACH && nodes[i].IsCH) continue;

                Node node = nodes[i];
                Node head = node;
                double distMin = double.MaxValue;

                // 一番近いCH候補を探す
                foreach (int headID in CHIDs)
                {
                    if (mode == Mode.My_IEE_LEACH && headID == node.ID) continue;
                    Node tmp = nodes[headID];
                    double dist = Dist2(tmp, node);
                    if (dist < distMin)
                    {
                        if (mode == Mode.My_IEE_LEACH && node.IsCH && Dist2(node, BS) <= Dist2(tmp, BS))
                        {
                            continue;
                        }
                        head = tmp;
                        distMin = dist;
                    }
                }

                // CH候補が自分自身なら、スキップ
                if (node.ID == head.ID) continue;
                // CH候補よりもBSのほうが近ければ直接送る
                else if (Dist2(BS, node) < distMin && (mode == Mode.IEE_LEACH || mode == Mode.IEE_LEACH_B))
                {
                    node.CHID = -1;
                    nodes[i] = node;
                }
                // CH候補を経由するよりも直接BSに送ったほうが、全体の消費エネルギーが小さければ直接送る
                else if(DirectIsMoreEfficient(node, head) && (mode == Mode.My_IEE_LEACH_B || mode == Mode.My_IEE_LEACH))
                {
                    node.CHID = -1;
                    nodes[i] = node;
                }
                // CH候補をCHに設定
                else
                {
                    node.CHID = head.ID;
                    if (node.IsCH) node.Status = status.member_CH;
                    else node.Status = status.member;
                    nodes[i] = node;
                    head.MemberNum += 1;
                    nodes[node.CHID] = head;
                }
            }
        }

        private bool DirectIsMoreEfficient(Node node, Node head)
        {
            double energyDirect, energyViaCH;
            double distDirect = Math.Sqrt(Dist2(BS, node));
            double distToCH = Math.Sqrt(Dist2(head, node));
            energyDirect = E_TX(packetSize, distDirect);
            energyViaCH = E_TX(packetSize, distToCH) + E_DA * packetSize + E_RX(packetSize);
            if (mode == Mode.My_IEE_LEACH)
            {
                energyDirect /= node.E_r;
                energyViaCH /= head.E_r;
            }
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
