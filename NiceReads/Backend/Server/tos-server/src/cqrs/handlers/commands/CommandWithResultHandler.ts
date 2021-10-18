import { injectable } from 'inversify';
import { CommandWithResult } from '../../executions/commands/CommandWithResult';
import { ExecutionHandlerWithResult } from '../ExecutionHandlerWithResult';
import { ICommandWithResultHandler } from './ICommandWithResultHandler';

@injectable()
export abstract class CommandWithResultHandler<TCommand extends CommandWithResult<TResult>, TResult>
    extends ExecutionHandlerWithResult<TCommand, TResult>
    implements ICommandWithResultHandler<TCommand, TResult> { }