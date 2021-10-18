import { Container } from 'inversify';
import { configCqrsDependencies } from './cqrs/CqrsConfig';
import { configDataDependencies } from './data/DataConfig';

export function configApplication(container: Container): void {
    configCqrsDependencies(container);
    configDataDependencies(container);
}