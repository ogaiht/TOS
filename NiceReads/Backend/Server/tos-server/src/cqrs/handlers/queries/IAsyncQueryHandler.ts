import { IAsyncQuery } from '../../executions/queries/async.query';
import { IAsyncExecutionHandlerWithResult } from '../IAsyncExecutionHandlerWithResult';

export interface IAsyncQueryHandler<TQuery extends IAsyncQuery<TResult>, TResult> extends IAsyncExecutionHandlerWithResult<TQuery, TResult> {

}