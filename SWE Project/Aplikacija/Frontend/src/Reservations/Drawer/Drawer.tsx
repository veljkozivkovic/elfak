import { Button, Flex, Group, Text } from "@mantine/core";
import { useRef, useState } from "react";
import { DndProvider } from "react-dnd";
import { HTML5Backend } from "react-dnd-html5-backend";
import Toolbar from "./Toolbar/Toolbar";
import Surface from "./Surface";
import styles from "./Drawer.module.css";
import { useTranslation } from "react-i18next";

export interface DrawerProps {
  onSubmit: Function;
  onCancel: Function;
}

export default function Drawer(props: DrawerProps) {
  const { t } = useTranslation();
  const [isCornerSelectedFromToolbar, setIsCornerSelectedFromToolbar] =
    useState(false);
  const [isTableSelectedFromToolbar, setIsTableSelectedFromToolbar] =
    useState(false);
  const [isStageSelectedFromToolbar, setIsStageSelectedFromToolbar] =
    useState(false);
  const [isBarSelectedFromToolbar, setIsBarSelectedFromToolbar] =
    useState(false);
  const [image, setImage] = useState<File | null>(null);
  const exportPlanFunctionRef = useRef<Function | null>(null);

  function setNewExportPlanFunction(exportFunction: Function) {
    exportPlanFunctionRef.current = exportFunction;
  }

  const handleImageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const selectedImage = event.target.files && event.target.files[0];
    setImage(selectedImage || null);
  };

  return (
    <DndProvider backend={HTML5Backend}>
      <Flex
        align="center"
        justify="center"
        direction="column"
        w="100%"
        h="100vh"
        className={styles.gradiental}
      >
        <h1 style={{ color: "hsla(0, 0%, 57%, 0.7)", marginBottom: "0" }}>
          {t("Draw floor plan")}
        </h1>
        <Text m="0" style={{ color: "hsla(0, 0%, 57%, 0.7)" }}>
          {t("Please keep browser open in full screen mode")}
        </Text>
        <Group align="center" justify="center" m="sm">
          <Toolbar
            cornerState={[
              isCornerSelectedFromToolbar,
              setIsCornerSelectedFromToolbar,
            ]}
            tableState={[
              isTableSelectedFromToolbar,
              setIsTableSelectedFromToolbar,
            ]}
            stageState={[
              isStageSelectedFromToolbar,
              setIsStageSelectedFromToolbar,
            ]}
            barState={[isBarSelectedFromToolbar, setIsBarSelectedFromToolbar]}
          />
          {image === null && (
            <input
              type="file"
              accept="image/png, image/jpeg"
              onChange={handleImageChange}
            />
          )}
          {image != null && (
            <button onClick={() => setImage(null)}>{t("Clear picture")}</button>
          )}
        </Group>
        <Surface
          isCornerSelectedFromToolbar={isCornerSelectedFromToolbar}
          isTableSelectedFromToolbar={isTableSelectedFromToolbar}
          isStageSelectedFromToolbar={isStageSelectedFromToolbar}
          isBarSelectedFromToolbar={isBarSelectedFromToolbar}
          planImage={image}
          changeExportFunctionRef={setNewExportPlanFunction}
        />
        <Group>
          <Button
            bg="green"
            m="10px"
            onClick={() => {
              if (exportPlanFunctionRef.current)
                props.onSubmit(exportPlanFunctionRef.current());
            }}
          >
            {t("Submit")}
          </Button>
          <Button
            m="10px"
            onClick={() => {
              console.log(
                exportPlanFunctionRef.current && exportPlanFunctionRef.current()
              );
              props.onCancel();
            }}
            bg="red"
          >
            {t("Cancel")}
          </Button>
        </Group>
      </Flex>
    </DndProvider>
  );
}
