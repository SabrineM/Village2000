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

using VillageLogic;

namespace Village2000
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Village Village;
        public MainWindow()
        {
            InitializeComponent();
            Village = new Village();
            var peopleViewer = new PeopleViewer(Village.Villagers);
            Grid.SetColumn(peopleViewer, 1);
            MainGrid.Children.Add(peopleViewer);
        }

        private void PlanActivity_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Window
            {
                Content = new PlanActivity(Village.Villagers)
            };
            dialog.ShowDialog();
            
        }
    }
}
