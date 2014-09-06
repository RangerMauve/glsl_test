Glsl = require("./glsl.js");
var fs = require("fs");

if (!Glsl.supported()) alert("WebGL is not supported.");

var canvas = document.getElementById("game");
var mouse = require("mouse-position")(canvas);
var width = window.innerWidth;
var height = window.innerHeight;

function Vec2(x, y) {
	this.x = x;
	this.y = y;
}

Glsl({
	canvas: canvas,
	fragment: fs.readFileSync(__dirname+"/shader.fs"),
	variables: {
		time: 0,
		center: new Vec2(0.5, 0.5)
	},
	update: function(time, delta) {
		this.set("time", time);
		this.set("center",new Vec2(mouse.x/width,(height-mouse.y)/height));
	}
}).start();
