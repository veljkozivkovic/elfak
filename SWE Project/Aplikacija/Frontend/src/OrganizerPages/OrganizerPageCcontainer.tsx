import { Flex } from "@mantine/core";
import { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { Footer } from "../HomePage/Footer/Footer";
import { HeaderMegaMenu } from "../HomePage/HeaderMegaMenu/HeaderMegaMenu";
import { RootState } from "../store/store";
import OrganizerPage from "./OrganizerPage/OrganizerPage";
import classes from "./OrganizerPage/OrganizerPage.module.css";
import NewEvent from "./NewEvent/NewEvent";
import View from "./EventViewPages";
import ManageEvent from "./ManageEvent/ManageEvent";
import EventReviews from "./EventReviews/EventReviews";
import { EventDto } from "./interfaces";

export default function OrganizerPageContainer() {
  const loggedUser = useSelector((state: RootState) => state.auth);
  const navigate = useNavigate();

  const [view, setView] = useState<View>(View.Basic);
  const [eventId, setEventId] = useState<number>(-1);
  const [eventName, setEventName] = useState<string>("");
  const [eventDate, setEventDate] = useState<string>("");
  const [eventDetails, setEventDetails] = useState<EventDto>();

  useEffect(() => {
    if (loggedUser.userType != "Host") navigate("/");
  }, []);

  return (
    <Flex className={classes.mainMain}>
      <HeaderMegaMenu />
      {view == View.Basic && (
        <OrganizerPage
          setEventId={setEventId}
          setEventName={setEventName}
          setEventDate={setEventDate}
          setEventDetails={setEventDetails}
          showEvent={setView}
          user={loggedUser}
        />
      )}
      {view == View.NewEvent && (
        <NewEvent showEvent={setView} user={loggedUser} />
      )}
      {view == View.ManageEvent && (
        <ManageEvent eventId={eventId} eventDetails={eventDetails} showEvent={setView} user={loggedUser} />
      )}
      {view == View.PastEventDetails && (
        <EventReviews eventId={eventId} eventName={eventName} eventDate={eventDate} showEvent={setView} />
      )}
      <Footer />
    </Flex>
  );
}
