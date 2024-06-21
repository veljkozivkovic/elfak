import { Fieldset, Flex, Stack, TextInput } from "@mantine/core";
import { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { Footer } from "../HomePage/Footer/Footer";
import { HeaderMegaMenu } from "../HomePage/HeaderMegaMenu/HeaderMegaMenu";
import { RootState } from "../store/store";
import SpaceOwnerPage from "./SpaceOwnerPage/SpaceOwnerPage";
import classes from "./SpaceOwnerPage/SpaceOwnerPage.module.css";
import View from "./SpaceViewPages";
import Drawer from "../Reservations/Drawer/Drawer";
import axios from "../../axiosconfig.ts";
import MapWithInput from "../Auth/Utils/MapInput";
import { LatLng } from "leaflet";
import { useTranslation } from "react-i18next";

export default function SpaceOwnerPageContainer() {
  const [position, setPosition] = useState<LatLng>(new LatLng(44.787197, 20.457273));
  const [city, setCity] = useState<string>("");
  const [country, setCountry] = useState<string>("");
  const [address, setAddress] = useState<string>("");
  const { t } = useTranslation();
  const loggedUser = useSelector((state: RootState) => state.auth);
  const navigate = useNavigate();

  const [view, setView] = useState<View>(View.Basic);

  useEffect(() => {
    if (loggedUser.userType != "Space owner") navigate("/");
  }, []);

  return (
    <Flex
      className={classes.mainMain}
      style={{ height: view == View.Basic ? "100vh" : "unset" }}
    >
      <HeaderMegaMenu />
      {view == View.Basic && (
        <SpaceOwnerPage showSpace={setView} user={loggedUser} />
      )}
      {view == View.NewSpace && (
        <Flex direction="column" justify="center" align="center">
          <Drawer
            onSubmit={async (spaceObject: any) => {
              if (city == "") {
                alert(t("EmptyCityField"));
                return;
              }
              if (country == "") {
                alert(t("EmptyCountryField"));
                return;
              }
              if (address == "") {
                alert(t("EmptyAddressField"));
                return;
              }

              spaceObject["city"] = city;
              spaceObject["country"] = country;
              spaceObject["address"] = address;
              spaceObject["latitude"] = position.lat;
              spaceObject["longitude"] = position.lng;

              await axios
                .post(`${import.meta.env.VITE_DB_SERVER}/Space/addSpace`, spaceObject)
                .then((_) => setView(View.Basic))
                .catch((err) => {
                  console.error(err);
                  if (Array.isArray(err.response.data) && err.response.data.length > 0) {
                    alert(err.response.data[0].description);
                  }
                  else {
                    alert(err.response.data);
                  }
                });
            }}
            onCancel={() => setView(View.Basic)}
          />
          <Fieldset
            legend={t("BasicInformation")}
            w="50%"
            h="fit-content"
            fz="xl"
            styles={{
              root: {
                display: "flex",
                justifyContent: "space-between",
                gap: "10px",
              },
            }}
            mb={10}
          >
            <Stack w="50%" justify="center">
              <TextInput
                value={city}
                onChange={(event) => setCity(event.currentTarget.value)}
                required
                label={t("City")}
              ></TextInput>
              <TextInput
                value={country}
                onChange={(event) => setCountry(event.currentTarget.value)}
                required
                label={t("Country")}
              ></TextInput>
              <TextInput
                value={address}
                onChange={(event) => setAddress(event.currentTarget.value)}
                required
                label={t("Address")}
              ></TextInput>
            </Stack>
            <Stack w="50%" justify="center">
              <TextInput
                required
                label={t("SelectLocationAddress")}
                disabled={true}
                value={`${position.lat} ${position.lng}`}
              ></TextInput>
              <MapWithInput position={position} setPosition={setPosition} />
            </Stack>
          </Fieldset>
        </Flex>
      )}
      <Footer />
    </Flex>
  );
}
