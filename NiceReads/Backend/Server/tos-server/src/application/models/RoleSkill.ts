import { Uuid } from '../../common/uuid';

export class RoleSkill {
    constructor(
        public skillId: Uuid = Uuid.EMPTY,
        public levelId: Uuid = Uuid.EMPTY
    ) { }
}