import { Location } from './location';

export class Event {
    id: number;
    weddingId: number;
    code: string;
    title: string;
    description: string;
    dateTime: Date;
    locationId: number;

    location: Location;
}
