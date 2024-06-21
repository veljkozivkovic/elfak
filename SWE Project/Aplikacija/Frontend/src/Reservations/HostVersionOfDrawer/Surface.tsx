import { CSSProperties, useCallback, useEffect, useRef, useState } from "react";
import { XYCoord, useDrop } from "react-dnd";
import { ItemTypes } from "./ItemTypes";
import { DragItem } from "./interfaces";
import update from "immutability-helper";
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
  changeExportFunctionRef: Function;
  spacePlan: SpaceDataType | undefined;
};

export default function Surface(props: SurfaceProps) {
  const [items, setItems] = useState<{
    [key: string]: { top: number; left: number; type: string };
  }>({});

  const exportFunctionsMapRef = useRef<Map<string, Function | null>>(new Map());

  function exportPlan() {
    const plan = {
      ...props.spacePlan,
      items: Array.from(exportFunctionsMapRef.current.values())
        .filter((func) => func != null)
        .map((func) => func!()),
    };
    return plan;
  }

  // React DND
  const moveItems = useCallback(
    (id: string, left: number, top: number) => {
      setItems(
        update(items, {
          [id]: {
            $merge: { left, top },
          },
        })
      );
    },
    [items, setItems]
  );

  const [, drop] = useDrop(
    () => ({
      accept: [
        ItemTypes.TABLE,
        ItemTypes.CORNER,
        ItemTypes.STAGE,
        ItemTypes.BAR,
        ItemTypes.PLAN_IMAGE,
      ],
      drop(item: DragItem, monitor) {
        const delta = monitor.getDifferenceFromInitialOffset() as XYCoord;
        const left = Math.round(item.left + delta.x);
        const top = Math.round(item.top + delta.y);
        moveItems(item.id, left, top);
        return undefined;
      },
    }),
    [moveItems]
  );

  useEffect(() => {
    props.changeExportFunctionRef(exportPlan);
  }, [items, moveItems, setItems]);

  function unspawnItem(key: string) {
    if (items[key].type != ItemTypes.TABLE) return;
    setItems((i) => {
      const updatedItems = { ...i };
      delete updatedItems[key];
      return updatedItems;
    });
    exportFunctionsMapRef.current.delete(key);
  }

  useEffect(() => {
    props.spacePlan?.items.forEach((x) => {
      exportFunctionsMapRef.current.set(x.id, null);
      setItems((prevItems) => ({
        ...prevItems,
        [x.id]: { top: x.top, left: x.left, type: x.type },
      }));
    });
  }, [props.spacePlan]);

  return (
    <div
      // className="main-surface-container"
      ref={drop}
      style={{
        ...styles,
        textAlign: "center",
        zIndex: 1,
        height: props.spacePlan?.surfaceDimension.height,
        width: props.spacePlan?.surfaceDimension.width,
      }}
    >
      {items != null &&
        Object.keys(items).map((key) => {
          const { left, top, type } = items[key] as {
            top: number;
            left: number;
            type: string;
          };
          const item = props.spacePlan?.items.find((x) => x != undefined && x.id == key)!;
          if (item == undefined) return <></>;
          if (type == ItemTypes.TABLE) {
            return (
              <Table
                key={key}
                id={item.id}
                left={left}
                height={item.height}
                numberOfSeats={(item as TableInterface).numberOfSeats}
                top={top}
                onRemove={() => {
                  unspawnItem(item.id);
                }}
                exportFunctions={exportFunctionsMapRef.current}
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
                exportFunctions={exportFunctionsMapRef.current}
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
                exportFunctions={exportFunctionsMapRef.current}
              />
            );
          }
        })}
      <svg
        style={{
          height: props.spacePlan?.surfaceDimension.height,
          width: props.spacePlan?.surfaceDimension.width,
          zIndex: 2,
        }}
      >
        {props.spacePlan?.lines.map((line, index) => (
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
