import { Uuid } from '../../common/uuid';
import { Document } from './Document';

export class City extends Document {
    constructor(
        public name: string = '',
        public stateId: Uuid = Uuid.EMPTY,
        id: Uuid = Uuid.EMPTY
    ) {
        super(id);
    }
}