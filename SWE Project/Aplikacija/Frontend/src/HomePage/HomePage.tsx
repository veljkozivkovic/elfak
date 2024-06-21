import { useQuery } from "@tanstack/react-query";
import { HeaderMegaMenu } from "./HeaderMegaMenu/HeaderMegaMenu";
import { HeroImageRight } from "./HeroIamgeRight/HeroImageRight";
import { HeroJustMissed } from "./HeroJustMissed/HeroJustMissed";
import axios from "../../axiosconfig.ts";
import EventListing from "../EventListing/EventListing";
import { Footer } from "./Footer/Footer";
import RecommendedEventListing from "../EventListing/RecommendedEventListing.tsx";
import { useSelector } from "react-redux";
import { RootState } from "../store/store.ts";

export default function HomePage() {
  const loggedUser = useSelector((state: RootState) => state.auth);

  const { isLoading, data, isError } = useQuery({
    queryKey: ["highlights"],
    queryFn: async () => {
      return await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/HomePage/getHighlights`)
        .then((resp) => {
          return resp.data;
        })
        .catch((err) => {
          console.error(err);
          return [];
        });
    },
  });

  return (
    <>
      <HeaderMegaMenu />
      <HeroImageRight />
      <HeroJustMissed
        isLoading={isLoading}
        isError={isError}
        CarouselProps={data}
      />
      <EventListing />
      {loggedUser.userType == "Visitor" && <RecommendedEventListing />}
      <Footer />
    </>
  );
}
