let datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ Registros Por Pagina",
            "zeroRecords": "Ningun Registro",
            "info": "Mostrar pagina _PAGE_ de _PAGES_",
            "infoEmpty": "no hay registros",
            "infoFiltered": "(filtered from _MAX_ total registros)",
            "search": "Buscar",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "ajax": {
            "url": "/Admin/Planta/ObtenerTodos"
        },
        "columns": [
            { "data": "nombreComun", "width": "20%" },
            { "data": "nombreCientifico", "width": "30%" },
            { "data": "estatusAmenaza", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                                <a href = "/Admin/Planta/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="bi bi-pencil"></i>
                                </a>
                                <a onclick=Delete("/Admin/Planta/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="bi bi-trash"></i>
                                </a>
                        </div>
                    `;
                }, "width": "20%"
            }
        ]
    });
}


function Delete(url) {

    swal({
        title: "Está seguro de Eliminar la Especie?",
        text: "Este registro no se podrá recuperar",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                type: "POST",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reaload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
} 
