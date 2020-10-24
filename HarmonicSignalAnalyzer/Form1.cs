using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HarmonicSignalAnalyzer
{
    public partial class Form1 : Form
    {
        const int Xpadding = 40;
        const int XStep = 20;
        const float YStep = 0.1f;
        int YMiddle;
        const int N = 256;
        const int K = 1;//3 * N / 4;
        const float deltaBasis = 0.707f;
        const int maxAmplitude = 1;

        Bitmap bm;
        readonly Font font = new Font("Arial", 9);
        readonly Brush brush = new SolidBrush(Color.Black);
        const int xRange = 5 * N;
        const int yRange = 2 * maxAmplitude;

        float PixelsInX => (pb_Graphics.Width - Xpadding) / (float)xRange;
        float PixelsInY => pb_Graphics.Height / (float)yRange;

        public Form1()
        {
            InitializeComponent();
        }

        private void DrawDeltaGraphics(PointF[] points, Color color)
        {
            points = (PointF[])points.Clone();
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X = Xpadding + (points[i].X - K) * PixelsInX;
                points[i].Y = YMiddle - points[i].Y * PixelsInY;
            }

            var graphics = Graphics.FromImage(bm);
            DrawDeltaAxis(graphics);

            for (int i = 0; i < points.Length - 1; i++)
            {
                graphics.DrawLine(new Pen(color, 2), points[i], points[i + 1]);
            }

            pb_Graphics.Image = bm;
        }

        private void DrawDeltaAxis(Graphics graphics)
        {
            graphics.DrawLine(Pens.Black, Xpadding, YMiddle, pb_Graphics.Width, YMiddle);
            graphics.DrawLine(Pens.Black, Xpadding, 0, Xpadding, pb_Graphics.Height);

            for (int x = K; x < 5 * N; x += XStep)
            {
                var pixel = (x - K) * PixelsInX + Xpadding;
                graphics.DrawLine(Pens.Black, pixel, YMiddle - 5, pixel, YMiddle + 5);
                graphics.DrawString($"{ x }", font, brush, pixel - 4, YMiddle + 7);
            }

            for (double y = maxAmplitude; y >= -maxAmplitude; y -= YStep)
            {
                graphics.DrawLine(Pens.Black, Xpadding + 5, YMiddle + (int)(y * PixelsInY), Xpadding - 5, YMiddle + (int)(y * PixelsInY));
                graphics.DrawString($"{-1 * y:0.0}", font, brush, Xpadding - 35, YMiddle + (int)(y * PixelsInY) - 8);
            }
        }

        private void CalculateCharacteristics(double fi0)
        {
            List<float> ms = new List<float>();
            int k = K;
            while (k <= 5 * N)
            {
                ms.Add(k);
                k += 1;
            }

            var Xi = new double[5 * N];
            for (int i = 0; i < Xi.Length; i++)
            {
                Xi[i] = Math.Sin(2 * Math.PI * i / N + fi0);
            }

            var rootMeanSquares1 = new float[ms.Count()];
            var rootMeanSquares2 = new float[ms.Count()];
            var amplitudes = new float[ms.Count()];
            var rootMeanSquareDeltas1 = new PointF[ms.Count()];
            var rootMeanSquareDeltas2 = new PointF[ms.Count()];
            var amplitudeDeltas = new PointF[ms.Count()];

            for (int i = 0; i < ms.Count; i++)
            {
                double sumX2 = 0;
                double sumX = 0;
                double reSum = 0;
                double imSum = 0;
                for (int j = 0; j < ms[i]; j++)
                {
                    sumX2 += Math.Pow(Xi[j], 2);
                    sumX += Xi[j];
                    reSum += Xi[j] * Math.Cos(2 * Math.PI * j  / ms[i]);
                    imSum += Xi[j] * Math.Sin(2 * Math.PI * j  / ms[i]);
                }

                rootMeanSquares1[i] = (float)Math.Sqrt(sumX2 / (ms[i] + 1));
                rootMeanSquares2[i] = (float)Math.Sqrt(sumX2 / (ms[i] + 1) - Math.Pow(sumX / (ms[i] + 1), 2));
                amplitudes[i] = (float)Math.Sqrt(Math.Pow(2 / ms[i] * reSum, 2) + Math.Pow(2 / ms[i] * imSum, 2));

                rootMeanSquareDeltas1[i] = new PointF(ms[i], deltaBasis - rootMeanSquares1[i]);
                rootMeanSquareDeltas2[i] = new PointF(ms[i], deltaBasis - rootMeanSquares2[i]);
                amplitudeDeltas[i] = new PointF(ms[i], maxAmplitude - amplitudes[i]);
            }

            bm = new Bitmap(pb_Graphics.Width, pb_Graphics.Height);
            DrawDeltaGraphics(rootMeanSquareDeltas1, Color.Aqua);
            DrawDeltaGraphics(rootMeanSquareDeltas2, Color.Green);
            DrawDeltaGraphics(amplitudeDeltas, Color.Blue);
        }

        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            double FiAngle = double.Parse(tb_FiAngle.Text, CultureInfo.InvariantCulture);
            FiAngle = FiAngle * Math.PI / 180;
            CalculateCharacteristics(FiAngle);
        }

        private void pb_Graphics_Resize(object sender, EventArgs e)
        {
            YMiddle = pb_Graphics.Height / 2;
        }
    }
}
