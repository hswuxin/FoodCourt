<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="web.UserModular.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>美食坊-用户登录</title>
    <link rel="/shortcut icon" type="favicon.ico" href="/images/logo-red.png">
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="/css/login.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrapValidator.css" rel="stylesheet" type="text/css" />
    <script src="../js/bootstrapValidator.js" type="text/javascript"></script>
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
                                stringLength: {
                                    min: 6,
                                    max: 30,
                                    message: '用户名长度不可低于6字符或高于30字符!'
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

                        ages: {
                            validators: {
                                notEmpty: {
                                    message: '年龄不能为空！'
                                },
                                lessThan: {
                                    value: 100,
                                    inclusive: true,
                                    message: '输入的年龄必须小于100岁！'
                                },
                                greaterThan: {
                                    value: 10,
                                    inclusive: false,
                                    message: '输入的年龄必须大于10岁！'
                                }
                            }
                        }
                    }
                });
            });
    </script>
</head>
<body>
    <div class="background-login">
        <div class="container">
            <div class="row center">
                <div class="login-box login-title">
                    <form id="form1" method="post" runat="server">
                    <h2>
                        登录
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
                                required TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="pull-right">
                            <a href="/UserModular/register.aspx">注册</a>
                        </div>
                    </div>
                    <div class="form-group login-btn">
                        <div class="input-group col-xs-12">
                            <asp:Button ID="submit" runat="server" Text="登录" class="btn btn-primary col-xs-12"
                                OnClick="submit_Click" />
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
