using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGeeksFrontEnd.GeeksService;

namespace WebGeeksFrontEnd
{
    public partial class shop : System.Web.UI.Page
    {
        Group_ServiceClient client = new Group_ServiceClient();
        dynamic list;

        protected void Page_Load(object sender, EventArgs e)
        {
            string orderBySelected = "";
            int orderBy = 4;
            if (Request.QueryString["order"] != null)
            {
                int order = Convert.ToInt32(Request.QueryString["order"]);
                orderBy = order;
                list = client.getAllProduct(order);

            }
            else
            {
                list = client.getAllProduct(45);
            }

            DisplayProducts();

            switch (orderBy)
            {
                case 4:
                    orderBySelected = "Names From A-Z";
                    break;
                case 6:
                    orderBySelected = "Prices from lowest to Highest";
                    break;
                case 5:
                    orderBySelected = "Names From Z-A";
                    break;
                case 7:
                    orderBySelected = "Prices from Highest to lowest";
                    break;
                default:
                    break;

            }

            sortID.InnerHtml = orderBySelected + " ";

            if (Request.QueryString["productID"] != null)
            {
                int ID = Convert.ToInt32(Request.QueryString["productID"]);
                AddProdToCart(ID);

            }


        }


        private void DisplayProducts()
        {

            string display = "";
            foreach (Product i in list)
            {

                display += "<div class='col-md-6 col-lg-3 ftco-animate'>";
                display += $"<div class='product' >";
                display += $"<a href='product-single.aspx?ID={i.ProductID}' class='img-prod'><img style='height:190px;width:265px' class='img-fluid' src='{i.ProductImage}' alt='Colorlib Template' id={i.ProductID}>";
                display += "<div class='overlay'></div>";
                display += "</a><div class='text py-3 pb-4 px-3 text-center'>";
                display += $"<h3>{i.ProductName}</h3>";
                display += $"<p class='price'> <span class='price-sale'>R{Math.Round(i.ProductPrice, 2)}</span> </p>";
                display += $"<a href='shop.aspx?productID={i.ProductID}' class='btn btn-primary'>Add To Cart <span><i class='ion-ios-cart'></i></span></a>";
                display += "</div>";
                display += "</div>";
                display += "</a>";
                display += "</div>";


            }

            catalogue.InnerHtml = display;
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

                }

                Response.Redirect($"shop.aspx?#{ID}");
            }


        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string productName = searchItem.Value;
            Response.Redirect("search.aspx?itemSearched=" + productName);
        }
    }
}