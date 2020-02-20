<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LaporanForm.aspx.cs" Inherits="Perpus.LaporanForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 423px;
        }
        .style1
        {
            text-decoration: underline;
            font-size: large;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button Text="Home" ID="btnHome" runat="server" OnClick="btnHome_Click"/>
            <asp:Button Text="Master Buku" ID="btnBuku" runat="server" OnClick="btnBuku_Click" />
            <asp:Button Text="Peminjaman" ID="btnSewa" runat="server" OnClick="btnSewa_Click" />
            <asp:Button Text="Logout" ID="btnLogout" runat="server" OnClick="btnLogout_Click" />

            <table>
                <caption class="style1">  
                    <strong>List Data Buku yang disewa</strong>  
                    <asp:Label ID="labelUser" runat="server" />
                </caption>
                
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvSewa" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Username" HeaderText="User Penyewa" />
                                <asp:BoundField DataField="JudulBuku" HeaderText="Judul Buku" />
                                <asp:BoundField DataField="Pengarang" HeaderText="Pengarang" />
                                <asp:BoundField DataField="JenisBuku" HeaderText="Jenis Buku" />
                                <asp:BoundField DataField="HargaSewa" HeaderText="Harga Sewa Per Hari (Rp)" />
                                <asp:BoundField DataField="LamaSewa" HeaderText="Lama Sewa (Hari)" />
                                <asp:BoundField DataField="TotalHarga" HeaderText="Total Sewa (Rp)" />
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
