import { ExecutionRequest } from '../executions/execution.request';

export abstract class ExecutionHandler<TExecution extends ExecutionRequest> {
    abstract execute(execution: TExecution): void;
}