import {
  Button,
  Fieldset,
  Flex,
  Group,
  InputLabel,
  Title,
  Stack,
  TextInput,
  Textarea,
  Select,
  NumberInput,
  FileInput,
  TagsInput,
  Table,
  Checkbox,
} from "@mantine/core";
import classes from "./NewEvent.module.css";
import EventBgImage from "../../assets/event_listing_bg_op.png";
import { AuthState } from "../../store/features/auth";
import View from "../EventViewPages";
import { DateInput } from "@mantine/dates";
import { useRef, useState } from "react";
import { useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "../../../axiosconfig.ts";
import Drawer from "../../Reservations/HostVersionOfDrawer/Drawer";
import { NewEventDto, SpaceBasic } from "../interfaces.ts";
import { useForm } from "@mantine/form";
import { formatOnlyDate } from "../../AdminPages/AdminPage/AdminPage.tsx";
import { SpaceDataType } from "../../Reservations/Reservation/interfaces.ts";
import { useTranslation } from "react-i18next";

export interface NewEventProps {
  user: AuthState;
  showEvent: React.Dispatch<React.SetStateAction<View>>;
}

export default function NewEvent(props: NewEventProps) {
  const { t } = useTranslation();
  const [tags, setTags] = useState<string[]>([]);
  const [selectedSpaceId, setSelectedSpaceId] = useState<number | string>(-1);
  const [selectedCity, setSelectedCity] = useState<string>("");
  const [capacity, setCapacity] = useState<number>(-1);
  const [alertCount, setAlertCount] = useState<number>(0);
  const [selectedSpacePlan, setSelectedSpacePlan] = useState<
    SpaceDataType | undefined
  >();
  const queryClient = useQueryClient();

  const getObjectFromDrawerRef = useRef<Function | null>(null);

  const {
    isLoading: areSpacesLoading,
    data: spaces,
    isError: spacesError,
  } = useQuery<SpaceBasic[]>({
    queryKey: ["new_event_spaces"],
    queryFn: async () => {
      const values = createEventForm.getValues();
      if (
        !(
          values.date &&
          values.time &&
          /^(?:[01]\d|2[0-3]):[0-5]\d$/.test(values.time)
        )
      ) {
        alertCount > 0
          ? alert(t("InvalidDateOrTimeFormat"))
          : setAlertCount(alertCount + 1);
        return [];
      }

      const date = values.date.toISOString().split("T")[0];
      let queryString = `${
        import.meta.env.VITE_DB_SERVER
      }/Host/getAvailableSpaces/${date}/${values.time}`;
      selectedCity
        ? (queryString += `/${selectedCity}`)
        : (queryString += "/null");
      capacity > 0 ? (queryString += `/${capacity}`) : (queryString += "/-1");

      return await axios
        .get(queryString)
        .then((resp) => resp.data)
        .catch((err) => {
          console.error(err);
          alert(err.resp.data);
          return [];
        });
    },
  });

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

  const getSpacePlan = async (spaceId: number) => {
    try {
      await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/Host/getSpacePlan/${spaceId}`)
        .then((resp) => {
          setSelectedSpacePlan(resp.data);
        })
        .catch((err) => {
          console.error(err);
          alert(err.resp.data);
        });
      setSelectedSpaceId(spaceId);
    } catch (err: any) {
      console.error(err);
      alert(err.response.data);
    }
  };

  const createEventForm = useForm({
    mode: "controlled",
    initialValues: {
      eventName: "",
      description: "",
      date: new Date(Date.now()),
      time: "",
      image: null,
      video: "",
    },

    validate: {
      eventName: (value) =>
        value.length > 0 ? null : t("EmptyEventNameField"),
      description: (value) =>
        value.length > 0 ? null : t("EmptyDescriptionField"),
      time: (value) =>
        /^(?:[01]\d|2[0-3]):[0-5]\d$/.test(value) ? null : t("WrongTimeFormat"),
    },
  });

  return (
    <Flex
      direction="column"
      h={selectedSpaceId != "-1" ? "fit-content" : "100vh"}
    >
      <Flex
        className={classes.mainContentFlex}
        styles={{
          root: {
            backgroundImage: `url(${EventBgImage})`,
            backgroundRepeat: "repeat",
          },
        }}
      >
        <Group style={{ width: "100%" }}>
          <Button
            onClick={(event) => {
              event.stopPropagation();
              props.showEvent(View.Basic);
            }}
          >
            Go back
          </Button>
          <Title c="#5a5959">{t("ScheduleNewEvent")}</Title>
        </Group>

        <Flex
          w="100%"
          h="100%"
          mt="20"
          align="center"
          justify="center"
          className={classes.subTitleContainer}
        >
          <form
            style={{
              width: "50%",
              height: "fit-content",
              marginBottom: "10px",
            }}
            onSubmit={createEventForm.onSubmit((_, event) => {
              event?.stopPropagation();
            })}
          >
            <Fieldset
              legend={t("BasicInformation")}
              w="100%"
              h="fit-content"
              fz="xl"
              styles={{
                root: {
                  display: "flex",
                  justifyContent: "space-between",
                  gap: "10px",
                },
              }}
              mb={10}
            >
              <Stack w="50%">
                <TextInput
                  required
                  label={t("EventName")}
                  placeholder={t("EventName...")}
                  key={createEventForm.key("eventName")}
                  {...createEventForm.getInputProps("eventName")}
                ></TextInput>
                <Textarea
                  required
                  placeholder={t("WriteSomethingAbouTthEevent...")}
                  label={t("Description")}
                  autosize
                  minRows={5}
                  key={createEventForm.key("description")}
                  {...createEventForm.getInputProps("description")}
                />
                <TagsInput
                  miw="100%"
                  label={t("PressEnterToSubmitATag")}
                  placeholder={t("EnterTag")}
                  value={tags}
                  onChange={setTags}
                  styles={{
                    input: {
                      overflowY: "scroll",
                      height: "7rem",
                    },
                  }}
                />
              </Stack>
              <Stack w="50%">
                <DateInput
                  required
                  placeholder={formatOnlyDate(new Date(Date.now()))}
                  label={t("Date")}
                  key={createEventForm.key("date")}
                  {...createEventForm.getInputProps("date")}
                />
                <TextInput
                  required
                  placeholder="HH:mm"
                  label={t("Time")}
                  key={createEventForm.key("time")}
                  {...createEventForm.getInputProps("time")}
                />
                <FileInput
                  required
                  placeholder={t("ImageToBeDisplayed")}
                  label={t("PromoImage")}
                  key={createEventForm.key("image")}
                  {...createEventForm.getInputProps("image")}
                />
                <TextInput
                  placeholder={t("YouTubeEmbedLink")}
                  label={t("PromoVideo")}
                  key={createEventForm.key("video")}
                  {...createEventForm.getInputProps("video")}
                />
                <div
                  style={{
                    width: "100%",
                    display: "flex",
                    flexDirection: "column",
                    lineHeight: "var(--mantine-line-height)",
                    marginTop: "8px",
                  }}
                >
                  <InputLabel className="mantine-TextInput-label">
                    Schedule
                  </InputLabel>
                  <Button
                    type="submit"
                    onClick={async (event) => {
                      event.stopPropagation();
                      const values = createEventForm.getValues();

                      if (createEventForm.validate().hasErrors) {
                        return;
                      }

                      const newSpacePlan =
                        getObjectFromDrawerRef?.current &&
                        typeof getObjectFromDrawerRef.current === "function"
                          ? getObjectFromDrawerRef.current()
                          : null;

                      if (tags.length === 0) {
                        alert(t("PleaseEnterAtLeastOneTag"));
                        return;
                      }

                      if (values.image === null) {
                        alert(t("PleaseUploadAnImage"));
                        return;
                      }

                      if (selectedSpaceId === -1 || newSpacePlan === null) {
                        alert(t("PleaseSelectASpace"));
                        return;
                      }

                      if (values.description.length > 500) {
                        alert(t("DescriptionTooLong"));
                        return;
                      }

                      const eventObj: NewEventDto = {
                        eventName: values.eventName,
                        description: values.description,
                        tags: tags,
                        date: values.date.toISOString().split("T")[0],
                        time: values.time,
                        video: values.video,
                        spaceId: selectedSpaceId as number,
                        items: newSpacePlan.items,
                        lines: newSpacePlan.lines,
                        surfaceDimension: newSpacePlan.surfaceDimension,
                      };

                      let eventId = -1;

                      const imageData = new FormData();
                      imageData.append("file", values.image);

                      await axios
                        .post(
                          `${import.meta.env.VITE_DB_SERVER}/Host/createEvent`,
                          {
                            ...eventObj,
                          }
                        )
                        .then((resp) => {
                          eventId = resp.data;
                        })
                        .catch((err) => {
                          console.error(err);
                          if (
                            Array.isArray(err.response.data) &&
                            err.response.data.length > 0
                          ) {
                            alert(err.response.data[0].description);
                          } else {
                            alert(err.response.data);
                          }
                        });

                      await axios
                        .post(
                          `${
                            import.meta.env.VITE_DB_SERVER
                          }/Image/uploadImage/${eventId}`,
                          imageData,
                          {
                            headers: {
                              "Content-Type": "multipart/form-data",
                            },
                          }
                        )
                        .then(() => {
                          alert(t("SuccessfullyScheduledEvent"));
                          props.showEvent(View.Basic);
                        })
                        .catch((err) => {
                          console.error(err);
                          if (
                            Array.isArray(err.response.data) &&
                            err.response.data.length > 0
                          ) {
                            alert(err.response.data[0].description);
                          } else {
                            alert(err.response.data);
                          }
                        });
                    }}
                  >
                    {t("ScheduleEvent")}
                  </Button>
                </div>
              </Stack>
            </Fieldset>
          </form>

          <Fieldset
            legend={t("QuerySpaces")}
            w="50%"
            h="fit-content"
            fz="xl"
            styles={{
              root: {
                display: "flex",
                justifyContent: "space-between",
                gap: "10px",
                flexDirection: "column",
                alignItems: "center",
              },
            }}
            mb={10}
          >
            <Group w="100%" justify="center" mb={10}>
              <Select
                label={t("Location")}
                data={areLocationsLoading || locationsError ? [] : locations}
                value={selectedCity}
                onChange={(value) => setSelectedCity(value ? value : "")}
                clearable
              />
              <NumberInput
                label={t("Capacity")}
                inputMode="numeric"
                value={capacity}
                onChange={(value) => setCapacity(parseInt(value.toString()))}
                inputContainer={(children) => (
                  <Group align="flex-start">
                    {children}
                    <Button
                      onClick={() =>
                        queryClient.invalidateQueries({
                          queryKey: ["new_event_spaces"],
                        })
                      }
                    >
                      {t("Query")}
                    </Button>
                  </Group>
                )}
              />
            </Group>
            <Checkbox
              checked={selectedSpaceId != -1}
              label={t("SelectedSpace?")}
              disabled
            />
            {areSpacesLoading || spacesError ? (
              <div className={classes.controls}>
                <div className={classes.ldsRing}>
                  <div></div>
                  <div></div>
                  <div></div>
                  <div></div>
                </div>
              </div>
            ) : (
              <Table>
                <Table.Thead>
                  <Table.Tr>
                    <Table.Th>{t("City")}</Table.Th>
                    <Table.Th>{t("Country")}</Table.Th>
                    <Table.Th>{t("Address")}</Table.Th>
                    <Table.Th>{t("SeatingCapacity")}</Table.Th>
                    <Table.Th></Table.Th>
                  </Table.Tr>
                </Table.Thead>
                <Table.Tbody>
                  {spaces?.map((space, idx) => (
                    <Table.Tr key={idx}>
                      <Table.Td>{space.city}</Table.Td>
                      <Table.Td>{space.country}</Table.Td>
                      <Table.Td>{space.address}</Table.Td>
                      <Table.Td>{space.capacity}</Table.Td>
                      <Table.Td>
                        <Button
                          onClick={(event) => {
                            event.stopPropagation();
                            getSpacePlan(space.id);
                          }}
                        >
                          {t("Select")}
                        </Button>
                      </Table.Td>
                    </Table.Tr>
                  ))}
                </Table.Tbody>
              </Table>
            )}
          </Fieldset>
        </Flex>
        {selectedSpaceId != -1 && (
          <Drawer
            exportPlanFunctionRef={getObjectFromDrawerRef}
            plan={selectedSpacePlan}
          />
        )}
      </Flex>
    </Flex>
  );
}
