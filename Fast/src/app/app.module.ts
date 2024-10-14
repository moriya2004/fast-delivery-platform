import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ButtonModule } from 'primeng/button';
import { DividerModule } from 'primeng/divider';
import { CardModule } from 'primeng/card';import { AccordionModule } from 'primeng/accordion';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginCustomerComponent } from './Components/login-customer/login-customer.component';
import { SignUpCustomerComponent } from './Components/sign-up-customer/sign-up-customer.component';
import { FormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http'; 
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { FieldsetModule } from 'primeng/fieldset';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {CustomerComponent} from './Components/customer/customer.component';
import { DemoComponent } from './Components/demo/demo.component';
import { DialogModule } from 'primeng/dialog';
import { CheckboxModule } from 'primeng/checkbox';
import { TableModule } from 'primeng/table';
import { EmployeeComponent } from './Components/employee/employee.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginCustomerComponent,
    SignUpCustomerComponent,
    CustomerComponent,
    DemoComponent,
    EmployeeComponent
  ],
  imports: [
    BrowserAnimationsModule,
    FieldsetModule,
    InputGroupModule,
    InputGroupAddonModule,
    HttpClientModule,
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    ButtonModule,
    DialogModule,
    CheckboxModule,
    TableModule,
    DividerModule,AccordionModule,CardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

