using System;
using System.Collections.Generic;
using System.Text;

namespace VP.KMeans.Core
{
	abstract public class DistanceStrategy
	{
		abstract public double CalculateDistance(ClusterObject obj1, ClusterObject obj2);
	}
}
