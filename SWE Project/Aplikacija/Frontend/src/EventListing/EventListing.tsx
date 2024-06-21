import {
  Autocomplete,
  Button,
  Flex,
  Group,
  MultiSelect,
  TextInput,
  Title,
} from "@mantine/core";
import { useState } from "react";
import { IconSelect } from "@tabler/icons-react";
import { DateInput } from "@mantine/dates";
import EventBgImage from "../assets/event_listing_bg_op.png";
import EventCard from "./EventCard";
import classes from "./EventListing.module.css";
import axios from "../../axiosconfig.ts";
import { keepPreviousData, useQuery } from "@tanstack/react-query";
import { Event } from "./interfaces";
import { formatOnlyDate } from "../AdminPages/AdminPage/AdminPage";
import { useTranslation } from "react-i18next";

export default function EventListing() {
  const [selectedCity, setSelectedCity] = useState("");
  const [selectedTags, setSelectedTags] = useState<string[]>([]);
  const [dateTime, setDateTime] = useState<Date | null>(null);
  const [searchTerm, setSearchTerm] = useState<string>("");
  const [page, setPage] = useState<number>(0);
  const { t } = useTranslation();

  const {
    isLoading: areLocationsLoading,
    data: locations,
    isError: locationsError,
  } = useQuery<string[]>({
    queryKey: ["locations"],
    queryFn: async () => {
      return await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/HomePage/getLocations`)
        .then((resp) => resp.data)
        .catch((err) => console.error(err));
    },
  });

  const {
    isLoading: areTagsLoading,
    data: tags,
    isError: tagsError,
  } = useQuery<string[]>({
    queryKey: ["tags"],
    queryFn: async () => {
      return await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/HomePage/getTags`)
        .then((resp) => resp.data)
        .catch((err) => console.error(err));
    },
  });

  const fetchEvents = async (page = 0) => {
    if (!selectedCity && !searchTerm && !selectedTags.length && !dateTime) {
      return await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/HomePage/getAllEvents/${page}`)
        .then((resp) => resp.data)
        .catch((err) => console.error(err));
    } else {
      const params = new URLSearchParams();
      if (selectedCity) params.append("location", selectedCity);
      if (searchTerm) params.append("search", searchTerm);
      if (selectedTags && selectedTags.length > 0)
        selectedTags.forEach((tag) => params.append("tags", tag));
      if (dateTime) params.append("date", formatOnlyDate(dateTime));
      return await axios
        .get(
          `${
            import.meta.env.VITE_DB_SERVER
          }/HomePage/getFilteredEvents/${page}`,
          {
            params,
          }
        )
        .then((resp) => resp.data)
        .catch((err) => {
          console.error(err);
          return [];
        });
    }
  };

  const {
    isLoading,
    data: events,
    isError,
    isRefetching,
    refetch,
    isPlaceholderData,
  } = useQuery<Event[]>({
    queryKey: ["events", page],
    queryFn: () => fetchEvents(page),
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
        {t("Welcome1")}
      </Title>
      <Group align="flex-end" justify="center" mb={50}>
        <TextInput
          label={t("SearchByName")}
          placeholder={t("SearchByNameP")}
          maw={229}
          styles={{
            label: {
              fontFamily: "Greycliff CF, var(--mantine-font-family)",
              fontSize: "1.01rem",
            },
          }}
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />

        <Autocomplete
          data={areLocationsLoading || locationsError ? [] : locations}
          value={selectedCity}
          onChange={setSelectedCity}
          placeholder={t("SelectLocationP")}
          label={t("SelectLocation")}
          styles={{
            label: {
              fontFamily: "Greycliff CF, var(--mantine-font-family)",
              fontSize: "1.01rem",
            },
          }}
          rightSection={<IconSelect />}
          rightSectionPointerEvents="none"
          maw={229}
        />

        <DateInput
          value={dateTime}
          onChange={setDateTime}
          label={t("SelectDate")}
          placeholder={t("SelectDateP")}
          maw={229}
          styles={{
            label: {
              fontFamily: "Greycliff CF, var(--mantine-font-family)",
              fontSize: "1.01rem",
            },
          }}
          rightSection={<IconSelect />}
          rightSectionPointerEvents="none"
          clearable
        />

        <MultiSelect
          label={t("SelectTags")}
          data={areTagsLoading || tagsError ? [] : tags}
          placeholder={t("SelectTagsP")}
          value={selectedTags}
          onChange={setSelectedTags}
          checkIconPosition="left"
          withScrollArea={false}
          maw={229}
          rightSection={<IconSelect />}
          styles={{
            label: {
              fontFamily: "Greycliff CF, var(--mantine-font-family)",
              fontSize: "1.01rem",
            },
          }}
        />
        <Button
          style={{
            fontFamily: "Greycliff CF, var(--mantine-font-family)",
            fontSize: "1.01rem",
          }}
          variant="outline"
          color="gray"
          size="md"
          onClick={async () => {
            await refetch();
          }}
        >
          {t("Search")}
        </Button>
      </Group>
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
      <Group mb={20}>
        <Button
          onClick={() => setPage((old) => Math.max(old - 1, 0))}
          disabled={page === 0}
        >
          {"<"}
        </Button>
        <Button disabled>{page + 1}</Button>
        <Button
          onClick={() => {
            if (!isPlaceholderData && events?.length === 10) {
              setPage((old) => old + 1);
            }
          }}
          disabled={isPlaceholderData || !(events?.length === 10)}
        >
          {">"}
        </Button>
      </Group>
    </Flex>
  );
}
