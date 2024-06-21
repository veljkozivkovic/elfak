import { Image, Accordion, Grid, Container, Title, Flex } from "@mantine/core";
import image from "../assets/faq.svg";
import classes from "./Faq.module.css";
import { HeaderMegaMenu } from "../HomePage/HeaderMegaMenu/HeaderMegaMenu";
import { Footer } from "../HomePage/Footer/Footer";
import EventBgImage from "../assets/event_listing_bg_op.png";
import { useTranslation } from "react-i18next";

const faqs = [
  {
    value: "Q1Val",
    question: "Q1Q",
    answer: "Q1A",
  },
  {
    value: "Q2Val",
    question: "Q2Q",
    answer: "Q2A",
  },
  {
    value: "Q3Val",
    question: "Q3Q",
    answer: "Q3A",
  },
  {
    value: "Q4Val",
    question: "Q4Q",
    answer: "Q4A",
  },
  {
    value: "Q5Val",
    question: "Q5Q",
    answer: "Q5A",
  },
  {
    value: "Q6Val",
    question: "Q6Q",
    answer: "Q6A",
  },
  {
    value: "Q7Val",
    question: "Q7Q",
    answer: "Q7A",
  },
];

export function Faq() {
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
      <div className={classes.wrapper} style={{ flex: 1 }}>
        <Container size="lg">
          <Grid id="faq-grid" gutter={50}>
            <Grid.Col span={{ base: 12, md: 6 }}>
              <Image src={image} alt="Frequently Asked Questions" />
            </Grid.Col>
            <Grid.Col span={{ base: 12, md: 6 }}>
              <Title order={2} ta="left" className={classes.title}>
                {t("Faqs")}
              </Title>

              <Accordion
                chevronPosition="right"
                defaultValue="reset-password"
                variant="separated"
              >
                {faqs.map((faq, idx) => (
                  <Accordion.Item
                    className={classes.item}
                    value={t(faq.value)}
                    key={idx}
                  >
                    <Accordion.Control>{t(faq.question)}</Accordion.Control>
                    <Accordion.Panel>{t(faq.answer)}</Accordion.Panel>
                  </Accordion.Item>
                ))}
              </Accordion>
            </Grid.Col>
          </Grid>
        </Container>
      </div>
      <Footer />
    </Flex>
  );
}
