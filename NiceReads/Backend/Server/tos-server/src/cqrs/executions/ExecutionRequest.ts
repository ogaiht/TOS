import { Uuid } from '../../common/uuid';
import { IExecutionRequest } from './IExecutionRequest';

export class ExecutionRequest implements IExecutionRequest {
    constructor(public readonly id: Uuid = Uuid.newUuid()) { }

}
