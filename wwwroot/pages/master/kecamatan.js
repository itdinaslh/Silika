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
        filter: true,
        stateSave: true,
        orderMulti: false,
        ajax: {
            url: "https://localhost:7177/api/wilayah/kecamatan",
            type: "POST",
            dataType: "json"
        },
        columns: [
            { data: "kecamatanID", name: "kecamatanID", autoWidth: true },
            { data: "namaKecamatan", name: "namaKecamatan", autoWidth: true },
            { data: "namaKabupaten", name: "namaKabupaten", autoWidth: true },
            { data: "namaProvinsi", name: "namaProvinsi", autoWidth: true },
            { data: "latitude", name: "latitude", autoWidth: true },
            { data: "longitude", name: "longitude", autoWidth: true },
            {
                data: 'kecamatanID',
                render: function (data, type, row) { return "<button type='button' class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/master/kecamatan/edit/?kecamatanID=" + row.kecamatanID + "'> Edit</button>" }
            }
        ],
        order: [[0, "desc"]]
    })
}

$(document).on('shown.bs.modal', function () {
    $('#sProvinsi').select2({
        placeholder: 'Pilih Provinsi...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/wilayah/provinsi/search",
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
                            text: item.namaProvinsi,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
});