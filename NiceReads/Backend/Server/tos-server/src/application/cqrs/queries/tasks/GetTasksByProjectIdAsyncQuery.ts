
import { Uuid } from '../../../../common/uuid';
import { AsyncQuery } from '../../../../cqrs/executions/queries/AsyncQuery';
import { TaskData } from '../../../../data/data';

export class GetTasksByProjectIdAsyncQuery extends AsyncQuery<TaskData[] | undefined> {
    constructor(public readonly projectId: Uuid) {
        super();
    }
}
