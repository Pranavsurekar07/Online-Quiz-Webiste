<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddQuestions.aspx.cs" Inherits="TestDemo.AddQuestions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Add Questions</title>
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
            <div class="">
                <div class="page-title">
                    <div style="margin-left: auto; margin-right: auto; text-align: center;">
                        <h2>Add Questions</h2>
                        <br />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_content">
                                <div class="form-group">
                                    <label>Question :</label>
                                    <asp:TextBox ID="txtQuestion" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtQuestion" ValidationGroup="reqSubValid" ErrorMessage="Please Enter Question" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <br />
                                <div class="form-group">
                                    <label>Option 1 :</label>
                                    <asp:TextBox ID="txtOption1" runat="server"></asp:TextBox>

                                </div>

                                <div class="form-group">
                                    <label>Option 2 :</label>
                                    <asp:TextBox ID="txtOption2" runat="server"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <label>Option 3 :</label>
                                    <asp:TextBox ID="txtOption3" runat="server"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <label>Option 4 :</label>
                                    <asp:TextBox ID="txtOption4" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Correct Answer :</label>
                                    <asp:RadioButton ID="rboption1" GroupName="Options" runat="server" Text="1" />&nbsp;
                                    <asp:RadioButton ID="rboption2" GroupName="Options" runat="server" Text="2" />&nbsp;
                                    <asp:RadioButton ID="rboption3" GroupName="Options" runat="server" Text="3" />&nbsp;
                                    <asp:RadioButton ID="rboption4" GroupName="Options" runat="server" Text="4" />&nbsp;
                                </div>
                                <div class="ln_solid"></div>
                                <div class="form-group col-3">
                                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="Submit" ValidationGroup="reqSubValid" OnClick="btnSubmit_Click" />
                                </div>
                                <br />
                                <div class="x_content">
                                    <asp:GridView runat="server" AutoGenerateColumns="False" BorderWidth="0px" BorderColor="#EEEEEE" DataKeyNames="QuestionID" ClientIDMode="Static" ID="gvBlog" EmptyDataText="Data not Found" CssClass="table table-striped table-bordered dt-responsive nowrap" AllowPaging="True" PageSize="100" OnRowDeleting="gvBlog_RowDeleting">
                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No.">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblSrNo" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Question">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#Eval("Question") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Answer">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#Eval("Answer") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Option 1">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#Eval("Option1") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Option 2">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#Eval("Option2") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Option 3">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#Eval("Option3") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Option 4">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#Eval("Option4") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:HyperLinkField DataNavigateUrlFields="QuestionID" DataNavigateUrlFormatString="/AddQuestions.aspx?QuestionID={0}" ControlStyle-ForeColor="#3498db" Text="Select">



                                                <ControlStyle ForeColor="#3498DB"></ControlStyle>
                                            </asp:HyperLinkField>
                                            <asp:ButtonField CommandName="Delete" Text="Delete" />



                                        </Columns>
                                    </asp:GridView>
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
