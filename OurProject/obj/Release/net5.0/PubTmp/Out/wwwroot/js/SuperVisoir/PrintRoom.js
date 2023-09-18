function PrintElem() {
    var mywindow = window.open('', 'PRINT');


    document.getElementById("example_filter").style.display = "none";
    document.getElementById("example_length").style.display = "none";
    document.getElementById("example_paginate").style.display = "none";
    document.getElementById("example_info").style.display = "none";
    document.getElementById("header").style.display = "block";
    document.getElementById("footer").style.display = "block";



    var css = "";
    var myStylesLocation = "/css/SuperVisoir/rooms.css";
    var css1 = "";
    var myStylesLocation1 = "/css/StoreKeeper/DataTable/bootstrap.min.css";
    var css2 = "";
    var myStylesLocation2 = "/css/StoreKeeper/DataTable/dataTables.bootstrap5.min.css";

    $.ajax({
        url: myStylesLocation,
        type: "GET",
        async: false
    }).done(function (data) {
        css += data;
    })
    $.ajax({
        url: myStylesLocation1,
        type: "GET",
        async: false
    }).done(function (data) {
        css1 += data;
    })
    $.ajax({
        url: myStylesLocation2,
        type: "GET",
        async: false
    }).done(function (data) {
        css2 += data;
    })

    mywindow.document.write('<html><head><title></title>');
    mywindow.document.write('<style type="text/css">' + css + ' </style>');
    mywindow.document.write('<style type="text/css">' + css1 + ' </style>');
    mywindow.document.write('<style type="text/css">' + css2 + ' </style>');
    mywindow.document.write('<link rel="stylesheet"  href="~/lib/bootstrap/dist/css/bootstrap.min.css" type="text/css" media="print"/>');
    mywindow.document.write('<link rel="stylesheet"  href="~/css/site.css" type="text/css" media="print"/>');
    mywindow.document.write('</head><body >');
    mywindow.document.write(document.getElementById("DivIdToPrint").innerHTML);
    mywindow.document.write('</body></html>');
    mywindow.document.close(); // necessary for IE >= 10
    mywindow.focus(); // necessary for IE >= 10*/

    mywindow.print();
    mywindow.close();

    document.getElementById("example_filter").style.display = "block";
    document.getElementById("example_length").style.display = "block";
    document.getElementById("example_paginate").style.display = "block";
    document.getElementById("example_info").style.display = "block";
    document.getElementById("header").style.display = "none";
    document.getElementById("footer").style.display = "none";

    return true;


}