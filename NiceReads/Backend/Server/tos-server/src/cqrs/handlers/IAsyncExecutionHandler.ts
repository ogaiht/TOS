import { IAsyncExecutionRequest } from '../executions/execution.request';

export interface IAsyncExecutionHandler<TExecution extends IAsyncExecutionRequest> {
    executeAsync(execution: TExecution): Promise<void>;
}