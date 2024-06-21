import { useSelector } from "react-redux";
import { RootState } from "../../store/store";
import Reservation from "./Reservation";
import { HeaderMegaMenu } from "../../HomePage/HeaderMegaMenu/HeaderMegaMenu";
import { Footer } from "../../HomePage/Footer/Footer";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";

export default function ReservationContainer() {
  const selectedEvent = useSelector((state: RootState) => state.selectedEvent);
  const navigate = useNavigate();

  useEffect(() => {
    if (selectedEvent.id == 0) navigate("/");
  }, []);

  return (
    <>
      <HeaderMegaMenu />
      <Reservation
        id={selectedEvent.id}
        title={selectedEvent.title}
        location={selectedEvent.location}
        date={selectedEvent.date}
        img={selectedEvent.img}
        time={selectedEvent.time}
        organizerID={selectedEvent.organizerID}
        organizerName={selectedEvent.organizer}
      />
      <Footer />
    </>
  );
}
