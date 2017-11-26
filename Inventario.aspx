<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="OPTIMA.Inventario" MasterPageFile="Site1.Master" %>

<%@ MasterType VirtualPath="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHome" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Inventario
            </h1>
            <ol class="breadcrumb">
                <li><a href="index.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active">Inventario</li>
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
                                <h5>Codigo</h5>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtCodigo" class="form-control" runat="server" MaxLength="30"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <h5>Nombre</h5>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtNombre" class="form-control" runat="server" MaxLength="30"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <h5>Estatus</h5>
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="DropEstatus" class="form-control" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Text="Seleccione..." Value="-1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                                    <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
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
                                <asp:Button ID="btnBuscar" CssClass="btn btn-block btn-success btn-cargando" data-loading-text="Procesando..." runat="server" Text="Buscar" UseSubmitBehavior="False" OnClick="btnBuscar_Click" />
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
                    <asp:LinkButton ID="LinkAddInventario" runat="server" Style='text-align: center' CssClass="btn btn-app bg-success btn-cargando pull-right" data-loading-text="<i class='fa fa-spinner fa-spin '></i>" ToolTip="Agregar Perfil" OnClick="LinkAddInventario_Click">
                        <i class="fa fa-user-plus"></i>
                        Nuevo
                    </asp:LinkButton>
                </div>
            </div>


            <div class="box box-success" style="overflow-x: auto">
                <div class="box-body">
                    <div class="text-center" id="divGridMateriales" runat="server" align="center">
                        <div class="panel panel-success " style="overflow-x: auto">

                            <asp:GridView ID="GridMateriales" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-HorizontalAlign="Center"
                                DataKeyNames="id" CellPadding="4" PageSize="6" AllowPaging="true" Caption="Materiales en Inventario"
                                OnRowCommand="GridMateriales_RowCommand"
                                OnPageIndexChanging="GridMateriales_PageIndexChanging"
                                class="table table-bordered table-striped table-hover">
                                <Columns>
                                    <asp:ButtonField HeaderText="Detalle" ButtonType="Image" CommandName="Modificar"
                                        ImageUrl="images/search.png" ItemStyle-Width="50px" />
                                    <asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imagebut" runat="server" ButtonType="Image" ImageUrl="images/eliminar2.png"
                                                CommandArgument='<%# Eval("id") %>' OnCommand="imagebut_Command" CommandName="Elimina"
                                                CausesValidation="true" OnClientClick="return confirm('¿Seguro que desea eliminar este Registro?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                                    <asp:BoundField HeaderText="Estatus" DataField="Estatus" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <center>
                    No hay información para este criterio de búsqueda...
                </center>
                                </EmptyDataTemplate>
                                <HeaderStyle CssClass="#76923C" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle CssClass="success" />
                                <RowStyle CssClass="bg-primary" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>




            <div class="box box-success" style="overflow-x: auto">
                <div class="box-body">
                    <div class="text-center" id="div1" runat="server" align="center">
                        <div class="panel panel-success " style="overflow-x: auto">


                            <asp:GridView ID="GridPinturas" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-HorizontalAlign="Center"
                                DataKeyNames="id" CellPadding="4" PageSize="15" AllowPaging="true" Caption="Pinturas en Inventario"
                                OnRowCommand="GridPinturas_RowCommand"
                                OnPageIndexChanging="GridPinturas_PageIndexChanging"
                                class="table table-bordered table-striped table-hover">
                                <Columns>
                                    <asp:ButtonField HeaderText="Detalle" ButtonType="Image" CommandName="Modificar"
                                        ImageUrl="images/search.png" ItemStyle-Width="50px" />
                                    <asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imagebut" runat="server" ButtonType="Image" ImageUrl="images/eliminar2.png"
                                                CommandArgument='<%# Eval("id") %>' OnCommand="imagebut_Command" CommandName="Elimina"
                                                CausesValidation="true" OnClientClick="return confirm('¿Seguro que desea eliminar este Registro?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                                    <asp:BoundField HeaderText="Estatus" DataField="Estatus" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <center>
                    No hay información para este criterio de búsqueda...
                </center>
                                </EmptyDataTemplate>
                                <HeaderStyle CssClass="#76923C" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle CssClass="success" />
                                <RowStyle CssClass="bg-primary" />
                            </asp:GridView>

                        </div>

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
