import { Container, inject, injectable } from 'inversify';
import { Types } from '../../types';
import { IExecutionHandlerProvider } from './IExecutionHandlerProvider';

@injectable()
export class ExecutionHandlerProvider implements IExecutionHandlerProvider {

    constructor(@inject(Types.CONTAINER) private readonly container: Container) { }

    getHandlerFor<THandler>(handlerIdentifier: string, throwExceptionIfNotFound: boolean = true): THandler {
        console.log('Executing query: ', handlerIdentifier);
        const handler: THandler = this.container.get<THandler>(handlerIdentifier);
        if (!handler && throwExceptionIfNotFound) {
            throw new Error(`Handler not found for '${handlerIdentifier}''.`);
        }
        return handler;
    }
}