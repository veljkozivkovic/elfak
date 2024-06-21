import { CSSProperties, FC, useEffect, useRef, useState } from "react";
import { ItemTypes } from "../ItemTypes";
import { useDrag } from "react-dnd";
import TableImage from "../../../assets/table.png";
import { useDisclosure } from "@mantine/hooks";
import {
  Button,
  CloseButton,
  Dialog,
  Group,
  Slider,
  Text,
  TextInput,
} from "@mantine/core";
import { t } from "i18next";

interface TableInterface {
  id: string;
  top: number;
  left: number;
  onRemove: () => void;
  exportFunctions: Map<string, Function | null>;
}

const TableStyle: CSSProperties = {
  position: "absolute",
  cursor: "move",
  margin: 0,
};

export const Table: FC<TableInterface> = ({
  id,
  top,
  left,
  onRemove,
  exportFunctions,
}) => {
  const [{ isDragging }, drag] = useDrag(
    () => ({
      type: ItemTypes.TABLE,
      item: { id, top, left },
      collect: (monitor) => ({
        isDragging: monitor.isDragging(),
      }),
    }),
    [id, top, left]
  );
  const [dialogOpened, { toggle, close }] = useDisclosure(false);
  const dialogTopLeft = useRef([20, 20]);
  const numberOfSeats = useRef(4);
  const [dialogInputFieldVal, setDialogInputFieldVal] = useState("");
  const [height, setHeight] = useState(20);

  function exportAsJSON() {
    return {
      type: ItemTypes.TABLE,
      id: id,
      numberOfSeats: Number.isNaN(parseInt(dialogInputFieldVal))
        ? 4
        : parseInt(dialogInputFieldVal),
      reserved: false,
      price: 15,
      top: top,
      left: left,
      height: height,
      heightFactor: 0.2,
    };
  }

  useEffect(() => {
    exportFunctions.set(id, exportAsJSON);
  }, [numberOfSeats.current, height, top, left]);

  if (isDragging) {
    return <div ref={drag}></div>;
  }

  return (
    <>
      <img
        src={TableImage}
        alt="TABLE"
        id={id}
        ref={drag}
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
        onDoubleClick={(e) => {
          e.stopPropagation();
          onRemove();
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

        <Group align="center" mb="md">
          <Text size="sm" fw={300} miw="45px">
            {t("seats")}:{" "}
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
        <Group align="center" mb="xl">
          <Text size="sm" fw={300} miw="45px">
            size:{" "}
          </Text>
          <Slider
            flex={1}
            color="blue"
            marks={[
              { value: 20, label: "20%" },
              { value: 50, label: "50%" },
              { value: 80, label: "80%" },
            ]}
            value={height}
            onChange={setHeight}
          />
        </Group>
        <Button
          w="100%"
          onClick={(e) => {
            e.stopPropagation();
            numberOfSeats.current = Number.parseInt(dialogInputFieldVal);
            close();
          }}
        >
          {t("Save table information")}
        </Button>
      </Dialog>
    </>
  );
};
