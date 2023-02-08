<%@ Page Title="" Language="C#" MasterPageFile="~/GeeksMaster.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebGeeksFrontEnd.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="home">
        <div class="login">
                    
                <h1 style="text-align:center; font-size:3.2rem; color:#82ae46;">Register</h1>
                
                <section>
                    <form method="post" action="#" runat="server" class="fields">
                        <div class="fields">
                            <div class="field">
                                <input type="text" name="txttitle" class="inputField" id="title" placeholder="Title" runat="server" />
                            </div>
                            <div class="field">
                                <input type="text" name="txtname" class="inputField" id="name" placeholder="First Name" runat="server" />
                            </div>
                            <div class="field">
                                <input type="text" name="txtsurname" class="inputField" id="surname" placeholder="Last Name" runat="server" />
                            </div>
                            <div class="field">
                                <input type="email" name="txtemail" class="inputField" id="email" placeholder="E-Mail" runat="server" />
                            </div>
                            <div class="field">
                                <input type="password" name="txtpass" class="inputField" id="password" placeholder="Password" runat="server" />
                            </div>
                            <div class="field">
                                <input type="password" name="txtconfirm" class="inputField" id="passConfirm" placeholder="Confirm Password" runat="server" />
                            </div>
                            <div class="field" id="check" runat="server">
                                <input type="text" class="inputField" id="userType" placeholder="User-Type[1 for admin][0 for customer]" runat="server" />
                            </div>
                        </div>
                        <asp:Button type="submit" id="BtnSend" class="btn btn-primary py-3 px-4" Text="Register" runat="server" OnClick="BtnSend_Click"/>
                    </form>
                </section>
            </div>
    </div>
</asp:Content>
