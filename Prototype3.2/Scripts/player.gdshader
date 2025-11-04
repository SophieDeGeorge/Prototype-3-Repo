shader_type canvas_item;

/* Player position in screen UV (0..1) */
uniform vec2 light_uv;

/* Set sizes in **pixels**; we’ll convert to UV inside the shader */
uniform float radius_px  = 220.0;
uniform float feather_px = 140.0;

/* Outer darkness strength (0..1) */
uniform float darkness = 1.0;

/* Passed from script each frame (viewport width,height in pixels) */
uniform vec2 viewport_size = vec2(1920.0, 1080.0);

void fragment() {
    // Work in UV space (0..1)
    vec2 p = SCREEN_UV;

    // Convert pixel radii to UV so the circle stays round on any resolution
    float px_ref = min(viewport_size.x, viewport_size.y);
    float r = radius_px  / px_ref;
    float f = feather_px / px_ref;

    float d = distance(p, light_uv);                 // 0..~1
    float t = smoothstep(r, r + f, d);               // 0 at center -> 1 at edges
    COLOR = vec4(0.0, 0.0, 0.0, t * darkness);       // dark fade outward
}
