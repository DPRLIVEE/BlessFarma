!function(t){var n={};function e(o){if(n[o])return n[o].exports;var i=n[o]={i:o,l:!1,exports:{}};return t[o].call(i.exports,i,i.exports,e),i.l=!0,i.exports}e.m=t,e.c=n,e.d=function(t,n,o){e.o(t,n)||Object.defineProperty(t,n,{enumerable:!0,get:o})},e.r=function(t){"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},e.t=function(t,n){if(1&n&&(t=e(t)),8&n)return t;if(4&n&&"object"==typeof t&&t&&t.__esModule)return t;var o=Object.create(null);if(e.r(o),Object.defineProperty(o,"default",{enumerable:!0,value:t}),2&n&&"string"!=typeof t)for(var i in t)e.d(o,i,function(n){return t[n]}.bind(null,i));return o},e.n=function(t){var n=t&&t.__esModule?function(){return t.default}:function(){return t};return e.d(n,"a",n),n},e.o=function(t,n){return Object.prototype.hasOwnProperty.call(t,n)},e.p="",e(e.s=11)}({11:function(t,n,e){"use strict";e.r(n);e(4);function o(t,n){for(var e=0;e<n.length;e++){var o=n[e];o.enumerable=o.enumerable||!1,o.configurable=!0,"value"in o&&(o.writable=!0),Object.defineProperty(t,o.key,o)}}var i=function(){function t(){var n=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{},e=n.animate,o=void 0===e||e,i=n.className,s=void 0===i?"":i;!function(t,n){if(!(t instanceof n))throw new TypeError("Cannot call a class as a function")}(this,t),this.animate=o,this.className=s,this.eventFired=!1,this._createRangeInput=this._createRangeInput.bind(this),this._onZoomEnd=this._onZoomEnd.bind(this),this._onChange=this._onChange.bind(this),this._bindEvents=this._bindEvents.bind(this),this._unbindEvents=this._unbindEvents.bind(this),this._createZoomControls=this._createZoomControls.bind(this)}var n,e,i;return n=t,(e=[{key:"onAdd",value:function(t){return this._map=t,this._container=document.createElement("div"),this._container.className="mapboxgl-ctrl tt-ctrl",this.minZoom=this._map.transform._minZoom,this.maxZoom=this._map.transform._maxZoom,this._container.appendChild(this._createZoomControls("tt-zoom-control ".concat(this.className))),this._bindEvents(),this._container}},{key:"onRemove",value:function(){this._unbindEvents(),this._container.parentNode.removeChild(this._container),this._map=void 0}},{key:"_bindEvents",value:function(){this._onZoomClickIn=this._onZoomClick.bind(this,"in"),this._onZoomClickOut=this._onZoomClick.bind(this,"out"),this._map.on("zoomend",this._onZoomEnd),this._rangeInput.addEventListener("change",this._onChange),this._zoomButtonIn.addEventListener("click",this._onZoomClickIn),this._zoomButtonOut.addEventListener("click",this._onZoomClickOut)}},{key:"_unbindEvents",value:function(){this._map.off("zoomend",this._onZoomEnd),this._rangeInput.removeEventListener("change",this._onChange),this._zoomButtonIn.removeEventListener("click",this._onZoomClickIn),this._zoomButtonOut.removeEventListener("click",this._onZoomClickOut)}},{key:"_onChange",value:function(){this.eventFired||(this.animate?this._map.zoomTo(this._rangeInput.value):this._map.setZoom(this._rangeInput.value))}},{key:"_onZoomClick",value:function(t){var n,e=this._map.getZoom();"in"===t?n=e+1:"out"===t&&(n=e-1),n<this.minZoom||n>this.maxZoom||(this.animate?this._map.zoomTo(n):this._map.setZoom(n))}},{key:"_onZoomEnd",value:function(){this.eventFired=!0,this._rangeInput.value=Math.floor(this._map.getZoom()),this.eventFired=!1}},{key:"_createZoomControls",value:function(t){var n=document.createElement("div");return n.className=t,this._rangeInput=this._createRangeInput(),this._zoomButtonIn=this._createZoomButton({type:"in"}),this._zoomButtonOut=this._createZoomButton({type:"out"}),n.appendChild(this._zoomButtonIn),n.appendChild(this._rangeInput),n.appendChild(this._zoomButtonOut),n}},{key:"_createRangeInput",value:function(){var t=document.createElement("input");return t.setAttribute("type","range"),t.setAttribute("min",this.minZoom),t.setAttribute("max",this.maxZoom),t.classList.add("tt-zoom-slider"),t.value=this._map.getZoom(),t}},{key:"_createZoomButton",value:function(t){var n=t.type,e=document.createElement("button"),o="tt-zoom-button--".concat(n);return e.classList.add("tt-zoom-button"),e.classList.add(o),e}}])&&o(n.prototype,e),i&&o(n,i),t}();window.tt=window.tt||{},window.tt.plugins=window.tt.plugins||{},window.tt.plugins.ZoomControls=i},4:function(t,n,e){t.exports=e.p+"src/ZoomControls/dist/ZoomControls.css"}});