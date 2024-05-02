import { Component, OnInit } from '@angular/core';
import { EmployeeModel } from '../../Models/employeeModel';
import { CommonModule } from '@angular/common';
import { EmployeeService } from '../../Services/Employee/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
  standalone:true,
  imports:[CommonModule]
})
export class EmployeeListComponent implements OnInit {

  employeeList: EmployeeModel[]; 

  constructor(private employeeService :EmployeeService) {
   }

  ngOnInit() {
    this.getEmployees();
  }

  getEmployees(){
    this.employeeService.getAllEmployees().subscribe(data=>{
      this.employeeList = data ;
    }
  );
  }
}
