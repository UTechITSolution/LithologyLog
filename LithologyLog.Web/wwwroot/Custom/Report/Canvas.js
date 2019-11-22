
var contexts = new Array();

var headerHeight = 160;

var tabelHeight = 0;

var rullerHeight = 167.5;

var rullerLeftBeginNumber = 0;

var immutablerLeftBeginNumber = 0;

var rullerRightBeginNumber = 0;

var seperateHeight = 60.5;

var pageLoad = false;

var _columns = null;

var _pageCreationMember = null;


$.ajax({
    url: "/Report/Column",
    async: false,
    success: function (colList) {

        _pageCreationMember = JSON.parse(colList);

        _columns = _pageCreationMember.Columns;

        rullerLeftBeginNumber = immutablerLeftBeginNumber = _pageCreationMember.RullerLeftBeginNumber;

        for (var i = 1; i <= 3; i++) {

            var ctx = CreateCanvas(i);

            contexts.push(ctx);

            Init(ctx);


        }
    }
});


function Init(ctx) {

    var tabelWidth = ctx.canvas.width;

    ctx.beginPath();

    ctx.moveTo(0, headerHeight);

    ctx.lineTo(tabelWidth, headerHeight);

    ctx.stroke();

    GenerateColumn(ctx);

    FillColumn(ctx);

    DrawRightRuler(ctx);

    DrawLeftRuler(ctx);
}

function GenerateHeader(id) {

    var div = document.createElement('div');

    var marginTop = id > 0 ? 100 : 0;

    div.innerHTML = _pageCreationMember.HeaderTemplateHtml.replace('#MarginTop', marginTop);

    return div;
}

function GenerateFooter(id) {

    var div = document.createElement('div');

    div.innerHTML = ` <table class="footerTabel" height="300" width="1402">
                     <tr>
                         <td>Footer</td>
                     </tr>
                     </table>
                  `;

    return div;
}

function CreateCanvas(id) {

    var canvas = document.createElement('canvas');

    var hidefCanvasWidth = 1400;
    var hidefCanvasHeight = 1568;

    canvas.id = "canvas_" + id;
    canvas.width = hidefCanvasWidth;
    canvas.height = hidefCanvasHeight;
    canvas.style.zIndex = 8;
    canvas.style.border = "1px solid #000000";


    if (window.devicePixelRatio) {

        tabelHeight = hidefCanvasHeight;

        var hidefCanvasCssWidth = hidefCanvasWidth;
        var hidefCanvasCssHeight = hidefCanvasHeight;

        canvas.width = hidefCanvasWidth * window.devicePixelRatio;
        canvas.height = hidefCanvasHeight * window.devicePixelRatio;

        canvas.style.width = hidefCanvasCssWidth;
        canvas.style.height = hidefCanvasCssHeight;
    }


    var body = document.getElementsByTagName("body")[0];

    body.appendChild(GenerateHeader(id));
    body.appendChild(canvas);
    body.appendChild(GenerateFooter(id));

    var ctx = canvas.getContext("2d");

    if (window.devicePixelRatio) {
        ctx.scale(window.devicePixelRatio, window.devicePixelRatio);

    }
    if (window.devicePixelRatio === 2) {

        canvas.setAttribute('width', 400);
        canvas.setAttribute('height', 400);
        canvas.scale(2, 2);
    }

    SetContextDefaultStyle(ctx);

    return ctx;
}

function SetContextDefaultStyle(ctx) {

    ctx.beginPath();

    ctx.font = "16px Arial";

    ctx.setLineDash([]);

    ctx.lineWidth = 1;

    ctx.strokeStyle = '#000';

    ctx.fillStyle = '#000';
}

function SetContextLightGrayStyle(ctx) {

    ctx.beginPath();
    ctx.setLineDash([4, 4]);
    ctx.strokeStyle = '#000000';
    ctx.lineWidth = 0.7;
}



