import { IExecutionTimer } from './IExecutionTimer';

export interface IHandlerExecutorLoggerScope {
    beforeExecution(): void;
    afterExecution(): void;
    onError(error: Error): void;
    timeExecution(): IExecutionTimer;
    complete(): void;
}