import { AsyncQuery } from '../../../../cqrs/executions/queries/AsyncQuery';
import { ProjectData } from '../../../../data/data';

export class GetProjectByNameAsyncQuery extends AsyncQuery<ProjectData[]> {

    constructor(public readonly projectName: string) {
        super();
    }
}