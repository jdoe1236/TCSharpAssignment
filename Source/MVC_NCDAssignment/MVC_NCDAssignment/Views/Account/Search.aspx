<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MVC_NCDAssignment.Models.SearchInfoModel>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Search
</asp:Content>

<asp:Content ID="indexFeatured" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">

                <h1>Search by Criminal Info</h1>

            </hgroup>

        </div>
    </section>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Criminal Info</h1>
    <br />
    Empty fields will be ignored<br />
    At least one parameter must be provided other than Sex.
    <br />
    <br />

    <span style="color: #00a300; font-weight: bold">
        <%: (string)ViewBag.SuccessMessage %>
    </span>
    <% using (Html.BeginForm())
       { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary() %>

    <table>
        <tr>
            <td style="width: 150px">
                <%--<%: Html.CheckBoxFor(m => m.HasName, htmlAttributes:   new { style="display:inline;", @class="kk97hh", itemid="_HasName"}) %>--%>
                <%: Html.LabelFor(m => m.Name) %>
            </td>
            <td>
                <%--<%: Html.TextBoxFor(m => m.Name, htmlAttributes:   new { id="TB_HasName", disabled="disabled"}) %>--%>
                <%: Html.TextBoxFor(m => m.Name) %>
            </td>
        </tr>

        <tr>
            <td>
                <%: Html.Label("Age") %>
            </td>
            <td>
                <%: Html.LabelFor(m => m.MinAge, htmlAttributes: new { style = "display:inline;" })%> <%: Html.TextBoxFor(m => m.MinAge,htmlAttributes:new { style="width:60px", @type = "number", onkeypress="return isNumberKey(event);" }) %>
                <%: Html.LabelFor(m => m.MaxAge, htmlAttributes: new { style = "display:inline;" })%> <%: Html.TextBoxFor(m => m.MaxAge,htmlAttributes:new { style="width:60px", @type = "number", onkeypress="return isNumberKey(event);" }) %>
            </td>
        </tr>

        <tr>
            <td>
                <%: Html.Label("Sex") %>
            </td>
            <td>
                <%: Html.CheckBoxFor(m => m.CanBeMale, htmlAttributes: new { style = "display:inline;", @checked="true" })%> <%: Html.LabelFor(m => m.CanBeMale, htmlAttributes: new { style = "display:inline;" })%><br />
                <%: Html.CheckBoxFor(m => m.CanBeFemale, htmlAttributes: new { style = "display:inline;" })%> <%: Html.LabelFor(m => m.CanBeFemale, htmlAttributes: new { style = "display:inline;" })%>
            </td>
        </tr>

        <tr>
            <td>
                <%: Html.Label("Height") %>
            </td>
            <td>
                <%: Html.LabelFor(m => m.MinHeight, htmlAttributes: new { style = "display:inline;" })%> <%: Html.TextBoxFor(m => m.MinHeight,htmlAttributes:new { style="width:60px", @type = "number", onkeypress="return isNumberKey(event);" }) %>
                <%: Html.LabelFor(m => m.MaxHeight, htmlAttributes: new { style = "display:inline;" })%> <%: Html.TextBoxFor(m => m.MaxHeight,htmlAttributes:new { style="width:60px", @type = "number", onkeypress="return isNumberKey(event);" }) %> &nbsp (in CM)
            </td>
        </tr>
        <tr>
            <td>
                <%: Html.Label("Weight") %>
            </td>
            <td>
                <%: Html.LabelFor(m => m.MinWeight, htmlAttributes: new { style = "display:inline;" })%> <%: Html.TextBoxFor(m => m.MinWeight,htmlAttributes:new { style="width:60px", @type = "number", onkeypress="return isNumberKey(event);" }) %>
                <%: Html.LabelFor(m => m.MaxWeight, htmlAttributes: new { style = "display:inline;" })%> <%: Html.TextBoxFor(m => m.MaxWeight,htmlAttributes:new { style="width:60px", @type = "number", onkeypress="return isNumberKey(event);" }) %> &nbsp (in KG)
            </td>
        </tr>
        <tr>
            <td>
                <%: Html.LabelFor(m => m.Nationality) %>
            </td>
            <td>
                <%: Html.TextBoxFor(m => m.Nationality) %>
            </td>
        </tr>
    </table>
    <input type="submit" value="Search" />






    <%} %>
    <br /><br /><span>NOTE : You can also use <a href="/SearchService.svc">this webservice</a> to search by any third party app/script.</span>
</asp:Content>
<asp:Content ID="scriptsContent" ContentPlaceHolderID="ScriptsSection" runat="server">
    <script type="text/javascript"><%--
        $(function () {
            $('.kk97hh').change(function () {
                if ($(this).is(':checked')) {
                    $('#TB' + $(this).attr('itemid')).removeAttr('disabled');
                } else {
                    $('#TB' + $(this).attr('itemid')).attr('disabled', 'disabled');
                }
                //document.getElementById("").disabled = false;//faster
            });
        });--%>


    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if (charCode != 46 && charCode > 31
          && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }</script>
</asp:Content>
