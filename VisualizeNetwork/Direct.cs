using System;
using System.Collections.Generic;

using static VisualizeNetwork.EnergyModel;

namespace VisualizeNetwork
{
	[Serializable()]
	internal class Direct : Sim
	{
		public Direct()
		{
			AlgoName = "Direct";
		}

		protected override void OneRound(List<Node> nodes)
		{
			SteadyState(nodes);
		}

		private void SteadyState(List<Node> nodes)
		{
			for (int i = 0; i < nodes.Count; i++)
			{
				if (!nodes[i].IsAlive) continue;
				Node node = nodes[i];
				double energy = CalcEnergyConsumption(node, nodes);
				ConsumeEnergy(energy, ref node);
				nodes[i] = node;
			}
		}
	}
}
