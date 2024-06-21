import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { Footer } from "../HomePage/Footer/Footer";
import { HeaderMegaMenu } from "../HomePage/HeaderMegaMenu/HeaderMegaMenu";
import { RootState } from "../store/store";
import UserProfile from "./UserProfile";
import { Flex } from "@mantine/core";
import classes from "./UserProfile.module.css";

export default function VisitorProfileContainer() {
  const loggedUser = useSelector((state: RootState) => state.auth);
  const navigate = useNavigate();

  useEffect(() => {
    if (loggedUser.userType != "Visitor") navigate("/");
  }, []);

  return (
    <Flex className={classes.mainMain}>
      <HeaderMegaMenu />
      <UserProfile user={loggedUser} />
      <Footer />
    </Flex>
  );
}
