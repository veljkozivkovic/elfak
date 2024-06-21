import React, {
  CSSProperties,
  useCallback,
  useEffect,
  useRef,
  useState,
} from "react";
import { XYCoord, useDrop } from "react-dnd";
import { ItemTypes } from "./ItemTypes";
import { DragItem } from "./interfaces";
import update from "immutability-helper";
import { Table } from "./ToolbarItems/Table";
import { Corner } from "./ToolbarItems/Corner";
import { Stage } from "./ToolbarItems/Stage";
import { Bar } from "./ToolbarItems/Bar";
import { PlanImage } from "./ToolbarItems/PlanImage";

const styles: CSSProperties = {
  width: "90%",
  height: "70%",
  border: "1px solid black",
  borderRadius: "20px",
  backgroundColor: "white",
  position: "relative",
};

type SurfaceProps = {
  isCornerSelectedFromToolbar: boolean;
  isTableSelectedFromToolbar: boolean;
  isStageSelectedFromToolbar: boolean;
  isBarSelectedFromToolbar: boolean;
  planImage: File | null;
  changeExportFunctionRef: Function;
};

export default function Surface(props: SurfaceProps) {
  const [items, setItems] = useState<{
    [key: string]: { top: number; left: number; type: string };
  }>({});

  const [selectedCornersAsEndsForLine, setSelectedCornersAsEndsForLine] =
    useState<[HTMLElement | null, HTMLElement | null]>([null, null]);

  const [lines, setLines] = useState<
    {
      corner1: HTMLElement;
      corner2: HTMLElement;
      x1: number;
      y1: number;
      x2: number;
      y2: number;
    }[]
  >([]);

  const exportFunctionsMapRef = useRef<Map<string, Function | null>>(new Map());

  // Exporting plan as Žson
  function exportPlan() {
    const surfaceDiv = document.querySelector(".main-surface-container");
    const dims = surfaceDiv?.getBoundingClientRect();

    const plan = {
      surfaceDimension: {
        width: dims?.width,
        height: dims?.height,
      },
      items: Array.from(exportFunctionsMapRef.current.values())
        .filter((func) => func != null)
        .map((func) => func!()),
      lines: lines.map((line) => ({
        x1: line.x1,
        y1: line.y1,
        x2: line.x2,
        y2: line.y2,
      })),
      image: props.planImage,
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
  }, [items, lines, props.planImage, moveItems, setItems]);

  // Manipulating lines
  const rearrangeLines = () => {
    setLines((l) =>
      l.map((line) => ({
        ...line,
        x1: parseFloat(line.corner1.style.left),
        y1: parseFloat(line.corner1.style.top),
        x2: parseFloat(line.corner2.style.left),
        y2: parseFloat(line.corner2.style.top),
      }))
    );
  };

  useEffect(() => {
    rearrangeLines();
  }, [items]);

  useEffect(() => {
    if (
      selectedCornersAsEndsForLine[0] &&
      selectedCornersAsEndsForLine[1] &&
      selectedCornersAsEndsForLine[0] === selectedCornersAsEndsForLine[1]
    )
      setSelectedCornersAsEndsForLine([null, null]);
    else if (
      selectedCornersAsEndsForLine[0] &&
      selectedCornersAsEndsForLine[1] &&
      !lines.some(
        (l) =>
          (l.corner1 === selectedCornersAsEndsForLine[0] &&
            l.corner2 === selectedCornersAsEndsForLine[1]) ||
          (l.corner1 === selectedCornersAsEndsForLine[1] &&
            l.corner2 === selectedCornersAsEndsForLine[0])
      )
    ) {
      const [x1, y1] = [
        parseFloat(selectedCornersAsEndsForLine[0].style.left),
        parseFloat(selectedCornersAsEndsForLine[0].style.top),
      ];
      const [x2, y2] = [
        parseFloat(selectedCornersAsEndsForLine[1].style.left),
        parseFloat(selectedCornersAsEndsForLine[1].style.top),
      ];
      setLines((l) => [
        ...l,
        {
          corner1: selectedCornersAsEndsForLine[0]!,
          corner2: selectedCornersAsEndsForLine[1]!,
          x1,
          y1,
          x2,
          y2,
        },
      ]);
      setSelectedCornersAsEndsForLine([null, null]);
      return;
    } else if (
      selectedCornersAsEndsForLine[0] &&
      selectedCornersAsEndsForLine[1]
    ) {
      setSelectedCornersAsEndsForLine([null, null]);
      setLines((l) =>
        l.filter(
          (line) =>
            line.corner1 !== selectedCornersAsEndsForLine[0] &&
            line.corner1 !== selectedCornersAsEndsForLine[1] &&
            line.corner2 !== selectedCornersAsEndsForLine[1] &&
            line.corner2 !== selectedCornersAsEndsForLine[0]
        )
      );
    }
  }, [selectedCornersAsEndsForLine]);

  // Align corners
  function cornerAlign(id1: string, id2: string) {
    let updatedItem: any = null;
    if (
      Math.abs(items[id1].top - items[id2].top) <
      Math.abs(items[id1].left - items[id2].left)
    ) {
      updatedItem = {
        ...items[id1],
        top: items[id2].top,
      };
    } else {
      updatedItem = {
        ...items[id1],
        left: items[id2].left,
      };
    }

    setItems((prevItems) => ({
      ...prevItems,
      [id1]: updatedItem,
    }));
  }

  // Spawn/Unspawn Items
  function spawnNewItem(event: React.MouseEvent<HTMLDivElement, MouseEvent>) {
    if (
      props.isBarSelectedFromToolbar ||
      props.isCornerSelectedFromToolbar ||
      props.isStageSelectedFromToolbar ||
      props.isTableSelectedFromToolbar
    ) {
      const { x, y } = event.currentTarget.getBoundingClientRect();
      const newItem = {
        top: event.clientY - y,
        left: event.clientX - x,
        type: props.isBarSelectedFromToolbar
          ? ItemTypes.BAR
          : props.isCornerSelectedFromToolbar
          ? ItemTypes.CORNER
          : props.isStageSelectedFromToolbar
          ? ItemTypes.STAGE
          : ItemTypes.TABLE,
      };
      const newID: string = "ID" + Math.random().toString();
      exportFunctionsMapRef.current.set(newID, null);
      setItems({ ...items, [newID]: newItem });
    }
  }

  useEffect(() => {
    if (props.planImage == null) {
      const updatedItems = { ...items };
      Object.keys(updatedItems).forEach((key) => {
        if (updatedItems[key].type == "image") {
          delete updatedItems[key];
          exportFunctionsMapRef.current.delete(key);
        }
      });
      setItems(updatedItems);
    } else {
      const newImage = {
        top: 10,
        left: 10,
        type: ItemTypes.PLAN_IMAGE,
      };
      setItems({ ...items, ["ID" + Math.random().toString()]: newImage });
    }
  }, [props.planImage]);

  function unspawnItem(key: string) {
    const cornerForDeletion = document.getElementById(key);
    if (cornerForDeletion == selectedCornersAsEndsForLine[0])
      selectedCornersAsEndsForLine[0] = null;
    else if (cornerForDeletion == selectedCornersAsEndsForLine[1])
      selectedCornersAsEndsForLine[1] = null;
    setLines((l) =>
      l.filter(
        (line) =>
          line.corner1 != cornerForDeletion && line.corner2 != cornerForDeletion
      )
    );

    setItems((i) => {
      const updatedItems = { ...i };
      delete updatedItems[key];
      return updatedItems;
    });
    exportFunctionsMapRef.current.delete(key);
  }

  return (
    <div
      className="main-surface-container"
      ref={drop}
      style={{ ...styles, textAlign: "center", zIndex: 1 }}
      onClick={spawnNewItem}
    >
      {Object.keys(items).map((key) => {
        const { left, top, type } = items[key] as {
          top: number;
          left: number;
          type: string;
        };
        if (type == ItemTypes.TABLE) {
          return (
            <Table
              key={key}
              id={key}
              left={left}
              top={top}
              onRemove={() => {
                unspawnItem(key);
              }}
              exportFunctions={exportFunctionsMapRef.current}
            />
          );
        } else if (type == ItemTypes.CORNER) {
          return (
            <Corner
              key={key}
              id={key}
              left={left}
              top={top}
              selectCorner={setSelectedCornersAsEndsForLine}
              selectedCorners={selectedCornersAsEndsForLine}
              onRemove={() => {
                unspawnItem(key);
              }}
              alignMyselfWithOtherCorner={cornerAlign}
              exportFunctions={exportFunctionsMapRef.current}
            />
          );
        } else if (type == ItemTypes.STAGE) {
          return (
            <Stage
              key={key}
              id={key}
              left={left}
              top={top}
              onRemove={() => {
                unspawnItem(key);
              }}
              exportFunctions={exportFunctionsMapRef.current}
            />
          );
        } else if (type == ItemTypes.BAR) {
          return (
            <Bar
              key={key}
              id={key}
              left={left}
              top={top}
              onRemove={() => {
                unspawnItem(key);
              }}
              exportFunctions={exportFunctionsMapRef.current}
            />
          );
        } else if (type == ItemTypes.PLAN_IMAGE && props.planImage) {
          return (
            <PlanImage
              key={key}
              id={key}
              left={left}
              top={top}
              src={URL.createObjectURL(props.planImage!)}
              exportFunctions={exportFunctionsMapRef.current}
            />
          );
        }
      })}
      <svg style={{ width: "100%", height: "100%", zIndex: 2 }}>
        {lines.map((line, index) => (
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
