import { IHandlerExecutorLoggerScope } from './IHandlerExecutorLoggerScope';

export interface IHandlerExecutorLoggerWithResultScope<TResult> extends IHandlerExecutorLoggerScope {
    afterExecutionWithResult(result: TResult): void;
}