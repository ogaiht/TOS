import { injectable } from 'inversify';
import { Query } from '../../executions/queries/query';
import { ExecutionHandlerWithResult } from '../ExecutionHandlerWithResult';
import { IQueryHandler } from './IQueryHandler';

@injectable()
export abstract class QueryHandler<TQuery extends Query<TResult>, TResult>
    extends ExecutionHandlerWithResult<TQuery, TResult>
    implements IQueryHandler<TQuery, TResult> { }