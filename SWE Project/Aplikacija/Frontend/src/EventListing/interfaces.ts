export interface Event {
  id: number;
  img: string;
  title: string;
  location: string;
  date: string;
  time: string;
  organizerID: number;
  organizer: string;
}

export interface EventCardProps {
  event: Event;
}
