//#region Draw columns border and text

function GenerateColumn(ctx) {

    DrawColumn_0(ctx);

    DrawColumn_1(ctx);

    DrawColumn_2(ctx);

    DrawColumn_3(ctx);

    DrawColumn_4(ctx);

    DrawColumn_5(ctx);

    DrawColumn_6(ctx);

    DrawColumn_7(ctx);

    DrawColumn_8(ctx);

    DrawColumn_9(ctx);

    DrawColumn_10(ctx);

    DrawColumn_11(ctx);

    DrawColumn_12(ctx);

}

function DrawColumn_0(ctx) {

    VerticalText(ctx, 0);

}

function DrawColumn_1(ctx) {

    VerticalText(ctx, 1);
}

function DrawColumn_2(ctx) {

    var column = _columns[2];

    if (column.Visible) {
        VerticalText(ctx, 2);
    }
}

function DrawColumn_3(ctx) {

    var column = _columns[3];

    if (column.Visible) {
        VerticalText(ctx, 3);
    }
}

function DrawColumn_4(ctx) {

    var column = _columns[4];
    if (column.Visible) {
        VerticalText(ctx, 4);
    }
}

function DrawColumn_5(ctx) {

    var column = _columns[5];

    if (column.Visible) {
        VerticalText(ctx, 5);
    }
}

function DrawColumn_6(ctx) {

    var column = _columns[6];

    if (column.Visible) {
        VerticalText(ctx, 6);
    }
}

function DrawColumn_7(ctx) {

    var column = _columns[7];
    if (column.Visible) {
        HorizontalText(ctx, 7, headerHeight / 2);
    }

}


function DrawColumn_11(ctx) {

    var column = _columns[11];
    if (column.Visible) {
        VerticalText(ctx, 11);
    }


}

function DrawColumn_8(ctx) {

    var column = _columns[8];

    if (column.Visible) {
        ctx.moveTo(column.X, 0.5);

        ctx.lineTo(column.X, tabelHeight);

        var X1 = column.X - column.Width;

        ctx.moveTo(X1, seperateHeight);

        ctx.lineTo(column.X, seperateHeight);

        HorizontalText(ctx, 8, seperateHeight);

        var eachColumn = column.Width / 3;


        ctx.moveTo(X1 + eachColumn, seperateHeight);

        ctx.lineTo(X1 + eachColumn, tabelHeight);

        ctx.moveTo(X1 + eachColumn * 2, seperateHeight);

        ctx.lineTo(X1 + eachColumn * 2, tabelHeight);

        FillText(ctx, column.PartTextOne, X1 + eachColumn / 2 + 5, headerHeight - 10);
        FillText(ctx, column.PartTextTwo, X1 + column.Width / 2 + 5, headerHeight - 10);
        FillText(ctx, column.PartTextThree, X1 + column.Width - eachColumn / 2 + 5, headerHeight - 10);

    }

}

function DrawColumn_9(ctx) {
    var column = _columns[9];

    if (column.Visible) {

        ctx.moveTo(column.X, 0.5);

        ctx.lineTo(column.X, tabelHeight);

        var X1 = column.X - column.Width;

        HorizontalText(ctx, 9, headerHeight / 2);

        DrawHorRulerOne(ctx, X1 + 8, headerHeight - 40);
    }


}

function DrawColumn_10(ctx) {

    var column = _columns[10];

    if (column.Visible) {

        ctx.moveTo(column.X, 0.5);

        ctx.lineTo(column.X, tabelHeight);

        var X1 = column.X - column.Width;

        ctx.moveTo(X1, seperateHeight);

        ctx.lineTo(column.X, seperateHeight);

        HorizontalText(ctx, 10, seperateHeight);

        var eachColumn = column.Width / 2;

        ctx.moveTo(X1 + eachColumn, seperateHeight);

        ctx.lineTo(X1 + eachColumn, tabelHeight);

        var marginLeft = (eachColumn - ctx.measureText(column.PartTextOne).width) / 2;

        ctx.fillText(column.PartTextOne, X1 + marginLeft, headerHeight - 60);

        marginLeft = (eachColumn - ctx.measureText(column.PartTextTwo).width) / 2;

        ctx.fillText(column.PartTextTwo, X1 + eachColumn + marginLeft, headerHeight - 60);

        var rullerOneX1 = X1 + (eachColumn - 100) / 2;

        var rullerTwoX1 = X1 + eachColumn + (eachColumn - 100) / 2;

        DrawHorRulerTwo(ctx, rullerOneX1, headerHeight - 40);

        DrawHorRulerTwo(ctx, rullerTwoX1, headerHeight - 40);
    }


}


function DrawColumn_12(ctx) {

    var column = _columns[12];

    if (column.Visible) {
        var X1 = column.X - column.Width;

        HorizontalText(ctx, 12, 100);

        var eachColumn = column.Width / 3;

        DrawRectangle(ctx, X1 + eachColumn / 2 - 20, headerHeight - 40, "red", column.PartTextOne);
        DrawRectangle(ctx, X1 + column.Width / 2 - 20, headerHeight - 40, "red", column.PartTextTwo);
        DrawRectangle(ctx, X1 + column.Width - eachColumn / 2 - 20, headerHeight - 40, "red", column.PartTextThree);

    }
}



//#endregion


//#region fill columns 

