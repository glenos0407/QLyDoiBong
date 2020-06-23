<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QLDoiBong.aspx.cs" Inherits="QLDoiBong.QLDoiBong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản Lý Đội Bóng</title>
    <link href="Content/bootstrap.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-3.5.1.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <style>
        #btnXoa{
            padding: 1em;
        }
    </style>
</head>
<body>
    <form id="frmQuanLy" runat="server">
        <div class="container">
            <asp:Label runat="server" Text="Danh Sách Đội Bóng"></asp:Label>
            <asp:DropDownList runat="server" ID="dropDownDSDoiBong" AutoPostBack="false"></asp:DropDownList>
            <asp:Button runat="server" ID="btnHienThiDSCauThu" OnClick="btnHienThiDSCauThu_Click" Text="Hiển Thị Danh Sách Cầu Thủ"></asp:Button>

            <div class="pnlThemCauThu" style="margin-top: 1em; margin-bottom: 1em;">
                <label>Mã Cầu Thủ</label>
                <asp:TextBox runat="server" ID="txtMaCauThu" ReadOnly="True"></asp:TextBox>
                <br />
                <label>Họ Tên</label>
                <asp:TextBox runat="server" ID="txtTenCauThu"></asp:TextBox>
                <br />
                <label>Địa Chỉ</label>
                <asp:TextBox runat="server" ID="txtDiaChi"></asp:TextBox>
                <br />
                <label>Chọn Đội Bóng</label>
                <asp:DropDownList runat="server" ID="dropDownDSDoiBong2" AutoPostBack="false"></asp:DropDownList>
                <br />
                <asp:Button runat="server" ID="btnThemCauThu" OnClick="btnThemCauThu_Click" Text="Thêm Cầu Thủ" />
                <asp:Button runat="server" ID="btnLuuSua" OnClick="btnLuuSua_Click" Text="Lưu Thay Đổi" Enabled="false" />
                <asp:LinkButton runat="server" ID="btnXoa" Text="Xoá" Visible="false" data-toggle="modal" data-target="#modalXacNhan" CssClass="badge badge-danger"/>
            </div>
            <br />
            <h2>Danh Sách Cầu Thủ</h2>
            <br />
            <asp:GridView runat="server" ID="gvwDSCauThu" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="maCauThu" HeaderText="Mã Cầu Thủ" />
                    <asp:BoundField DataField="tenCauThu" HeaderText="Họ Tên" />
                    <asp:BoundField DataField="diaChi" HeaderText="Địa Chỉ" />
                    <asp:BoundField DataField="tenDoiBong" HeaderText="Tên Đội Bóng" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="Chọn" ID="btnSua" OnClick="btnSuaCauThu_Click" CommandArgument='<%# Eval("maCauThu") %>'> </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="modal" id="modalXacNhan">
            <div class="modal-dialog">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Bạn Có Muốn Xoá Không ?</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <asp:Button runat="server" ID="btnChapNhanXoa" Text="OK" CssClass="btn btn-success" OnClick="btnChapNhanXoa_Click"/>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancle</button>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
