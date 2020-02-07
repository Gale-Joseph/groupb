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
            AllQuotes = new List<DeskQuote>();

            //this chunk of code (lines 28-55) adds fake quotes for testing purposes 
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

            //Save Quotes to Json file
            //Write each quote one after another and add a new line each time
            var linePath = @"..\..\linequotes.json";
            string lineOne = JsonConvert.SerializeObject(deskQuoteOne);
            lineOne = lineOne + System.Environment.NewLine;
            File.AppendAllText(linePath, lineOne);

            //string lineTwo = JsonConvert.SerializeObject(quoteTwo);
            //lineTwo = lineTwo + System.Environment.NewLine;
            //File.AppendAllText(linePath, lineTwo);

            //Create a list of all quotes by deserializing the Json quotes file - works!
            StreamReader lineReader = new StreamReader(linePath);
            List<DeskQuote> lineQuotes = new List<DeskQuote>();
            
            String line;
            while((line = lineReader.ReadLine()) != null)
            {
                DeskQuote lineQuote = JsonConvert.DeserializeObject<DeskQuote>(line);
                lineQuotes.Add(lineQuote);
            }

            
         // BEGIN FILTERING QUOTES BY MATERIAL FOR SEARCH PAGE
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
