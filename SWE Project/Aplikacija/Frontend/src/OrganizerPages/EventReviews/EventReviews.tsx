import { Button, Flex, Group, Title } from "@mantine/core";
import classes from "./EventReviews.module.css";
import EventBgImage from "../../assets/event_listing_bg_op.png";
import { Comment } from "./Comment";
import View from "../EventViewPages";
import axios from "../../../axiosconfig.ts"
import { Review } from "../interfaces";
import { useQuery } from "@tanstack/react-query";
import { t } from "i18next";

export interface EventReviewsProps {
  eventId: number;
  eventName: string;
  eventDate: string;
  showEvent: React.Dispatch<React.SetStateAction<View>>;
}

export default function EventReviews(props: EventReviewsProps) {

  const {
    isLoading: areReviewsLoading,
    data: reviews,
    isError: reviewsError,
  } = useQuery<Review[]>({
    queryKey: ["event_reviews"],
    queryFn: async () => {
      return await axios
        .get(`${import.meta.env.VITE_DB_SERVER}/Host/getReviewsForEvent/${props.eventId}`)
        .then((resp) => {
          return resp.data;
        })
        .catch((err) => {
          console.error(err);
          if (
            Array.isArray(err.response.data) &&
            err.response.data.length > 0
          ) {
            alert(err.response.data[0].description);
          } else {
            alert(err.response.data);
          }
          return [];
        });
    },
  });

  return (
    <Flex
      className={classes.mainContentFlex}
      styles={{
        root: {
          backgroundImage: `url(${EventBgImage})`,
          backgroundRepeat: "repeat",
        },
      }}
    >
      <Group style={{ width: "100%" }}>
        <Button
          onClick={(event) => {
            event.stopPropagation();
            props.showEvent(View.Basic);
          }}
        >
          {t("GoBack")}
        </Button>
        <Title c="#5a5959">{props.eventName} - {props.eventDate}</Title>
      </Group>

      <Flex mt={20} wrap="wrap" rowGap="20">
      {(areReviewsLoading || reviewsError) ? (
            <div className={classes.controls}>
              <div className={classes.ldsRing}>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
              </div>
            </div>
      ) :
      (reviews?.map((review, idx) => (
          <Comment key={idx} review={review}/>
      )))}
      </Flex>
    </Flex>
  );
}
