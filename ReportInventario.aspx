<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportInventario.aspx.cs" Inherits="OPTIMA.ReportInventario" MasterPageFile="Site1.Master"%>

<%@ MasterType VirtualPath="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHome" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Reporte Inventarios
            </h1>
            <ol class="breadcrumb">
                <li><a href="index.aspx"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li>Reportes</li>
                <li class="active">Reporte Inventarios</li>
            </ol>
        </section>
        <section class="content">

            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title"></h3>
                    
                </div>
                <!-- /.box-header -->
                <div class="box-body">


                    <div class="form-group">
                        <div class="row">
                            

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

