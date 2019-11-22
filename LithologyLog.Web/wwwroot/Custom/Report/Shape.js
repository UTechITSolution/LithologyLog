
function DrawRectangle(ctx, x, color, text) {


    ctx.fillText(text, x + 2, headerHeight - 75);
    ctx.fillText('%', x + 10, headerHeight - 55);
    ctx.fillStyle = color;
    ctx.fillRect(x, headerHeight - 50, 40, 40);
    ctx.stroke();
    SetContextDefaultStyle(ctx);
}

function DrawRectangleWithText(ctx, X1, width, beginHeight, endHeight, x, y, color, lineText) {

    ctx.fillStyle = color;

    ctx.fillRect(X1, beginHeight, width, endHeight);

    ctx.stroke();

    SetContextDefaultStyle(ctx);

    ctx.font = "14px Arial";

    ctx.fillText(lineText, x, y);

    SetContextDefaultStyle(ctx);
}

function DrawLineBetwenRec(ctx, pageId, order, x, y) {

    var color = "#6ABD45";

    for (var i = 0; i < lineArray.length; i++) {

        if (lineArray[i].Order === order && lineArray[i].PageId === pageId) {

            ctx.moveTo(x, y + 0.5);

            ctx.strokeStyle = color;

            ctx.fillStyle = color;

            ctx.lineTo(lineArray[i].X, lineArray[i].Y1 + 0.5);

            ctx.stroke();

            SetContextDefaultStyle(ctx);

        }
    }
}