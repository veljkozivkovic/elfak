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
  NumberInput,
  FileInput,
  TagsInput,
} from "@mantine/core";
import classes from "./ManageEvent.module.css";
import EventBgImage from "../../assets/event_listing_bg_op.png";
import { AuthState } from "../../store/features/auth";
import View from "../EventViewPages";
import { DateInput } from "@mantine/dates";
import { StatsCard } from "../StatsCard";
import { useState } from "react";
import { ChangeEventDto, EventDto } from "../interfaces";
import { useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "../../../axiosconfig";
import { useForm } from "@mantine/form";
import { CustomStatsCard } from "../../VisitorProfile/CustomStatsCard";
import { useTranslation } from "react-i18next";
import Drawer from "../../Reservations/ViewOnlyDrawer/Drawer";
import { SpaceDataType } from "../../Reservations/Reservation/interfaces";

export interface ManageEventProps {
  user: AuthState;
  showEvent: React.Dispatch<React.SetStateAction<View>>;
  eventId: number;
  eventDetails?: EventDto;
}

export default function ManageEvent(props: ManageEventProps) {
  const [tags, setTags] = useState<string[]>(props.eventDetails?.tags ?? []);
  const { t } = useTranslation();
  const queryClient = useQueryClient();

  const cancelEvent = async (eventId: number) => {
    try {
      if (confirm(t("AreYouSureYouWantToCancelThisEvent"))) {
        await axios
          .delete(
            `${import.meta.env.VITE_DB_SERVER}/Host/cancelEvent/${eventId}`
          )
          .then(() => {
            queryClient.invalidateQueries({ queryKey: ["incoming_events"] });
            props.showEvent(View.Basic);
            alert(t("EventHasBeenSuccessfullyCanceled"));
          });
      }
    } catch (err: any) {
      if (Array.isArray(err.response.data) && err.response.data.length > 0) {
        alert(err.response.data[0].description);
      } else {
        alert(err.response.data);
      }
      console.error(err);
    }
  };

  const { data: spacePlan } = useQuery<SpaceDataType>({
    queryKey: ["event_plan"],
    queryFn: async () => {
      return await axios
        .get(
          `${import.meta.env.VITE_DB_SERVER}/Host/getEventSpace/${
            props.eventId
          }`
        )
        .then((resp) => {
          console.log(resp.data);
          return resp.data;
        })
        .catch((err) => {
          console.error(err);
          alert(err.resp.data);
        });
    },
  });

  const changeEventForm = useForm({
    mode: "controlled",
    initialValues: {
      eventName: props.eventDetails?.eventName,
      description: props.eventDetails?.description,
      date: new Date(props.eventDetails?.date ?? Date.now()),
      tags: props.eventDetails?.tags,
      time: props.eventDetails?.time,
      image: null,
      video: props.eventDetails?.video,
    },

    validate: {
      eventName: (value) =>
        value && value.length > 0 ? null : t("EmptyEventNameField"),
      description: (value) =>
        value && value.length > 0 ? null : t("EmptyDescriptionField"),
      time: (value) =>
        /^(?:[01]\d|2[0-3]):[0-5]\d$/.test(value ?? "")
          ? null
          : t("WrongTimeFormat"),
    },
  });

  return (
    <>
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
              queryClient.invalidateQueries({ queryKey: ["event_preview"] });
            }}
          >
            {t("GoBack")}
          </Button>
          <Title c="#5a5959">{t("ManageEvent")}</Title>
          <Button
            bg={"red"}
            onClick={async () => {
              await cancelEvent(props.eventId);
            }}
          >
            {t("CancelEvent")}
          </Button>
        </Group>

        <Flex
          w="100%"
          h="100%"
          mt="20"
          align="center"
          justify="center"
          gap="10px"
          className={classes.subTitleContainer}
        >
          <form
            style={{
              width: "100%",
              height: "fit-content",
              marginBottom: "10px",
            }}
            onSubmit={changeEventForm.onSubmit((_, event) => {
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
                  key={changeEventForm.key("eventName")}
                  {...changeEventForm.getInputProps("eventName")}
                ></TextInput>
                <Textarea
                  required
                  placeholder={t("WriteSomethingAbouTthEevent...")}
                  label={t("Description")}
                  autosize
                  minRows={5}
                  key={changeEventForm.key("description")}
                  {...changeEventForm.getInputProps("description")}
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
                  label={t("Date")}
                  key={changeEventForm.key("date")}
                  {...changeEventForm.getInputProps("date")}
                />
                <TextInput
                  required
                  placeholder="HH:mm"
                  label={t("Time")}
                  key={changeEventForm.key("time")}
                  {...changeEventForm.getInputProps("time")}
                />
                <FileInput
                  required
                  placeholder={t("ImageToBeDisplayed")}
                  label={t("PromoImage")}
                  key={changeEventForm.key("image")}
                  {...changeEventForm.getInputProps("image")}
                />
                <TextInput
                  placeholder={t("YouTubeEmbedLink")}
                  label={t("PromoVideo")}
                  key={changeEventForm.key("video")}
                  {...changeEventForm.getInputProps("video")}
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
                    {t("Edit")}
                  </InputLabel>
                  <Button
                    type="submit"
                    onClick={async (event) => {
                      event.stopPropagation();
                      const values = changeEventForm.getValues();

                      if (changeEventForm.validate().hasErrors) {
                        return;
                      }

                      if (tags.length === 0) {
                        alert(t("PleaseAddAtLeastOneTag"));
                        return;
                      }

                      if (values.image === null) {
                        alert(t("PleaseUploadAnImage"));
                        return;
                      }

                      if (
                        values.description
                          ? values.description.length > 500
                          : false
                      ) {
                        alert(t("DescriptionTooLong"));
                        return;
                      }

                      const eventObj: ChangeEventDto = {
                        id: props.eventId,
                        eventName: values.eventName ?? "",
                        description: values.description ?? "",
                        tags: tags,
                        date: values.date
                          ? values.date.toISOString().split("T")[0]
                          : "",
                        time: values.time ?? "",
                        video: values.video ?? "",
                      };

                      const imageData = new FormData();
                      imageData.append("file", values.image);

                      await axios
                        .put(
                          `${
                            import.meta.env.VITE_DB_SERVER
                          }/Host/changeEventDetails`,
                          {
                            ...eventObj,
                          }
                        )
                        .then((resp) => {
                          queryClient.invalidateQueries({
                            queryKey: ["event_preview"],
                          });
                          return resp.data;
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
                          }/Image/uploadImage/${props.eventId}`,
                          imageData,
                          {
                            headers: {
                              "Content-Type": "multipart/form-data",
                            },
                          }
                        )
                        .then(() => {
                          alert(t("SuccessfullyChangedEventInfo"));
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
                    {t("EditEventDetails")}
                  </Button>
                </div>
              </Stack>
            </Fieldset>
          </form>

          <Flex w="50%" direction="column">
            <Fieldset
              legend={t("SpaceInformation")}
              w="100%"
              h="fit-content"
              fz="xl"
              styles={{
                root: {
                  display: "flex",
                  justifyContent: "space-between",
                  gap: "10px",
                  flexDirection: "column",
                },
              }}
              mb={10}
            >
              <Stack w="100%" justify="center">
                <TextInput
                  label={t("Location")}
                  value={props.eventDetails?.location}
                  disabled={true}
                />
                <TextInput
                  label={t("Address")}
                  value={props.eventDetails?.address}
                  disabled={true}
                />
                <NumberInput
                  disabled={true}
                  label={t("Capacity")}
                  inputMode="numeric"
                  value={props.eventDetails?.capacity}
                />
                <TextInput
                  label={t("SpaceOwnerPhoneNumber")}
                  value={props.eventDetails?.phoneNumber}
                  disabled={true}
                />
              </Stack>
            </Fieldset>

            <Fieldset
              legend={t("Statistics")}
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
              <CustomStatsCard
                title={t("ReservedTables")}
                dash={false}
                level=""
                current={props.eventDetails?.reservedTables ?? 0}
                nextStage={props.eventDetails?.maxTables ?? 0}
              />
              <StatsCard
                title={t("TotalEarning")}
                current={props.eventDetails?.totalEarnings ?? 0}
              />
            </Fieldset>
          </Flex>
        </Flex>
      </Flex>
      <div>
        <Drawer plan={spacePlan} />
      </div>
    </>
  );
}
