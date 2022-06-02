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
            url: "/api/master/bidang",            
            type: "POST",
            dataType: "json"
        },
        columns: [
            { data: "namaBidang", name: "namaBidang", autoWidth: true },
            { data: "kepalaBidang", name: "kepalaBidang", autoWidth: true },
            {
                data: 'bidangID',
                render: function (data, type, row) { return "<button type='button' class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/master/bidang/edit/?bidangId=" + row.bidangID + "'> Edit</button>" }
            }
        ],
        order: [[0, "desc"]]
    })
}

