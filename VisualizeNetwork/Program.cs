using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

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
    }

    /// <summary>
    /// ノード1つの構造体
    /// </summary>
    public struct Node
    {
        public int ID { get; }      // ノードID
        public double X { get; }    // x座標
        public double Y { get; }    // y座標
        public int CHID { get; set; }
        //{
        //    get { return this.CHID; }
        //    set
        //    {
        //        if (value >= -1 && value <= Sim.N) CHID = value;
        //        else CHID = -1;
        //    }
        //}       // クラスタヘッドID
        public Boolean IsCH { get; set; }   // CHか否か
        public int MemberNum { get; set; }  // 自身がCHの場合、メンバノード数(自信を含む）
        public Boolean IsAlive { get; set; }  // 生存しているか否か
        public double E_r { get; set; }     // 残量エネルギー
        public double CmsEnergy { get; set; }       // ラウンド時の消費エネルギー
        public int HasCHCnt { get; set; }           // CHになった回数
        public int UnqualifiedRound { get; set; }   // あと何ラウンドCHになる資格がないか
        public double Pi { get; set; }
        private static Random R = new Random();

        public Node(int ID, double X, double Y, int CHID, bool ConstInitialEnergy = true) : this()
        {
            this.ID = ID;
            this.X = X;
            this.Y = Y;
            this.CHID = CHID;
            HasCHCnt = 0;
            UnqualifiedRound = 0;
            IsAlive = true;
            if (ConstInitialEnergy) E_r = Sim.E_init;   //(J)残量エネルギー(初期値：0.5J)
            else E_r = R.NextDouble()/2 + 0.5;
        }

        public void ResetParameter()    // ラウンドごとに行うパラメータの初期化処理
        {
            CmsEnergy = 0;
            MemberNum = 0;
            CHID = -1;
            IsCH = false;
            Pi = 0;
        }
    }
}