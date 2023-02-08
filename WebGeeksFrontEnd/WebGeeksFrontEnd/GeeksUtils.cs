using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGeeksFrontEnd
{
    public class GeeksUtils
    {
        private static double FreeDeliveryFee = 200;
        private static double VAT = 0.15;
        private static double deliveryFee = 15;
        private static double SubTotal;
        private static double Total;
        private static double discount = 0.0;
        private static double calculatedDiscount = 0.0;

        public static void setCalculatedDiscount(double value)
        {
            calculatedDiscount = value;
        }

        public static double getCalculatedDiscount()
        {
            return calculatedDiscount;
        }

        public static void setDiscount(double dis)
        {
            discount = dis;

        }

        public static double getDiscount()
        {
            return discount;
        }


        public static double getFreeDeliveryFee()
        {
            return FreeDeliveryFee;
        }

        public static void setFreeDeliveryFee(double newFee)
        {
            FreeDeliveryFee = newFee;
        }

        public static double getVat()
        {
            return VAT;
        }

        public static void setVat(double newVat)
        {
            VAT = newVat;
        }



        public static double getDeliveryFee()
        {
            return deliveryFee;
        }

        public static void setDeliveryFee(double newDeliveryFee)
        {
            deliveryFee = newDeliveryFee;
        }

        //post to checkout Page
        public static void setSubtotal(double subTotal)
        {
            SubTotal = subTotal;
        }

        public static double getSubTotal()
        {
            return SubTotal;
        }

        public static void setTotal(double total)
        {
            Total = total;
        }
        public static double getTotal()
        {
            return Total;
        }

    }
}