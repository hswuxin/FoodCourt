<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="web.header" %>
<link href="../css/header.css" rel="stylesheet" type="text/css" />
<nav class='navbar navbar-inverse navbar-fixed-top'>
        <div class='container'>
            <div class='navbar-header'>
                <button class='navbar-toggle' type='button' data-toggle='collapse' data-target='#collapse'>
                    <span class='sr-only'>切换导航栏</span>
                    <span class='icon-bar'></span>
                    <span class='icon-bar'></span>
                    <span class='icon-bar'></span>
                </button>
                <a class='navbar-brand' href='#toppage' ><strong>FoodCourt</strong></a>
            </div>
            <div id="collapse" class="collapse navbar-collapse navbar-left">
                    <ul class="nav navbar-nav">
                        <li><a href="/default.aspx">首页</a></li>
                        <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="/NewsListModular/newslist.aspx">大千美食<b class="caret"></b></a>
                        <ul class="ul-login dropdown-menu">
                        <li><a href="/NewsListModular/newslist.aspx">美食列表</a></li>
                        <li><a href="/admin/newsmanage.aspx">美食管理</a></li>
                        </ul>
                        </li>
                        <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="/PictureListModular/picture.aspx">来点图片<b class="caret"></b></a>
                        <ul class="ul-login dropdown-menu">
                        <li><a href="/PictureListModular/picture.aspx">图片长廊</a></li>
                        <li><a href="/admin/picturemanage.aspx">图片管理</a></li>
                        </ul>
                        </li>
                        <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="/VideoListModular/video.aspx">视频点播<b class="caret"></b></a>
                        <ul class="ul-login dropdown-menu">
                        <li><a href="/VideoListModular/video.aspx">视频点播</a></li>
                        <li><a href="/admin/videomanage.aspx">视频管理</a></li>
                        </ul>
                        </li>
                    </ul>
                </div>
            <ul class="nav navbar-nav navbar-right myLogin">
                    <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#"><%=username%><b class="caret"></b></a>
                    <ul class="ul-login dropdown-menu">
                    <li id="li-login"><a href="/UserModular/login.aspx">登录</a></li>
                    <li><a href="/UserModular/register.aspx">注册</a></li>
                    <li><a href="/UserModular/changelogin.aspx">修改</a></li>
                    <li><a href="/UserModular/login.aspx?type=exit">注销</a></li>
                    </ul>
                    </li>
                    <li class="role"><span class="badge"><%=role %></span></li>
                </ul>

        </div>
    </nav>
