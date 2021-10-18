import { inject, injectable } from 'inversify';
import { constr } from '../../../common/common.types';
import { Uuid } from '../../../common/uuid';
import { IDatabase } from '../../../database/database';
import { Types } from '../../../types';
import { TaskData } from '../../../data/data';
import { Repository } from '../../../data/repository';
import { ITaskRepository } from './ITaskRepository';

@injectable()
export class TaskRepository extends Repository<TaskData, Uuid> implements ITaskRepository {
    constructor(@inject(Types.DATABASE) database: IDatabase<Uuid>) {
        super(database);
    }

    protected getEntityType(): constr<TaskData> {
        return TaskData;
    }

    async getByProjectIdAsync(projectId: Uuid): Promise<TaskData[] | undefined> {
        return this.database.getCollection(TaskData).findAsync((t: TaskData) => t.projectId === projectId);
    }
}