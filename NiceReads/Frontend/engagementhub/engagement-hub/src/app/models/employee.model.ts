import { Nullable } from '../utils/nullable';

export interface Employee {
    id?: string;
    name: Name;
    dateOfBirth: Nullable<Date>;
    email: string;
}

export interface Name {
    firstName: string;
    middleName: string;
    lastName: string;
}

export interface EmployeeSkill {
    skillId: string;
    levelId: string;
}
