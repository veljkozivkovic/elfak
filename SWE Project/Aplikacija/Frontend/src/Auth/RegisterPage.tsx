import { Flex } from "@mantine/core";
import { Footer } from "../HomePage/Footer/Footer";
import { HeaderMegaMenu } from "../HomePage/HeaderMegaMenu/HeaderMegaMenu";
import classes from "./RegisterPage.module.css";
import { RegisterPage1 } from "./RegisterPage1";

export default function RegisterPage() {
  return (
    <>
      <HeaderMegaMenu />

      <Flex
        h="100%"
        w="100%"
        align="center"
        justify="center"
        flex={1}
        className={classes.wrapper}
      >
        <RegisterPage1 />
      </Flex>

      <Footer />
    </>
  );
}
