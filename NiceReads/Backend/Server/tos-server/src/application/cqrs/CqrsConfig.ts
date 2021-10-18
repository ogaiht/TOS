import { Container } from 'inversify';
import { CqrsConfigurator } from '../../cqrs/CqrsConfigurator';
import { ProjectData, TaskData } from '../../data/data';
import { City } from '../models/City';
import { Country } from '../models/Country';
import { State } from '../models/State';
import { CreateProjectCommand } from './commands/projects/CreateProjectCommand';
import { CreateProjectCommandHandler } from './commands/projects/CreateProjectCommandHandler';
import { CompleteTaskAsyncCommand } from './commands/tasks/CompleteTaskAsyncCommand';
import { CompleteTaskAsyncCommandHandler } from './commands/tasks/CompleteTaskAsyncCommandHandler';
import { GetCitiesByStateIdAsyncQuery } from './queries/cities/GetCitiesByStateIdAsyncQuery';
import { GetCitiesByStateIdAsyncQueryHandler } from './queries/cities/GetCitiesByStateIdAsyncQueryHandler';
import { GetCountryByNameAsyncQuery } from './queries/countries/GetCountryByNameAsyncQuery';
import { GetCountryByNameAsyncQueryHandler } from './queries/countries/GetCountryByNameAsyncQueryHandler';
import { GetProjectByIdAsyncQuery } from './queries/projects/GetProjectByIdAsyncQuery';
import { GetProjectByIdAsyncQueryHandler } from './queries/projects/GetProjectByIdAsyncQueryHandler';
import { GetProjectByNameAsyncQuery } from './queries/projects/GetProjectByNameAsyncQuery';
import { GetProjectByNameAsyncQueryHandler } from './queries/projects/GetProjectByNameQueryAsyncHandler';
import { GetStatesByCountryIdAsyncQuery } from './queries/states/GetStatesByCountryIdAsynQuery';
import { GetStatesByCountryIdAsynQueryHandler } from './queries/states/GetStatesByCountryIdAsynQueryHandler';
import { GetStatesByNameAsyncQuery } from './queries/states/GetStatesByNameAsyncQuery';
import { GetTaskByIdAsyncQuery } from './queries/tasks/GetTaskByIdAsyncQuery';
import { GetTaskByIdAsyncQueryHandler } from './queries/tasks/GetTaskByIdAsyncQueryHandler';
import { GetTasksByProjectIdAsyncQuery } from './queries/tasks/GetTasksByProjectIdAsyncQuery';
import { GetTasksByProjectIdAsyncQueryHandler } from './queries/tasks/GetTasksByProjectIdAsyncQueryHandler';
import { GetStateByIdAsyncQuery } from './queries/states/GetStateByIdAsyncQuery';
import { GetStateByIdAsyncQueryHandler } from './queries/states/GetStateByIdAsyncQueryHandler';
import { GetStatesByNameAsyncQueryHandler } from './queries/states/GetStatesByNameAsyncQueryHandler';
import { GetCitiesByNameAsyncQuery } from './queries/cities/GetCitiesByNameAsyncQuery';
import { GetCitiesByNameAsyncQueryHandler } from './queries/cities/GetCitiesByNameAsyncQueryHandler';

export function configCqrsDependencies(container: Container): void {
    const cqrsConfigurator: CqrsConfigurator = CqrsConfigurator.createCqrsContainer(container);
    configureCommands(cqrsConfigurator);
    configureQueries(cqrsConfigurator);
}

function configureCommands(cqrsConfig: CqrsConfigurator): void {
    cqrsConfig
        .addCommand(CreateProjectCommand, CreateProjectCommandHandler)
        .addAsyncCommandWithResult(CompleteTaskAsyncCommand, CompleteTaskAsyncCommandHandler);
}

function configureQueries(cqrsConfig: CqrsConfigurator): void {
    cqrsConfig
        .addAsyncQuery<GetCitiesByNameAsyncQuery, City[], GetCitiesByNameAsyncQueryHandler>(GetCitiesByNameAsyncQuery, GetCitiesByNameAsyncQueryHandler)
        .addAsyncQuery<GetCitiesByStateIdAsyncQuery, City[], GetCitiesByStateIdAsyncQueryHandler>(GetCitiesByStateIdAsyncQuery, GetCitiesByStateIdAsyncQueryHandler)
        .addAsyncQuery<GetCountryByNameAsyncQuery, Country[], GetCountryByNameAsyncQueryHandler>(GetCountryByNameAsyncQuery, GetCountryByNameAsyncQueryHandler)
        .addAsyncQuery<GetProjectByIdAsyncQuery, ProjectData | undefined, GetProjectByIdAsyncQueryHandler>(GetProjectByIdAsyncQuery, GetProjectByIdAsyncQueryHandler)
        .addAsyncQuery<GetProjectByNameAsyncQuery, ProjectData[], GetProjectByNameAsyncQueryHandler>(GetProjectByNameAsyncQuery, GetProjectByNameAsyncQueryHandler)
        .addAsyncQuery<GetStatesByCountryIdAsyncQuery, State[], GetStatesByCountryIdAsynQueryHandler>(GetStatesByCountryIdAsyncQuery, GetStatesByCountryIdAsynQueryHandler)
        .addAsyncQuery<GetStateByIdAsyncQuery, State | undefined, GetStateByIdAsyncQueryHandler>(GetStateByIdAsyncQuery, GetStateByIdAsyncQueryHandler)
        .addAsyncQuery<GetStatesByNameAsyncQuery, State[], GetStatesByNameAsyncQueryHandler>(GetStatesByNameAsyncQuery, GetStatesByNameAsyncQueryHandler)
        .addAsyncQuery<GetTaskByIdAsyncQuery, TaskData | undefined, GetTaskByIdAsyncQueryHandler>(GetTaskByIdAsyncQuery, GetTaskByIdAsyncQueryHandler)
        .addAsyncQuery<GetTasksByProjectIdAsyncQuery, TaskData[] | undefined, GetTasksByProjectIdAsyncQueryHandler>(GetTasksByProjectIdAsyncQuery, GetTasksByProjectIdAsyncQueryHandler);
}
