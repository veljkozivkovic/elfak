import { CSSProperties, FC, useEffect } from "react";
import { ItemTypes } from "../ItemTypes";
import { useDrag } from "react-dnd";
import StageImage from "../../../assets/stage.png";

interface StageInterface {
  id: string;
  top: number;
  left: number;
  height: number;
  exportFunctions: Map<string, Function | null>;
}

const StageStyle: CSSProperties = {
  position: "absolute",
  cursor: "move",
  margin: 0,
};

export const Stage: FC<StageInterface> = ({
  id,
  top,
  left,
  height,
  exportFunctions,
}) => {
  const [{ isDragging }, drag] = useDrag(
    () => ({
      type: ItemTypes.STAGE,
      item: { id, top, left },
      collect: (monitor) => ({
        isDragging: monitor.isDragging(),
      }),
    }),
    [id, top, left]
  );

  function exportAsJSON() {
    return {
      type: ItemTypes.STAGE,
      id: id,
      top: top,
      left: left,
      height: height,
      heightFactor: 0.8,
    };
  }
  useEffect(() => {
    exportFunctions.set(id, exportAsJSON);
  }, [top, left]);

  if (isDragging) {
    return <div ref={drag}></div>;
  }

  return (
    <>
      <img
        src={StageImage}
        alt="STAGE"
        id={id}
        ref={drag}
        style={{
          ...StageStyle,
          top,
          left,
          maxHeight: "80%",
          height: `${0.8 * height}%`,
        }}
        data-testid="stage"
        onClick={(e) => {
          e.stopPropagation();
        }}
      />{" "}
    </>
  );
};
