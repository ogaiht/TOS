import { Uuid } from '../../../../common/uuid';
import { AsyncQuery } from '../../../../cqrs/executions/queries/async.query';
import { ProjectData } from '../../../../data/data';

export class GetProjectByIdAsyncQuery extends AsyncQuery<ProjectData | undefined> {

    constructor(public readonly projectId: Uuid) {
        super();
    }
}