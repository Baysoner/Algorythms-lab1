﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using PowAlgorythms;

namespace Algorythms
{
    /// <summary>
    /// Логика взаимодействия для PowWindow.xaml
    /// </summary>
    public partial class PowWindow : Window
    {
        public PowWindow()
        {
            InitializeComponent();
        }

        private IPowAlgorithm GetSelectedAlgorithm()
        {
            switch (SelectAlgorythm.SelectedIndex)
            {
                case 0: return new Pow();
                case 1: return new RecPow();
                case 2: return new QuickPow();
                case 3: return new QuickPow1();
            }
            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IPowAlgorithm algorithm = GetSelectedAlgorithm();

            // Создание данных для графика
            var values = PowAlgorythms.Tools.Export(algorithm);

            // Создание графика
            var plotModel = new PlotModel { Title = "Pow" };
            var linearAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Degree",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };
            var linearAxis2 = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Steps",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };

            plotModel.Axes.Add(linearAxis);
            plotModel.Axes.Add(linearAxis2);

            var lineSeries = new LineSeries { ItemsSource = values, MarkerType = MarkerType.Circle, Color = OxyColors.Red, MarkerFill = OxyColors.DarkRed };
            plotModel.Series.Add(lineSeries);

            // Привязка данных к графику
            Plot.Model = plotModel;
        }
    }
}
