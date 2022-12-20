using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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

        public virtual void SteadyState(List<Node> nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (!nodes[i].Alive) continue;
                double assignedTime, sendMessageBit, dist, energyTX;
                Node node = nodes[i];

                sendMessageBit = Sim.packetSize;
                dist = Math.Sqrt(Sim.Dist2(BS, node));
                energyTX = Sim.E_TX(sendMessageBit, dist);

                ConsumeEnergy(energyTX, ref node);
                nodes[i] = node;
            }
        }
    }
}
