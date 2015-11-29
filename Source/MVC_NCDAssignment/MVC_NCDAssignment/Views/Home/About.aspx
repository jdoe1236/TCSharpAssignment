<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About - National Criminals Database
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>About</h1>        
    </hgroup>

    <article>
        <p>
            This site is for real.
        </p>

        
    </article>

    <aside>
        <h3>This is title</h3>
        <p>
            Additional information.
        </p>
        <ul>
            <li><%: Html.ActionLink("Home", "Index", "Home") %></li>
            <li><%: Html.ActionLink("About", "About", "Home") %></li>
            <li><%: Html.ActionLink("Contact", "Contact", "Home") %></li>
        </ul>
    </aside>
</asp:Content>