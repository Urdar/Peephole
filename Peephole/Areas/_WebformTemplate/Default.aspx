<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Peephole.Views.Shared.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>


<asp:Content ID="DefaultMain" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <!-- START vulnerability -->
        <div class="col-sm-8 col-md-8 col-lg-8;">

            

            <h1>Heading</h1>
            Lorem ipsum dolor sit atmet

            <!-- END vulnerability -->

            <!-- START solution -->

            <h1>Solution</h1>

            <!-- END solution -->

        </div>

        <!-- START hints/sidemenu -->
       
        <div class="col-sm-4 col-md-4 col-lg-4">
            <script src="../../Scripts/jquery-1.10.2.js"> </script>
            <script type="text/javascript">
                $(document).ready(function () {
                    $('#hint-content').hide();
                    $('#checkbox1').change(function () {
                        $('#hint-content').fadeToggle();
                    });
                });
            </script>
            <input type="checkbox" id="checkbox1" />
            Show/hide hints
            <div class="hint-content" id="hint-content">
                Description and hints
            </div>
        </div>

        <!-- END hints/sidemenu -->

    </div>

</asp:Content>
