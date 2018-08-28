<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="minelag.aspx.cs" Inherits="eksamen2018.minelag" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


 <div class="jumbotron">


    <h1>Mine lag</h1>

     <img src="https://upload.wikimedia.org/wikipedia/commons/6/6c/Input-gaming.png" id="game" alt="Logo" style="width:120px; height:120px; left: 980px; top: 55px; position: absolute;">

    <h3><asp:Label ID="labelLag" runat="server" Text=""></asp:Label></h3>
     <h3>Under ser du en oversikt lagene. Velg lag for å se spillere som er registrerte til laget. osv....</h3>
     </div>

         <div id="eventoppsett" class="container" runat="server">
            
    </div>

      
     <div id="minelagtext" runat="server">

     </div>
    <td colspan="1">

  
    </td>
  
    




        </asp:Content>