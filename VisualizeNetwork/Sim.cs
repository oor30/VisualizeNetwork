using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizeNetwork
{
    public abstract class Sim
    {
        // 変数
        public string AlgoName { get; protected set; }     //アルゴリズム名
        public int Round { get; private set; } = 0;   //現在のラウンド数
        protected int CHNum = 0;        //CH数
        protected int aliveNum = N;     //生存ノード数
        public List<List<Node>> nodesList = new List<List<Node>>(); //全ラウンド分のノードリスト

        //シミュレーションを評価する指標
        public int FDN { get; private set; } = 0;
        public int LDN { get; private set; } = 0;
        public List<int> CHNumList { get; private set; } = new List<int>();     //CH数のリスト
        public List<int> AliveNumList { get; private set; } = new List<int>();  //生存ノード数のリスト

        //パラメーター
        public Node BS = new Node(-1, 50, 125, -1);//BS
        public const int N = 100;           //ノード数
        public const int N_CH = 5;          //クラスタヘッド数
        public const int R = 2500;          //シミュレーションラウンド数
        public const int INTERVAL = 20;     //(s/Round)

        public void Run(List<Node> nodes)
        {
            for (int i = 0; i < R; i++)
            {
                nodes = new List<Node>(nodes);
                ResetNodesParameter(nodes);

                Round++;
                nodes = OneRound(nodes);
                nodesList.Add(nodes);
                CHNumList.Add(CHNum);
                AliveNumList.Add(aliveNum);
            }
        }

        protected List<Node> ResetNodesParameter(List<Node> nodes)
        {
            for (int i = 0; i < N; i++)
            {
                Node node = nodes[i];
                node.cmsEnergy = 0;
                node.MemberNum = 0;
                node.headID = -1;
                node.IsCH = false;
                nodes[i] = node;
            }
            return nodes;
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
        public const double packetSize = 4000;      //(bits/node/Round)1ラウンド毎に1ノードが送信するデータサイズ

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

        protected void ConsumeEnergy(double energy, ref Node node)
        {
            if (!node.Alive) return;
            node.E_r -= energy;
            node.cmsEnergy += energy;
            if (node.E_r <= 0)
            {
                node.Alive = false;
                node.E_r = 0;
                aliveNum--;
                if (aliveNum == Sim.N - 1) FDN = Round;
                else if (aliveNum == 0) LDN = Round;
                node.headID = node.ID;
            }
        }

        protected static double Dist2(Node a, Node b)
        {
            return Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2);
        }
    }
}
