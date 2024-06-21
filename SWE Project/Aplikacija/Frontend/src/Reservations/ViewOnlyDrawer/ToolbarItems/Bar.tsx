import { CSSProperties, FC } from "react";
import BarImage from "../../../assets/bar.png";

interface StageInterface {
  id: string;
  top: number;
  left: number;
  height: number;
}

const StageStyle: CSSProperties = {
  position: "absolute",
  cursor: "move",
  margin: 0,
};

export const Bar: FC<StageInterface> = ({ id, top, left, height }) => {
  return (
    <>
      <img
        src={BarImage}
        alt="BAR"
        id={id}
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
      />
    </>
  );
};
