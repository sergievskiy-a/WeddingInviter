import { Guest } from './guest';

export class Invite {
    id: number;
    alias: string;
    eventId: number;
    customGreeting: string;
    description: string;
    guests: Guest[] = [];
}
