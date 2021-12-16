using CaseStudy.DAL;
using CaseStudy.Models;
using System.Collections.Generic;
using System.Windows;

namespace test
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string strLandcode = txtLandcode.Text;
            if (strLandcode.Length < 2)
            {
                string strMessage = "Gelieve minstens 2 letters in te typen";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBoxImage image = MessageBoxImage.Stop;
                MessageBox.Show(strMessage, "Error", buttons, image);
            }
            Covid covid = new Covid { Code = strLandcode };

            // Database
            CountryRepository countryRepository = new CountryRepository();
            // insert code in database
            countryRepository.InsertCountry(covid);
            // api key
            string userApiKey = "1dfcbc5119msh976e680d3bb9a79p10c5d2jsn7b0d3c163136";
            // api
            ApiRepository apiRepository = new ApiRepository(userApiKey);
            try
            {
                List<Api> list = apiRepository.GetApiByCountries(covid);
                foreach (var word in list)
                {
                    txtInfo.Text = "Country:  " + word.Country + "\n" + "Bevestigde gevallen:  " + word.Confirmed + "\n" +
                         "Kritische gevallen:  " + word.Critical + "\n" + "Doden:  " + word.Deaths + "\n" + "Herstelde gevallen  " + word.Recovered;
                }
            }
            catch
            {
                txtInfo.Text = "Er was een error die iets met de API te maken heeft, probeer het nog eens opnieuw";
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInfo.Text = "";
            txtLandcode.Text = "";
            txtLandcode.Focus();
        }
    }

}
