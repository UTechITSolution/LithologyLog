class SwalUtility {
    static Success() {
        var table = $("#dataTable").DataTable();
        table.draw();

        Swal.fire({
            type: 'success',
            title: 'Əməliyyat yerinə yetirildi',
            showConfirmButton: false,
            timer: 1000
        });

        $("button#closeModal").click();
    }

    static Fail() {
        var table = $("#dataTable").DataTable();
        table.draw();

        Swal.fire({
            type: 'error',
            title: 'Xəta baş verdi',
            showConfirmButton: false,
            timer: 1000
        });

        $("button#closeModal").click();
    }

    static Fail(text) {
        var table = $("#dataTable").DataTable();
        table.draw();

        Swal.fire({
            type: 'error',
            title: text,
            showConfirmButton: false,
            timer: 2000
        });

        $("button#closeModal").click();
    }


    static Delete(url) {
        Swal.fire({
            title: 'Silmək istədiyinizə əminsiniz?',
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sil!',
            cancelButtonText: 'Imtina et'
        }).then((result) => {
            if (result.value) {
                $.get(url).done(function (response) {

                    if (response.status === 200) {
                        var tables = $("#dataTable").DataTable();
                        tables.draw();

                        Swal.fire({
                            type: 'success',
                            title: response.message,
                            showConfirmButton: false,
                            timer: 2000
                        });
                    } else if (response.status === 402) {
                        Swal.fire({
                            type: 'error',
                            title: response.message,
                            showConfirmButton: true
                        });
                    } else if (response.status === 400) {
                        Swal.fire({
                            type: 'error',
                            title: response.message,
                            showConfirmButton: true
                        });
                    } else {
                        Swal.fire({
                            type: 'error',
                            title: response.message,
                            showConfirmButton: true
                        });
                    }
                });
            }
        });
    }

}

