import { Uuid } from '../../../common/uuid';
import { AsyncExecutionRequestWithResult } from '../AsyncExecutionRequestWithResult';
import { IAsyncCommandWithResult } from './IAsyncCommandWithResult';

export abstract class AsyncCommandWithResult<TResult> extends AsyncExecutionRequestWithResult<TResult> implements IAsyncCommandWithResult<TResult> {
    constructor(id: Uuid = Uuid.newUuid()) {
        super(id);
    }
}