function DashBoarItems(response) {
    var result = jQuery.parseJSON(response.d);
    if (result == null) return;
    document.getElementById("spnItem1").textContent = 'S/' + result[0].Item;
    document.getElementById("spnItem2").textContent = result[1].Item;
    document.getElementById("spnItem3").textContent =  result[2].Item;
    document.getElementById("spnItem4").textContent = '+' + result[3].Item+'%' ;
    document.getElementById("spnGananciasTotales").textContent = 'Ganancias Totales   : S/'+result[4].Item;
}
    function Pedidos2Semanas(response) {
    
    var result = jQuery.parseJSON(response.d);
    if (result == null) return;
    document.getElementById("spnGananciasSemana1").textContent = 'S/'+result[6].PrecioPedido;
    document.getElementById("spnGananciasSemana2").textContent = 'S/'+result[13].PrecioPedido;

    var ctx = document.getElementById('revenue').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'line',

        data: {
            labels: [result[6].NomDia, result[5].NomDia, result[4].NomDia, result[3].NomDia, result[2].NomDia, result[1].NomDia, result[0].NomDia],
            datasets: [{
                label: 'Semana Actual',
                data: [result[6].Cantidad, result[5].Cantidad, result[4].Cantidad, result[3].Cantidad, result[2].Cantidad, result[1].Cantidad, result[0].Cantidad],
                backgroundColor: "rgba(89, 105, 255,0.5)",
                borderColor: "rgba(89, 105, 255,0.7)",
                borderWidth: 2

            }, {
                label: 'Semana Anterior',
                    data: [result[13].Cantidad, result[12].Cantidad, result[11].Cantidad, result[10].Cantidad, result[9].Cantidad, result[8].Cantidad, result[7].Cantidad],
                backgroundColor: "rgba(255, 64, 123,0.5)",
                borderColor: "rgba(255, 64, 123,0.7)",
                borderWidth: 2
            }]
        },
        options: {

            legend: {
                display: true,
                position: 'bottom',

                labels: {
                    fontColor: '#71748d',
                    fontFamily: 'Circular Std Book',
                    fontSize: 14,
                }
            },
            scales: {
                yAxes: [{
                    ticks: {
                        // Include a dollar sign in the ticks
                        callback: function (value, index, values) {
                            return '$' + value;
                        }
                    }
                }]
            },


            scales: {
                xAxes: [{
                    ticks: {
                        fontSize: 14,
                        fontFamily: 'Circular Std Book',
                        fontColor: '#71748d',
                    }
                }],
                yAxes: [{
                    ticks: {
                        fontSize: 14,
                        fontFamily: 'Circular Std Book',
                        fontColor: '#71748d',
                    }
                }]
            }

        }
    });
}

function EstadosPedido(response) {
    var result = jQuery.parseJSON(response.d);
    if (result == null) return;
    var Estado1 = result[0].NomEstadoPedido;
    var Cantidad1 = result[0].IdPedido;
    var Estado2 = result[1].NomEstadoPedido;
    var Cantidad2 = result[1].IdPedido;
    var Estado3 = result[2].NomEstadoPedido;
    var Cantidad3 = result[2].IdPedido;
    var Estado4 = result[3].NomEstadoPedido;
    var Cantidad4 = result[3].IdPedido;
    var Estado5 = result[4].NomEstadoPedido;
    var Cantidad5 = result[4].IdPedido;
    var Estado6 = result[5].NomEstadoPedido;
    var Cantidad6 = result[5].IdPedido;

    Morris.Donut({
        element: 'gender_donut',
        data: [
            { value: Cantidad1, label: Estado1 },
            { value: Cantidad2, label: Estado2 },
            { value: Cantidad3, label: Estado3 },
            { value: Cantidad4, label: Estado4 },
            { value: Cantidad5, label: Estado5 },
            { value: Cantidad6, label: Estado6 }

        ],

        labelColor: '#5969ff',
        colors: [
            '#5969ff',
            '#ff407b',
            '#25d5f2',
            '#ffc750',
            '#2ec551',
            '#1ba3b9',

        ],



        formatter: function (x) { return x + "" }
    });
}
function GetError(error) {
    alert(error);
}
    
    //$(function() {
    //    "use strict";
    //    // ============================================================== 
    //    // Product Sales
    //    // ============================================================== 
       

    //    new Chartist.Bar('.ct-chart-product', {
    //        labels: ['Q1', 'Q2', 'Q3', 'Q4'],
    //        series: [
    //            [800000, 1200000, 1400000, 1300000],
    //            [200000, 400000, 500000, 300000],
    //            [100000, 200000, 400000, 600000]
    //        ]
    //    }, {
    //        stackBars: true,
    //        axisY: {
    //            labelInterpolationFnc: function(value) {
    //                return (value / 1000) + 'k';
    //            }
    //        }
    //    }).on('draw', function(data) {
    //        if (data.type === 'bar') {
    //            data.element.attr({
    //                style: 'stroke-width: 40px'
    //            });
    //        }
    //    });
    //});

