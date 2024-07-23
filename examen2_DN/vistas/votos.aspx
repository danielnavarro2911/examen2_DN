<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/menu.Master" AutoEventWireup="true" CodeBehind="votos.aspx.cs" Inherits="examen2_DN.vistas.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registrar votos</h1>
    <br />
    <asp:DropDownList ID="ddlPartidos" runat="server"></asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="Bregistrar_voto" runat="server" Text="Registrar Voto" OnClick="Bregistrar_voto_Click" />
    <br />

    <br />
&nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" Height="135px" Width="227px">
    </asp:GridView>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />  


</asp:Content>
