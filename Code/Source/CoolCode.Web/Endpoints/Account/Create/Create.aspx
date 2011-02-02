<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPages/CoolCode.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="CoolCode.Web.Endpoints.Account.Create.Create" %>
<%@ Import Namespace="CoolCode.Web.Configuration.Fubu.UI.Extensions" %>
<%@ Import Namespace="CoolCode.Web.Configuration.Fubu.UI.Profiles" %>
<%@ Import Namespace="FubuMVC.Core.UI" %>

<asp:Content ContentPlaceHolderID="Title" runat="server">
    Create a New Account
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
   <% this.Tags().SetProfile(HtmlConventionProfiles.Default); %>

   <% if (!string.IsNullOrEmpty(Model.Message)) { %>
        <div><%= Model.Message %></div>
    <% } %>

    <form action="" method="post">
        <%= this.RowFor(m => m.Username) %>
        <%= this.RowFor(m => m.Password) %>
        <%= this.RowFor(m => m.ConfirmPassword) %>
        <input type="submit" value="Create" />
    </form>
</asp:Content>
