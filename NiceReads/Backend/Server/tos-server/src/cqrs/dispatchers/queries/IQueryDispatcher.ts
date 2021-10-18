import { IAsyncQuery } from '../../executions/queries/IAsyncQuery';
import { IQuery } from '../../executions/queries/IQuery';

export interface IQueryDispatcher {
    execute<TQuery extends IQuery<TResult>, TResult>(query: TQuery): TResult;
    executeAsync<TAsyncQuery extends IAsyncQuery<TResult>, TResult>(asyncQuery: TAsyncQuery): Promise<TResult>;
}