import { Carousel } from "@mantine/carousel";
import { useMediaQuery } from "@mantine/hooks";
import { useMantineTheme, rem, AspectRatio } from "@mantine/core";
import classes from "./HighlightsCarousel.module.css";
import { HighlightsCarouselProps } from "../interfaces";

export function HighlightsCarousel(props: HighlightsCarouselProps) {
  const theme = useMantineTheme();
  const mobile = useMediaQuery(`(max-width: ${theme.breakpoints.sm})`);
  const slides = props.highlightsUrls.map((item) => (
    <Carousel.Slide key={item.id}>
      <AspectRatio ratio={1080 / 720}>
        <iframe
          width="560"
          height="315"
          src={item.embedSrc}
          title="YouTube video player"
          allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
          referrerPolicy="strict-origin-when-cross-origin"
          allowFullScreen
        ></iframe>
      </AspectRatio>
    </Carousel.Slide>
  ));

  return (
    <Carousel
      slideSize={{ base: "100%", sm: "50%" }}
      slideGap={{ base: rem(2), sm: "xl" }}
      align="start"
      slidesToScroll={mobile ? 1 : 2}
      mb={60}
      className={classes.carousel}
    >
      {slides}
    </Carousel>
  );
}
