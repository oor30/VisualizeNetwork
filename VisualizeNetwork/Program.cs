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

	public enum status
	{
		dead,
		normal,
		member,
		CH,
		member_CH,
		BS
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
		public status Status { get; set; }
		public int CHID { get; set; }    // クラスタヘッドID
		public bool IsCH { get; set; }   // CHか否か
		public int MemberNum { get; set; }  // 自身がCHの場合、メンバノード数(自信を含む）
		public double Pi { get; set; }              // CH選出確立
		public double CmsEnergy { get; set; }       // ラウンド時の消費エネルギー

		// 次ラウンドに引き継ぐ
		public double E_r { get; set; }     // 残量エネルギー
		public bool IsAlive { get; set; }   // 生存しているか否か
		public int HasCHCnt { get; set; }           // CHになった回数
		public int UnqualifiedRound { get; set; }   // あと何ラウンドCHになる資格がないか

		public Node(int ID, double X, double Y, int CHID = -1, double initEnergy = Sim.E_init) : this()
		{
			this.ID = ID;
			this.X = X;
			this.Y = Y;
			this.CHID = CHID;
			E_init = initEnergy;
			Initialize();
		}

		public void Initialize()    // シミュレーション前に１度だけ行うパラメータの初期化
		{
			E_r = E_init;
			IsAlive = true;
			HasCHCnt = 0;
			UnqualifiedRound = 0;
		}

		public void ResetParameter()    // ラウンドごとに行うパラメータの初期化処理
		{
			Status = status.normal;
			CHID = -1;
			IsCH = false;
			MemberNum = 0;
			CmsEnergy = 0;
			Pi = 0;
		}

		public void SetCH()
		{
			MemberNum = 1;
			IsCH = true;
			HasCHCnt++;
			Status = status.CH;
		}
	}
}