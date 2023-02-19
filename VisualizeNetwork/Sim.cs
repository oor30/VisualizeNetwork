﻿using System;
using System.Collections.Generic;

using static VisualizeNetwork.Config;

namespace VisualizeNetwork
{
	[Serializable()]
	internal abstract class Sim
	{
		// 定数
		public string AlgoName { get; protected set; }     // アルゴリズム名
		public const int R = 5000;          // 最大シミュレーションラウンド数
		// 変数
		protected int Round { get; private set; }   // 現在のラウンド数
		protected int CHNum { get; private set; }        // CH数
		protected int AliveNum { get; private set; }     // 生存ノード数
		private double EnergyConsumption;   // エネルギー消費量

		// シミュレーションを評価する指標
		public int FDN { get; private set; } = 0;
		public int LDN { get; private set; } = 0;
		public double CHMean { get; private set; } = 0;
		public double CHSD { get; private set; } = 0;
		public double AveEnergyConsumption { get; private set; } = 0;
		public int CollectedDataNum { get; private set; } = 0;
		public List<int> CHNumList { get; } = new List<int>();      // CH数のリスト
		public List<int> AliveNumList { get; } = new List<int>();   // 生存ノード数のリスト
		public List<int> CollectedDataNumList { get; } = new List<int>();
		public List<double> TotalEnergyConsumptionList { get; } = new List<double>();

		// 全ラウンド分のノードリスト
		public List<List<Node>> NodesList { get; } = new List<List<Node>>();

		public void Run(List<Node> initialNodes)
		{
			Round = 0;
			AliveNum = N;
			List<Node> nodes = new List<Node>(initialNodes);
			for (int i = 0; i < R; i++)
			{
				nodes = new List<Node>(nodes);
				for (int j = 0; j < N; j++)
				{
					Node node = nodes[j];
					if (node.IsAlive) node.ResetParameter();
					else if (node.Status != StatusEnum.dead) node.SetDead();
					nodes[j] = node;
				}

				Round++;
				CHNum = 0;
				EnergyConsumption = 0;
				OneRound(nodes);
				NodesList.Add(nodes);
				CHNumList.Add(CHNum);
				AliveNumList.Add(AliveNum);
				CollectedDataNum += AliveNum;
				CollectedDataNumList.Add(CollectedDataNum);
				if (i == 0) TotalEnergyConsumptionList.Add(EnergyConsumption);
				else TotalEnergyConsumptionList.Add(TotalEnergyConsumptionList[i - 1] + EnergyConsumption);

				if (AliveNum == 0) break;
			}
			FinalizeSimulation();
		}

		/// <summary>
		/// 1ラウンドで行う処理。抽象メソッド。
		/// </summary>
		/// <param name="nodes">ノードリスト</param>
		/// <returns>ノードリスト</returns>
		protected abstract void OneRound(List<Node> nodes);

		/// <summary>
		/// エネルギーを消費する
		/// </summary>
		/// <param name="energy">消費エネルギー量</param>
		/// <param name="node">ノード</param>
		protected void ConsumeEnergy(double energy, ref Node node)
		{
			if (!node.IsAlive) return;
			energy = Math.Min(energy, node.E_r);
			node.Consume(energy);
			EnergyConsumption += energy;
			if (!node.IsAlive)
			{
				AliveNum--;
				if (AliveNum == N - 1) FDN = Round;
				else if (AliveNum == 0) LDN = Round;
			}
		}

		protected void SetCH(ref Node node)
		{
			CHNum++;
			node.SetCH();
		}

		protected void SetMN(ref Node node, ref Node head)
		{
			node.SetMN(ref node, ref head);
		}

		/// <summary>
		/// シミュレーションの最後に評価指標を計算する
		/// </summary>
		private void FinalizeSimulation()
		{
			for (int j = 0; j < FDN; j++)
			{
				CHMean += CHNumList[j];
				foreach (Node node in NodesList[j])
				{
					AveEnergyConsumption += node.CnsEnergy;
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
