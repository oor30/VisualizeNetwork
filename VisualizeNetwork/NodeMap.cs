﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Svg;

namespace VisualizeNetwork
{
	internal class NodeMap
	{
		internal readonly PictureBox canvas;
		private float CanvasW { get { return canvas.Width; } }
		private float CanvasH { get { return canvas.Height; } }
		private double minX, maxX, minY, maxY;
		private double rw, rh;

		internal SvgDocument svgDoc;

		internal NodeMap(PictureBox pictureBox)
		{
			canvas = pictureBox;
			svgDoc = new SvgDocument();
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

			svgDoc.ViewBox = new SvgViewBox(-50, -50, 1100, 1100);
			svgDoc.Width = CanvasW;
			svgDoc.Height = CanvasH;
		}

		/// <summary>
		/// ノード図を更新する
		/// </summary>
		/// <param name="nodes">ノードリスト</param>
		internal void RefreshNodeMap(List<Node> nodes, int selectedNodeID, bool enabledGrid)
		{
			// 座標リストからノードを描画する
			Graphics g = Graphics.FromImage(canvas.Image);
			//g.Clear(Color.White);
			//g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			svgDoc.Children.Clear();
			if (enabledGrid) PaintLines(g);
			PaintEdges(g, nodes);
			PaintNodes(g, nodes, selectedNodeID);
			canvas.Invalidate();
			canvas.Refresh();
			g.Dispose();

			canvas.Image = svgDoc.Draw();
		}

		/// <summary>
		/// ノードを描画する
		/// </summary>
		/// <param name="g">キャンバスのGraphics</param>
		/// <param name="nodes">ノードリスト</param>
		private void PaintNodes(Graphics g, List<Node> nodes, int selectedNodeID)
		{
			var group = new SvgGroup();
			svgDoc.Children.Add(group);
			SvgColourServer scs = new SvgColourServer();

			//Pen pen = new Pen(Color.Black);
			//Brush brush = Brushes.Gray;
			foreach (Node node in nodes)
			{
				//pen.Width = 1;
				if (node.IsAlive)
				{
					if (node.IsCH && node.CHID != -1)
					{
						//pen.Color = Color.Green;
						//brush = Brushes.Green;

						scs = new SvgColourServer(Color.Green);
					}
					else if (node.IsCH)
					{
						//pen.Color = Color.Blue;
						//brush = Brushes.Blue;

						scs = new SvgColourServer(Color.Blue);
					}
					else
					{
						//pen.Color = Color.Black;
						//brush = Brushes.Black;

						scs = new SvgColourServer(Color.Black);
					}
				}
				//else pen.Color = Color.Red;
				if (node.ID == selectedNodeID)
				{
					//pen.Width = 4;
					//pen.Color = Color.LightBlue;
				}
				//Point p = Normalize(node);
				//lock (g)
				//{
				//	g.DrawEllipse(pen, (p.X - 5), p.Y - 5, 10, 10);
				//	if (node.IsAlive)
				//		g.FillPie(brush, (p.X - 5), (p.Y - 5), 10, 10, 0, (int)(node.E_r / node.E_init * 360));
				//}

				group.Children.Add(new SvgCircle
				{
					CenterX = (int)node.X * 10,
					CenterY = (int)node.Y * 10,
					Radius = 10,
					Fill = scs,
					Stroke = scs,
				});
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
			var group = new SvgGroup();
			svgDoc.Children.Add(group);
			SvgColourServer scs;

			//Pen pen = new Pen(Color.Black);
			foreach (Node node in nodes)
			{
				if (node.Status == StatusEnum.dead) continue;
				if (!node.IsAlive) continue;

				Node head;
				if (node.CHID == -1)
				{
					continue;
				}

				head = nodes[node.CHID];

				if (node.ID != head.ID)
				{
					//if (node.IsCH) pen.Color = Color.Green;
					//else pen.Color = Color.Black;
					//g.DrawLine(pen, Normalize(node), Normalize(head));

					if (node.IsCH) scs = new SvgColourServer(Color.Green);
					else scs = new SvgColourServer(Color.Black);
					group.Children.Add(new SvgLine()
					{
						StartX = (int)node.X * 10,
						StartY = (int)node.Y * 10,
						EndX = (int)head.X * 10,
						EndY = (int)head.Y * 10,
						Stroke = scs,
						StrokeWidth = 1,
					});
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
			var group = new SvgGroup();
			svgDoc.Children.Add(group);
			SvgColourServer scs = new SvgColourServer(Color.Gray);

			//Pen pen = new Pen(Color.Gray);
			for (int i = (int)(minX - 10) / 50; i <= (maxX + 10); i += 50)
			{
				//var p = Normalize(new Point(i, i));
				//g.DrawLine(pen, p.X, 0, p.X, CanvasH);
				//g.DrawString(i.ToString(), canvas.Font, Brushes.Black, p.X, 0);

				group.Children.Add(new SvgText()
				{
					Nodes = { new SvgContentNode { Content = i.ToString() } },
					X = { i*10 },
					Y = { 0 },
					Fill = scs,
					FontSize = 30,
					FontFamily = "sans-serif",
				});

				group.Children.Add(new SvgLine()
				{
					StartX = i * 10,
					StartY = svgDoc.ViewBox.MinY,
					EndX = i * 10,
					EndY = svgDoc.ViewBox.MinY + svgDoc.ViewBox.Height,
					Stroke = scs,
					StrokeWidth = 1,
				});
			}
			for (int i = (int)(minY - 10) / 50; i <= (maxY + 10); i += 50)
			{
				//var p = Normalize(new Point(i, i));
				//g.DrawLine(pen, 0, p.Y, CanvasW, p.Y);
				//g.DrawString(i.ToString(), canvas.Font, Brushes.Black, 0, p.Y);

				group.Children.Add(new SvgText()
				{
					Nodes = { new SvgContentNode { Content = i.ToString() } },
					X = { 0 },
					Y = { i * 10 },
					Fill = scs,
					FontSize = 30,
					FontFamily = "sans-serif",
				});

				group.Children.Add(new SvgLine()
				{
					StartX = svgDoc.ViewBox.MinX,
					StartY = i * 10,
					EndX = svgDoc.ViewBox.MinX + svgDoc.ViewBox.Width,
					EndY = i * 10,
					Stroke = scs,
					StrokeWidth = 1,
				});
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
