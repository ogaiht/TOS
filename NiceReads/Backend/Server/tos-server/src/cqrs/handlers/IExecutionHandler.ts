import { IExecutionRequest } from '../executions/execution.request';

export interface IExecutionHandler<TExecution extends IExecutionRequest> {
    execute(execution: TExecution): void;
}
