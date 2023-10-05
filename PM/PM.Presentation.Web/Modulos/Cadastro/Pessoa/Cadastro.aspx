<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="PM.Presentation.Web.Modulos.Cadastro.Pessoa.Cadastro" %>
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
                              CausesValidation="true"
                              MsgTarget="Side"
                              EnforceMaxLength="true" 
                              MaxLength="200" />
                      </Items>
                  </ext:Container>

                  <ext:Container runat="server" Layout="HBoxLayout" Flex="1">
                      <Items>

                          <ext:TextField runat="server"
                              ID="txtCPF"
                              LabelAlign="Top"
                              Focusable="true"
                              Flex="1"
                              MarginSpec="0 5 0 0"
                              FieldLabel="CPF"
                              AllowBlank="false"
                              CausesValidation="true"
                              MsgTarget="Side"
                              EnforceMaxLength="true"
                              MaxLength="14" />

                          <ext:DateField
                              runat="server"
                              ID="txtDataNascimento"
                              MarginSpec="0 5 0 0"
                              LabelAlign="Top"
                              FieldLabel="Data de Nascimento"
                              MsgTarget="Side"
                              DataIndex="DataNascimento"
                              CausesValidation="true"
                              AllowBlank="true"
                              Flex="1">
                          </ext:DateField>

                          <ext:SelectBox runat="server"
                              ID="comboFuncionario"
                              LabelAlign="Top"
                              FieldLabel="Funcionario"
                              SelectOnFocus="true"
                              CausesValidation="true"
                              AllowBlank="false"
                              MsgTarget="Side"
                              Editable="false"
                              EmptyText="Selecione..."
                              ValueField="Value"
                              DisplayField="Text"
                              TypeAhead="true"
                              MultiSelect="false"
                              Flex="1"
                              MarginSpec="0 5 0 0">
                              <Items>
                                  <ext:ListItem Text="Sim" Value="True" />
                                  <ext:ListItem Text="Não" Value="False" />
                              </Items>
                          </ext:SelectBox>

                      </Items>
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
                      <click handler="parent.parent.Ext.net.ResourceMgr.getCmp('winCadPessoa').destroy();" />
                  </listeners>
              </ext:Button>
          </items>
      </ext:Toolbar>

      </Items>
  </ext:Viewport>
</asp:Content>
