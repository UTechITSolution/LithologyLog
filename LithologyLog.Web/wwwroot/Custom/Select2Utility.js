
function FillSelect2Utlity(className, url) {
    $(className).select2({
        language: {
            inputTooShort: function () {
                return 'Zəhmət olmasa 1 hərf daxil edin';
            },
            noResults: function () {
                return "Nətice yoxdur";
            },
            searching: function () {
                return "Axtarılır...";
            }
        },
        placeholder: "Axtarış",
        allowClear: true,
        minimumInputLength: 1,
        width: 'resolve',
        ajax: {
            url: url,
            type: "Get",
            dataType: 'json',
            data: function (query) {

                return { search: query.term }
            },
            processResults: function (data) {
                return {
                    results: data.items //JSON.parse()
                };
            }
        }
    });
}
