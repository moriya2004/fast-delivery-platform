import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Customer } from 'src/app/Models/Customer';
import { CustomerService } from 'src/app/Services/customer.service';

@Component({
  selector: 'app-sign-up-customer',
  templateUrl: './sign-up-customer.component.html',
  styleUrls: ['./sign-up-customer.component.css']
})
export class SignUpCustomerComponent {
  customer:Customer=new Customer();

  constructor(private customerService:CustomerService,private router:Router){

  }
addCustomer(){
this.customerService.postCustomer(this.customer).subscribe(a=>{ this.router.navigate(["//"])});
}
}
