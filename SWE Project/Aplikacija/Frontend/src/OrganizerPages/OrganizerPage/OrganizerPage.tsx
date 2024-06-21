import { AuthState, login } from "../../store/features/auth";
import classes from "./OrganizerPage.module.css";
import EventBgImage from "../../assets/event_listing_bg_op.png";
import {
  Box,
  Button,
  Fieldset,
  Flex,
  InputLabel,
  PasswordInput,
  Stack,
  TextInput,
  Title,
  Image,
  Text,
} from "@mantine/core";
import { useQuery } from "@tanstack/react-query";
import axios from "../../../axiosconfig.ts";
import { useState, useEffect } from "react";
import { StatsCard } from "../StatsCard";
import { View } from "../EventViewPages";
import { useIsMobile } from "../../util/useIsMobile";
import { DateInput } from "@mantine/dates";
import { useForm } from "@mantine/form";
import { useDispatch } from "react-redux";
import { PasswordStrength } from "../../Auth/Utils/PasswordStrength";
import { EventBasic } from "../../AdminPages/AdminPage/interfaces.ts";
import { formatOnlyDate } from "../../AdminPages/AdminPage/AdminPage.tsx";
import { formatTimeOnly } from "../../VisitorProfile/UserProfile.tsx";
import { EventDto, HostStatistics } from "../interfaces.ts";
import { useTranslation } from "react-i18next";

export interface OrganizerPageProps {
  user: AuthState;
  showEvent: React.Dispatch<React.SetStateAction<View>>;
  setEventId: React.Dispatch<React.SetStateAction<number>>;
  setEventName: React.Dispatch<React.SetStateAction<string>>;
  setEventDate: React.Dispatch<React.SetStateAction<string>>;
  setEventDetails: React.Dispatch<React.SetStateAction<EventDto | undefined>>;
}

