import { inject, injectable } from 'inversify';
import { Uuid } from '../../../../common/uuid';
import { AsyncCommandWithResultHandler } from '../../../../cqrs/handlers/commands/AsyncCommandWithResultHandler';
import { TaskData } from '../../../../data/data';
import { ITaskRepository } from '../../../data/repositories/ITaskRepository';
import { CompleteTaskAsyncCommand } from './CompleteTaskAsyncCommand';

@injectable()
export class CompleteTaskAsyncCommandHandler implements AsyncCommandWithResultHandler<CompleteTaskAsyncCommand, TaskData> {

    constructor(@inject('ITaskRepository') private readonly taskRepository: ITaskRepository) { }

    async executeAsync(asyncCommand: CompleteTaskAsyncCommand): Promise<TaskData> {
        const task: TaskData | undefined = await this.taskRepository.findAsync(Uuid.fromString(asyncCommand.taskId));
        if (!task) {
            throw new Error(`Task not found for id '${asyncCommand.taskId}'.`);
        }
        if (task.completed === true) {
            throw new Error(`Task with id '${asyncCommand.taskId}' is already completed.`);
        }
        task.completed = true;
        await this.taskRepository.updateAsync(task);
        return task;
    }
}