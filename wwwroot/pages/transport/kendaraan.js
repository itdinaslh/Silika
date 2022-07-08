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
            url: "/api/transport/kendaraan",
            type: "POST",
            dataType: "json"
        },
        columns: [
            { data: "kendaraanId", name: "kendaraanId", autoWidth: true },
            { data: "noPolisi", name: "noPolisi", autoWidth: true },
            { data: "jenis", name: "jenis", autoWidth: true },
            { data: "tahun", name: "tahun", autoWidth: true },
            { data: "bidang", name: "bidang", autoWidth: true },
            { data: "kabupaten", name: "kabupaten", autoWidth: true },
            { data: "kecamatan", name: "kecamatan", autoWidth: true },
            {
                data: 'kendaraanId',
                render: function (data, type, row) { return "<button type='button' class='btn btn-sm btn-success mr-2 showMe' style='width:100%;' data-href='/transport/kendaraan/edit/?jenisId=" + row.kendaraanId + "'> Edit</button>" }
            }
        ],
        order: [[0, "desc"]]
    })
}

$(document).on('shown.bs.modal', function () {
    // Merk API search
    $('#MyMerk').select2({
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

    // Tipe api search
    $('#MyTipe').select2({
        placeholder: 'Pilih Tipe...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/transport/tipe/search",
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
                            text: item.namaTipe,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });

    // Jenis api search
    $('#MyJenis').select2({
        placeholder: 'Pilih Jenis...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/transport/jenis/search",
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
                            text: item.namaJenis,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
});