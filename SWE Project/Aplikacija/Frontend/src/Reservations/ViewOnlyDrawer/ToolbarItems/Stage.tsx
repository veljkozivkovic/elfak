import { CSSProperties, FC } from "react";

import StageImage from "../../../assets/stage.png";

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

export const Stage: FC<StageInterface> = ({ id, top, left, height }) => {
  return (
    <>
      <img
        src={StageImage}
        alt="STAGE"
        id={id}
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
