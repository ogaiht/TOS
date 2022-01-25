const Data = Object.freeze({
    DATABASE: 'IDatabase',
});

const Repositories = Object.freeze({
    CITY_REPOSITORY: 'ICityRepository',
    COUNTRY_REPOSITORY: 'ICountryRepository',
    EMPLOYEE_REPOSITORY: 'IEmployeeRepository',
    PROJECT_REPOSITORY: 'IProjectRepository',
    SKILL_REPOSITORY: 'ISkillRepository',
    SKILL_LEVEL_REPOSITORY: 'ISkillLevelRepository',
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
    SCORE_CALCULATOR: 'IScoreCalculator',
    Data,
    Repositories
});

