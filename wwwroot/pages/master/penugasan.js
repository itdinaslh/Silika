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
            url: "/api/master/penugasan",
            type: "POST",
            dataType: "json"
        },
        columns: [
            { data: 'penugasanId', name: 'penugasanId', autoWidth: true },
            { data: "namaPenugasan", name: "namaPenugasan", autoWidth: true },            
            {
                data: 'penugasanId',
                render: function (data, type, row) { return "<button type='button' class='btn btn-sm btn-success mr-2 showMe' style='width:100%;' data-href='/master/penugasan/edit/?id=" + row.penugasanId + "'> Edit</button>" }
            }
        ],
        order: [[0, "desc"]]
    })
}