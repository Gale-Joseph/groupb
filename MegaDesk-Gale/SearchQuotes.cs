using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_Gale
{
    public partial class SearchQuotes : Form
    {

        List<DeskQuote> allQuotes;

        public SearchQuotes()
        {
            InitializeComponent();
            materialSelect.DataSource = Enum.GetValues(typeof(Material));
            materialSelect.Text = "Select a material";
            // start with all of the existing quotes (read from JSON or a central memory place)
            updateGridView(allQuotes);

            // todo
            // need to get all the added quotes in the system available to this class (ApplicationState static class?)
            // need to figure out how to display quotes in GridView
            // add a display all button that updates with allQuotes
        }

        private void viewQuoteExitButton_Click(object sender, EventArgs e)
        {
            MainMenu viewMainMenu = new MainMenu();
            viewMainMenu.Show(this);
            this.Hide();
        }

        private void materialSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //materialSelect;
            Material material;
            Enum.TryParse<Material>(materialSelect.SelectedValue.ToString(), out material);

            List<DeskQuote> results = filterQuotes(allQuotes, material);
            updateGridView(results);

        }

        private List<DeskQuote> filterQuotes(List<DeskQuote> origQuotes, Material material)
        {
            List<DeskQuote> results = new List<DeskQuote>();
            
            /*
            * 
            * for (quote in origQuotes){
            * 
            *  if (quote.material == material){
            *  
            *      results.push(quote)
            *      
                   }
            * 
            * }
            * 
            * 
            */

            return results;
        }

        // Update the visual component with the new quotes
        private void updateGridView(List<DeskQuote> quotes)
        {
            // update the UI component
        }
    }
}
