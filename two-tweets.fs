uniform vec3      iResolution;           // viewport resolution (in pixels)
uniform float     iGlobalTime;           // shader playback time (in seconds)
uniform float     iChannelTime0;       // channel playback time (in seconds)
uniform float     iChannelTime1;       // channel playback time (in seconds)
uniform float     iChannelTime2;       // channel playback time (in seconds)
uniform float     iChannelTime3;       // channel playback time (in seconds)
uniform vec3      iChannelResolution0; // channel resolution (in pixels)
uniform vec3      iChannelResolution1; // channel resolution (in pixels)
uniform vec3      iChannelResolution2; // channel resolution (in pixels)
uniform vec3      iChannelResolution3; // channel resolution (in pixels)
uniform vec4      iMouse;                // mouse pixel coords. xy: current (if MLB down), zw: click
uniform sampler2D iChannel0;          // input channel. XX = 2D/Cube
uniform sampler2D iChannel1;          // input channel. XX = 2D/Cube
uniform sampler2D iChannel2;          // input channel. XX = 2D/Cube
uniform sampler2D iChannel3;          // input channel. XX = 2D/Cube
uniform vec4      iDate;                 // (year, month, day, time in seconds)
uniform float     iViewpoint;


// Created by inigo quilez - iq/2013
// License Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License.

float f(vec3 p)
{
	p.z+=iGlobalTime;return length(.05*cos(9.*p.y*p.x)+cos(p)-.1*cos(9.*(p.z+.3*p.x-p.y)))-1.;
}
void mainImage( out vec4 c, in vec2 p )
{
    vec3 d=.5-vec3(p,1.)/iResolution.x,o=d+vec3(0.1*iViewpoint,0,0);for(int i=0;i<99;i++)o+=f(o)*d;
    c=vec4(abs(f(o-d)*vec3(.0,.1,.2)+f(o-.6)*vec3(.2,.12,.01))*(10.-o.z),1.);
}


void main(void)
{
    vec4 color = vec4(0.0,0.0,0.0,1.0);

    mainImage( color, gl_FragCoord.xy );
    color.w = 1.0;
    gl_FragColor = color;
}
