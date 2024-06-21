import { CSSProperties, FC, useRef } from "react";
import TableFreeImage from "../../../assets/table_free.png";
import TableNotFreeImage from "../../../assets/table_not_free.png";
import { useDisclosure } from "@mantine/hooks";
import {
  Box,
  CloseButton,
  Dialog,
  Group,
  Text,
} from "@mantine/core";
import { t } from "i18next";

interface TableInterface {
  id: string;
  realId: number;
  top: number;
  left: number;
  height: number;
  numberOfSeats: number;
  reserved: boolean;
  reservationId: number;
  reservedSeats: number;
  price: number;
}

const TableStyle: CSSProperties = {
  position: "absolute",
  cursor: "move",
  margin: 0,
};

export const Table: FC<TableInterface> = ({ id, realId, top, left, height, reserved, numberOfSeats, reservationId, reservedSeats, price }) => {
  const [dialogOpened, { toggle, close }] = useDisclosure(false);
  const dialogTopLeft = useRef([20, 20]);

  return (
    <>
      <img
        src={reserved ? TableNotFreeImage : TableFreeImage}
        alt="TABLE"
        id={id}
        style={{
          ...TableStyle,
          top,
          left,
          maxHeight: "20%",
          height: `${height * 0.2}%`,
        }}
        data-testid="table"
        onClick={(e) => {
          e.stopPropagation();
        }}
        onContextMenu={(e) => {
          e.preventDefault();
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
        <Group mb="sm" align="center">
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

        {reserved ? (
        <Group align="center">
          <Box>
            <Text size="sm" fw={300} miw="45px" c="red">
              {t("Table is reserved.")}
            </Text>
            <Text size="sm" fw={300} miw="45px">
              {t("Table ID:")} {realId}
              <br />
              {t("Reservation ID:")} {reservationId}
              <br />
              {t("Number of seats:")} {numberOfSeats}
              <br />
              {reservedSeats} {t("seats reserved.")}
              <br />
              {t("Price per seat:")} ${price}
            </Text>
          </Box>
        </Group>
      ) : (
      <Group align="center">
        <Box>
          <Text size="sm" fw={300} miw="45px" c="green">
            {t("Table is not reserved.")}
          </Text>
          <Text size="sm" fw={300} miw="45px">
            {t("Table ID:")} {realId}
            <br />
            {t("Number of seats:")} {numberOfSeats}
            <br />
            {t("Price per seat:")} ${price}
          </Text>
        </Box>
      </Group>
      )}
      </Dialog>
    </>
  );
};
