import { AsyncQuery } from '../../../../cqrs/executions/queries/AsyncQuery';
import { ProjectData } from '../../../../data/data';

export class GetCountryByNameAsyncQuery extends AsyncQuery<ProjectData> {

    constructor(public readonly countryName: string = '') {
        super();
    }
}