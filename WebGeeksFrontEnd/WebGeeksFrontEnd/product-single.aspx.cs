using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGeeksFrontEnd.GeeksService;

namespace WebGeeksFrontEnd
{
    public partial class product_single : System.Web.UI.Page
    {
        Group_ServiceClient client = new Group_ServiceClient();


        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            Session["P_ID"] = ID;
            String name = client.fetchProduct(ID);
            ProductClass single = client.getProduct(name);
            String display = " ";

            display += "<div class='col-lg-6 mb-5 ftco-animate'>";
            display += $"<a href ='{single.image}' class='image-popup'><img src='{single.image}' class='img-fluid' alt='Colorlib Template'></a>";
            display += "</div>";
            display += "<div class='col-lg-6 product-details pl-md-5 ftco-animate'>";
            display += $"<h3>{single.name}</h3>";
            display += $"<p class='price'><span>R{single.price}</span></p>";
            display += $"<p>{single.description}";
            display += "</p>";
            display += "<div class='row mt-4'>";
            display += "<div class='w-100'></div>";
            display += "<div class='input-group col-md-6 d-flex mb-3'>";
            display += "</div>";
            display += "</div>";
            display += "</div>";
            display += "</div>";

            about.InnerHtml = display;
        }

        protected void LinkClick(object sender, EventArgs e)
        {
            List<ProductsInCart> products = (List<ProductsInCart>)Session["CartProducts"];
            //products.Add((Session["P_ID"]));
            Session["CartProducts"] = products;
            //Response.Redirect("shop.aspx");

            if (Request.QueryString["ID"] != null)
            {
                int ID = Convert.ToInt32(Request.QueryString["ID"]);
                if (ID.Equals(-100))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alertMessage", "notifyUser()", true);
                }
                else
                {
                    AddProdToCart(ID);
                }


            }


        }

        private void AddProdToCart(int ID)
        {
            if (Session["CartProducts"] != null)
            {
                List<ProductsInCart> items = (List<ProductsInCart>)Session["CartProducts"];
                Boolean found = false;
                foreach (ProductsInCart pr in items)
                {
                    if (pr.ID == ID)
                    {
                        found = true;
                        ProductClass fetchedProduct = client.getProductByID(ID);
                        if ((pr.Quantity + 1) < fetchedProduct.quantity)
                        {
                            pr.Quantity++;
                            break;
                        }
                        else
                        {
                            Response.Redirect("shop.aspx?ID=" + (-100));
                            break;
                        }

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

                Response.Redirect($"shop.aspx?#{ID}");
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }
    }
}