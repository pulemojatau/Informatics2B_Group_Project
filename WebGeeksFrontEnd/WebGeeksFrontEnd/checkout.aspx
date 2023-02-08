<%@ Page Title="" Language="C#" MasterPageFile="~/GeeksMaster.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="WebGeeksFrontEnd.checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="ftco-section">
      
             
	          
					<div class="col-xl-5">
	          <div class="row mt-5 pt-3">
	          	<div class="col-md-12 d-flex mb-5">
	          		<div class="cart-detail cart-total p-3 p-md-4">
	          			<h3 class="billing-heading mb-4">Cart Total</h3>
	          			<p class="d-flex">
		    						<span>Subtotal</span>
		    						<span id="Subtotal" runat="server"></span>
		    					</p>
		    					<p class="d-flex">
		    						<span>Delivery</span>
		    						<span id="deliveryFee" runat="server"></span>
		    					</p>
		    					<p class="d-flex">
		    						<span>Discount</span>
		    						<span id="discount" runat="server"></span>
		    					</p>
		    					<hr>
		    					<p class="d-flex total-price">
		    						<span>Total</span>
		    						<span id="Total" runat="server"></span>
		    					</p>
								</div>
	          	</div>
	          	<div class="col-md-12">
	          		<div class="cart-detail p-3 p-md-4">
	          			<h3 class="billing-heading mb-4">Payment Method</h3>
                           <form runat="server">
									<div class="form-group">
										<div class="col-md-12">
											<div class="radio">
											   <label><input type="radio" id="radioEFT" name="optradio" value="eft" class="mr-2" runat="server">Direct EFT</label>
											</div>
										</div>
									</div>
									<div class="form-group">
										<div class="col-md-12">
											<div class="radio">
											   <label><input type="radio" id="radioScan" name="optradio" value="scan" class="mr-2" runat="server"> SnapScan/Zapper</label>
											</div>
										</div>
									</div>
									<div class="form-group">
										<div class="col-md-12">
											<div class="radio">
											   <label><input type="radio" id="radioCard" name="optradio" value="card" class="mr-2" runat="server"> Debit/Credit Card</label>
											</div>
										</div>
									</div>
									
                         
                               <asp:Button ID="placeOrderBtn" class="btn btn-primary py-3 px-4" runat="server" Text="Place an order" OnClick="placeOrderBtn_Click" />
                          </form>
                          <div id="tester" runat="server"></div>
                       </div>
	          	</div>
	          </div>
          </div> <!-- .col-md-8 -->
      
    </section> <!-- .section -->

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
