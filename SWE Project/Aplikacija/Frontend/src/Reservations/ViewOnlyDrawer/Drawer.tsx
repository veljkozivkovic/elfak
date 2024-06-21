import { DndProvider } from "react-dnd";
import { HTML5Backend } from "react-dnd-html5-backend";
import Surface from "./Surface";
import styles from "./Drawer.module.css";
import { SpaceDataType } from "../Reservation/interfaces";

export interface DrawerProps {
  plan: SpaceDataType | undefined;
}

export default function Drawer(props: DrawerProps) {

  return (
    <DndProvider backend={HTML5Backend}>
      <div
        className={styles.mainContentContainer}
        style={{
          zIndex: 1,
          overflow: "auto",
          border: "1px solid black",
          width: "100%",
        }}
      >
        <Surface spacePlan={props.plan} />
      </div>
    </DndProvider>
  );
}
