﻿using System;
using System.Collections.Generic;

namespace VisualizeNetwork
{
    internal class LEACH : Sim
    {
        protected const double P = (double)N_CH / N;
        protected Random rand = new Random();
        protected List<int> CHIDs = new List<int>();    //CHのリスト

        public LEACH(Form1 form1) : base(form1)
        {
            AlgoName = "LEACH";
        }

        protected override List<Node> OneRound(List<Node> nodes)
        {
            CHElection(nodes);
            ClusterFormation(nodes);
            SteadyState(nodes);
            return nodes;
        }

        protected virtual void ResetUnqualifiedRound(List<Node> nodes)
        {
            if (Round % (1 / P) == 1)   // 1/Pラウンドごとに、(1,21,41,...ラウンド時に)
            {
                for (int i = 0; i < N; i++)
                {
                    //hasBeenCH[i] = 0;   // CHになる確立を等しくする
                    Node node = nodes[i];
                    node.UnqualifiedRound = 0;
                    nodes[i] = node;
                }
            }
        }

        protected virtual double GetPi(List<Node> nodes, int i)
        {
            if (nodes[i].UnqualifiedRound == 0) // CHの資格あり
                return P / (1 - P * ((Round - 1) % (1 / P)));
            return 0;
        }

        //protected Node CHElectionHelper(Node node)
        //{
        //    //if (node.UnqualifiedRound == 0) // CHの資格あり
        //    //{
        //    node.T = T;
        //    if (node.Pi > rand.NextDouble())  // 確立T(0<=T<=1)でCHになる
        //    {
        //        node.MemberNum = 1;

        //        node.UnqualifiedRound = (int)Math.Round(1 / node.Pi);
        //        CHIDs.Add(node.ID);
        //        CHNum++;
        //        node.IsCH = true;
        //        node.HasCHCnt++;
        //    }
        //    //}
        //    if (node.UnqualifiedRound > 0) // CHの資格なし
        //    {
        //        node.UnqualifiedRound--;
        //    }
        //    return node;
        //}

        /// <summary>
        /// 引数をもとにクラスタヘッドを選出し、クラスタヘッドフラグを立てる
        /// </summary>
        /// <param AlgoName="nodes">構造体Nodeのリスト</param>
        protected virtual void CHElection(List<Node> nodes)
        {
            CHIDs.Clear();
            CHNum = 0;
            ResetUnqualifiedRound(nodes);
            for (int i = 0; i < nodes.Count; i++)
            {
                Node node = nodes[i];
                if (!node.IsAlive) continue;// ノードが死んでたら次

                // ラウンド数に応じたCH選出確立を計算
                if (node.IsAlive) node.Pi = GetPi(nodes, i);
                if (node.Pi > rand.NextDouble())  // 確立T(0<=T<=1)でCHになる
                {
                    node.MemberNum = 1;
                    node.UnqualifiedRound = (int)Math.Round(1 / node.Pi);
                    CHIDs.Add(node.ID);
                    CHNum++;
                    node.IsCH = true;
                    node.HasCHCnt++;
                }
                //}
                if (node.UnqualifiedRound > 0) // CHの資格なし
                {
                    node.UnqualifiedRound--;
                }
                nodes[i] = node;
                //nodes[i] = CHElectionHelper(node);
            }
        }

        /// <summary>
        /// 引数をもとにメンバノードが参加するクラスタを選択する。
        /// 最短距離のクラスタヘッドを選択する。
        /// </summary>
        /// <param AlgoName="nodes">構造体Nodeのリスト</param>
        protected virtual void ClusterFormation(List<Node> nodes)
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
                node.CHID = head.ID;
                nodes[i] = node;
                head.MemberNum += 1;
                nodes[node.CHID] = head;
            }
        }

        /// <summary>
        /// SteadyState中で消費する電力を計算
        /// </summary>
        /// <param AlgoName="nodes">構造体Nodeのリスト</param>
        protected virtual void SteadyState(List<Node> nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (!nodes[i].IsAlive) continue;
                //double assignedTime;
                //double sendMessageBit, dist, energyTX;
                Node node = nodes[i];

                //if (node.IsCH)  //CH→BS
                //{
                //    //assignedTime = (double)Sim.INTERVAL / node.MemberNum;
                //    //sendMessageBit = Sim.bandwidth * assignedTime;

                //    sendMessageBit = Sim.packetSize;
                //    dist = Math.Sqrt(Sim.Dist2(BS, node));
                //    energyTX = Sim.E_TX(sendMessageBit, dist) + Sim.E_DA * sendMessageBit * node.MemberNum;
                //}
                //else if (node.CHID == -1)//member→BS
                //{
                //    sendMessageBit = Sim.packetSize;
                //    dist = Math.Sqrt(Sim.Dist2(BS, node));
                //    energyTX = Sim.E_TX(sendMessageBit, dist);
                //}
                //else//member→CH
                //{
                //    Node head = nodes[node.CHID];
                //    //assignedTime = (double)Sim.INTERVAL / head.MemberNum;
                //    //sendMessageBit = Sim.bandwidth * assignedTime;

                //    sendMessageBit = Sim.packetSize;
                //    dist = Math.Sqrt(Sim.Dist2(head, node));
                //    energyTX = Sim.E_TX(sendMessageBit, dist);
                //    //head.E_r -= Sim.E_RX(sendMessageBit);
                //    ConsumeEnergy(Sim.E_RX(sendMessageBit), ref head);
                //    //head.ConsumeEnergy(Sim.E_RX(sendMessageBit), this);
                //    nodes[node.CHID] = head;
                //}

                double energy = CalcEnergyConsumption(node, nodes);
                ConsumeEnergy(energy, ref node);
                nodes[i] = node;
            }
        }
    }
}