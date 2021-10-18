import { IAsyncExecutionRequest } from '../executions/IAsyncExecutionRequest';

export interface IAsyncExecutionHandler<TExecution extends IAsyncExecutionRequest> {
    executeAsync(execution: TExecution): Promise<void>;
}