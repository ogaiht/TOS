import { ICommand } from '../../executions/commands/commands';
import { IExecutionHandler } from '../IExecutionHandler';

export interface ICommandHandler<TCommand extends ICommand> extends IExecutionHandler<TCommand> {
}
