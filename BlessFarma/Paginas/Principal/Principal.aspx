<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="BlessFarma.Paginas.Principal" EnableEventValidation="false" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- morris js -->
    <script src="../../DashBoard/vendor/charts/morris-bundle/raphael.min.js"></script>
    <script src="../../DashBoard/vendor/charts/morris-bundle/morris.js"></script>
    <!-- chart c3 js -->
    <script src="../../DashBoard/vendor/charts/c3charts/c3.min.js"></script>
    <script src="../../../DashBoard/vendor/charts/c3charts/d3-5.4.0.min.js"></script>
    <script src="../../DashBoard/vendor/charts/c3charts/C3chartjs.js"></script>
    <script src="../../DashBoard/libs/js/dashboard-ecommerce.js"></script>
    <script src="../../DashBoard/vendor/charts/charts-bundle/Chart.bundle.js"></script>
    <script src="../../DashBoard/vendor/charts/charts-bundle/chartjs.js"></script>
    <!-- main js-->
    <script src="../../DashBoard/libs/js/main-js.js"></script>
    <!-- jvactormap js-->
    <script src="../../DashBoard/vendor/jvectormap/jquery-jvectormap-2.0.2.min.js"></script>
    <script src="../../DashBoard/vendor/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
    <!-- sparkline js-->
    <script src="../../DashBoard/vendor/charts/sparkline/jquery.sparkline.js"></script>
    <script src="../../DashBoard/vendor/charts/sparkline/spark-js.js"></script>
    <!-- dashboard sales js-->

    <style>
        .navbar-brand {
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
        }

        .table td, .table th {
            padding: 14px !important;
            vertical-align: middle !important;
            border-top: 1px solid #e6e6f2 !important;
            font-weight: normal !important;
        }

        .title-earnings {
            color: #3d405c;
            margin: 0;
            font-size: 20px;
            line-height: 26px;
            font-weight: 700;
        }

        .earnings-month {
            color: #3d405c;
            font-size: 28px;
            font-weight: 700;
        }
    </style>
    <div class="row">

        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card  border-left-success shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-success text-uppercase mb-1">Ventas del Mes</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800"><span id=""></span></div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-primary  shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary  text-uppercase mb-1">Pedidos del mes</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800"><span id="spnItem2"></span></div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-shopping-bag fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-info text-uppercase mb-1">Crecimiento</div>
                            <div class="row no-gutters align-items-center">
                                <div class="col-auto">
                                    <div class="h5 mb-0 mr-3 font-weight-bold text-gray-800"><span id=""></span></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-chart-line fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-warning shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">Nuevos Clientes</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800"><span id="spnItem3"></span></div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-street-view fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <div class="row">

        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">
            <div class="card shadow mb-4">

                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">Estado de Pedidos</h6>
                </div>

                <div class="card-body">

                    <div id="gender_donut" style="height: 300px;"></div>

                    <div class="text-center m-t-40">
                        <span class="legend-item mr-3">
                            <span class="fa-xs text-primary mr-1 legend-tile"><i class="fa fa-fw fa-square-full "></i>
                            </span><span class="legend-text">Creado</span>
                        </span>
                        <span class="legend-item mr-3">
                            <span class="fa-xs text-secondary mr-1 legend-tile"><i class="fa fa-fw fa-square-full"></i></span>
                            <span class="legend-text">En Espera</span>
                        </span>
                        <span class="legend-item mr-3">
                            <span class="fa-xs text-info mr-1 legend-tile"><i class="fa fa-fw fa-square-full"></i></span>
                            <span class="legend-text">Aceptado</span>
                        </span>
                        <span class="legend-item mr-3">
                            <span class="fa-xs text-info mr-1 legend-tile" style="color: #ffc750 !important"><i class="fa fa-fw fa-square-full"></i></span>
                            <span class="legend-text">Rechazado</span>
                        </span>
                        <span class="legend-item mr-3">
                            <span class="fa-xs text-info mr-1 legend-tile" style="color: #2ec551 !important"><i class="fa fa-fw fa-square-full"></i></span>
                            <span class="legend-text">Entregado</span>
                        </span>
                        <%--<span class="legend-item mr-3">
                            <span class="fa-xs text-info mr-1 legend-tile" style="color: #1ba3b9 !important"><i class="fa fa-fw fa-square-full"></i></span>
                            <span class="legend-text">Cotizados</span>
                        </span>--%>
                   </div>

                </div>

            </div>
        </div>

        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">

            <div class="card shadow mb-4">

                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">Pedidos</h6>
                </div>

                <div class="card-body">
                    <canvas id="revenue" width="400" height="150"></canvas>
                </div>

                <div class="card-body border-top">
                    <div class="row">

                        <div class="offset-xl-1 col-xl-3 col-lg-3 col-md-12 col-sm-12 col-12 p-3">
                            <h4 class="title-earnings"><span id="spnGananciasTotales"></span></h4>
                        </div>

                        <div class="offset-xl-1 col-xl-3 col-lg-3 col-md-6 col-sm-12 col-12 p-3 text-center">
                            <h2 class="font-weight-normal mb-2"><span class="earnings-month" id="">25</span>                                                    </h2>
                            <div class="mb-0 mt-2 legend-item">
                                <span class="fa-xs text-primary mr-1 legend-title "><i class="fa fa-fw fa-square-full"></i></span>
                                <span class="legend-text">Semana Actual</span>
                            </div>
                        </div>

                        <div class="offset-xl-1 col-xl-3 col-lg-3 col-md-6 col-sm-12 col-12 p-3 text-center">
                            <h2 class="font-weight-normal mb-2">
                            <span class="earnings-month" id="">23</span>
                            </h2>
                            <div class="text-muted mb-0 mt-2 legend-item"><span class="fa-xs text-secondary mr-1 legend-title"><i class="fa fa-fw fa-square-full"></i></span><span class="legend-text">Semana Anterior</span></div>
                        </div>

                    </div>
                </div>
            </div>

        </div>

    </div>

    <div class="row">

        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
            <div class="card shadow mb-4">
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">Pedidos Recientes</h6>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table">
                            <thead class="bg-light">

                                <tr class="border-0">
                                    <th class="border-0">#</th>
                                    <th class="border-0">Plataforma</th>
                                    <th class="border-0">Codigo Pedido</th>
                                    <th class="border-0">Cantidad</th>
                                    <th class="border-0">Precio</th>
                                    <th class="border-0">Fecha Registro</th>
                                    <th class="border-0">Cliente</th>
                                    <th class="border-0">Estado</th>
                                </tr>

                            </thead>
                            <tbody>
                                <asp:Literal runat="server"></asp:Literal>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

        
    </div>
   
   
</asp:Content>
