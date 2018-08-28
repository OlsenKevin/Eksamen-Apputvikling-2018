<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="visdeltager.aspx.cs" Inherits="eksamen2018.visdeltager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


 <div class="jumbotron">


    <h1>Endre deltagere</h1>

     <img src="https://upload.wikimedia.org/wikipedia/commons/6/6c/Input-gaming.png" id="game" alt="Logo" style="width:120px; height:120px; left: 980px; top: 55px; position: absolute;">

    <h3><asp:Label ID="labelLag" runat="server" Text=""></asp:Label></h3>
     <h3>Velg spiller</h3>

     </div>
   <div id="registrerspiller" runat="server"></div>
    <br />
     <div id="deltagere" class="container" runat="server"></div>

     <div id="feilspillere" runat="server"></div>    
    
    <td colspan="1">

  
    </td>

    <div id="tilminelag" runat="server"></div>    




        </asp:Content>