﻿using DuszaTKVGameLib;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DuszaWpfApp
{
    /// <summary>
    /// Interaction logic for BetCard.xaml
    /// </summary>
    public partial class BetCard : UserControl
    {
        public BetCard(Game game)
        {
            InitializeComponent();
            Header.Text = game.Name;
            
            Body.Text += "Subjects:";
            foreach (string subject in game.Subjects)
            {
                Body.Text+=$"\n\t{subject}";
            }

            Body.Text += "\nEvents:";
            foreach (string _event in game.Events.Select(x => x.Name).Distinct())
            {
                Body.Text += $"\n\t{_event}";
            }
        }
    }
}