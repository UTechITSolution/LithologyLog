$(document).ready(function () {
    $('.select2DropDown').select2({
        placeholder: "Seçin"
    });

    $(".PersonName").select2({

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
         // to adjust proper width of select2 wrapped elements 
        ajax: {
            url: "/Select2/Personel", // Controller - Select2Demo and Action -AccessRemoteData
            type: "Get",
            dataType: 'json',
            data: function (query) {
                //console.log(query); 
                //console.log(query.term);
                return { search: query.term }
            },
            //processes the results from the JSON method and gives us the select list
            processResults: function (data) {
                //console.log(data.items);
                return {
                    results: data.items //JSON.parse()
                };
            }
        },
        allowClear: true,
        minimumInputLength: 1,  // minimumInputLength for sending ajax request to server
        width: 'resolve', 
    });

});