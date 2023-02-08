<%@ Page Title="" Language="C#" MasterPageFile="~/GeeksMaster.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="WebGeeksFrontEnd.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">

        function updateQty(productID) {
            var qty = document.getElementById(productID).value;

             window.location.href = "cart.aspx?ProductID=" + productID + "&Qty=" + qty;
           
           
        }

        function notifyUser() {
             alert("Only few items remaining");
        }
    
         
     </script>

     <form method="post" action="#" runat="server" class="fields">
           
    <section class="ftco-section ftco-cart">
			<div class="container">
				<div class="row">
    			<div class="col-md-12 ftco-animate">
    				<div class="cart-list">
	    				<table class="table">
						    <thead class="thead-primary">
						      <tr class="text-center">
						        <th>&nbsp;</th>
						        <th>&nbsp;</th>
						        <th>Product name</th>
						        <th>Price</th>
						        <th>Quantity</th>
                                  <th>Update Cart</th>
						        <th>Total</th>
						      </tr>
						    </thead>
						    <tbody id="theCart" runat="server">
                                
						  
						    </tbody>
						  </table>
					  </div>
    			</div>
    		</div>
               
    		<div class="row justify-content-end">
    			<div class="col-lg-4 mt-5 cart-wrap ftco-animate">
    				<div class="cart-total mb-3">
    					<h3>Coupon Code</h3>
    					<p>Enter your coupon code if you have one</p>
                       
  						
	              <div class="form-group">
	              	<label for="">Coupon code</label>

	                <input id="couponID" runat="server" type="text" class="form-control text-left px-3" placeholder="Enter Coupon ID">
	              </div>
	          
    				</div>
                        
    			</div>
    			
    			<div class="col-lg-4 mt-5 cart-wrap ftco-animate">
                     
    				<div class="cart-total mb-3">
    					<h3>Cart Totals</h3>
    					<p class="d-flex">
    						<span>Subtotal</span>
    						<span id="subtotal" runat="server"></span>
    					</p>
    					<p class="d-flex">
    						<span>Delivery</span>
    						<span id="delivery" runat="server"></span>
    					</p>
    					<p class="d-flex">
    						<span>Discount</span>
    						<span id="discount" runat="server"></span>
    					</p>
    					<hr>
                        <p class="d-flex">
    						<span id="vat" runat="server"></span>
    						<span id="vatValue" runat="server"></span>
    					</p>
    					<p class="d-flex total-price">
    						<span>Total</span>
    						<span id="totalPrice" runat="server"></span>
    					</p>
    				</div>

    				
                        
                        <asp:Button ID="checkOutBtn" class="btn btn-primary py-3 px-4" runat="server" Text="Proceed to Checkout"  OnClick="checkOutBtn_Click" />
                          

    			</div>
    		</div>
			</div>
		</section>
            </form> 

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
