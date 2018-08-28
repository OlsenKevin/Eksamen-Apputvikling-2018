<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="administrerlag.aspx.cs" Inherits="eksamen2018.administrerlag" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    
 <div class="jumbotron">

     <h3>Lag administrasjon</h3>
     <br />
     <img src="https://upload.wikimedia.org/wikipedia/commons/6/6c/Input-gaming.png" id="game" alt="Logo" style="width:120px; height:120px; left: 980px; top: 55px; position: absolute;">

    <h4>Lagnavn</h4>
    <asp:TextBox ID="lagnavn" runat="server"></asp:TextBox>
    <br/>
   <br />

    <asp:Button ID="endrelag" runat="server" Text="Endre lag" OnClick="endrelag_Click" />
     <asp:Button ID="slettlag" runat="server" Text="Slett lag" OnClick="slettlag_Click" BackColor="#FF5050"/>
 </div>

       <div id="endrelagtext" runat="server">

 </div>
 

    <td colspan="1">

        <asp:Label ID="lblMessage" Text="&nbsp;" runat="server" />
    </td>
        </asp:Content>