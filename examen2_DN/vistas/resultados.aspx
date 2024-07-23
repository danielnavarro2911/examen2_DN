<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/menu.Master" AutoEventWireup="true" CodeBehind="resultados.aspx.cs" Inherits="examen2_DN.vistas.resultados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Resultados</h1>
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="ganador" runat="server" Text="El partido ganador es"></asp:Label>
    <br />
    <br />
</asp:Content>
