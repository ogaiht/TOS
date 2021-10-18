import { Uuid } from '../../../common/uuid';
import { ExecutionRequest } from '../ExecutionRequest';
import { ICommand } from './ICommand';

export abstract class Command extends ExecutionRequest implements ICommand {
    constructor(id: Uuid = Uuid.newUuid()) {
        super(id);
    }
}