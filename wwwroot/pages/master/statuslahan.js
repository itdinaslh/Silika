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
        lengthMenu: [5, 10, 25, 50],
        stateSave: true,
        filter: true,
        orderMulti: false,
        ajax: {
            url: "/api/master/status-lahan",
            type: "POST",
            dataType: "json"
        },
        columns: [
            { data: "statusLahanId", name: "statusLahanId", autoWidth: true },
            { data: "namaStatus", name: "namaStatus", autoWidth: true },
            {
                data: 'statusLahanId',
                render: function (data, type, row) { return "<button type='button' class='btn btn-sm btn-success mr-2 showMe' style='width:100%;' data-href='/master/status-lahan/edit/?id=" + row.statusLahanId + "'> Edit</button>" }
            }
        ],
        order: [[0, "desc"]]
    })
}