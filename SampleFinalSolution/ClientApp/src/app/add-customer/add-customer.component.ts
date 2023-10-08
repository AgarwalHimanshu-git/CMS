import { Component, Inject } from '@angular/core';
import { Customer } from '../customer';
import { CommonModule, CurrencyPipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-customer',
  templateUrl: '../customer.shared.html',
  styleUrls: ['../customer.shared.css']
})
export class AddCustomerComponent {
  customer: Customer = {} as Customer;
  isSubmitted = false;
  Genders = ["m", "f", "o"];
  formattedAmount: string | null = '';
  customerid: string | null = '';
  isEdit: boolean = false;
  constructor(private currencyPipe: CurrencyPipe, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute, private router: Router) {
  }

  transformAmount(element: any) {
    this.formattedAmount = this.currencyPipe.transform(this.customer.balance, '$');

    element.target.value = this.formattedAmount;
  }

  public clear() {
    this.customer = {} as Customer;
  }

  public onSubmit() {
    this.http.post<Customer>(this.baseUrl + 'customer', this.customer).subscribe(result => {
      var res = result;
      this.router.navigate(['']);
    }, error => console.error(error));
  }
}


