import { IAsyncCommand, IAsyncCommandWithResult } from '../../executions/commands/async.command';
import { ICommand, ICommandWithResult } from '../../executions/commands/commands';

export interface ICommandDispatcher {
    execute<TCommand extends ICommand>(command: TCommand): void;
    executeWithResult<TCommand extends ICommandWithResult<TResult>, TResult>(command: TCommand): TResult;
    executeAsync<TAsyncCommand extends IAsyncCommand>(asyncCommand: TAsyncCommand): Promise<void>;
    executeAsyncWithResult<TAsyncCommand extends IAsyncCommandWithResult<TResult>, TResult>(asyncCommand: TAsyncCommand): Promise<TResult>;
}
