using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CS_RFID3_Host_Sample2
{
    public partial class MotoProgressBar : UserControl
    {

        int min = 0;	// Minimum value for progress range
        int max = 100;	// Maximum value for progress range
        int val = 0;	// Current progress

        Color BarColor = Color.Blue;		// Color of progress meter
        
        public MotoProgressBar()
        {
            InitializeComponent();

        }

        protected override void OnResize(EventArgs e)
        {
            // Invalidate the control to get a repaint.
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(BarColor);
 
            // paint bar 
            paintBar(g, brush);

            // Draw a three-dimensional border around the control.
            Draw3DBorder(g);

            // Clean up.
            brush.Dispose();
            g.Dispose();
        }

        public int Minimum
        {
            get
            {
                return min;
            }

            set
            {
                // Prevent a negative value.
                if (value < 0)
                {
                    min = 0;
                }

                // Make sure that the minimum value is never set higher than the maximum value.
                if (value > max)
                {
                    min = value;
                    min = value;
                }

                // Ensure value is still in range
                if (val < min)
                {
                    val = min;
                }

                // Invalidate the control to get a repaint.
                this.Invalidate();
            }
        }

        public int Maximum
        {
            get
            {
                return max;
            }

            set
            {
                // Make sure that the maximum value is never set lower than the minimum value.
                if (value < min)
                {
                    min = value;
                }

                max = value;

                // Make sure that value is still in range.
                if (val > max)
                {
                    val = max;
                }

                // Invalidate the control to get a repaint.
                this.Invalidate();
            }
        }

        public int Value
        {
            get
            {
                return val;
            }

            set
            {
                int oldValue = val;

                // Make sure that the value does not stray outside the valid range.
                if (value < min)
                {
                    val = min;
                }
                else if (value > max)
                {
                    val = max;
                }
                else
                {
                    val = value;
                }
                // Invalidate the intersection region only.
                this.Invalidate();
            }
        }

        public void paintBar(Graphics g, Brush brush)
        {
            int barHeight = 0;
            int barWidth = 0;
            int x = 0;
            int y = this.Height;

            barHeight = (val - min) * this.Height / (max - min);
            barWidth = this.Width;

            g.FillRectangle(brush, x, (y - barHeight), barWidth, barHeight);
        }

        public Color ProgressBarColor
        {
            get
            {
                return BarColor;
            }

            set
            {
                BarColor = value;

                // Invalidate the control to get a repaint.
                this.Invalidate();
                
            }
        }

        private void Draw3DBorder(Graphics g)
        {
 
#if WindowsCE
            Pen pen = new Pen(Color.DarkGray, 1);
            g.DrawLine(pen, this.Width, 0, 0, 0);
            g.DrawLine(pen, 0, 0, 0, this.Height);
            pen = new Pen(Color.White, 1);
            g.DrawLine(pen, 0, this.Height, this.Width, this.Height);
            g.DrawLine(pen, this.Width, this.Height, this.Width, 0);
           
#else
            int PenWidth = (int)Pens.White.Width;

            g.DrawLine(Pens.DarkGray,
                new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),
                new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top));
            g.DrawLine(Pens.DarkGray,
                new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),
                new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth));
            g.DrawLine(Pens.White,
                new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth),
                new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth));
            g.DrawLine(Pens.White,
                new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top),
                new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth));
#endif
        } 
					
    }
}
