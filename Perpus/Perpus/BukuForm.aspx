<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BukuForm.aspx.cs" Inherits="Perpus.BukuForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-decoration: underline;
            font-size: large;
            text-align: left;
        }
        .style2
        {
            width: 141px;
        }   
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button Text="Home" ID="btnHome" runat="server" OnClick="btnHome_Click"/>
            <asp:Button Text="Laporan" ID="btnLaporan" runat="server" OnClick="btnLaporan_Click"/>
            <asp:Button Text="Logout" ID="btnLogout" runat="server" OnClick="btnLogout_Click"/>
            <asp:HiddenField  ID="hfIDBuku" runat="server" />
            <table>
                <caption class="style1">  
                    <strong>Daftar Buku</strong>  
                </caption>  
                <tr>
                    <td>
                        <asp:Label Text="Judul Buku :" runat="server"/>
                    </td>
                    <td>
                        <asp:TextBox ID="JudulBuku" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Pengarang :" runat="server"/>
                    </td>
                    <td>
                        <asp:TextBox ID="Pengarang" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Jenis Buku :" runat="server"/>
                    </td>
                    <td>
                        <asp:TextBox ID="JenisBuku" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Harga Sewa :" runat="server"/>
                    </td>
                    <td>
                        <asp:TextBox ID="HargaSewa" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button Text="Save" ID="btnSave" runat="server" OnClick="btnSave_Click" />
                        <asp:Button Text="Delete" ID="btnDelete" runat="server" OnClick="btnDelete_Click" />
                        <asp:Button Text="Clear" ID="btnClear" runat="server" OnClick="btnClear_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblSuccessMessage" runat="server" ForeColor="Green" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red" />
                    </td>
                </tr>
            </table>
            <br/. />
            <asp:GridView ID="gvBuku" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="JudulBuku" HeaderText="Judul Buku" />
                    <asp:BoundField DataField="Pengarang" HeaderText="Pengarang" />
                    <asp:BoundField DataField="JenisBuku" HeaderText="Jenis Buku" />
                    <asp:BoundField DataField="HargaSewa" HeaderText="Harga Sewa Per Hari" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton Text="Select" ID="lnkSelect" CommandArgument='<%# Eval("IdBuku") %>' runat="server" OnClick="lnkSelect_OnClick"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
