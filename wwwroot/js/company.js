// var dataTable;

$(document).ready(function () {
    $('#tblData').dataTable();
})

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