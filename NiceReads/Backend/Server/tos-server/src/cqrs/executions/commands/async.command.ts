import { Uuid } from '../../../common/uuid';
import {
    AsyncExecutionRequest,
    AsyncExecutionRequestWithResult,
    IAsyncExecutionRequest,
    IAsyncExecutionRequestWithResult,
 } from '../execution.request';
import { ICommand } from './commands';

export interface IAsyncCommand extends IAsyncExecutionRequest {

}

export interface IAsyncCommandWithResult<TResult> extends IAsyncExecutionRequestWithResult<TResult> {

}


export abstract class AsyncCommand extends AsyncExecutionRequest implements ICommand {
    constructor(id: Uuid = Uuid.EMPTY) {
        super(id);
    }
}

export abstract class AsyncCommandWithResult<TResult> extends AsyncExecutionRequestWithResult<TResult> implements IAsyncCommandWithResult<TResult> {
    constructor(id: Uuid = Uuid.EMPTY) {
        super(id);
    }
}
