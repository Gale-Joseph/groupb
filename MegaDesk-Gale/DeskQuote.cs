/* This class is used to calculate the price of a desk;
 * A DeskQuote object and Desk object are created in AddQuote.cs once the user starts entering data;
 * As the user enters data, that data is added to the DeskQuote object and Desk object;
 * Most of these functions are executed when the final quote is displayed in DisplayQuote.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Gale
{
   
    public class DeskQuote
    {
        /*member variables: */
        string quoteDate = DateTime.Now.ToString();
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string currentDate;

        /* standard delivery is 14 days and accrues no extra costs;
         * however, if deliveryTime is different, the cost will be
         * adjusted in the function getDeliveryPrice() listed below;*/
        public int deliveryTime = 14;

        /*pricing structure variables:*/
        public int basePrice = 200;
        int saPrice = 1; //surface area price: $1 per square inch
        public int drawerPrice = 50;
        public int surfacePrice; //the price of the material for desk surface
        public int deliveryPrice { get; set; }

        /*constructor*/
        public Desk desk { get; set; }

        //methods  
        /* getDeliveryPrice is not particularly written well and gets cumbersome to fill out, but
         * as of 1/30/20 it makes the program function correctly*/
        public int getDeliveryPrice(int width, int depth, int deliveryTime)
        {
            int sa = width * depth;
            int total;
            switch (deliveryTime)
            {
                case 3:
                    if (sa < 1000)
                    {
                        total = 60;
                    }
                    else if(sa >=1000 && sa <=2000){
                        total = 70;
                    }
                    else
                    {
                        total = 80;
                    }
                    break;
                case 5:
                    if (sa < 1000)
                    {
                        total = 40;
                    }
                    else if (sa >= 1000 && sa <= 2000)
                    {
                        total = 50;
                    }
                    else
                    {
                        total = 60;
                    }
                    break;
                case 7:
                    if (sa < 1000)
                    {
                        total = 30;
                    }
                    else if (sa >= 1000 && sa <= 2000)
                    {
                        total = 35;
                    }
                    else
                    {
                        total = 40;
                    }
                    break;
                default:
                    total = 0;
                    break;
            }

            return total;
        }

        public int getArea()
        {
           return this.desk.Width * this.desk.Depth;
        }
        public int getSurfacePrice(Desk desk)
        {
            int surfacePrice = (int)desk.Surface;
            return surfacePrice;
        }
        /* getTotal will be rewritten to get rid of "magic" numbers in price calculation;
         * this will be the function that also stores the quote to quotes.json */
        public int getTotal(Desk desk)
        {
            saPrice *= desk.Width * desk.Depth;
            drawerPrice *= desk.Drawers;
            surfacePrice = getSurfacePrice(desk);
            deliveryPrice = 100;//wrong number, needs to be redone: getDeliveryPrice(desk.width,desk.depth,this.deliveryTime)
            int total = basePrice + saPrice + drawerPrice + surfacePrice + deliveryPrice;            

            return total;
        }
    }
}
