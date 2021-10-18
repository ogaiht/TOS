import { Uuid } from '../../common/uuid';
import { ExecutionRequest } from './ExecutionRequest';
import { IExecutionRequestWitResult } from './IExecutionRequestWitResult';

export class ExecutionRequestWithResult<TResult> extends ExecutionRequest implements IExecutionRequestWitResult<TResult> {

    constructor(id: Uuid = Uuid.newUuid()) {
        super(id);
     }
}
