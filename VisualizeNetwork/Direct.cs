using System.Collections.Generic;

namespace VisualizeNetwork
{
    internal class Direct : Sim
    {
        public Direct()
        {
            AlgoName = "Direct";
        }
        protected override List<Node> OneRound(List<Node> nodes)
        {
            SteadyState(nodes);
            return nodes;
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
