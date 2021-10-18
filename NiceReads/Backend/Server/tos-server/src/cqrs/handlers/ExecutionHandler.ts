import { ExecutionRequest } from '../executions/ExecutionRequest';

export abstract class ExecutionHandler<TExecution extends ExecutionRequest> {
    abstract execute(execution: TExecution): void;
}