import { IAsyncCommandWithResult } from '../../executions/commands/async.command';
import { IAsyncExecutionHandlerWithResult } from '../IAsyncExecutionHandlerWithResult';

export interface IAsyncCommandWithResultHandler<TCommand extends IAsyncCommandWithResult<TResult>, TResult>
    extends IAsyncExecutionHandlerWithResult<TCommand, TResult> {
}

