import { IExecutionRequest, IExecutionRequestWitResult } from '../executions/execution.request';
import { IExecutionHandler } from '../handlers/IExecutionHandler';
import { IExecutionHandlerWithResult } from '../handlers/IExecutionHandlerWithResult';

export interface IHandlerExecutorIdGenerator {
    createExecutionId<TExecution extends IExecutionRequest, THandler extends IExecutionHandler<TExecution>>(
        execution: TExecution,
        handler: THandler): void;

    createExecutionWithResultId<
        TExecution extends IExecutionRequestWitResult<TResult>,
        THandler extends IExecutionHandlerWithResult<TExecution,
        TResult>, TResult>(
            execution: TExecution,
            handler: THandler): void;
}