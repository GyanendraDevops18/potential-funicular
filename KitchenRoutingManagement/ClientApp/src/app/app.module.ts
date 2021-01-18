import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

// Component
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HttpCommonService } from './services/http-common.service';
import { CheckoutComponent } from './checkout/checkout.component';
import { LoadingSpinnerComponent } from './spinner/spinner.component';
import { OrderComponent } from './order/order.component';

// Service 
import { MenuService } from './services/menu.service';
import { CheckoutService } from './services/checkout.service';
import { OrderService } from './services/order.service';
import { KitchenService } from './services/kitchen.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CheckoutComponent,
    FetchDataComponent,
    LoadingSpinnerComponent,
    OrderComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'checkout', component: CheckoutComponent },
    { path: 'order', component: OrderComponent },
    { path: 'fetch-data', component: FetchDataComponent },
], { relativeLinkResolution: 'legacy' })
  ],
  providers: [
    HttpCommonService,
    MenuService,
    CheckoutService,
    OrderService,
    KitchenService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
