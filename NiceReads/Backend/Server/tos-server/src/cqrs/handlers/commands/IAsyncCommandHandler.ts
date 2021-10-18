import { IAsyncCommand } from '../../executions/commands/async.command';
import { IAsyncExecutionHandler } from '../IAsyncExecutionHandler';

export interface IAsyncCommandHandler<TCommand extends IAsyncCommand> extends IAsyncExecutionHandler<TCommand> {
}
