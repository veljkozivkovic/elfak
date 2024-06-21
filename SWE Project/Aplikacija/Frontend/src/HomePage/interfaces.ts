export interface HighLight {
  id: string;
  embedSrc: string;
}

export interface HighlightsCarouselProps {
  highlightsUrls: HighLight[];
}

export interface HeroJustMissedProps {
  isLoading: boolean;
  isError: boolean;
  CarouselProps: HighLight[];
}
