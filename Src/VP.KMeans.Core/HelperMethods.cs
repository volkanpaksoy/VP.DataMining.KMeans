using System;
using System.Collections.Generic;
using System.Text;

namespace VP.KMeans.Core
{
	public class HelperMethods
	{
		public static string GenerateLogLine(string message)
		{
			return String.Format("{0}\t\t\t{1}", System.DateTime.Now.ToString(), message);
		}
	}
}
