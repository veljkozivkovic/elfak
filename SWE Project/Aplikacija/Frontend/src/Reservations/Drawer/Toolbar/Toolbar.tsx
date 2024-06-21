import { Group } from "@mantine/core";
import styles from "./Toolbar.module.css";
import { t } from "i18next";

export interface ToolbarProps {
  cornerState: [boolean, React.Dispatch<React.SetStateAction<boolean>>];
  tableState: [boolean, React.Dispatch<React.SetStateAction<boolean>>];
  stageState: [boolean, React.Dispatch<React.SetStateAction<boolean>>];
  barState: [boolean, React.Dispatch<React.SetStateAction<boolean>>];
}

export default function Toolbar(props: ToolbarProps) {
  return (
    <Group h="50px">
      <p
        style={{
          border: props.cornerState[0]
            ? "2px dashed hsla(0, 0%, 57%, 0.897)"
            : "none",
        }}
        className={styles.p}
        onClick={() => {
          props.cornerState[1](!props.cornerState[0]);
          props.tableState[1](false);
          props.stageState[1](false);
          props.barState[1](false);
        }}
      >
        {t("Corner")}
      </p>
      <p
        style={{
          border: props.tableState[0]
            ? "2px dashed hsla(0, 0%, 57%, 0.897)"
            : "none",
        }}
        className={styles.p}
        onClick={() => {
          props.tableState[1](!props.tableState[0]);
          props.cornerState[1](false);
          props.stageState[1](false);
          props.barState[1](false);
        }}
      >
        {t("Table")}
      </p>
      <p
        style={{
          border: props.stageState[0]
            ? "2px dashed hsla(0, 0%, 57%, 0.897)"
            : "none",
        }}
        className={styles.p}
        onClick={() => {
          props.stageState[1](!props.stageState[0]);
          props.cornerState[1](false);
          props.tableState[1](false);
          props.barState[1](false);
        }}
      >
        {t("Stage")}
      </p>
      <p
        style={{
          border: props.barState[0]
            ? "2px dashed hsla(0, 0%, 57%, 0.897)"
            : "none",
        }}
        className={styles.p}
        onClick={() => {
          props.barState[1](!props.barState[0]);
          props.cornerState[1](false);
          props.tableState[1](false);
          props.stageState[1](false);
        }}
      >
        {t("Bar")}
      </p>
    </Group>
  );
}
