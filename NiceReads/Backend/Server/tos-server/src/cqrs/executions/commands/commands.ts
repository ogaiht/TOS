import { Uuid } from '../../../common/uuid';
import {
    ExecutionRequest,
    ExecutionRequestWithResult,
    IExecutionRequest,
    IExecutionRequestWitResult
 } from '../execution.request';

export interface ICommand extends IExecutionRequest {

}

export interface ICommandWithResult<TResult> extends ICommand, IExecutionRequestWitResult<TResult> {

}

export abstract class Command extends ExecutionRequest implements ICommand {
    constructor(id: Uuid = Uuid.EMPTY) {
        super(id);
    }
}

export abstract class CommandWithResult<TResult> extends ExecutionRequestWithResult<TResult> implements ICommandWithResult<TResult> {
    constructor(id: Uuid = Uuid.EMPTY) {
        super(id);
    }
}