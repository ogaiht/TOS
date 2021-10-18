import { Query, Resolver, Mutation, Arg, Root, FieldResolver } from 'type-graphql'
import { CreateProjectCommand } from '../cqrs/commands/projects/CreateProjectCommand';
import { GetProjectByNameAsyncQuery } from '../cqrs/queries/projects/GetProjectByNameAsyncQuery';
import { GetTasksByProjectIdAsyncQuery } from '../cqrs/queries/tasks/GetTasksByProjectIdAsyncQuery';
import container from '../../configuration/ContainerConfig';
import { ICommandDispatcher } from '../../cqrs/dispatchers/commands/ICommandDispatcher';
import { IQueryDispatcher } from '../../cqrs/dispatchers/queries/IQueryDispatcher';
import { ProjectData, TaskData } from '../../data/data';
import { AddProjectInput } from '../schemas/add-project-input';
import { Project } from '../schemas/project'
import { Types } from '../../types';

@Resolver(Project)
export class ProjectResolver {

    private readonly commandDispatcher: ICommandDispatcher;
    private readonly queryDispatcher: IQueryDispatcher;

    constructor() {
            this.commandDispatcher = container.get<ICommandDispatcher>(Types.COMMAND_DISPATCHER);
            this.queryDispatcher = container.get<IQueryDispatcher>(Types.QUERY_DISPATCHER);
    }

    @Mutation(returns => Project)
    addProject(@Arg('project') newProject: AddProjectInput): ProjectData {
        return this.commandDispatcher.executeWithResult(new CreateProjectCommand(newProject));
    }

    @Query(returns => [Project], { nullable: true})
    async projectByName(@Arg('name') name: string): Promise<ProjectData[]> {
        return await this.queryDispatcher.executeAsync(new GetProjectByNameAsyncQuery(name));
    }

    @FieldResolver()
    async tasks(@Root() projectData: ProjectData): Promise<TaskData[] | undefined> {
        return await this.queryDispatcher.executeAsync(new GetTasksByProjectIdAsyncQuery(projectData.id));
    }

    @FieldResolver()
    id(@Root() projectData: ProjectData): string {
        return projectData.id.toString();
    }
}