<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="OPTIMA.Usuarios" MasterPageFile="Site1.Master"%>

<%@ MasterType VirtualPath="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHome" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Usuarios
            </h1>
            <ol class="breadcrumb">
                <li><a href="index.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active">Usuarios</li>
            </ol>
        </section>
        <section class="content">

            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Filtros de búsqueda</h3>

                </div>
                <!-- /.box-header -->
                <div class="box-body">


                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-1">
                                <h5>Nombre</h5>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtNombre" class="form-control" runat="server" MaxLength="30" ></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <h5>Estatus</h5>
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="DropEstatus" class="form-control" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Text="Seleccione..." Value="-1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Inactivo" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-2"></div>
                            <div class="col-sm-2"></div>
                            <div class="col-sm-2"></div>
                            <div class="col-sm-2"></div>
                            <div class="col-sm-2">
                                <asp:Button ID="BtnBuscar" CssClass="btn btn-block btn-primary btn-cargando" data-loading-text="Procesando..." runat="server" Text="Buscar" UseSubmitBehavior="False" OnClick="BtnBuscar_Click" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Button ID="BtnLimpiar" CssClass="btn btn-block btn-default btn-cargando" data-loading-text="Procesando..." runat="server" Text="Limpiar" OnClick="BtnLimpiar_Click" />
                            </div>
                        </div>



                    </div>

                </div>
            </div>

            <div class="row" id="divInsertar">

                <div class="col-md-12">
                    <asp:LinkButton ID="LinkAddUsuario" runat="server" Style='text-align: center' CssClass="btn btn-app bg-primary btn-cargando pull-right" data-loading-text="<i class='fa fa-spinner fa-spin '></i>" ToolTip="Agregar Usuario" OnClick="LinkAddUsuario_Click">
                        <i class="fa fa-user-plus"></i>
                        Usuario Nuevo
                    </asp:LinkButton>
                </div>
            </div>


            <div class="box box-success" style="overflow-x: auto">
                <div class="box-body">
                    <div class="text-center" id="divGridUsuarios" runat="server" align="center">

                        <asp:GridView ID="GridUsuariosAdm" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-HorizontalAlign="Center"
                            DataKeyNames="idUsuario" CellPadding="5" PageSize="10" AllowPaging="true" AllowSorting="true" Caption="Resultado de la Busqueda"
                            OnRowCommand="GridUsuariosAdm_RowCommand"
                            OnPageIndexChanging="GridUsuariosAdm_PageIndexChanging"
                            CssClass="table table-bordered table-striped table-hover">
                            <Columns>
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BtnModificar" runat="server" ButtonType="Image" ImageUrl="~/images/search.png"
                                            CommandArgument='<%# Eval("idUsuario") %>' CommandName="Modificar">
                                            <img src="img/search.png" style="padding-bottom: 10px; padding-right: 10px;" />
                                        </asp:LinkButton>
                                        
                                        <asp:ImageButton ID="BtnEliminar" runat="server" ButtonType="Image" ImageUrl="~/images/eliminar2.png"
                                            CommandArgument='<%# Eval("idUsuario") %>' title="Haga click aqui desactivar usuario" OnCommand="BtnEliminar_Command" CommandName="Elimina"
                                            CausesValidation="true" OnClientClick="return confirm('¿Seguro que desea eliminar este Registro?');"  />
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Correo" DataField="Correo" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Perfil" DataField="NombrePerfil" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Estatus" DataField="nomEstatus" ItemStyle-HorizontalAlign="Center" />

                            </Columns>
                            <EmptyDataTemplate>
                                <center>
                    No hay información para este criterio de búsqueda...
                </center>
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass=" bg-primary" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle CssClass="success" />
                            <RowStyle CssClass=" primary" />
                        </asp:GridView>

                    </div>
                </div>
            </div>
        </section>




    </div>

    <script type="text/javascript">
        function pageLoad(sender, args) {

            $('.btn-cargando').on('click', function () {
                var $this = $(this);
                $this.button('loading');
                //setTimeout(function () {
                //    $this.button('reset');
                //}, 8000);
            });
        }
    </script>
</asp:Content>

