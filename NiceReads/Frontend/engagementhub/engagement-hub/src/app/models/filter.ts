export interface Pagination {
    offset?: number;
    limit?: number;
}

export enum SortDirection {
    ASC = 'asc',
    DESC = 'desc'
}

export interface Sorting {
    sortBy?: any
}

export interface PagedResult<TResult> {
    items: TResult[];
    offset: number;
    limit: number;
    total: number;
}

export const DEFAULT_PAGED_RESULT = {
    items: [],
    offset: -1,
    limit: -1,
    total: -1,
};