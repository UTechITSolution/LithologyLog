
function DrawRectangle(ctx, x, y, color, text) {


    ctx.fillText(text, x + 2, headerHeight - 75);
    ctx.fillText('%', x + 10, headerHeight - 55);
    ctx.rect(x, headerHeight - 50, 40, 40);
    ctx.stroke();
}