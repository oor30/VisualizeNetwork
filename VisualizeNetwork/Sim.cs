using System;
using System.Collections.Generic;

namespace VisualizeNetwork
{
    internal abstract class Sim
    {
        // 変数
        public string AlgoName { get; protected set; }     // アルゴリズム名
        public int Round { get; private set; } = 0;   // 現在のラウンド数
        protected int CHNum = 0;        // CH数
        protected int aliveNum = N;     // 生存ノード数
        private double EnergyConsumption = 0;   // エネルギー消費量
        protected List<Node> nodes;             // ノードリスト

        // 全ラウンド分のノードリスト
        public readonly List<List<Node>> nodesList = new List<List<Node>>();

        // シミュレーションを評価する指標
        public int FDN { get; private set; } = 0;
        public int LDN { get; private set; } = 0;
        public double CHMean { get; private set; } = 0;
        public double CHSD { get; private set; } = 0;
        public double AveEnergyConsumption { get; private set; } = 0;
        public int CollectedDataNum { get; private set; } = 0;
        public List<int> AliveNumList { get; } = new List<int>();   // 生存ノード数のリスト
        public List<int> CHNumList { get; } = new List<int>();      // CH数のリスト
        public List<int> CollectedDataNumList { get; } = new List<int>();
        public List<double> TotalEnergyConsumptionList { get; } = new List<double>();

        // パラメーター
        public static Node BS = new Node(-1, 50, 125, -1);//BS
        public const int N = 100;           // ノード数
        public const int k = 5;             // クラスタヘッド数
        public const int R = 3500;          // シミュレーションラウンド数
        public const int INTERVAL = 20;     // (s/Round)

        public void Run(List<Node> initialNodes)
        {
            nodes = initialNodes;
            for (int i = 0; i < R; i++)
            {
                nodes = new List<Node>(nodes);
                for (int j = 0; j < N; j++)
                {
                    Node node = nodes[j];
                    node.ResetParameter();
                    nodes[j] = node;
                }

                Round++;
                EnergyConsumption = 0;
                nodes = OneRound(nodes);
                nodesList.Add(nodes);
                AliveNumList.Add(aliveNum);
                CHNumList.Add(CHNum);
                CollectedDataNum += aliveNum;
                CollectedDataNumList.Add(CollectedDataNum);
                if (i == 0) TotalEnergyConsumptionList.Add(EnergyConsumption);
                else TotalEnergyConsumptionList.Add(TotalEnergyConsumptionList[i - 1] + EnergyConsumption);
            }
            FinalizeSimulation();
        }

        protected abstract List<Node> OneRound(List<Node> nodes);

        //エネルギー消費モデル
        public const double E_init = 0.5;         //(J)ノードの初期エネルギー
        public const double E_elec = 50.0e-9;   //(nj/bit)
        public const double E_DA = 5.0e-9;      //(nj/bit/signal)
        public const double d_0 = 87.0;         //(m)
        public const double e_fs = 10.0e-12;    //(pj/bit/m^2)
        public const double e_mp = 0.0013e-12;  //(pj/bit/m^4)
        //public const double bandwidth = 1.0e6;  //(Mb/s)
        public const double bandwidth = 4000;    //(bits/s)
        public static double packetSize = 4000;      //(bits/node/Round)1ラウンド毎に1ノードが送信するデータサイズ

        protected static double E_TX(double m, double d)
        {
            if (d <= d_0)
                return m * E_elec + m * e_fs * Math.Pow(d, 2);
            else
                return m * E_elec + m * e_mp * Math.Pow(d, 4);
        }
        protected static double E_RX(double m)
        {
            return m * E_elec;
        }

        protected static double CalcEnergyConsumption(Node node, List<Node> nodes)
        {
            double sendMessageBit = packetSize;
            double energy;

            Node addressNode;
            if (node.CHID == -1) addressNode = BS;
            else addressNode = nodes[node.CHID];
            double dist = Math.Sqrt(Dist2(addressNode, node));
            if (node.IsCH)
            {
                energy = E_TX(sendMessageBit, dist) + E_DA * sendMessageBit * node.MemberNum
                    + E_RX(sendMessageBit) * node.MemberNum;
            }
            else
            {
                energy = E_TX(sendMessageBit, dist);
            }
            return energy;
        }

        protected void ConsumeEnergy(double energy, ref Node node)
        {
            if (!node.IsAlive) return;
            energy = Math.Min(energy, node.E_r);
            node.E_r -= energy;
            node.CmsEnergy += energy;
            EnergyConsumption += energy;
            if (node.E_r <= 0)
            {
                node.IsAlive = false;
                node.Status = "dead";
                aliveNum--;
                if (aliveNum == N - 1) FDN = Round;
                else if (aliveNum == 0) LDN = Round;
                node.CHID = node.ID;
            }
        }

        protected static double Dist2(Node a, Node b)
        {
            return Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2);
        }

        protected void FinalizeSimulation()
        {
            for (int j = 0; j < FDN; j++)
            {
                CHMean += CHNumList[j];
                foreach (Node node in nodesList[j])
                {
                    AveEnergyConsumption += node.CmsEnergy;
                }
            }
            CHMean /= FDN;
            AveEnergyConsumption /= FDN;

            for (int j = 0; j < FDN; j++)
            {
                CHSD += Math.Pow((CHNumList[j] - CHMean), 2);
            }
            CHSD = Math.Sqrt(CHSD / N);
        }
    }
}
