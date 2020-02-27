using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Data;
using MegaDeskWeb.Models;

namespace MegaDeskWeb
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWeb.Data.MegaDeskWebContext _context;

        public IndexModel(MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            _context = context;
        }

        public IList<Quote> Quote { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
    
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        
        
        public async Task OnGetAsync(string sortOrder, string currentFilter, string SearchString, int? pageIndex)
        {

            //if user clicks on Date link for sorting, toggle values as follows/go to switch statement
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            //if while toggling the SearchString goes null, set the SearchString equal to previously entered currentFilter argument
            if (SearchString == null)
            {
                SearchString = currentFilter;
            }

            //set Quotes.CurrentFilter to SearchString to bring in conformity with  asp-route-currentFilter="@Model.CurrentFilter">
            CurrentFilter = SearchString;

            //create a querable object called quotesIQ with all quotes from db
            IQueryable<Quote> quotesIQ = from q in _context.Quote select q;

            //modify current quotesIQ to match search string
            if (!String.IsNullOrEmpty(SearchString))
            {
                quotesIQ = quotesIQ.Where(q => q.lastname.Contains(SearchString));
            }

            //order quotesIQ based on asp-route-sortOrder
            switch (DateSort)
            {
                   case "Date":                    
                    quotesIQ = quotesIQ.OrderBy(q => q.quoteDate);
                    break;
                case "date_desc":
                    quotesIQ = quotesIQ.OrderByDescending(s => s.quoteDate);
                    break;
                default:
                    quotesIQ = quotesIQ.OrderByDescending(q => q.lastname);
                    break;
            }

            //print quotesIQ based on if there is sortOrder or not
            if (sortOrder == null)
            {
                Quote = await quotesIQ.ToListAsync();
            }
            else
            {
                Quote = await quotesIQ.AsNoTracking().ToListAsync();
            }

           
        }
    }
}
