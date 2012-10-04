<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DigitallyImported.Web._Default" %>
<%@ Register Assembly="DigitallyImported.Controls" Namespace="DigitallyImported.Controls.Web" TagPrefix="DIC" %>
<%@ Import Namespace="DigitallyImported.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater runat="server" ID="ChannelRepeater">
            <HeaderTemplate>Channel Data:</HeaderTemplate>
            <ItemTemplate>
                <%#DataBinder.Eval(Container.DataItem, "ChannelName") %>
            </ItemTemplate>
        </asp:Repeater>
        <DIC:ChannelList ID="ChannelList1" runat="server" />
    </div>
    </form>
</body>
</html>
