import { Uuid } from '../../common/uuid';
import { Document } from './Document';
import { RoleSkill } from './RoleSkill';

export class Role extends Document {
    constructor(
        public name: string = '',
        public projectId: Uuid = Uuid.EMPTY,
        public description: string = '',
        public startDate: Date | undefined = undefined,
        public endDate: Date | undefined = undefined,
        public skills: RoleSkill[] = [],
        id: Uuid | undefined = undefined
    ) {
        super(id);
    }
}