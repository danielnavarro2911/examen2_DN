<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/menu.Master" AutoEventWireup="true" CodeBehind="partidos.aspx.cs" Inherits="examen2_DN.vistas.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registrar partido politico</h1>
    <asp:Label ID="lmensaje" runat="server" Text="Label"></asp:Label>
    <br />
    Partido Politico:
    <asp:TextBox ID ="partido" runat="server"></asp:TextBox>

    Nombre Candidato:

    <asp:TextBox ID ="candidato" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="agregarpartido" runat="server" Text="Agregar" OnClick="agregarpartido_Click" />
    <br />
    <asp:Button ID="borrarpartido" runat="server" Text="Borrar" OnClick="borrarpartido_Click" />

    <br />
    <br />
    Partidos Disponibles:
    <br />
&nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" Height="135px" Width="227px">
    </asp:GridView>
    <br />
    <asp:Label ID="error_partido" runat="server"></asp:Label>
    <br />
    <br />
    <br />
    <br />
    <br />  

</asp:Content>
