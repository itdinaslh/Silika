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
            url: "/api/transport/merk-kendaraan",            
            type: "POST",
            dataType: "json"
        },
        columns: [
            { data: "merkID", name: "merkID", autoWidth: true },
            { data: "namaMerk", name: "namaMerk", autoWidth: true },
            {
                data: 'merkID',
                render: function (data, type, row) { return "<button type='button' class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/transport/merk-kendaraan/edit/?jenisId=" + row.merkID + "'> Edit</button>" }
            }
        ],
        order: [[0, "desc"]]
    })
}

