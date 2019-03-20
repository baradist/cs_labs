using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace lab3
{
    enum eLineType { None, Curved, Filled, Polygone, Bezier };

    public enum MoveType { None, Ordered, Hchaotic };

    public partial class Form1 : Form
    {
        FormParams formParams = new lab3.FormParams();
        bool bAddPoints = false;
        public MoveType bMooveType { set; get; } = MoveType.None;
        eLineType lineType = eLineType.None;

        List<Point> arPoints;
        List<Point> speedList;
        Point orderedSpeed = new Point(2, 5);
        Timer moveTimer = new Timer();

        bool bDragging = false;
        int draggingPointIndex = -1;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            arPoints = new List<Point>();
            speedList = new List<Point>();

            this.buttonDots.Click += (sender, e) => bAddPoints = !bAddPoints;
            this.buttonParams.Click += (sender, e) => formParams.ShowDialog(this);
            this.buttonClear.Click += ClearDots;
            this.buttonCurved.Click += (sender, e) => { lineType = eLineType.Curved; Refresh(); };
            this.buttonPolygone.Click += (sender, e) => { lineType = eLineType.Polygone; Refresh(); };
            this.buttonFilled.Click += (sender, e) => { lineType = eLineType.Filled; Refresh(); };
            this.buttonBezier.Click += (sender, e) => { lineType = eLineType.Bezier; Refresh(); };
            this.buttonMove.Click += buttonMove_Click;
            Paint += Form1_Paint;
            MouseClick += Form1_MouseClick;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            moveTimer.Interval = 30;
            moveTimer.Tick += TimerTickHandler;
        }

        private void ClearDots(object sender, EventArgs e)
        {
            bMooveType = MoveType.None;
            MoveTypeChanged();
            arPoints.Clear();
            Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (bAddPoints)
            {
                return;
            }
            int radius = Decimal.ToInt32(formParams.DotRadius.Value);
            for (int i = 0; i < arPoints.Count(); i++)
            {
                if ((arPoints[i].X - e.X) * (arPoints[i].X - e.X)
                    + (arPoints[i].Y - e.Y) * (arPoints[i].Y - e.Y)
                    <= radius * radius)
                {
                    draggingPointIndex = i;
                    bDragging = true;
                    continue;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bDragging)
            {
                arPoints[draggingPointIndex] = e.Location;
                Refresh();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            bDragging = false;
            draggingPointIndex = -1;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                Accelerate(new Point(0, -1));
                return true;
            }
            else if (keyData == Keys.Down)
            {
                Accelerate(new Point(0, 1));
                return true;
            }
            else if (keyData == Keys.Left)
            {
                Accelerate(new Point(-1, 0));
                return true;
            }
            else if (keyData == Keys.Right)
            {
                Accelerate(new Point(1, 0));
                return true;
            }
            else if (keyData == Keys.Space)
            {
                buttonMove_Click(null, null);
                return true;
            }
            else if (keyData == Keys.Add)
            {
                Accelerate(1);
                return true;
            }
            else if (keyData == Keys.Subtract)
            {
                Accelerate(-1);
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                ClearDots(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Accelerate(int acceleration)
        {
            int speedLimit = Decimal.ToInt32(formParams.Speed.Value);
            orderedSpeed = GetNewSpeed(orderedSpeed, acceleration, speedLimit);
            for (int i = 0; i < speedList.Count(); i++)
            {
                speedList[i] = GetNewSpeed(speedList[i], acceleration, speedLimit);
            }
        }

        private void Accelerate(Point acceleration)
        {
            int speedLimit = Decimal.ToInt32(formParams.Speed.Value);
            switch (bMooveType)
            {
                case MoveType.None:
                    for (int i = 0; i < arPoints.Count(); i++)
                    {
                        int newX = arPoints[i].X + acceleration.X;
                        if (newX < 0 || newX > Width)
                        {
                            newX -= acceleration.X;
                        }
                        int newY = arPoints[i].Y + acceleration.Y;
                        if (newY < 0 || newY > Height)
                        {
                            newY -= acceleration.Y;
                        }
                        arPoints[i] = new Point(newX, newY);
                    }
                    Refresh();
                    break;
                case MoveType.Ordered:
                    orderedSpeed = GetNewSpeed(orderedSpeed, acceleration.X, acceleration.Y, speedLimit);
                    for (int i = 0; i < speedList.Count(); i++)
                    {
                        speedList[i] = GetNewSpeed(speedList[i], acceleration.X, acceleration.Y, speedLimit);
                    }
                    break;
                case MoveType.Hchaotic:
                    for (int i = 0; i < speedList.Count(); i++)
                    {
                        speedList[i] = GetNewSpeed(speedList[i], acceleration.X, acceleration.Y, speedLimit);
                    }
                    break;
            }
        }

        private Point GetNewSpeed(Point currentSpeed, int accelerationX, int accelerationY, int speedLimit)
        {
            int x = currentSpeed.X + accelerationX;
            x = x < -speedLimit ? -speedLimit : (x > speedLimit ? speedLimit : x);
            int y = currentSpeed.Y + accelerationY;
            y = y < -speedLimit ? -speedLimit : (y > speedLimit ? speedLimit : y);
            return new Point(x, y);
        }

        private Point GetNewSpeed(Point currentSpeed, int acceleration, int speedLimit)
        {
            int x = currentSpeed.X < 0 ? currentSpeed.X - acceleration : (currentSpeed.X > 0 ? currentSpeed.X + acceleration : acceleration > 0 ? acceleration : 0);
            x = x < -speedLimit ? -speedLimit : (x > speedLimit ? speedLimit : x);
            int y = currentSpeed.Y < 0 ? currentSpeed.Y - acceleration : (currentSpeed.Y > 0 ? currentSpeed.Y + acceleration : acceleration > 0 ? acceleration : 0);
            y = y < -speedLimit ? -speedLimit : (y > speedLimit ? speedLimit : y);
            return new Point(x, y);
        }

        private void TimerTickHandler(object sender, EventArgs e)
        {
            Point curPoint;
            Point curSpeed;
            for (int i = 0; i < arPoints.Count(); i++)
            {
                curPoint = arPoints[i];
                curSpeed = speedList[i];
                if (curPoint.X > this.Width || curPoint.X < 0)
                {
                    curSpeed = new Point(-curSpeed.X, curSpeed.Y);
                    speedList[i] = curSpeed;
                }
                if (curPoint.Y > this.Height || curPoint.Y < 0)
                {
                    curSpeed = new Point(curSpeed.X, -curSpeed.Y);
                    speedList[i] = curSpeed;
                }

                arPoints[i] = new Point(curPoint.X + curSpeed.X, curPoint.Y + curSpeed.Y);
            }
            Refresh();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (bAddPoints)
            {
                arPoints.Add(e.Location);
                if (bMooveType == MoveType.Ordered)
                {
                    speedList.Add(orderedSpeed);
                }
                else if (bMooveType == MoveType.Hchaotic)
                {
                    Random random = new Random();
                    int speed = Decimal.ToInt32(formParams.Speed.Value);
                    speedList.Add(new Point(random.Next(0, speed), random.Next(0, speed)));
                }
                else
                {
                    speedList.Add(new Point());
                }
                Refresh();
            }
        }

        // Обработчик события Paint
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (arPoints.Count > 0)
            {
                if (lineType == eLineType.Curved)
                {
                    g.FillClosedCurve(formParams.lineBrush, arPoints.ToArray());
                }
                else if (lineType == eLineType.Polygone)
                {
                    if (arPoints.Count() > 1)
                    {
                        int width = Decimal.ToInt32(formParams.LineWidth.Value);
                        g.DrawPolygon(new Pen(formParams.lineBrush, width), arPoints.ToArray());
                    }
                }
                else if (lineType == eLineType.Filled)
                {
                    g.FillPolygon(formParams.lineBrush, arPoints.ToArray());
                }
                else if (lineType == eLineType.Bezier)
                {
                    if ((arPoints.Count - 1) % 3 == 0)
                    {
                        int width = Decimal.ToInt32(formParams.LineWidth.Value);
                        g.DrawBeziers(new Pen(formParams.lineBrush, width), arPoints.ToArray());
                    }
                }
            }
            foreach (var p in arPoints)
            {
                int radius = Decimal.ToInt32(formParams.DotRadius.Value);
                g.FillEllipse(formParams.dotBrush, p.X - radius, p.Y - radius, radius * 2, radius * 2);
            }
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            bMooveType = (MoveType)(((int)bMooveType + 1) % 3);
            MoveTypeChanged();
        }

        public void MoveTypeChanged()
        {
            buttonMove.Text = "" + bMooveType;
            switch (bMooveType)
            {
                case MoveType.None:
                    moveTimer.Stop();
                    break;
                case MoveType.Ordered:
                    SetOrderedSpeed();
                    moveTimer.Start();
                    break;
                case MoveType.Hchaotic:
                    SetRandomSpeed();
                    moveTimer.Start();
                    break;
            }
        }

        private void SetOrderedSpeed()
        {
            for (int i = 0; i < speedList.Count(); i++)
            {
                speedList[i] = orderedSpeed;
            }
        }

        private void SetRandomSpeed()
        {
            Random random = new Random();
            int speed = Decimal.ToInt32(formParams.Speed.Value);
            for (int i = 0; i < speedList.Count(); i++)
            {
                speedList[i] = new Point(random.Next(0, speed), random.Next(0, speed));
            }
        }
    }
}
