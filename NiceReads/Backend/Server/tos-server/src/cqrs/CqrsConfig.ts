import { Container } from 'inversify';
import { Types } from '../types';
import { CommandDispatcher } from './dispatchers/commands/CommandDispatcher';
import { ICommandDispatcher } from './dispatchers/commands/ICommandDispatcher';
import { ExecutionHandlerProvider } from './dispatchers/ExecutionHandlerProvider';
import { IExecutionHandlerProvider } from './dispatchers/IExecutionHandlerProvider';
import { IQueryDispatcher } from './dispatchers/queries/IQueryDispatcher';
import { QueryDispatcher } from './dispatchers/queries/QueryDispatcher';
import { HandlerExecutor } from './handlers/HandlerExecutor';
import { IHandlerExecutor } from './handlers/IHandlerExecutor';
import { HandlerExecutorLogger } from './logging/HandlerExecutorLogger';
import { IHandlerExecutorLogger } from './logging/IHandlerExecutorLogger';

export function configCqrs(container: Container): void {
    container.bind<ICommandDispatcher>(Types.COMMAND_DISPATCHER).to(CommandDispatcher);
    container.bind<IQueryDispatcher>(Types.QUERY_DISPATCHER).to(QueryDispatcher);
    container.bind<IHandlerExecutor>(Types.HANDLER_EXECUTOR).to(HandlerExecutor);
    container.bind<IExecutionHandlerProvider>(Types.EXECUTOR_HANDLER_PROVIDER).to(ExecutionHandlerProvider);
    container.bind<IHandlerExecutorLogger>(Types.HANDLER_EXECUTOR_LOGGER).to(HandlerExecutorLogger);
}
