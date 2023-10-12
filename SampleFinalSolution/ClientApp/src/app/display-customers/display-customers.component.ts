import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Customer } from '../customer';
@Component({
  selector: 'app-display-customers',
  templateUrl: './display-customers.component.html',
  styleUrls: ['./display-customers.component.css']
})
export class DisplayCustomersComponent {
  public customers: Customer[] = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    http.get<Customer[]>(baseUrl + 'customer').subscribe(result => {
      this.customers = result;
    }, error => console.error(error));
  }

  public DeleteCustomer(id: string) {
    this.http.delete(this.baseUrl + 'customer/DeleteCustomer/' + id).subscribe(result => {
      debugger;
      this.http.get<Customer[]>(this.baseUrl + 'customer').subscribe(result => {
        this.customers = result;
      }, error => console.error(error));
    }, error => console.error(error));
  }

  public getEmailString(customer: Customer) {
    return "mailto:" + customer.email;
  }
}


