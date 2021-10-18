import { IAsyncCommand } from '../../executions/commands/IAsyncCommand';
import { IAsyncExecutionHandler } from '../IAsyncExecutionHandler';

export interface IAsyncCommandHandler<TCommand extends IAsyncCommand> extends IAsyncExecutionHandler<TCommand> {
}
