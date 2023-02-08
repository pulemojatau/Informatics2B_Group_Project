using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGeeksFrontEnd.GeeksService;

namespace WebGeeksFrontEnd
{
    public partial class register : System.Web.UI.Page
    {
        Group_ServiceClient client = new Group_ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null)
            {
                userType.Visible = false;
                userType.Value = "0";
            }
            else if (Session["UserType"].Equals(1))
            {
                userType.Visible = true;
            }


        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {


            if (password.Value.Equals(passConfirm.Value))
            {


                UserClass newUser = new UserClass
                {
                    Title = title.Value,
                    Name = name.Value,
                    Surname = surname.Value,
                    email = email.Value,
                    Password = password.Value,
                    userType = Convert.ToInt32(userType.Value)

                };

                if (client.Register(newUser) == 1)
                {
                    if (Session["Name"] != null)
                    {
                        if (Session["UserType"].Equals(1))
                        {
                            Response.Redirect("adminPage.aspx");
                        }

                    }
                    else
                        Response.Redirect("login.aspx");
                }


            }

            title.Value = "";
            name.Value = "";
            surname.Value = "";
            email.Value = "";
            password.Value = "";
        }
    }
}