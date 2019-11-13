$(document).ready(function () {
    $("#dataTable").DataTable({
        "language": {
            "url": "/DataTables/Azerbaijan.json"
        },
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ordering": false,
        "ajax": {
            "url": "/Organization/LoadDataForTable",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs":
            [{
                //"targets": [0],
                //"visible": false
            }],
        "columns": [
            {
                data: null, render: function (row) {
                    return `<ul class="d-flex justify-content-center">
                               <li class="mr-2">
                                <a href="/Organization/Edit?id=${row.Id}" data-toggle="modal" id="editButton"  data-target="#pageModal" class=" btn text-primary btn-sm "><i class='fa fa-edit'></i></a>
                               </li>
                               <li class="mr-2">
                                <a href="/Organization/Delete?id=${row.Id}"   id="deleteButton" class=" btn text-primary btn-sm "><i class='fa fa-trash'></i></a>
                               </li>
                            </ul>`;
                }
            },
            { "data": "Name", "autoWidth": true },
            { "data": "ShortName", "autoWidth": true },
            { "data": "MobileNumber", "autoWidth": true },
            { "data": "Email", "autoWidth": true },
            { "data": "Fax", "autoWidth": true },
            { "data": "TIN", "autoWidth": true }
        ]


    });

    $(document).on("click", "#editButton", function (event) { FillModal(this, event); });

    $(document).on("click", "#addButton", function (event) { FillModal(this, event); });

    $(document).on("click",
        "#deleteButton",
        function (event) {
            event.preventDefault();

            const href = $(this).attr("href");

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

                    $.post(href).done(function (response) {

                        SwalUtility.Success();

                    }).fail(function () {

                        SwalUtility.Fail();

                    });
                }
            });
        });
});



function FillModal(s, e) {

    e.preventDefault();
    const href = $(s).attr("href");
    const modelDialog = $(s).attr("data-target");

    $.ajax({
        url: href
    }).done(
        function (response) {
            $(modelDialog.concat(" .modal-dialog")).html(response);
        });
}