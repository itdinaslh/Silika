$(document).ready(function () {
    loadTable();
});

function loadContent() {
    loadTable();
}

function loadTable() {
    $('#tblData').DataTable().clear().destroy();
    $('#tblData').DataTable({
        processing: false,
        serverSide: true,
        lengthMenu: [5,10,25,50],
        stateSave: true,
        filter: true,
        orderMulti: false,
        ajax: {
            url: "/api/wr/jenis",            
            type: "POST",
            dataType: "json"
        },
        columns: [
            { data: "namaJenis", name: "namaJenis", autoWidth: true },
            { data: "noRekening", name: "noRekening", autoWidth: true },
            {
                data: 'jenisID',
                render: function (data, type, row) { return "<button type='button' class='btn btn-sm btn-success mr-2 showMe' style='width:100%;' data-href='/wr/jenis/edit/?jenisId=" + row.jenisID + "'> Edit</button>" }
            }
        ],
        order: [[0, "desc"]]
    })
}

