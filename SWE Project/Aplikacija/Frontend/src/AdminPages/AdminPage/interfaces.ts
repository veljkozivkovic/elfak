export interface EventBasic {
  id: number;
  name: string;
  date: Date;
  image: string;
}

export interface Comment {
  id: number;
  comment: string;
}

export interface UserWithBans {
  userId: string;
  banId: number;
  firstName: string;
  lastName: string;
  avatar: string;
  role: string;
  timeFrom: string;
  timeTo: string;
  reason: string;
}