$.ajax({
    type: "post",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    url: 'Paginas/Otros/Metodos.aspx/GetEstadosPedidoActual',
    //data: '{"CodPerfil": "' + CodPerfil + '","CodConductor": "' + CodConductor + '"}',
    success: EstadosPedido,
    error: GetError,
    complete: function () {
       
    }
});

$.ajax({
    type: "post",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    url: 'Paginas/Otros/Metodos.aspx/GetPedidos2Semanas',
    //data: '{"CodPerfil": "' + CodPerfil + '","CodConductor": "' + CodConductor + '"}',
    success: Pedidos2Semanas,
    error: GetError,
    complete: function () {

    }
});

$.ajax({
    type: "post",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    url: 'Paginas/Otros/Metodos.aspx/DashBoarSelectAll',
    //data: '{"CodPerfil": "' + CodPerfil + '","CodConductor": "' + CodConductor + '"}',
    success: DashBoarItems,
    error: GetError,
    complete: function () {

    }
});




    // ============================================================== 
    // Product Category
    // ============================================================== 
    //var chart = new Chartist.Pie('.ct-chart-category', {
    //    series: [60, 30, 30],
    //    labels: ['Bananas', 'Apples', 'Grapes']
    //}, {
    //    donut: true,
    //    showLabel: false,
    //    donutWidth: 40

    //});


    //chart.on('draw', function(data) {
    //    if (data.type === 'slice') {
    //        // Get the total path length in order to use for dash array animation
    //        var pathLength = data.element._node.getTotalLength();

    //        // Set a dasharray that matches the path length as prerequisite to animate dashoffset
    //        data.element.attr({
    //            'stroke-dasharray': pathLength + 'px ' + pathLength + 'px'
    //        });

    //        // Create animation definition while also assigning an ID to the animation for later sync usage
    //        var animationDefinition = {
    //            'stroke-dashoffset': {
    //                id: 'anim' + data.index,
    //                dur: 1000,
    //                from: -pathLength + 'px',
    //                to: '0px',
    //                easing: Chartist.Svg.Easing.easeOutQuint,
    //                // We need to use `fill: 'freeze'` otherwise our animation will fall back to initial (not visible)
    //                fill: 'freeze'
    //            }
    //        };

    //        // If this was not the first slice, we need to time the animation so that it uses the end sync event of the previous animation
    //        if (data.index !== 0) {
    //            animationDefinition['stroke-dashoffset'].begin = 'anim' + (data.index - 1) + '.end';
    //        }

    //        // We need to set an initial value before the animation starts as we are not in guided mode which would do that for us
    //        data.element.attr({
    //            'stroke-dashoffset': -pathLength + 'px'
    //        });

    //        // We can't use guided mode as the animations need to rely on setting begin manually
    //        // See http://gionkunz.github.io/chartist-js/api-documentation.html#chartistsvg-function-animate
    //        data.element.animate(animationDefinition, false);
    //    }
    //});

    //// For the sake of the example we update the chart every time it's created with a delay of 8 seconds
    


    //// ============================================================== 
    //// Customer acquisition
    //// ============================================================== 
    //var chart = new Chartist.Line('.ct-chart', {
    //    labels: ['Mon', 'Tue', 'Wed'],
    //    series: [
    //        [1, 5, 2, 5],
    //        [2, 3, 4, 8]

    //    ]
    //}, {
    //    low: 0,
    //    showArea: true,
    //    showPoint: false,
    //    fullWidth: true
    //});

    //chart.on('draw', function(data) {
    //    if (data.type === 'line' || data.type === 'area') {
    //        data.element.animate({
    //            d: {
    //                begin: 2000 * data.index,
    //                dur: 2000,
    //                from: data.path.clone().scale(1, 0).translate(0, data.chartRect.height()).stringify(),
    //                to: data.path.clone().stringify(),
    //                easing: Chartist.Svg.Easing.easeOutQuint
    //            }
    //        });
    //    }
    //});




    //// ============================================================== 
    //// Revenue Cards
    //// ============================================================== 
    //$("#sparkline-revenue").sparkline([5, 5, 7, 7, 9, 5, 3, 5, 2, 4, 6, 7], {
    //    type: 'line',
    //    width: '99.5%',
    //    height: '100',
    //    lineColor: '#5969ff',
    //    fillColor: '#dbdeff',
    //    lineWidth: 2,
    //    spotColor: undefined,
    //    minSpotColor: undefined,
    //    maxSpotColor: undefined,
    //    highlightSpotColor: undefined,
    //    highlightLineColor: undefined,
    //    resize: true
    //});



    //$("#sparkline-revenue2").sparkline([3, 7, 6, 4, 5, 4, 3, 5, 5, 2, 3, 1], {
    //    type: 'line',
    //    width: '99.5%',
    //    height: '100',
    //    lineColor: '#ff407b',
    //    fillColor: '#ffdbe6',
    //    lineWidth: 2,
    //    spotColor: undefined,
    //    minSpotColor: undefined,
    //    maxSpotColor: undefined,
    //    highlightSpotColor: undefined,
    //    highlightLineColor: undefined,
    //    resize: true
    //});



    //$("#sparkline-revenue3").sparkline([5, 3, 4, 6, 5, 7, 9, 4, 3, 5, 6, 1], {
    //    type: 'line',
    //    width: '99.5%',
    //    height: '100',
    //    lineColor: '#25d5f2',
    //    fillColor: '#dffaff',
    //    lineWidth: 2,
    //    spotColor: undefined,
    //    minSpotColor: undefined,
    //    maxSpotColor: undefined,
    //    highlightSpotColor: undefined,
    //    highlightLineColor: undefined,
    //    resize: true
    //});



    //$("#sparkline-revenue4").sparkline([6, 5, 3, 4, 2, 5, 3, 8, 6, 4, 5, 1], {
    //    type: 'line',
    //    width: '99.5%',
    //    height: '100',
    //    lineColor: '#fec957',
    //    fillColor: '#fff2d5',
    //    lineWidth: 2,
    //    spotColor: undefined,
    //    minSpotColor: undefined,
    //    maxSpotColor: undefined,
    //    highlightSpotColor: undefined,
    //    highlightLineColor: undefined,
    //    resize: true,
    //});





    //// ============================================================== 
    //// Total Revenue
    //// ============================================================== 
    //Morris.Area({
    //    element: 'morris_totalrevenue',
    //    behaveLikeLine: true,
    //    data: [
    //        { x: '2016 Q1', y: 0, },
    //        { x: '2016 Q2', y: 7500, },
    //        { x: '2017 Q3', y: 15000, },
    //        { x: '2017 Q4', y: 22500, },
    //        { x: '2018 Q5', y: 30000, },
    //        { x: '2018 Q6', y: 40000, }
    //    ],
    //    xkey: 'x',
    //    ykeys: ['y'],
    //    labels: ['Y'],
    //    lineColors: ['#5969ff'],
    //    resize: true

    //});




    //// ============================================================== 
    //// Revenue By Categories
    //// ============================================================== 

    //var chart = c3.generate({
    //    bindto: "#c3chart_category",
    //    data: {
    //        columns: [
    //            ['Men', 100],
    //            ['Women', 80],
    //            ['Accessories', 50],
    //            ['Children', 40],
    //            ['Apperal', 20],

    //        ],
    //        type: 'donut',

    //        onclick: function(d, i) { console.log("onclick", d, i); },
    //        onmouseover: function(d, i) { console.log("onmouseover", d, i); },
    //        onmouseout: function(d, i) { console.log("onmouseout", d, i); },

    //        colors: {
    //            Men: '#5969ff',
    //            Women: '#ff407b',
    //            Accessories: '#25d5f2',
    //            Children: '#ffc750',
    //            Apperal: '#2ec551',



    //        }
    //    },
    //    donut: {
    //        label: {
    //            show: false
    //        }
    //    },



    //});

