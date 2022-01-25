import { QueryInput } from '../../../common/datamodel/QueryInput';

export class EmployeeFilter extends QueryInput {
    constructor(
        public readonly nameContains: string = '',
        offset: number = -1,
        limit: number = -1,
        sortBy: string | undefined = undefined,
        sortDirection: SortDirection = SortDirection.ASC
    ) {
        super(offset, limit, sortBy, sortDirection);
    }
}