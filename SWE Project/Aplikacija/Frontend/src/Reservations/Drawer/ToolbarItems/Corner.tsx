import { useDrag } from "react-dnd";
import { ItemTypes } from "../ItemTypes";
import { CSSProperties, FC, useEffect } from "react";

interface CornerInterface {
  id: string;
  top: number;
  left: number;
  selectedCorners: [HTMLElement | null, HTMLElement | null];
  selectCorner: React.Dispatch<
    React.SetStateAction<[HTMLElement | null, HTMLElement | null]>
  >;
  onRemove: () => void;
  alignMyselfWithOtherCorner: (id1: string, id2: string) => void;
  exportFunctions: Map<string, Function | null>;
}

const CornerStyle: CSSProperties = {
  position: "absolute",
  width: "15px",
  height: "15px",
  border: "1px solid black",
  cursor: "move",
  margin: 0,
};

export const Corner: FC<CornerInterface> = ({
  id,
  top,
  left,
  selectedCorners,
  selectCorner,
  onRemove,
  alignMyselfWithOtherCorner,
  exportFunctions,
}) => {
  const [{ isDragging }, drag] = useDrag(
    () => ({
      type: ItemTypes.CORNER,
      item: { id, top, left },
      collect: (monitor) => ({
        isDragging: monitor.isDragging(),
      }),
    }),
    [id, top, left]
  );

  useEffect(() => {
    exportFunctions.set(id, null);
  }, []);

  if (isDragging) {
    return <div ref={drag}></div>;
  }

  function onClickCorner(event: React.MouseEvent<HTMLDivElement, MouseEvent>) {
    event.stopPropagation();
    if (
      event.shiftKey &&
      ((selectedCorners[0] && selectedCorners[0] != event.currentTarget) ||
        (selectedCorners[1] && selectedCorners[1] != event.currentTarget))
    ) {
      alignMyselfWithOtherCorner(
        id,
        selectedCorners[0] && selectedCorners[0] != event.currentTarget
          ? selectedCorners[0].id
          : selectedCorners[1]!.id
      );
    }
    selectCorner([
      selectedCorners[0] ? selectedCorners[0] : selectedCorners[1],
      event.currentTarget,
    ]);
  }

  return (
    <div
      id={id}
      ref={drag}
      style={{
        ...CornerStyle,
        top,
        left,
        backgroundColor:
          selectedCorners[0]?.id == id || selectedCorners[1]?.id == id
            ? "red"
            : "white",
      }}
      data-testid="corner"
      onClick={onClickCorner}
      onDoubleClick={(e) => {
        e.stopPropagation();
        onRemove();
      }}
    ></div>
  );
};
