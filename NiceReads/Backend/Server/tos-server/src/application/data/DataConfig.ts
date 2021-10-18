import { Container } from 'inversify';
import { configRepositories } from './repositories/RepositoriesConfig';

export function configDataDependencies(container: Container): void {
    configRepositories(container);
}