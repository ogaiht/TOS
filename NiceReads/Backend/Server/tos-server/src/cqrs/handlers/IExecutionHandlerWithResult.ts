import { IExecutionRequestWitResult } from '../executions/execution.request';

export interface IExecutionHandlerWithResult<TExecution extends IExecutionRequestWitResult<TResult>, TResult> {
    execute(execute: TExecution): TResult;
}

