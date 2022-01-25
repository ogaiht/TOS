import { inject, injectable } from 'inversify';
import { constr } from '../../../common/common.types';
import { Uuid } from '../../../common/uuid';
import { Repository } from '../../../data/repository';
import { IDatabase } from '../../../database/database';
import { Types } from '../../../types';
import { Employee } from '../../models/Employee';
import { IEmployeeRepository } from './IEmployeeRepository';

@injectable()
export class EmployeeRepository extends Repository<Employee, Uuid> implements IEmployeeRepository {
    constructor(@inject(Types.DATABASE) database: IDatabase<Uuid>) {
        super(database);
    }

    protected getEntityType(): constr<Employee> {
        return Employee;
    }
}