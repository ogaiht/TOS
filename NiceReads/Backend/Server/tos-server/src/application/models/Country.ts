import { Uuid } from '../../common/uuid';
import { Document } from './Document';

export class Country extends Document {
    constructor(public name: string = '', id: Uuid = Uuid.EMPTY) {
        super(id);
    }
}