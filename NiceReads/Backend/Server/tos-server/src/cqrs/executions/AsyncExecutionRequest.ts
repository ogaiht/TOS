import { Uuid } from '../../common/uuid';
import { IAsyncExecutionRequest } from './IAsyncExecutionRequest';

export class AsyncExecutionRequest implements IAsyncExecutionRequest {
    constructor(public readonly id: Uuid = Uuid.newUuid()) { }
}
