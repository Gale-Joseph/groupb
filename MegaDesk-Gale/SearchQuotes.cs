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
            AllQuotes = Json.GetQuotes();
            InitializeComponent();

            materialSelect.DataSource = Enum.GetValues(typeof(Material));
            materialSelect.Text = "Select a material";
        }


        private void materialSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //materialSelect;
            Material material;
            Enum.TryParse<Material>(materialSelect.SelectedValue.ToString(), out material);

            List<DeskQuote> results = filterQuotes(AllQuotes, material);
            updateGridView(results);

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

            /*
             * First Name
             * Last Name
             * Date
             * Desk Specs
             *  - width
             *  - depth
             *  - material
             *  - drawers
             * Total Price
             * *
             */

            DataTable data = new DataTable();

            data.Columns.Add("Customer Name");
            data.Columns.Add("Order Date");
            data.Columns.Add("Desk Width");
            data.Columns.Add("Desk Depth");
            data.Columns.Add("Total Price");

            foreach(DeskQuote quote in quotes)
            {
                data.Rows.Add(quote.firstName + " " + quote.lastName, quote.currentDate, quote.desk.Width, quote.desk.Depth, quote.getTotal(quote.desk));
            }

            searchGridView.DataSource = data;
        }

        private void viewQuoteExitButton_Click(object sender, EventArgs e)
        {
            MainMenu viewMainMenu = new MainMenu();
            viewMainMenu.Show(this);
            this.Hide();
        }
    }
}
