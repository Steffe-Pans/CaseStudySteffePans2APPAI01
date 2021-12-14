using CaseStudy.DAL;
using CaseStudy.Models;
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

namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string strLandcode = txtLandcode.Text;
            Covid covid = new Covid { Code = strLandcode };
            // Database
            CountryRepository countryRepository = new CountryRepository();
            // insert code in database
            countryRepository.InsertCountry(covid);
            // api key
            string userApiKey = "1dfcbc5119msh976e680d3bb9a79p10c5d2jsn7b0d3c163136";
            // api
            ApiRepository apiRepository = new ApiRepository(userApiKey);
            List<Api> list = apiRepository.GetApiByCountries(covid);
          foreach (var word in list)
           {
               txtInfo.Text =  "Country:  " + word.Country  + "\n" + "Bevestigde gevallen:  " + word.Confirmed + "\n" +
                    "Kritische gevallen:  " + word.Critical + "\n" + "Doden:  " + word.Deaths + "\n" + "Herstelde gevallen  " + word.Recovered;
             }

        }
    }
}
