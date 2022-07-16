$(document).ready(function () {
    loadTable();
});

$(document).on('select2:open', () => {
    document.querySelector('.select2-search__field').focus();
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
            url: "/api/transport/tps",
            type: "POST",
            dataType: "json"
        },
        columns: [
            { data: "tpsId", name: "tpsId", autoWidth: true },
            { data: "namaTps", name: "namaTps", autoWidth: true },
            { data: "namaKecamatan", name: "namaKecamatan", autoWidth: true },
            { data: "namaKelurahan", name: "namaKelurahan", autoWidth: true },
            { data: "namaJenis", name: "bidang", autoWidth: true },
            { data: "namaStatus", name: "namaStatus", autoWidth: true },            
            {
                data: 'tpsId',
                render: function (data, type, row) { return "<button type='button' class='btn btn-sm btn-success mr-2 showMe' style='width:100%;' data-href='/transport/tps/edit/?id=" + row.tpsId + "'> Edit</button>" }
            }
        ],
        order: [[0, "desc"]]
    })
}