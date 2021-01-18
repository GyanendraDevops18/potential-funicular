import { Component } from '@angular/core';
import { MenuService, MenuItem } from '../services/menu.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  menuItemCollection: MenuItem[] = [];
  isLoading = false;
  constructor(private menuService: MenuService) {

  }

  ngOnInit() {
    this.isLoading = true;
    this.menuService.getMenuList("/api/product").subscribe(responseData => {
      this.menuItemCollection = responseData;
    });
    this.isLoading = false;
  }

  onCheckout(_param: MenuItem) {
    this.isLoading = true;
    this.menuService.addToCart("/api/cart", _param).subscribe(() => { });
    this.isLoading = false;
  }
}
