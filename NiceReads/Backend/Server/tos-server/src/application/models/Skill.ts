import { Uuid } from '../../common/uuid';
import { Document } from './Document';

export class Skill extends Document {
    constructor(
        public name: string = '',
        public description: string = '',
        id: Uuid = Uuid.EMPTY
    ) {
        super(id);
    }
}