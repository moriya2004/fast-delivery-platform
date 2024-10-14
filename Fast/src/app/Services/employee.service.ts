import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../Models/Employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  employee: Employee = new Employee()
  constructor(private http: HttpClient) {
    this.employee.Id = 4;

  }
  url = 'https://localhost:7164/api/Employees';

  getEmployee(id: number): Observable<Employee> {
    return this.http.get<Employee>(this.url + "/" + id)
  }
  putEmployee(id: number, employee: Employee): Observable<Employee> {
    return this.http.put<Employee>(this.url + "/" + id, employee)
  }
  getSalary(id: number): Observable<number> {
    return this.http.get<number>(this.url + "/salary/" + id)
  }

}
