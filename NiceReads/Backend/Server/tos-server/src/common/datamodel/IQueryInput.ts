import { IPaging } from './IPaging';
import { ISort } from './ISort';

export interface IQueryInput {
    paging: IPaging;
    sort: ISort;
}