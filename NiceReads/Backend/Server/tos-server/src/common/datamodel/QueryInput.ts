import { IPaging } from './IPaging';
import { IQueryInput } from './IQueryInput';
import { ISort } from './ISort';
import { Paging } from './Paging';

export class QueryInput implements IQueryInput {
    public paging: IPaging;
    public sort: ISort;

    constructor(
        offset:number = -1,
        limit: number = -1,
        sortBy: string | undefined = undefined,
        sortDirection: SortDirection = SortDirection.ASC
    ) {
        this.paging = new Paging(limit, offset);
    }
}