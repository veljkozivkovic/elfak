export interface Space {
  id: number;
  city: string;
  country: string;
  address: string;
  latitude: string;
  longitude: string;
  capacity: number;
}

export interface SpaceReservation {
  id: number;
  eventName: string;
  address: string;
  startTime: Date;
  endTime: Date;
  status: string;
}

export interface SpaceOwnerStatistics {
  rentableSpaces: number;
  totalRents: number;
}