function FillColumn(ctx) {

    FillColumn_3(ctx);
    FillColumn_4(ctx);
    FillColumn_5(ctx);
    FillColumn_6(ctx);
    FillColumn_7(ctx);
}


function FillCell(ctx, length, index, text) {

    var page = FindPage(length);

    if (page === FindCanvasId(ctx)) {

        var column = _columns[index];

        var height = (immutablerLeftBeginNumber - length - (page - 1) * 20) * 70 + rullerHeight;

        ctx.moveTo(column.X - column.Width, height);

        ctx.lineTo(column.X, height);

        var marginLeft = (column.Width - ctx.measureText(length).width) / 2;

        var X1 = column.X - column.Width;

        ctx.fillText(text, X1 + marginLeft, height - 10);

    }
}

function FillColumn_3(ctx) {

    var column = _columns[2];

    if (column.Visible) {

        var columnValues = _pageCreationMember.Columns_3;

        for (var i = 0; i < columnValues.length; i++) {

            FillCell(ctx, columnValues[i].Y, 2, columnValues[i].Value);
        }
    }

}

function FillColumn_4(ctx) {

    var column = _columns[3];

    if (column.Visible) {

        var columnValues = _pageCreationMember.Columns_4;

        for (var i = 0; i < columnValues.length; i++) {

            FillCell(ctx, columnValues[i].Y, 3, columnValues[i].Value);
        }
    }
}

function FillColumn_5(ctx) {

    var column = _columns[4];

    if (column.Visible) {
        var columnValues = _pageCreationMember.Columns_5;

        for (var i = 0; i < columnValues.length; i++) {

            FillCell(ctx, columnValues[i].Y, 4, columnValues[i].Value);
        }
    }
}

function FillColumn_6(ctx) {

    var column = _columns[5];

    if (column.Visible) {
        var columnValues = _pageCreationMember.Columns_6;

        for (var i = 0; i < columnValues.length; i++) {

            var Y1 = columnValues[i].Y;

            var Y2 = columnValues[i].Y2;

            var pageY1 = FindPage(Y1);

            var pageY2 = FindPage(Y2);

            if (pageY1 === FindCanvasId(ctx)) {

                let column = _columns[5];

                let beginHeight = (immutablerLeftBeginNumber - Y1 - (pageY1 - 1) * 20) * 70 + rullerHeight - 7.5;

                let endHeight = (Y1 - Y2) * 70 + 7.5;

                let X1 = column.X - column.Width;

                let img = new Image();

                img.src = columnValues[i].ImageSrc;

                img.onload = function () {

                    let ptrn = ctx.createPattern(img, 'repeat');

                    ctx.fillStyle = ptrn;

                    ctx.fillRect(X1, beginHeight, column.Width, endHeight);
                };

                if (pageY2 === FindCanvasId(ctx)) {
                    let lineHeight = (immutablerLeftBeginNumber - Y2 - (pageY2 - 1) * 20) * 70 + rullerHeight;

                    ctx.moveTo(column.X - column.Width, lineHeight);

                    ctx.lineTo(column.X, lineHeight);
                }




            }
            else if (pageY2 > FindCanvasId(ctx)) {
                let column = _columns[5];

                let X1 = column.X - column.Width;

                let img = new Image();

                img.src = columnValues[i].ImageSrc;

                img.onload = function () {

                    let ptrn = ctx.createPattern(img, 'repeat');

                    ctx.fillStyle = ptrn;

                    ctx.fillRect(X1, rullerHeight - 7.5, column.Width, tabelHeight);
                };
            }
            else if (pageY2 === FindCanvasId(ctx)) {

                let column = _columns[5];

                let endHeight = (immutablerLeftBeginNumber - Y2) % 20 * 70 + 7.5;

                let X1 = column.X - column.Width;

                let img = new Image();

                img.src = columnValues[i].ImageSrc;

                img.onload = function () {

                    let ptrn = ctx.createPattern(img, 'repeat');

                    ctx.fillStyle = ptrn;

                    ctx.fillRect(X1, rullerHeight - 7, column.Width, endHeight);
                };

                let lineHeight = (immutablerLeftBeginNumber - Y2 - (pageY2 - 1) * 20) * 70 + rullerHeight;

                ctx.moveTo(column.X - column.Width, lineHeight);

                ctx.lineTo(column.X, lineHeight);
            }
        }
    }





}


function FillColumn_7(ctx) {

    var column = _columns[11];


    if (column.Visible) {

        var columnValues = _pageCreationMember.Columns_12;

        for (var i = 0; i < columnValues.length; i++) {

            var length = columnValues[i].Y;

            var page = FindPage(length);

            if (page === FindCanvasId(ctx)) {

                var height = (immutablerLeftBeginNumber - length - (page - 1) * 20) * 70 + rullerHeight;

                ctx.moveTo(column.X - column.Width, height);

                var X1 = column.X - column.Width;

                WriteRotateText(ctx, columnValues[i].Value, X1 + column.Width / 2 + 5, height);

            }
        }
    }
}

function FindPage(length) {

    if (immutablerLeftBeginNumber === length) {

        return 1;
    }

    return Math.ceil((immutablerLeftBeginNumber - length) / 20);
}

function FindCanvasId(ctx) {
    return parseInt(ctx.canvas.id.split('_')[1]);
}

