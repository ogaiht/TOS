import { ExecutionRequestWithResult } from '../executions/execution.request';

export abstract class ExecutionHandlerWithResult<TExecution extends ExecutionRequestWithResult<TResult>, TResult> {
    abstract execute(execution: TExecution): TResult;
}