import { LatLng } from "leaflet";
import { MapContainer, TileLayer, Marker, useMapEvents } from "react-leaflet";

export interface MapWithInputProps {
  position: LatLng;
  setPosition: React.Dispatch<React.SetStateAction<LatLng>>;
}

function MapWithInput({ position, setPosition }: MapWithInputProps) {
  const Markers = () => {
    useMapEvents({
      click(e) {
        setPosition(new LatLng(e.latlng.lat, e.latlng.lng));
      },
    });

    return (
      <Marker key={position.lat} position={position} interactive={false} />
    );
  };

  return (
    <MapContainer
      center={position}
      zoom={13}
      style={{ height: "300px", width: "100%" }}
    >
      <TileLayer
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
      />
      <Markers />
    </MapContainer>
  );
}

export default MapWithInput;
