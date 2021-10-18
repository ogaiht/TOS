import { Uuid } from '../../../../common/uuid';
import { AsyncQuery } from '../../../../cqrs/executions/queries/AsyncQuery';
import { City } from '../../../models/City';

export class GetCitiesByStateIdAsyncQuery extends AsyncQuery<City[]> {

    constructor(public readonly stateId: Uuid) {
        super();
    }
}