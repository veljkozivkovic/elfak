import { MapContainer, TileLayer, Marker } from "react-leaflet";
import { LatLng } from "leaflet";

export interface MapComponentProps {
  lat: number;
  lng: number;
}

function MapComponent(props: MapComponentProps) {
  const position = new LatLng(props.lat, props.lng);

  return (
    <MapContainer
      center={position}
      zoom={13}
      scrollWheelZoom={false}
      style={{ width: "100%", height: "auto", flex: 1 }}
    >
      <TileLayer
        attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
      />
      <Marker position={position}></Marker>
    </MapContainer>
  );
}

export default MapComponent;
