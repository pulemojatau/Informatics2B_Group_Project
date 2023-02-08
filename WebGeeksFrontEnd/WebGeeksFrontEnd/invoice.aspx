<%@ Page Title="" Language="C#" MasterPageFile="~/GeeksMaster.Master" AutoEventWireup="true" CodeBehind="invoice.aspx.cs" Inherits="WebGeeksFrontEnd.invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        .theTable {
          font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
          border-collapse: collapse;
          width: 100%;
        }

        .theTable td, #theTable th {
          border: 1px solid #ddd;
          padding: 8px;
          text-align:center;
          text-transform:capitalize;
        }

        .theTable tr:nth-child(even){background-color: #f2f2f2;}

        .theTable tr:hover {background-color: #ddd;}

        .theTable th {
          padding-top: 12px;
          padding-bottom: 12px;
          text-align: left;
          background-color: #4CAF50;
          color: white;
          text-align:center;
          text-transform:capitalize;
          font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="padding: 5px 5rem 5px 5rem; width:100vw">
        <div id="inv" runat="server"></div>

    </div>
</asp:Content>
