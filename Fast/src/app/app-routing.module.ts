import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginCustomerComponent } from './Components/login-customer/login-customer.component';
import {CustomerComponent} from './Components/customer/customer.component';
import { SignUpCustomerComponent } from './Components/sign-up-customer/sign-up-customer.component';


const routes: Routes = [
  { path: '', component: LoginCustomerComponent },
  { path: 'customer', component: CustomerComponent },
  { path: 'signUp', component: SignUpCustomerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

