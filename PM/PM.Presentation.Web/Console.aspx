<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Console.aspx.cs" Inherits="PM.Presentation.Web.Console" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project Manager</title>

    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/modernizr-2.8.3.js"></script>

    <link href="Content/font-awesome.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
</head>

<body oncontextmenu="return false">

    <form runat="server">

        <ext:ResourceManager
            ID="ResourceManager1"
            runat="server"
            IDMode="Static"
            ClientIDMode="Static"
            RegisterAllResources="true"
            DirectMethodNamespace="PM">
        </ext:ResourceManager>

        <ext:Viewport runat="server" ID="vport" Layout="BorderLayout">
            <Items>

                <%--HEADER--%>
                <ext:Panel
                    ID="pnlNorth"
                    runat="server"
                    Region="North"
                    Height="50"
                    Border="false"
                    BodyStyle="background-color: #000;">
                    <Content>
                            <h1 id="pageTitle">Project Manager</h1>
                    </Content>
                </ext:Panel>

                <%--MENU PRINCIPAL--%>
                 <ext:Panel
                    runat="server"
                    Region="West"
                    Title="Menu do Sistema"
                    Width="200"
                    ID="pnlSettings"
                    BodyStyle="background-color: #transparent;"
                    Collapsible="true"
                    Split="true"
                    MinWidth="175"
                    MaxWidth="400"
                    MarginSpec="0 0 0 0"
                    Layout="BorderLayout">
                     <Items>
                        <ext:MenuPanel runat="server" Region="Center">
                            <Menu ID="mnu1" runat="server">
                                <Items>
                                    <ext:MenuItem runat="server" Text="Projetos" Icon="Bricks">
                                        <DirectEvents>
                                            <Click OnEvent="Projetos_Click" />
                                        </DirectEvents>
                                    </ext:MenuItem>
                                    <ext:MenuItem runat="server" Text="Pessoas" Icon="User">
                                        <DirectEvents>
                                            <Click OnEvent="Pessoas_Click" />
                                        </DirectEvents>
                                    </ext:MenuItem>
                                </Items>
                            </Menu>
                        </ext:MenuPanel>
                    </Items>
                </ext:Panel>

                <%--TAB PRINCIPAL--%>
                <ext:TabPanel
                    runat="server"
                    ID="tabPrincipal"
                    IDMode="Static"
                    ClientIDMode="Static"
                    Region="Center"
                    Header="false"
                    EnableViewState="true"
                    ViewStateMode="Enabled">
                </ext:TabPanel>

            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
