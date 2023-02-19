using System;

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
		public StatusEnum Status { get; private set; }  // ノードの状態
		public short CHID { get; private set; }    // クラスタヘッドID
		public bool IsCH { get; private set; }   // CHか否か
		public short MemberNum { get; private set; }  // 自身がCHの場合、メンバノード数(自信を含む）
		public float Pi { get; set; }              // CH選出確立
		public float CnsEnergy { get; private set; }       // ラウンド時の消費エネルギー

		// 次ラウンドに引き継ぐ
		public float E_r { get; private set; }     // 残量エネルギー
		public bool IsAlive { get; private set; }   // 生存しているか否か
		public short HasCHCnt { get; private set; }           // CHになった回数
		public short UnqualifiedRound { get; set; }   // あと何ラウンドCHになる資格がないか

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
			E_r = (float)E_init;
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
			CnsEnergy = 0;
			Pi = 0;
		}

		public void SetCH()
		{
			MemberNum = 0;
			IsCH = true;
			HasCHCnt++;
			Status = StatusEnum.CH;
		}

		public void SetMN(ref Node node, ref Node head)
		{
			node.CHID = (short)head.ID;
			node.Status = (node.Status | StatusEnum.member) & ~StatusEnum.normal;
			head.MemberNum += 1;
		}

		public void SetDead()
		{
			Status = StatusEnum.dead;
			CHID = 444;
			IsCH = false;
			MemberNum = 0;
			Pi = 0;
			CnsEnergy = 0;
			UnqualifiedRound = 0;
		}

		public void Consume(double energy)
		{
			if (energy > E_r)
			{
				throw new Exception("引数が残量エネルギーを超えています。");
			}
			E_r -= (float)energy;
			CnsEnergy += (float)energy;
			if (E_r <= 0)
			{
				IsAlive = false;
			}
		}
	}

}
