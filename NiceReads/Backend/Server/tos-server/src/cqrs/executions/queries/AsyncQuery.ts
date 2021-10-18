import { Uuid } from '../../../common/uuid';
import { AsyncExecutionRequestWithResult } from '../AsyncExecutionRequestWithResult';
import { IAsyncExecutionRequestWithResult } from '../IAsyncExecutionRequestWithResult';

export abstract class AsyncQuery<TResult> extends AsyncExecutionRequestWithResult<TResult> implements IAsyncExecutionRequestWithResult<TResult> {
    constructor(id: Uuid = Uuid.EMPTY) {
        super(id);
    }
 }