using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGeeksFrontEnd.GeeksService;

namespace WebGeeksFrontEnd
{
    public partial class invoice : System.Web.UI.Page
    {
        Group_ServiceClient client = new Group_ServiceClient();
        String sb = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["CartProducts"] = null;

            if (Session["Name"] != null)
            {
                if (Request.QueryString["viewInvoice"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["viewInvoice"]);
                    InvoiceClass inv = client.getInvoiceByID(id);
                    Session["DateCheckedOut"] = inv.day;

                }
                if (Session["DateCheckedOut"] != null)
                {

                    if (Session["ID"] != null)
                    {
                        int userID = Convert.ToInt32(Session["ID"]);

                        int invID = client.getInvoiceID(userID, Convert.ToDateTime(Session["DateCheckedOut"]));

                        InvoiceClass theInvoice = client.getInvoiceByID(invID);

                        dynamic list = client.getAllInvoiceProduct(invID);


                        string companyName = "Web-Geeks";

                        DataTable dt = new DataTable();
                        dt.Columns.AddRange(new DataColumn[5] {
                            new DataColumn("ProductId", typeof(int)),
                            new DataColumn("Product", typeof(string)),
                            new DataColumn("Price", typeof(double)),
                            new DataColumn("Quantity", typeof(int)),
                            new DataColumn("Total", typeof(double))});

                        if (Session["downloadInvoice"] == null)
                        {
                            Session["downloadInvoice"] = new List<InvoiceProduct>();


                        }

                        List<InvoiceProduct> DownloadInvoice = (List<InvoiceProduct>)Session["downloadInvoice"];
                        foreach (InvoiceProduct p in list)
                        {
                            var prName = client.getProductByID(p.prodID);
                            dt.Rows.Add(p.prodID, prName.name, p.price, p.qty, (p.price * p.qty));
                            DownloadInvoice.Add(p);
                        }


                        //Generate Invoice (Bill) Header.
                        sb += "<table class='theTable'>";
                        sb += "<tr><td align='center' colspan ='2'><b>Invoice</b></td></tr>";
                        sb += "<tr><td colspan='2'></td></tr>";
                        sb += $"<tr><td><b>Order No:{invID} </b>";
                        sb += $"</td><td align='right'><b>Date:{Session["DateCheckedOut"]}</b>";
                        sb += "</td></tr>";
                        sb += $"<tr><td><b>Company Name:{companyName} </b>";
                        sb += $"</td><td align='right'><b>Payment Method:{Session["PaymentMethod"]}</b>";
                        sb += "</td></tr>";
                        sb += "</table>";
                        sb += "<br/>";

                        //Generate Invoice (Bill) Items Grid.
                        sb += "<table class='theTable' border='1'>";
                        sb += "<tr>";
                        foreach (DataColumn column in dt.Columns)
                        {
                            sb += "<th>";
                            sb += column.ColumnName;
                            sb += "</th>";
                        }
                        sb += "</tr>";
                        foreach (DataRow row in dt.Rows)
                        {
                            sb += "<tr>";
                            foreach (DataColumn column in dt.Columns)
                            {
                                sb += "<td>";
                                sb += row[column];
                                sb += "</td>";
                            }
                            sb += "</tr>";
                        }
                        //
                        sb += "<tr><td align='right' colspan='";
                        sb += dt.Columns.Count - 1;
                        sb += "'>SubTotal</td>";
                        sb += "<td>";
                        sb += "R" + theInvoice.subtotal;
                        sb += "</td>";
                        sb += "</tr>";
                        //
                        sb += "<tr><td align='right' colspan='";
                        sb += dt.Columns.Count - 1;
                        sb += "'>VAT</td>";
                        sb += "<td>";
                        sb += "R" + theInvoice.vat;
                        sb += "</td>";
                        sb += "</tr>";
                        //
                        sb += "<tr><td align='right' colspan='";
                        sb += dt.Columns.Count - 1;
                        sb += "'>Delivery Fee </td>";
                        sb += "<td>";
                        sb += "R" + theInvoice.delivery;
                        sb += "</td>";
                        sb += "</tr>";
                        //
                        sb += "<tr><td align='right' colspan='";
                        sb += dt.Columns.Count - 1;
                        sb += "'>Discount </td>";
                        sb += "<td>";
                        sb += "R" + GeeksUtils.getCalculatedDiscount();
                        sb += "</td>";
                        sb += "</tr>";
                        //
                        sb += "<tr><td align='right' colspan='";
                        sb += dt.Columns.Count - 1;
                        sb += "'>Total </td>";
                        sb += "<td>";
                        sb += "R" + theInvoice.grossTotal;
                        sb += "</td>";
                        sb += "</tr></table>";
                        Session["downloadPdf"] = sb;
                        inv.InnerHtml = sb;

                    }

                }
            }
            GeeksUtils.setDeliveryFee(15);
            Session["DateCheckedOut"] = null;
            Session["PaymentMethod"] = null;
        }

       
    }
}