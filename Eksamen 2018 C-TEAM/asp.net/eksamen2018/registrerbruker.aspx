<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registrerbruker.aspx.cs" Inherits="eksamen2018._registrerbruker" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">

         <h3>Registrer bruker</h3>

            <img src="https://upload.wikimedia.org/wikipedia/commons/6/6c/Input-gaming.png" id="game" alt="Logo" style="width:120px; height:120px; left: 980px; top: 55px; position: absolute;">

         <div class='form-group'>

            <asp:TextBox ID="brukernavn" runat="server" class='form-control' placeholder='Brukernavn'></asp:TextBox>

            <asp:TextBox ID="passord" runat="server" class='form-control' placeholder='Passord' TextMode="Password"></asp:TextBox>

          </div>
  

         <asp:Button ID="registrerbrukerknapp" class='btn btn-primary' runat="server" OnClick="Registrerbruker_Click" Text="Registrer" />
         <br />
         <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
              <h5> <a href="logginn.aspx">Logg inn</a></h5>
        </div>

      

       <div id="registrerbrukertext" runat="server">
 </div>


     <p> 
         &nbsp;</p>
     <p>&nbsp;</p>
     <p>&nbsp;</p>
  
 
 

</asp:Content>

