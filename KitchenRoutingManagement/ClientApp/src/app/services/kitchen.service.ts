import { Injectable } from '@angular/core';
import { HttpCommonService } from './http-common.service';
import { map } from "rxjs/operators";

@Injectable()
export class KitchenService {
    constructor(
        private httpCommonService: HttpCommonService) {
    }

    getKitchenList(apiName: string) {
        return this.httpCommonService.loadCollection(apiName)
            .pipe(map((responseData: KitchenItems[]) => {                
                return responseData.slice();
            }));
    }
}

export interface KitchenItems {
    orderid: string;
    productname: string;
    quantity: number;
    producttype: string;
    lineitemstatus: number;
}
