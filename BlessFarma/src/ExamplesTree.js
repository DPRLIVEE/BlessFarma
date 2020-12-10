import React from 'react';

// To set an example as advanced use the property `advanced: true`.
const examplesTree = {
    'Basic map initialization': {
        'Vector map': {
            page: 'vector-map.html',
            description: <p>Most basic usage of vector maps</p>
        },
        'Raster map': {
            page: 'raster-map.html',
            description: <p>
                The most basic and minimalistic example of the TomTom map usage. There are multiple possible ways
                of initializing the <a href="https://developer.tomtom.com/maps-sdk-web-js/documentation#Maps.Map"
                    target="_blank" rel="noopener noreferrer">map</a>.
                However, the only required parameter is the id of the DOM object where map is going to be displayed.
                It is important that the map object has a proper size.
            </p>
        },
        'Multiple maps': {
            page: 'multiple-maps.html',
            description: <p>
                Developers are not limited to attaching only a single map. You can put as many map objects as you want
                on the same page without any issues.
            </p>
        },
        'Copyrights and attribution': {
            page: 'copyrights.html',
            description: <p>
                There is a legal requirement to properly credit TomTom content display to the end users. When using
                the SDK proper clickable link is added to the map. This example shows how to customize the location
                of attribution control and its content by adding links to report map issue and information about privacy.
            </p>
        },
        'Static map image': {
            page: 'static-map-image.html',
            description: <p>
                This example shows usage of static map image service to show how to obtain an url to a desired part of the world map.
            </p>
        },
        'Geopolitical views': {

            page: 'geopolitical-views.html',
            description: <p>
                This example shows how to use Geopolitical views in the map. We also provide you with two maps
                side by side so that you can compare the different views available.
            </p>
        },
        'Base styles': {
            page: 'base-styles.html',
            description: <p>This example shows how to change the base layer, the style of the map and layers shown on the map.</p>
        }
    },
    'Map layers': {
        'GeoJSON polygon with solid fill': {
            page: 'geojson-overlay-solid-fill.html',
            description: <p>This example shows how to add a polygon overlay to the map. We are applying a solid fill with an outline.</p>
        },
        'GeoJSON polygon with pattern fill': {
            page: 'geojson-overlay-pattern-fill.html',
            description: <p>This example shows how to add a polygon overlay to the map. We are applying a pattern fill to the polygon.</p>
        },
        'WMS base layer': {
            page: 'wms-base-layer.html',
            description: <p>
                This example show the usage of <a href="https://developer.tomtom.com/maps-api/maps-api-documentation-raster/wms"
                    target="_blank" rel="noopener noreferrer"> WMS Service </a> as a provider for the base layer.
            </p>
        },
        'Layer with WMS source': {
            page: 'layer-wms-source.html',
            description: <p>
                This example shows how to add a layer with WMS source positioned before the first layer of the hybrid night style.
                <br />
                To read more about WMS please visit the <a href="https://developer.tomtom.com/maps-api/maps-api-documentation-raster/wms"
                    target="_blank" rel="noopener noreferrer">WMS Service documentation</a> page.
            </p>
        },
        'Setting custom map style': {
            page: 'setting-custom-map-style.html',
            description: <div>
                <p>
                    This example shows how to change map style "on the fly" using setStyle method.
                    You can call it with style schema, URL pointing to style, or style object.
                    Here we use style object provided by uploading file.
                    You can create your own custom style file using the <a href="https://developer.tomtom.com/maps-api/map-styler">Map styler</a>.
                </p>
            </div>
        },
        'Changing layers visibility': {
            page: 'changing-layers-visibility.html',
            description: <div>
                <p>
                    This example shows how to change layer visibility on the map.
                    First, we get all map layers and then we add mechanism for toggling their visibility.
                </p>
            </div>
        },
        'Heatmap': {
            page: 'heatmap.html',
            description: <div>
                <p>This example shows how to add a heatmap layer on the map.</p>
                <br/>
                <p>
                    To build this example we created three clusters of points with different densities.
                    The areas with more points are shown as red in higher zoom levels.
                    <br/>
                    These points are then converted to a GeoJson object that is used to create the heatmap layer.
                </p>
            </div>
        },
        'Building extrusions': {
            page: 'building-extrusions.html',
            description: <div>On lower zoom levels, we are displaying 3D building. In this example, we are showing you
                how to hide them if you don't want them to be visible.
            </div>
        }
    },
    'Map interaction': {
        'Changing map center': {
            page: 'changing-map-center.html',
            description: <p>
                A center point's latitude and longitude coordinates together with a zoom level can be passed to a method
                initializing a map object. You can construct the map only after a #map div is rendered - for example,
                by using the window.onload event or placing script just before body closing tag.
            </p>
        },
        'Automated location change': {
            page: 'automated-location-change.html',
            description: <p>
                Multiple map locations can be used in a form of an animated carousel. The only information that you need
                to provide is set of center points coordinates and a desired time interval between location switches.
                <br/>
                You have three options of location changing by deciding to use: <code>map.flyTo()</code>,
                <code>map.easeTo()</code> or <code>map.jumpTo()</code>. Play with them to choose the one that
                works best for you.
            </p>
        },
        'Resize map': {
            page: 'resize-map.html',
            description: <p>
                You can resize map size by changing map container size. Then you need to call <code>map.resize()</code>
                to inform library that viewport changed.
            </p>
        },
        'Map events': {
            page: 'map-events.html',
            description: <p>
                The map object can be combined with every JavaScript DOM event.
                For example, by using the click() event, application may get the clicked location's
                coordinates and show them in a popup.
            </p>
        },
        'Limit map interactions': {
            page: 'limit-map-interactions.html',
            description: <p>
                Visible map area can be limited to certain bounding box and a range of zoom levels. It is possible
                by setting the following properties: maxBounds, maxZoom and minZoom.
                Just test it by panning and zooming the map.
            </p>
        },
        'Block map interactions': {
            page: 'block-map-interactions.html',
            description: <p>
                There might be a need to disable particular map browsing capabilities for a given map instance.
                You can achieve this by using invidual options like <code>scrollZoom</code>, <code>dragPan</code>,
                as shown below or by setting <code>interactive</code> option to <code>false</code> to disable all
                map interactions.
            </p>
        },
        'Pan and zoom controls': {
            page: 'pan-and-zoom.html',
            description: <p>
                This example shows how custom pan and zoom controls can be added to the map.
                Please note that even though we include plugins from a remote location
                (see <code>script</code> and <code>style</code> tags in the <code>head</code>),
                you should not rely on the availability of these links, it is preferable to host them on your own server.
            </p>
        },
        'Pitch and bearing controls': {
            page: 'pitch-and-bearing.html',
            description: <p>
                Pitch and bearing controls to make map tilts and rotations a little bit easier.
            </p>
        },
        'Minimap': {
            page: 'minimap.html',
            description: <p>
                We can easily add a smaller map in any corner of the main map. It shows the main map in the context of
                lower zoom level.
            </p>
        },
        'Distance measurement': {
            page: 'distance-measurement.html',
            description: <p>
                In this example we show you how to create a distance measurement tool with Maps SDK for Web and Turf.js.
            </p>
        }
    },
    'Markers': {
        'Draggable markers': {
            page: 'draggable-markers.html',
            description: <p>This example shows how to create a draggable marker.</p>
        },
        'Custom markers': {
            page: 'custom-markers.html',
            description: <p>The marker mechanism allows straight forward look and feel customizations.
                You can also embed multiple types of images, e.g. jpg, png, svg.</p>
        },
        'Markers clustering': {
            page: 'markers-clustering.html',
            description: <p>This example shows how to use and customize clustering layers using a predefined
                set of points.</p>
        }
    },
    'Traffic': {
        'Vector traffic incidents': {
            page: 'vector-traffic-incidents.html',
            description: <div>
                <p>
                    This example shows how to display vector traffic incident tiles and incident details on the map.
                    Traffic Incident tiles can be displayed in three different variants:
                </p>
                <ul>
                    <li>s1</li>
                    <li>s2</li>
                    <li>s3</li>
                </ul>
                <p>For more information please refer to the <a target='_blank' rel='noopener noreferrer' href='https://developer.tomtom.com/traffic-api/traffic-api-documentation/traffic-incidents'>
                    Traffic Incidents documentation</a>.
                </p>
            </div>
        },
        'Raster traffic incidents': {
            page: 'raster-traffic-incidents.html',
            description: <div>
                <p>
                    This example shows how to display raster traffic incident tiles and incident details on the map.
                    Traffic Incident tiles can be displayed in three different variants:
                </p>
                <ul>
                    <li>s1</li>
                    <li>s2</li>
                    <li>s3</li>
                </ul>
                <p>For more information please refer to the <a target='_blank' rel='noopener noreferrer' href='https://developer.tomtom.com/traffic-api/traffic-api-documentation/traffic-incidents'>
                    Traffic Incidents documentation</a>.
                </p>
            </div>
        },
        'Traffic incidents heatmap': {
            page: 'traffic-incidents-heatmap.html',
            description: <div>
                <p>This example shows how to add a heatmap layer to the map using traffic incidents.</p>
                <br />
                <p>
                    To build this example we start by rendering the map and fetch traffic incidents for the current viewport (bounding box).
                    Once we receive the response from the service we extract all the points and build a GeoJson - please note that
                    the response contains clusters with traffic incident points which also need to be extracted.
                    We then use the GeoJson to generate a heatmap layer and add it to the map.
                </p>
            </div>
        },
        'Vector traffic flow': {
            page: 'vector-traffic-flow.html',
            description: <div>
                <p>This example shows vector traffic flow data from TomTom Traffic service.
                Traffic flow can be displayed in three different variants:</p>
                <ul>
                    <li>absolute (default) - the colours reflect the absolute speed measured on the given road segment</li>
                    <li>relative - the speed relative to free-flow is taken into account, highlighting areas of congestion</li>
                    <li>relative-delay - displays relative speeds only where they are different from the freeflow speed (no
                green segments)</li>
                </ul>
            </div>
        },
        'Raster traffic flow': {
            page: 'raster-traffic-flow.html',
            description: <div>
                <p>This example shows rasterized data from TomTom Traffic service.
                Traffic flow can be displayed in three different variants:</p>
                <ul>
                    <li>absolute (default) - the colours reflect the absolute speed measured on the given road segment</li>
                    <li>relative - the speed relative to free-flow is taken into account, highlighting areas of congestion</li>
                    <li>relative-delay - displays relative speeds only where they are different from the freeflow speed (no
                green segments)</li>
                </ul>
            </div>
        }
    },
    'Routing': {
        'Static route': {
            page: 'static-route.html',
            description: <div>
                <p>This example shows how to display static route based on the geoJSON data retrieved
                from the <a href='https://developer.tomtom.com/routing-api/routing-api-documentation-routing/calculate-route'>
                Calculate Route</a> service.</p>

                <p>No traffic information is used to calculate routes.</p>
            </div>
        }
    },
    'Search and geocoding': {
        'My location': {
            page: 'my-location.html',
            description: <p>
                By usage of HTML5 Geolocation API user location can be shown on the map.
                In this example Mapbox
                <a href="https://developer.tomtom.com/maps-sdk-web-js/documentation#Maps.GeolocateControl" target="_blank" rel="noopener noreferrer">
                GeolocateControl</a> is used to retrieve location and display UI button.
                Note that, geolocalization may be not available in user's device or permission can be denied
                and you need to handle those cases manually and display appropriate information to users.
            </p>
        },
        'Search': {
            page: 'search.html',
            description: <p>
                A simple application that shows how to use different Tomtom Search Services: such like:
                fuzzy search, point of interest search, category search, geometry search and nearby search.
                <br/><br/>
                Choose one of given search types from the list, type in the query that you want to search for
                (e.g. pizza, Amsterdam or New York) and press Submit button.
            </p>
        },
        'Search with autocomplete': {
            page: 'search-with-autocomplete.html',
            description: <p>This is a simple example, which shows how to use the SearchBox plugin with our SDK.
            If you need to customize it (eg. optimize the number of calls made to the API), you can find additional options in the
            <a href="https://developer.tomtom.com/maps-sdk-web-js/documentation#ttPlugins.SearchBox">
            SearchBox plugin documentation</a></p>
        },
        'Polygons for search': {
            page: 'polygons-for-search.html',
            description: <p>
                This example shows how to use Additional Data service to retrieve polygons representing borders of a
                particular search result. Polygons are shown when geometry data is available.

                For more information please refer to the <a href='https://developer.tomtom.com/search-api/search-api-documentation/additional-data'>
                    Additional Data</a> service documentation.
            </p>
        }
    },
    'Reverse geocode': {
        'Entity type filtering': {
            page: 'entity-type-filtering.html',
            description: <p>
                Reverse geocoder parameter <code>entityType</code> allows to filter response by entity type.
                You can observe different output after selecting one or multiple entity types from the dropdown
                and clicking on the map.
            </p>
        },
        'Polygons for reverse geocoder results': {
            page: 'polygons-for-rev-geo-results.html',
            description: <p>
                Reverse geocoder parameter <code>entityType</code> allows to filter response by entity type.
                Additional data parameter <code>geometryZoom</code> allows you to adjust accurateness of the polygon.
                You can observe different output after selecting one or multiple entity types from the dropdown
                and clicking on the map.
            </p>
        }
    },
};

export function findExample(wantedExamplePageUrl) {
    for (const categoryName in examplesTree) {
        if (examplesTree.hasOwnProperty(categoryName)) {
            for (const exampleName in examplesTree[categoryName]) {
                if (examplesTree[categoryName].hasOwnProperty(exampleName) &&
                    wantedExamplePageUrl === examplesTree[categoryName][exampleName].page) {
                    const example = examplesTree[categoryName][exampleName];
                    return {
                        name: exampleName,
                        page: example.page,
                        description: example.description,
                        category: categoryName,
                        advanced: example.advanced || false
                    };
                }
            }
        }
    }
    throw new Error(`Unknown example page url: ${wantedExamplePageUrl}`);
}

export function filterExamplesTree(wantedExamplesName) {
    const result = {};
    for (const mainCategory in examplesTree) {
        if (examplesTree.hasOwnProperty(mainCategory)) {
            for (const exampleName in examplesTree[mainCategory]) {
                if (examplesTree[mainCategory].hasOwnProperty(exampleName)) {
                    if (exampleName.toLowerCase().indexOf(wantedExamplesName) !== -1) {
                        result[exampleName] = examplesTree[mainCategory][exampleName];
                    }
                }
            }
        }
    }

    return result;
}

export default examplesTree;
