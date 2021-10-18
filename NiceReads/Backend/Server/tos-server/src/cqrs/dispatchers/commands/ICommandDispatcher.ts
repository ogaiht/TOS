import { IAsyncCommand } from '../../executions/commands/IAsyncCommand';
import { IAsyncCommandWithResult } from '../../executions/commands/IAsyncCommandWithResult';
import { ICommand } from '../../executions/commands/ICommand';
import { ICommandWithResult } from '../../executions/commands/ICommandWithResult';

export interface ICommandDispatcher {
    execute<TCommand extends ICommand>(command: TCommand): void;
    executeWithResult<TCommand extends ICommandWithResult<TResult>, TResult>(command: TCommand): TResult;
    executeAsync<TAsyncCommand extends IAsyncCommand>(asyncCommand: TAsyncCommand): Promise<void>;
    executeAsyncWithResult<TAsyncCommand extends IAsyncCommandWithResult<TResult>, TResult>(asyncCommand: TAsyncCommand): Promise<TResult>;
}
