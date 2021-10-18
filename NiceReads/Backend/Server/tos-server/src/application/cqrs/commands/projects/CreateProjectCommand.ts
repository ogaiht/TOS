import { CommandWithResult } from '../../../../cqrs/executions/commands/CommandWithResult';
import { ProjectData } from '../../../../data/data';
import { AddProjectInput } from '../../../schemas/add-project-input';

export class CreateProjectCommand extends CommandWithResult<ProjectData> {
    constructor(public readonly project: AddProjectInput) {
        super();
    }
}

