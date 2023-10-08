import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule, CurrencyPipe } from '@angular/common';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { DisplayCustomersComponent } from './display-customers/display-customers.component';
import { AddCustomerComponent } from './add-customer/add-customer.component';
import { EditCustomerComponent } from './edit-customer/edit-customer.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    DisplayCustomersComponent,
    AddCustomerComponent,
    EditCustomerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    CommonModule,
    RouterModule.forRoot([
      { path: '', component: DisplayCustomersComponent, pathMatch: 'full' },
      { path: 'add-customer', component: AddCustomerComponent },
      { path: 'edit-customer', component: EditCustomerComponent }
    ])
  ],
  providers: [CurrencyPipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
