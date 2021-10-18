import { injectable } from 'inversify';
import { AsyncCommandWithResult } from '../../executions/commands/AsyncCommandWithResult';
import { AsyncExecutionHandlerWithResult } from '../AsyncExecutionHandlerWithResult';
import { IAsyncCommandWithResultHandler } from './IAsyncCommandWithResultHandler';

@injectable()
export abstract class AsyncCommandWithResultHandler<TCommand extends AsyncCommandWithResult<TResult>, TResult>
    extends AsyncExecutionHandlerWithResult<TCommand, TResult>
    implements IAsyncCommandWithResultHandler<TCommand, TResult> { }
