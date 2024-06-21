import {
  Paper,
  TextInput,
  PasswordInput,
  Button,
  Title,
  Text,
  Anchor,
} from "@mantine/core";
import classes from "./LoginPage.module.css";
import { HeaderMegaMenu } from "../HomePage/HeaderMegaMenu/HeaderMegaMenu";
import { Footer } from "../HomePage/Footer/Footer";
import { useNavigate } from "react-router-dom";
import { useForm } from "@mantine/form";
import { useDispatch } from "react-redux";
import { login } from "../store/features/auth";
import axios from "../../axiosconfig.ts";
import { useTranslation } from "react-i18next";

export function LoginPage() {
  const { t } = useTranslation();

  const loginForm = useForm({
    mode: "controlled",
    initialValues: { email: "", password: "" },

    validate: {
      email: (value) => (/^\S+@\S+$/.test(value) ? null : t("InvalidEmail")),
      password: (value) => (value.length > 0 ? null : t("EmptyPassword")),
    },
  });

  const dispatch = useDispatch();

  const navigate = useNavigate();
  return (
    <>
      <HeaderMegaMenu />
      <div className={classes.wrapper}>
        <Paper className={classes.form} radius={0} p={30}>
          <>
            <Title
              order={2}
              className={classes.title}
              ta="center"
              mt="md"
              mb={50}
            >
              {t("WelcomeBack")}
            </Title>

            <form
              onSubmit={loginForm.onSubmit(async (values, event) => {
                event?.stopPropagation();
                if (loginForm.validate().hasErrors) {
                  return;
                }
                await axios
                  .post(`${import.meta.env.VITE_DB_SERVER}/Account/login`, {
                    email: values.email,
                    password: values.password,
                  })
                  .then((resp) => {
                    const obj = JSON.parse(atob(resp.data.token.split(".")[1]));
                    dispatch(
                      login({
                        userId: obj["nameid"],
                        token: resp.data.token,
                        email: obj["email"],
                        userType: obj["role"],

                        firstName: resp.data.firstName,
                        lastName: resp.data.lastName,
                        birthday: resp.data.dateOfBirth,
                        phoneNumber: resp.data.phoneNumber,
                        avatar: resp.data.avatar,
                        address: resp.data.address,
                        city: resp.data.city,
                      })
                    );
                    navigate("/");
                  })
                  .catch((err) => {
                    if (
                      Array.isArray(err.response.data) &&
                      err.response.data.length > 0
                    ) {
                      alert(err.response.data[0].description);
                    } else {
                      alert(err.response.data);
                    }
                    console.error(err);
                  });
              })}
            >
              <TextInput
                label={t("Email")}
                placeholder={t("EmailP")}
                size="md"
                key={loginForm.key("email")}
                {...loginForm.getInputProps("email")}
              />
              <PasswordInput
                label={t("Password")}
                placeholder={t("PasswordP")}
                mt="md"
                size="md"
                key={loginForm.key("password")}
                {...loginForm.getInputProps("password")}
              />
              <Button
                type="submit"
                fullWidth
                mt="xl"
                size="md"
                onClick={() => {}}
              >
                {t("Login")}
              </Button>
            </form>

            <Text ta="center" mt="md">
              {t("DontHaveAccount")}{" "}
              <Anchor<"a">
                href="#"
                fw={700}
                onClick={(event) => {
                  event.preventDefault();
                  navigate("/register");
                }}
              >
                {t("Signup")}
              </Anchor>
            </Text>
          </>
        </Paper>
      </div>
      <Footer />
    </>
  );
}
