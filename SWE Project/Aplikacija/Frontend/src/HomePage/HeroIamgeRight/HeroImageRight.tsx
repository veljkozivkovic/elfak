import { Container, Title, Text, Button } from "@mantine/core";
import classes from "./HeroImageRight.module.css";
import { useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState } from "../../store/store";
import { useTranslation } from "react-i18next";

export function HeroImageRight() {
  const navigate = useNavigate();
  const { t } = useTranslation();
  const loggedUser = useSelector((state: RootState) => state.auth);

  return (
    <div className={classes.root}>
      <Container size="lg">
        <div className={classes.inner}>
          <div className={classes.content}>
            <Title className={classes.title}>
              <Text
                component="span"
                inherit
                variant="gradient"
                gradient={{ from: "pink", to: "yellow" }}
              >
                {t("Welcome1")}
              </Text>{" "}
              {t("Welcome2")}
            </Title>

            <Text
              className={classes.description}
              mt={30}
              style={{ color: "white" }}
            >
              {t("Welcome3")}
            </Text>

            <Button
              variant="gradient"
              gradient={{ from: "pink", to: "yellow" }}
              size="xl"
              className={classes.control}
              mt={40}
              onClick={(e) => {
                e.stopPropagation();
                if (loggedUser.userType == "Unregistered") navigate("/login");
                else
                  document
                    .querySelector(".main-ev-listing-div")
                    ?.scrollIntoView({ behavior: "smooth", block: "start" });
              }}
            >
              {t("StartExploring")}
            </Button>
          </div>
        </div>
      </Container>
    </div>
  );
}
