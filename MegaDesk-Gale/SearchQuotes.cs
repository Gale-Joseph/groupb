using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;


namespace MegaDesk_Gale
{
    public partial class SearchQuotes : Form
    {

        public List<DeskQuote> AllQuotes;
        
        public SearchQuotes()
        {
            // start with all of the existing quotes (from quotes.json file)
            //List<string> AllQuotesList = JsonConvert.DeserializeObject<List<string>>(@"..\..\quotes.json");

            // need to figure out how to display quotes in GridView
            AllQuotes = new List<DeskQuote>();

            DeskQuote deskQuoteOne = new DeskQuote();
            Desk deskOne = new Desk();
            deskOne.Surface = Material.laminate;
            deskQuoteOne.desk = deskOne;

            AllQuotes.Add(deskQuoteOne);
            
            String filePath = @"..\..\Allquotes.json";
            //Read all quotes if there are any on there
            StreamReader startReader = new StreamReader(filePath);
            var firstRead = startReader.ReadToEnd();
            startReader.Close();
            List<DeskQuote> test = JsonConvert.DeserializeObject<List<DeskQuote>>(firstRead);

            //If test is null then there was no data in the file
            if (test == null)
            {
                test = new List<DeskQuote>();
            }

            // Add a quote to the file
            DeskQuote quoteTwo = new DeskQuote();
            Desk deskTwo = new Desk();
            deskTwo.Surface = Material.pine;
            quoteTwo.desk = deskTwo;

            test.Add(quoteTwo);

            //Write out all Quotes in a list
            string result = JsonConvert.SerializeObject(test);
            File.Delete(filePath);
            File.AppendAllText(filePath, result);

            //Read all quotes at one time from AllQuotes
            StreamReader reader = new StreamReader(filePath);
            var fileContents = reader.ReadToEnd();
            List<DeskQuote> testTwo = JsonConvert.DeserializeObject<List<DeskQuote>>(fileContents);

            //Write each quote one after another - Current implementation
            var singlePath = @"..\..\quotes.json";
            string resultOne = JsonConvert.SerializeObject(deskQuoteOne);
            File.AppendAllText(singlePath, resultOne);

            string resultTwo = JsonConvert.SerializeObject(quoteTwo);
            File.AppendAllText(singlePath, resultTwo);
            
            //Try to read a single quote out of the file - does not work
            StreamReader singleReader = new StreamReader(singlePath);
            var singleContents = reader.ReadToEnd();
            DeskQuote singleQuote = JsonConvert.DeserializeObject<DeskQuote>(singleContents);

            //Try to read all the quotes from the file - does not work
            List<DeskQuote> singleAll = JsonConvert.DeserializeObject<List<DeskQuote>>(singleContents);


            //Write a single quote at a time to every line and read the lines
            //Write each quote one after another and add a new line each time
            var linePath = @"..\..\linequotes.json";
            string lineOne = JsonConvert.SerializeObject(deskQuoteOne);
            lineOne = lineOne + System.Environment.NewLine;
            File.AppendAllText(linePath, lineOne);

            string lineTwo = JsonConvert.SerializeObject(quoteTwo);
            lineTwo = lineTwo + System.Environment.NewLine;
            File.AppendAllText(linePath, lineTwo);

            //Try to read all quotes out of the file - does work
            StreamReader lineReader = new StreamReader(linePath);
            List<DeskQuote> lineQuotes = new List<DeskQuote>();

            String line;
            while((line = lineReader.ReadLine()) != null)
            {
                DeskQuote lineQuote = JsonConvert.DeserializeObject<DeskQuote>(line);
                lineQuotes.Add(lineQuote);
            }

            filterQuotes(test, Material.laminate);
            InitializeComponent();

            materialSelect.DataSource = Enum.GetValues(typeof(Material));
            materialSelect.Text = "Select a material";
        }


        private void materialSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //materialSelect;
            Material material;
            Enum.TryParse<Material>(materialSelect.SelectedValue.ToString(), out material);

            //List<DeskQuote> results = filterQuotes(AllQuotes, material);
            //updateGridView(results);

        }

        private List<DeskQuote> filterQuotes(List<DeskQuote> origQuotes, Material material)
        {
            List<DeskQuote> results = new List<DeskQuote>();

            foreach(var quote in origQuotes){

                if (quote.desk.Surface == material)
                {
                    results.Add(quote);
                }
            }
            
           return results;
        }

        // Update the visual component with the new quotes
        private void updateGridView(List<DeskQuote> quotes)
        {
            
        }

        private void viewQuoteExitButton_Click(object sender, EventArgs e)
        {
            MainMenu viewMainMenu = new MainMenu();
            viewMainMenu.Show(this);
            this.Hide();
        }
    }
}
