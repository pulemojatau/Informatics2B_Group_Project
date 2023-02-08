using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGeeksFrontEnd.GeeksService;

namespace WebGeeksFrontEnd
{
    public partial class search : System.Web.UI.Page
    {
        Group_ServiceClient client = new Group_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["productID"] != null)
            {
                int ID = Convert.ToInt32(Request.QueryString["productID"]);
                AddProdToCart(ID);

            }
            if (Request.QueryString["itemSearched"] != null)
            {
                ProductClass prod = client.getProduct(Request.QueryString["itemSearched"]);
                string display = "";
                try
                {
                    display += "<div class='col-md-6 col-lg-3 ftco-animate'>";
                    display += $"<div class='product' >";
                    display += $"<a href='product-single.aspx?ID={prod.productID}' class='img-prod'><img style='height:190px;width:265px' class='img-fluid' src='{prod.image}' alt='Colorlib Template' id={prod.productID}>";
                    display += "<div class='overlay'></div>";
                    display += "</a><div class='text py-3 pb-4 px-3 text-center'>";
                    display += $"<h3>{prod.name}</h3>";
                    display += $"<p class='price'> <span class='price-sale'>R{Math.Round(prod.price, 2)}</span> </p>";
                    display += $"<a href='search.aspx?productID={prod.productID}' class='btn btn-primary'>Add To Cart <span><i class='ion-ios-cart'></i></span></a>";
                    display += "</div>";
                    display += "</div>";
                    display += "</a>";
                    display += "</div>";

                    searchedItem.InnerHtml = display;
                }
                catch (Exception ex)
                {
                    display += "<div style='display:flex; align-items:center; justify-content:center; margin:auto'>";
                    display += "<h2> Item not Found </h2> ";
                    display += "</div>";

                    searchedItem.InnerHtml = display;

                    ex.GetBaseException();
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
                        if (fetchedProduct.quantity >= pr.Quantity)
                        {
                            pr.Quantity++;
                            break;
                        }
                        else
                        {
                            Response.Redirect("shop.aspx?productID=" + (-9999999));

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
                    Response.Redirect("shop.aspx");

                }

            }


        }
    }
}