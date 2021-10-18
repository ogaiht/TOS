import { ICommand } from '../../executions/commands/ICommand';
import { IExecutionHandler } from '../IExecutionHandler';

export interface ICommandHandler<TCommand extends ICommand> extends IExecutionHandler<TCommand> {
}
