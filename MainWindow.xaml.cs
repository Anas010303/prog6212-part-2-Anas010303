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
using WpfApplication1;


namespace progPoeP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    
    {
        private TimeManagementApplication _timeManagementApplication;

        public MainWindow()
        {
            InitializeComponent();

            _timeManagementApplication = new TimeManagementApplication();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Module  module = new Module();
            module.Code = ModuleCodeTextBox.Text;
            module.Name = ModuleNameTextBox.Text;
            module.NumberOfCredits = int.Parse(ModuleCreditsTextBox.Text);
            module.ClassHoursPerWeek = int.Parse(ModuleClassHoursPerWeekTextBox.Text);

            _timeManagementApplication.Modules.Add(module);

            ModuleListBox.ItemsSource = _timeManagementApplication.Modules;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _timeManagementApplication.NumberOfWeeksInSemester = int.Parse(NumberOfWeeksInSemesterTextBox.Text);
            _timeManagementApplication.StartDateOfSemester = DateTime.Parse(StartDateOfSemesterTextBox.Text);

            _timeManagementApplication.CalculateSelfStudyHours();

            SelfStudyHoursLabel.Content = string.Join("\n", _timeManagementApplication.Modules.Select(module => $"{module.Code}: {module.SelfStudyHoursPerWeek} hours"));
        }
    }

}





