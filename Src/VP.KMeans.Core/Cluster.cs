using System;
using System.Collections.Generic;

using System.Text;

namespace VP.KMeans.Core
{
	public class Cluster
	{
		private int m_nClusterId = -1;
		public int ClusterId
		{
			get { return m_nClusterId; }
			set { m_nClusterId = value; }
		}
		
		private int m_nDimensionCount = 0;
		
		private ClusterObject m_ClusterCentroid = null;
		public ClusterObject ClusterCentroid
		{
			get { return m_ClusterCentroid; }
			set { m_ClusterCentroid = value; }
		}
		
		private ClusterObject m_OldClusterCentroid = null;
		
		private bool m_bCenterMoved = false;
		public bool CenterMoved
		{
			get { return m_bCenterMoved; }
			set { m_bCenterMoved = value; }
		}


		private Dictionary<int, ClusterObject> m_dictObjects = new Dictionary<int, ClusterObject>();

		public void AddObject(int rowId, ClusterObject newObject)
		{
			m_dictObjects.Add(rowId, newObject);
			m_nDimensionCount = newObject.Coordinates.Count;
		}

		public void RemoveObject(int rowId)
		{
			m_dictObjects.Remove(rowId);
		}

		public void UpdateClusterMeans()
		{
			ClusterObject newCentroid = new ClusterObject();
			double[] newCoordinates = new double[m_nDimensionCount];
			
			foreach (KeyValuePair<int, ClusterObject> kvp in m_dictObjects)
			{
				for (int i = 0; i < m_nDimensionCount; i++)
				{
					newCoordinates[i] += kvp.Value.Coordinates[i];
				}
			}

			for (int i = 0; i < m_nDimensionCount; i++)
			{
				newCoordinates[i] /= m_dictObjects.Count;
			}

			newCentroid.Coordinates = new List<double>(newCoordinates);
			
			if (m_OldClusterCentroid == null)
			{
				m_OldClusterCentroid = newCentroid;
			}
			else
			{
				m_OldClusterCentroid = m_ClusterCentroid;
			}
			
			m_ClusterCentroid = newCentroid;
			
			EuclidianDistanceStrategy e = new EuclidianDistanceStrategy();
			double dDistance = e.CalculateDistance(m_OldClusterCentroid, m_ClusterCentroid);
			if (dDistance > 0) //TODO: Set an acceptable margin to determine if the 
							   // center moved or not. To aviod osciallation, small changes 
							   // may be neglected.
			{
				CenterMoved = true;
			}
			else
			{
				CenterMoved = false;
			}
		}
		
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Cluster ID: " + ClusterId.ToString());
			sb.AppendLine("Objects belonging to this cluster: ");
			sb.AppendLine("-----------------------------------");
			foreach (KeyValuePair<int, ClusterObject> kvp in m_dictObjects)
			{
				sb.AppendLine(kvp.Value.ToString());
			}
			sb.AppendLine("-----------------------------------");
			return sb.ToString();
		}
	}
	
}
