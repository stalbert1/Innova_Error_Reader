using Innova_Error_Reader.Classes;
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
using Microsoft.Win32;

namespace Innova_Error_Reader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //This is the list we start with
        List<ErrorCode> errorList;
        //this will be the filtered List
        List<ErrorCode> filteredList;

        //This will be used to determine which txt box to fill when the selected error is chosen.
        int selectedErrorChosen = 0;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnSelectFileToRead_Click(object sender, RoutedEventArgs e)
        {

            //need to import using statement to use OpenFileDialog
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                string filename = dialog.FileName;
                errorList = ErrorParser.getList(filename);
                //This is setting the error list as source.
                errorCodeListView.ItemsSource = errorList;

                //Need to load the filtered list up to match the original
                filteredList = errorList;

                UpdateErrorCount();
            }
            
        }

        private void UpdateErrorCount()
        {
            //display a count of the current errors in filtered list...
            var count = filteredList.Count;

            //get the days between the earliest and latest time dates
            var dayStr = ErrorCode.daysInErrorLog(filteredList);

            lblDisplay.Content = $"{count} errors. {dayStr}";
            lblColumnInfo.Content = ErrorCode.columnsInRows(filteredList);
        }

        //This will eventually go away and will wait until the filter button is pressed before any filtering done.
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ////Probably easier to just name the text box.
            //TextBox message = sender as TextBox;
            ////lblDisplay.Content = message.Text;
            //var searchText = message.Text;

            ////(c => c.errorCode.Contains(searchText)) || && can use or and to further query
            ////filtering the list errorCode where it contains text from the search box.
            ////var filteredList = errorList.Where(c => c.errorCode.Contains(searchText) || c.errorClass == "WR").ToList();
            //var filteredList = errorList.Where(c => c.errorCode.Contains(searchText)).ToList();
            ////changing the listViews item source.
            //errorCodeListView.ItemsSource = filteredList;

            ////display a count of the current errors in filtered list...
            //var count = filteredList.Count;
            //lblDisplay.Content = $"There are {count} errors listed";
        }

        private void btnFilterList_Click(object sender, RoutedEventArgs e)
        {
            var filter1 = txtFilter1.Text;
            var filter2 = txtFilter2.Text;
            var filter3 = txtFilter3.Text;
            var filter4 = txtFilter4.Text;

            filteredList = errorList.Where(c => c.errorCode == filter1 || c.errorCode == filter2 || c.errorCode == filter3 || c.errorCode == filter4).ToList();

            errorCodeListView.ItemsSource = filteredList;

            UpdateErrorCount();

           

        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            txtFilter1.Text = "";
            txtFilter2.Text = "";
            txtFilter3.Text = "";
            txtFilter4.Text = "";
            filteredList = errorList;
            errorCodeListView.ItemsSource = filteredList;
            UpdateErrorCount();
            selectedErrorChosen = 0;
            
        }

        private void btnLoadTestList_Click(object sender, RoutedEventArgs e)
        {
            //Calling the list stored for testing.
            errorList = ErrorParser.getList("error_2019_September_09_202117.csv");

            //This is setting the error list as source.
            errorCodeListView.ItemsSource = errorList;

            //Need to load the filtered list up to match the original
            filteredList = errorList;

            UpdateErrorCount();

        }

        private void errorCodeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Have the list view where you can only select one item at a time in the xaml. Once a item is highlighted this will fire.

            //e has my info, but is of type object

            //BAM, this seems to work. The [0] is because it is the first item selected
            var selectedError = e.AddedItems[0] as ErrorCode;

            var errorCodeStrg = selectedError.errorCode;

            switch (selectedErrorChosen)
            {
                case 0:
                    txtFilter1.Text = errorCodeStrg;
                    break;
                case 1:
                    txtFilter2.Text = errorCodeStrg;
                    break;
                case 2:
                    txtFilter3.Text = errorCodeStrg;
                    break;
                case 3:
                    txtFilter4.Text = errorCodeStrg;
                    break;

                //default:
            }

            //Incrementing so that next time will advance to the next text box.
            selectedErrorChosen = selectedErrorChosen + 1;



        }
    }
}
