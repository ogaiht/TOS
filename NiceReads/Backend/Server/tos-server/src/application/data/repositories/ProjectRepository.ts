import { inject, injectable } from 'inversify';
import { constr } from '../../../common/common.types';
import { Uuid } from '../../../common/uuid';
import { IDatabase } from '../../../database/database';
import { Types } from '../../../types';
import { ProjectData } from '../../../data/data';
import { Repository } from '../../../data/repository';
import { IProjectRepository } from './IProjectRepository';

@injectable()
export class ProjectRepository extends Repository<ProjectData, Uuid> implements IProjectRepository {

    constructor(@inject(Types.DATABASE) database: IDatabase<Uuid>) {
        super(database);
        console.log('Database at ProjectRepository: ', database);
    }

    protected getEntityType(): constr<ProjectData> {
        return ProjectData;
    }

    async getProjectsByNameAsync(name: string): Promise<ProjectData[]> {
        const projects: ProjectData[] = await this.database.getCollection(ProjectData).findAsync((p: ProjectData) => p.name === name);
        return projects;
    }
}