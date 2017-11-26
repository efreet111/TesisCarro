<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfiles.aspx.cs" Inherits="OPTIMA.Perfiles" MasterPageFile="Site1.Master" %>

<%@ MasterType VirtualPath="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHome" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Perfiles
            </h1>
            <ol class="breadcrumb">
                <li><a href="index.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active">Perfiles</li>
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
                                <h5>Perfil</h5>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="DropPerfil" class="form-control" runat="server" AppendDataBoundItems="true" >
                                </asp:DropDownList>
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
                                <asp:Button ID="BtnBuscar" CssClass="btn btn-block btn-success btn-cargando" data-loading-text="Procesando..." runat="server" Text="Buscar" UseSubmitBehavior="False" OnClick="BtnBuscar_Click" />
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
                    <asp:LinkButton ID="LinkAddPerfil" runat="server" Style='text-align: center' CssClass="btn btn-app bg-primary btn-cargando pull-right" data-loading-text="<i class='fa fa-spinner fa-spin '></i>" ToolTip="Agregar Perfil" OnClick="LinkAddPerfil_Click">
                        <i class="fa fa-user-plus"></i>
                        Perfil Nuevo
                    </asp:LinkButton>
                </div>
            </div>


            <div class="box box-success" style="overflow-x: auto">
                <div class="box-body">
                    <div class="text-center" id="divGridPerfil" runat="server" align="center">

                        <asp:GridView ID="GridPerfil" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-HorizontalAlign="Center"
                            DataKeyNames="idPerfil,Activo" CellPadding="4" PageSize="10" AllowPaging="true" Caption="Resultado de la Busqueda"
                            OnRowCommand="GridPerfil_RowCommand"
                            OnPageIndexChanging="GridPerfil_PageIndexChanging"
                            class="table table-bordered table-striped table-hover">
                            <Columns>
                                <asp:ButtonField HeaderText="Detalle" ButtonType="Image" CommandName="Modificar"
                                    ImageUrl="images/search.png" ItemStyle-Width="50px" />
                                <asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imagebut" runat="server" ButtonType="Image" ImageUrl="images/eliminar2.png"
                                            CommandArgument='<%# Eval("idPerfil") %>' OnCommand="imagebut_Command" CommandName="Elimina"
                                            CausesValidation="true" OnClientClick="return confirm('¿Seguro que desea eliminar este Registro?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Estatus" DataField="nomActivo" />
                            </Columns>
                            <EmptyDataTemplate>
                                <center>
                    No hay información para este criterio de búsqueda...
                </center>
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="#76923C" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle CssClass="success" />
                            <RowStyle CssClass="bg-primary"/>
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
