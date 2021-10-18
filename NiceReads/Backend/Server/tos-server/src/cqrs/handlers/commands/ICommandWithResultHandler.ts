import { ICommandWithResult } from '../../executions/commands/commands';
import { IExecutionHandlerWithResult } from '../IExecutionHandlerWithResult';

export interface ICommandWithResultHandler<TCommand extends ICommandWithResult<TResult>, TResult>
    extends IExecutionHandlerWithResult<TCommand, TResult> {
}