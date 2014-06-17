﻿<%@ Page Title="Перегляд групи ЕІР" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IrGroupView.aspx.cs" Inherits="Site.EIR.IrGroup.IrGroupView" %>

<asp:Content ID="GroupViewContent" ContentPlaceHolderID="body" runat="server">
    
    <div class="page-header">
        <h1><%=Page.Title %></h1>
        <h2 id="group_name" runat="server"></h2>

    </div>

    <asp:Button ID="add_ir" runat="server" Text="Додати ЕІР" CssClass="btn btn-warning" ClientIDMode="Static" />
    <asp:Button ID="edit" runat="server" Text="Редагувати" CssClass="btn btn-warning" ClientIDMode="Static" OnClick="EditGroup_Click" />

    <asp:Panel ID="LinkContainer" runat="server">
        <div id="out_json" runat="server"></div>
    </asp:Panel>

</asp:Content>
