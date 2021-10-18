const Data = Object.freeze({
    DATABASE: 'IDatabase',
});

const Repositories = Object.freeze({
    CITY_REPOSITORY: 'ICityRepository',
    COUNTRY_REPOSITORY: 'ICountryRepository',
    PROJECT_REPOSITORY: 'IProjectRepository',
    STATE_REPOSITORY: 'IStateRepository',
    TASK_REPOSITORY: 'ITaskRepository'
});

export const Types = Object.freeze({
    COMMAND_DISPATCHER: 'ICommandDispatcher',
    QUERY_DISPATCHER: 'IQueryDispatcher',
    HANDLER_EXECUTOR_LOGGER: 'IHandlerExecutorLogger',
    HANDLER_EXECUTOR: 'IHandlerExecutor',
    EXECUTOR_HANDLER_PROVIDER: 'IExecutionHandlerProvider',
    DATABASE: 'IDatabase',
    UUID_GENERATOR: 'IIdGenerator<Uuid>',
    CONTAINER: 'container',
    Data,
    Repositories
});

