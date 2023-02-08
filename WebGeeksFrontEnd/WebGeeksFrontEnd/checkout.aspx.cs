using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGeeksFrontEnd.GeeksService;

namespace WebGeeksFrontEnd
{
    public partial class checkout : System.Web.UI.Page
    {
        Group_ServiceClient client = new Group_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["Name"] != null)
            {
                List<ProductsInCart> itemsCount = (List<ProductsInCart>)Session["CartProducts"];
                int exists = itemsCount.Count;

                if (exists > 0)
                {
                    Subtotal.InnerHtml = "R" + Convert.ToString(GeeksUtils.getSubTotal());
                    deliveryFee.InnerHtml = "R" + Convert.ToString(GeeksUtils.getDeliveryFee());
                    Total.InnerHtml = "R" + Convert.ToString(GeeksUtils.getTotal());
                    discount.InnerHtml = "R" + Convert.ToString(GeeksUtils.getCalculatedDiscount());
                }
                else
                {
                    Response.Redirect("shop.aspx");

                }
            }
            else
            {

                Response.Redirect("shop.aspx");
            }

        }

        protected void placeOrderBtn_Click(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                int UserID = Convert.ToInt32(Session["ID"]);
                int coupon = 0;
                String Payment_Method = "";
                if (radioEFT.Checked)
                {
                    Payment_Method = "Direct EFT";
                    

                }
                else if (radioScan.Checked)
                {
                    Payment_Method = "Zapper/SnapScan";
                    

                }
                else if (radioCard.Checked)
                {
                    Payment_Method = "Credit/Debit Card";
                    

                }

               

                Session["PaymentMethod"] = Payment_Method;
                DateTime now = DateTime.Now;
                Session["DateCheckedOut"] = now;
                InvoiceClass newInv = new InvoiceClass
                {
                    user = Convert.ToInt32(Session["ID"]),
                    day = Convert.ToDateTime(Session["DateCheckedOut"]),
                    subtotal = GeeksUtils.getSubTotal(),
                    vat = GeeksUtils.getVat(),
                    delivery = GeeksUtils.getDeliveryFee(),
                    grossTotal = GeeksUtils.getTotal()
                };

                int result = client.generateInvoice(newInv);
                int invID = client.getInvoiceID(newInv.user, newInv.day);

                List<ProductsInCart> savelist = (List<ProductsInCart>)Session["CartProducts"];

                ProductsInCart[] somelist = new ProductsInCart[savelist.Count];
                int a = 0;
                foreach (ProductsInCart b in savelist)
                {
                    somelist[a] = b;
                    a++;
                }
                foreach (ProductsInCart b in savelist)
                {
                    ProductClass prod = client.getProductByID(b.ID);
                    prod.quantity -= b.Quantity;
                    client.EditProduct(prod);
                }
                bool saved = client.saveOrderProduct(somelist, invID);
                Response.Redirect("invoice.aspx");


            }


        }
    }
}