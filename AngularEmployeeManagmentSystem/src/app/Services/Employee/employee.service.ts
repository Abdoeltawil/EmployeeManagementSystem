import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmployeeModel } from '../../Models/employeeModel';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  URL = "https://localhost:7019/Employee/";
constructor(private http: HttpClient) { }

  getAllEmployees(){
    return this.http.get<EmployeeModel[]>(this.URL+'GetAll');
  }
}
