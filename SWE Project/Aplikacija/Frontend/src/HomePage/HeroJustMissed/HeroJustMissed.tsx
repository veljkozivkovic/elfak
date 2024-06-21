import { Title, Text, Button, Container } from "@mantine/core";
import { Dots } from "./Dots";
import classes from "./HeroJustMissed.module.css";
import { HighlightsCarousel } from "./HighlightsCarousel";
import { HeroJustMissedProps } from "../interfaces";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { RootState } from "../../store/store";
import { useTranslation } from "react-i18next";

export function HeroJustMissed(props: HeroJustMissedProps) {
  const navigate = useNavigate();
  const { t } = useTranslation();

  const loggedUser = useSelector((state: RootState) => state.auth);
  return (
    <Container className={`${classes.wrapper} trending-container`} size={1400}>
      <Dots className={classes.dots} style={{ left: 0, top: 0 }} />
      <Dots className={classes.dots} style={{ left: 60, top: 0 }} />
      <Dots className={classes.dots} style={{ left: 0, top: 140 }} />
      <Dots className={classes.dots} style={{ right: 0, top: 60 }} />

      <div className={classes.inner}>
        <Title className={classes.title} mb={60}>
          <Text
            component="span"
            inherit
            variant="gradient"
            gradient={{ from: "pink", to: "yellow" }}
          >
            {t("Highlights1")}
          </Text>
          <Text
            inherit
            variant="gradient"
            gradient={{ from: "pink", to: "yellow" }}
          >
            {t("Highlights2")}
          </Text>
        </Title>

        {props.isLoading || props.isError ? (
          <div className={classes.controls}>
            <div className={classes.ldsRing}>
              <div></div>
              <div></div>
              <div></div>
              <div></div>
            </div>
          </div>
        ) : (
          <HighlightsCarousel highlightsUrls={props.CarouselProps} />
        )}

        <div className={classes.controls}>
          <Button
            className={classes.control}
            size="lg"
            variant="default"
            color="gray"
            onClick={(e) => {
              e.stopPropagation();
              if (loggedUser.userType == "Unregistered") navigate("/login");
              else
                document.querySelector(".main-ev-listing-div")?.scrollIntoView({
                  behavior: "smooth",
                  block: "start",
                });
            }}
          >
            {t("StartExploring")}
          </Button>
          <Button
            variant="gradient"
            gradient={{ from: "pink", to: "yellow" }}
            className={classes.control}
            size="lg"
            onClick={(e) => {
              e.stopPropagation();
              if (loggedUser.userType == "Unregistered") navigate("/login");
              else
                document.querySelector(".main-ev-listing-div")?.scrollIntoView({
                  behavior: "smooth",
                  block: "start",
                });
            }}
          >
            {t("StartExploring")}
          </Button>
        </div>
      </div>
    </Container>
  );
}
