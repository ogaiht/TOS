import { IAsyncExecutionRequest, IAsyncExecutionRequestWithResult, IExecutionRequest, IExecutionRequestWitResult } from '../executions/execution.request';
import { IAsyncExecutionHandler } from './IAsyncExecutionHandler';
import { IAsyncExecutionHandlerWithResult } from './IAsyncExecutionHandlerWithResult';
import { IExecutionHandler } from './IExecutionHandler';
import { IExecutionHandlerWithResult } from './IExecutionHandlerWithResult';

export interface IHandlerExecutor {
    execute<TExecution extends IExecutionRequest, THandler extends IExecutionHandler<TExecution>>(executionHandler: THandler, execution: TExecution): void;
    executeWithResult<TExecution extends IExecutionRequestWitResult<TResult>, THandler extends IExecutionHandlerWithResult<TExecution, TResult>, TResult>(
        executionHandler: THandler,
        execution: TExecution): TResult;
    executeAsync<TExecution extends IAsyncExecutionRequest, THandler extends IAsyncExecutionHandler<TExecution>>(
        executionHandler: THandler,
        execution: TExecution): Promise<void>;
    executeWithResultAsync<
        TExecution extends IAsyncExecutionRequestWithResult<TResult>,
        THandler extends IAsyncExecutionHandlerWithResult<TExecution, TResult>, TResult>(
            executionHandler: THandler,
            execution: TExecution): Promise<TResult>;
}
