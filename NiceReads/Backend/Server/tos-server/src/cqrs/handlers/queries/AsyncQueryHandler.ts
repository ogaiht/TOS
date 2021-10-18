import { injectable } from 'inversify';
import { AsyncQuery } from '../../executions/queries/async.query';
import { AsyncExecutionHandlerWithResult } from '../AsyncExecutionHandlerWithResult';
import { IAsyncQueryHandler } from './IAsyncQueryHandler';

@injectable()
export abstract class AsyncQueryHandler<TQuery extends AsyncQuery<TResult>, TResult>
    extends AsyncExecutionHandlerWithResult<TQuery, TResult>
    implements IAsyncQueryHandler<TQuery, TResult> { }