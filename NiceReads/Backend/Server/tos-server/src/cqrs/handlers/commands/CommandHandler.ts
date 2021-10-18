import { injectable } from 'inversify';
import { Command } from '../../executions/commands/commands';
import { ExecutionHandler } from '../ExecutionHandler';
import { ICommandHandler } from './ICommandHandler';

@injectable()
export abstract class CommandHandler<TCommand extends Command>
    extends ExecutionHandler<TCommand>
    implements ICommandHandler<TCommand> {  }