import { Uuid } from '../../common/uuid';
import { Document } from './Document';

export class State extends Document {
    constructor(
        public name: string = '',
        public countryId: Uuid = Uuid.EMPTY,
        id: Uuid = Uuid.EMPTY) {
            super(id);
        }
}