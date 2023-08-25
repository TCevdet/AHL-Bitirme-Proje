var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url:'/admin/company/getall'},
        "columns": [
            { data: 'isim', "width": "25%"},
            { data: 'adres', "width": "15%"},
            { data: 'sehir', "width": "10%"},
            { data: 'ilce', "width": "15%"},
            { data: 'telefonNo', "width": "10%"},
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/admin/company/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Düzenle</a>
                    <a onClick=Delete('/admin/company/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash"></i>Sil</a>
                    
                    </div>`
                },
                "width": "30%"


            },

        ]
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
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'Delete',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                    
                }

            })
            
        }
    })
}
