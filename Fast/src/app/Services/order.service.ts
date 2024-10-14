import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Order } from '../Models/Order';
import { Observable } from 'rxjs/internal/Observable';
import { Employee } from '../Models/Employee';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }
  url = "https://localhost:7164/api/Orders";
  

  GetByCustomerId(id: number): Observable<Order[]> {
    return this.http.get<Order[]>(this.url + "/ByCustomer/" + id)
  }
  GetByEmployeeId(id: number): Observable<Order[]> {
    return this.http.get<Order[]>(this.url + "/ByEmployee/" + id)
  }
  GetOrder(id: number): Observable<Order> {
    return this.http.get<Order>(this.url + "/" + id)
  }
  PostOrder(order: Order): Observable<Order> {
    return this.http.post<Order>(this.url, order)
  }
  PutOrder(id: number, order: Order): Observable<Order> {
    return this.http.put<Order>(this.url + "/" + id, order)
  }
  DeleteOrder(id: number): Observable<Order> {
    return this.http.delete<Order>(this.url + "/" + id)
  }

}
