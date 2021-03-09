import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  product :IProduct[] |any;

  constructor(private shopService :ShopService , private activateRoute :ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct(){
    this.shopService.getProductById(this.activateRoute.snapshot.paramMap.get('id')).subscribe( product =>{
      this.product =product;
      console.log(this.product);
    }, error =>{
      console.log(error);
    }
    );
  }

}
