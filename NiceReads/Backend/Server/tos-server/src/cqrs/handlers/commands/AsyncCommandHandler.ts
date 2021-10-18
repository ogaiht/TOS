import { injectable } from 'inversify';
import { AsyncCommand } from '../../executions/commands/AsyncCommand';
import { AsyncExecutionHandler } from '../AsyncExecutionHandler';
import { IAsyncCommandHandler } from './IAsyncCommandHandler';

@injectable()
export abstract class AsyncCommandHandler<TAsyncCommand extends AsyncCommand>
    extends AsyncExecutionHandler<TAsyncCommand>
    implements IAsyncCommandHandler<TAsyncCommand>
{ }