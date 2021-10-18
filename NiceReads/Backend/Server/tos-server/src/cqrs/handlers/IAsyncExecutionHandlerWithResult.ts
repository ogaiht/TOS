import { IAsyncExecutionRequestWithResult } from '../executions/execution.request';

export interface IAsyncExecutionHandlerWithResult<TExecution extends IAsyncExecutionRequestWithResult<TResult>, TResult> {
    executeAsync(execute: TExecution): Promise<TResult>;
}