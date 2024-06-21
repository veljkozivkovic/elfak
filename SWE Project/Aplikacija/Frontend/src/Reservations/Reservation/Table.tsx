import { TableInterface } from "./interfaces";
import TableFreeImage from "../../assets/table_free.png";
import TableNotFreeImage from "../../assets/table_not_free.png";
import TableMineImage from "../../assets/table_mine.png";
import { Box, Button, CloseButton, Dialog, Group, Text, TextInput } from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";
import { useRef, useState } from "react";
import axios from "../../../axiosconfig.ts";
import { useQueryClient } from "@tanstack/react-query";
import { useTranslation } from "react-i18next";

export interface TableProps {
  item: TableInterface;
}

export default function Table({ item }: TableProps) {
  const [dialogInputFieldVal, setDialogInputFieldVal] = useState(""); 
  const [dialogOpened, { toggle, close }] = useDisclosure(false);
  const dialogTopLeft = useRef([20, 20]);
  const queryClient = useQueryClient();
  const { t } = useTranslation();
  const makeReservation = async (itemId: number, numberOfSeats: number) => {
    try {
      await axios.post(
        `${import.meta.env.VITE_DB_SERVER}/Reservation/makeReservation/${itemId}/${numberOfSeats}`
      );
      alert(t("Reservation made succesfully!"));
      queryClient.invalidateQueries({ queryKey: ["reservedSpace"] });
    } catch (err : any) {
      console.error(err);
      alert(err.response.data);
    }
  };

  return (
    <>
      <img
        key={item.id}
        style={{
          position: "absolute",
          top: item.top,
          left: item.left,
          zIndex: 5,
        }}
        height={`${item.height * item.heightFactor}%`}
        src={
          !(item as TableInterface).reserved ? TableFreeImage :
          (item as TableInterface).reservationId != -1 ? TableMineImage : TableNotFreeImage
        }
        onClick={(e) => {
          e.stopPropagation();
          dialogTopLeft.current = [e.clientY, e.clientX];
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
        <Group mb="md" align="center">
          <Text size="sm" fw={300} flex={1}>
            {t("Information about this table")}
          </Text>
          <CloseButton
            onClick={(event) => {
              event.stopPropagation();
              close();
            }}
          />
        </Group>

        {item.reserved ? (
          <Group align="center" mb="xs">
            {item.reservationId != -1 ? (
            <Box>
            <Text size="sm" fw={300} miw="45px" c="green">
              {t("You have reserved this table.")}
            </Text>
            <Text size="sm" fw={300} miw="45px">
              {t("Reservation ID:")} {item.reservationId}
              <br />
              {item.reservedSeats} {t("seats reserved.")}
              <br />
              {t("Price per seat:")} ${item.price}
            </Text>
            </Box>
            ) : (
            <Text size="sm" fw={300} miw="45px" c="red">
              {t("Table is already reserved!")}
            </Text>
            )}
          </Group>
        ) : (
          <>
            <Group align="center" mb="xs">
              <Text size="sm" fw={300} miw="45px">
                {t("Price per seat:")} ${item.price}
              </Text>
            </Group>
            <Group align="center" mb="xs">
              <Text size="sm" fw={300} miw="45px">
                {t("Number of seats:")} {item.numberOfSeats}
              </Text>
            </Group>
            <Group align="center" mb="xl">
              <Text size="sm" fw={300} miw="45px">
                {t("Reserve seats:")} {" "}
              </Text>
              <TextInput
                placeholder="Number of seats..."
                style={{ flex: 1 }}
                value={dialogInputFieldVal}
                onChange={(event) => 
                  setDialogInputFieldVal(
                    event.currentTarget.value
                      .split("")
                      .filter((c) => c >= "0" && c <= "9")
                      .join("")
                  )
                }
              />
        </Group>
        <Button
          w="100%"
          onClick={(e) => {
            e.stopPropagation();

            if (!dialogInputFieldVal) {
              alert(t("Please enter number of seats!"));
              return;
            }

            if (parseInt(dialogInputFieldVal) < 0.75 * item.numberOfSeats) {
              alert(t("You need to reserve at least 75% of the seats!"));
              return;
            }

            if (parseInt(dialogInputFieldVal) > item.numberOfSeats) {
              alert(`${t("Table only has")} ${item.numberOfSeats} ${t("seats!")}`);
              return;
            }
            makeReservation(item.realId, parseInt(dialogInputFieldVal));
            close();
          }}
        >
          {t("Make a reservation")}
        </Button>
          </>
        )}

      </Dialog>
    </>
  );
}
