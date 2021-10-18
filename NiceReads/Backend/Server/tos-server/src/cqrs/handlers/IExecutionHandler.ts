import { IExecutionRequest } from '../executions/IExecutionRequest';

export interface IExecutionHandler<TExecution extends IExecutionRequest> {
    execute(execution: TExecution): void;
}
