import React from 'react';

import BasicMap from '../../assets/icons/ic_basic_map_initialization.svg';
import MapLayers from '../../assets/icons/ic_map_layers.svg';
import MapInteraction from '../../assets/icons/ic_map_interaction.svg';
import SearchAndGeocode from '../../assets/icons/ic_search_and_geocoding.svg';
import AdvancedExamples from '../../assets/icons/ic_advanced.svg';
import SearchIcon from '../../assets/icons/ic_search_for.svg';
import ReverseGeocode from '../../assets/icons/ic_reversed_geocode.svg';
import Traffic from '../../assets/icons/ic_traffic.svg';
import Routing from '../../assets/icons/ic_routing.svg';
import Markers from '../../assets/icons/ic_markers.svg';

const mapping = {
    'Basic map initialization': BasicMap,
    'Map layers': MapLayers,
    'Map interaction': MapInteraction,
    'Search and geocoding': SearchAndGeocode,
    'Advanced examples': AdvancedExamples,
    'Search results': SearchIcon,
    'Reverse geocode': ReverseGeocode,
    'Traffic': Traffic,
    'Routing': Routing,
    'Markers': Markers
};

export default function CategoryIcon({ name }) {
    const Icon = mapping[name];

    return <Icon />;
}
