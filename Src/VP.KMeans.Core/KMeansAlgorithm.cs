using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace VP.KMeans.Core
{
	public class KMeansAlgorithm
	{
		public int K { get; set; }
		private Cluster[] clusters = null;
		public string FilePath { get; set; }

		private Dictionary<int, ClusterObject> m_lstData = new Dictionary<int, ClusterObject>();
		public Dictionary<int, ClusterObject> ClusteredData
		{
			get { return m_lstData; }
		}
		

		private List<int> m_lstInitialCentroidIdList = new List<int>(); // List to keep track of chosen initial centroids.
																		// It is used to prevent selecting the same object more than once
		
		public void Run()
		{
			Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceInfo, HelperMethods.GenerateLogLine("********************************************"));
			Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceInfo, HelperMethods.GenerateLogLine("K-Means started"));
			
			clusters = new Cluster[K];
			
			// Load data into memory.
			m_lstData = VP.KMeans.Core.DataLoader.LoadData(FilePath);

			if (m_lstData.Count == 0)
			{
				Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceInfo, HelperMethods.GenerateLogLine("No data loaded. Exiting..."));
				return;
			}

			// 01. Generate random numbers to pick initial cluster means.
			Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceVerbose, HelperMethods.GenerateLogLine("Determining initial cluster centers."));
			int nCentroidCount = 0;
			do
			{
				Random randItemNumber = new Random((int)System.DateTime.Now.Ticks);
				int nLineNumber = (randItemNumber.Next() % m_lstData.Count);
				
				if (!m_lstInitialCentroidIdList.Contains(nLineNumber))
				{
					clusters[nCentroidCount] = new Cluster();
					clusters[nCentroidCount].ClusterId = nCentroidCount;
					clusters[nCentroidCount].AddObject(nLineNumber, m_lstData[nLineNumber]);
					m_lstData[nLineNumber].ClusterId = nCentroidCount;
					
					clusters[nCentroidCount].UpdateClusterMeans();
					
					m_lstInitialCentroidIdList.Add(nLineNumber);
					
					nCentroidCount++;

					Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceVerbose, HelperMethods.GenerateLogLine("Cluster ID: " + m_lstData[nLineNumber].ClusterId.ToString() + ", Object: " + m_lstData[nLineNumber].ToString()));
				}
				
				System.Threading.Thread.Sleep(3);
			}
			while (nCentroidCount < K);
			
			bool bChangeDetected;
			int nCycle = 1;
			do
			{
				Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceVerbose, HelperMethods.GenerateLogLine("-------------------------------------------"));
				Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceVerbose, HelperMethods.GenerateLogLine("Assigning objects to clusters. Cycle: " + nCycle.ToString()));

				bChangeDetected = false;

				// 02. Assign each object to the closest cluster
				foreach (KeyValuePair<int, ClusterObject> kvp in m_lstData)
				{
					if (!m_lstInitialCentroidIdList.Contains(kvp.Key)) // Skip initial centroids.
					{
						Cluster c = FindClosestCluster(kvp.Value);
						// If the current cluster is the same as the new one, skip.
						// If not, assign the object to its new cluster and modify its
						// cluster ID, and remove it from its old cluster if it assigned to any..
						Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceVerbose, HelperMethods.GenerateLogLine(String.Format("Current cluster : [{0}], Closest cluster : [{1}]", kvp.Value.ClusterId, c.ClusterId)));
						
						if (c.ClusterId != kvp.Value.ClusterId)
						{
							// Assign the object to its cluster
							c.AddObject(kvp.Key, kvp.Value);
							c.UpdateClusterMeans();

							// If it is assigned to a cluster, remove it 
							if (kvp.Value.ClusterId >= 0)
							{
								clusters[kvp.Value.ClusterId].RemoveObject(kvp.Key);
								clusters[kvp.Value.ClusterId].UpdateClusterMeans();
							}
							
							// Update object's cluster ID.
							kvp.Value.ClusterId = c.ClusterId;

							bChangeDetected = c.CenterMoved;
						}
					}
					else
					{
						m_lstInitialCentroidIdList.Remove(kvp.Key);
					}
				}

				nCycle++;
			}
			while (bChangeDetected);
			Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceVerbose, HelperMethods.GenerateLogLine("-------------------------------------------"));

			Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceInfo, HelperMethods.GenerateLogLine("Clustering Output: "));
			Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceInfo, HelperMethods.GenerateLogLine("-------------------------------------------"));
			Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceInfo, HelperMethods.GenerateLogLine(GetOutput()));

			
			Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceInfo, HelperMethods.GenerateLogLine("K-Means completed"));
			Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceInfo, HelperMethods.GenerateLogLine("********************************************"));
		}

		private Cluster FindClosestCluster(ClusterObject clusterObject)
		{
			Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceVerbose, HelperMethods.GenerateLogLine("Find closest cluster to object : " + clusterObject.ToString()));
			
			double[] distances = new double[K];
			Cluster closestCluster = null;
			for (int i = 0; i < clusters.Length; i++)
			{
				distances[i] = ClusterObject.CalculateDistance(clusterObject, clusters[i].ClusterCentroid);
				Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceVerbose, HelperMethods.GenerateLogLine(String.Format("Distance for cluster [{0}] = {1}", i, distances[i])));
			}
			
			int nSmallestDistanceIndex = 0;
			double dSmallestDistance = Double.MaxValue;
			for (int i = 0; i < distances.Length; i++)
			{
				if (distances[i] < dSmallestDistance)
				{
					dSmallestDistance = distances[i];
					nSmallestDistanceIndex = i;
				}
			}
			
			closestCluster = clusters[nSmallestDistanceIndex];
			Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceVerbose, HelperMethods.GenerateLogLine(String.Format("Closest cluster : [{0}] ", nSmallestDistanceIndex)));
			return closestCluster;
		}

		public string GetOutput()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("Number of clusters :" + K.ToString());
			
			foreach (Cluster c in clusters)
			{
				sb.AppendLine(c.ToString());
			}
			return sb.ToString();
		}
	}
}
