<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home
</asp:Content>

<asp:Content ID="indexFeatured" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                Please login or register
            </hgroup>

        </div>
    </section>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>This is public web site for finding the criminals of nation, please <%: Html.ActionLink("Log in", "Login", "Account", routeValues: null, htmlAttributes: new { id = "loginLink" })%> to continue. If you're a new user, please <%: Html.ActionLink("Register", "Register", "Account", routeValues: null, htmlAttributes: new { id = "registerLink" })%>.</h3>

</asp:Content>
<asp:Content ID="scriptsContent" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
