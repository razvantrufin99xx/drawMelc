/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 5/24/2024
 * Time: 10:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace melcDraw
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// T O DO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public Graphics g;
		
		public Pen p = new Pen(Color.FromArgb(255,0,0,0),1);
		public Brush b = new SolidBrush(Color.Black);
		
		public void drawMelcOriginal()
		{
			 int L = 25;
			 int T = 25;
			 float rx = 300;
			 float ry = 300;
			 double rad = 180/Math.PI;
			 
			 double  x = L*(Math.Cos(0/rad))+rx;
			 double  y = T*(Math.Sin(0/rad))+ry;
			 
			 double px = x;
			 double py = y;
			 float iT = 0.0f;
			 float err = 38.0f;
			 float step = err;
			 float cerc =  360.0f;
			 float z = 1/err;
			 for(float i = 0.0f ; i<100*cerc+step; i+=step)
			 {
			 	iT += 1.0f;
			 	
			 	z = (i/err);
			 	x = (z+L)*(Math.Cos(i/rad))+rx+iT-z;
			 	y = (z+T)*(Math.Sin(i/rad))+ry+iT-z;
			 	
			 	g.DrawLine(p,(float)x,(float)y,(float)px,(float)py);
			 	g.DrawEllipse(p,(float)x,(float)y,iT/100,iT/100);
			 	px = x;
			 	py = y;
			 }
			 
		
		}
		
		public void drawMelc()
		{
			 int L = 25;
			 int T = 25;
			 float rx = 300;
			 float ry = 300;
			 
			 float posx = 200;
			 float posy = 200;
			 
			 
			 double rad = 180/Math.PI;
			 
			 double  x = L*(Math.Cos(0/rad))+rx;
			 double  y = T*(Math.Sin(0/rad))+ry;
			 
			 double px = x;
			 double py = y;
			 float iT = 0.0f;
			 float err = 2.0f;
			 float step = err;
			 float cerc =  360.0f;
			 float z = 1/err;
			 float handicap = 1.0f;
			 float counter = 10;
			 float zoom = 0.2500f;
			 for(float i = 0.0f+handicap ; i<counter*cerc+step; i+=step)
			 {
			 	iT += 1.00f;
			 	
			 	z = (i/err);
			 	x = (z+L)*(Math.Cos(i/rad))+rx+iT-z;
			 	y = (z+T)*(Math.Sin(i/rad))+ry+iT-z;
			 	posx += iT-z;
			 	posy += iT-z;
			 	g.DrawLine(p,(float)x*zoom+posx,(float)y*zoom+posy,(float)px*zoom+posx,(float)py*zoom+posy);
			 	g.DrawEllipse(p,(float)x*zoom+posx,(float)y*zoom+posy,iT*zoom,iT*zoom);
			 	px = x;
			 	py = y;
			 }
			 
		
		}
		
		
		void MainFormLoad(object sender, EventArgs e)
		{
			g = this.panel1.CreateGraphics();
		}
		void Button1Click(object sender, EventArgs e)
		{
			drawMelc();
		}
	}
}