import { IAsyncExecutionRequest, IAsyncExecutionRequestWithResult, IExecutionRequest, IExecutionRequestWitResult } from '../executions/execution.request';
import { IAsyncExecutionHandler } from '../handlers/IAsyncExecutionHandler';
import { IAsyncExecutionHandlerWithResult } from '../handlers/IAsyncExecutionHandlerWithResult';
import { IExecutionHandler } from '../handlers/IExecutionHandler';
import { IExecutionHandlerWithResult } from '../handlers/IExecutionHandlerWithResult';
import { IHandlerExecutorLoggerScope } from './IHandlerExecutorLoggerScope';
import { IHandlerExecutorLoggerWithResultScope } from './IHandlerExecutorLoggerWithResultScope';

export interface IHandlerExecutorLogger {
    createScope<TExecution extends IExecutionRequest, THandler extends IExecutionHandler<TExecution>>(execution: TExecution, handler: THandler): IHandlerExecutorLoggerScope;
    createScopeWithResult<TExecution extends IExecutionRequestWitResult<TResult>, THandler extends IExecutionHandlerWithResult<TExecution, TResult>, TResult>(execution: TExecution, handler: THandler): IHandlerExecutorLoggerWithResultScope<TResult>;
    createScopeForAsync<TExecution extends IAsyncExecutionRequest, THandler extends IAsyncExecutionHandler<TExecution>>(execution: TExecution, handler: THandler): IHandlerExecutorLoggerScope;
    createScopeWithResultForAsync<TExecution extends IAsyncExecutionRequestWithResult<TResult>, THandler extends IAsyncExecutionHandlerWithResult<TExecution, TResult>, TResult>(execution: TExecution, handler: THandler): IHandlerExecutorLoggerWithResultScope<TResult>;
}