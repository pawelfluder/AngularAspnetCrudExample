import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class EmployeesService {
  
  baseApiUrl: string = 'https://localhost:7066'
  //environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getAllEmployees(): Observable<Employee[]>{
    return this.http.get<Employee[]>(this.baseApiUrl + '/' + 'api' + '/' + 'employees');
  }

  addEmployee(addEmployeeRequest: Employee): Observable<Employee>
  {
    addEmployeeRequest.id = "00000000-0000-0000-0000-000000000000";
    return this.http.post<Employee>(this.baseApiUrl + '/' + 'api' + '/' + 'employees',
      addEmployeeRequest);
  }
}
