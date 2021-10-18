import { Uuid } from '../../../common/uuid';
import { TaskData } from '../../../data/data';
import { IRepository, Repository } from '../../../data/repository';

export interface ITaskRepository extends IRepository<TaskData, Uuid> {
    getByProjectIdAsync(projectId: Uuid): Promise<TaskData[] | undefined>;
}