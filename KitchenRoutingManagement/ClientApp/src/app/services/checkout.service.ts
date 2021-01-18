import { Injectable } from '@angular/core';
import { HttpCommonService } from './http-common.service';
import { map } from "rxjs/operators";

@Injectable()
export class CheckoutService {
    constructor(
        private httpCommonService: HttpCommonService) {
    }

    getCartItemList(apiName: string) {
        return this.httpCommonService.loadCollection(apiName)
            .pipe(map((responseData: CheckoutItems[]) => {                
                return responseData.slice();
            }));
    }

    deleteCartItem(apiName: string, model: string) {
        return this.httpCommonService.delete(apiName, model);        
    }

    checkoutCart(apiName: string) {
        return this.httpCommonService.put(apiName);        
    }
}

export interface CheckoutItems {
    orderid: string;
    ordercheckincode: string;
    productname: string;
    quantity: number;
    price: number;
    totalsum: number;
    totalPrice: number;
    producttype: string;
    lineitemstatus: number;
}
