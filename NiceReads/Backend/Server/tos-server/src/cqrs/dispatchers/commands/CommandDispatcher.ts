import { inject, injectable } from 'inversify';
import { Types } from '../../../types';
import { IAsyncCommand } from '../../executions/commands/IAsyncCommand';
import { IAsyncCommandWithResult } from '../../executions/commands/IAsyncCommandWithResult';
import { ICommand } from '../../executions/commands/ICommand';
import { ICommandWithResult } from '../../executions/commands/ICommandWithResult';
import { IAsyncCommandHandler } from '../../handlers/commands/IAsyncCommandHandler';
import { IAsyncCommandWithResultHandler } from '../../handlers/commands/IAsyncCommandWithResultHandler';
import { ICommandHandler } from '../../handlers/commands/ICommandHandler';
import { ICommandWithResultHandler } from '../../handlers/commands/ICommandWithResultHandler';
import { IHandlerExecutor } from '../../handlers/IHandlerExecutor';
import { IExecutionHandlerProvider } from '../IExecutionHandlerProvider';
import { ICommandDispatcher } from './ICommandDispatcher';

@injectable()
export class CommandDispatcher implements ICommandDispatcher {

    constructor(
        @inject(Types.EXECUTOR_HANDLER_PROVIDER) private readonly executionHandlerProvider: IExecutionHandlerProvider,
        @inject(Types.HANDLER_EXECUTOR) private readonly handlerExecutor: IHandlerExecutor
        ) { }

    execute<TCommand extends ICommand>(command: TCommand): void {
        const handlerIdentifier: string = command.constructor.name;
        const handler: ICommandHandler<TCommand> = this.executionHandlerProvider.getHandlerFor<ICommandHandler<TCommand>>(handlerIdentifier);
        try {
            this.handlerExecutor.execute(handler, command);
        } catch (error) {
            this.logError(error as Error, command, handler);
            throw error;
        }
    }

    executeWithResult<TCommand extends ICommandWithResult<TResult>, TResult>(command: TCommand): TResult {
        const handlerIdentifier: string = command.constructor.name;
        const handler: ICommandWithResultHandler<TCommand, TResult> =
         this.executionHandlerProvider.getHandlerFor<ICommandWithResultHandler<TCommand, TResult>>(handlerIdentifier);
        try {
            return this.handlerExecutor.executeWithResult(handler, command);
        } catch (error) {
            this.logError(error as Error, command, handler);
            throw error;
        }
    }

    async executeAsync<TAsyncCommand extends IAsyncCommand>(asyncCommand: TAsyncCommand): Promise<void> {
        const handlerIdentifier: string = asyncCommand.constructor.name;
        const asyncHandler: IAsyncCommandHandler<TAsyncCommand> =
         this.executionHandlerProvider.getHandlerFor<IAsyncCommandHandler<TAsyncCommand>>(handlerIdentifier);
        try {
            await this.handlerExecutor.executeAsync(asyncHandler, asyncCommand);
        } catch (error) {
            this.logError(error as Error, asyncCommand, asyncHandler);
            throw error;
        }
    }

    async executeAsyncWithResult<TAsyncCommand extends IAsyncCommandWithResult<TResult>, TResult>(asyncCommand: TAsyncCommand): Promise<TResult> {
        const handlerIdentifier: string = asyncCommand.constructor.name;
        const asyncHandler: IAsyncCommandWithResultHandler<TAsyncCommand, TResult> =
            this.executionHandlerProvider.getHandlerFor<IAsyncCommandWithResultHandler<TAsyncCommand, TResult>>(handlerIdentifier);
        try {
            return await this.handlerExecutor.executeWithResultAsync(asyncHandler, asyncCommand);
        } catch (error) {
            this.logError(error as Error, asyncCommand, asyncHandler);
            throw error;
        }
    }

    private logError(error: Error, command: any, handler: any): void {

    }
}