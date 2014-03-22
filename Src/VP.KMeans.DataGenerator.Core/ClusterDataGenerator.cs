using System;
using System.Collections.Generic;
using System.IO;

using System.Text;

namespace VP.KMeans.DataGenerator.Core
{
	public class ClusterDataGenerator
	{
		private int m_nMinLine = 200;
		private int m_nMaxLine = 200;
		private int m_nMinValue = 1;
		private int m_nMaxValue = 200;
		private string m_strOutputPath = @"C:\ClusterData.txt";
		private char m_cSeparatorChar = ' ';
		private int m_nMinValuesPerRecord = 2;
		private int m_nMaxValuesPerRecord = 2;

		public bool Start(string outputPath = null, int minLine = -1, int maxLine = -1, int minValue = -1, int maxValue = -1, char separatorChar = ' ', int minValuesPerRecord = -1, int maxValuesPerRecord = -1)
		{
			if (!String.IsNullOrEmpty(outputPath))
			{
				m_strOutputPath = outputPath;
			}

			if (minLine != -1)
			{
				m_nMinLine = minLine;
			}

			if (maxLine != -1)
			{
				m_nMaxLine = maxLine;
			}

			if (minValue != -1)
			{
				m_nMinValue = minValue;
			}
			
			if (maxValue != -1)
			{
				m_nMaxValue = maxValue;
			}

			if (separatorChar != ' ')
			{
				m_cSeparatorChar = separatorChar;
			}

			if (minValuesPerRecord != -1)
			{
				m_nMinValuesPerRecord = minValuesPerRecord;
			}

			if (maxValuesPerRecord != -1)
			{
				m_nMaxValuesPerRecord = maxValuesPerRecord;
			}

			bool bResult = true;

			int nLineCount = -1;
			
			// Generate random line number if it's not fixed (min and max not same)..
			Random randItemCount;
			if (m_nMinLine != m_nMaxLine)
			{
				randItemCount = new Random((int)System.DateTime.Now.Ticks);
				nLineCount = (randItemCount.Next() % m_nMaxLine) + m_nMinLine;
			}
			else
			{
				nLineCount = m_nMaxLine;
			}

			FileStream fs = new FileStream(m_strOutputPath, FileMode.Create, FileAccess.Write, FileShare.None);
			StreamWriter writer = new StreamWriter(fs);

			int nValueCount = 0;
			Random randValueCount;
			for (int i = 0; i < nLineCount; i++)
			{
				string strLine = String.Empty;

				// Generate numer of items per row..
				if (m_nMinValuesPerRecord == m_nMaxValuesPerRecord)
				{
					nValueCount = m_nMaxValuesPerRecord;
				}
				else
				{
					System.Threading.Thread.Sleep(3);
					randValueCount = new Random((int)System.DateTime.Now.Ticks);
					nValueCount = (randValueCount.Next() % m_nMaxValuesPerRecord) + m_nMinValuesPerRecord;
				}

				int nValue = -1;
				Random randValue;
				for (int j = 0; j < nValueCount; j++)
				{
					randValue = new Random((int)System.DateTime.Now.Ticks);
					nValue = (randValue.Next() % m_nMaxValue) + m_nMinValue;

					strLine += nValue.ToString() + m_cSeparatorChar.ToString();
					
					System.Threading.Thread.Sleep(nValue);
				}
				
				strLine = strLine.TrimEnd(m_cSeparatorChar);
				writer.WriteLine(strLine);
			}

			writer.Flush();
			writer.Close();
			fs.Close();

			return bResult;
		}
	}
}
