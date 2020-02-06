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
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();
        }

        private void viewQuoteExitButton_Click(object sender, EventArgs e)
        {
                MainMenu viewMainMenu = new MainMenu();
                viewMainMenu.Show(this);
                this.Hide();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DeskQuote> allQuotes = Json.GetQuotes();
            foreach(DeskQuote quote in allQuotes)
            {
                //change this to be put in gridview
                string quoteString = quote.currentDate + " " + quote.firstName + " " + quote.lastName +
                    " " + quote.deliveryTime + " day delivery " + quote.desk.Surface + quote.getTotal(quote.desk);
                listBox1.Items.Add(quoteString);
            }
            
        }
    }
}
