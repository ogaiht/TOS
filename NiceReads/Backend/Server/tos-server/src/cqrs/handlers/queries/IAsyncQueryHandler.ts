import { IAsyncQuery } from '../../executions/queries/IAsyncQuery';
import { IAsyncExecutionHandlerWithResult } from '../IAsyncExecutionHandlerWithResult';

export interface IAsyncQueryHandler<TQuery extends IAsyncQuery<TResult>, TResult> extends IAsyncExecutionHandlerWithResult<TQuery, TResult> {

}