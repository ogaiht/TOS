import { IQuery } from '../../executions/queries/IQuery';
import { IExecutionHandlerWithResult } from '../IExecutionHandlerWithResult';

export interface IQueryHandler<TQuery extends IQuery<TResult>, TResult> extends IExecutionHandlerWithResult<TQuery, TResult> {

}