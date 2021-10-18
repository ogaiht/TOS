import { injectable } from 'inversify';
import { AsyncExecutionRequestWithResult } from '../executions/execution.request';

@injectable()
export abstract class AsyncExecutionHandlerWithResult<TExecution extends AsyncExecutionRequestWithResult<TResult>, TResult> {
    abstract executeAsync(execute: TExecution): Promise<TResult>;
}