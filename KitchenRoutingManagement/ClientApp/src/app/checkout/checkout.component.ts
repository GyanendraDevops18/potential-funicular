import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CheckoutService, CheckoutItems } from '../services/checkout.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent {
  checkoutCollection: CheckoutItems[] = [];
  totalSum: number = 0;
  constructor(private checkoutService: CheckoutService,
    private router: Router) {

  }

  ngOnInit() {
    this.checkoutService.getCartItemList("/api/cart").subscribe(responseData => {
      this.checkoutCollection = responseData;
      this.totalSum = responseData.reduce((sum, current) => sum + (current.price * current.quantity), 0);
    });
  }

  onCheckoutItemDelete(_param: string) {
    this.checkoutService.deleteCartItem("/api/cart", _param);

    this.checkoutService.getCartItemList("/api/cart").subscribe(responseData => {
      this.checkoutCollection = responseData;
      this.totalSum = responseData.reduce((sum, current) => sum + (current.price * current.quantity), 0);
    });
  }

  onCheckout() {
    if(this.checkoutCollection.length === 0){
      return;
    }

    this.checkoutService.checkoutCart("/api/cart");
    this.router.navigate(['/order']);
  }
}
