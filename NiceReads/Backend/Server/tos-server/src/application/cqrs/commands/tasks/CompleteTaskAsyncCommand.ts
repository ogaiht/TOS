import { AsyncCommandWithResult } from '../../../../cqrs/executions/commands/async.command';
import { TaskData } from '../../../../data/data';

export class CompleteTaskAsyncCommand extends AsyncCommandWithResult<TaskData> {
    constructor(public readonly taskId: string) {
        super();
    }
}