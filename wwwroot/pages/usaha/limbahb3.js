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
            url: "/api/usaha/limbahb3",
            type: "POST",
            dataType: "json"
        },
        columns: [
            { data: "limbahB3Id", name: "limbahB3Id", autoWidth: true },
            { data: "kodeLimbah", name: "kodeLimbah", autoWidth: true },
            { data: "namaLimbah", name: "namaLimbah", autoWidth: true },          
            {
                data: 'limbahB3Id',
                render: function (data, type, row) { return "<button type='button' class='btn btn-sm btn-success mr-2 showMe' style='width:100%;' data-href='/usaha/limbahb3/edit/?id=" + row.limbahB3Id + "'> Edit</button>" }
            }
        ],
        order: [[0, "desc"]]
    })
}