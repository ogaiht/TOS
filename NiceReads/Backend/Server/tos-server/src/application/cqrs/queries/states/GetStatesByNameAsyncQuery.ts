import { AsyncQuery } from '../../../../cqrs/executions/queries/AsyncQuery';
import { State } from '../../../models/State';

export class GetStatesByNameAsyncQuery extends AsyncQuery<State[]> {
    constructor(public readonly stateName: string) {
        super();
    }
}