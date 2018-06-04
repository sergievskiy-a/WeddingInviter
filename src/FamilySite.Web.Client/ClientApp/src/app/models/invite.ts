import { Guest } from './guest';
import { InviteAnswer } from './inviteAnswer';

export class Invite {
    id: number;
    alias: string;
    eventId: number;
    customGreeting: string;
    description: string;
    suggestHotel: boolean;
    guests: Guest[] = [];
    inviteAnswer: InviteAnswer;
}
