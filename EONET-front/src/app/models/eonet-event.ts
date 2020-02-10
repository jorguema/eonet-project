import { Category } from './categoy';

export interface EonetEvent {
    id: string;
    title: string;
    description: string;
    link: string;
    status: number;
    categories: Category[]
}
