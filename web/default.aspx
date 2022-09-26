<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="web._default" %>

<%@ Register Src="/AscxModular/header.ascx" TagName="head" TagPrefix="head" %>
<%@ Register Src="/AscxModular/footer.ascx" TagName="foot" TagPrefix="foot" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>美食坊-首页</title>
    <link rel="shortcut icon" type="favicon.ico" href="/images/logo-red.png">
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="echarts/echarts.js" type="text/javascript"></script>
    <link href="css/default.css" rel="stylesheet" type="text/css" />
    <script src="echarts/china.js" type="text/javascript"></script>
    <link href="css/search.css" rel="stylesheet" type="text/css" />
    <link href="fonts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--导航栏-->
    <head:head ID="head" runat="server"></head:head>
    <!--搜索框-->
    <div class="container mysearch-box">
        <div class="input-group input-group-lg mysearch">
            <asp:TextBox ID="SearchBox" class="form-control" runat="server" placeholder="搜索内容"
                aria-describedby="basic-addon2"></asp:TextBox>
            <span class="input-group-addon" id="basic-addon2" style="padding: 8px 14px 8px 14px">
                <asp:Button ID="toSearch" runat="server" Text="搜索" OnClick="toSearch_Click" />
            </span>
        </div>
    </div>
    <!--轮播图-->
    <div class="container mycarousel">
        <div id="carousel-example-generic" class="carousel slide carousel-img" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                <li data-target="#carousel-example-generic" data-slide-to="2"></li>
            </ol>
            <!-- Wrapper for slides -->
            <div class="carousel-inner " role="listbox">
                <%=CarouselString %>
            </div>
            <!-- Controls -->
            <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span><span class="sr-only">
                    Previous</span> </a><a class="right carousel-control" href="#carousel-example-generic"
                        role="button" data-slide="next"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true">
                        </span><span class="sr-only">Next</span> </a>
        </div>
    </div>
    <!--ecahts地图投影-->
    <div class="container mymap">
        <div class="row">
            <div class="col-lg-4 col-md-5 col-sm-6  col-xs-12 mycahrts-box" id="mycahrts">
            </div>
            <div class=" col-lg-8 col-md-7 col-sm-6  col-xs-12 chartnewslist table-responsive">
                <div class="row ">
                    <div class="col-md-10 col-sm-8 col-xs-6">
                        <h2>
                            新鲜速递
                        </h2>
                    </div>
                    <div class="col-md-2 col-sm-4 col-xs-6 center">
                        <a href="/NewsListModular/newslist.aspx" class="chartMore">更多</a><span class="glyphicon glyphicon-chevron-right"
                            style="color: Silver"></span>
                    </div>
                </div>
                <table class="table table-hover mytable">
                    <asp:ListView ID="ChartsList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <a class="ChartsListurl" href="/NewsListModular/newscontent.aspx?id=<%#Eval("NewsID") %>">
                                        <%#Eval("NewsTitle") %></a>
                                </td>
                                <td>
                                    <%#Eval("NewsCuisines") %>
                                </td>
                                <td>
                                    <%#Eval("NewsProvince") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
    </div>
    <!--后台数据-->
    <div class="container mybody">
        <div class="row">
            <div class="col-md-3">
                <div class="mybox1 row">
                    <div class="col-md-4 col-xs-4 col-sm-4 myicon">
                        <i class="fa fa-refresh fa-spin" style="font-size: 24px; color: #000;"></i>
                    </div>
                    <div class="col-md-8 col-xs-8 col-sm-8" style="position: relative;">
                        <h4 style="position: absolute; color: rgb(1, 1, 1); font-weight: 800; margin-top: 30px;">
                            <%=usernumber %>
                        </h4>
                        <h5 style="color: #000; font-weight: 500;margin-top: 50px;position: absolute;">注册人数</h5>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="mybox1 row">
                    <div class="col-md-4 col-xs-4 col-sm-4 myicon">
                        <i class="fa fa-circle-o-notch fa-spin" style="font-size: 24px; color: #000;"></i>
                    </div>
                    <div class="col-md-8 col-xs-8 col-sm-8" style="position: relative;">
                        <h4 style="position: absolute; color: rgb(1, 1, 1); font-weight: 800; margin-top: 30px;">
                            <%=newsnumber %>
                        </h4>
                        <h5 style="color: #000; font-weight: 500; margin-top: 50px;position: absolute;">收录菜品</h5>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="mybox1 row">
                    <div class="col-md-4 col-xs-4 col-sm-4 myicon">
                        <i>
                            <i class="fa fa-spinner fa-spin" style="font-size: 24px; color: #000;"></i>
                        </i>
                    </div>
                    <div class="col-md-8 col-xs-8 col-sm-8" style="position: relative;">
                        <h4 style="position: absolute; color: rgb(1, 1, 1); font-weight: 800; margin-top: 30px;">
                            <%=onlinenumber %>
                        </h4>
                        <h5 style="color: #000; font-weight: 500; margin-top: 50px;position: absolute;">在线人数</h5>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="mybox1 row">
                    <div class="col-md-4 col-xs-4 col-sm-4 myicon">
                        <i>
                            <i class="fa fa-cog fa-spin" style="font-size: 24px; color: #000;"></i>
                        </i>
                    </div>
                    <div class="col-md-8 col-xs-8 col-sm-8" style="position: relative;">
                        <h4 style="position: absolute; color: rgb(1, 1, 1); font-weight: 800; margin-top: 30px;">
                            <%=visitednumber%>
                        </h4>
                        <h5 style="color: #000; font-weight: 500;margin-top: 50px;position: absolute;">访问人数</h5>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--底部导航-->
    <foot:foot ID="foot" runat="server"></foot:foot>
    </form>
    <script>
        var chartDom = document.getElementById('mycahrts');
        var myChart = echarts.init(chartDom);
        var option;

        option = {
            title:{
            left: "center",
            top: "10%",
            text:'已收录菜系数量'
            },
            tooltip: {
                trigger: 'item'
            },
            legend: {
                top: '25%',
                left: 'center'
            },
            series: [
    {
        name: '菜系',
        type: 'pie',
        radius: ['40%', '70%'],
        avoidLabelOverlap: false,
        itemStyle: {
            borderRadius: 10,
            borderColor: '#fff',
            borderWidth: 2
        },
        label: {
            show: false,
            position: 'center'
        },
        emphasis: {
            label: {
                show: true,
                fontSize: '40',
                fontWeight: 'bold'
            }
        },
        labelLine: {
            show: false
        },
        top:'25%',
        data: [
        <%=chartsstring %>
      ]
    }
  ]
        };

        option && myChart.setOption(option);
    </script>
</body>
</html>
