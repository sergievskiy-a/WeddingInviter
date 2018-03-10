import { Event } from './../models/event';

export class WeddingInfo {
    id: number;
    title: string;
    hashtag: string;
    events: Event[];
}
