using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace VisualizeNetwork
{
	internal static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

		//public static Dictionary<int, string> AlgoName = new Dictionary<int, string>()
		//{
		//	{1, "Direct" },
		//	{2, "LEACH" },
		//	{3, "IEE-LEACH" },
		//	{4, "IEE-LEACH-A" },
		//	{5, "IEE-LEACH-B" },
		//	{6, "My-IEE-LEACH-B" },
		//	{7, "My-IEE-LEACH" },
		//	{8, "HEED" }
		//};
	}

	internal static class CopyHelper
	{
		internal static T DeepCopy<T>(this T src)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(stream, src);
				stream.Position = 0;

				return (T)formatter.Deserialize(stream);
			}
		}
	}

	enum AlgoName
	{
		Direct,
		LEACH,
		IEE_LEACH,
		IEE_LEACH_A,
		IEE_LEACH_B,
		My_IEE_LEACH_B,
		My_IEE_LEACH,
		HEED
	}

	/// <summary>
	/// ノード1つの構造体
	/// </summary>
	//[Serializable]
	public struct Node
	{
		// パラメータ
		// 定数
		public int ID { get; }      // ノードID
		public double X { get; }    // x座標
		public double Y { get; }    // y座標
		public double E_init { get; set; }       // 初期エネルギー

		// ラウンドごとにリセット
		public string Status
		{
			get { return StatusList[StatusList.Count - 1]; }
			set { StatusList[StatusList.Count - 1] = value; }
		}
		public int CHID
		{
			get { return CHIDList[CHIDList.Count - 1]; }
			set { CHIDList[CHIDList.Count - 1] = value; }
		}    // クラスタヘッドID
		public bool IsCH
		{
			get { return IsCHList[IsCHList.Count - 1]; }
			set { IsCHList[IsCHList.Count - 1] = value; }
		}   // CHか否か
		public int MemberNum
		{
			get { return MemberNumList[MemberNumList.Count - 1]; }
			set { MemberNumList[MemberNumList.Count - 1] = value; }
		}  // 自身がCHの場合、メンバノード数(自信を含む）
		public double Pi
		{
			get { return PiList[PiList.Count - 1]; }
			set { PiList[PiList.Count - 1] = value; }
		}              // CH選出確立
		public double CmsEnergy
		{
			get { return CmsEnergyList[CmsEnergyList.Count - 1]; }
			set { CmsEnergyList[CmsEnergyList.Count - 1] = value; }
		}       // ラウンド時の消費エネルギー

		public List<string> StatusList;
		public List<int> CHIDList;
		public List<bool> IsCHList;
		public List<int> MemberNumList;
		public List<double> PiList;
		public List<double> CmsEnergyList;

		// 次ラウンドに引き継ぐ
		public double E_r
		{
			get { return E_rList[E_rList.Count - 1]; }
			set { E_rList[E_rList.Count - 1] = value; }
		}     // 残量エネルギー
		public bool IsAlive
		{
			get { return IsAliveList[IsAliveList.Count - 1]; }
			set { IsAliveList[IsAliveList.Count - 1] = value; }
		}   // 生存しているか否か
		public int HasCHCnt
		{
			get { return HasCHCntList[HasCHCntList.Count - 1]; }
			set { HasCHCntList[HasCHCntList.Count - 1] = value; }
		}           // CHになった回数
		public int UnqualifiedRound
		{
			get { return UnqualifiedRoundList[UnqualifiedRoundList.Count - 1]; }
			set { UnqualifiedRoundList[UnqualifiedRoundList.Count - 1] = value; }
		}   // あと何ラウンドCHになる資格がないか

		public List<double> E_rList;
		public List<bool> IsAliveList;
		public List<int> HasCHCntList;
		public List<int> UnqualifiedRoundList;

		public Node(int ID, double X, double Y, int CHID = -1, double initEnergy = Sim.E_init) : this()
		{
			this.ID = ID;
			this.X = X;
			this.Y = Y;
			E_init = initEnergy;
			Initialize();
			this.CHID = CHID;
		}

		public Node(Node node) : this()
		{
			this.ID = node.ID;
			this.X = node.X;
			this.Y = node.Y;
			this.E_init = node.E_init;
			Initialize();
			this.CHID = node.CHID;
		}

		public void Initialize()    // シミュレーション前に１度だけ行うパラメータの初期化
		{

			StatusList = new List<string>();
			CHIDList = new List<int>();
			IsCHList = new List<bool>();
			MemberNumList = new List<int>();
			PiList = new List<double>();
			CmsEnergyList = new List<double>();

			E_rList = new List<double>();
			IsAliveList = new List<bool>();
			HasCHCntList = new List<int>();
			UnqualifiedRoundList = new List<int>();

			//E_r = E_init;
			//IsAlive = true;
			//HasCHCnt = 0;
			//UnqualifiedRound = 0;

			//E_rList.Add(E_init);
			//IsAliveList.Add(true);
			//HasCHCntList.Add(0);
			//UnqualifiedRoundList.Add(0);

			ResetParameter();
		}

		public void ResetParameter()    // ラウンドごとに行うパラメータの初期化処理
		{
			StatusList.Add("normal");
			CHIDList.Add(-1);
			IsCHList.Add(false);
			MemberNumList.Add(0);
			CmsEnergyList.Add(0);
			PiList.Add(0);

			Status = "normal";
			CHID = -1;
			IsCH = false;
			MemberNum = 0;
			CmsEnergy = 0;
			Pi = 0;

			if (E_rList.Count == 0)
			{
				E_rList.Add(E_init);
				IsAliveList.Add(true);
				HasCHCntList.Add(0);
				UnqualifiedRoundList.Add(0);
			}
			else
			{
				E_rList.Add(E_rList[E_rList.Count - 1]);
				IsAliveList.Add(IsAliveList[IsAliveList.Count - 1]);
				HasCHCntList.Add(HasCHCntList[HasCHCntList.Count - 1]);
				UnqualifiedRoundList.Add(UnqualifiedRoundList[UnqualifiedRoundList.Count - 1]);
			}
		}

		public void SetCH()
		{
			MemberNum = 1;
			IsCH = true;
			HasCHCnt++;
			Status = "CH";
		}
	}
}