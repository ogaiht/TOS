import { Uuid } from '../../../../common/uuid';
import { AsyncQuery } from '../../../../cqrs/executions/queries/AsyncQuery';
import { State } from '../../../models/State';

export class GetStateByIdAsyncQuery extends AsyncQuery<State | undefined> {
    constructor(public readonly stateId: Uuid) {
        super();
    }
}