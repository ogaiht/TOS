import { Uuid } from '../../../common/uuid';
import { ExecutionRequestWithResult } from '../ExecutionRequestWithResult';
import { ICommandWithResult } from './ICommandWithResult';

export abstract class CommandWithResult<TResult> extends ExecutionRequestWithResult<TResult> implements ICommandWithResult<TResult> {
    constructor(id: Uuid = Uuid.newUuid()) {
        super(id);
    }
}