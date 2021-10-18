import { Arg, FieldResolver, Mutation, Query, Resolver, Root } from 'type-graphql';
import { CompleteTaskAsyncCommand } from '../cqrs/commands/tasks/CompleteTaskAsyncCommand';
import { GetProjectByIdAsyncQuery } from '../cqrs/queries/projects/GetProjectByIdAsyncQuery';
import { GetTaskByIdAsyncQuery } from '../cqrs/queries/tasks/GetTaskByIdAsyncQuery';
import container from '../../configuration/ContainerConfig';
import { ICommandDispatcher } from '../../cqrs/dispatchers/commands/ICommandDispatcher';
import { IQueryDispatcher } from '../../cqrs/dispatchers/queries/IQueryDispatcher';
import { ProjectData, TaskData } from '../../data/data';
import { Task } from '../schemas/task';
import { Types } from '../../types';

@Resolver(Task)
export class TaskResolver {

    private readonly commandDispatcher: ICommandDispatcher;
    private readonly queryDispatcher: IQueryDispatcher;

    constructor(
        // @inject(CqrsConfig.COMMAND_DISPATCHER) private readonly commandDispatcher: ICommandDispatcher,
        // @inject(CqrsConfig.QUERY_DISPATCHER) private readonly queryDispatcher: IQueryDispatcher
        ) {
            this.commandDispatcher = container.get<ICommandDispatcher>(Types.COMMAND_DISPATCHER);
            this.queryDispatcher = container.get<IQueryDispatcher>(Types.QUERY_DISPATCHER);
        }


    @Query(returns => [Task])
    fetchTasks(): TaskData[] {
        return [];
    }

    @Query(returns => Task, { nullable: true })
    async getTask(@Arg('taskId') taskId: string): Promise<TaskData | undefined> {
        return await this.queryDispatcher.executeAsync(new GetTaskByIdAsyncQuery(taskId));
    }

    @Mutation(returns => Task)
    async markAsCompleted(@Arg('taskId') taskId: string): Promise<TaskData | undefined> {
        return await this.commandDispatcher.executeAsyncWithResult(new CompleteTaskAsyncCommand(taskId));
    }

    @FieldResolver()
    async project(@Root() taskData: TaskData): Promise<ProjectData | undefined> {
        return this.queryDispatcher.executeAsync(new GetProjectByIdAsyncQuery(taskData.projectId));
    }

    @FieldResolver()
    id(@Root() taskData: TaskData): string {
        return taskData.id.toString();
    }
}