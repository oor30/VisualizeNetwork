using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace VisualizeNetwork
{
	public partial class Form1 : Form
	{
		/// <summary>
		/// ノード図を並列処理で再生する
		/// </summary>
		/// <param name="ct"></param>
		/// <returns></returns>
		private async Task<int> PlayClustering(CancellationToken ct)
		{

			for (int i = round; i <= enabledAlgorithm.NodesList.Count; i++)
			{
				//ct.ThrowIfCancellationRequested();
				if (ct.IsCancellationRequested) return -1;

				ChangeRound(i);
				//trackBarRound.Value = round;
				await Task.Delay(1000 / playSpeed);
			}
			//round = 100;
			return 0;
		}

		/// <summary>
		/// ノード図を更新する
		/// </summary>
		/// <param name="nodes">ノードリスト</param>
		private void RefreshNodeMap(List<Node> nodes)
		{
			// 座標リストからノードを描画する
			Graphics g = Graphics.FromImage(pictureBoxNodeMap.Image);
			g.Clear(Color.White);
			PaintLines(g);
			PaintEdges(g, nodes);
			PaintNodes(g, nodes);
			pictureBoxNodeMap.Invalidate();
			pictureBoxNodeMap.Refresh();
			g.Dispose();
		}

		/// <summary>
		/// ノードを描画する
		/// </summary>
		/// <param name="g">キャンバスのGraphics</param>
		/// <param name="nodes">ノードリスト</param>
		private void PaintNodes(Graphics g, List<Node> nodes)
		{
			Pen pen = new Pen(Color.Black);
			Brush brush = Brushes.Gray;
			foreach (Node node in nodes)
			{
				pen.Width = 1;
				if (node.IsAlive)
				{
					if (node.IsCH && node.CHID != -1)
					{
						pen.Color = Color.Green;
						brush = Brushes.Green;
					}
					else if (node.IsCH)
					{
						pen.Color = Color.Blue;
						brush = Brushes.Blue;
					}
					else
					{
						pen.Color = Color.Black;
						brush = Brushes.Black;
					}
				}
				else pen.Color = Color.Red;
				if (node.ID == selectedNodeID)
				{
					pen.Width = 4;
					pen.Color = Color.LightBlue;
				}
				Point p = Normalize(node);
				lock (g)
				{
					g.DrawEllipse(pen, (p.X - 5), p.Y - 5, 10, 10);
					if (node.IsAlive)
						g.FillPie(brush, (p.X - 5), (p.Y - 5), 10, 10, 0, (int)(node.E_r / node.E_init * 360));
				}
			}
			return;
		}

		/// <summary>
		/// エッジを描画する
		/// </summary>
		/// <param name="g">キャンバスのGraphics</param>
		/// <param name="nodes">ノードリスト</param>
		private void PaintEdges(Graphics g, List<Node> nodes)
		{
			Pen pen = new Pen(Color.Black);
			foreach (Node node in nodes)
			{
				if (node.Status == StatusEnum.dead) continue;

				Node head;
				if (node.CHID == -1)
				{
					//head = Sim.BS;
					continue;
				}
				else
				{
					head = nodes[node.CHID];
				}
				if (node.ID != head.ID)
				{
					if (node.IsCH) pen.Color = Color.Green;
					else pen.Color = Color.Black;
					g.DrawLine(pen, Normalize(node), Normalize(head));
				}
			}
			return;
		}

		/// <summary>
		/// x軸,y軸と目盛りを描画する
		/// </summary>
		/// <param name="g">キャンバスのGraphics</param>
		private void PaintLines(Graphics g)
		{
			Pen pen = new Pen(Color.Gray);
			for (int i = (int)(scenario.minX - 10) / 50; i <= (scenario.maxX + 10); i += 50)
			{
				var p = Normalize(new Point(i, i));
				g.DrawLine(pen, p.X, 0, p.X, scenario.canvasH);
				g.DrawString(i.ToString(), this.Font, Brushes.Black, p.X, 0);
			}
			for (int i = (int)(scenario.minY - 10) / 50; i <= (scenario.maxY + 10); i += 50)
			{
				var p = Normalize(new Point(i, i));
				g.DrawLine(pen, 0, p.Y, scenario.canvasW, p.Y);
				g.DrawString(i.ToString(), this.Font, Brushes.Black, 0, p.Y);
			}
		}

		/// <summary>
		/// ノードの座標をノード図のピクセルに変換する
		/// </summary>
		/// <param name="node">ノード</param>
		/// <returns>ポイント</returns>
		private Point Normalize(Node node)
		{
			return new Point((int)((node.X - scenario.minX) * scenario.rw * 0.95 + scenario.canvasW * 0.025),
				(int)((node.Y - scenario.minY) * scenario.rh * 0.95 + scenario.canvasH * 0.025));
		}

		/// <summary>
		/// ノードの座標をノード図のピクセルに変換する
		/// </summary>
		/// <param name="point">ポイント</param>
		/// <returns>ポイント</returns>
		private Point Normalize(Point point)
		{
			Point p = new Point((int)((point.X - scenario.minX) * scenario.rw * 0.95 + scenario.canvasW * 0.025),
				(int)((point.Y - scenario.minY) * scenario.rh * 0.95 + scenario.canvasH * 0.025));
			return p;
		}

		/// <summary>
		/// ノード図のピクセルをノードの座標に変換する
		/// </summary>
		/// <param name="p">ポイント</param>
		/// <returns>ポイント</returns>
		private Point RevNormalize(Point p)
		{
			return new Point((int)((p.X - scenario.canvasW * 0.025) / scenario.rw / 0.95 + scenario.minX),
				(int)((p.Y - scenario.canvasH * 0.025) / scenario.rh / 0.95 + scenario.minY));
		}
	}
}
