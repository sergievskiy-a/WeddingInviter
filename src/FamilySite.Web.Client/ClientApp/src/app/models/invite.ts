import { Guest } from './guest';

export class Invite {
    id: number;
    alias: string;
    description: string;
    guests: Guest[] = [];
}
