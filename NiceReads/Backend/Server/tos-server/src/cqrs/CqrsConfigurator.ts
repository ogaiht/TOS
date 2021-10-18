import { Container } from 'inversify';
import { Constr } from '../common/common.types';
import { AsyncCommand, AsyncCommandWithResult } from './executions/commands/async.command';
import { Command, CommandWithResult } from './executions/commands/commands';
import { AsyncQuery } from './executions/queries/async.query';
import { Query } from './executions/queries/query';
import { AsyncCommandHandler } from './handlers/commands/AsyncCommandHandler';
import { AsyncCommandWithResultHandler } from './handlers/commands/AsyncCommandWithResultHandler';
import { CommandHandler } from './handlers/commands/CommandHandler';
import { CommandWithResultHandler } from './handlers/commands/CommandWithResultHandler';
import { AsyncQueryHandler } from './handlers/queries/AsyncQueryHandler';
import { QueryHandler } from './handlers/queries/QueryHandler';

export class CqrsConfigurator {

    constructor(private readonly container: Container) {}

    static createCqrsContainer(container: Container): CqrsConfigurator {
        return new CqrsConfigurator(container);
    }

    addCommand<TCommand extends Command, THandler extends CommandHandler<TCommand>>(
        command: Constr<TCommand>,
        handler: Constr<THandler>
        ): CqrsConfigurator {
            this.container.bind<CommandHandler<TCommand>>(command.name).to(handler);
            return this;
    }

    addCommandWithResult<TCommandWithResult extends CommandWithResult<TResult>, TResult, THandler extends CommandWithResultHandler<TCommandWithResult, TResult>>(
        command: Constr<TCommandWithResult>,
        handler: Constr<THandler>
    ): CqrsConfigurator {
        this.container.bind<CommandWithResultHandler<TCommandWithResult, TResult>>(command.name).to(handler);
        return this;
    }

    addAsyncCommand<TAsyncCommand extends AsyncCommand, TAsyncHandler extends AsyncCommandHandler<TAsyncCommand>>(
        command: Constr<TAsyncCommand>,
        handler: Constr<TAsyncHandler>
        ): CqrsConfigurator {
            this.container.bind<AsyncCommandHandler<TAsyncCommand>>(command.name).to(handler);
            return this;
    }

    addAsyncCommandWithResult<TAsyncCommandWithResult extends AsyncCommandWithResult<TResult>, TResult, THandler extends AsyncCommandWithResultHandler<TAsyncCommandWithResult, TResult>>(
        command: Constr<TAsyncCommandWithResult>,
        handler: Constr<THandler>
    ): CqrsConfigurator {
        this.container.bind<AsyncCommandWithResultHandler<TAsyncCommandWithResult, TResult>>(command.name).to(handler);
        return this;
    }

    addQuery<TQuery extends Query<TResult>, TResult, THandler extends QueryHandler<TQuery, TResult>>(
        query: Constr<TQuery>,
        handler: Constr<THandler>
        ): CqrsConfigurator {
            this.container.bind<CommandHandler<TQuery>>(query.name).to(handler);
            return this;
    }

    addAsyncQuery<TAsyncQuery extends AsyncQuery<TResult>, TResult, THandler extends AsyncQueryHandler<TAsyncQuery, TResult>>(
        query: Constr<TAsyncQuery>,
        handler: Constr<THandler>
    ): CqrsConfigurator {
        this.container.bind<AsyncQueryHandler<TAsyncQuery, TResult>>(query.name).to(handler);
        return this;
    }
}