<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="PM.Presentation.Web.Modulos.Cadastro.Projeto.Cadastro" %>

<%--CADASTRO DE PROJETOS--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ext:Viewport runat="server" Layout="BorderLayout">
        <Items>

            <ext:FormPanel runat="server" ID="FormPanel1" Layout="FormLayout" Region="Center" Padding="5">
                <Items>
                    <ext:Container runat="server" Layout="HBoxLayout" Flex="1">
                        <Items>
                            <ext:TextField CausesValidation="false" runat="server" ID="txtId" LabelAlign="Top" Focusable="false" FieldStyle="text-align: center;" Width="100" ReadOnly="true" MarginSpec="0 5 0 0" FieldLabel="Id" />
                        </Items>
                    </ext:Container>

                    <ext:Container runat="server" Layout="HBoxLayout" Flex="1">
                        <Items>
                            <ext:TextField runat="server" 
                                ID="txtNome" 
                                LabelAlign="Top" 
                                Focusable="true" 
                                Flex="1" 
                                MarginSpec="0 5 0 0" 
                                FieldLabel="Nome"
                                AllowBlank="false"
                                MsgTarget="Side"
                                EnforceMaxLength="true" 
                                MaxLength="200" />
                        </Items>
                    </ext:Container>

                    <ext:Container runat="server" Layout="HBoxLayout" Flex="1">
                        <Items>
                            <ext:SelectBox runat="server"
                                ID="comboStatus"
                                Flex="1"
                                LabelAlign="Top"
                                FieldLabel="Status"
                                SelectOnFocus="true"
                                AllowBlank="false"
                                FireChangeOnLoad="false"
                                FireSelectOnLoad="false"
                                MsgTarget="Side"
                                Editable="false"
                                EmptyText="Selecione..."
                                ValueField="Value"
                                DisplayField="Value"
                                TypeAhead="true"
                                MultiSelect="false"
                                MarginSpec="0 5 0 0">
                                <Items>
                                    <ext:ListItem Text="Em Análise" Value="Em Analise" />
                                    <ext:ListItem Text="Análise Realizada" Value="Analise Realizada" />
                                    <ext:ListItem Text="Análise Aprovada" Value="Analise Aprovada" />
                                    <ext:ListItem Text="Iniciado" Value="Iniciado" />
                                    <ext:ListItem Text="Planejado" Value="Planejado" />
                                    <ext:ListItem Text="Em Andamento" Value="Em Andamento" />
                                    <ext:ListItem Text="Encerrado" Value="Encerrado" />
                                    <ext:ListItem Text="Cancelado" Value="Cancelado" />
                                </Items>
                            </ext:SelectBox>

                            <ext:SelectBox runat="server"
                                ID="comboRisco"
                                Flex="1"
                                LabelAlign="Top"
                                FieldLabel="Risco"
                                SelectOnFocus="true"
                                AllowBlank="false"
                                FireChangeOnLoad="false"
                                FireSelectOnLoad="false"
                                MsgTarget="Side"
                                Editable="false"
                                EmptyText="Selecione..."
                                ValueField="Value"
                                DisplayField="Value"
                                TypeAhead="true"
                                MultiSelect="false"
                                MarginSpec="0 5 0 0">
                                <Items>
                                    <ext:ListItem Text="Alto" Value="Alto"></ext:ListItem>
                                    <ext:ListItem Text="Médio" Value="Medio"></ext:ListItem>
                                    <ext:ListItem Text="Baixo" Value="Baixo"></ext:ListItem>
                                </Items>
                            </ext:SelectBox>

                            <ext:NumberField runat="server" 
                                ID="txtOrcamento" 
                                LabelAlign="Top" 
                                Focusable="true" 
                                MarginSpec="0 5 0 0" 
                                FieldLabel="Orçamento" 
                                MsgTarget="Side"
                                AllowBlank="false"
                                Flex="1" />

                        </Items>
                    </ext:Container>
                    <ext:Container runat="server" Layout="HBoxLayout" Flex="1">
                        <Items>
                            <ext:DateField
                                runat="server"
                                ID="txtDataInicio"
                                MarginSpec="0 5 0 0"
                                LabelAlign="Top"
                                FieldLabel="Data de Início"
                                MsgTarget="Side"
                                DataIndex="DataInicio"
                                AllowBlank="true"
                                Flex="1">
                            </ext:DateField>

                            <ext:DateField 
                                runat="server"
                                ID="txtDataPrevisaoFim"
                                MarginSpec="0 5 0 0"
                                LabelAlign="Top"
                                FieldLabel="Data Previsao Fim"
                                MsgTarget="Side"
                                DataIndex="DataPrevisaoFim"
                                AllowBlank="true"
                                Flex="1">
                            </ext:DateField>

                            <ext:DateField 
                                runat="server"
                                ID="txtDataFim"
                                MarginSpec="0 5 0 0"
                                LabelAlign="Top"
                                FieldLabel="Data Fim"
                                MsgTarget="Side"
                                DataIndex="DataFim"
                                AllowBlank="true"
                                Flex="1">
                            </ext:DateField>

                        </Items>
                </ext:Container>

                <ext:Container runat="server" Layout="HBoxLayout" Flex="1">
                    <items>
                        <ext:ComboBox
                            ID="comboGerente"
                            runat="server"
                            Editable="false"
                            EmptyText="Selecione..."
                            Flex="1"
                            LabelAlign="Top"
                            FieldLabel="Gerente"
                            SelectOnFocus="true"
                            AllowBlank="false"
                            MsgTarget="Side"
                            MarginSpec="0 5 0 0"
                            ValueField="Id"
                            DisplayField="Nome">
                            <store>
                                <ext:Store runat="server">
                                    <model>
                                        <ext:Model runat="server" IDProperty="Id">
                                            <fields>
                                                <ext:ModelField Name="Id" Type="Int" />
                                                <ext:ModelField Name="Nome" Type="String" />
                                            </fields>
                                        </ext:Model>
                                    </model>
                                </ext:Store>
                            </store>
                        </ext:ComboBox>
                    </items>
                </ext:Container>

                <ext:Container runat="server" Layout="HBoxLayout" Flex="1">
                    <items>
                        <ext:Container runat="server" Layout="HBoxLayout" Flex="1">
                            <items>
                                <ext:TextArea runat="server" 
                                    ID="txtDescricao" 
                                    MarginSpec="0 5 0 0" 
                                    LabelAlign="Top" 
                                    MsgTarget="Side"
                                    FieldLabel="Descrição" 
                                    SelectOnFocus="true" 
                                    Flex="1" 
                                    Height="100"
                                    DataIndex="Descricao" 
                                    EnforceMaxLength="true" 
                                    MaxLength="5000" />
                            </items>
                        </ext:Container>
                    </items>
                </ext:Container>
        </Items>

        <Listeners>
            <validitychange handler="#{btnOK}.setDisabled(!valid);" />
        </Listeners>
        </ext:FormPanel>

        <ext:Toolbar runat="server" Height="50" Region="South">
            <items>
                <ext:ToolbarFill />

                <ext:Button ID="btnOK" runat="server" Text="Salvar" IconCls="fa fa-check">
                    <directevents>
                        <click
                            onevent="btnOK_Click" showwarningonfailure="true">
                            <eventmask showmask="true" />
                        </click>
                    </directevents>
                </ext:Button>

                <ext:Button ID="btnCancelar" runat="server" Text="Fechar" IconCls="fa fa-times">
                    <listeners>
                        <click handler="parent.parent.Ext.net.ResourceMgr.getCmp('winCadProjeto').destroy();" />
                    </listeners>
                </ext:Button>
            </items>
        </ext:Toolbar>

        </Items>
    </ext:Viewport>
</asp:Content>
