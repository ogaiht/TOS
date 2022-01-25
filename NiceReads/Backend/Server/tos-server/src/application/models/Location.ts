import { City } from './City';

export class Location {
    constructor(
        public address: string = '',
        public city: City | undefined = undefined) {
    }
}