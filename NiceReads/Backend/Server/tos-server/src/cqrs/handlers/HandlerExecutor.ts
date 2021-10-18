import { inject, injectable } from 'inversify';
import { Types } from '../../types';
import { IAsyncExecutionRequest, IAsyncExecutionRequestWithResult, IExecutionRequest, IExecutionRequestWitResult } from '../executions/execution.request';
import { IExecutionTimer } from '../logging/IExecutionTimer';
import { IHandlerExecutorLogger } from '../logging/IHandlerExecutorLogger';
import { IHandlerExecutorLoggerScope } from '../logging/IHandlerExecutorLoggerScope';
import { IHandlerExecutorLoggerWithResultScope } from '../logging/IHandlerExecutorLoggerWithResultScope';
import { IAsyncExecutionHandler } from './IAsyncExecutionHandler';
import { IAsyncExecutionHandlerWithResult } from './IAsyncExecutionHandlerWithResult';
import { IExecutionHandler } from './IExecutionHandler';
import { IExecutionHandlerWithResult } from './IExecutionHandlerWithResult';
import { IHandlerExecutor } from './IHandlerExecutor';

@injectable()
export class HandlerExecutor implements IHandlerExecutor {

    constructor(@inject(Types.HANDLER_EXECUTOR_LOGGER) private readonly handlerExecutorLogger: IHandlerExecutorLogger) { }

    public execute<TExecution extends IExecutionRequest, THandler extends IExecutionHandler<TExecution>>(
        executionHandler: THandler,
        execution: TExecution): void {

        const loggerScope: IHandlerExecutorLoggerScope = this.handlerExecutorLogger.createScope(execution, executionHandler);
        loggerScope.beforeExecution();
        try {
            const executionTimer: IExecutionTimer = loggerScope.timeExecution();
            try {
                executionHandler.execute(execution);
            } finally {
                executionTimer.stop();
            }
            loggerScope.afterExecution();
        } catch (error) {
            loggerScope.onError(error as Error);
            throw error;
        } finally {
            loggerScope.complete();
        }
    }

    public executeWithResult<
        TExecution extends IExecutionRequestWitResult<TResult>,
        THandler extends IExecutionHandlerWithResult<TExecution, TResult>, TResult>
    (executionHandler: THandler, execution: TExecution): TResult {

        const loggerScope: IHandlerExecutorLoggerWithResultScope<TResult> = this.handlerExecutorLogger
            .createScopeWithResult<TExecution, THandler, TResult>(execution, executionHandler);
        loggerScope.beforeExecution();
        try {
            let result: TResult;
            const executionTimer: IExecutionTimer = loggerScope.timeExecution();
            try {
                result = executionHandler.execute(execution);
            } finally {
                executionTimer.stop();
            }
            loggerScope.afterExecutionWithResult(result);
            return result;
        } catch (error) {
            loggerScope.onError(error as Error);
            throw error;
        } finally {
            loggerScope.complete();
        }
    }

    public async executeAsync<TExecution extends IAsyncExecutionRequest, THandler extends IAsyncExecutionHandler<TExecution>>(
        executionHandler: THandler,
        execution: TExecution): Promise<void> {

        const loggerScope: IHandlerExecutorLoggerScope = this.handlerExecutorLogger.createScopeForAsync(execution, executionHandler);
        loggerScope.beforeExecution();
        try {
            const executionTimer: IExecutionTimer = loggerScope.timeExecution();
            try {
                await executionHandler.executeAsync(execution);
            } finally {
                executionTimer.stop();
            }
            loggerScope.afterExecution();
        } catch (error) {
            loggerScope.onError(error as Error);
            throw error;
        } finally {
            loggerScope.complete();
        }
    }

    public async executeWithResultAsync<
        TExecution extends IAsyncExecutionRequestWithResult<TResult>,
        THandler extends IAsyncExecutionHandlerWithResult<TExecution, TResult>, TResult>
    (executionHandler: THandler, execution: TExecution): Promise<TResult> {

        const loggerScope: IHandlerExecutorLoggerWithResultScope<TResult> = this.handlerExecutorLogger
            .createScopeWithResultForAsync<TExecution, THandler, TResult>(execution, executionHandler);
        loggerScope.beforeExecution();
        try {
            let result: TResult;
            const executionTimer: IExecutionTimer = loggerScope.timeExecution();
            try {
                result = await executionHandler.executeAsync(execution);
            } finally {
                executionTimer.stop();
            }
            loggerScope.afterExecutionWithResult(result);
            return result;
        } catch (error) {
            loggerScope.onError(error as Error);
            throw error;
        } finally {
            loggerScope.complete();
        }
    }
}