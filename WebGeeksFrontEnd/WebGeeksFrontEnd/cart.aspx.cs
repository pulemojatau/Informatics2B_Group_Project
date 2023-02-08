using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGeeksFrontEnd.GeeksService;

namespace WebGeeksFrontEnd
{
    public partial class cart : System.Web.UI.Page
    {
        Group_ServiceClient client = new Group_ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {



            if (Request.QueryString["ProductID"] != null && Request.QueryString["Qty"] != null)
            {
                int ProdID = Convert.ToInt32(Request.QueryString["ProductID"]);

                ProductClass fetchedProduct = client.getProductByID(ProdID);
                int providedQuantity = Convert.ToInt32(Request.QueryString["Qty"]);
                if (providedQuantity < 1)
                {
                    providedQuantity = 1;
                }

                if (fetchedProduct.quantity <= providedQuantity)
                {
                    AddProdToCart(Convert.ToInt32(Request.QueryString["ProductID"]), fetchedProduct.quantity);

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alertMessage", "notifyUser()", true);
                }
                else
                {
                    AddProdToCart(Convert.ToInt32(Request.QueryString["ProductID"]), providedQuantity);
                }



            }
            List<ProductsInCart> itemsCount = (List<ProductsInCart>)Session["CartProducts"];
            int exists = itemsCount.Count;

            if (exists > 0)
            {
                checkOutBtn.Visible = true;
            }
            else
            {
                checkOutBtn.Visible = false;

            }

            if (Request.QueryString["removeID"] != null)
            {
                int ID = Convert.ToInt32(Request.QueryString["removeID"]);
                RemoveProduct(ID);

            }

            String display = "";
            double total = 0;


            if (Session["CartProducts"] != null)
            {
                List<ProductsInCart> items = (List<ProductsInCart>)Session["CartProducts"];

                foreach (ProductsInCart pr in items)
                {

                    String name = client.fetchProduct(pr.ID);
                    ProductClass single = client.getProduct(name);
                    total += single.price * pr.Quantity;

                    display += "<tr class='text-center'>";
                    display += $"<td class='product-remove'><a href='cart.aspx?removeID={single.productID}' ><span class='ion-ios-close'></span></a></td>";
                    display += $"<td class='image-prod'><div class='img' style='background-image:url({single.image});'></div></td>";
                    display += "<td class='product-name'>";
                    display += $"<h3>{single.name}</h3>";
                    display += "</td>";
                    display += $"<td class='price'>R{single.price}</td>";
                    display += "<td class='quantity'>";
                    display += "<div class='input-group mb-3'>";
                    display += $"<input type='number' name='quantity' id='{single.productID}' class='quantity form-control input-number' value='{pr.Quantity}'>";
                    display += "</div>";
                    display += "</td>";
                    display += "<td>";
                    display += $"<a onclick='updateQty({single.productID});' style='padding: 0 0.5rem 0 0.5rem;' class='btn btn-primary py-3 px-4'>update cart</a>";
                    display += "</td>";
                    display += $"<td class='total'>R{single.price * pr.Quantity}</td>";
                    display += "</tr>";

                }
                theCart.InnerHtml = display;
                vat.InnerHtml = "VAT: " + Convert.ToString(GeeksUtils.getVat() * 100) + "%";
                vatValue.InnerHtml = "R" + Math.Round(total * GeeksUtils.getVat(), 2);
                delivery.InnerHtml = "R" + Convert.ToString(GeeksUtils.getDeliveryFee());
                discount.InnerHtml = "R" + Convert.ToString(total * GeeksUtils.getDiscount());
                GeeksUtils.setCalculatedDiscount(total * GeeksUtils.getDiscount());
                subtotal.InnerHtml = "R" + Math.Round(total, 2);
                GeeksUtils.setSubtotal(total);
                if (total == 0 || total >= 300)
                {

                    delivery.InnerHtml = "R0.00";
                    totalPrice.InnerHtml = "R" + Math.Round((total * GeeksUtils.getVat() + total) - (total * GeeksUtils.getDiscount()), 2);
                    GeeksUtils.setTotal((total * GeeksUtils.getVat() + total) - (total * GeeksUtils.getDiscount()));
                    GeeksUtils.setDeliveryFee(0);

                }
                else
                {
                    totalPrice.InnerHtml = "R" + Math.Round((total * GeeksUtils.getVat() + total) + (GeeksUtils.getDeliveryFee()) - (GeeksUtils.getDiscount() * total), 2);
                    GeeksUtils.setTotal((total * GeeksUtils.getVat() + total) + (GeeksUtils.getDeliveryFee()) - (GeeksUtils.getDiscount() * total));
                }



            }

        }


        protected void checkOutBtn_Click(object sender, EventArgs e)
        {
            if (Session["Name"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (Session["Name"] != null)
            {

                Response.Redirect("checkout.aspx");

            }

        }


        private void RemoveProduct(int ID)
        {
            if (Session["CartProducts"] != null)
            {
                List<ProductsInCart> items = (List<ProductsInCart>)Session["CartProducts"];
                foreach (ProductsInCart prod in items)
                {
                    if (prod.ID.Equals(ID))
                    {
                        items.Remove(prod);
                        break;
                    }
                }

            }
        }

        public void AddProdToCart(int ID, int qty)
        {
            if (Session["CartProducts"] != null)
            {
                List<ProductsInCart> items = (List<ProductsInCart>)Session["CartProducts"];
                Boolean found = false;

                foreach (ProductsInCart pr in items)
                {

                    if (ID.Equals(pr.ID))
                    {
                        found = true;
                        pr.Quantity = qty;

                        break;
                    }

                }

                if (!found)
                {
                    var newItem = new ProductsInCart
                    {
                        ID = ID,
                        Quantity = 1
                    };

                    items.Add(newItem);
                }

            }

        }
    }
}