import { Uuid } from '../../common/uuid';

export class EmployeeSkill {
    constructor(
        public skillId: Uuid = Uuid.EMPTY,
        public levelId: Uuid = Uuid.EMPTY
    ) {}
}