<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="event.aspx.cs" Inherits="eksamen2018._event" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Pågående eventer</h1>
        <p class="lead">Under finner du en oversikt over eventer som du kan registrere deg til</p>
        <img src="https://upload.wikimedia.org/wikipedia/commons/6/6c/Input-gaming.png" id="game" alt="Logo" style="width:120px; height:120px; left: 980px; top: 55px; position: absolute;">
   </div>

        <div id="eventoppsett" class="container" runat="server">
    </div>
    
        </asp:Content>
