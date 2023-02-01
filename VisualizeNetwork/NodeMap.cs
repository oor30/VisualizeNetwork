using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VisualizeNetwork
{
	internal class NodeMap
	{
		private readonly PictureBox canvas;
		private float CanvasW { get { return canvas.Width; } }
		private float CanvasH { get { return canvas.Height; } }
		private double minX, maxX, minY, maxY;
		private double rw, rh;

		internal NodeMap(PictureBox pictureBox)
		{
			canvas = pictureBox;
		}

		internal void SetParameters(List<Node> initialNodes)
		{
			maxX = double.MinValue;
			minX = double.MaxValue;
			maxY = double.MinValue;
			minY = double.MaxValue;

			foreach (Node node in initialNodes)
			{
				if (maxX < node.X) maxX = node.X;
				if (minX > node.X) minX = node.X;
				if (maxY < node.Y) maxY = node.Y;
				if (minY > node.Y) minY = node.Y;
			}

			double w = maxX - minX;
			double h = maxY - minY;
			rw = CanvasW / w;
			rh = CanvasH / h;
		}

		/// <summary>
		/// ノード図を更新する
		/// </summary>
		/// <param name="nodes">ノードリスト</param>
		internal void RefreshNodeMap(List<Node> nodes, int selectedNodeID)
		{
			// 座標リストからノードを描画する
			Graphics g = Graphics.FromImage(canvas.Image);
			g.Clear(Color.White);
			PaintLines(g);
			PaintEdges(g, nodes);
			PaintNodes(g, nodes, selectedNodeID);
			canvas.Invalidate();
			canvas.Refresh();
			g.Dispose();
		}

		/// <summary>
		/// ノードを描画する
		/// </summary>
		/// <param name="g">キャンバスのGraphics</param>
		/// <param name="nodes">ノードリスト</param>
		private void PaintNodes(Graphics g, List<Node> nodes, int selectedNodeID)
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
			for (int i = (int)(minX - 10) / 50; i <= (maxX + 10); i += 50)
			{
				var p = Normalize(new Point(i, i));
				g.DrawLine(pen, p.X, 0, p.X, CanvasH);
				g.DrawString(i.ToString(), canvas.Font, Brushes.Black, p.X, 0);
			}
			for (int i = (int)(minY - 10) / 50; i <= (maxY + 10); i += 50)
			{
				var p = Normalize(new Point(i, i));
				g.DrawLine(pen, 0, p.Y, CanvasW, p.Y);
				g.DrawString(i.ToString(), canvas.Font, Brushes.Black, 0, p.Y);
			}
		}

		/// <summary>
		/// ノードの座標をノード図のピクセルに変換する
		/// </summary>
		/// <param name="node">ノード</param>
		/// <returns>ポイント</returns>
		private Point Normalize(Node node)
		{
			return new Point((int)((node.X - minX) * rw * 0.95 + CanvasW * 0.025),
				(int)((node.Y - minY) * rh * 0.95 + CanvasH * 0.025));
		}

		/// <summary>
		/// ノードの座標をノード図のピクセルに変換する
		/// </summary>
		/// <param name="point">ポイント</param>
		/// <returns>ポイント</returns>
		private Point Normalize(Point point)
		{
			Point p = new Point((int)((point.X - minX) * rw * 0.95 + CanvasW * 0.025),
				(int)((point.Y - minY) * rh * 0.95 + CanvasH * 0.025));
			return p;
		}

		/// <summary>
		/// ノード図のピクセルをノードの座標に変換する
		/// </summary>
		/// <param name="p">ポイント</param>
		/// <returns>ポイント</returns>
		internal Point RevNormalize(Point p)
		{
			return new Point((int)((p.X - CanvasW * 0.025) / rw / 0.95 + minX),
				(int)((p.Y - CanvasH * 0.025) / rh / 0.95 + minY));
		}
	}
}
