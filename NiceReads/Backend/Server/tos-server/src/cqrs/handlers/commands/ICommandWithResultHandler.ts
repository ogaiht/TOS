import { ICommandWithResult } from '../../executions/commands/ICommandWithResult';
import { IExecutionHandlerWithResult } from '../IExecutionHandlerWithResult';

export interface ICommandWithResultHandler<TCommand extends ICommandWithResult<TResult>, TResult>
    extends IExecutionHandlerWithResult<TCommand, TResult> {
}