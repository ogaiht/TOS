import { ExecutionTimer } from './ExecutionTimer';
import { IExecutionTimer } from './IExecutionTimer';
import { IHandlerExecutorLoggerScope } from './IHandlerExecutorLoggerScope';

export class HandlerExecutorLoggerScope implements IHandlerExecutorLoggerScope {
    beforeExecution(): void { }
    afterExecution(): void { }
    onError(error: Error): void { console.error(error); }
    timeExecution(): IExecutionTimer { return new ExecutionTimer(); }
    complete(): void { }
}