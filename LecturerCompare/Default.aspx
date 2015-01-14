<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LecturerCompare._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="container" class="container">
        <%for(var i = 0 ; i < 50; i++){ %>
        <div class="block">
            <legend>Sample Box</legend>   
            <img src="http://th07.deviantart.net/fs71/PRE/f/2011/245/5/5/sexy_teacher_by_scbr-d48lisl.jpg">
            <a class="btn btn-default" href="#">לחץ כאן להשוואה</a>
            <div class="shr_box4"></div>
            <div class="shl_box4"></div>
        </div>
        <%} %>
    </div>
    <script>
        $(document).ready(function () {
            $('#container').BlocksIt({
                numOfCol: 4,
                offsetX: 8,
                offsetY: 8,
                blockElement: '.block'
            });
        });
    </script>
</asp:Content>
