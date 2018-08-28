<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registrertelag.aspx.cs" Inherits="eksamen2018.registrertelag" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


 <div class="jumbotron">


    <h1>Registrerte lag</h1>

     <img src="https://upload.wikimedia.org/wikipedia/commons/6/6c/Input-gaming.png" id="game" alt="Logo" style="width:120px; height:120px; left: 980px; top: 55px; position: absolute;">

    <h3><asp:Label ID="labelLag" runat="server" Text=""></asp:Label></h3>
      <h3>Under finner du en oversikt over alle lag med registrerte spillere</h3>
      
     </div>
        
    <div id="tilturnering" class="container" runat="server"></div>
   <br />
     <div id="pameldtelag" class="container" runat="server"></div>
        
    <td colspan="1">

        <asp:Label ID="lblMessage" Text="&nbsp;" runat="server" />
    </td>

    




        </asp:Content>