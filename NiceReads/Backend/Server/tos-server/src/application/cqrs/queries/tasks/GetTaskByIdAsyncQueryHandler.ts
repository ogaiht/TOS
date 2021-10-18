import { inject, injectable } from 'inversify';
import { Uuid } from '../../../../common/uuid';
import { TaskData } from '../../../../data/data';
import { ITaskRepository } from '../../../data/repositories/ITaskRepository';
import { Types } from '../../../../types';
import { GetTaskByIdAsyncQuery } from './GetTaskByIdAsyncQuery';
import { AsyncQueryHandler } from '../../../../cqrs/handlers/queries/AsyncQueryHandler';

@injectable()
export class GetTaskByIdAsyncQueryHandler implements AsyncQueryHandler<GetTaskByIdAsyncQuery, TaskData | undefined> {

    constructor(@inject(Types.Repositories.TASK_REPOSITORY) private readonly taskRepository: ITaskRepository) { }

    async executeAsync(asyncQuery: GetTaskByIdAsyncQuery): Promise<TaskData | undefined> {
        const taskId: Uuid = Uuid.fromString(asyncQuery.taskId);
        return await this.taskRepository.findAsync(taskId);
    }
}