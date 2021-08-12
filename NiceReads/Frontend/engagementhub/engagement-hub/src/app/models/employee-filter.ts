import { Pagination } from './filter';

export interface EmployeeFilter extends Pagination {
    cities?: string[],
    roles?: string[]
    name?: string
}