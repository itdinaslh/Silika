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
            url: "/api/transport/tipe-kendaraan",
            type: "POST",
            dataType: "json"
        },
        columns: [
            { data: "tipeKendaraanId", name: "tipeKendaraanId", autoWidth: true },
            { data: "namaMerk", name: "namaMerk", autoWidth: true },
            { data: "namaTipe", name: "namaTipe", autoWidth: true },
            {
                data: 'tipeKendaraanId',
                render: function (data, type, row) { return "<button type='button' class='btn btn-sm btn-success mr-2 showMe' style='width:100%;' data-href='/transport/tipe-kendaraan/edit/?id=" + row.tipeKendaraanId + "'> Edit</button>" }
            }
        ],
        order: [[0, "desc"]]
    })
}


$(document).on('shown.bs.modal', function () {
    $('#sMerk').select2({
        placeholder: 'Pilih Merk...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/transport/merk/search",
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            text: item.namaMerk,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
});