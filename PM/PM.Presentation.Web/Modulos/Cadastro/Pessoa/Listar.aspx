<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="PM.Presentation.Web.Modulos.Cadastro.Pessoa.Listar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function funcionarioRenderer(value) {
            if (value === true)
                return "<span style='color:red;'>Não</span>";
            else if (value === false)
                return "<span style='color:green;'>Sim</span>";
        }
        function atualizarLista() {
            PM.Atualizar();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ext:Viewport runat="server" Layout="BorderLayout">
    <Items>

        <%--TOOLBAR--%>
        <ext:Toolbar runat="server" Region="North">
            <Items>

                <ext:Button ID="btnNovo" runat="server" Text="Novo" IconCls="fa fa-plus">
                    <DirectEvents>
                        <Click OnEvent="btnNovo_Click" ShowWarningOnFailure="true" ViewStateMode="Enabled">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>

                <ext:Button ID="btnEditar" runat="server" Text="Editar" IconCls="fa fa-pencil">
                    <DirectEvents>
                        <Click 
                            OnEvent="btnEditar_Click" 
                            ShowWarningOnFailure="true"
                            ViewStateMode="Enabled">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Id" Value="#{ gridPessoa }.getSelectionModel().getSelected().items[0].data.Id" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>

                <ext:Button ID="btnExcluir" runat="server" Text="Excluir" IconCls="fa fa-times">
                    <DirectEvents>
                        <Click OnEvent="btnExcluir_Click" ViewStateMode="Enabled">
                            <Confirmation ConfirmRequest="true" Title="Atenção!" Message="Realmente deseja excluir este(s) registro(s)?" />
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Id" Value="#{ gridPessoa }.getSelectionModel().getSelected().items[0].data.Id" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>

                <ext:ToolbarSeparator />

                <ext:Button ID="btnAtualizar" runat="server" Text="Atualizar" IconCls="fa fa-refresh">
                    <DirectEvents>
                        <Click OnEvent="btnAtualizar_Click" ShowWarningOnFailure="true">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>

            </Items>
        </ext:Toolbar>

        <%--LISTA--%>
        <ext:GridPanel
            ID="gridPessoa"
            runat="server"
            Region="Center"
            Header="false"
            TitleAlign="Left"
            ColumnLines="true"
            MultiSelect="false"
            StripeRows="true"
            EnableViewState="true"
            AutoShow="true"
            ViewStateMode="Enabled"
            Margin="2"
            ContextMenuID="RowContextMenu"
            RowLines="true">
            <Store>
                <ext:Store ID="Store1"
                    runat="server"
                    RemoteSort="false"
                    PageSize="100"
                    OnReadData="Data_Refresh">
                    <Model>
                        <ext:Model runat="server" IDProperty="Id">
                            <Fields>
                                <ext:ModelField Name="Id" />
                                <ext:ModelField Name="Nome" />
                                <ext:ModelField Name="CPF" />
                                <ext:ModelField Name="DataNascimento" />
                                <ext:ModelField Name="Funcionario" />
                            </Fields>
                        </ext:Model>
                    </Model>
                    <Sorters>
                        <ext:DataSorter Property="Nome" Direction="ASC" />
                    </Sorters>
                </ext:Store>
            </Store>

            <ColumnModel runat="server">
                <Columns>
                    <ext:Column runat="server" Text="Id" DataIndex="Id" Width="80" Align="Center" />
                    <ext:Column runat="server" Text="CPF" DataIndex="CPF" Width="150" Align="Center"/>
                    <ext:Column runat="server" Text="Nome" DataIndex="Nome" Flex="1" />
                    <ext:Column runat="server" Text="Funcionario" DataIndex="Funcionario" Width="150" Align="Center">
                        <Renderer Fn="funcionarioRenderer" />
                    </ext:Column>
                    <ext:DateColumn runat="server" Text="Data Nascimento" DataIndex="DataNascimento" Format="dd/MM/yyyy" Width="150" Align="Center" />
                </Columns>
            </ColumnModel>

            <DirectEvents>
                <ItemDblClick OnEvent="gridRow_DblClick">
                    <EventMask ShowMask="true" />
                    <ExtraParams>
                        <ext:Parameter Name="Id" Value="#{ gridPessoa }.getSelectionModel().getSelected().items[0].data.Id" Mode="Raw" />
                    </ExtraParams>
                </ItemDblClick>
            </DirectEvents>

            <SelectionModel>
                <ext:RowSelectionModel runat="server" SingleSelect="true" ID="RowSelectionModel1" />
            </SelectionModel>

            <BottomBar>
                <ext:PagingToolbar runat="server">
                    <Items>
                        <ext:StatusBar ID="StatusBar1" runat="server" />
                    </Items>
                </ext:PagingToolbar>
            </BottomBar>
        </ext:GridPanel>

        <%--MENU DE CONTEXTO--%>
        <ext:Menu ID="RowContextMenu" runat="server">
            <Items>

                <ext:MenuItem ID="mnuNovo" runat="server" Text="Novo" IconCls="fa fa-plus icon-size">
                    <DirectEvents>
                        <Click OnEvent="btnNovo_Click" ShowWarningOnFailure="true">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>

                <ext:MenuItem ID="mnuEditar" runat="server" Text="Editar" IconCls="fa fa-pencil icon-size">
                    <DirectEvents>
                        <Click OnEvent="btnEditar_Click" ShowWarningOnFailure="true">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Id" Value="#{ gridPessoa }.getSelectionModel().getSelected().items[0].data.Id" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>

                <ext:MenuItem ID="mnuExcluir" runat="server" Text="Excluir" IconCls="fa fa-times icon-size">
                    <DirectEvents>
                        <Click OnEvent="btnExcluir_Click" ViewStateMode="Enabled">
                            <Confirmation ConfirmRequest="true" Title="Atenção!" Message="Realmente deseja excluir este(s) registro(s)?" />
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Id" Value="#{ gridPessoa }.getSelectionModel().getSelected().items[0].data.Id" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>

                <ext:MenuSeparator />

                <ext:MenuItem ID="mnuAtualizar" runat="server" Text="Atualizar" IconCls="fa fa-refresh icon-size">
                    <DirectEvents>
                        <Click OnEvent="btnAtualizar_Click" ShowWarningOnFailure="true">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>

            </Items>
        </ext:Menu>

    </Items>
</ext:Viewport>
</asp:Content>
