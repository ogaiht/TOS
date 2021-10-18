import { injectable } from 'inversify';
import { AsyncExecutionRequest } from '../executions/execution.request';

@injectable()
export abstract class AsyncExecutionHandler<TExecution extends AsyncExecutionRequest> {
    abstract executeAsync(execution: TExecution): Promise<void>;
}