import { HandlerExecutorLoggerScope } from './HandlerExecutorLoggerScope';
import { IHandlerExecutorLoggerWithResultScope } from './IHandlerExecutorLoggerWithResultScope';

export class HandlerExecutorLoggerWithResultScope<TResult> extends HandlerExecutorLoggerScope implements IHandlerExecutorLoggerWithResultScope<TResult> {
    afterExecutionWithResult(result: TResult): void { }
}