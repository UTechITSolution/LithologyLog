function DateFormat(s) {
    var v = s.value;
    if (v.match(/^\d{2}$/) !== null) {
        s.value = v + '/';
    } else if (v.match(/^\d{2}\/\d{2}$/) !== null) {
        s.value = v + '/';
    }
}

function TimeFormat(s) {
    var v = s.value;
    if (v.match(/^\d{2}$/) !== null) {
        s.value = v + ':';
    } else if (v.match(/^\d{2}\/\d{2}$/) !== null) {
        s.value = v + ':';
    }
}
