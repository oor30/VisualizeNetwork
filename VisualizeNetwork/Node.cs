﻿using System;

namespace VisualizeNetwork
{
	/// <summary>
	/// ノードの状態
	/// </summary>
	[Flags]
	public enum StatusEnum
	{
		dead = 0,
		normal = 1,
		member = 2,
		CH = 4,
		BS = 8
	}

	/// <summary>
	/// ノード1つの構造体
	/// </summary>
	[Serializable()]
	public struct Node
	{
		// パラメータ
		// 定数
		public int ID { get; }      // ノードID
		public double X { get; }    // x座標
		public double Y { get; }    // y座標
		public double E_init { get; private set; }       // 初期エネルギー

		// ラウンドごとにリセット
		public StatusEnum Status { get; set; }  // ノードの状態
		public int CHID { get; set; }    // クラスタヘッドID
		public bool IsCH { get; set; }   // CHか否か
		public int MemberNum { get; set; }  // 自身がCHの場合、メンバノード数(自信を含む）
		public double Pi { get; set; }              // CH選出確立
		public double CmsEnergy { get; set; }       // ラウンド時の消費エネルギー

		// 次ラウンドに引き継ぐ
		public double E_r { get; set; }     // 残量エネルギー
		public bool IsAlive { get; set; }   // 生存しているか否か
		public int HasCHCnt { get; private set; }           // CHになった回数
		public int UnqualifiedRound { get; set; }   // あと何ラウンドCHになる資格がないか

		public Node(int ID, double X, double Y) : this()
		{
			this.ID = ID;
			this.X = X;
			this.Y = Y;
		}

		// シミュレーション前に１度だけ行うパラメータの初期化
		public void Initialize(double E_init)
		{
			this.E_init = E_init;
			E_r = E_init;
			IsAlive = true;
			HasCHCnt = 0;
			UnqualifiedRound = 0;
		}

		// ラウンドごとに行うパラメータの初期化処理
		public void ResetParameter()
		{
			Status = StatusEnum.normal;
			CHID = -1;
			IsCH = false;
			MemberNum = 0;
			CmsEnergy = 0;
			Pi = 0;
		}

		public void SetCH()
		{
			MemberNum = 0;
			IsCH = true;
			HasCHCnt++;
			Status = StatusEnum.CH;
		}

		public void SetDead()
		{
			Status = StatusEnum.dead;
			CHID = 444;
			IsCH = false;
			MemberNum = 0;
			Pi = 0;
			CmsEnergy = 0;
			UnqualifiedRound = 0;
		}
	}

}