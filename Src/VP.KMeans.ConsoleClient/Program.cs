using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
using System.Text;

using VP.KMeans.Core;


namespace VP.KMeansClient
{
	class Program
	{
		private static string filePath = null;

		static void Main(string[] args)
		{
			Console.WriteLine("--------------------------------------");
			Console.WriteLine(" Data Mining Assignment 3             ");
			Console.WriteLine(" K-Means Algorithm implementation     ");
			Console.WriteLine(" by Volkan Paksoy                     ");
			Console.WriteLine("--------------------------------------");
			
			///////////////////////////////////////////////////////////////
			// Get required parameters from the user: Number of clusters (k) 
			// and the path for the database file
			Console.Write("Enter the number of clusters:  ");
			string strK = Console.ReadLine();
			int k = -1;
			bool bKEntered = Int32.TryParse(strK, out k);
			if (!bKEntered || k < 0)
			{
				Console.WriteLine("Invalid k value");
				return;
			}

			Console.Write("Enter path for database : ");
			filePath = Console.ReadLine();
			if (!File.Exists(filePath))
			{
				Console.WriteLine("File does not exist");
				return;
			}
			///////////////////////////////////////////////////////////////

			KMeansAlgorithm kmeans = new KMeansAlgorithm();
			kmeans.K = k;
			kmeans.FilePath = filePath;
			kmeans.Run();
			
			Console.WriteLine("K-Means clustering completed.");
			Console.WriteLine();
			Console.WriteLine("Clustering output : ");
			Console.WriteLine("----------------------");
			Console.WriteLine(kmeans.GetOutput());
			
			Console.ReadLine();
		}
	}
}
