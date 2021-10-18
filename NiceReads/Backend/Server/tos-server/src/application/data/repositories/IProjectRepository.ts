import { Uuid } from '../../../common/uuid';
import { ProjectData } from '../../../data/data';
import { IRepository } from '../../../data/repository';

export interface IProjectRepository extends IRepository<ProjectData, Uuid> {
    getProjectsByNameAsync(name: string): Promise<ProjectData[]>;
}
