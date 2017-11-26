<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="OPTIMA.index" MasterPageFile="Site1.Master"%>

<%@ MasterType VirtualPath="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHome" runat="server">

    <style type="text/css">
        ul.wysihtml5-toolbar {
            display: none;
        }
    </style>



    <section class="content">
        <div class="row ">
            <div class="col-md-12" style="text-align: justify;">
                <asp:Label ID="MsjInicio" CssClass="textarea2" runat="server"></asp:Label>
            </div>
        </div>



        <div class="row">
            <div class="col-md-6" style="text-align: center;">

                <a href="Inventario.aspx">
                    <div class="small-box" style="background-color: #4682B4">
                        <div class="inner" style="height: 200px; color: white">
                            <br />
                            <br />
                            <br />
                            <div style="color: white; font-size: xx-large;">Inventario </div>
                        </div>
                        <div class="icon">
                            <i class="fa fa-gavel"></i>
                        </div>
                    </div>
                </a>

            </div>

            

            <div class="col-md-6" style="text-align: center;">
                <a href="Pintura.aspx">
                    <div class="small-box" style="background-color: #5C7EC3">
                        <div class="inner" style="height: 200px">
                            <br />
                            <br />
                            <br />
                            <div style="color: white; font-size: xx-large">Pintura </div>
                        </div>
                        <div class="icon">
                            <i class="fa fa-sitemap"></i>
                        </div>

                    </div>
                </a>
            </div>

        </div>


        <div class="row">
            <div class="col-md-6" style="text-align: center;">
                <a href="ServicioPintura.aspx">
                    <div class="small-box" style="background-color: #008080">
                        <div class="inner" style="height: 200px">
                            <br />
                            <br />
                            <br />
                            <div style="color: white; font-size: xx-large">ServicioPintura</div>
                        </div>
                        <div class="icon">
                            <i class="fa fa-flag"></i>
                        </div>
                    </div>
                </a>
            </div>

            <div class="col-md-6" style="text-align: center;">
                <a href="Reportes.aspx">
                    <div class="small-box" style="background-color: #6495ED">
                        <div class="inner" style="height: 200px">
                            <br />
                            <br />
                            <br />
                            <div style="color: white; font-size: xx-large">Reportes</div>
                        </div>
                        <div class="icon">
                            <i class="fa fa-users"></i>
                        </div>
                    </div>
                </a>
            </div>

            

        </div>

    </section>
</asp:Content>
