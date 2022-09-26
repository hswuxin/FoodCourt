<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newslist.aspx.cs" Inherits="web.ListModular.newslist" %>

<%@ Register Src="/AscxModular/header.ascx" TagName="head" TagPrefix="head" %>
<%@ Register Src="/AscxModular/footer.ascx" TagName="foot" TagPrefix="foot" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>美食坊-更多美食</title>
    <link rel="shortcut icon" type="favicon.ico" href="/images/logo-red.png">
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../css/newlist.css" rel="stylesheet" type="text/css" />
    <link href="../css/search.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--导航栏-->
    <head:head ID="head" runat="server"></head:head>
    <!--搜索框-->
    <div class="container mysearch-box">
        <div class="input-group input-group-lg mysearch">
            <asp:TextBox ID="SearchBox" class="form-control" runat="server" placeholder="您要查找的标题"
                aria-describedby="basic-addon2"></asp:TextBox>
            <span class="input-group-addon" id="basic-addon2" style="padding: 8px 14px 8px 14px">
                <asp:Button ID="SearchBtn" runat="server" Text="搜索" OnClick="SearchBtn_Click" /></span>
        </div>
    </div>
    <div class="container selectbox">
        <div class="row">
            <div class="col-md-3 col-xs-3">
                <asp:Button ID="All" runat="server" Text="全部" class="btn btn-default" 
                    onclick="All_Click" />
            </div>
            <div class="col-md-3 col-xs-3">
                <asp:Button ID="Stir" runat="server" Text="炒菜" class="btn btn-primary " 
                    onclick="Stir_Click" />
            </div>
            <div class="col-md-3 col-xs-3">
                <asp:Button ID="Cook" runat="server" Text="煮菜" class="btn btn-success" 
                    onclick="Cook_Click" />
            </div>
            <div class="col-md-3 col-xs-3">
                <asp:Button ID="Stew" runat="server" Text="炖菜" class="btn btn-info" 
                    onclick="Stew_Click" />
            </div>
        </div>
    </div>
    <!--newslist-->
    <div class="container listimgbox">
        <div class="row newcontent">
            <%=ListString %>
        </div>
    </div>
    </form>
    <!--底部导航-->
    <foot:foot ID="foot" runat="server"></foot:foot>
</body>
</html>
