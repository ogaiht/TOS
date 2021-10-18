import { IAsyncExecutionRequestWithResult } from '../executions/IAsyncExecutionRequestWithResult';

export interface IAsyncExecutionHandlerWithResult<TExecution extends IAsyncExecutionRequestWithResult<TResult>, TResult> {
    executeAsync(execute: TExecution): Promise<TResult>;
}