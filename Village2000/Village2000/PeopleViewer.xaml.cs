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
    /// Interaction logic for PeopleViewer.xaml
    /// </summary>
    public partial class PeopleViewer : UserControl
    {
        public IList<Person> People {
            set
            {
                if (PeopleList != null)
                {
                    PeopleList.ItemsSource = value;
                }
            }
        }

        public SelectionMode SelectionMode
        {
            set
            {
                if (PeopleList != null)
                {
                    PeopleList.SelectionMode = value;
                }
            }
        }

        public PeopleViewer(){ }

        public PeopleViewer(IList<Person> people)
        {
            InitializeComponent();

            People = people;
        }

        private void PeopleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = PeopleList.SelectedItems;
            var temp2 = 2;
        }
    }
}
