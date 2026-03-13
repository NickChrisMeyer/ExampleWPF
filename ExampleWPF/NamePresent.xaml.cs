using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExampleWPF
{
    /// <summary>
    /// Interaction logic for NamePresent.xaml
    /// </summary>
    public partial class NamePresent : Window
    {
        public NamePresent()
        {
            InitializeComponent();
        }

        public NamePresent(List<string> names)
        {
            InitializeComponent();
            lstReceivedNames.ItemsSource = names;
        }

        private Polyline? currentStroke;
        private bool isDrawing;

        private void DrawCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDrawing = true;
            DrawCanvas.CaptureMouse();

            Point startPoint = e.GetPosition(DrawCanvas);
            currentStroke = new Polyline
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                StrokeLineJoin = PenLineJoin.Round,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round
            };

            currentStroke.Points.Add(startPoint);
            DrawCanvas.Children.Add(currentStroke);
        }

        private void DrawCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing || currentStroke is null)
            {
                return;
            }

            Point currentPoint = e.GetPosition(DrawCanvas);
            currentStroke.Points.Add(currentPoint);
        }

        private void DrawCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDrawing = false;
            DrawCanvas.ReleaseMouseCapture();
            currentStroke = null;
        }
    }
}
