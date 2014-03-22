using System;
using System.Collections;
using System.Collections.Generic;

using System.Text;

namespace VP.KMeans.Core
{
	public class ClusterObject
	{
		private List<double> m_lstCoordinates = new List<double>();
		public List<double> Coordinates
		{
			get { return m_lstCoordinates; }
			set { m_lstCoordinates = value; }
		}

		private int m_nClusterId = -1;
		public int ClusterId
		{
			get { return m_nClusterId; }
			set { m_nClusterId = value; }
		}
		
				
		public static ClusterObject Create(string rawData)
		{
			ClusterObject newClusterObject = new ClusterObject();
			string[] coordList = rawData.Split(" ".ToCharArray());
			foreach (string coord in coordList)
			{
				newClusterObject.Coordinates.Add(Double.Parse(coord));
			}
			return newClusterObject;
		}

		
		public static double CalculateDistance(ClusterObject object1, ClusterObject object2)
		{
			EuclidianDistanceStrategy distance = new EuclidianDistanceStrategy();
			return distance.CalculateDistance(object1, object2);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (double d in Coordinates)
			{
				sb.Append(d.ToString() + " ");
			}

			return sb.ToString(); ;
		}
	}

}
