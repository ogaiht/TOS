import { Uuid } from '../../../common/uuid';
import { ExecutionRequestWithResult } from '../ExecutionRequestWithResult';
import { IQuery } from './IQuery';

export abstract class Query<TResult> extends ExecutionRequestWithResult<TResult> implements IQuery<TResult> {
    constructor(id: Uuid = Uuid.EMPTY) {
        super(id);
    }
 }