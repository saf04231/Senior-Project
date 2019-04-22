var canvasDiv = document.getElementById('mapArea');
var canvas = document.createElement('canvas');
var clickX = new Array();

var clickY = new Array();
var clickDrag = new Array();
var paint;

canvas.setAttribute("height", 600);
canvas.setAttribute("width", 800);
canvas.setAttribute('style', "background-color:lightgray");
canvas.setAttribute('id', "canvas");
canvas.style.cursor = 'crosshair';
canvasDiv.appendChild(canvas);
if (typeof G_vmlCanvasManager != 'undefined') {
	canvas = G_vmlCanvasManager.initElement(canvas);
}
ctx = canvas.getContext("2d");

/* taken from http://www.williammalone.com/articles/create-html5-canvas-javascript-drawing-app/ */
$('#canvas').mousedown(function (e) {
    var mouseX = e.pageX - canvas.offsetParent.offsetLeft;
    var mouseY = e.pageY - canvas.offsetParent.offsetTop - 72; // figure out why i need to subtract 72 from the top...

    //console.log("e.pageX=%d canvas.offsetParent.offsetLeft=%d", e.pageX, canvas.offsetParent.offsetLeft)
    //console.log("e.pageY=%d canvas.offsetParent.offsetTop - 72=%d", e.pageY, canvas.offsetParent.offsetLeft)

	paint = true;
	addClick(mouseX, mouseY);
	redraw();
});

$('#canvas').mousemove(function (e) {
    if (paint) {
        addClick(e.pageX - canvas.offsetParent.offsetLeft, e.pageY - canvas.offsetParent.offsetTop - 72, true);
		redraw();
	}
});

$('#canvas').mouseup(function (e) {
	paint = false;
});

$('#canvas').mouseleave(function (e) {
	paint = false;
});

$('#eraseBtn').click(function () {
	clickX = new Array();
	clickY = new Array();
	clickDrag = new Array();
	ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
});

$('#chngMapBtn').change(function (e) {
    var reader = new FileReader();
    reader.onload = function (event) {
        var img = new Image();
        img.onload = function () {
            ctx.drawImage(img, 0, 0);
        }
        img.src = event.target.result;
    }
    reader.readAsDataURL(e.target.files[0]);
});

function addClick(x, y, dragging) {
	clickX.push(x);
	clickY.push(y);
	clickDrag.push(dragging);
}

function redraw() {
	ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);

	ctx.strokeStyle = "#000000";
	ctx.lineJoin = "round";
	ctx.lineWidth = 5;

	for (var i = 0; i < clickX.length; i++) {
		ctx.beginPath();
		if (clickDrag[i] && i) {
			ctx.moveTo(clickX[i - 1], clickY[i - 1]);
		} else {
			ctx.moveTo(clickX[i] - 1, clickY[i]);
		}
		ctx.lineTo(clickX[i], clickY[i]);
		ctx.closePath();
		ctx.stroke();
	}
}