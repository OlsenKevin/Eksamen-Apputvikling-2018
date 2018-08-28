<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registrerlag.aspx.cs" Inherits="eksamen2018.registrerlag" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


 <div class="jumbotron">


        <h1>Registrer av lag</h1>
        <p class="lead">Under kan du registrer lag </p>

     <img src="https://upload.wikimedia.org/wikipedia/commons/6/6c/Input-gaming.png" id="game" alt="Logo" style="width:120px; height:120px; left: 980px; top: 55px; position: absolute;">

        <asp:TextBox id="lagnavn" class='form-control' placeholder='Lag navn' runat="server"></asp:TextBox>
        <br />
        <asp:button type='button' id='lagknapp' class='btn btn-primary' text='Registrer lag' OnClick="Registrerlag_Click" runat='server'></asp:button>
   </div>

   <div id="registrerlagtext" runat="server">

 </div>

        <td colspan="1">
        <asp:Label ID="lblMessage" Text="&nbsp;" runat="server" />
    </td>

        <div id="eventoppsett" class="container" runat="server">
    </div>

    




        </asp:Content>