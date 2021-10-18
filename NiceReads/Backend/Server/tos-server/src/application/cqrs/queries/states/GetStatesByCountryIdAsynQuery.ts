import { Uuid } from '../../../../common/uuid';
import { AsyncQuery } from '../../../../cqrs/executions/queries/async.query';
import { State } from '../../../models/State';

export class GetStatesByCountryIdAsyncQuery extends AsyncQuery<State[]> {

    constructor(public readonly countryId: Uuid) {
        super();
    }
}