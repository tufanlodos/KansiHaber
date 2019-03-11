<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web_HaberPortal.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kansi</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>KANSİ HABER PORTALI</h1>
            <h2>Tık tuzağından uzak haber keyfi</h2>
        </header>
        <div class="topmenu">
            <div class="topmenuitem">
                <asp:Button ID="okunma" runat="server" Text="Çok okunanlar" OnClick="okunma_Click" />
            </div>
            <div class="topmenuitem">
                <asp:Button ID="yeniye" runat="server" Text="Önce yeni" OnClick="yeniye_Click" />
            </div>
            <div class="topmenuitem">
                <asp:Button ID="eskiye" runat="server" Text="Önce eski" OnClick="eskiye_Click" />
            </div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Repeater ID="repNews" runat="server" OnItemCommand="repNews_ItemCommand">
            <ItemTemplate>
                <table cellpadding="0px" cellspacing="0px">
                    <tr class="HaberBaslik">
                        <td colspan="4"><b>
                            <div>
                                <%#Eval("HaberBaslik") %>
                            </div>
                        </b></td>
                    </tr>
                    <tr>
                        <td colspan="2" rowspan="2" class="HaberResim">
                            <img src='<%#Eval("HaberGoruntu")%>' alt="<%#Eval("GoruntuAciklama")%>" title="<%#Eval("GoruntuAciklama")%>" /></td>
                        <td colspan="2" rowspan="2" class="HaberOzet">
                            <p><%#Eval("HaberOzet")%></p>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                    <tr class="HaberDetay">
                        <td colspan="4">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <b>Görüntülenme:</b><asp:Label ID="goruntuleme" runat="server" Text='<%#Eval("Goruntulenme")%>'></asp:Label><br />
                                    <b>Haber Tarihi:</b> <%#Eval("HaberTarih")%><br />
                                    <%--Haber detayları için <b><a href='<%#Eval("HaberDetay")%>' target="blank" runat="server" onserverclick="okunma_Click" >tıklayınız.</a></b>--%>
                                    <%--'<%# "PopulateTicketDiv(" +Eval("SHOW_ID") + " );" %>'--%>
                                Haber detayları için <b><asp:LinkButton ID="lbDetay" runat="server" OnClientClick='<%# "DetayaGit("+Eval("HaberDetay")+")"%>' CommandName="Goruntulenme" CommandArgument='<%#Eval("Id") %>'>tıklayınız</asp:LinkButton></b>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <%--<%#Eval("HaberDetay") %>--%>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </form>
    <script type="text/javascript">
        function DetayaGit(siteAdres) {
            console.log(siteAdres);
            window.open(siteAdres, '_blank');
        }
    </script>
</body>

</html>
