import { IPaging } from './IPaging';

export class Paging implements IPaging {
    constructor(
        public limit: number = -1,
        public offset: number = -1
    ) { }
}