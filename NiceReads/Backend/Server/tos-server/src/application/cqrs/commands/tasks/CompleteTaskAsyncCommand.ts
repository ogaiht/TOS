import { AsyncCommandWithResult } from '../../../../cqrs/executions/commands/AsyncCommandWithResult';
import { TaskData } from '../../../../data/data';

export class CompleteTaskAsyncCommand extends AsyncCommandWithResult<TaskData> {
    constructor(public readonly taskId: string) {
        super();
    }
}