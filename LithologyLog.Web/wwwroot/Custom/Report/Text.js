function VerticalText(ctx, index) {

    var column = _columns[index];

    ctx.moveTo(column.X, 0.5);

    ctx.lineTo(column.X, tabelHeight);

    var center = column.X - column.Width / 2;

    FillText(ctx, column.MainText, center, headerHeight - 10);
}

function HorizontalText(ctx, index, height) {

    var column = _columns[index];

    ctx.moveTo(column.X, 0.5);

    ctx.lineTo(column.X, tabelHeight);

    var X1 = column.X - column.Width;

    var center = height / 2;

    var res = column.MainText.split("~");

    var marginTop = 0;

    if (res.length === 2) {
        marginTop += 15;
        center += 15;
    }

    if (res.length === 3) {
        marginTop += 20;
        center += 20;

    }

    var marginLeft = (column.Width - ctx.measureText(res[0]).width) / 2;

    ctx.fillText(res[0], X1 + marginLeft, center - marginTop);

    if (res.length >= 2) {
        marginLeft = (column.Width - ctx.measureText(res[1]).width) / 2;
        ctx.fillText(res[1], X1 + marginLeft, center);
    }

    if (res.length >= 3) {
        marginLeft = (column.Width - ctx.measureText(res[2]).width) / 2;
        ctx.fillText(res[2], X1 + marginLeft, center + marginTop);
    }



}

function WriteRotateText(ctx, text, x, y) {

    ctx.save();

    ctx.translate(x, y);

    ctx.rotate(-0.5 * Math.PI);

    ctx.fillText(text, 0, 0);

    ctx.restore();

}

function FillText(ctx, text, x, y) {

    y = y + 7;
    var res = text.split("~");

    var lineMargin = 0;

    if (res.length === 2) {
        lineMargin = 10;
    }
    if (res.length === 3) {
        lineMargin = 20;
    }


    WriteRotateText(ctx, res[0], x - lineMargin, y);

    if (res.length >= 2) {
        WriteRotateText(ctx, res[1], x+10, y);
    }
    if (res.length >= 3) {
        WriteRotateText(ctx, res[2], x + lineMargin + 10, y);
    }

}

function SplitText(ctx, text, width) {

    var res = text.split(' ');

    var linesArray = new Array();

    width -= 20;

    var currentTotalWidth = 0;

    var currentWordWidth = 0;

    var lineWords = '';

    for (var i = 0; i < res.length; i++) {

        currentWordWidth = ctx.measureText(res[i]).width;

        if (currentWordWidth + currentTotalWidth < width) {

            if (currentTotalWidth === 0) {
                lineWords += res[i];
            }
            else {
                lineWords += ' ' + res[i];
            }

        }
        else {

            linesArray.push(lineWords);

            lineWords = res[i];

            currentTotalWidth = 0;
        }

        currentTotalWidth += currentWordWidth;
    }

    linesArray.push(lineWords);

    return linesArray;

}

 