import { Uuid } from '../../../common/uuid';
import { AsyncExecutionRequestWithResult, IAsyncExecutionRequestWithResult } from '../execution.request';

export interface IAsyncQuery<TResult> extends IAsyncExecutionRequestWithResult<TResult> { }

export abstract class AsyncQuery<TResult> extends AsyncExecutionRequestWithResult<TResult> implements IAsyncExecutionRequestWithResult<TResult> {
    constructor(id: Uuid = Uuid.EMPTY) {
        super(id);
    }
 }