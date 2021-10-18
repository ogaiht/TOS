import { inject, injectable } from 'inversify';
import { Types } from '../../../types';
import { IAsyncQuery } from '../../executions/queries/async.query';
import { IQuery } from '../../executions/queries/query';
import { IHandlerExecutor } from '../../handlers/IHandlerExecutor';
import { IAsyncQueryHandler } from '../../handlers/queries/IAsyncQueryHandler';
import { IQueryHandler } from '../../handlers/queries/IQueryHandler';
import { IExecutionHandlerProvider } from '../IExecutionHandlerProvider';
import { IQueryDispatcher } from './IQueryDispatcher';

@injectable()
export class QueryDispatcher implements IQueryDispatcher {

    constructor(
        @inject(Types.EXECUTOR_HANDLER_PROVIDER) private readonly executionHandlerProvider: IExecutionHandlerProvider,
        @inject(Types.HANDLER_EXECUTOR) private readonly handlerExecutor: IHandlerExecutor
        ) { }

    execute<TQuery extends IQuery<TResult>, TResult>(query: TQuery): TResult {
        const handlerIdentifier: string = query.constructor.name;
        const handler: IQueryHandler<TQuery, TResult> =
         this.executionHandlerProvider.getHandlerFor<IQueryHandler<TQuery, TResult>>(handlerIdentifier);
        try{
            return this.handlerExecutor.executeWithResult(handler, query);
        } catch (error) {
            throw error;
        }
    }

    async executeAsync<TAsyncQuery extends IAsyncQuery<TResult>, TResult>(asyncQuery: TAsyncQuery): Promise<TResult> {
        const handlerIdentifier: string = asyncQuery.constructor.name;;
        const handler: IAsyncQueryHandler<TAsyncQuery, TResult> =
         this.executionHandlerProvider.getHandlerFor<IAsyncQueryHandler<TAsyncQuery, TResult>>(handlerIdentifier);
        try{
            return await this.handlerExecutor.executeWithResultAsync(handler, asyncQuery);
        } catch (error) {
            throw error;
        }
    }
}