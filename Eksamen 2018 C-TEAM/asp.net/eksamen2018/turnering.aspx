<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="turnering.aspx.cs" Inherits="eksamen2018._turnering" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">   
        <h1>Turneringer i eventet</h1>
        <p class="lead">Under finner du en oversikt over turneringer som du kan registrere deg til</p>
        <img src="https://upload.wikimedia.org/wikipedia/commons/6/6c/Input-gaming.png" id="game" alt="Logo" style="width:120px; height:120px; left: 980px; top: 55px; position: absolute;">
   </div>

   <br />
       
 <div id="logintext" runat="server"></div>

    <div id="turneringoppsett" class="container" runat="server">
    </div>

        <div id="tilevent" class="container" runat="server"></div>
    
        </asp:Content>