export default function OrganizerPage(props: OrganizerPageProps) {
  const { t } = useTranslation();
  const [imageWidth, setImageWidth] = useState("25%");
  const isMobile = useIsMobile();
  const dispatch = useDispatch();

  useEffect(() => {
    function handleResize() {
      if (document.body.clientWidth > 1000) {
        setImageWidth("25%");
      } else {
        setImageWidth("100%");
      }
    }

    window.addEventListener("resize", handleResize);

    return () => {
      window.removeEventListener("resize", handleResize);
    };
  }, []);

  const updateUserForm = useForm({
    mode: "controlled",
    initialValues: {
      firstName: props.user.firstName,
      lastName: props.user.lastName,
      city: props.user.city,
      address: props.user.address,
      birthday: new Date(props.user.birthday),
      phoneNumber: props.user.phoneNumber,
      newPassword: "",
      currentPassword: "",
    },

    validate: {
      firstName: (value) =>
        value.length > 0 ? null : t("EmptyFirstNameField"),
      lastName: (value) => (value.length > 0 ? null : t("EmptyLastNameField")),
      city: (value) =>
        value != null && value.length > 0 ? null : t("EmptyCityField"),
      address: (value) =>
        value != null && value.length > 0 ? null : t("EmptyAddressField"),
      phoneNumber: (value) =>
        value.length > 0 ? null : t("EmptyPhoneNumberField")
    },
  });

  const {
    isLoading: areEventsLoading,
    data: events,
    isError: eventsError,
  } = useQuery<EventBasic[]>({
    queryKey: ["incoming_events"],
    queryFn: async () => {
      return await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/Host/getIncomingEvents`)
        .then((resp) => {
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
          return [];
        });
    },
  });

  const {
    isLoading: arePastEventsLoading,
    data: pastEvents,
    isError: pastEventsError,
  } = useQuery<EventBasic[]>({
    queryKey: ["past_events"],
    queryFn: async () => {
      return await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/Host/getPastEvents`)
        .then((resp) => {
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
          return [];
        });
    },
  });

  const {
    isLoading: isStatisticsLoading,
    data: statistics,
    isError: statisticsError,
  } = useQuery<HostStatistics>({
    queryKey: ["host_statistics"],
    queryFn: async () => {
      return await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/Host/getStatistics`)
        .then((resp) => {
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
          return null;
        });
    },
  });

  const getEventDetails = async (eventId: number) => {
    return await axios
      .get(`${import.meta.env.VITE_DB_SERVER}/Host/getEventDetails/${eventId}`)
      .then((resp) => {
        return resp.data;
      })
      .catch((err) => {
        console.error(err);
        alert(err.resp.data);
        return null;
      });
  };

  return (
    <Flex
      className={classes.mainContentFlex}
      styles={{
        root: {
          backgroundImage: `url(${EventBgImage})`,
          backgroundRepeat: "repeat",
        },
      }}
    >
      <Flex className={classes.contentContainerFlex}>
        <Title mb={10}>{t("UserInfo")}</Title>
        <Stack className={classes.contentStack}>
          <form
            onSubmit={updateUserForm.onSubmit((_, event) => {
              event?.stopPropagation();
            })}
          >
            <Fieldset
              legend={t("PersonalInformation")}
              w="98%"
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
                  label={t("UserID")}
                  disabled
                  value={props.user.userId}
                ></TextInput>
                <TextInput
                  label={t("FirstName")}
                  key={updateUserForm.key("firstName")}
                  {...updateUserForm.getInputProps("firstName")}
                />
                <TextInput
                  label={t("City")}
                  key={updateUserForm.key("city")}
                  {...updateUserForm.getInputProps("city")}
                />
                <DateInput
                  label={t("Birthday")}
                  key={updateUserForm.key("birthday")}
                  {...updateUserForm.getInputProps("birthday")}
                />
                <PasswordStrength
                  label={t("NewPassword")}
                  placeholder={t("NewPassword")}
                  required={false}
                  key={updateUserForm.key("password")}
                  useFormProps={{
                    ...updateUserForm.getInputProps("newPassword"),
                  }}
                />
              </Stack>
              <Stack w="50%">
                <TextInput label="Email" disabled value={props.user.email} />{" "}
                <TextInput
                  label={t("LastName")}
                  key={updateUserForm.key("lastName")}
                  {...updateUserForm.getInputProps("lastName")}
                />
                <TextInput
                  label={t("Address")}
                  key={updateUserForm.key("address")}
                  {...updateUserForm.getInputProps("address")}
                />
                <TextInput
                  label={t("PhoneNumber")}
                  key={updateUserForm.key("phoneNumber")}
                  {...updateUserForm.getInputProps("phoneNumber")}
                />
                <PasswordInput
                  label={t("CurrentPassword")}
                  placeholder={t("CurrPassP")}
                  key={updateUserForm.key("currentPassword")}
                  {...updateUserForm.getInputProps("currentPassword")}
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
                    {t("SaveChanges")}
                  </InputLabel>
                  <Button
                    type="submit"
                    onClick={async (event) => {
                      event.stopPropagation();

                      const values = updateUserForm.getValues();

                      if (updateUserForm.validate().hasErrors) {
                        return;
                      }

                      await axios
                        .put(
                          `${
                            import.meta.env.VITE_DB_SERVER
                          }/Account/updateUser`,
                          {
                            ...values,
                            birthday: values.birthday.toISOString(),
                          }
                        )
                        .then((resp) => {
                          alert(t("SuccessfullyChangedUserInfo"));
                          const obj = JSON.parse(
                            atob(resp.data.token.split(".")[1])
                          );
                          dispatch(
                            login({
                              userId: obj["nameid"],
                              token: resp.data.token,
                              email: obj["email"],
                              userType: obj["role"],

                              firstName: resp.data.firstName,
                              lastName: resp.data.lastName,
                              birthday: resp.data.dateOfBirth,
                              phoneNumber: resp.data.phoneNumber,
                              avatar: resp.data.avatar,
                              address: resp.data.address,
                              city: resp.data.city,
                            })
                          );
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
                    {t("SaveChanges")}
                  </Button>
                </div>
              </Stack>
            </Fieldset>
          </form>
          <Fieldset
            legend={t("Statistics")}
            w="98%"
            fz="sm"
            styles={{
              root: {
                display: "flex",
                justifyContent: "space-between",
                flexWrap: "wrap",
              },
            }}
          >
            <StatsCard
              title={t("HostedEvents")}
              current={
                statistics && !isStatisticsLoading && !statisticsError
                  ? statistics.hostedEvents
                  : 0
              }
            />
            <StatsCard
              title={t("AverageRating")}
              current={
                statistics && !isStatisticsLoading && !statisticsError
                  ? statistics.averageRating
                  : 0
              }
            />
            <StatsCard
              title={t("Reservations")}
              current={
                statistics && !isStatisticsLoading && !statisticsError
                  ? statistics.reservations
                  : 0
              }
            />
            <StatsCard
              title={t("EstimatedEarnings")}
              current={
                statistics && !isStatisticsLoading && !statisticsError
                  ? statistics.estimatedEarnings
                  : 0
              }
            />
          </Fieldset>
        </Stack>
      </Flex>
      <Flex className={classes.contentContainerFlex}>
        <Title>
          {t("IncomingEvents")}{" "}
          <Button
            onClick={(e) => {
              e.stopPropagation();
              if (isMobile) {
                alert(
                  t("CannotScheduleEventFromMobileDevice.WeAreWorkingOnIt")
                );
                return;
              }
              props.showEvent(View.NewEvent);
            }}
          >
            {t("NewEvent")}
          </Button>
        </Title>
        <Stack className={classes.contentStack} align="center">
          {(areEventsLoading || eventsError) && (
            <div className={classes.controls}>
              <div className={classes.ldsRing}>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
              </div>
            </div>
          )}
          {!areEventsLoading &&
            !eventsError &&
            events?.map((ev, idx) => (
              <Flex
                key={idx}
                p="sm"
                columnGap="md"
                className={classes.reservationAndVisitedDiv}
              >
                <Image
                  src={`data:image/jpeg;base64,${ev.image}`}
                  alt={`${t("CouldNotLoad")} ${ev.name} ${t("Image")}`}
                  fit="cover"
                  w={imageWidth}
                  className={classes.reservationAndVisitedDivImage}
                />
                <Box className={classes.reservationAndVisitedDivBox}>
                  <Text className={classes.reservationAndVisitedDivText}>
                    {ev.name}
                    <br />
                    {formatOnlyDate(new Date(ev.date))}{" "}
                    {formatTimeOnly(new Date(ev.date))}
                  </Text>
                </Box>
                <Stack w="fit-content" gap={5} align="center">
                  <Button
                    w="fit-content"
                    onClick={async (event) => {
                      event.stopPropagation();
                      if (isMobile) {
                        alert(
                          t(
                            "CannotScheduleEventFromMobileDevice.WeAreWorkingOnIt"
                          )
                        );
                        return;
                      }
                      props.setEventId(ev.id);
                      const eventDetails = await getEventDetails(ev.id);
                      props.setEventDetails(eventDetails);
                      props.showEvent(View.ManageEvent);
                    }}
                  >
                    {t("Manage")}
                  </Button>
                  <Button
                    w="fit-content"
                    onClick={async (event) => {
                      event.stopPropagation();

                      const data = await axios
                        .get(
                          `${
                            import.meta.env.VITE_DB_SERVER
                          }/Host/getReservations/${ev.id}`
                        )
                        .then((resp) => {
                          return resp.data;
                        })
                        .catch((err) => {
                          console.error(err);
                          alert(
                            "There was an error while trying to fetch list of visitors"
                          );
                        });

                      const blob = new Blob([data], {
                        type: "text/plain",
                      });
                      const url = URL.createObjectURL(blob);
                      const a = document.createElement("a");
                      a.href = url;
                      a.download = "data.txt";
                      document.body.appendChild(a);
                      a.click();
                      document.body.removeChild(a);
                      URL.revokeObjectURL(url);
                    }}
                  >
                    {t("Reservations")}
                  </Button>
                </Stack>
              </Flex>
            ))}
        </Stack>
      </Flex>
      <Flex className={classes.contentContainerFlex}>
        <Title>{t("PastEvents")}</Title>
        <Stack className={classes.contentStack} align="center">
          {(arePastEventsLoading || pastEventsError) && (
            <div className={classes.controls}>
              <div className={classes.ldsRing}>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
              </div>
            </div>
          )}
          {!arePastEventsLoading &&
            !pastEventsError &&
            pastEvents?.map((ev, idx) => (
              <Flex
                key={idx}
                p="sm"
                columnGap="md"
                className={classes.reservationAndVisitedDiv}
              >
                <Image
                  className={classes.reservationAndVisitedDivImage}
                  src={`data:image/jpeg;base64,${ev.image}`}
                  alt={`${t("CouldNotLoad")} ${ev.name} ${t("Image")}`}
                  fit="cover"
                  w={imageWidth}
                />
                <Box className={classes.reservationAndVisitedDivBox}>
                  <Text className={classes.reservationAndVisitedDivText}>
                    {ev.name}
                    <br />
                    {formatOnlyDate(new Date(ev.date))}{" "}
                    {formatTimeOnly(new Date(ev.date))}
                  </Text>
                </Box>
                <Button
                  w="fit-content"
                  onClick={(event) => {
                    event.stopPropagation();
                    props.setEventId(ev.id);
                    props.setEventName(ev.name);
                    props.setEventDate(formatOnlyDate(new Date(ev.date)));
                    props.showEvent(View.PastEventDetails);
                  }}
                >
                  {t("Reviews")}
                </Button>
              </Flex>
            ))}
        </Stack>
      </Flex>
    </Flex>
  );
}
