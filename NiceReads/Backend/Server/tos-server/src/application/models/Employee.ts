import { Uuid } from '../../common/uuid';
import { Document } from './Document';
import { EmployeeSkill } from './EmployeeSkill';
import { Name } from './Name';

export class Employee extends Document {
    constructor(
        public name: Name = new Name(),
        public dateOfBirth: Date | undefined = undefined,
        public email: string | undefined = undefined,
        public cityId: Uuid | undefined = undefined,
        public rankId: Uuid | undefined = undefined,
        public skills: EmployeeSkill[] = [],
        id: Uuid = Uuid.EMPTY
    ) {
        super(id);
    }
}