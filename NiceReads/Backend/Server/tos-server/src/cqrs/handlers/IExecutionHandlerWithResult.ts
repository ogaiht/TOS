import { IExecutionRequestWitResult } from '../executions/IExecutionRequestWitResult';

export interface IExecutionHandlerWithResult<TExecution extends IExecutionRequestWitResult<TResult>, TResult> {
    execute(execute: TExecution): TResult;
}

