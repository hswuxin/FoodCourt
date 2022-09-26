<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" Inherits="web.admin.NewsEdit" %>

<%@ Register Src="/AscxModular/header.ascx" TagName="head" TagPrefix="head" %>
<%@ Register Src="/AscxModular/footer.ascx" TagName="foot" TagPrefix="foot" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>美食坊-文章编辑</title>
    <link rel="shortcut icon" type="favicon.ico" href="/images/logo-red.png">
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../css/newsedit.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap-datetimepicker.css" rel="stylesheet" type="text/css" />
    <script src="../js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <script src="../js/bootstrap-datetimepicker.zh-CN.js" type="text/javascript"></script>
    <link href="../kindeditor/themes/simple/simple.css" rel="stylesheet" type="text/css" />
    <script src="../kindeditor/kindeditor-all-min.js" type="text/javascript"></script>
    <script src="../kindeditor/lang/zh-CN.js" type="text/javascript"></script>
    <script src="/Jcrop/jquery.Jcrop.js" type="text/javascript"></script>
    <link href="/Jcrop/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
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
                        userName: {
		          validators: {
		            notEmpty: {
		              message: '不能为空'
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
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor1 = K.create('#NewsContent', {
                cssPath: '../kindeditor/plugins/code/prettify.css',
                uploadJson: '../kindeditor/asp.net/upload_json.ashx',

                fileManagerJson: '../kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                cssPath: "../kindeditor/picture.css",
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!--导航栏-->
    <head:head ID="head" runat="server"></head:head>
    <div class="container editbox">
        <h2>
            <span class="glyphicon glyphicon-th-large"></span>文章编辑
        </h2>
        <div class="form-group myfont">
            <div class="row">
                <div class="col-md-1">
                    <h5>
                        标题
                    </h5>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="NewsTitle" runat="server" class="form-control" name="username" required
                        placeholder="请输入新闻标题"></asp:TextBox>
                </div>
                <div class="col-md-1">
                    <h5>
                        菜系
                    </h5>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="NewsCuisines" runat="server" class="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="addCuisine" runat="server" class="form-control" placeholder="新增菜系"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="addCuisineBtn" runat="server" class="btn btn-info" Text="新增菜系" OnClick="addCuisineBtn_Click" />
                </div>
            </div>
        </div>
        <!---->
        <div class="form-group myfont">
            <div class="row">
                <div class="col-md-1">
                    <h5>
                        作者
                    </h5>
                </div>
                <div class="col-md-5">
                    <asp:TextBox ID="NewsAuthor" runat="server" class="form-control" name="username"
                        required placeholder="请输入作者"></asp:TextBox>
                </div>
                <div class="col-md-1">
                    <h5>
                        省份
                    </h5>
                </div>
                <div class="col-md-5">
                    <asp:TextBox ID="NewsProvince" runat="server" class="form-control" name="username"
                        required placeholder="请输入省份"></asp:TextBox>
                </div>
            </div>
        </div>
        <!---->
        <div class="form-group myfont">
            <div class="row">
                <div class="col-md-1">
                    <h5>
                        分类
                    </h5>
                </div>
                <div class="col-md-5">
                    <asp:TextBox ID="NewsClass" runat="server" class="form-control" name="username" required
                        placeholder="请输入作者"></asp:TextBox>
                </div>
                <div class="col-md-1">
                    <h5>
                        日期
                    </h5>
                </div>
                <div class="col-md-5">
                    <asp:TextBox ID="NewsAddTime" runat="server" class="form-control form_date" name="username"
                        required placeholder="请输入时间" data-date-format="yyyy-mm-dd hh:ii:ss" data-link-field="dtp_ input2"
                        data-link-format="yyyy-mm-dd hh:ii:ss"></asp:TextBox>
                </div>
            </div>
        </div>
        <!---->
        <div class="form-group myfont">
            <div class="row">
                <div class="col-md-1">
                    <h5>
                        缩略图
                    </h5>
                </div>
                <div class="col-md-1">
                    <asp:Button ID="imgBtn" class="btn btn-success" runat="server" Text="上传" OnClick="imgBtn_Click" />
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnReset" runat="server" Text="重置" class="btn btn-info" OnClick="btnReset_Click" />
                </div>
                <div class="col-md-9">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-9">
                    <asp:Image ID="Imgcroped" runat="server" />
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="30px"></asp:Label>
                </div>
            </div>
            <div class="row">
                <asp:Panel ID="PnlCrop" runat="server" Visible="false">
                    <asp:Button ID="btnCrop" runat="server" Text="裁剪保存" class="btn btn-danger" OnClick="btnCrop_Click" />
                    <asp:Image ID="Imgtocrop" runat="server" />
                    <input id="XCoordinate" type="hidden" runat="server" />
                    <input id="YCoordinate" type="hidden" runat="server" />
                    <input id="Width" type="hidden" runat="server" />
                    <input id="Height" type="hidden" runat="server" />
                </asp:Panel>
            </div>
            <div class="row">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <!---->
        <div class="form-group myfont">
            <div class="row">
                <div class="col-md-1">
                    <h5>
                        内容
                    </h5>
                </div>
                <div class="col-md-11">
                    <asp:TextBox ID="NewsContent" runat="server" class="form-control" placeholder="请输入内容"
                        TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
        </div>
        <!---->
        <div class="form-group myfont">
            <div class="row">
                <div class="col-md-6">
                    <asp:Button ID="update" class="col-md-12 col-xs-6 btn btn-primary" runat="server"
                        Text="修改" OnClick="update_Click" />
                </div>
                <div class="col-md-6">
                    <asp:Button ID="insert" class="col-md-12 col-xs-6 btn btn-info " runat="server" Text="新增"
                        OnClick="insert_Click" />
                </div>
            </div>
        </div>
    </div>
    </form>
    <!--底部导航-->
    <foot:foot ID="foot" runat="server"></foot:foot>
    <script type="text/javascript">
        $('.form_date').datetimepicker({
            language: 'zh-CN',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=Imgtocrop.ClientID%>').Jcrop({
                allowResize: false,
                maxSize: [690, 390],
                minSize: [690, 390],
                onSelect: getAreaToCrop
            });
        });
        function getAreaToCrop(c) {
            $('#XCoordinate').val(parseInt(c.x));
            $('#YCoordinate').val(parseInt(c.y));
            $('#Width').val(parseInt(c.w));
            $('#Height').val(parseInt(c.h));
        }
    </script>
</body>
</html>
