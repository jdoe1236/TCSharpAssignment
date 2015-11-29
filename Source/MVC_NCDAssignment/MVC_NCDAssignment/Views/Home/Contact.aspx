<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="contactTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Contact - National Criminals Database
</asp:Content>

<asp:Content ID="contactContent" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Contact</h1>        
    </hgroup>
    <section class="contact">
        <header>
            <h3>Phone:</h3>
        </header>
        <p>
            <span class="label">Main:</span>
            <span>1800-0003-1234</span>
        </p>
        <p>
            <span class="label">After Hours:</span>
            <span>1800-PLEASE-DONT</span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span class="label">Support:</span>
            <span><a href="mailto:Support@example.com">Support@Blah.com</a></span>
        </p>
        <p>
            <span class="label">Marketing:</span>
            <span><a href="mailto:Marketing@example.com">Marketing@Blah.com</a></span>
        </p>
        <p>
            <span class="label">General:</span>
            <span><a href="mailto:General@example.com">General@Blah.com</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Address:</h3>
        </header>
        <p>
           345, Blah blah road,<br />
            Blah blah city, 99999
        </p>
    </section>
</asp:Content>