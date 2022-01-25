import { Uuid } from '../../../common/uuid';
import { IRepository } from '../../../data/repository';
import { Employee } from '../../models/Employee';

export interface IEmployeeRepository extends IRepository<Employee, Uuid> { }