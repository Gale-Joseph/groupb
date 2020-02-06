/* This class is used to calculate the price of a desk;
 * A DeskQuote object and Desk object are created in AddQuote.cs once the user starts entering data;
 * As the user enters data, that data is added to the DeskQuote object and Desk object;
 * Most of these functions are executed when the final quote is displayed in DisplayQuote.cs(the next page)
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
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string currentDate; //set in the AddQuote form
        public int deliveryTime = 14; //standard delivery is 14

        /*constructor*/
        public Desk desk { get; set; }

        /*methods */

/*        public int GetRushOrder()
        {
            //read everything from text file and store in an array
            try
            {
                int[,,] priceGrid =
                {

                }
                for(int r = 0; r < 3; r++)
                {
                    for (int c = 0; c < 3; c++)
                    {

                    }
                }
            }
            catch
            {

            }

            *//*use nested loop to create 3x3 multidimensional array
             * rushArray(row1,row2,row3)
             * row1(col1,col2,col3)
             * row2(col1,col2,col3)
             * row3(col1,col2,col3)*//*
            return 5;
        }*/

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

        /*gets the surface area of desk for pricing*/
        public int getArea()
        {
           return this.desk.Width * this.desk.Depth;
        }

        /*get price of surface based on material'*/
        public int getSurfacePrice(Desk desk)
        {
            /*use (int)object.enumType to get numeric value of enum*/
            int surfacePrice = (int)desk.Surface;
            return surfacePrice;
        }

       
        /*this creates a total based on desk object specs defined by user input*/
        public int getTotal(Desk desk)
        {
            /*unit pricing structure variables:*/
            int basePrice = 200;
            int saPrice = 1; 
            int drawerPrice = 50;

        saPrice *= desk.Width * desk.Depth;
            drawerPrice *= desk.Drawers;
            int surfacePrice = getSurfacePrice(desk);
            int deliveryPrice = getDeliveryPrice(desk.Width, desk.Depth, this.deliveryTime);
            int total = basePrice + saPrice + drawerPrice + surfacePrice + deliveryPrice;
            return total;
        }

      

    }
}
