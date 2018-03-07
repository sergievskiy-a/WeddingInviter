import { Guest } from './guest';

export interface Invite {
    id: number;
    alias: string;
    description: string;
    guests: Guest[];
}
