import { Uuid } from '../../../../common/uuid';
import { AsyncQuery } from '../../../../cqrs/executions/queries/AsyncQuery';
import { State } from '../../../models/State';

export class GetStatesByCountryIdAsyncQuery extends AsyncQuery<State[]> {

    constructor(public readonly countryId: Uuid) {
        super();
    }
}