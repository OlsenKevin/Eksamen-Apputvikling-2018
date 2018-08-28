<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="logginn.aspx.cs" Inherits="eksamen2018.logginn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">

         <h3>Logg inn med brukernavn og passord</h3>

            <img src="https://upload.wikimedia.org/wikipedia/commons/6/6c/Input-gaming.png" id="game" alt="Logo" style="width:120px; height:120px; left: 980px; top: 55px; position: absolute;">

         <div class='form-group'>

            <asp:TextBox ID="t1" runat="server" class='form-control' placeholder='Brukernavn' OnTextChanged="t1_TextChanged"></asp:TextBox>

            <asp:TextBox ID="t2" runat="server" class='form-control' placeholder='Passord' OnTextChanged="t2_TextChanged" TextMode="Password"></asp:TextBox>

          </div>
  

         <asp:Button ID="Button1" class='btn btn-primary' runat="server" OnClick="Button1_Click" Text="Logg inn" />
         <br />
         <br />

         <h5> <a href="registrerbruker.aspx">Registrer bruker</a></h5>

         <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>

       <div id="logintext" runat="server">
 </div>


     <p> 
         &nbsp;</p>
     <p>&nbsp;</p>
     <p>&nbsp;</p>
  
 
 

</asp:Content>
