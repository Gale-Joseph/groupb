using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb
{
    public enum Material
    {
        oak = 200,
        laminate = 100,
        pine = 50,
        rosewood = 300,
        veneer = 125

    }

   
    
    public static class QuoteTotal
    {
        
        public static double get(int depth, int width, string material, int drawers, int rush)
        {
            var basePrice = 200;
            var surfaceArea = depth * width;
            var surfaceAreaPrice = surfaceArea * 1;
            var deliveryPrice = getDeliveryPrice(surfaceArea, rush);
            var deskMaterial = Enum.Parse(typeof(Material),material);
            var materialPrice = (int)deskMaterial;
            var drawerPrice = drawers * 50;

            var total = basePrice + surfaceAreaPrice + deliveryPrice + materialPrice + drawerPrice;


            return total;
        }

        private static double getDeliveryPrice(int sa, int deliveryTime)
        {
            int total;
            switch (deliveryTime)
            {
                case 3:
                    if (sa < 1000)
                    {
                        total = 60;
                    }
                    else if (sa >= 1000 && sa <= 2000)
                    {
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
    }
}
