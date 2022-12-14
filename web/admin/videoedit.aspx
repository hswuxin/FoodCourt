<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="videoedit.aspx.cs" Inherits="web.admin.videoedit" %>

<%@ Register Src="/AscxModular/header.ascx" TagName="head" TagPrefix="head" %>
<%@ Register Src="/AscxModular/footer.ascx" TagName="foot" TagPrefix="foot" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>美食坊-视频编辑</title>
    <link rel="shortcut icon" type="favicon.ico" href="/images/logo-red.png">
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../css/newsedit.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap-datetimepicker.css" rel="stylesheet" type="text/css" />
    <script src="../js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <script src="../js/bootstrap-datetimepicker.zh-CN.js" type="text/javascript"></script>
    <script src="/Jcrop/jquery.Jcrop.js" type="text/javascript"></script>
    <link href="/Jcrop/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <link href="../css/newsedit.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--导航栏-->
    <head:head ID="head" runat="server"></head:head>
    <div class="container editbox">
        <h2>
            视频编辑
        </h2>
        <div class="form-group myfont">
            <div class="row">
                <div class="col-md-1">
                    <h5>
                        标题
                    </h5>
                </div>
                <div class="col-md-5">
                    <asp:TextBox ID="videotitle" class="form-control col-md-12" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <h5>
                        添加时间
                    </h5>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="videoaddtime" runat="server" class="form-control form_date col-md-12"
                        placeholder="请输入时间" data-date-format="yyyy-mm-dd hh:ii:ss" data-link-field="dtp_ input2"
                        data-link-format="yyyy-mm-dd hh:ii:ss" CausesValidation="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="时间不能为空"
                        ControlToValidate="videoaddtime"></asp:RequiredFieldValidator></div>
            </div>
        </div>
        <div class="form-group myfont">
            <div class="row">
                <div class="col-md-2">
                    <h5>
                        封面
                    </h5>
                </div>
                <div class="col-md-10">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
            </div>
        </div>
        <div class="form-group myfont">
            <div class="row">
                <div class="col-md-2">
                    <h5>
                        视频
                    </h5>
                </div>
                <div class="col-md-8">
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="Button1" class="btn btn-info" runat="server" Text="提交" 
                        onclick="Button1_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                封面地址
            </div>
            <div class="col-md-1">
                <asp:Button ID="imgBtn" class="btn btn-success" runat="server" Text="上传" 
                    onclick="imgBtn_Click" />
            </div>
            <div class="col-md-1">
                <asp:Button ID="btnReset" runat="server" Text="重置" class="btn btn-info" 
                    onclick="btnReset_Click" />
            </div>
            <div class="col-md-8">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row">
                <div class="col-md-9">
                    <asp:Image ID="Imgcroped" runat="server" />
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="30px"></asp:Label>
                </div>
            </div>
            <div class="row">
                <asp:Panel ID="PnlCrop" runat="server" Visible="false">
                    <asp:Button ID="btnCrop" runat="server" Text="裁剪保存" class="btn btn-danger" 
                        onclick="btnCrop_Click"  />
                    <asp:Image ID="Imgtocrop" runat="server" />
                    <input id="XCoordinate" type="hidden" runat="server" />
                    <input id="YCoordinate" type="hidden" runat="server" />
                    <input id="Width" type="hidden" runat="server" />
                    <input id="Height" type="hidden" runat="server" />
                </asp:Panel>
            </div>
        <div class="row">
            <div class="col-md-2">
                视频地址
            </div>
            <div class="col-md-10">
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <!---->
        <div class="form-group myfont">
            <div class="row">
                <div class="col-md-6">
                    <asp:Button ID="btnupdate" class="btn btn-primary col-md-12" runat="server" 
                        Text="修改" onclick="btnupdate_Click" />
                </div>
                <div class="col-md-6">
                    <asp:Button ID="btninsert" class="btn btn-info col-md-12" runat="server" Text="新增"
                        OnClick="btninsert_Click" />
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
                allowResize: true,
                maxSize: [1280, 720],
                minSize: [500, 333],
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
