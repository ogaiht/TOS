import { Uuid } from '../../../common/uuid';
import { ExecutionRequestWithResult, IExecutionRequestWitResult } from '../execution.request';

export interface IQuery<TResult> extends IExecutionRequestWitResult<TResult> { }

export abstract class Query<TResult> extends ExecutionRequestWithResult<TResult> implements IQuery<TResult> {
    constructor(id: Uuid = Uuid.EMPTY) {
        super(id);
    }
 }