
import { inject, injectable } from 'inversify';
import { TaskData } from '../../../../data/data';
import { ITaskRepository } from '../../../data/repositories/ITaskRepository';
import { Types } from '../../../../types';
import { GetTasksByProjectIdAsyncQuery } from './GetTasksByProjectIdAsyncQuery';
import { AsyncQueryHandler } from '../../../../cqrs/handlers/queries/AsyncQueryHandler';

@injectable()
export class GetTasksByProjectIdAsyncQueryHandler implements AsyncQueryHandler<GetTasksByProjectIdAsyncQuery, TaskData[] | undefined> {

    constructor(@inject(Types.Repositories.TASK_REPOSITORY) private readonly taskRepository: ITaskRepository) { }

    async executeAsync(query: GetTasksByProjectIdAsyncQuery): Promise<TaskData[] | undefined> {
        return await this.taskRepository.getByProjectIdAsync(query.projectId);
    }
}