precision mediump float;
uniform vec2 resolution;
uniform float time;
uniform vec2 center;

const float radius = 0.2;

bool inCircle(vec2 p, vec2 center, float radius) {
	vec2 ratio = resolution.xy / resolution.x;
	return distance(p * ratio, center * ratio) < radius;
}

void main() {
	vec2 p = gl_FragCoord.xy / resolution.xy;
	float z = 0.5 + 0.5 * smoothstep(-1.0, 1.0, cos(time * 0.005));
	gl_FragColor = vec4(0.0, 0.0, 0.0, 1.0 - distance(p,center));

	if (inCircle(p, center, radius)) {
		gl_FragColor = vec4(p.x, p.y, z, 1.0);
	}
}
