import { IAsyncCommandWithResult } from '../../executions/commands/IAsyncCommandWithResult';
import { IAsyncExecutionHandlerWithResult } from '../IAsyncExecutionHandlerWithResult';

export interface IAsyncCommandWithResultHandler<TCommand extends IAsyncCommandWithResult<TResult>, TResult>
    extends IAsyncExecutionHandlerWithResult<TCommand, TResult> {
}

