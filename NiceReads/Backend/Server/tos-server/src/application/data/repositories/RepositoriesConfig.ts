import { Container } from 'inversify';
import { Types } from '../../../types';
import { CityRepository } from './CityRepository';
import { CountryRepository } from './CountryRepository';
import { ICityRepository } from './ICityRepository';
import { ICountryRepository } from './ICountryRepository';
import { IProjectRepository } from './IProjectRepository';
import { IStateRepository } from './IStateRepository';
import { ITaskRepository } from './ITaskRepository';
import { ProjectRepository } from './ProjectRepository';
import { StateRepository } from './StateRepository';
import { TaskRepository } from './TaskRepository';

export function configRepositories(container: Container): void {
    container.bind<IProjectRepository>(Types.Repositories.PROJECT_REPOSITORY).to(ProjectRepository);
    container.bind<ITaskRepository>(Types.Repositories.TASK_REPOSITORY).to(TaskRepository);
    container.bind<ICityRepository>(Types.Repositories.CITY_REPOSITORY).to(CityRepository);
    container.bind<IStateRepository>(Types.Repositories.STATE_REPOSITORY).to(StateRepository);
    container.bind<ICountryRepository>(Types.Repositories.COUNTRY_REPOSITORY).to(CountryRepository);
}