import {
  Flex,
  Stack,
  Title,
  Text,
  Image,
  Button,
  Fieldset,
  TextInput,
  InputLabel,
  PasswordInput,
  TagsInput,
  Dialog,
  Group,
  CloseButton,
  SimpleGrid,
  Box,
  Slider,
  Textarea,
} from "@mantine/core";
import EventBgImage from "../assets/event_listing_bg_op.png";
import { useEffect, useRef, useState } from "react";
import { useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "../../axiosconfig.ts";
import classes from "./UserProfile.module.css";
import { useDisclosure } from "@mantine/hooks";
import { CustomStatsCard } from "./CustomStatsCard";
import { login } from "../store/features/auth";
import { DateInput } from "@mantine/dates";
import { useDispatch } from "react-redux";
import { useForm } from "@mantine/form";
import { PasswordStrength } from "../Auth/Utils/PasswordStrength";
import { StatsCard } from "../SpaceOwnerPages/StatsCard";
import {
  ActiveReservations,
  VisitedEvents,
  VisitorProfileProps,
  VisitorStatistics,
} from "./interfaces";
import { formatOnlyDate } from "../AdminPages/AdminPage/AdminPage";
import { useTranslation } from "react-i18next";

export function formatTimeOnly(date: Date) {
  const hours = String(date.getHours()).padStart(2, "0");
  const minutes = String(date.getMinutes()).padStart(2, "0");

  return `${hours}:${minutes}`;
}

export default function VisitorProfile(props: VisitorProfileProps) {
  const [tags, setTags] = useState<string[]>([]);
  const [dialogOpened, { toggle, close }] = useDisclosure(false);
  const dialogTopLeft = useRef([20, 20]);
  const [avatarN, setAvatarN] = useState<string | null>(null);
  const [eventSelectedForReview, setEventSelectedForReview] = useState<
    number | null
  >(null);
  const [review, setReview] = useState<string>("");
  const [rating, setRating] = useState<number>(-1);
  const dispatch = useDispatch();
  const queryClient = useQueryClient();
  const { t } = useTranslation();

  const [reviewDialogOpened, { toggle: toggleReview, close: closeReview }] =
    useDisclosure(false);
  const reviewDialogTopLeft = useRef([
    document.body.clientHeight / 2 - 200,
    document.body.clientWidth / 2 - 200,
  ]);

  const [imageWidth, setImageWidth] = useState("25%");
  const [avatarWidth, setAvatarWidth] = useState("30%");

  useEffect(() => {
    function handleResize() {
      if (document.body.clientWidth > 1000) {
        setImageWidth("25%");
        setAvatarWidth("30%");
      } else {
        setImageWidth("100%");
        setAvatarWidth("80%");
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
      birthday: new Date(props.user.birthday),
      phoneNumber: props.user.phoneNumber,
      newPassword: "",
      currentPassword: "",
    },

    validate: {
      firstName: (value) => (value.length > 0 ? null : t("EmptyFirstName")),
      lastName: (value) => (value.length > 0 ? null : t("EmptyLastName")),
      phoneNumber: (value) => (value.length > 0 ? null : t("EmptyPhoneNumber")),
    },
  });

  const {
    isLoading: areReservationsLoading,
    data: reservations,
    isError: reservationsError,
  } = useQuery<ActiveReservations[]>({
    queryKey: ["active_reservations"],
    queryFn: async () => {
      return await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/Visitor/getActiveReservations`)
        .then((resp) => {
          return resp.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },
  });

  const {
    isLoading: areVisitedEventsLoading,
    data: visitedEvents,
    isError: visitedEventsError,
  } = useQuery<VisitedEvents[]>({
    queryKey: ["visited_events"],
    queryFn: async () => {
      return await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/Visitor/getVisitedEvents`)
        .then((resp) => {
          return resp.data;
        })
        .catch((err) => {
          console.log(err);
          return [];
        });
    },
  });

  const {
    isLoading: isStatisticsLoading,
    data: statistics,
    isError: statisticsError,
  } = useQuery<VisitorStatistics>({
    queryKey: ["visitor_statistics"],
    queryFn: async () => {
      return await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/Visitor/getStatistics`)
        .then((resp) => {
          return resp.data;
        })
        .catch((err) => {
          console.log(err);
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

  useEffect(() => {
    const fetchAvatarAndTags = async () => {
      try {
        const resp = await axios.get(
          `${import.meta.env.VITE_DB_SERVER}/Visitor/getAvatarAndTags`
        );
        setAvatarN(resp.data.avatar);
        setTags(resp.data.tags);
      } catch (err: any) {
        console.log(err);
      }
    };

    fetchAvatarAndTags();
  }, []);

  const cancelReservation = async (reservationId: number) => {
    try {
      await axios.delete(
        `${
          import.meta.env.VITE_DB_SERVER
        }/Visitor/cancelReservation/${reservationId}`
      );
      queryClient.invalidateQueries({ queryKey: ["active_reservations"] });
    } catch (err: any) {
      if (Array.isArray(err.response.data) && err.response.data.length > 0) {
        alert(err.response.data[0].description);
      } else {
        alert(err.response.data);
      }
      console.error(err);
    }
  };

  const postReview = async () => {
    try {
      await axios.post(
        `${import.meta.env.VITE_DB_SERVER}/Visitor/postComment`,
        {
          eventId: eventSelectedForReview,
          rating: rating,
          comment: review,
        }
      );
      setRating(-1);
      setReview("");
      setEventSelectedForReview(null);
      alert("Review posted successfully!");
      queryClient.invalidateQueries({ queryKey: ["visited_events"] });
    } catch (err: any) {
      if (Array.isArray(err.response.data) && err.response.data.length > 0) {
        alert(err.response.data[0].description);
      } else {
        alert(err.response.data);
      }
      console.error(err);
      alert(err.response.data);
    }
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
          <Fieldset
            legend={t("AvatarNTags")}
            w="98%"
            fz="xl"
            mb={10}
            styles={{
              root: {
                display: "flex",
                gap: "15px",
                flexWrap: "wrap",
                justifyContent: "center",
              },
            }}
          >
            <Image
              w={avatarWidth}
              src={avatarN == null ? props.user.avatar : avatarN}
              alt="avatar currently unavailable"
              onClick={(e) => {
                e.stopPropagation();
                dialogTopLeft.current = [e.clientY - 20, e.clientX - 20];
                toggle();
              }}
            />
            <Dialog
              opened={dialogOpened}
              withCloseButton={false}
              onClose={close}
              size="md"
              radius="md"
              position={{
                top: dialogTopLeft.current[0],
                left: dialogTopLeft.current[1],
              }}
              onClick={(event) => event.stopPropagation()}
            >
              {" "}
              <Group mb="md" align="center">
                <Text size="sm" fw={300} flex={1}>
                  {t("PickAvatar")}
                </Text>
                <CloseButton
                  onClick={(event) => {
                    event.stopPropagation();
                    close();
                  }}
                />
              </Group>
              <SimpleGrid cols={3}>
                {Array.from({ length: 9 }).map((_, idx) => (
                  <Image
                    key={idx}
                    src={`https://raw.githubusercontent.com/mantinedev/mantine/master/.demo/avatars/avatar-${
                      idx + 1
                    }.png`}
                    onClick={(event) => {
                      event.stopPropagation();
                      setAvatarN(
                        `https://raw.githubusercontent.com/mantinedev/mantine/master/.demo/avatars/avatar-${
                          idx + 1
                        }.png`
                      );
                      close();
                    }}
                  />
                ))}
              </SimpleGrid>
            </Dialog>
            <Flex
              direction="column"
              gap="xs"
              align="center"
              justify="center"
              h="100%"
              flex={1}
            >
              <TagsInput
                miw="100%"
                label={t("EnterToTag")}
                placeholder={t("EnterToTagP")}
                value={tags}
                onChange={setTags}
                styles={{
                  input: {
                    overflowY: "scroll",
                    height: "5rem",
                  },
                }}
              />
              <Group w="100%" justify="center">
                <Button
                  onClick={async (event) => {
                    event.stopPropagation();

                    if (updateUserForm.validate().hasErrors) {
                      return;
                    }

                    await axios
                      .put(
                        `${
                          import.meta.env.VITE_DB_SERVER
                        }/Visitor/updateUserAvatarAndTags`,
                        {
                          avatar: avatarN,
                          tags: tags,
                        }
                      )
                      .then(() => {
                        alert(t("SuccessfullyChangedUserInfo"));
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
              </Group>
            </Flex>
          </Fieldset>
          <form
            onSubmit={updateUserForm.onSubmit((_, event) => {
              event?.stopPropagation();
            })}
          >
            <Fieldset
              legend={t("PersonalInfo")}
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
                  label={t("UID")}
                  disabled
                  value={props.user.userId}
                ></TextInput>
                <TextInput
                  label={t("FirstName")}
                  key={updateUserForm.key("firstName")}
                  {...updateUserForm.getInputProps("firstName")}
                />
                <DateInput
                  label={t("Birthday")}
                  key={updateUserForm.key("birthday")}
                  {...updateUserForm.getInputProps("birthday")}
                />
                <PasswordStrength
                  label={t("NewPass")}
                  placeholder={t("NewPassP")}
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

                      await axios
                        .put(
                          `${
                            import.meta.env.VITE_DB_SERVER
                          }/Account/updateUser`,
                          {
                            ...values,
                            avatar: avatarN,
                            birthday: values.birthday.toISOString(),
                          }
                        )
                        .then((resp) => {
                          alert("Successfully changed user info!");
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
            <CustomStatsCard
              title={t("VisitedEvents")}
              level={
                isStatisticsLoading || statisticsError
                  ? ""
                  : statistics?.rankName || ""
              }
              current={
                isStatisticsLoading || statisticsError
                  ? 0
                  : statistics?.visitedEventsCount || 0
              }
              nextStage={
                isStatisticsLoading || statisticsError
                  ? 0
                  : statistics?.nextRankPoints || 0
              }
              dash={true}
            />
            <StatsCard
              title={t("MoneySpent")}
              current={
                isStatisticsLoading || statisticsError
                  ? 0
                  : statistics?.moneySpent || 0
              }
            />
          </Fieldset>
        </Stack>
      </Flex>
      <Flex className={classes.contentContainerFlex}>
        <Title>{t("ActiveReservations")}</Title>
        <Stack className={classes.contentStack} align="center">
          {(areReservationsLoading || reservationsError) && (
            <div className={classes.controls}>
              <div className={classes.ldsRing}>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
              </div>
            </div>
          )}
          {!areReservationsLoading &&
            !reservationsError &&
            reservations?.map((reservation, idx) => (
              <Flex
                key={idx}
                p="sm"
                columnGap="md"
                className={classes.reservationAndVisitedDiv}
              >
                <Image
                  src={`data:image/jpeg;base64,${reservation.image}`}
                  alt={`Couldn't load ${reservation.title} image`}
                  fit="cover"
                  w={imageWidth}
                  className={classes.reservationAndVisitedDivImage}
                />
                <Box className={classes.reservationAndVisitedDivBox}>
                  <Text className={classes.reservationAndVisitedDivText}>
                    {reservation.title}
                    <br />
                    {formatOnlyDate(new Date(reservation.date))}
                    <br />
                    {formatTimeOnly(new Date(reservation.date))}
                  </Text>
                </Box>
                <Button
                  w="fit-content"
                  onClick={() => cancelReservation(reservation.reservationId)}
                >
                  {t("Cancel")}
                </Button>
                <Box w="20%">
                  <Text ta="center">
                    {t("ID")}: {reservation.reservationId}
                    <br />
                    ${reservation.price}
                    <br/>
                    ({reservation.seats} {t("Seats")})
                  </Text>
                </Box>
              </Flex>
            ))}
        </Stack>
      </Flex>
      <Flex className={classes.contentContainerFlex}>
        <Title>{t("VisitedEvents")}</Title>
        <Stack className={classes.contentStack} align="center">
          {areVisitedEventsLoading || visitedEventsError ? (
            <div className={classes.controls}>
              <div className={classes.ldsRing}>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
              </div>
            </div>
          ) : (
            visitedEvents?.map((ev, idx) => (
              <Flex
                key={idx}
                p="sm"
                columnGap="md"
                className={classes.reservationAndVisitedDiv}
              >
                <Image
                  className={classes.reservationAndVisitedDivImage}
                  src={`data:image/jpeg;base64,${ev.image}`}
                  alt={`Couldn't load ${ev.title} image`}
                  fit="cover"
                  w={imageWidth}
                />
                <Box className={classes.reservationAndVisitedDivBox}>
                  <Text className={classes.reservationAndVisitedDivText}>
                    {ev.title}
                    <br />
                    {formatOnlyDate(new Date(ev.date))}
                  </Text>
                </Box>

                {ev.canLeaveReview ? (
                <Button
                  w="fit-content"
                  onClick={(e) => {
                    e.stopPropagation();
                    setEventSelectedForReview(ev.eventId);
                    toggleReview();
                  }}
                >
                  {t("LeaveReview")}
                </Button>
                ) : (
                <Button
                  w="fit-content"
                  onClick={(e) => {
                    e.stopPropagation();
                  }}
                  disabled
                >
                  {t("LeaveReview")}
                </Button>
                )}
              </Flex>
            ))
          )}
        </Stack>
      </Flex>
      <Dialog
        opened={reviewDialogOpened}
        withCloseButton={false}
        onClose={close}
        size="md"
        radius="md"
        position={{
          top: reviewDialogTopLeft.current[0],
          left: reviewDialogTopLeft.current[1],
        }}
        onClick={(event) => event.stopPropagation()}
      >
        {" "}
        <Group mb="md" align="center">
          <Text size="sm" fw={300} flex={1}>
            {t("LeaveReview")}
          </Text>
          <CloseButton
            onClick={(event) => {
              event.stopPropagation();
              closeReview();
            }}
          />
        </Group>
        <Group align="center" mb="xl">
          <Text size="sm" fw={300} miw="45px">
            {t("Rating")}:{" "}
          </Text>
          <Slider
            flex={1}
            color="blue"
            min={0}
            max={10}
            marks={[
              { value: 0, label: "0" },
              { value: 1, label: "1" },
              { value: 2, label: "2" },
              { value: 3, label: "3" },
              { value: 4, label: "4" },
              { value: 5, label: "5" },
              { value: 6, label: "6" },
              { value: 7, label: "7" },
              { value: 8, label: "8" },
              { value: 9, label: "9" },
              { value: 10, label: "10" },
            ]}
            scale={(value) => value}
            value={rating}
            onChange={(value) => setRating(value)}
          />
        </Group>
        <Textarea
          mb={10}
          label={t("Review")}
          placeholder={t("ReviewP")}
          maxRows={8}
          minRows={3}
          autosize
          value={review}
          onChange={(event) => setReview(event.currentTarget.value)}
        />
        <Button
          w="100%"
          onClick={() => {
            if (rating == -1) {
              alert(t("PleaseChooseRating"));
              return;
            }
            if (review.length == 0) {
              alert(t("PleaseWriteReview"));
              return;
            }

            closeReview();
            postReview();
          }}
        >
          {t("Post review")}
        </Button>
      </Dialog>
    </Flex>
  );
}
