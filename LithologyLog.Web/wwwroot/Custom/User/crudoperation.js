$(document).on("click", ".btnPageEdit", function (event) {
    event.preventDefault();

    const $form = $(this).parent().parent();
    const method = $form.attr("method");
    const action = $form.attr("action");

    $.validator.unobtrusive.parse($form);
    if ($form.valid()) {
        $.ajax({
            url: action,
            type: method,
            data: $form.serialize(),
            success: function (response) {

                if (response.status === 200) {
                    SwalUtility.Success();
                }
                else {
                    SwalUtility.Fail(response.message);
                }


            }
        }).fail(function () {



        });
    }

});


$(document).on("click", ".btnPageAdd", function (event) {
    event.preventDefault();

    const $form = $(this).parent().parent();
    const method = $form.attr("method");
    const action = $form.attr("action");

    $.validator.unobtrusive.parse($form);
    if ($form.valid()) {
        $.ajax({
            url: action,
            type: method,
            data: $form.serialize(),
            success: function (response) {

                if (response.status === 200) {
                    SwalUtility.Success();
                }
                else {
                    SwalUtility.Fail(response.message);
                }

            }
        }).fail(function () {

            SwalUtility.Fail();

        });
    }

});