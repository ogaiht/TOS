import { inject, injectable } from 'inversify';
import { ProjectData } from '../../../../data/data';
import { IProjectRepository } from '../../../data/repositories/IProjectRepository';
import { Types } from '../../../../types';
import { GetProjectByNameAsyncQuery } from './GetProjectByNameAsyncQuery';
import { AsyncQueryHandler } from '../../../../cqrs/handlers/queries/AsyncQueryHandler';

@injectable()
export class GetProjectByNameAsyncQueryHandler implements AsyncQueryHandler<GetProjectByNameAsyncQuery, ProjectData[]> {

    constructor(@inject(Types.Repositories.PROJECT_REPOSITORY) private readonly projectRepository: IProjectRepository) { }

    async executeAsync(query: GetProjectByNameAsyncQuery): Promise<ProjectData[]> {
        return await this.projectRepository.getProjectsByNameAsync(query.projectName);
    }
}