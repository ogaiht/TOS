import { inject, injectable } from 'inversify';
import { AsyncQueryHandler } from '../../../../cqrs/handlers/queries/AsyncQueryHandler';
import { ProjectData } from '../../../../data/data';
import { IProjectRepository } from '../../../data/repositories/IProjectRepository';
import { GetProjectByIdAsyncQuery } from './GetProjectByIdAsyncQuery';

@injectable()
export class GetProjectByIdAsyncQueryHandler implements AsyncQueryHandler<GetProjectByIdAsyncQuery,  ProjectData | undefined> {

    constructor(@inject('IProjectRepository') private readonly projectRepository: IProjectRepository) { }

    async executeAsync(asyncQuery: GetProjectByIdAsyncQuery): Promise<ProjectData | undefined> {
        return await this.projectRepository.findAsync(asyncQuery.projectId);
    }
}