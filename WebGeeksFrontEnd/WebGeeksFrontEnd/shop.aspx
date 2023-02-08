<%@ Page Title="" Language="C#" MasterPageFile="~/GeeksMaster.Master" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="WebGeeksFrontEnd.shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center; font-size:3rem; color:#82ae46;">Shop</h1>
    <section class="ftco-section ftco-no-pt ftco-no-pb py-5 bg-light">
      <div>
        <div class="row d-flex justify-content-center py-5">
          <div class="col-md-6 d-flex align-items-center">
            <form action="#" class="subscribe-form" runat="server">
              <div class="form-group d-flex">
                <input type="text"  id="searchItem" runat="server" class="form-control" placeholder="Enter Product Name">
                  <asp:Button ID="searchBtn" runat="server" Text="Search"  class="submit px-3" OnClick="searchBtn_Click" />
              </div>
            </form>
          </div>
        </div>
      </div>
    </section>

    <div class="col-lg-11">
        <div class="row justify-content-end">
           
            <a class="nav-link dropdown-toggle" href="#" id="dropdown04" data-toggle="dropdown" 
                aria-haspopup="true" aria-expanded="false">Sort By</a><span class="nav-link" id="sortID" runat="server"></span>

            <div class="dropdown-menu" aria-labelledby="dropdown04">
            <a class="dropdown-item" href="shop.aspx?order=4">Names From A-Z</a>
            <a class="dropdown-item" href="shop.aspx?order=6">Prices from lowest to Highest</a>
                <a class="dropdown-item" href="shop.aspx?order=5">Names From Z-A</a>
            <a class="dropdown-item" href="shop.aspx?order=7">Prices from Highest to lowest</a>
            </div>

        </div>
    </div>
     
    <section class="ftco-section">
    	<div class="container">
    		<div class="row justify-content-center">
    			<div class="col-md-10 mb-5 text-center">
    				<ul class="product-category">
    					<li><a href="#" class="active">All</a></li>
    				</ul>
    			</div>
    		</div>
    		<div class="row" id="catalogue" runat="server">
    			<!-- products here -->
			
    		</div>
			
    	</div>
    </section>


		<section class="ftco-section ftco-no-pt ftco-no-pb py-5 bg-light">
      <div class="container py-4">
        <div class="row d-flex justify-content-center py-5">
          <div class="col-md-6">
          	<h2 style="font-size: 22px;" class="mb-0">Subcribe to our Newsletter</h2>
          	<span>Get e-mail updates about our latest shops and special offers</span>
          </div>
          <div class="col-md-6 d-flex align-items-center">
            <form action="#" class="subscribe-form">
              <div class="form-group d-flex">
                <input type="text" class="form-control" placeholder="Enter email address">
                <input type="submit" value="Subscribe" class="submit px-3">
              </div>
            </form>
          </div>
        </div>
      </div>
    </section>
</asp:Content>
