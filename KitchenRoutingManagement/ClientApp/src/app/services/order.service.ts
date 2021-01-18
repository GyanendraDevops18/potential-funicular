import { Injectable } from '@angular/core';
import { HttpCommonService } from './http-common.service';
import { map } from "rxjs/operators";

@Injectable()
export class OrderService {
    constructor(
        private httpCommonService: HttpCommonService) {
    }

    getOrderList(apiName: string) {
        return this.httpCommonService.loadCollection(apiName)
            .pipe(map((responseData: OrderItems[]) => {                
                return responseData.slice();
            }));
    }
}

export interface OrderItems {
    orderid: string;
    ordercheckincode: string;
    productname: string;
    quantity: number;
    price: number;
    totalsum: number;
    totalPrice: number;
    producttype: string;
    lineitemstatus: string;
}
