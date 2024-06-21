import { Flex } from "@mantine/core";
import { useEffect } from "react";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { Footer } from "../HomePage/Footer/Footer";
import { HeaderMegaMenu } from "../HomePage/HeaderMegaMenu/HeaderMegaMenu";
import { RootState } from "../store/store";
import classes from "./AdminPage/AdminPage.module.css";
import AdminPage from "./AdminPage/AdminPage";

export default function AdminPageContainer() {
  const loggedUser = useSelector((state: RootState) => state.auth);
  const navigate = useNavigate();

  useEffect(() => {
    if (loggedUser.userType != "Admin") navigate("/");
  }, []);

  return (
    <Flex className={classes.mainMain}>
      <HeaderMegaMenu />
      <AdminPage/>
      <Footer />
    </Flex>
  );
}
