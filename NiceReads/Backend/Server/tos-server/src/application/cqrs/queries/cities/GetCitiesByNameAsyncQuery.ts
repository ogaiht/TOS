import { AsyncQuery } from '../../../../cqrs/executions/queries/AsyncQuery';
import { City } from '../../../models/City';

export class GetCitiesByNameAsyncQuery extends AsyncQuery<City[]> {

    constructor(public readonly cityName: string) {
        super();
    }
}