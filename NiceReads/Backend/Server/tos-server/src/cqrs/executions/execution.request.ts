import { constr } from '../../common/common.types';
import { Uuid } from '../../common/uuid';

export interface IExecutionRequest {
    id: Uuid;
}

export interface IExecutionRequestWitResult<TResult> {

}

export interface IAsyncExecutionRequest extends IExecutionRequest {

}

export interface IAsyncExecutionRequestWithResult<TResult> extends IAsyncExecutionRequest {

}

export class ExecutionRequest implements IExecutionRequest {
    constructor(public readonly id: Uuid = Uuid.newUuid()) { }

}

export class ExecutionRequestWithResult<TResult> extends ExecutionRequest implements IExecutionRequestWitResult<TResult> {

    constructor(id: Uuid = Uuid.newUuid()) {
        super(id);
     }
}

export class AsyncExecutionRequest implements IAsyncExecutionRequest {
    constructor(public readonly id: Uuid = Uuid.newUuid()) { }
}

export class AsyncExecutionRequestWithResult<TResult> extends AsyncExecutionRequest implements IAsyncExecutionRequestWithResult<TResult> {
    constructor(id: Uuid = Uuid.newUuid()) {
        super(id);
     }
}