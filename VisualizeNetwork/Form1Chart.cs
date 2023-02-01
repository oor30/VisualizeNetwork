using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace VisualizeNetwork
{
	public partial class Form1 : Form
	{
		/// <summary>
		/// グラフを描画
		/// </summary>
		private void DrawChart()
		{
			PrintConsole("グラフを描画");
			int maxRound = 0;
			foreach (Sim sim in scenario.algorithms)
			{
				if (maxRound < sim.LDN) maxRound = sim.LDN;
				if (sim.LDN == 0)
				{
					maxRound = Sim.R;
					break;
				}
			}
			maxRound = ((maxRound / 100) + 1) * 100;

			List<Chart> charts = new List<Chart>
			{
				chartAliveNums,
				chartNumCH,
				chartReceivedData,
				chartTotalEnergyConsumption
			};

			List<string> yTitles = new List<string>
			{
				"Number of nodes alive",
				"Number of CH",
				"Number of received data as BS",
				"Total Energy Consumption of the Network(J)"
			};

			for (int i = 0; i < charts.Count; i++)
			{
				Chart chart = charts[i];
				string yTitle = yTitles[i];
				chart.ChartAreas.Clear();
				chart.Series.Clear();
				ChartArea chartArea = new ChartArea("chartArea");
				chartArea.AxisX.Minimum = 0;
				chartArea.AxisX.Maximum = maxRound;
				chartArea.AxisX.Title = "Number of rounds";
				chartArea.AxisY.Title = yTitle;
				chartArea.AxisX.ScaleView.Size = 1000;
				chartArea.AxisX.IsMarginVisible = false;
				chart.ChartAreas.Add(chartArea);
			}

			foreach (Sim sim in scenario.algorithms)
			{
				List<Series> seriesList = new List<Series>
				{
					CreateNewSeries(sim.AlgoName),
					CreateNewSeries(sim.AlgoName),
					CreateNewSeries(sim.AlgoName),
					CreateNewSeries(sim.AlgoName)
				};

				// 生存ノード数のグラフを描く
				for (int i = 0; i < sim.AliveNumList.Count; i++)
				{
					seriesList[0].Points.AddXY(i, sim.AliveNumList[i]);
					if (i % 50 == 0)
						seriesList[1].Points.AddXY(i, sim.CHNumList[i]);
					seriesList[2].Points.AddXY(i, sim.CollectedDataNumList[i]);
					seriesList[3].Points.AddXY(i, sim.TotalEnergyConsumptionList[i]);
				}
				for (int i = 0; i < charts.Count; i++)
				{
					charts[i].Series.Add(seriesList[i]);
				}
			}


		}

		/// <summary>
		/// Seriesを作成する(DrawChartの補助)
		/// </summary>
		/// <param name="algoName">アルゴリズムの名前</param>
		/// <returns>グラフのSeries</returns>
		private Series CreateNewSeries(string algoName)
		{
			Series series = new Series
			{
				ChartType = SeriesChartType.Line,
				LegendText = algoName
			};
			return series;
		}
	}
}
