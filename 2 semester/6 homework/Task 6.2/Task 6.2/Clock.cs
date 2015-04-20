using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_6._2
{
    /// <summary>
    /// Класс для аналоговых часов
    /// </summary>
    public partial class Clock : Form
    {
        public Clock()
        {
            InitializeComponent();
            timer1.Start();
        }

        private int width = 300;
        private int height = 300;

        // Координаты центра
        private int centerX;
        private int centerY;

        private Bitmap bitmap;

        private void Form1Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(width, height);
            centerX = width / 2;
            centerY = height / 2;
            this.BackColor = Color.LightCyan;
        }

        // Определяет координаты концов секундной и минутной стрелок
        private int[] CoordinatesForMinuteAndSecondHands(int value, int handLength)
        {
            int[] coordinates = new int[2];

            // Каждую секунду секундная стрелка поворачивается на 6 градусов
            // Также каждую минуту минутная стрелка поворачивается на 6 градусов
            value *= 6;
            coordinates[0] = centerX + (int)(handLength * Math.Sin(Math.PI * value / 180));
            coordinates[1] = centerY - (int)(handLength * Math.Cos(Math.PI * value / 180));
            return coordinates;
        }

        /// <summary>
        /// Определяет координаты конца часовой стрелки
        /// </summary>
        private int[] CoordinatesForHourHand(int hourValue, int minuteValue, int handLength)
        {
            int[] coordinates = new int[2];

            // Каждый час стрелка передвигается на 30 градусов
            // Каждую минуту на 0,5 градуса
            int value = (int)((hourValue * 30) + (minuteValue * 0.5));
            coordinates[0] = centerX + (int)(handLength * Math.Sin(Math.PI * value / 180));
            coordinates[1] = centerY - (int)(handLength * Math.Cos(Math.PI * value / 180));
            return coordinates;
        }

        /// <summary>
        /// Помещает начало координат в центр формы и масштабирует изображение в соответствии с его размерами
        /// </summary>
        private void InitializeTransform(Graphics graph)
        {
            graph.ResetTransform();
            graph.TranslateTransform(centerX, centerY);
            float scale = System.Math.Min(width, height) / 213.0f;
            graph.ScaleTransform(scale, scale);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            var graph = Graphics.FromImage(bitmap);
            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int hh = DateTime.Now.Hour;

            graph.Clear(Color.LightCyan); // Очищаем всю поверхность рисования, чтобы не оставались стрелки на своих предыдущих позициях
            graph.DrawEllipse(new Pen(Color.DarkBlue, 15f), 10, 10, width - 20, height - 20);
            graph.DrawEllipse(new Pen(Color.DeepSkyBlue, 5f), 16, 16, width - 32, height - 32);

            graph.DrawString("1", new Font("Arlekino", 28), Brushes.Black, new PointF(190, 42));
            graph.DrawString("2", new Font("Arlekino", 28), Brushes.Black, new PointF(217, 77));
            graph.DrawString("3", new Font("Arlekino", 28), Brushes.Black, new PointF(234, 131));
            graph.DrawString("4", new Font("Arlekino", 28), Brushes.Black, new PointF(216, 177));
            graph.DrawString("5", new Font("Arlekino", 28), Brushes.Black, new PointF(180, 212));
            graph.DrawString("6", new Font("Arlekino", 28), Brushes.Black, new PointF(129, 223));
            graph.DrawString("7", new Font("Arlekino", 28), Brushes.Black, new PointF(85, 207));
            graph.DrawString("8", new Font("Arlekino", 28), Brushes.Black, new PointF(48, 179));
            graph.DrawString("9", new Font("Arlekino", 26), Brushes.Black, new PointF(29, 125)); // размер 26, т.к. 9 выглядит намного больше всех остальных цифр
            graph.DrawString("10", new Font("Arlekino", 28), Brushes.Black, new PointF(46, 77));
            graph.DrawString("11", new Font("Arlekino", 28), Brushes.Black, new PointF(83, 42));
            graph.DrawString("12", new Font("Arlekino", 28), Brushes.Black, new PointF(126, 28));

            int[] handCoordinates = new int[2];
            
            // Рисуем секундную стрелку
            int lengthOfSecondHand = 125;
            handCoordinates = CoordinatesForMinuteAndSecondHands(ss, lengthOfSecondHand);
            graph.DrawLine(new Pen(Color.Red, 1f), new Point(centerX, centerY), new Point(handCoordinates[0], handCoordinates[1]));
            
            // Рисуем минутную стрелку
            int lengthOfMinuteHand = 110;
            handCoordinates = CoordinatesForMinuteAndSecondHands(mm, lengthOfMinuteHand);
            graph.DrawLine(new Pen(Color.Blue, 4f), new Point(centerX, centerY), new Point(handCoordinates[0], handCoordinates[1]));
            
            // Рисуем часовую стрелку
            int lengthOfHourHand = 75;
            handCoordinates = CoordinatesForHourHand(hh % 12, mm, lengthOfHourHand);
            graph.DrawLine(new Pen(Color.Black, 6f), new Point(centerX, centerY), new Point(handCoordinates[0], handCoordinates[1]));

            InitializeTransform(graph);
            
            // Сдвигаем объект по часовой стрелке, чтобы деления стояли ровно там, где нужно
            // Если не сдвинуть, то они будут стоять немного неправильно, и секундная стрелка будет каждую секунду указывать не на одно из них, а между ними
            graph.RotateTransform(3.0f);

            for (int i = 0; i < 60; i++)
            {
                if (i % 5 == 0)
                {
                    graph.FillRectangle(Brushes.DarkCyan, 85, -6, 6, 3);
                    graph.RotateTransform(6);
                }
                else
                {
                    graph.FillRectangle(Brushes.DarkCyan, 85, -5, 6, 1);
                    graph.RotateTransform(6);
                }
            }

            pictureBox1.Image = bitmap;
            this.Text = "Clock  -  " + DateTimeOffset.Now.ToString();
        }
    }
}
