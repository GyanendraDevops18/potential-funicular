import { Injectable } from '@angular/core';
import { HttpCommonService } from './http-common.service';
import { map } from "rxjs/operators";

@Injectable()
export class MenuService {
    constructor(
        private httpCommonService: HttpCommonService) {
    }

    getMenuList(apiName: string) {
        return this.httpCommonService.loadCollection(apiName)
            .pipe(map((responseData: MenuItem[]) => {
                return responseData.slice();
            }));
    }

    addToCart(apiName: string, model: MenuItem) {
        return this.httpCommonService.PostRequest(apiName, model)
            .pipe(map((responseData: any) => {
                return responseData;
            }));
    }
}

export interface MenuItem {
    productid: string;
    name: string;
    code: string;
    imagesrc: string;
    imagealt: string;
    type: string;
    price: number;
    qty: number;
    createddate: Date;
}
