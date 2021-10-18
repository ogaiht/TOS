import { Uuid } from '../../../../common/uuid';
import { inject, injectable } from 'inversify';
import { IProjectRepository } from '../../../data/repositories/IProjectRepository';
import { ITaskRepository } from '../../../data/repositories/ITaskRepository';
import { ProjectData, TaskData } from '../../../../data/data';
import { CreateProjectCommand } from './CreateProjectCommand';
import { CommandWithResultHandler } from '../../../../cqrs/handlers/commands/CommandWithResultHandler';

@injectable()
export class CreateProjectCommandHandler implements CommandWithResultHandler<CreateProjectCommand, ProjectData> {

    constructor(
        @inject('IProjectRepository') private readonly projectRepository: IProjectRepository,
        @inject('ITaskRepository') private readonly taskRepository: ITaskRepository) { }

    public execute(command: CreateProjectCommand): ProjectData {
        const projectData: ProjectData = new ProjectData(command.project.name);
        const projectId: Uuid =  this.projectRepository.add(projectData);

        if (command.project.tasks && command.project.tasks.length > 0) {
            for (const newTask of command.project.tasks) {
                this.taskRepository.add(new TaskData(newTask.title, false, projectId));
            }
        }
        return projectData;
    }
}