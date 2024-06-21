import { Flex, Title } from "@mantine/core";
import EventBgImage from "../assets/event_listing_bg_op.png";
import EventCard from "./EventCard";
import classes from "./EventListing.module.css";
import axios from "../../axiosconfig.ts";
import { keepPreviousData, useQuery } from "@tanstack/react-query";
import { Event } from "./interfaces";
import { t } from "i18next";

export default function RecommendedEventListing() {
  const fetchEvents = async () => {
    return await axios
      .get(`${import.meta.env.VITE_DB_SERVER}/HomePage/GetRecommendedEvents`)
      .then((resp) => {
        return resp.data;
      })
      .catch((err) => console.error(err));
  };

  const {
    isLoading,
    data: events,
    isError,
    isRefetching,
  } = useQuery<Event[]>({
    queryKey: ["recommended"],
    queryFn: fetchEvents,
    placeholderData: keepPreviousData,
  });

  return (
    <Flex
      direction="column"
      align="center"
      styles={{
        root: {
          backgroundImage: `url(${EventBgImage})`,
        },
      }}
      pt={40}
      className="main-ev-listing-div"
    >
      <Title
        style={{
          fontFamily: "Greycliff CF, var(--mantine-font-family)",
          fontSize: "3rem",
          color: "white",
          textShadow: `-1px -1px 0 #868e96, 1px -1px 0 #868e96, -1px 1px 0 #868e96, 1px 1px 0 #868e96`,
          textAlign: "center",
        }}
        mb={60}
      >
        {t("Recommendation")}
      </Title>

      <Flex
        h="fit-content"
        w="100%"
        p={30}
        pl={40}
        pr={40}
        align="flex-start"
        justify="center"
        gap="30px"
        wrap="wrap"
      >
        {isLoading || isError || isRefetching ? (
          <div className={classes.controls}>
            <div className={classes.ldsRing}>
              <div></div>
              <div></div>
              <div></div>
              <div></div>
            </div>
          </div>
        ) : (
          events?.map((ev: Event, idx: number) => (
            <EventCard key={idx} event={ev} />
          ))
        )}
      </Flex>
    </Flex>
  );
}
