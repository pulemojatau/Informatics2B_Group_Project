<%@ Page Title="" Language="C#" MasterPageFile="~/GeeksMaster.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebGeeksFrontEnd.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main" class="home">
            <div class="login">
                
                <h1 style="text-align:center; font-size:3.2rem; color:#82ae46;">Login</h1>
                
                <section>
                    <form method="post" action="#" runat="server" class="fields">
                        <div class="fields">
                            <div class="field">
                                <input type="email" name="email" class="inputField" id="email" placeholder="Email" runat="server"/>
                            </div>
                            <div class="field">
                                <input type="password" name="password" class="inputField" id="password" placeholder="Password" runat="server"/>
                            </div>
                        </div>
                        <span><a href="register.aspx">New Customer?, Register</a></span>
                  
                        <asp:Button ID="Button1" runat="server" class="btn btn-primary py-3 px-4" Text="Login" OnClick="Login_Click" />
                    </form>
                      <div class="field">
                                <input type="text" style="text-align:center; font-size:1.2rem; color:#82ae46;" name="display Message" class="inputField" id="popUpMessage" placeholder="" readonly="readonly" runat="server"/>
                            </div>
                </section>
            </div>
        </div>
</asp:Content>
