<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="OPTIMA.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Optima | Log in</title>
    <link rel="shortcut icon" href="images/icono.png" />
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="plugins/iCheck/square/blue.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
</head>
<body class="hold-transition login-page">
    <form runat="server" id="form1">
        <div class="login-box">




            <!-- /.login-logo -->
            <div class="login-box-body">
                <div class="login-logo">
                    <%--<img src="img/Logo-AllInOne.jpg" width="70%" height="70%" />--%>
                    <img src="images/iconoLogo.png" />
                </div>
                <p class="login-box-msg">Inicie su Sesión</p>

                <div class="form-group has-feedback">
                    <asp:TextBox ID="TxtEmail" runat="server" type="email" class="form-control" placeholder="Email"></asp:TextBox>
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox type="password" class="form-control" placeholder="Password" ID="Txtpassword" runat="server"></asp:TextBox>
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                </div>
                <div class="row">
                    <!-- /.col -->
                    <div class="col-xs-12">
                        <asp:Button ID="BtnEntrar" runat="server" class="btn btn-primary btn-block btn-flat" Text="Entrar" OnClick="BtnEntrar_Click" />
                        <a href="#" style="text-align: center" data-toggle="modal" data-target="#RecuperarPassword">Olvide mi contraseña</a><br>
                    </div>
                    <!-- /.col -->
                </div>

            </div>
            <!-- /.login-box-body -->
        </div>
        <!-- /.login-box -->





        <div class="modal" id="RecuperarPassword" tabindex="-1" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Recuperar Contraseña</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group has-feedback">
                        <asp:TextBox ID="txtUsuario2" runat="server" CssClass="form-control" placeholder="Introduzca el correo del usuario" data-toggle='tooltip' data-placement='top' title=""></asp:TextBox>
                        <span class="glyphicon glyphicon-user form-control-feedback"></span>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btEnviarPass" runat="server" Text="Enviar" CssClass="btn bg-red margin" OnClick="btEnviarPass_Click" />

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <div class="modal" id="CambiarPassword" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Cambio de contraseña</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group has-feedback">
                        <asp:TextBox ID="txtPasswordOld" runat="server" CssClass="form-control" placeholder="Introduzca su antigua contraseña" TextMode="Password"></asp:TextBox>
                        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <asp:TextBox ID="txtPasswordNew" runat="server" CssClass="form-control" placeholder="Introduzca su nueva contraseña" TextMode="Password"></asp:TextBox>
                        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <asp:TextBox ID="txtPasswordConfirm" runat="server" CssClass="form-control" placeholder="Confirme su nueva contraseña" TextMode="Password"></asp:TextBox>
                        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btCambiarPassword" runat="server" Text="Enviar" CssClass="btn bg-red margin" OnClick="btCambiarPassword_Click" />

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal modal-warning fade" id="MensajeAlerta" tabindex="-1" role="dialog" aria-labelledby="Advertencia">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Atención</h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label ID="lbMensaje" runat="server" Text=""></asp:Label>
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->


    </div>

    <div class="modal modal-danger fade" id="MensajeError" tabindex="-1" role="dialog" aria-labelledby="Error">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body" style="text-align: justify; font-size: small;">
                    <p>
                        <asp:Label ID="lbMensajeError" runat="server" Text=""></asp:Label>
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>


    </form>


    



    <!-- jQuery 3 -->
    <script src="bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
    </script>




    <%if (lbMensaje.Text != "")
      { %>
    <script type="text/javascript">
        $(window).on('load', function () {
            $('#MensajeAlerta').modal('show');
        });
    </script>
    <%} %>

    <%if (lbMensajeError.Text != "")
      { %>
    <script type="text/javascript">
        $(window).on('load', function () {
            $('#MensajeError').modal('show');
        });
    </script>
    <%} %>
    <%if (cambioClave)
      { %>
    <script type="text/javascript">
        $(window).on('load', function () {
            $('#CambiarPassword').modal('show');
        });
    </script>
    <%}
      else
      { %>
    <script type="text/javascript">
        $(window).on('load', function () {
            $('#CambiarPassword').modal('hide');
        });
    </script>
    <%} %>
</body>
</html>
