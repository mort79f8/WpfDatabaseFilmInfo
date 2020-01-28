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
using WpfDatabaseFilmInfo.Biz;
using WpfDatabaseFilmInfo.DataAccess;

namespace WpfDatabaseFilmInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBiz biz = new ClassBiz();        

        public MainWindow()
        {
            InitializeComponent();            
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            biz.MoviesToTextBlock(SearchResultTextBlock,biz.SearchDB(TitelSearchBox, LandSearchBox, YearSearchBox, GenreSearchBox, OscarsSearchBox));
        }
    }
}
