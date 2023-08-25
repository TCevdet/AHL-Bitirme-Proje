'use strict';

var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/urun/getall' },
        "columns": [{ data: 'urunAdi', "width": "25%" }, { data: 'kategori.ad', "width": "15%" }, { data: 'urunKodu', "width": "10%" }, { data: 'urunMarka', "width": "15%" }, { data: 'listeFiyat', "width": "10%" }, {
            data: 'id',
            "render": function render(data) {
                return '<div class="w-75 btn-group" role="group">\n                    <a href="/admin/urun/upsert?id=' + data + '" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Düzenle</a>\n                    <a onClick=Delete(\'/admin/urun/delete/' + data + '\') class="btn btn-danger mx-2"> <i class="bi bi-trash"></i>Sil</a>\n                    \n                    </div>';
            },
            "width": "30%"

        }]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Emin misiniz?',
        text: "Bu işlem geri döndürülemez.",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, Sil'
    }).then(function (result) {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'Delete',
                success: function success(data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }

            });
        }
    });
}

