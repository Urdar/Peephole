<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="peephole._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--
    <div class="jumbotron">
        <h1>Peephole Bank</h1>
        <p class="lead">Peephole bank is an internet-based bank. We save money so that you get the best interest and the best customer support.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Read more about Peephole Bank &raquo;</a></p>
    </div>-->

    <!-- 1. Link to jQuery (1.8 or later), -->
    <script src="Scripts/jquery/1.11.1/jquery.min.js"></script>
    <!-- 33 KB -->
    <header>
    <script src="<%=ResolveUrl("~/Scripts/fotorama.js")%>"></script>
    <link href="<%=ResolveUrl("~/Content/fotorama.css")%>" rel="stylesheet">
    </header>

    <div class="fotorama"
        data-fit="cover"
        data-width="100%"
        data-height="30%"
        data-autoplay="true"
        data-arrows="true"
        data-click="true"
        data-keyboard="true">
        <!-- All images is under the CC0 license and is retrieved from http://negativespace.co/ -->
        <a href="/img/bank1.jpg">test</a>
        <a href="/img/bank2.jpg">test</a>
        <a href="/img/bank3.jpg">test</a>
        <a href="/img/bank4.jpg">test</a>
    </div>



    <div class="row">
        <div class="col-md-4">
            <h3>Become a customer</h3>
            <p>
                If you are under 34 years old, we could provide you with the best interest in the market. You keep the low interest for the rest of your life, as you long as don't change the loan agreement. Become a customer of Peephole bank today!
            </p>
            <p>
                <a class="btn btn-default" href="/Areas/login/register">Become a customer &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h3>Contact one of our employees</h3>
            <p>
                We have several employees that we year of experience. Please send us an mail or contact one of our fanastic employees!
            </p>
            <p>
                <a class="btn btn-default" href="/Areas/Employee/Search">Our employees &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h3>Our customers</h3>
            <p>
                "I moved my loan and my saving to Peephole Bank - From that day forward I've had only positive experience with banking. Good interest and good customer support"
            </p>
            <p>
                <a class="btn btn-default" href="/Feedback/Comment/Comments">What other customers are saying &raquo;</a>
            </p>
        </div>
    </div>




</asp:Content>
