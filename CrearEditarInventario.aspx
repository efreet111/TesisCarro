<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearEditarInventario.aspx.cs" Inherits="OPTIMA.CrearEditarMaterial" MasterPageFile="Site1.Master" %>


<%@ MasterType VirtualPath="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHome" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div class="container-fluid">

        <asp:HiddenField ID="HideInsertEdit" runat="server" />
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

                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-success">

                            <!-- /.box-header -->
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <!--Precio-->
                                        <div class="panel panel-success" id="datospersonales" runat="server" visible="true">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-sm-4">
                                                        <h5>Informacón del material</h5>
                                                    </div>
                                                    <div class="col-sm-8">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-sm-2">
                                                        Nombre
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" MaxLength="25" Style="text-transform: uppercase"></asp:TextBox>
                                                    </div>

                                                    <div class="col-sm-2">
                                                        <h5>Codigo</h5>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server" MaxLength="30" Style="text-transform: uppercase"></asp:TextBox>
                                                    </div>

                                                </div>

                                                <div class="row">
                                                    <div class="col-sm-2">
                                                        <h5>Cantidad</h5>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server" MaxLength="30" Style="text-transform: uppercase"></asp:TextBox>
                                                    </div>
                                                </div>



                                                <div class="row">
                                                    <div class="col-sm-2">
                                                        <h5>Tipo</h5>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <asp:DropDownList ID="DropTipo" class="form-control" runat="server" AppendDataBoundItems="true" >
                                                            <asp:ListItem Text="Seleccione..." Value="-1" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Pintura" Value="9"></asp:ListItem>
                                                            <asp:ListItem Text="Material" Value="10"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <h5>Estatus</h5>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <asp:DropDownList ID="DropEstatus" class="form-control" runat="server" AppendDataBoundItems="true">
                                                            <asp:ListItem Text="Seleccione..." Value="-1" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                                                            <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                
                        </div>

                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-sm-12">
                        <div id="DivContenido" class="panel-body" runat="server" visible="true" style="background-color: #ECF0F5">
                            <div class="row" style="text-align: right">
                                <div class="col-sm-3">
                                    <asp:Button ID="BtnAtras" CssClass="btn btn-block btn-default btn-cargando" runat="server" Text="Atras" data-loading-text="Procesando..." OnClick="BtnAtras_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button ID="Limpiar" CssClass="btn btn-block btn-default btn-cargando" runat="server" Text="Limpiar" data-loading-text="Procesando..." OnClick="BtnLimpiar_Click" />
                                </div>
                                <div class="col-sm-3" style="text-align: right">
                                    
                                </div>
                                <div class="col-sm-3" style="text-align: right">
                                    <asp:Button ID="BtnGuardar" CssClass="btn btn-block btn-success btn-cargando" runat="server" Text="Guardar" data-loading-text="Procesando..." OnClick="BtnGuardar_Click" />
                                </div>
                            </div>
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
