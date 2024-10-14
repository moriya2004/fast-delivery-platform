import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DividerModule } from 'primeng/divider';
import { Customer } from 'src/app/Models/Customer';
import { CustomerService } from 'src/app/Services/customer.service';


@Component({
  selector: 'app-login-customer',
  templateUrl: './login-customer.component.html',
  styleUrls: ['./login-customer.component.css']
})
export class LoginCustomerComponent {
  name: string = "";
  tz: string = "";
  customer: Customer = new Customer();
  constructor(private customerService: CustomerService, private router: Router) { }

  login() {
    this.customerService.getCustomerByTz(this.tz).subscribe(a => {
      
      (this.customer) = a;
      console.log(a);
      if (this.customer != null) {
        this.customerService.customer.id = this.customer.id;
        this.customerService.customer.name = this.customer.name;
        this.router.navigate(['/customer'])
      }
      else{
      
    }
    })
  }
  signUp() {
    this.router.navigate(['/signUp'])
  }
}

