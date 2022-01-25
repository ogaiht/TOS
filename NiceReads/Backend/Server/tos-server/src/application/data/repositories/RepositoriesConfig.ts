import { Container } from 'inversify';
import { Types } from '../../../types';
import { CityRepository } from './CityRepository';
import { CountryRepository } from './CountryRepository';
import { EmployeeRepository } from './EmployeeRepository';
import { ICityRepository } from './ICityRepository';
import { ICountryRepository } from './ICountryRepository';
import { IEmployeeRepository } from './IEmployeeRepository';
import { IProjectRepository } from './IProjectRepository';
import { ISkillLevelRepository } from './ISkillLevelRepository';
import { ISkillRepository } from './ISkillRepository';
import { IStateRepository } from './IStateRepository';
import { ITaskRepository } from './ITaskRepository';
import { ProjectRepository } from './ProjectRepository';
import { SkillLevelRepository } from './SkillLevelRepository';
import { SkillRepository } from './SkillRepository';
import { StateRepository } from './StateRepository';
import { TaskRepository } from './TaskRepository';

export function configRepositories(container: Container): void {
    container.bind<IProjectRepository>(Types.Repositories.PROJECT_REPOSITORY).to(ProjectRepository);
    container.bind<ITaskRepository>(Types.Repositories.TASK_REPOSITORY).to(TaskRepository);
    container.bind<ICityRepository>(Types.Repositories.CITY_REPOSITORY).to(CityRepository);
    container.bind<IStateRepository>(Types.Repositories.STATE_REPOSITORY).to(StateRepository);
    container.bind<ICountryRepository>(Types.Repositories.COUNTRY_REPOSITORY).to(CountryRepository);
    container.bind<IEmployeeRepository>(Types.Repositories.EMPLOYEE_REPOSITORY).to(EmployeeRepository);
    container.bind<ISkillLevelRepository>(Types.Repositories.SKILL_LEVEL_REPOSITORY).to(SkillLevelRepository);
    container.bind<ISkillRepository>(Types.Repositories.SKILL_REPOSITORY).to(SkillRepository);
}