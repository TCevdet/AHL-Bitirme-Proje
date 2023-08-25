var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url:'/admin/siparis/getall'},
        "columns": [
            { data: 'id', "width": "20%"},
            { data: 'isim', "width": "20%"},
            { data: 'siparisZamani', "width": "20%"},
            { data: 'telefonNo', "width": "20%" },
            { data: 'siparisToplamTutar', "width": "20%" },
            //{
            //    //data: 'id',
            //    //"render": function (data) {
            //    //    //return `<div class="w-75 btn-group" role="group">
            //    //    //<a href="/admin/company/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Düzenle</a>
            //    //    //<a onClick=Delete('/admin/company/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash"></i>Sil</a>
                    
            //    //    //</div>`
            //    //},
            //    //"width": "10%"


            //},

        ]
    });
}


