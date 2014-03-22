using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using System.Text;

namespace VP.KMeans.Core
{
	public class DataLoader
	{
		/// <summary>
		/// Opens the data file and loads cluster objects into memory.
		/// </summary>
		public static Dictionary<int, ClusterObject> LoadData(string filePath)
		{
			Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceInfo, HelperMethods.GenerateLogLine("Loading data..."));

			Dictionary<int, ClusterObject> lstData = new Dictionary<int, ClusterObject>();

			FileStream fs = null;
			StreamReader reader = null;

			try
			{
				fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
				reader = new StreamReader(fs);

				string line = reader.ReadLine();
				int n = 0; // Line number in file. Used to pick random objects.
				while (!String.IsNullOrEmpty(line))
				{
					try
					{
						lstData.Add(n, ClusterObject.Create(line));
					}
					catch (Exception ex)
					{
						Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceError, HelperMethods.GenerateLogLine("Error while creating new object: " + ex.StackTrace));
					}

					line = reader.ReadLine();
					n++;
				}

				Trace.WriteLineIf(SystemDefinitions.ErrSev.TraceInfo, HelperMethods.GenerateLogLine("Data loading completed. Rows loaded: " + lstData.Count.ToString()));
			}
			finally
			{
				reader.Close();
				fs.Close();
			}

			return lstData;
		}

	}
}
