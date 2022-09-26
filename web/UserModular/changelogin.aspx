<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changelogin.aspx.cs" Inherits="web.UserModular.changelogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>美食坊-修改信息</title>
    <link rel="/shortcut icon" type="favicon.ico" href="/images/logo-red.png">
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="/css/login.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrapValidator.css" rel="stylesheet" type="text/css" />
    <script src="../js/bootstrapValidator.js" type="text/javascript"></script>
    <link href="../css/register.css" rel="stylesheet" type="text/css" />
    <link href="../css/changelogin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
            $(document).ready(function () {
                $('#form1').bootstrapValidator({
                    message: '请输入正确的登陆信息!',
                    feedbackIcons: {
                        valid: 'glyphicon glyphicon-ok',
                        invalid: 'glyphicon glyphicon-remove',
                        validating: 'glyphicon glyphicon-refresh'
                    },
                    fields: {
                        username: {
                            message: '您输入的用户名不正确!',
                            validators: {
                                notEmpty: {
                                    message: 
                                },
                                regexp: {
                                    regexp: /^[\.\w\u4e00-\u9fa5]+$/gi,
                                    message: '用户名只可包含字母、数字、下划线！'
                                }
                            }
                        },

                        password: {
                            validators: {
                                notEmpty: {
                                    message: '密码不能为空！'
                                },
                                identical: {
                                    field: 'confirmPassword',
                                    message: '您输入的密码和确认的密码不相同！'
                                }
                            }
                        },
                         telenumber: {
                        validators: {
                            notEmpty: {
                                message: '联系方式不能为空！'
                            },
                            regexp:/^1\d{10}$/,
                            message:'请输入11为手机号码！'
                        }
                    },
                });
            });
    </script>
</head>
<body>
    <div class="background-login">
        <div class="container">
            <div class="register-row register-center">
                <div class="register-box register-title">
                    <form id="form1" method="post" runat="server">
                    <h2>
                        信息修改
                    </h2>
                    <div class="form-group" class="form-horizontal">
                        <label class="col-xs-3 login-label">
                            用户名</label>
                        <div class="input-group col-xs-9">
                            <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                            <asp:TextBox ID="Username" class="form-control" name="username" runat="server" placeholder="请输入用户名"
                                required></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-3 login-label">
                            密&nbsp;&nbsp;&nbsp;码</label>
                        <div class="input-group col-xs-9">
                            <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                            <asp:TextBox ID="Password" class="form-control" name="password" runat="server" placeholder="请输入密码"
                                required></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" class="form-horizontal">
                        <label class="col-xs-3 login-label">
                            城&nbsp;&nbsp;&nbsp;市</label>
                        <div class="input-group col-xs-9">
                            <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                            <asp:TextBox ID="City" class="form-control" runat="server" placeholder="请输入城市"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" class="form-horizontal">
                        <label class="col-xs-3 login-label">
                            电话号码</label>
                        <div class="input-group col-xs-9">
                            <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                            <asp:TextBox ID="TelNumber" class="form-control" runat="server" placeholder="请输入电话号码"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 register-warning-box">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="请输入正确的号码"
                            ControlToValidate="TelNumber" ValidationExpression="^1(3[0-9]|5[012356789]|7[1235678]|8[0-9])\d{8}$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-3 login-label">
                            头&nbsp;&nbsp;&nbsp;像</label>
                        <asp:Button ID="imgSubmit" class="col-md-3 col-xs-3 btn btn-info" runat="server" Text="上传"
                            OnClick="imgSubmit_Click" />
                        <div class="col-md-3 col-xs-3">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                        <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12 col-xs-12" style="text-align:right">
                            <a href="/UserModular/login.aspx">登录</a>
                        </div>
                    </div>
                    <div class="form-group changelogin-btn">
                        <div class="col-md-6 col-xs-6">
                            <asp:Button ID="submit" runat="server" Text="确定" class="btn btn-primary col-md-4 col-xs-6 form-control"
                                OnClick="submit_Click" />
                        </div>
                        <div class="col-md-6 col-xs-6">
                            <a class="btn btn-primary btn-block col-md-4 col-xs-6" href="/default.aspx">返回</a>
                        </div>
                    </div>
                    <div class="warning-box">
                        <asp:Label ID="warning" runat="server" Text=""></asp:Label>
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
