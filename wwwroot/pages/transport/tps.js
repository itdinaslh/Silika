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

$(document).on('shown.bs.modal', function () {
    // initiate select2 for kecamatan & kelurahan    
    $('#Kecamatan').select2({
        placeholder: 'Pilih Kecamatan...'
    });
    
    $('#Kelurahan').select2({
        placeholder: 'Pilih Kelurahan...'
    });

    // Jenis TPS API search
    $('#JenisTPS').select2({
        placeholder: 'Pilih Jenis TPS...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/transport/jenis-tps/search",
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

    // Status Lahan API search
    $('#StatusLahan').select2({
        placeholder: 'Pilih Status Lahan...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/master/status-lahan/search",
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
                            text: item.namaStatus,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });

    // Kabupaten asal api search
    $('#Kota').select2({
        placeholder: 'Pilih Kota/Kabupaten...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/master/kabupaten/search",
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
                            text: item.namaKabupaten,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });

    $('#Kota').change(function () {
        var thisKab = this.value;

        if (thisKab == '') {
            $('#Kecamatan').prop("disabled", true);
        } else {
            $('#Kecamatan').prop("disabled", false);
            $('#Kecamatan').val(null).trigger('change');
            PopulateKecamatan(thisKab);
        }
    });

    $('#Kecamatan').change(function () {
        var thisKec = this.value;

        if (thisKec == '') {
            $('#Kelurahan').prop("disabled", true);
        } else {
            $('#Kelurahan').prop("disabled", false);
            $('#Kelurahan').val(null).trigger('change');
            PopulateKelurahan(thisKec);
        }
    });
});

function PopulateKecamatan(kab) {
    $('#Kecamatan').select2("destroy");
    $('#Kecamatan').select2({
        placeholder: 'Pilih Kecamatan...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/master/kecamatan/search/?kab=" + kab,
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
                            text: item.namaKecamatan,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
}

function PopulateKelurahan(kab) {
    $('#Kelurahan').select2("destroy");
    $('#Kelurahan').select2({
        placeholder: 'Pilih Kelurahan...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/master/kelurahan/search/?kec=" + kab,
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
                            text: item.namaKelurahan,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
}