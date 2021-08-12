import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeFilter } from '../models/employee-filter';
import { Employee, EmployeeSkill } from '../models/employee.model';
import { PagedResult } from '../models/filter';
import { EngagementHubApiService } from './engagement-hub-api.service';
import * as Uri from './route-uris';


@Injectable()
export class EmployeeService {

    constructor(private readonly apiService: EngagementHubApiService) { }

    public createEmployee(employee: Employee): Observable<string> {
        return this.apiService.post(Uri.EMPLOYEES, employee);
    }

    public loadEmployees(filter?: EmployeeFilter): Observable<PagedResult<Employee>> {
        return this.apiService.get(Uri.EMPLOYEES, filter);
    }

    public loadEmployee(employeeId: string): Observable<Employee> {
        return this.apiService.get([Uri.EMPLOYEES, employeeId]);
    }

    public addSkillsToEmployee(employeeId: string, employeeSkills: EmployeeSkill[]): Observable<void> {
        return this.apiService.post<EmployeeSkill[], void>([Uri.EMPLOYEES, employeeId, Uri.SKILLS], employeeSkills);
    }

    public deleteEmployee(employeeId: string): Observable<void> {
        return this.apiService.delete([Uri.EMPLOYEES, employeeId]);
    }
}
