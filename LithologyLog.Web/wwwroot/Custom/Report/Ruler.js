var _font = "14px Arial";

function DrawLeftRuler(ctx) {

    var startIndex = 0;

    var endIndex = 200;

    var lineWidth = 50;

    var rullerBeginHeight = rullerHeight;

    var integralPart = integral(rullerLeftBeginNumber);

    var fractionalPart = fract(rullerLeftBeginNumber);

    if (fractionalPart !== 0) {

        rullerBeginHeight -= fractionalPart;

        startIndex = 10 - fractionalPart;

        endIndex += 10;
    }

    for (var i = startIndex; i <= endIndex; i++) {

        ctx.moveTo(50, rullerBeginHeight);

        if (i === 0) {
            ctx.fillText(integralPart, lineWidth - 32, rullerBeginHeight + 5 + 0.5);
            integralPart--;
        }
        else {
            if (i % 10 === 0) {
                lineWidth -= 8;
                var tmepX = 18;

                if (integralPart > 99) {
                    tmepX = 28;
                }

                ctx.fillText(integralPart, lineWidth - tmepX, rullerBeginHeight + 5 + 0.5);

                integralPart--;
            }
            else if (i % 5 === 0) {
                lineWidth -= 14;
            }
            else {
                lineWidth = 44;
            }

            ctx.moveTo(lineWidth, rullerBeginHeight);

            ctx.lineTo(50, rullerBeginHeight);

            rullerBeginHeight += 7;
        }

    }


    rullerLeftBeginNumber = rullerLeftBeginNumber - 20;
    rullerLeftBeginNumber = Math.round(rullerLeftBeginNumber * 100) / 100;
    ctx.stroke();
}


function DrawRightRuler(ctx) {

    var lineWidth = 60;

    var rullerBeginHeight = rullerHeight;

    var endNumber = rullerRightBeginNumber + 200;

    for (var i = rullerRightBeginNumber; i <= endNumber; i++) {
        ctx.moveTo(50, rullerBeginHeight);

        if (i === 0) {
            ctx.fillText(i / 10, lineWidth + 5, rullerBeginHeight + 5 + 0.5);
        }
        else {
            if (i % 10 === 0) {
                lineWidth += 8;
                ctx.fillText(i / 10, lineWidth + 5, rullerBeginHeight + 5 + 0.5);
            }
            else if (i % 5 === 0) {
                lineWidth += 12;
            }
            else {
                lineWidth = 56;
            }

            ctx.lineTo(lineWidth, rullerBeginHeight);

            rullerBeginHeight += 7;
        }


    }

    rullerRightBeginNumber = endNumber + 1;

    ctx.stroke();
}

function DrawHorRulerOne(ctx, x, y) {

    var color = '#6ABD45';

    ctx.stroke();

    ctx.beginPath();

    ctx.moveTo(x, y);

    ctx.lineTo(x + 125, y);

    ctx.strokeStyle = color;

    ctx.stroke();

    var lineNumber = 0;

    for (var i = 0; i < 26; i++) {

        ctx.moveTo(x, y);

        if (i % 5 === 0) {
             
            ctx.lineTo(x, y + 16);

            ctx.strokeStyle = color;

            ctx.fillStyle = color;

            ctx.fillText(lineNumber, x - 5, y + 28);

            ctx.strokeStyle = color;

            ctx.stroke();

            SetContextDefaultStyle(ctx);

            lineNumber += 10;

            SetContextLightGrayStyle(ctx);

            ctx.moveTo(x, y + 40);

            ctx.lineTo(x, tabelHeight);

            ctx.stroke();

            SetContextDefaultStyle(ctx);
        }
        else {
            ctx.strokeStyle = color;

            ctx.fillStyle = color;

            ctx.lineTo(x, y + 10);

            ctx.stroke();

        }

        x += 5;
    }

}

function DrawHorRulerTwo(ctx, x, y, color) {

    ctx.stroke();

    var lineNumber = 0;

    ctx.beginPath();

    ctx.moveTo(x, y);

    ctx.lineTo(x + 100, y);

    ctx.strokeStyle = color;

    ctx.stroke();


    for (var i = 0; i < 21; i++) {

        ctx.moveTo(x, y);

        if (i % 5 === 0) {

            ctx.lineTo(x, y + 16);

            if (i % 10 === 0) {

                ctx.strokeStyle = color;

                ctx.fillStyle = color;

                ctx.fillText(lineNumber, x - (i === 0 ? 3 : 10), y + 28);

                lineNumber += 200;
            }

            ctx.stroke();

            SetContextLightGrayStyle(ctx);

            ctx.moveTo(x, y + 40);

            ctx.lineTo(x, tabelHeight);

            ctx.stroke();

            SetContextDefaultStyle(ctx);
        }
        else {
            ctx.strokeStyle = color;

            ctx.fillStyle = color;

            ctx.lineTo(x, y + 10);


        }

        x += 5;
    }


}