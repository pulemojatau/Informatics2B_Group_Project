<%@ Page Title="" Language="C#" MasterPageFile="~/GeeksMaster.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="WebGeeksFrontEnd.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div >
        <h1 style="text-align:center; font-size:5rem; color:#82ae46;">Contact</h1>
    </div>
    <section class="ftco-section contact-section bg-light">
      <div class="container">
      	<div class="row d-flex mb-5 contact-info">
          <div class="w-100"></div>
          <div class="col-md-3 d-flex">
          	<div class="info bg-white p-4">
	            <p><span>Address:  </span><a href="https://goo.gl/maps/tMiY6V8jk9BP5orp9"> 5 Kingsway Ave, Rossmore, Johannesburg, 2092</a></p>
	          </div>
          </div>
          <div class="col-md-3 d-flex">
          	<div class="info bg-white p-4">
	            <p><span>Phone:</span> <a href="tel://0837174177">+27 81332 1557</a></p>
	          </div>
          </div>
          <div class="col-md-3 d-flex">
          	<div class="info bg-white p-4">
	            <p><span>Email:</span> <a href="mailto:farmbrellaza@gmail.com">Web-geeks@gmail.com</a></p>
	          </div>
          </div>
        </div>

        <div class="row block-9">
          <div class="col-md-6 order-md-last d-flex">
            <form action="#" runat="server" class="bg-white p-5 contact-form">
              <div class="form-group">
                <input id="name" runat="server" type="text" class="form-control" placeholder="Your Name">
              </div>
              <div class="form-group">
                <input id="email" runat="server" type="email" class="form-control" placeholder="Your Email">
              </div>
              <div class="form-group">
                <input id="subject" runat="server" type="text" class="form-control" placeholder="Subject">
              </div>
              <div class="form-group">
                <textarea name="content" id="body" runat="server" cols="30" rows="7" class="form-control" placeholder="Message"></textarea>
              </div>

            </form>    
          </div>

          <div class="col-md-6 d-flex">
          	<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d14321.736136949452!2d27.9959458!3d-26.1825556!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x3d9ee40e6cfbca2c!2sUniversity%20of%20Johannesburg%20Student%20Center%20-%20Auckland%20Park%20Campus!5e0!3m2!1sen!2sza!4v1570900762590!5m2!1sen!2sza" width="600" height="450" style="border:0;" ></iframe>
          </div>
        </div>
      </div>
    </section>
</asp:Content>
