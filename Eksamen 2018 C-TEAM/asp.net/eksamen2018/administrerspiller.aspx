<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="administrerspiller.aspx.cs" Inherits="eksamen2018.administrerspiller" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    
 <div class="jumbotron">

     <h3>Endre informasjon om spiller</h3>

  <img src="https://upload.wikimedia.org/wikipedia/commons/6/6c/Input-gaming.png" id="game" alt="Logo" style="width:120px; height:120px; left: 980px; top: 55px; position: absolute;">

    <h4>Fornavn</h4>
    <asp:TextBox ID="fornavn" runat="server"></asp:TextBox>
    <br/>

    <h4>Etternavn</h4>
    <asp:TextBox ID="etternavn" runat="server"></asp:TextBox>
    <br/>

    <h4>Nick name</h4>
    <asp:TextBox ID="nickname" runat="server"></asp:TextBox>
    <br/>

    <h4>Velg Nasjon</h4>
    <asp:DropDownList ID="nasjonlist" runat="server" AutoPostBack="True"></asp:DropDownList>
     <br/>

    <asp:Button ID="endredeltager" runat="server" Text="Endre deltager" OnClick="endredeltager_Click" />
     <asp:Button ID="slettedeltager" runat="server" Text="Slette deltager" OnClick="slettedeltager_Click" BackColor="#FF5050"/>

 </div>
       <div id="redigerspillertext" runat="server">

 </div>
 

    <td colspan="1">

        <asp:Label ID="lblMessage" Text="&nbsp;" runat="server" />
    </td>
        </asp:Content>