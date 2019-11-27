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
            "url": "/Report/LoadDataForTable",
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
                                <a href="/Report/Edit?id=${row.Id}" class=" btn text-primary btn-sm "><i class='fa fa-edit'></i></a>
                               </li>
                               <li class="mr-2">
                                <a href="/Report/Delete?id=${row.Id}"  id="deleteButton" class=" btn text-primary btn-sm "><i class='fa fa-trash'></i></a>
                               </li>
                            </ul>`;
                }
            },
            { "data": "ContractorOrg", "autoWidth": true },
            { "data": "ClientOrg", "autoWidth": true },
            { "data": "ProjectName", "autoWidth": true },
            { "data": "SiteName", "autoWidth": true },
        ]


    });
 
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