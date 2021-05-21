<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exam.aspx.cs" Inherits="TestDemo.Exam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Exam Page</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap-grid.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-reboot.min.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_col" role="main">
            <div class="" style="margin: auto">
                <div class="page-title">
                    <div style="margin-left: auto; margin-right: auto; text-align: center;">
                        <h2>Exam Page</h2>
                        <div style="text-align: right; margin-right: 10px; margin-top: 1px">
                            <asp:Button ID="btnLogout" runat="server" class="btn btn-primary" Text="Logout" ValidationGroup="reqSubValid" OnClick="btnLogout_Click" />
                        </div>
                        <br />
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_content" style="margin-left: 10px">
                                <div class="form-group">
                                    <label runat="server" id="lblQNumber"></label>
                                    <label runat="server" id="lblQuestion"></label>

                                </div>
                                <br />

                                <div class="form-group">
                                    <asp:RadioButton ID="rboption1" GroupName="Options" runat="server" value="1" /><br />
                                    <asp:RadioButton ID="rboption2" GroupName="Options" runat="server" value="2" /><br />
                                    <asp:RadioButton ID="rboption3" GroupName="Options" runat="server" value="3" /><br />
                                    <asp:RadioButton ID="rboption4" GroupName="Options" runat="server" value="4" />

                                </div>
                                <div class="ln_solid"></div>
                                <div class="form-group col-3">
                                    <asp:Button ID="btnNext" runat="server" class="btn btn-primary" Text="Next" ValidationGroup="reqSubValid" OnClick="btnNext_Click" />&nbsp;
                                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="Submit" ValidationGroup="reqSubValid" OnClick="btnSubmit_Click" />
                                </div>
                                <br />
                                <div style="margin-left: auto; margin-right: auto; text-align: center;">
                                    <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Black"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
