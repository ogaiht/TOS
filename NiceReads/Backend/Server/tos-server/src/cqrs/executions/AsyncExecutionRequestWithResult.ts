import { Uuid } from '../../common/uuid';
import { AsyncExecutionRequest } from './AsyncExecutionRequest';
import { IAsyncExecutionRequestWithResult } from './IAsyncExecutionRequestWithResult';

export class AsyncExecutionRequestWithResult<TResult> extends AsyncExecutionRequest implements IAsyncExecutionRequestWithResult<TResult> {
    constructor(id: Uuid = Uuid.newUuid()) {
        super(id);
     }
}