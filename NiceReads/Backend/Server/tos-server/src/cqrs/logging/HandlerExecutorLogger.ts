import { injectable } from 'inversify';
import { IAsyncExecutionRequest } from '../executions/IAsyncExecutionRequest';
import { IAsyncExecutionRequestWithResult } from '../executions/IAsyncExecutionRequestWithResult';
import { IExecutionRequest } from '../executions/IExecutionRequest';
import { IExecutionRequestWitResult } from '../executions/IExecutionRequestWitResult';
import { IAsyncExecutionHandler } from '../handlers/IAsyncExecutionHandler';
import { IAsyncExecutionHandlerWithResult } from '../handlers/IAsyncExecutionHandlerWithResult';
import { IExecutionHandler } from '../handlers/IExecutionHandler';
import { IExecutionHandlerWithResult } from '../handlers/IExecutionHandlerWithResult';
import { HandlerExecutorLoggerScope } from './HandlerExecutorLoggerScope';
import { HandlerExecutorLoggerWithResultScope } from './HandlerExecutorLoggerWithResultScope';
import { IHandlerExecutorLogger } from './IHandlerExecutorLogger';
import { IHandlerExecutorLoggerScope } from './IHandlerExecutorLoggerScope';
import { IHandlerExecutorLoggerWithResultScope } from './IHandlerExecutorLoggerWithResultScope';


@injectable()
export class HandlerExecutorLogger implements IHandlerExecutorLogger {
    createScope<TExecution extends IExecutionRequest, THandler extends IExecutionHandler<TExecution>>(execution: TExecution, handler: THandler): IHandlerExecutorLoggerScope {
        return new HandlerExecutorLoggerScope();
    }
    createScopeWithResult<TExecution extends IExecutionRequestWitResult<TResult>, THandler extends IExecutionHandlerWithResult<TExecution, TResult>, TResult>(execution: TExecution, handler: THandler): IHandlerExecutorLoggerWithResultScope<TResult> {
        console.log('Creating execution scope for: ', handler, execution);
        return new HandlerExecutorLoggerWithResultScope();
    }
    createScopeForAsync<TExecution extends IAsyncExecutionRequest, THandler extends IAsyncExecutionHandler<TExecution>>(execution: TExecution, handler: THandler): IHandlerExecutorLoggerScope {
        return new HandlerExecutorLoggerScope();
    }
    createScopeWithResultForAsync<TExecution extends IAsyncExecutionRequestWithResult<TResult>, THandler extends IAsyncExecutionHandlerWithResult<TExecution, TResult>, TResult>(execution: TExecution, handler: THandler): IHandlerExecutorLoggerWithResultScope<TResult> {
        return new HandlerExecutorLoggerWithResultScope();
    }
}