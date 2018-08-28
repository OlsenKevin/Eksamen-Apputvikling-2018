<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registrerdeltager.aspx.cs" Inherits="eksamen2018.registrerdeltager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



     <div class="jumbotron">

         <h3>Registrer deltagere til lagene</h3>

         <img src="https://upload.wikimedia.org/wikipedia/commons/6/6c/Input-gaming.png" id="game" alt="Logo" style="width:120px; height:120px; left: 980px; top: 55px; position: absolute;">

         <h4>Velg lag</h4>
         <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="Page_Load"></asp:DropDownList>
         <br/>

        <h4>Fornavn</h4>
        <asp:TextBox ID="fornavn" runat="server" OnTextChanged="Page_Load"></asp:TextBox>
        <br/>

        <h4>Etternavn</h4>
        <asp:TextBox ID="etternavn" runat="server" OnTextChanged="Page_Load"></asp:TextBox>
        <br/>

        <h4>Nick name</h4>
        <asp:TextBox ID="nickname" runat="server" OnTextChanged="Page_Load"></asp:TextBox>
        <br/>

        <h4>Velg Nasjon</h4>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Page_Load"></asp:DropDownList>
         <br/>


        <asp:Button ID="registrerspiller" runat="server" Text="Registrer spiller" OnClick="registrerspiller_Click" />
     </div>
           <div id="registrerlagtext" runat="server">

     </div>


        <td colspan="1">

            <asp:Label ID="lblMessage" Text="&nbsp;" runat="server" />
        </td>
            </asp:Content>