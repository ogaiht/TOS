export interface IExecutionHandlerProvider {
    getHandlerFor<THandler>(handler: string, throwExceptionIfNotFound?: boolean): THandler;
}
