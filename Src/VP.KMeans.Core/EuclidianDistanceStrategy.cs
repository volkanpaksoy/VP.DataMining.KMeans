using System;
using System.Collections.Generic;
using System.Text;

namespace VP.KMeans.Core
{
	public class EuclidianDistanceStrategy : DistanceStrategy
	{
		public override double CalculateDistance(ClusterObject obj1, ClusterObject obj2)
		{
			double dDistance = 0;
			double dTemp = 0;
			for (int i = 0; i < obj1.Coordinates.Count; i++)
			{
				dTemp += Math.Pow((obj2.Coordinates[i] - obj1.Coordinates[i]), 2);
			}
			
			dDistance = Math.Sqrt(dTemp);

			return dDistance;
		}
	}
}
