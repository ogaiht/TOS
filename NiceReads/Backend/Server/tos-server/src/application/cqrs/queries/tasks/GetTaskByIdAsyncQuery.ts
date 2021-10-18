import { AsyncQuery } from '../../../../cqrs/executions/queries/AsyncQuery';
import { TaskData } from '../../../../data/data';

export class GetTaskByIdAsyncQuery extends AsyncQuery<TaskData | undefined> {

    constructor(public readonly taskId: string) {
        super();
    }
}
