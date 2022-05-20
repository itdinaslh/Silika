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
            url: "/api/kualitas-lingkungan/nilai-pencemaran",            
            type: "POST",
            dataType: "json"
        },
        columns: [
            { data: "nilaiID", name: "nilaiID", autoWidth: true },
            { data: "namaNilai", name: "namaNilai", autoWidth: true },
            { data: "awal", name: "awal", autoWidth: true },
            { data: "akhir", name: "akhir", autoWidth: true },
            {
                data: 'nilaiID',
                render: function (data, type, row) { return "<button type='button' class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/kualitas-lingkungan/nilai-pencemaran/edit/?nilaiID=" + row.nilaiID + "'> Edit</button>" }
            }
        ],
        order: [[0, "desc"]]
    })
}

