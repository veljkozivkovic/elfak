import { AuthState } from "../../store/features/auth";
import classes from "./SpaceOwnerPage.module.css";
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
  Text,
  Group,
} from "@mantine/core";
import { useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "../../../axiosconfig.ts";
import { useIsMobile } from "../../util/useIsMobile";
import { StatsCard } from "../StatsCard";
import View from "../SpaceViewPages";
import { DateInput } from "@mantine/dates";
import { Space, SpaceOwnerStatistics, SpaceReservation } from "./interfaces.ts";
import { PasswordStrength } from "../../Auth/Utils/PasswordStrength.tsx";
import { useForm } from "@mantine/form";
import { useDispatch } from "react-redux";
import { login } from "../../store/features/auth";
import { useTranslation } from "react-i18next";

export interface OrganizerPageProps {
  user: AuthState;
  showSpace: React.Dispatch<React.SetStateAction<View>>;
}

export function formatDate(date: Date) {
  const day = String(date.getDate()).padStart(2, "0");
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const year = date.getFullYear();
  const hours = String(date.getHours()).padStart(2, "0");
  const minutes = String(date.getMinutes()).padStart(2, "0");

  return `${day}.${month}.${year}. ${hours}:${minutes}`;
}

export default function SpaceOwnerPage(props: OrganizerPageProps) {
  const isMobile = useIsMobile();
  const queryClient = useQueryClient();
  const dispatch = useDispatch();
  const { t } = useTranslation();

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
      firstName: (value) => (value.length > 0 ? null : t("EmptyFirstName")),
      lastName: (value) => (value.length > 0 ? null : t("EmptyLastName")),
      city: (value) =>
        value != null && value.length > 0 ? null : t("EmptyCity"),
      address: (value) =>
        value != null && value.length > 0 ? null : t("EmptyAddress"),
      phoneNumber: (value) => (value.length > 0 ? null : t("EmptyPhoneNumber"))
    },
  });

  const {
    isLoading: areSpacesLoading,
    data: spaces,
    isError: spacesError,
  } = useQuery<Space[]>({
    queryKey: ["owner_spaces"],
    queryFn: async () => {
      return await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/Space/getOwnerSpaces`)
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
    isLoading: areReservationsLoading,
    data: reservations,
    isError: reservationsError,
  } = useQuery<SpaceReservation[]>({
    queryKey: ["owner_reservations"],
    queryFn: async () => {
      return await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/Space/getSpacesReservations`)
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
  } = useQuery<SpaceOwnerStatistics>({
    queryKey: ["owner_statistics"],
    queryFn: async () => {
      return await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/Space/getStatistics`)
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

  const respondToReservation = async (
    reservationId: number,
    response: string
  ) => {
    try {
      await axios.put(
        `${
          import.meta.env.VITE_DB_SERVER
        }/Space/respondToSpaceReservation/${reservationId}/${response}`
      );
      queryClient.invalidateQueries({ queryKey: ["owner_reservations"] });
    } catch (err: any) {
      console.error(err);
      if (Array.isArray(err.response.data) && err.response.data.length > 0) {
        alert(err.response.data[0].description);
      } else {
        alert(err.response.data);
      }
    }
  };

  const removeSpace = async (spaceId: number) => {
    try {
      await axios.delete(
        `${import.meta.env.VITE_DB_SERVER}/Space/deleteSpace/${spaceId}`
      );
      queryClient.invalidateQueries({ queryKey: ["owner_spaces"] });
    } catch (err: any) {
      console.error(err);
      if (Array.isArray(err.response.data) && err.response.data.length > 0) {
        alert(err.response.data[0].description);
      } else {
        alert(err.response.data);
      }
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
                  label={t("CurrPass")}
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
              title={t("RentableSpaces")}
              current={
                isStatisticsLoading || statisticsError
                  ? 0
                  : statistics?.rentableSpaces || 0
              }
            />
            <StatsCard
              title={t("TotalRents")}
              current={
                isStatisticsLoading || statisticsError
                  ? 0
                  : statistics?.totalRents || 0
              }
            />
          </Fieldset>
        </Stack>
      </Flex>
      <Flex className={classes.contentContainerFlex}>
        <Title>
          {t("MySpaces")}{" "}
          <Button
            onClick={(e) => {
              e.stopPropagation();
              if (isMobile) {
                alert(t("ForbidMobile"));
                return;
              }
              props.showSpace(View.NewSpace);
            }}
          >
            {t("NewSpace")}
          </Button>
        </Title>
        <Stack className={classes.contentStack} align="center">
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
            spaces?.map((space, idx) => (
              <Flex
                key={idx}
                p="sm"
                columnGap="md"
                className={classes.reservationAndVisitedDiv}
                style={{ justifyContent: "center" }}
              >
                <Box className={classes.reservationAndVisitedDivBox}>
                  <Text className={classes.reservationAndVisitedDivText}>
                    {space.address}
                    <br />
                    {t("Capacity")}: {space.capacity}
                  </Text>
                </Box>
                <Button onClick={() => removeSpace(space.id)} bg={"red"}>
                  {t("RemoveSpace")}
                </Button>
              </Flex>
            ))
          )}
        </Stack>
      </Flex>
      <Flex className={classes.contentContainerFlex}>
        <Title>{t("ReservationStatuses")}</Title>
        <Stack className={classes.contentStack} align="center">
          {areReservationsLoading || reservationsError ? (
            <div className={classes.controls}>
              <div className={classes.ldsRing}>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
              </div>
            </div>
          ) : (
            reservations?.map((reservation, idx) => (
              <Flex
                key={idx}
                p="sm"
                columnGap="md"
                className={classes.reservationAndVisitedDiv}
              >
                <Box className={classes.reservationAndVisitedDivBox}>
                  <Text className={classes.reservationAndVisitedDivText}>
                    {reservation.address}
                    <br />
                    {formatDate(new Date(reservation.startTime))}
                    <br />
                    {formatDate(new Date(reservation.endTime))}
                  </Text>
                </Box>
                <Box className={classes.reservationAndVisitedDivBox}>
                  <Text className={classes.reservationAndVisitedDivText}>
                    {reservation.eventName}
                  </Text>
                </Box>
                {reservation.status == "WaitingConfirmation" && (
                  <Group>
                    <Button
                      bg="green"
                      fullWidth
                      onClick={() =>
                        respondToReservation(reservation.id, "accept")
                      }
                    >
                      {t("Accept")}
                    </Button>
                    <Button
                      bg="red"
                      fullWidth
                      onClick={() =>
                        respondToReservation(reservation.id, "reject")
                      }
                    >
                      {t("Reject")}
                    </Button>
                  </Group>
                )}
                {reservation.status == "Confirmed" && (
                  <Group>
                    <Button disabled={true} fullWidth>
                      {t("Upcoming")}
                    </Button>
                  </Group>
                )}
                {reservation.status == "Finished" && (
                  <Group>
                    <Button disabled={true} fullWidth>
                      {t("Finished")}
                    </Button>
                  </Group>
                )}
                {reservation.status == "Rejected" && (
                  <Group>
                    <Button disabled={true} fullWidth>
                      {t("Rejected")}
                    </Button>
                  </Group>
                )}
              </Flex>
            ))
          )}
        </Stack>
      </Flex>
    </Flex>
  );
}
