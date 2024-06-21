import {
  Image,
  Container,
  Title,
  Text,
  Button,
  SimpleGrid,
  Flex,
} from "@mantine/core";
import classes from "./Page404.module.css";
import image from "../assets/pagenotfound.svg";
import EventBgImage from "../assets/event_listing_bg_op.png";
import { HeaderMegaMenu } from "../HomePage/HeaderMegaMenu/HeaderMegaMenu";
import { Footer } from "../HomePage/Footer/Footer";
import { useTranslation } from "react-i18next";

export function Page404() {
  const { t } = useTranslation();
  return (
    <Flex
      h="100vh"
      direction="column"
      styles={{
        root: {
          backgroundImage: `url(${EventBgImage})`,
        },
      }}
    >
      <HeaderMegaMenu />
      <Container
        className={classes.root}
        flex={1}
        style={{ display: "flex", alignItems: "center" }}
      >
        <SimpleGrid spacing={{ base: 40, sm: 80 }} cols={{ base: 1, sm: 2 }}>
          <Image src={image} className={classes.mobileImage} />
          <div>
            <Title className={classes.title}>{t("Page404")}</Title>
            <Text c="dimmed" size="lg">
              {t("Page404Expl")}
            </Text>
            <Button
              variant="outline"
              size="md"
              mt="xl"
              className={classes.control}
            >
              {t("Page404GoBack")}
            </Button>
          </div>
        </SimpleGrid>
      </Container>
      <Footer />
    </Flex>
  );
}
