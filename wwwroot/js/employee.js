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
