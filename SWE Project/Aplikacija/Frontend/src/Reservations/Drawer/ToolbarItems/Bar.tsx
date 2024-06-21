import { CSSProperties, FC, useEffect, useRef, useState } from "react";
import { ItemTypes } from "../ItemTypes";
import { useDrag } from "react-dnd";
import BarImage from "../../../assets/bar.png";
import {
  Dialog,
  Group,
  CloseButton,
  Slider,
  Button,
  Text,
} from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";
import { t } from "i18next";

interface StageInterface {
  id: string;
  top: number;
  left: number;
  onRemove: () => void;
  exportFunctions: Map<string, Function | null>;
}

const StageStyle: CSSProperties = {
  position: "absolute",
  cursor: "move",
  margin: 0,
};

export const Bar: FC<StageInterface> = ({
  id,
  top,
  left,
  onRemove,
  exportFunctions,
}) => {
  const [{ isDragging }, drag] = useDrag(
    () => ({
      type: ItemTypes.BAR,
      item: { id, top, left },
      collect: (monitor) => ({
        isDragging: monitor.isDragging(),
      }),
    }),
    [id, top, left]
  );
  const [dialogOpened, { toggle, close }] = useDisclosure(false);
  const dialogTopLeft = useRef([20, 20]);
  const [height, setHeight] = useState(25);

  function exportAsJSON() {
    return {
      type: ItemTypes.BAR,
      id: id,
      top: top,
      left: left,
      height: height,
      heightFactor: 0.8,
    };
  }
  useEffect(() => {
    exportFunctions.set(id, exportAsJSON);
  }, [height, top, left]);

  if (isDragging) {
    return <div ref={drag}></div>;
  }

  return (
    <>
      <img
        src={BarImage}
        alt="BAR"
        id={id}
        ref={drag}
        style={{
          ...StageStyle,
          top,
          left,
          maxHeight: "80%",
          height: `${0.8 * height}%`,
        }}
        data-testid="bar"
        onClick={(e) => {
          e.stopPropagation();
        }}
        onDoubleClick={(e) => {
          e.stopPropagation();
          onRemove();
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
        <Group mb="md" align="center">
          <Text size="sm" fw={300} flex={1}>
            {t("Bar properties")}
          </Text>
          <CloseButton
            onClick={(event) => {
              event.stopPropagation();
              close();
            }}
          />
        </Group>

        <Group align="center" mb="xl">
          <Text size="sm" fw={300} miw="45px">
            {t("size")}:{" "}
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
        <Button w="100%" onClick={close}>
          {t("Save properties")}
        </Button>
      </Dialog>
    </>
  );
};
