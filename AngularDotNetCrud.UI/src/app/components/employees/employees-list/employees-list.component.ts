import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {
    employees: Employee[] = [
    {
      id: 'Sbd4ed4cc-f31b-444b-a@6e-05ce7b322892',
      name: 'John Doe',
      email: 'john.doe@email.com',
      phone: 998877665,
      salary: 60000,
      department: 'Human Resources'
    },
    {
      id: 'c7@5cd8b-0297-441c-af5b-102620816a70',
      name: 'Sameer Saini',
      email: 'sameer.saini@email.com',
      phone: 789789789,
      salary: 70000,
      department: 'Information Technology'
    },
    {
      id: 'c705cd8b-0297-441c-af5b-102620816a70',
      name: 'Samantha James',
      email: 'samantha.james@email.com',
      phone: 8787878787,
      salary: 80000,
      department: 'Accounts'
    }
  ];
    constructor() {}

    ngOnInit(): void {}
}
