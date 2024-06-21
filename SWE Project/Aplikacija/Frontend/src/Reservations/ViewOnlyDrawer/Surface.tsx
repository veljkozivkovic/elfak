import { CSSProperties, useEffect, useState } from "react";
import { ItemTypes } from "./ItemTypes";
import { Table } from "./ToolbarItems/Table";
import { Stage } from "./ToolbarItems/Stage";
import { Bar } from "./ToolbarItems/Bar";
import { SpaceDataType, TableInterface } from "../Reservation/interfaces";

const styles: CSSProperties = {
  width: "90%",
  height: "70%",
  // border: "1px solid black",
  // borderRadius: "20px",
  backgroundColor: "white",
  position: "relative",
};

type SurfaceProps = {
  spacePlan: SpaceDataType | undefined;
};

export default function Surface(props: SurfaceProps) {
  const [items, setItems] = useState<{
    [key: string]: { top: number; left: number; type: string };
  }>({});

  useEffect(() => {
    props.spacePlan?.items?.forEach((x) => {
      setItems((prevItems) => ({
        ...prevItems,
        [x.id]: { top: x.top, left: x.left, type: x.type },
      }));
    });
  }, [props.spacePlan]);

  return (
    <div
      // className="main-surface-container"
      style={{
        ...styles,
        textAlign: "center",
        zIndex: 1,
        height: props.spacePlan?.surfaceDimension?.height,
        width: props.spacePlan?.surfaceDimension?.width,
      }}
    >
      {items != null &&
        Object.keys(items).map((key) => {
          const { left, top, type } = items[key] as {
            top: number;
            left: number;
            type: string;
          };
          const item = props.spacePlan?.items.find(
            (x) => x != undefined && x.id == key
          )!;
          if (item == undefined) return <></>;
          if (type == ItemTypes.TABLE) {
            return (
              <Table
                key={key}
                id={item.id}
                realId={item.realId}
                left={left}
                height={item.height}
                numberOfSeats={(item as TableInterface).numberOfSeats}
                top={top}
                reserved={(item as TableInterface).reserved}
                reservationId={(item as TableInterface).reservationId}
                reservedSeats={(item as TableInterface).reservedSeats}
                price={(item as TableInterface).price}
              />
            );
          } else if (type == ItemTypes.STAGE) {
            return (
              <Stage
                key={key}
                id={item.id}
                left={item.left}
                top={item.top}
                height={item.height}
              />
            );
          } else if (type == ItemTypes.BAR) {
            return (
              <Bar
                key={key}
                id={item.id}
                left={item.left}
                top={item.top}
                height={item.height}
              />
            );
          }
        })}
      <svg
        style={{
          height: props.spacePlan?.surfaceDimension?.height,
          width: props.spacePlan?.surfaceDimension?.width,
          zIndex: 2,
        }}
      >
        {props.spacePlan?.lines?.map((line, index) => (
          <line
            key={index}
            x1={line.x1}
            y1={line.y1}
            x2={line.x2}
            y2={line.y2}
            style={{
              stroke: "hsl(0, 1%, 47%)",
              strokeWidth: 2,
            }}
          />
        ))}
      </svg>
    </div>
  );
}
