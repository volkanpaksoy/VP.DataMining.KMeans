using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using CPI.Plot3D;
using VP.KMeans.Core;

namespace VP.KMeansClient.GUI
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		
		public void DrawSquare(Plotter3D p, float sideLength)
		{
			for (int i = 0; i < 4; i++)
			{
				p.Forward(sideLength);  // Draw a line sideLength long
				p.TurnRight(90);        // Turn right 90 degrees
			}
		}

		public void DrawSquare(Plotter3D p, float sideLength, int clusterId)
		{
			SetColor(p, clusterId);
			DrawSquare(p, sideLength);
		}

		public void DrawCube(Plotter3D p, float sideLength)
		{
			for (int i = 0; i < 4; i++)
			{
				DrawSquare(p, sideLength);
				p.Forward(sideLength);
				p.TurnDown(90);
			}
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			string filePath = txtFilePath.Text;
			Dictionary<int, ClusterObject> m_lstData = DataLoader.LoadData(filePath);

			using (Graphics g = pnlGraph.CreateGraphics())
			using (CPI.Plot3D.Plotter3D p = new CPI.Plot3D.Plotter3D(g))
			{
				g.Clear(this.BackColor);
			//	p.Location = new CPI.Plot3D.Point3D(0, 0, 0);
			//	DrawSquare(p, 400);

				foreach (KeyValuePair<int, ClusterObject> kvp in m_lstData)
				{
					p.Location = new CPI.Plot3D.Point3D((int)kvp.Value.Coordinates[0], (int)kvp.Value.Coordinates[1], 0);
					DrawSquare(p, 1, 1000); // 1000: To get black. Any number greater than 12 will do...
				}
			}
		}
		
		private void btnRunKMeans1_Click(object sender, EventArgs e)
		{
			string filePath = txtFilePath.Text;
			Dictionary<int, ClusterObject> m_lstData = DataLoader.LoadData(filePath);

			KMeansAlgorithm kmeans = new KMeansAlgorithm();
			kmeans.K = Int32.Parse(txtClusterCount.Text);
			kmeans.FilePath = filePath;
			kmeans.Run();

			using (Graphics g = pnlGraph.CreateGraphics())
			using (CPI.Plot3D.Plotter3D p = new CPI.Plot3D.Plotter3D(g))
			{
				g.Clear(this.BackColor);
				
				foreach (KeyValuePair<int, ClusterObject> kvp in kmeans.ClusteredData)
				{
					p.Location = new CPI.Plot3D.Point3D((int)kvp.Value.Coordinates[0], (int)kvp.Value.Coordinates[1], 0);
					DrawSquare(p, 1, kvp.Value.ClusterId);
				}
			}
		}
		
		private void SetColor(Plotter3D p, int clusterId)
		{
			switch (clusterId)
			{
				case 0 :  p.Pen = new Pen(Color.Blue); break;
				case 1 :  p.Pen = new Pen(Color.Red); break;
				case 2 :  p.Pen = new Pen(Color.Green); break;
				case 3 :  p.Pen = new Pen(Color.Yellow); break;
				case 4 :  p.Pen = new Pen(Color.White); break;
				case 5 :  p.Pen = new Pen(Color.Brown); break;
				case 6 :  p.Pen = new Pen(Color.BurlyWood); break;
				case 7 :  p.Pen = new Pen(Color.LawnGreen); break;
				case 8 :  p.Pen = new Pen(Color.LightSalmon); break;
				case 9:  p.Pen = new Pen(Color.Magenta); break;
				case 10:  p.Pen = new Pen(Color.MediumTurquoise); break;
				case 11:  p.Pen = new Pen(Color.PapayaWhip); break;
				case 12: p.Pen = new Pen(Color.AliceBlue); break;
				default:  p.Pen = new Pen(Color.Black); break;
			}
		}

		private void btBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			DialogResult result = ofd.ShowDialog();
			if (result == DialogResult.OK)
			{
				txtFilePath.Text = ofd.FileName;
			}
		}
	}
}
