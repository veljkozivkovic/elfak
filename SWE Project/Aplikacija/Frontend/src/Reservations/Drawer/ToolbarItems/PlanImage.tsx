import { CSSProperties, FC, useEffect, useRef, useState } from "react";
import { ItemTypes } from "../ItemTypes";
import { useDrag } from "react-dnd";
import { useDisclosure } from "@mantine/hooks";
import { Button, Dialog, Group, Text, Slider } from "@mantine/core";
import { t } from "i18next";

interface StageInterface {
  id: string;
  top: number;
  left: number;
  src: string;
  exportFunctions: Map<string, Function | null>;
}

const PlanImageStyle: CSSProperties = {
  position: "absolute",
  cursor: "move",
  margin: 0,
};

export const PlanImage: FC<StageInterface> = ({
  id,
  top,
  left,
  src,
  exportFunctions,
}) => {
  const [{ isDragging }, drag] = useDrag(
    () => ({
      type: ItemTypes.PLAN_IMAGE,
      item: { id, top, left },
      collect: (monitor) => ({
        isDragging: monitor.isDragging(),
      }),
    }),
    [id, top, left]
  );
  const [dialogOpened, { toggle, close }] = useDisclosure(false);
  const dialogTopLeft = useRef([20, 20]);
  const [height, setHeight] = useState(80);

  function exportAsJSON() {
    return {
      type: ItemTypes.PLAN_IMAGE,
      id: id,
      top: top,
      left: left,
      height: height,
      heightFactor: 0.9,
    };
  }
  useEffect(() => {
    exportFunctions.set(id, exportAsJSON);
  }, [height, top, left]);

  if (isDragging) {
    return <img ref={drag} />;
  }

  return (
    <>
      <img
        id={id}
        ref={drag}
        style={{
          ...PlanImageStyle,
          top,
          left,
          maxWidth: "90%",
          maxHeight: "90%",
          height: `${height * 0.9}%`,
        }}
        src={src}
        alt="There was a mistake loading your image, please try again."
        data-testid="plan-image"
        onContextMenu={(e) => {
          e.preventDefault();
          dialogTopLeft.current = [e.clientY, e.clientX];
          toggle();
        }}
      />
      <Dialog
        opened={dialogOpened}
        withCloseButton
        onClose={close}
        size="md"
        radius="md"
        position={{
          top: dialogTopLeft.current[0],
          left: dialogTopLeft.current[1],
        }}
      >
        <Text size="sm" mb="md" fw={300}>
          {t("Edit picture properties")}
        </Text>

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
