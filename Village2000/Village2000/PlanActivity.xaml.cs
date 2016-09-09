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
    /// Interaction logic for PlanActivity.xaml
    /// </summary>
    public partial class PlanActivity : UserControl
    {
        /*public ActivityType SelectedActivityType { get; set; }
        public IEnumerable<ActivityType> ActivityTypes
        {
            get
            {
                return Enum.GetValues(typeof(ActivityType)).Cast<ActivityType>();
            }
        }*/

        public PlanActivity(IList<Person> people)
        {
            InitializeComponent();
            this.DataContext = this;
            var peopleView = new PeopleViewer(people);
            peopleView.SelectionMode = SelectionMode.Multiple;
            Grid.SetColumn(PeopleViewGrid, 0);
            PeopleViewGrid.Children.Add(peopleView);

            ActivityTypes.ItemsSource = Enum.GetValues(typeof(ActivityType)).Cast<ActivityType>();
        }

        private void Plan_Click(object sender, RoutedEventArgs e)
        {
            var tem2 = 2;
        }
    }
}
