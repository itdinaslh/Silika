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
            url: "/api/kualitas-lingkungan/jenis-pencemaran",            
            type: "POST",
            dataType: "json"
        },
        columns: [
            { data: "jenisID", name: "jenisID", autoWidth: true },
            { data: "namaJenis", name: "namaJenis", autoWidth: true },
            {
                data: 'jenisID',
                render: function (data, type, row) { return "<button type='button' class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/kualitas-lingkungan/jenis-pencemaran/edit/?jenisId=" + row.jenisID + "'> Edit</button>" }
            }
        ],
        order: [[0, "desc"]]
    })
}

