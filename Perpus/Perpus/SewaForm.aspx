<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SewaForm.aspx.cs" Inherits="Perpus.SewaForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 386px;
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
                <tr >
                    <td>
                        <asp:Label Text="PEMINJAMAN BUKU" runat="server"/>
                    </td>
                    <td align="right">
                        <asp:Label ID="labelUser" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Judul Buku :" runat="server"/>
                    </td>
                    <td>
                        <asp:Label ID="JudulBuku" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Pengarang :" runat="server"/>
                    </td>
                    <td>
                        <asp:Label ID="Pengarang" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Jenis Buku :" runat="server"/>
                    </td>
                    <td>
                        <asp:Label ID="JenisBuku" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Harga Sewa :" runat="server"/>
                    </td>
                    <td>
                        <asp:Label ID="HargaSewa" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Tanggal Sewa:" runat="server"/>
                    </td>
                    <td>
                        <asp:TextBox ID="tglSewa" runat="server" TextMode="Date"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Lama Sewa (Hari):" runat="server"/>
                    </td>
                    <td>
                        <asp:TextBox ID="LamaSewa" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button Text="Sewa" ID="btnSave" runat="server" OnClick="btnSave_Click" />
                        <asp:Button Text="Clear" ID="btnClear" runat="server" OnClick="btnClear_Click"  />
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
            <label>List Data Buku</label>
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
            
            <br/. />
            <label>List Data Buku yang disewa</label>
            <table>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvSewa" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="JudulBuku" HeaderText="Judul Buku" />
                            <asp:BoundField DataField="Pengarang" HeaderText="Pengarang" />
                            <asp:BoundField DataField="JenisBuku" HeaderText="Jenis Buku" />
                            <asp:BoundField DataField="HargaSewa" HeaderText="Harga Sewa Per Hari" />
                            <asp:BoundField DataField="LamaSewa" HeaderText="Lama Sewa" />
                            <asp:BoundField DataField="TotalHarga" HeaderText="Total Sewa" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton Text="Remove" ID="lnkRemove" CommandArgument='<%# Eval("IdSewa") %>' runat="server" OnClick="lnkRemove_OnClick"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" align="right">
                        Total Uang Sewa :
                    </td>
                    <td>
                        <asp:Label ID="subTotal" runat="server"/>
                    </td>
                </tr>
            </table>
            
        </div>
    </form>
</body>
</html>
