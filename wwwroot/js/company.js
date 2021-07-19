var table;

$(document).ready(function () {
    table = $('#tblData').dataTable();
})

function deleteEntry(url) {
    Swal.fire({
        title: "Are you sure you want to delete?",
        text: "You will not be able to recover this entry!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: '#FF7851',
        button: true,
        dangerMode: true
    }).then((deleted) => {
        if (deleted.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        window.location.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}

/*function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Company/GetAll"
        },
        "columns": [
            { "data": "name", "width": "60%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center" style="display:flex; justify-content:center">
                        <div style="margin-right:1em">
                            <a href="../Company/Edit/${data}" class="btn btn-success text-light" style="cursor:pointer">
                                <i class="bi bi-pencil-square">&nbsp; Edit</i>
                            </a>
                        </div>

                        <div>
                            <a class="btn btn-danger text-light" style="cursor:pointer">
                                <i class="bi bi-x-circle">&nbsp; Delete</i>
                            </a>
                        </div>
                        </div>
                        `
                }, "width": "10%"

            }
        ]
    });
}*/