document.addEventListener('DOMContentLoaded', ChangeStyle, false);


function addRow(tabelId) {

    var table = document.getElementById(tabelId);

    var rowCount = table.rows.length;

    var row = table.insertRow(rowCount);

    var colCount = table.rows[1].cells.length;

    for (var i = 0; i < colCount; i++) {

        var newcell = row.insertCell(i);

        newcell.innerHTML = table.rows[1].cells[i].innerHTML;

        switch (newcell.childNodes[0].type) {
            case "text":
                newcell.childNodes[0].value = "";
                break;
            case "checkbox":
                newcell.childNodes[0].checked = false;
                break;
            case "select-one":
                newcell.childNodes[0].selectedIndex = 0;
                break;
        }
    }

}

function deleteRow(tabelId) {

    try {

        var table = document.getElementById(tabelId);

        var rowCount = table.rows.length;

        for (var i = 1; i < rowCount; i++) {

            var row = table.rows[i];

            var chkbox = row.cells[0].childNodes[0];

            if (null !== chkbox && true === chkbox.checked) {

                if (rowCount <= 2) {

                    break;
                }

                table.deleteRow(i);

                rowCount--;

                i--;
            }
        }

    } catch (e) {

        alert(e);
    }
}

function fillRows(tabelId, data) {

    var table = document.getElementById(tabelId);

    var rowCount = table.rows.length;

    var cellIndex = 0;

    for (var key in data) {

        var row = table.insertRow(rowCount);

        cellIndex = 0;

        var newcell = row.insertCell(cellIndex);

        newcell.innerHTML = table.rows[1].cells[cellIndex].innerHTML;

        newcell.childNodes[0].checked = false;

        for (var key1 in data[key]) {

            newcell = row.insertCell(cellIndex);

            newcell.innerHTML = table.rows[1].cells[i].innerHTML;

            switch (newcell.childNodes[0].type) {
                case "text":
                    newcell.childNodes[0].value = data[key][key1];
                    break;
                case "checkbox":
                    newcell.childNodes[0].checked = false;
                    break;
                case "select-one":
                    newcell.childNodes[0].selectedIndex = 0;
                    break;
            }
            cellIndex++;
        }

        rowCount++;
    }
}


function ChangeStyle() {
    $('.select2DropDown').select2({
        placeholder: "Seçin"
    });
}

function toJSONString(form) {
    var obj = {};
    var elements = form.querySelectorAll("input, select, textarea");
    for (var i = 0; i < elements.length; ++i) {
        var element = elements[i];
        var name = element.name;
        var value = element.value;
        console.log(element.type);
        if (name) {
            switch (element.type) {
                case "select-one":
                    value = parseInt(value);
                    break;
                case "number":
                    value = parseInt(value);
                    break;
            }

            obj[name] = value;
        }
    }

    return JSON.stringify(obj);
}


function createLog() {

    $.ajax({
        url: "Report/Create",
        type: "POST",
        data: $form.serialize(),
        success: function (response) {

            SwalUtility.Success();

        }
    }).fail(function () {

        SwalUtility.Fail();

    });
}