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

    var res = text.split("~");

    var lineMargin = 0;

    if (res.length === 2) {
        lineMargin = 15;
    }
    if (res.length === 3) {
        lineMargin = 30;
    }


    WriteRotateText(ctx,res[0], x - lineMargin, y);

    if (res.length >= 2) {
        WriteRotateText(ctx,res[1], x, y);
    }
    if (res.length >= 3) {
        WriteRotateText(ctx,res[2], x + lineMargin + 10, y);
    }

}