<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeForm.aspx.cs" Inherits="Perpus.HomeForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Username" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button Text="Laporan" ID="btnLaporan" runat="server" OnClick="btnLaporan_Click" />
                        <asp:Button Text="Daftar Buku" ID="btnBuku" runat="server" OnClick="btnBuku_Click" />
                        <asp:Button Text="Sewa" ID="btnSewa" runat="server" OnClick="btnSewa_Click" />
                        <asp:Button Text="Logout" ID="btnLogout" runat="server" OnClick="btnLogout_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
