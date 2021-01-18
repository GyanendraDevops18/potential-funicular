import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { OrderService, OrderItems } from '../services/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent {
  OrderCollection: OrderItems[] = [];
  totalSum: number = 0;
  constructor(private orderService: OrderService,
    private router: Router) {

  }

  ngOnInit() {
    this.orderService.getOrderList("/api/order").subscribe(responseData => {
      this.OrderCollection = responseData;
    });
  }
}
