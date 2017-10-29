﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Windows.Forms;

namespace TracProg.GUI
{
    /// <summary>
    /// Логика взаимодействия для TestSettings.xaml
    /// </summary>
    public partial class TestSettings : Window
    {
        public TestSettings()
        {
            InitializeComponent();

            _outFilesPath.Click += _outFilesPath_Click;
            _okButton.Click += _okButton_Click;
            _cancelButton.Click += _cancelButton_Click;
        }

        private void _outFilesPath_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            DialogResult result = folderBrowser.ShowDialog();

            if (!string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
            {
                FileOutPath = folderBrowser.SelectedPath;
                _outFilesPathTextBox.Text = FileOutPath;
            }
        }

        private void _okButton_Click(object sender, RoutedEventArgs e)
        {
            int width;
            if (!int.TryParse(_gridWidth.Text, out width))
            {
                System.Windows.MessageBox.Show("Значение ширины сетки имеет неверный формат.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            int height;
            if (!int.TryParse(_gridHeight.Text, out height))
            {
                System.Windows.MessageBox.Show("Значение высоты сетки имеет неверный формат.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void _cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }


        /// <summary>
        /// Ширина сетки
        /// </summary>
        public int M { get; private set; }

        /// <summary>
        /// Высота сетки
        /// </summary>
        public int N { get; private set; }

        /// <summary>
        /// Количество элементов
        /// </summary>
        public int CountPins { get; private set; }

        /// <summary>
        /// Количество зон запрета
        /// </summary>
        public int CountProhibitionZones { get; private set; }

        /// <summary>
        /// Количество элементов в трассе
        /// </summary>
        public int CountPinsInNet { get; private set; }

        /// <summary>
        /// Абсолютный путь до каталога с выходными файлами эксперимента
        /// </summary>
        public string FileOutPath { get; private set; }

        /// <summary>
        /// Тип алгоритма
        /// </summary>
        public TypeOfAlgorithm TypeOfAlgorithm { get; private set; }

        /// <summary>
        /// Количество запусков
        /// </summary>
        public int CountRuns { get; private set; }
    }
}
