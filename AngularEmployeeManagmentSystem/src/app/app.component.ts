import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './Components/header/header.component';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './Components/employee-list/employee-list.component';
import { FooterComponent } from './Components/footer/footer.component';
import { HomeComponent } from './Components/home/home.component';
import { EmployeeService } from './Services/Employee/employee.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    CommonModule,
    HeaderComponent,
    EmployeeListComponent,
    FooterComponent,
    HomeComponent,
    

  ],
  providers:[
    HttpClient,
    EmployeeService,
    
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AngularEmployeeManagmentSystem';
}
