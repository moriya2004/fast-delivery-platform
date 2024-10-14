import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Order } from 'src/app/Models/Order';
import {Customer} from 'src/app/Models/Customer'
import { CustomerService } from 'src/app/Services/customer.service';
import { OrderService } from 'src/app/Services/order.service';


@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent {
  customer: Customer;
  orders: Order[] = [];
  name: string = ''
  order: Order = new Order();
  newOrder: Order = new Order();
  visible: boolean = false;
  visibleNewOrder: boolean = false
  visibleChangeOrder: boolean = false
  constructor(private orderService: OrderService,private customerService: CustomerService, private router: Router, ) {
    this.customer = this.customerService.customer;
    this.name = customerService.customer.name
    this.orderService.GetByCustomerId(customerService.customer.id).subscribe(
      (response) => {
        console.log('הנתונים המתקבלים:', response);
        this.orders = response;
        console.log('ההזמנות שמורות במשתנה orders:', this.orders);
      },
      (error) => {
        console.error('שגיאה בקריאה לשירות ההזמנות:', error);
      }
    );
  }
  
  changeOrder(order: Order) {
    this.order = order
    this.visibleChangeOrder = true
  }
  changeName() {
    this.visible = true
  }
  updateCustomer() {
    this.visible = false
    this.customerService.customer.name = this.name;

    // Send a PUT request to update the customer's name in the database
    this.customerService.putCustomer(this.customerService.customer.id, this.customerService.customer).subscribe(
        (response) => {
            console.log('Customer name updated successfully:', response);
        },
        (error) => {
            console.error('Error updating customer name:', error);
        }
    );
  }
  updateOrder() {
    this.visibleChangeOrder = false
    this.orderService.PutOrder(this.order.id, this.order).subscribe(
      (response) => {
          console.log('Order updated successfully:', response);
          // Optionally, you can reload the orders list after successful update
          this.loadOrders();
      },
      (error) => {
          console.error('Error updating order:', error);
      }
  );
  }
  loadOrders() {
    // Reload orders after an update
    this.orderService.GetByCustomerId(this.customerService.customer.id).subscribe(
        (response) => {
            console.log('Updated orders:', response);
            this.orders = response;
        },
        (error) => {
            console.error('Error loading updated orders:', error);
        }
    );
}
  deleteOrder(id: number) {
    this.orderService.DeleteOrder(id);
  }
  OpenNewOrder() {
    this.visibleNewOrder = true
  }
  addNewOrder(newOrder: Order) {
    // Close the dialog
    this.visibleNewOrder = false;
    this.newOrder.toAddress=newOrder.toAddress;
    this.newOrder.customerId=1;
  
    // Send a POST request to add the new order
    this.orderService.PostOrder(newOrder).subscribe({
      next: (addedOrder: any) => {
        console.log('Order added successfully:', addedOrder);
        // Reset the newOrder object
        this.newOrder = new Order();
        // Reload orders after successful addition
        this.loadOrders();
      },
      error: (error: any) => {
        console.error('Error adding order:', error);
      }
    });
  }
  
}
