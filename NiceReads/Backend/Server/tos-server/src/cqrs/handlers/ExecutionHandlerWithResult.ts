import { ExecutionRequestWithResult } from '../executions/ExecutionRequestWithResult';

export abstract class ExecutionHandlerWithResult<TExecution extends ExecutionRequestWithResult<TResult>, TResult> {
    abstract execute(execution: TExecution): TResult;
}