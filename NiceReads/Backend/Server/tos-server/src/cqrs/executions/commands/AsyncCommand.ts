import { Uuid } from '../../../common/uuid';
import { AsyncExecutionRequest } from '../AsyncExecutionRequest';
import { ICommand } from './ICommand';

export abstract class AsyncCommand extends AsyncExecutionRequest implements ICommand {
    constructor(id: Uuid = Uuid.newUuid()) {
        super(id);
    }
}