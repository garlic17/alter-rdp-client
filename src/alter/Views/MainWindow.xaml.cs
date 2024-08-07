﻿using System;
using System.ComponentModel;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using AlterApp.ViewModels.Interfaces;
using AlterApp.ViewModels;

namespace AlterApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<MainWindowViewModel>();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (DataContext is IWindowClosing dataContext)
            {
                e.Cancel = dataContext.OnClosing();
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            if (DataContext is IWindowContentRendered dataContext)
            {
                dataContext.OnContentRendered();
            }
        }
    }
}
