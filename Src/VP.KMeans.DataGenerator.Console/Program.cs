using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VP.KMeans.DataGenerator.Core;

namespace VP.KMeans.DataGenerator.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			ClusterDataGenerator cdg = new ClusterDataGenerator();
			cdg.Start();
			System.Console.WriteLine("File generation completed");
		}
	}
}
