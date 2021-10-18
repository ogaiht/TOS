import { IAsyncQuery } from '../../executions/queries/async.query';
import { IQuery } from '../../executions/queries/query';

export interface IQueryDispatcher {
    execute<TQuery extends IQuery<TResult>, TResult>(query: TQuery): TResult;
    executeAsync<TAsyncQuery extends IAsyncQuery<TResult>, TResult>(asyncQuery: TAsyncQuery): Promise<TResult>;
}