using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MegaDesk_Gale
{
    public static class Json
    {
       
        /*methods*/
        public static void Store(DeskQuote o)
        {
            var filepath = @"..\..\linequotes.json";
            string quoteInfo = JsonConvert.SerializeObject(o);
            quoteInfo += System.Environment.NewLine;
            File.AppendAllText(filepath, quoteInfo);
        }

        public static List<DeskQuote> GetQuotes()
        {
            var filepath = @"..\..\linequotes.json";
            StreamReader lineReader = new StreamReader(filepath);
            List<DeskQuote> quoteList = new List<DeskQuote>();
            String line;
            while ((line = lineReader.ReadLine()) != null)
            {
                DeskQuote lineQuote = JsonConvert.DeserializeObject<DeskQuote>(line);
                quoteList.Add(lineQuote);
            }
            return quoteList;
        }

    }

   
}
